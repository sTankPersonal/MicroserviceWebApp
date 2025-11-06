using RecipeMicroservice.Application.Interfaces.ViewModels;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class AttachElementsRecipeViewModel : IInfoViewModel<Guid>
    {
        public Guid Id { get; init;  }
        public CreateRecipeCategoryViewModel NewCategory { get; init; } = new CreateRecipeCategoryViewModel();
        public CreateRecipeIngredientViewModel NewIngredient { get; init; } = new CreateRecipeIngredientViewModel();
        public CreateRecipeInstructionViewModel NewInstruction { get; init; } = new CreateRecipeInstructionViewModel();
    }
}
