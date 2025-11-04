using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeMapper
    {
        public static Recipe ToEntity(this CreateRecipeDto dto)
        {
            return new Recipe
            {
                Name = dto.Name,
                PrepTimeInMinutes = dto.PrepTimeInMinutes,
                CookTimeInMinutes = dto.CookTimeInMinutes,
                Servings = dto.Servings
            };
        }
        public static Recipe ToEntity(this UpdateRecipeDto dto, Recipe recipe)
        {
            recipe.Name = dto.Name;
            recipe.PrepTimeInMinutes = dto.PrepTimeInMinutes;
            recipe.CookTimeInMinutes = dto.CookTimeInMinutes;
            recipe.Servings = dto.Servings;
            return recipe;
        }
        public static RecipeDto ToDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeInMinutes = recipe.PrepTimeInMinutes,
                CookTimeInMinutes = recipe.CookTimeInMinutes,
                Servings = recipe.Servings,
                Instructions = [.. recipe.RecipeInstructions.Select(ri => ri.ToDto())],
                Ingredients = [.. recipe.RecipeIngredients.Select(ri => ri.ToDto())],
                Categories = [.. recipe.RecipeCategories.Select(rc => rc.ToDto())],
                Photos = [.. recipe.Photos.Select(p => p.ToDto())]
            };
        }
        public static IEnumerable<RecipeDto> ToDtos(this IEnumerable<Recipe> recipes)
        {
            return recipes.Select(r => r.ToDto());
        }
    }
}
