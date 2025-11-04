namespace RecipeMicroservice.Application.DTOs.Ingredient
{
    public class UpdateIngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
