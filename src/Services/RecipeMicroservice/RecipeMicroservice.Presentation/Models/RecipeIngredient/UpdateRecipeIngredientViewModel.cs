using RecipeMicroservice.Application.Interfaces.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class UpdateRecipeIngredientViewModel : RecipeAggregateViewModels, IInfoViewModel<Guid>
    {
        public Guid Id { get; init; }
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }

        //Display Properties
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
    }
}
