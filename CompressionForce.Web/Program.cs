
using CompressionForce.Data;
using CompressionForce.Domain.Validation;
using CompressionForce.Services.Lookups;
using CompressionForce.Services.Recipes;
using CompressionForce.Services.Validation;
using CompressionForce.Web.ModelBinding;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// Configuration sources
// -----------------------------------------------------------------------------
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Load JSON validation config from output directory (Services should copy the file)
builder.Configuration.AddJsonFile(
    Path.Combine(AppContext.BaseDirectory, "recipe-validation.json"),
    optional: false,
    reloadOnChange: true);

// -----------------------------------------------------------------------------
// Services (DI)
// -----------------------------------------------------------------------------

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Options binding (configurable validation)
builder.Services.Configure<RecipeValidationConfig>(builder.Configuration);

// Config provider + validators
builder.Services.AddSingleton<IRecipeValidationConfigProvider, JsonRecipeValidationConfigProvider>();
builder.Services.AddScoped<ConfigRecipeValidator>();

// Domain validation
builder.Services.AddScoped<IRecipeValidator, RecipeRulesValidator>();
builder.Services.AddScoped<LookupRecipeValidator>();

// Application services
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddHttpContextAccessor();
// MVC & Razor (uncomment runtime compilation if you want hot reload of views in dev)
// builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services
    .AddControllersWithViews(
options =>
{
    options.ModelBinderProviders.Insert(0, new RecipeParameterModelBinderProvider());
}
)
    .AddSessionStateTempDataProvider(); // uses Session for TempData

// Add a distributed cache (in-memory for dev)
builder.Services.AddDistributedMemoryCache();

// Add Session
builder.Services.AddSession(options =>
{
    // Customize as needed
    options.IdleTimeout = TimeSpan.FromMinutes(30); // session timeout
    options.Cookie.HttpOnly = true;                 // mitigate XSS
    options.Cookie.IsEssential = true;              // required for GDPR scenarios
    options.Cookie.Name = ".CompressionForce.Session";
});

var app = builder.Build();

// -----------------------------------------------------------------------------
// Middleware pipeline
// -----------------------------------------------------------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // add Views/Shared/Error.cshtml if needed
    app.UseHsts();
}
else
{
    // In dev you can also see detailed exceptions:
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
// Uncomment if you use authentication/authorization
// app.UseAuthentication();
app.UseAuthorization();

// -----------------------------------------------------------------------------
// Routing
// -----------------------------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Recipe}/{action=RecipeParameter}/{id?}");

// If you have areas, add area routes too:
// app.MapControllerRoute(
//     name: "areas",
//     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
