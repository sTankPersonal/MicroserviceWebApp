using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class AttachElementsRecipeViewModel : BaseIdViewModel<Guid>
    {
        public CreateRecipeCategoryViewModel NewCategory { get; init; } = new();
        public CreateRecipeIngredientViewModel NewIngredient { get; init; } = new();
        public CreateRecipeInstructionViewModel NewInstruction { get; init; } = new();
    }
}
