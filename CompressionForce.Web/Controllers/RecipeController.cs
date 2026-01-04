using CompressionForce.Data;
using CompressionForce.Data.Entities;
using CompressionForce.Domain.Entities;
using CompressionForce.Web.Models;
using CompressionForce.Services.Recipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections;


using CompressionForce.Web.DTOs;
using CompressionForce.Web.Mapping;

namespace CompressionForce.WebControllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // Requirement 0: List recipe codes
        [HttpGet("codes")]
        public async Task<IActionResult> GetRecipeCodes()
        {
            var codes = await _recipeService.GetRecipeCodesAsync();
            return Ok(codes);
        }

        // Requirement 1: Get recipe by code
        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var recipe = await _recipeService.GetByCodeAsync(code);
            if (recipe == null)
                return NotFound();

            return Ok(RecipeDtoMapper.ToDto(recipe));
        }

        // Requirements 2–5: Add recipe
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipeDto dto)
        {
            var recipe = RecipeDtoMapper.ToDomain(dto);
            await _recipeService.AddAsync(recipe, User.Identity?.Name ?? "system");
            return Ok();
        }

        // Requirements 6–8: Update recipe
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecipeDto dto)
        {
            var recipe = RecipeDtoMapper.ToDomain(dto);
            await _recipeService.UpdateAsync(recipe, User.Identity?.Name ?? "system");
            return Ok();
        }

        // Requirements 9–10: Delete recipe
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _recipeService.DeleteAsync(code, User.Identity?.Name ?? "system");
            return Ok();
        }
    }

}
