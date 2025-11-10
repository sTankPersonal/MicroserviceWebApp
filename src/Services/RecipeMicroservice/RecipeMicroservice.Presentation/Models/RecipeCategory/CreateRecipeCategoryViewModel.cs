using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class CreateRecipeCategoryViewModel : IHasRecipeAggregate<CreateRecipeCategoryViewModel>
    {
        // Properties
        [Required]
        public Guid CategoryId { get; set; }

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public CreateRecipeCategoryViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
