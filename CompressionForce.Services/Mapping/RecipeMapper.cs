using CompressionForce.Data.Entities;
using CompressionForce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompressionForce.Services.Mapping
{
    /// <summary>
    /// Maps between EF entities and domain models.
    /// </summary>
    public static class RecipeMapper
    {
        public static Recipe ToDomain(RecipeEntity entity)
        {
            var parameters = JsonSerializer
                .Deserialize<List<RecipeParameter>>(entity.Parameters)
                ?? new List<RecipeParameter>();

            return new Recipe(
                entity.RecipeCode,
                entity.RecipeName,
                parameters);
        }

        public static RecipeEntity ToEntity(Recipe recipe)
        {
            return new RecipeEntity
            {
                RecipeCode = recipe.Code,
                RecipeName = recipe.Name,
                Parameters = JsonSerializer.Serialize(recipe.Parameters)
            };
        }
    }

}
