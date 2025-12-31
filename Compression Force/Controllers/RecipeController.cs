using Compression_Force.Data;
using Compression_Force.Domain.Entities;
using Compression_Force.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections;


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
            var allCodes = _context.Recipes
                .Select(r => r.RecipeCode)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            var initialCode = allCodes.FirstOrDefault();
            var firstRecipe = _context.Recipes.FirstOrDefault(r => r.RecipeCode == initialCode);

            var viewModel = new RecipeParameterViewModel
            {
                AllRecipeCodes = allCodes,
                SelectedRecipe = firstRecipe
            };

            var dropdownData = BuildDropdownData(firstRecipe);
            ViewData["toolTypes"] = dropdownData.toolTypes;
            ViewData["toolTypeDisplay"] = dropdownData.toolTypeDisplay;
            ViewData["awcList"] = dropdownData.awcList;
            ViewData["awcDisplay"] = dropdownData.awcDisplay;
            ViewData["recipeList"] = dropdownData.recipeList;
            ViewData["recipeDisplay"] = dropdownData.recipeDisplay;

            ViewData["toolTypes"] = dropdownData.toolTypes;
            ViewData["toolTypeDisplay"] = dropdownData.toolTypeDisplay;
            ViewData["awcList"] = dropdownData.awcList;
            ViewData["awcDisplay"] = dropdownData.awcDisplay;

            ViewData["Title"] = "RecipeParameter";

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult GetRecipeDetails(string code)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeCode == code);
            if (recipe == null) return Json(null);
            var dropdownData = BuildDropdownData(recipe);
            return Json(new
            {
                recipeCode = recipe.RecipeCode,
                toolTypes = dropdownData.toolTypes,
                toolTypeDisplay = dropdownData.toolTypeDisplay,
                awcList = dropdownData.awcList,
                awcDisplay = dropdownData.awcDisplay,
                recipeList = dropdownData.recipeList,
                recipeDisplay = dropdownData.recipeDisplay,


                // Example product parameters (add all you need)
                forceFeederRatioS1 = dropdownData.forceFeederRatioS1,
                forceFeederRatioS1Display = dropdownData.forceFeederRatioS1Display,
                fillDepthS1 = recipe.FillDepthS1,
                mainPenetrationPositionS1 = recipe.MainPenetrationPositionS1,
                mainThicknessPositionS1 = recipe.MainThicknessPositionS1,
                prePenetrationPositionS1 = recipe.PrePenetrationPositionS1,
                preThicknessPositionS1 = recipe.PreThicknessPositionS1,
                sampleIntervalS1 = recipe.SampleIntervalS1,
                sampleRevolutionQtyS1 = recipe.SampleRevolutionQtyS1,
                maxMainCompForceS1 = recipe.MaxMainCompForceS1,
                maxPreCompForceS1 = recipe.MaxPreCompForceS1,
                maxEjectionForceS1 = recipe.MaxEjectionForceS1,
                // AWC & AR parameters
                rejectionForceLimitMaxS1 = recipe.RejectionForceLimitMaxS1,
                awcForceLimitMaxS1 = recipe.AwcForceLimitMaxS1,
                awcForceSetPointS1 = recipe.AwcForceSetPointS1,
                awcForceLimitMinS1 = recipe.AwcForceLimitMinS1,
                rejectionForceLimitMinS1 = recipe.RejectionForceLimitMinS1,

                // Example product parameters (add all you need)
                forceFeederRatioS2 = dropdownData.forceFeederRatioS2,
                forceFeederRatioS2Display = dropdownData.forceFeederRatioS2Display,
                fillDepthS2 = recipe.FillDepthS2,
                mainPenetrationPositionS2 = recipe.MainPenetrationPositionS2,
                mainThicknessPositionS2 = recipe.MainThicknessPositionS2,
                prePenetrationPositionS2 = recipe.PrePenetrationPositionS2,
                preThicknessPositionS2 = recipe.PreThicknessPositionS2,
                sampleIntervalS2 = recipe.SampleIntervalS2,
                sampleRevolutionQtyS2 = recipe.SampleRevolutionQtyS2,
                maxMainCompForceS2 = recipe.MaxMainCompForceS2,
                maxPreCompForceS2 = recipe.MaxPreCompForceS2,
                maxEjectionForceS2 = recipe.MaxEjectionForceS2,
                // AWC & AR parameters
                rejectionForceLimitMaxS2 = recipe.RejectionForceLimitMaxS2,
                awcForceLimitMaxS2 = recipe.AwcForceLimitMaxS2,
                awcForceSetPointS2 = recipe.AwcForceSetPointS2,
                awcForceLimitMinS2 = recipe.AwcForceLimitMinS2,
                rejectionForceLimitMinS2 = recipe.RejectionForceLimitMinS2
            });
        }

        private (IEnumerable<string> toolTypes, IEnumerable<string> awcList, IEnumerable<string> recipeList, IEnumerable<string> forceFeederRatioS1, IEnumerable<string> forceFeederRatioS2, string toolTypeDisplay, string awcDisplay, string recipeDisplay, string forceFeederRatioS1Display, string forceFeederRatioS2Display)
            BuildDropdownData(Recipe recipe)
        {
            IEnumerable<string> GetItems(object val)
            {
                if (val == null) return new List<string> { "" };
                if (val is string s) return new List<string> { s };
                if (val is IEnumerable enumerable)
                {
                    var list = new List<string>();
                    foreach (var item in enumerable) list.Add(item?.ToString() ?? "");
                    return list;
                }
                return new List<string> { val.ToString() };
            }

            var toolTypes = GetItems(recipe?.ToolType);
            var awcList = GetItems(new[] { "Item1", "1111" });
            var recipeList = GetItems(recipe?.RecipeName);
            var forceFeederRatioS1 = GetItems(new[] { "0.5", "1.0", "2.0" });
            var forceFeederRatioS2 = GetItems(new[] { "0.5", "1.0" });

            return (toolTypes, awcList, recipeList, forceFeederRatioS1, forceFeederRatioS2,
                    toolTypes.FirstOrDefault() ?? "",
                    awcList.FirstOrDefault() ?? "",
                    recipeList.FirstOrDefault() ?? "",
                    forceFeederRatioS1.FirstOrDefault() ?? "",
                    forceFeederRatioS2.FirstOrDefault() ?? "");
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
