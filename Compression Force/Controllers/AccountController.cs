using Microsoft.AspNetCore.Mvc;
using Compression_Force.Data;
using Compression_Force.Models;
using Microsoft.EntityFrameworkCore;

namespace Compression_Force.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        /* =====================
           Login
           ===================== */

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.UserManagements
                .FirstOrDefaultAsync(u =>
                    u.ERname == model.Email &&
                    u.ERpassword == model.Password);

            if (user == null || string.IsNullOrEmpty(user.ERname))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // ✅ FIX: Guarantee non-null values for Session
            HttpContext.Session.SetString("UserName", user.ERname);
            HttpContext.Session.SetString("UserLevel", user.ERlevel ?? "User");

            return RedirectToAction("Welcome", "Home");
        }

        /* =====================
           Logout
           ===================== */

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        /* =====================
           Change Password
           ===================== */

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
                return NotFound();

            if (user.ERpassword != model.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "The old password you entered is incorrect.");
                return View(model);
            }

            user.ERpassword = model.NewPassword;
            _context.Update(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Password updated successfully!";
            return RedirectToAction("Welcome", "Home");
        }
    }
}
