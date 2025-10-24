using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.PresentationMVC.Models.Recipe
{
    public class CreateRecipeViewModel
    {
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
    }
}
