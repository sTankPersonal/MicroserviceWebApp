using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeCategoryMapper
    {
        // Map CreateRecipeCategoryDto to RecipeCategory entity
        public static RecipeCategory ToEntity(this CreateRecipeCategoryDto dto, Guid recipeId) => new()
        {
            RecipeId = recipeId,
            CategoryId = dto.CategoryId
        };

        // Map UpdateRecipeCategoryDto to existing RecipeCategory entity
        public static RecipeCategory ToEntity(this UpdateRecipeCategoryDto dto, RecipeCategory recipeCategory)
        {
            recipeCategory.CategoryId = dto.CategoryId;
            return recipeCategory;
        }

        // Map RecipeCategory entity to RecipeCategoryDto
        public static RecipeCategoryDto ToDto(this RecipeCategory recipeCategory) => new()
        {
            Id = recipeCategory.Id,
            CategoryId = recipeCategory.CategoryId,
            RecipeName = recipeCategory.Recipe != null ? recipeCategory.Recipe.Name : string.Empty,
            CategoryName = recipeCategory.Category != null ? recipeCategory.Category.Name : string.Empty
        };

        // Map IEnumerable<RecipeCategory> to IEnumerable<RecipeCategoryDto>
        public static IEnumerable<RecipeCategoryDto> ToDtos(this IEnumerable<RecipeCategory> recipeCategories) => 
            recipeCategories.Select(rc => rc.ToDto());
    }
}
