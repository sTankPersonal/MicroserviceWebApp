using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class UpdateRecipeIngredientViewModel : IHasEntity<UpdateRecipeIngredientViewModel, Guid>, IHasRecipeAggregate<UpdateRecipeIngredientViewModel>
    {
        // Properties
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }

        //Display Properties
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public UpdateRecipeIngredientViewModel WithId(Guid entityId) => (Id = entityId, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public UpdateRecipeIngredientViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
