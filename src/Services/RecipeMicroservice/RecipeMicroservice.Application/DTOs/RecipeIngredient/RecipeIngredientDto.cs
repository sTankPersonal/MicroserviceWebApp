namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class RecipeIngredientDto
    {
        public required Guid Id { get; set; }
        public required Guid IngredientId { get; set; }
        public required Guid UnitId { get; set; }
        public required decimal Quantity { get; set; }

        //Optional Display Fields
        public string RecipeName { get; set; } = string.Empty;
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }
}
