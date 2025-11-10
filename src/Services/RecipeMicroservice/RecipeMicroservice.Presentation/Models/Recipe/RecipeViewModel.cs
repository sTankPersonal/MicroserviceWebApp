using RecipeMicroservice.Presentation.Interfaces.Models;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class RecipeViewModel : IHasEntity<RecipeViewModel, Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public ListRecipeInstructionViewModel Instructions { get; init; } = new();
        public ListRecipeIngredientViewModel Ingredients { get; init; } = new();
        public ListRecipeCategoryViewModel Categories { get; init; } = new();

        public bool HasInstructions => Instructions.Items.Any();
        public bool HasIngredients => Ingredients.Items.Any();
        public bool HasCategories => Categories.Items.Any();

        // IHasEntity
        public required Guid Id { get; set; }
        public RecipeViewModel WithId(Guid id) => (Id = id, this).Item2;
    }
}
