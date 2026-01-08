using Microsoft.AspNetCore.Mvc;
using CompressionForce.Data;
using CompressionForce.Models;
using Microsoft.EntityFrameworkCore;
using CompressionForce.Web.Models;
using CompressionForce.Domain.Entities;

namespace CompressionForce.WebControllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        /* ===================== LOGIN ===================== */

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var input = model.Email.Trim();

            // 🔍 LOGIN BY USERNAME OR EMAIL
            var user = await _context.UserManagements
                .FirstOrDefaultAsync(u =>
                    u.ERemail == input.ToLower() ||
                    u.ERname == input
                );

            if (user == null || string.IsNullOrWhiteSpace(user.ERpassword))
            {
                ModelState.AddModelError("", "Invalid username/email or password");
                return View(model);
            }

            // 🔴 DEACTIVATED USER
            if (!user.IsActive)
            {
                ModelState.AddModelError("", "Your account is deactivated. Contact administrator.");
                return View(model);
            }

            // 🔐 ACCOUNT LOCKED → SHOW REMAINING TIME
            if (user.LockedUntil != null && user.LockedUntil > DateTime.UtcNow)
            {
                var remaining = user.LockedUntil.Value - DateTime.UtcNow;

                var minutes = Math.Max(0, remaining.Minutes);
                var seconds = Math.Max(0, remaining.Seconds);

                ModelState.AddModelError("",
                    $"Account locked due to multiple failed attempts. Try again after {minutes} min {seconds} sec.");

                return View(model);
            }

            bool passwordValid;
            try
            {
                passwordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.ERpassword);
            }
            catch
            {
                ModelState.AddModelError("", "Invalid username/email or password");
                return View(model);
            }

            // ❌ WRONG PASSWORD
            if (!passwordValid)
            {
                var settings = await _context.SecuritySettings.FirstOrDefaultAsync();

                user.FailedLoginAttempts++;

                if (settings != null &&
                    user.FailedLoginAttempts >= settings.MaxWrongAttempts)
                {
                    // 🔒 LOCK ACCOUNT (30 MINUTES)
                    user.LockedUntil = DateTime.UtcNow.AddMinutes(30);
                }

                await _context.SaveChangesAsync();

                ModelState.AddModelError("", "Invalid username/email or password");
                return View(model);
            }

            // 🔁 PASSWORD EXPIRED → FORCE CHANGE
            if (user.ExpiryDate != null && user.ExpiryDate < DateTime.UtcNow)
            {
                HttpContext.Session.SetString("UserName", user.ERname);
                return RedirectToAction("ChangePassword");
            }

            // ✅ SUCCESS LOGIN
            user.FailedLoginAttempts = 0;
            user.LockedUntil = null;
            user.LastLoginDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("UserName", user.ERname);
            HttpContext.Session.SetString("UserLevel", user.ERlevel ?? "User");

            // 🔑 REQUIRED FOR APPLICATION TIMEOUT
            HttpContext.Session.SetString(
                "LastActivity",
                DateTime.UtcNow.ToString("O")
            );

            return RedirectToAction("Welcome", "Home");
        }

        /* ===================== REGISTER ===================== */

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var email = model.Email.Trim().ToLower();
            var username = model.UserName.Trim();

            if (await _context.UserManagements.AnyAsync(u => u.ERemail == email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            if (await _context.UserManagements.AnyAsync(u => u.ERname == username))
            {
                ModelState.AddModelError("UserName", "Username already exists");
                return View(model);
            }

            var settings = await _context.SecuritySettings.FirstOrDefaultAsync();

            var user = new UserManagement
            {
                ERname = username,
                ERemail = email,
                ERpassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
                ERlevel = string.IsNullOrWhiteSpace(model.Role) ? "User" : model.Role,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(
                    settings?.PasswordExpiryDays ?? 90
                ),
                FailedLoginAttempts = 0,
                LockedUntil = null
            };

            _context.UserManagements.Add(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Signup successful. Please login.";
            return RedirectToAction("Login");
        }

        /* ===================== CHANGE PASSWORD ===================== */

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Login");

            var user = await _context.UserManagements
                .FirstOrDefaultAsync(u => u.ERname == userName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            if (!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.ERpassword))
            {
                ModelState.AddModelError("OldPassword", "Old password is incorrect");
                return View(model);
            }

            var settings = await _context.SecuritySettings.FirstOrDefaultAsync();

            user.ERpassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            user.ExpiryDate = DateTime.UtcNow.AddDays(
                settings?.PasswordExpiryDays ?? 90
            );

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Password changed successfully";
            return RedirectToAction("Welcome", "Home");
        }

        /* ===================== LOGOUT ===================== */

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
