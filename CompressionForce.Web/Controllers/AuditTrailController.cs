using Microsoft.AspNetCore.Mvc;
using CompressionForce.Data;
using CompressionForce.Domain.Entities;
using System;
using System.Linq;

namespace CompressionForce.Controllers
{
    public class AuditTrailController : Controller
    {
        private readonly ApplicationDbContext _context;

        // 🔹 Constructor
        public AuditTrailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Audit Trail Page
        // URL: /AuditTrail/AuditTrail
        public IActionResult AuditTrail(string userName, string activity)
        {
            // 1️⃣ Base query
            var query = _context.AuditTrails.AsQueryable();

            // 2️⃣ Filter by User Name
            if (!string.IsNullOrEmpty(userName) && userName != "None")
            {
                query = query.Where(x => x.UserName == userName);
            }

            // 3️⃣ Filter by Activity
            if (!string.IsNullOrEmpty(activity) && activity != "None")
            {
                query = query.Where(x => x.Activity == activity);
            }

            // 4️⃣ Fetch filtered audit data
            var auditList = query
                            .OrderByDescending(x => x.DateTime)
                            .ToList();

            // 5️⃣ Fetch distinct User Names for dropdown
            ViewBag.Users = _context.AuditTrails
                                    .Where(x => x.UserName != null)
                                    .Select(x => x.UserName)
                                    .Distinct()
                                    .OrderBy(x => x)
                                    .ToList();

            // 6️⃣ Fetch distinct Activities for dropdown
            ViewBag.Activities = _context.AuditTrails
                                         .Where(x => x.Activity != null)
                                         .Select(x => x.Activity)
                                         .Distinct()
                                         .OrderBy(x => x)
                                         .ToList();

            // 7️⃣ Send data to View
            return View(auditList);
        }
    }
}
