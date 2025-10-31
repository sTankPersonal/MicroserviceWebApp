using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeIngredientMapper
    {
        public static RecipeIngredient ToEntity(this CreateRecipeIngredientDto dto)
        {
            return new RecipeIngredient
            {
                UnitId = dto.UnitId,
                Quantity = dto.Quantity
            };
        }
        public static RecipeIngredientDto ToDto(this RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientDto
            {
                Id = recipeIngredient.Id,
                RecipeId = recipeIngredient.RecipeId,
                IngredientId = recipeIngredient.IngredientId,
                UnitId = recipeIngredient.UnitId,
                Quantity = recipeIngredient.Quantity,
                IngredientName = recipeIngredient.Ingredient != null ? recipeIngredient.Ingredient.Name : string.Empty,
                UnitName = recipeIngredient.Unit != null ? recipeIngredient.Unit.Name : string.Empty
            };
        }
        public static IEnumerable<RecipeIngredientDto> ToDtos(this IEnumerable<RecipeIngredient> recipeIngredients)
        {
            return recipeIngredients.Select(ri => ri.ToDto());
        }
    }
}
