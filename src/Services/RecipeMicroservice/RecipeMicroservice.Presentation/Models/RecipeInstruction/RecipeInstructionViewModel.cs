using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class RecipeInstructionViewModel : IHasEntity<RecipeInstructionViewModel, Guid>, IHasRecipeAggregate<RecipeInstructionViewModel>
    {
        // Properties
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public RecipeInstructionViewModel WithId(Guid entityId) => (Id = entityId, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public RecipeInstructionViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
