using Compression_Force.Data;
using Compression_Force.Domain.Entities;
using Compression_Force.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Compression_Force.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*Recipe Pages*/
        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }
        //public IActionResult AddRecipe2()
        //{
        //    return View();
        //}

        /*Delete Recipe page*/
        public IActionResult DeleteRecipe()
        {
            return View();
        }

        /*Edit Recipe*/
        public IActionResult EditRecipe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RecipeParameter()
        {
            var allCodes = _context.Recipes.Select(r => r.RecipeCode).Distinct().OrderBy(c => c).ToList();

            // Get the first recipe in the list as the default display
            var initialCode = allCodes.FirstOrDefault();
            var firstRecipe = _context.Recipes.FirstOrDefault(r => r.RecipeCode == initialCode);

            var viewModel = new RecipeParameterViewModel
            {
                AllRecipeCodes = allCodes,
                SelectedRecipe = firstRecipe
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetRecipeDetails(string code)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeCode == code);
            if (recipe == null) return NotFound();

            // Returns the full database row as a JSON object
            return Json(recipe);
        }

        [HttpGet]
        public IActionResult CheckCodeExists(string code)
        {
            var exists = _context.Recipes.Any(r => r.RecipeCode == code);
            return Json(new { exists = exists });
        }

        /// <summary>
        /// Logic for the "Add Recipe" Modal submission
        /// </summary>
        [HttpPost]
        public IActionResult PrepareAdd(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                TempData["ErrorMessage"] = "Recipe code cannot be empty.";
                return RedirectToAction("RecipeParameter");
            }

            // Check database for existing Recipe_code
            var exists = _context.Recipes.Any(r => r.RecipeCode == code);

            if (exists)
            {
                TempData["ErrorMessage"] = $"Recipe code '{code}' already exists.";
                return RedirectToAction("RecipeParameter");
            }

            // Success: Pass the code to the Add page via TempData
            TempData["NewRecipeCode"] = code;
            return RedirectToAction("AddRecipe");
        }

/*
        [HttpGet]
        public IActionResult AddRecipe()
        {
            var code = TempData["NewRecipeCode"] as string;

            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("RecipeParameter");
            }

            // Initialize model with the code and current timestamp
            var model = new Recipe
            {
                RecipeCode = code,
                DateTime = DateTime.Now
            };

            return View(model);
        }
*/
       /* [HttpGet]
        public IActionResult AddRecipe(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("RecipeParameter");
            }

            // Initialize the model with the code provided from the modal
            var model = new Recipe
            {
                RecipeCode = code,
                DateTime = DateTime.Now
            };

            return View(model);
        }*/

        [HttpPost]
        public IActionResult SaveNewRecipe(Recipe model)
        {
            if (ModelState.IsValid)
            {
                _context.Recipes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("RecipeParameter");
            }

            return View("AddRecipe", model);
        }
    }
}
