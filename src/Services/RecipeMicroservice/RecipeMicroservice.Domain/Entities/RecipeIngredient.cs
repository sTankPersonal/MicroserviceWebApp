using BuildingBlocks.SharedKernel.Entities;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Domain.Entities
{
    public class RecipeIngredient : BaseEntity<Guid>
    {
        public Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public Guid UnitId { get; set; }
        public Unit? Unit { get; set; }
        public decimal Quantity { get; set; }

    }
}
