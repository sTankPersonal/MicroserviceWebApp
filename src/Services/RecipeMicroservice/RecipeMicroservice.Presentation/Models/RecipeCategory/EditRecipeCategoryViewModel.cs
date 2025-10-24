using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class EditRecipeCategoryViewModel
    {
        public Guid RecipeId { get; set; }
        public Guid CategoryId { get; set; }

        public static EditRecipeCategoryViewModel FromDto(Application.DTOs.RecipeCategory.RecipeCategoryDto dto)
        {
            return new EditRecipeCategoryViewModel
            {
                RecipeId = dto.RecipeId,
                CategoryId = dto.CategoryId
            };
        }
    }
}
