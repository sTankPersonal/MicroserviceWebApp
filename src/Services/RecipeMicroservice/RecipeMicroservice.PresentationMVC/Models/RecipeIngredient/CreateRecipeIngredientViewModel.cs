using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.PresentationMVC.Models.RecipeIngredient
{
    public class CreateRecipeIngredientViewModel
    {
        public Guid UnitId { get; set; }
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }
    }
}
