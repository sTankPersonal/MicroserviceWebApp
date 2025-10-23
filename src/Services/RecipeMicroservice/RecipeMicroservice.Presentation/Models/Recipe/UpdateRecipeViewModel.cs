using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class UpdateRecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public IEnumerable<RecipeInstructionViewModel> Instructions { get; set; } = [];
        public IEnumerable<RecipeIngredientViewModel> Ingredients { get; set; } = [];
        public IEnumerable<RecipeCategoryViewModel> Categories { get; set; } = [];
    }
}
