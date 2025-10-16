namespace RecipeService.Application.DTOs.RecipeIngredient
{
    public class RecipeIngredientDto
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string UnitName { get; set; } = string.Empty;
    }
}
