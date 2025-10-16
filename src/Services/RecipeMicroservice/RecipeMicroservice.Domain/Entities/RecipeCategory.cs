using BuildingBlocks.SharedKernel.Entities;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Domain.Entities
{
    public class RecipeCategory : BaseEntity<Guid>
    {
        public Guid RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
