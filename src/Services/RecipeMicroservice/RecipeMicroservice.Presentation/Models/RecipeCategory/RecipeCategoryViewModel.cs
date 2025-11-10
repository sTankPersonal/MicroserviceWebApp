using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class RecipeCategoryViewModel : IHasEntity<RecipeCategoryViewModel, Guid>, IHasRecipeAggregate<RecipeCategoryViewModel>
    {
        // Properties
        public required Guid CategoryId { get; set; }
        // Display Properties
        public string CategoryName { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public RecipeCategoryViewModel WithId(Guid id) => (Id = id, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public RecipeCategoryViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;

       

    }
}
