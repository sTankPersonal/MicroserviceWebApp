using BuildingBlocks.SharedKernel.Entities;
using RecipeService.Domain.Aggregates;

namespace RecipeService.Domain.Entities
{
    public class Instruction : BaseEntity<Guid>
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
