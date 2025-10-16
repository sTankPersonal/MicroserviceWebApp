namespace RecipeService.Application.DTOs.RecipeIngredient
{
    public class CreateRecipeIngredientDto
    {
        public Guid UnitId { get; set; }
        public decimal Quantity { get; set; }
    }
}
