using CompressionForce.Data;
using CompressionForce.Services.Audit;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

// ===================== SERVICES =====================

// ✅ IHttpContextAccessor (needed for Session + AuditLogger)
builder.Services.AddHttpContextAccessor();

// ✅ PostgreSQL DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ✅ Audit Logger (CRITICAL)
builder.Services.AddScoped<AuditLogger>();

// ✅ MVC
builder.Services.AddControllersWithViews();

// ✅ Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1); // handled by middleware
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ===================== PIPELINE =====================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ SESSION MUST COME BEFORE CUSTOM MIDDLEWARE
app.UseSession();

// ===================== 🔐 APPLICATION TIMEOUT MIDDLEWARE =====================
app.Use(async (context, next) =>
{
    var username = context.Session.GetString("UserName");

    if (!string.IsNullOrEmpty(username))
    {
        var db = context.RequestServices.GetRequiredService<ApplicationDbContext>();
        var settings = await db.SecuritySettings.FirstOrDefaultAsync();

        if (settings != null && settings.ApplicationTimeoutMinutes > 0)
        {
            var lastActivityStr = context.Session.GetString("LastActivity");

            if (!string.IsNullOrEmpty(lastActivityStr) &&
                DateTime.TryParse(lastActivityStr, out var lastActivity))
            {
                var idleMinutes =
                    (DateTime.UtcNow - lastActivity).TotalMinutes;

                if (idleMinutes > settings.ApplicationTimeoutMinutes)
                {
                    // ⛔ SESSION TIMEOUT
                    context.Session.Clear();
                    context.Response.Redirect("/Account/Login");
                    return;
                }
            }

            // ✅ Update last activity timestamp (UTC)
            context.Session.SetString(
                "LastActivity",
                DateTime.UtcNow.ToString("O")
            );
        }
    }

    await next();
});

app.UseAuthorization();

// ===================== ROUTES =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}"
);

Rotativa.AspNetCore.RotativaConfiguration.Setup(
    app.Environment.WebRootPath,
    "Rotativa"
);


app.Run();
