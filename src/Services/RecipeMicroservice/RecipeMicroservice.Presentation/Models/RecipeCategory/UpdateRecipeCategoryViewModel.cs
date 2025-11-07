using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class UpdateRecipeCategoryViewModel : BaseIdViewModel<Guid>, IHasAggregate<UpdateRecipeCategoryViewModel, Guid>
    {
        public Guid CategoryId { get; set; }
        // Display Properties
        public string CategoryName { get; set; } = string.Empty;

        public Guid AggregateId { get; set; }

        public UpdateRecipeCategoryViewModel WithAggregateId(Guid aggregateId)
        {
            AggregateId = aggregateId;
            return this;
        }
    }
}
