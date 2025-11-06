using RecipeMicroservice.Application.Interfaces.ViewModels;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class IngredientViewModel : IInfoViewModel<Guid>
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
    }
}
