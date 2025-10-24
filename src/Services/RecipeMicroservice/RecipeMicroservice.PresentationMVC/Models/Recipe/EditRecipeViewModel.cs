using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.PresentationMVC.Models.RecipeCategory;
using RecipeMicroservice.PresentationMVC.Models.RecipeIngredient;
using RecipeMicroservice.PresentationMVC.Models.RecipeInstruction;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.PresentationMVC.Models.Recipe
{
    public class EditRecipeViewModel
    {
        public Guid Id { get; set; }
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
        public ICollection<RecipeCategoryViewModel> RecipeCategories { get; set; } = [];
        public ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; } = [];
        public ICollection<RecipeInstructionViewModel> RecipeInstructions { get; set; } = [];

        public CreateRecipeCategoryViewModel NewCategory { get; set; } = new CreateRecipeCategoryViewModel();
        public CreateRecipeIngredientViewModel NewIngredient { get; set; } = new CreateRecipeIngredientViewModel();
        public CreateRecipeInstructionViewModel NewInstruction { get; set; } = new CreateRecipeInstructionViewModel();

        public static EditRecipeViewModel FromDto(RecipeDto dto)
        {
            return new EditRecipeViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                PrepTimeInMinutes = dto.PrepTimeInMinutes,
                CookTimeInMinutes = dto.CookTimeInMinutes,
                Servings = dto.Servings,
                RecipeCategories = [.. dto.Categories.Select(RecipeCategoryViewModel.FromDto)],
                RecipeIngredients = [.. dto.Ingredients.Select(RecipeIngredientViewModel.FromDto)],
                RecipeInstructions = [.. dto.Instructions.Select(RecipeInstructionViewModel.FromDto)]
            };
        }
        public bool HasCategories()
        {
            return RecipeCategories != null && RecipeCategories.Count > 0;
        }
        public bool HasIngredients()
        {
            return RecipeIngredients != null && RecipeIngredients.Count > 0;
        }
        public bool HasInstructions()
        {
            return RecipeInstructions != null && RecipeInstructions.Count > 0;
        }
    }
}
