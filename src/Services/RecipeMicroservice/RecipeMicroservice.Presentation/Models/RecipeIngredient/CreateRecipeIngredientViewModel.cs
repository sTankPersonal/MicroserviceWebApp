using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class CreateRecipeIngredientViewModel
    {
        [Required]
        public Guid IngredientId { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }
    }
}
