using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class CreateRecipeIngredientViewModel : IHasRecipeAggregate<CreateRecipeIngredientViewModel>
    {
        // Properties
        [Required]
        public Guid IngredientId { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        [Required]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public CreateRecipeIngredientViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
