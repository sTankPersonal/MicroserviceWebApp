
namespace RecipeMicroservice.Application.DTOs.RecipeCategory
{
    public class UpdateRecipeCategoryDto
    {
        public required Guid Id { get; set; }
        public required Guid CategoryId { get; set; }

        //Optional Display Fields
        public string CategoryName { get; set; } = string.Empty;
    }
}
