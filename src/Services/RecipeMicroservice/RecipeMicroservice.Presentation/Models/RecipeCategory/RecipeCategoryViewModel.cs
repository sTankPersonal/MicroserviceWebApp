using RecipeMicroservice.Application.DTOs.RecipeCategory;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class RecipeCategoryViewModel
    {
        public Guid RecipeId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public static RecipeCategoryViewModel FromDto(RecipeCategoryDto dto)
        {
            return new RecipeCategoryViewModel
            {
                RecipeId = dto.RecipeId,
                CategoryId = dto.CategoryId,
                CategoryName = dto.CategoryName
            };
        }
    }
}
