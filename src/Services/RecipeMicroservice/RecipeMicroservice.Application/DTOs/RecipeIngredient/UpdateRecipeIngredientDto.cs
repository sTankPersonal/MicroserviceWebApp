namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class UpdateRecipeIngredientDto
    {
        public required Guid Id { get; set; }
        public required Guid RecipeId { get; set; }
        public required Guid IngredientId { get; set; }
        public required Guid UnitId { get; set; }
        public required decimal Quantity { get; set; }
    }
}
