using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeIngredientMapper
    {
        public static RecipeIngredient ToEntity(this CreateRecipeIngredientDto dto) => new()
        {
            UnitId = dto.UnitId,
            Quantity = dto.Quantity
        };
        public static RecipeIngredient ToEntity(this UpdateRecipeIngredientDto dto, RecipeIngredient recipeIngredient)
        {
            recipeIngredient.UnitId = dto.UnitId;
            recipeIngredient.Quantity = dto.Quantity;
            return recipeIngredient;
        }
        public static RecipeIngredientDto ToDto(this RecipeIngredient recipeIngredient) => new()
        {
            Id = recipeIngredient.Id,
            RecipeId = recipeIngredient.RecipeId,
            IngredientId = recipeIngredient.IngredientId,
            UnitId = recipeIngredient.UnitId,
            Quantity = recipeIngredient.Quantity,
            IngredientName = recipeIngredient.Ingredient != null ? recipeIngredient.Ingredient.Name : string.Empty,
            UnitName = recipeIngredient.Unit != null ? recipeIngredient.Unit.Name : string.Empty
        };
        public static IEnumerable<RecipeIngredientDto> ToDtos(this IEnumerable<RecipeIngredient> recipeIngredients) =>
            recipeIngredients.Select(ri => ri.ToDto());
    }
}
