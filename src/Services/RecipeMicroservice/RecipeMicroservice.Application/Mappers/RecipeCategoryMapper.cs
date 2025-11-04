using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeCategoryMapper
    {
        public static RecipeCategory ToEntity(this CreateRecipeCategoryDto dto) => new()
        {
        };
        public static RecipeCategory ToEntity(this UpdateRecipeCategoryDto dto, RecipeCategory recipeCategory)
        {
            return recipeCategory;
        }
        public static RecipeCategoryDto ToDto(this RecipeCategory recipeCategory) => new()
        {
            Id = recipeCategory.Id,
            RecipeId = recipeCategory.RecipeId,
            CategoryId = recipeCategory.CategoryId,
            CategoryName = recipeCategory.Category != null ? recipeCategory.Category.Name : string.Empty
        };
        public static IEnumerable<RecipeCategoryDto> ToDtos(this IEnumerable<RecipeCategory> recipeCategories) => 
            recipeCategories.Select(rc => rc.ToDto());
    }
}
