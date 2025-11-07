namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class IngredientViewModel : BaseIdViewModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
