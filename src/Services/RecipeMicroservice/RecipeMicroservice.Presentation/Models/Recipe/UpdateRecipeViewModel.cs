using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class UpdateRecipeViewModel : BaseIdViewModel<Guid>
    {
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        [Display(Name = "Recipe Name")]
        [StringLength(200, ErrorMessage = "Recipe name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for preparation time.")]
        [Display(Name = "Preparation Time (Minutes)")]
        public int PrepTimeInMinutes { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for cooking time.")]
        [Display(Name = "Cooking Time (Minutes)")]
        public int CookTimeInMinutes { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for servings.")]
        [Display(Name = "# of Servings")]
        public int Servings { get; set; } = 0;

        public ListRecipeCategoryViewModel RecipeCategories { get; init; } = new();
        public ListRecipeIngredientViewModel RecipeIngredients { get; init; } = new();
        public ListRecipeInstructionViewModel RecipeInstructions { get; init; } = new();
    }
}
