using CompressionForce.Data;
using CompressionForce.Domain.Validation;
using CompressionForce.Services.Lookups;
using CompressionForce.Services.Recipes;
using CompressionForce.Services.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// To use @inject IHttpContextAccessor in your view
builder.Services.AddHttpContextAccessor();

// ✅ CHANGE HERE: SQL Server → PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
//builder.Services.AddControllersWithViews();

// Domain validation
builder.Services.AddScoped<IRecipeValidator, RecipeRulesValidator>();

// Services
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<LookupRecipeValidator>();

// Add Session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Use Session (must be placed before MapControllerRoute)
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=OperationMode}/{id?}");

app.Run();
