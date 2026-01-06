using Compression_Force.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ================= SERVICES =================

// IHttpContextAccessor (used in controllers + middleware)
builder.Services.AddHttpContextAccessor();

// PostgreSQL DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// MVC
builder.Services.AddControllersWithViews();

// Session (fallback timeout – real timeout handled by middleware)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1); // keep large
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ================= PIPELINE =================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ SESSION FIRST
app.UseSession();

// ================= 🔐 APPLICATION TIMEOUT MIDDLEWARE =================
app.Use(async (context, next) =>
{
    var username = context.Session.GetString("UserName");

    if (!string.IsNullOrEmpty(username))
    {
        // Resolve DbContext via RequestServices (CORRECT WAY)
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

            // ✅ Update activity timestamp
            context.Session.SetString(
                "LastActivity",
                DateTime.UtcNow.ToString("O")
            );
        }
    }

    await next();
});

app.UseAuthorization();

// ================= ROUTES =================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}"
);

app.Run();
