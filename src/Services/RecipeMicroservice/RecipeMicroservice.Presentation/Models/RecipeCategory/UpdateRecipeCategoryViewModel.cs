using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class UpdateRecipeCategoryViewModel : IHasEntity<UpdateRecipeCategoryViewModel, Guid>, IHasRecipeAggregate<UpdateRecipeCategoryViewModel>
    {
        // Properties
        public Guid CategoryId { get; set; }
        // Display Properties
        public string CategoryName { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public UpdateRecipeCategoryViewModel WithId(Guid entityId) => (Id = entityId, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public UpdateRecipeCategoryViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;

        
    }
}
