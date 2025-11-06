namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class CreateRecipeIngredientDto
    {
        public required Guid IngredientId { get; set; }
        public required Guid UnitId { get; set; }
        public required decimal Quantity { get; set; }
    }
}
