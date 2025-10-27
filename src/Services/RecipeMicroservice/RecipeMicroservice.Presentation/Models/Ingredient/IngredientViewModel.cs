namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public static IngredientViewModel FromDto(Application.DTOs.Ingredient.IngredientDto dto)
        {
            return new IngredientViewModel
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
