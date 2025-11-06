using RecipeMicroservice.Application.Interfaces.ViewModels;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class RecipeViewModel : IInfoViewModel<Guid>
    {
        public Guid Id { get; init;  }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public ListRecipeInstructionViewModel Instructions { get; init; } = new();
        public ListRecipeIngredientViewModel Ingredients { get; init; } = new();
        public ListRecipeCategoryViewModel Categories { get; init; } = new();
    }
}
