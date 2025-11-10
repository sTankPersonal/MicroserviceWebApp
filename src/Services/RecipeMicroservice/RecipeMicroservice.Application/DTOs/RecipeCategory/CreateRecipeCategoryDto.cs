namespace RecipeMicroservice.Application.DTOs.RecipeCategory
{
    public class CreateRecipeCategoryDto
    {
        public required Guid RecipeId { get; set; }
        public required Guid CategoryId { get; set; }
    }
}
