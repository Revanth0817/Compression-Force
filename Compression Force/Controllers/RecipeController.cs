using Compression_Force.Data;
using Compression_Force.Domain.Entities;
using Compression_Force.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Compression_Force.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /* =======================
           Recipe Pages
           ======================= */

        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }

        public IActionResult DeleteRecipe()
        {
            return View();
        }

        public IActionResult EditRecipe()
        {
            return View();
        }

        /* =======================
           Recipe Parameter Page
           ======================= */

        [HttpGet]
        public IActionResult RecipeParameter()
        {
            var allCodes = _context.Recipes
                .Where(r => r.RecipeCode != null)
                .Select(r => r.RecipeCode!)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            string? initialCode = allCodes.FirstOrDefault();

            Recipe? firstRecipe = null;

            if (!string.IsNullOrEmpty(initialCode))
            {
                firstRecipe = _context.Recipes
                    .AsNoTracking()
                    .FirstOrDefault(r => r.RecipeCode == initialCode);
            }

            var viewModel = new RecipeParameterViewModel
            {
                AllRecipeCodes = allCodes,
                SelectedRecipe = firstRecipe   // ✅ NO WARNING
            };

            return View(viewModel);
        }

        /* =======================
           AJAX APIs
           ======================= */

        [HttpGet]
        public IActionResult GetRecipeDetails(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest("Invalid recipe code");

            var recipe = _context.Recipes
                .AsNoTracking()
                .FirstOrDefault(r => r.RecipeCode == code);

            if (recipe == null)
                return NotFound();

            return Json(recipe);
        }

        [HttpGet]
        public IActionResult CheckCodeExists(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Json(new { exists = false });

            var exists = _context.Recipes.Any(r => r.RecipeCode == code);
            return Json(new { exists });
        }

        /* =======================
           Add Recipe Logic
           ======================= */

        [HttpPost]
        public IActionResult PrepareAdd(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                TempData["ErrorMessage"] = "Recipe code cannot be empty.";
                return RedirectToAction(nameof(RecipeParameter));
            }

            var exists = _context.Recipes.Any(r => r.RecipeCode == code);

            if (exists)
            {
                TempData["ErrorMessage"] = $"Recipe code '{code}' already exists.";
                return RedirectToAction(nameof(RecipeParameter));
            }

            TempData["NewRecipeCode"] = code;
            return RedirectToAction(nameof(AddRecipe));
        }

        [HttpPost]
        public IActionResult SaveNewRecipe(Recipe model)
        {
            if (!ModelState.IsValid)
                return View("AddRecipe", model);

            model.DateTime = DateTime.Now;

            _context.Recipes.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(RecipeParameter));
        }
    }
}
