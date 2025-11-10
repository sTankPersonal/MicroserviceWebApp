using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class AttachElementsRecipeViewModel 
    {
        public required CreateRecipeCategoryViewModel NewCategory { get; init; }
        public required CreateRecipeIngredientViewModel NewIngredient { get; init; }
        public required CreateRecipeInstructionViewModel NewInstruction { get; init; }
    }
}
