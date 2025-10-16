using BuildingBlocks.SharedKernel.Entities;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Domain.Entities
{
    public class Instruction : BaseEntity<Guid>
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
