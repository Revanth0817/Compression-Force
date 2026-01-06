using Compression_Force.Data;
using Microsoft.EntityFrameworkCore;

public class SecurityTimeoutMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityTimeoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ApplicationDbContext db)
    {
        // Ignore login page
        var path = context.Request.Path.Value?.ToLower();
        if (path!.Contains("/account/login"))
        {
            await _next(context);
            return;
        }

        var username = context.Session.GetString("UserName");

        if (!string.IsNullOrEmpty(username))
        {
            var settings = await db.SecuritySettings.FirstOrDefaultAsync();

            if (settings != null)
            {
                var lastActivityStr = context.Session.GetString("LastActivity");

                if (!string.IsNullOrEmpty(lastActivityStr))
                {
                    var lastActivity = DateTime.Parse(lastActivityStr);
                    var idleMinutes = (DateTime.UtcNow - lastActivity).TotalMinutes;

                    if (idleMinutes >= settings.ApplicationTimeoutMinutes)
                    {
                        // ⛔ FORCE LOGOUT
                        context.Session.Clear();
                        context.Response.Redirect("/Account/Login?timeout=true");
                        return;
                    }
                }

                // ✅ UPDATE ACTIVITY
                context.Session.SetString(
                    "LastActivity",
                    DateTime.UtcNow.ToString("O")
                );
            }
        }

        await _next(context);
    }
}
