namespace RecipeMicroservice.Application.DTOs.RecipeCategory
{
    public class RecipeCategoryDto
    {
        public Guid Id { get; set; }
		public Guid RecipeId { get; set; }
        public Guid CategoryId { get; set; }
        //Display Properties
        public string CategoryName { get; set; } = string.Empty;
    }
}
