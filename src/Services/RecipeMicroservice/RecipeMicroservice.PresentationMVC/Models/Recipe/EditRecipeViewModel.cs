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
        public ICollection<EditRecipeCategoryViewModel> RecipeCategories { get; set; } = [];
        public ICollection<EditRecipeIngredientViewModel> RecipeIngredients { get; set; } = [];
        public ICollection<EditRecipeInstructionViewModel> RecipeInstructions { get; set; } = [];

        public static EditRecipeViewModel FromDto(RecipeDto dto)
        {
            return new EditRecipeViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                PrepTimeInMinutes = dto.PrepTimeInMinutes,
                CookTimeInMinutes = dto.CookTimeInMinutes,
                Servings = dto.Servings,
                RecipeCategories = [.. dto.Categories.Select(EditRecipeCategoryViewModel.FromDto)],
                RecipeIngredients = [.. dto.Ingredients.Select(EditRecipeIngredientViewModel.FromDto)],
                RecipeInstructions = [.. dto.Instructions.Select(EditRecipeInstructionViewModel.FromDto)]
            };
        }
    }
}
