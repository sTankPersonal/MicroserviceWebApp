namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class RecipeIngredientDto
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        public decimal Quantity { get; set; }

        //Display Properties
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }
}
