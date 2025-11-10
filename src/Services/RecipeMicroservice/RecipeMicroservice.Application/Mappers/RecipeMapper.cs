using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeMapper
    {
        public static Recipe ToEntity(this CreateRecipeDto dto) => new()
        {
            Name = dto.Name,
            PrepTimeInMinutes = dto.PrepTimeInMinutes,
            CookTimeInMinutes = dto.CookTimeInMinutes,
            Servings = dto.Servings
        };
        public static Recipe ToEntity(this UpdateRecipeDto dto, Recipe recipe)
        {
            recipe.Name = dto.Name;
            recipe.PrepTimeInMinutes = dto.PrepTimeInMinutes;
            recipe.CookTimeInMinutes = dto.CookTimeInMinutes;
            recipe.Servings = dto.Servings;
            return recipe;
        }
        public static RecipeDto ToDto(this Recipe recipe) => new()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            PrepTimeInMinutes = recipe.PrepTimeInMinutes,
            CookTimeInMinutes = recipe.CookTimeInMinutes,
            Servings = recipe.Servings,
            Categories = recipe.RecipeCategories.Map(RecipeCategoryMapper.ToDto),
            Ingredients = recipe.RecipeIngredients.Map(RecipeIngredientMapper.ToDto),
            Instructions = recipe.RecipeInstructions.Map(RecipeInstructionMapper.ToDto),
            Photos = recipe.Photos.Map(PhotoMapper.ToDto)
        };
        //public static IEnumerable<RecipeDto> ToDtos(this IEnumerable<Recipe> recipes)
        //{
        //    return recipes.Select(r => r.ToDto());
        //}
    }
}
