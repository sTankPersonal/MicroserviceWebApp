namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class RecipeCategoryViewModel
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid CategoryId { get; set; }

        // Display Properties
        public string CategoryName { get; set; } = string.Empty;

        public static RecipeCategoryViewModel FromDto(Application.DTOs.RecipeCategory.RecipeCategoryDto dto)
        {
            return new RecipeCategoryViewModel
            {
                Id = dto.Id,
                RecipeId = dto.RecipeId,
                CategoryId = dto.CategoryId,
                CategoryName = dto.CategoryName
            };
        }
    }
}
