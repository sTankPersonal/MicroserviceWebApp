using BuildingBlocks.SharedKernel.Entities;
using RecipeService.Domain.Aggregates;

namespace RecipeService.Domain.Entities
{
    public class RecipeCategory : BaseEntity<Guid>
    {
        public Guid RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
