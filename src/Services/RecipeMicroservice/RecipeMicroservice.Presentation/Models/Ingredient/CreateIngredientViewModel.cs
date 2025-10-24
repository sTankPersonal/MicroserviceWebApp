using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.PresentationMVC.Models.Ingredient
{
    public class CreateIngredientViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
