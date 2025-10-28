using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class EditAndAttachElementsRecipeViewModel
    {
        public EditRecipeViewModel Recipe {  get; set; } = new EditRecipeViewModel();
        public CreateRecipeCategoryViewModel NewCategory { get; set; } = new CreateRecipeCategoryViewModel();
        public CreateRecipeIngredientViewModel NewIngredient { get; set; } = new CreateRecipeIngredientViewModel();
        public CreateRecipeInstructionViewModel NewInstruction { get; set; } = new CreateRecipeInstructionViewModel();

        public static EditAndAttachElementsRecipeViewModel FromDto(RecipeDto recipeDto)
        {
            return new EditAndAttachElementsRecipeViewModel
            {
                Recipe = EditRecipeViewModel.FromDto(recipeDto)
            };
        }
    }
}
