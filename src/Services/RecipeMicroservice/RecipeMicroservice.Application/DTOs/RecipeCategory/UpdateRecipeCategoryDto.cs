
namespace RecipeMicroservice.Application.DTOs.RecipeCategory
{
    public class UpdateRecipeCategoryDto
    {
        public required Guid Id { get; set; }
        public required Guid RecipeId { get; set; }
        public required Guid CategoryId { get; set; }
    }
}
