
using CompressionForce.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompressionForce.Web.Models.Recipes
{
    public class EditRecipeVm
    {
        [Required, MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public List<RecipeParameter> Parameters { get; set; } = new();

        public List<string> ToolTypes { get; set; } = new();
        public List<string> Treatments { get; set; } = new();

        public List<string> AWC_ARTypes { get; set; } = new();
        public List<string> ForceFeederRatioS1Types { get; set; } = new();
        public List<string> ForceFeederRatioS2Types { get; set; } = new();
        public List<string> RecipeTypes { get; set; } = new();
    }
}
