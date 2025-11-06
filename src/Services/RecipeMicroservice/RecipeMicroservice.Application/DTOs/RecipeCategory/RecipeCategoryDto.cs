namespace RecipeMicroservice.Application.DTOs.RecipeCategory
{
    public class RecipeCategoryDto
    {
        public required Guid Id { get; set; }
        public required Guid CategoryId { get; set; }

        //Optional Display Fields
        public string RecipeName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
