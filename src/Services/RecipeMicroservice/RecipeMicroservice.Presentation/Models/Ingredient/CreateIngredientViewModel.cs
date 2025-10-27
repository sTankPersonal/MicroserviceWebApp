using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class CreateIngredientViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name", Prompt = "Please enter a name for the new ingredient...")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
