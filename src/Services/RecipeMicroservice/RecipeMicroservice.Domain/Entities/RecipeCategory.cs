using BuildingBlocks.SharedKernel.Entities;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Domain.Entities
{
    public class RecipeCategory : BaseEntity<Guid>
    {
        public Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
