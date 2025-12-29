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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UserManagements
                    .FirstOrDefaultAsync(u => u.ERname == model.Email && u.ERpassword == model.Password);

                if (user != null)
                {
                    // Store username in session
                    HttpContext.Session.SetString("UserName", user.ERname);
                    // You can also store User Level if needed
                    HttpContext.Session.SetString("UserLevel", user.ERlevel ?? "User");

                    return RedirectToAction("Welcome", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears all session data
            return RedirectToAction("Login", "Account");
        }

        /*Change password and Welcome*/
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Get current user from Session
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName)) return RedirectToAction("Login");

            // Find user in Database
            var user = await _context.UserManagements.FirstOrDefaultAsync(u => u.ERname == userName);

            if (user == null) return NotFound();

            // Verify Old Password
            if (user.ERpassword != model.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "The old password you entered is incorrect.");
                return View(model);
            }

            // Update and Save
            user.ERpassword = model.NewPassword;
            _context.Update(user);
            Console.WriteLine($"Updating user {user.ERname} password to {user.ERpassword}");
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Password updated successfully!";
            return RedirectToAction("Welcome", "Home");
        }
    }
}