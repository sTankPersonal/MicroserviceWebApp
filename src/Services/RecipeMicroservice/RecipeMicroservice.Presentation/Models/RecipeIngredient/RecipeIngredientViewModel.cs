using BuildingBlocks.SharedKernel.Utils;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class RecipeIngredientViewModel : RecipeAggregateViewModels
    {
        public Guid Id { get; init; }
        public Guid IngredientId { get; init; }
        public Guid UnitId { get; init; }
        public decimal Quantity { get; set; } = 0;

        //Display Properties
        public string IngredientName { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;

        // Read-only property for display
        public string FormattedQuantity => DecimalFormatting.FormatAmount(Quantity);
    }
}
