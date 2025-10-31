using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeCategoryMapper
    {
        public static RecipeCategory ToEntity(this CreateRecipeCategoryDto dto)
        {
            return new RecipeCategory
            {
            };
        }
        public static RecipeCategoryDto ToDto(this RecipeCategory recipeCategory)
        {
            return new RecipeCategoryDto
            {
                Id = recipeCategory.Id,
                RecipeId = recipeCategory.RecipeId,
                CategoryId = recipeCategory.CategoryId,
                CategoryName = recipeCategory.Category != null ? recipeCategory.Category.Name : string.Empty
            };
        }
        public static IEnumerable<RecipeCategoryDto> ToDtos(this IEnumerable<RecipeCategory> recipeCategories)
        {
            return recipeCategories.Select(rc => rc.ToDto());
        }
    }
}
