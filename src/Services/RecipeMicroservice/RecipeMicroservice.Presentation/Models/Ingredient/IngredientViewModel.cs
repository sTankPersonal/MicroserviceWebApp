using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class IngredientViewModel : IHasEntity<IngredientViewModel, Guid>
    {
        public string Name { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public IngredientViewModel WithId(Guid id) => (Id = id, this).Item2;
    }
}
