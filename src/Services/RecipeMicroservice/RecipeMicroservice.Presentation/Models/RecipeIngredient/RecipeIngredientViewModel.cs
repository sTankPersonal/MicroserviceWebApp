using BuildingBlocks.SharedKernel.Utils;
using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class RecipeIngredientViewModel : IHasEntity<RecipeIngredientViewModel, Guid>, IHasRecipeAggregate<RecipeIngredientViewModel>
    {
        // Properties
        public Guid IngredientId { get; init; }
        public Guid UnitId { get; init; }
        public decimal Quantity { get; set; } = 0;

        //Display Properties
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string FormattedQuantity => DecimalFormatting.FormatAmount(Quantity);

        // IHasEntity
        public required Guid Id { get; set; }
        public RecipeIngredientViewModel WithId(Guid entityId) => (Id = entityId, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public RecipeIngredientViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
