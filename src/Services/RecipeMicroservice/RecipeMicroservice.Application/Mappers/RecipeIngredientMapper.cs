using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeIngredientMapper
    {
        public static RecipeIngredient ToEntity(this CreateRecipeIngredientDto dto, Guid recipeId) => new()
        {
            RecipeId = recipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity
        };
        public static RecipeIngredient ToEntity(this UpdateRecipeIngredientDto dto, RecipeIngredient recipeIngredient)
        {
            recipeIngredient.IngredientId = dto.IngredientId;
            recipeIngredient.UnitId = dto.UnitId;
            recipeIngredient.Quantity = dto.Quantity;
            return recipeIngredient;
        }
        public static RecipeIngredientDto ToDto(this RecipeIngredient recipeIngredient) => new()
        {
            Id = recipeIngredient.Id,
            IngredientId = recipeIngredient.IngredientId,
            UnitId = recipeIngredient.UnitId,
            Quantity = recipeIngredient.Quantity,
            RecipeName = recipeIngredient.Recipe != null ? recipeIngredient.Recipe.Name : string.Empty,
            IngredientName = recipeIngredient.Ingredient != null ? recipeIngredient.Ingredient.Name : string.Empty,
            UnitName = recipeIngredient.Unit != null ? recipeIngredient.Unit.Name : string.Empty
        };
        public static IEnumerable<RecipeIngredientDto> ToDtos(this IEnumerable<RecipeIngredient> recipeIngredients) =>
            recipeIngredients.Select(ri => ri.ToDto());
    }
}
