namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class UpdateRecipeIngredientDto
    {
        public Guid UnitId { get; set; }
        public decimal Quantity { get; set; }
    }
}
