using RecipeMicroservice.Application.Interfaces.ViewModels;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class UpdateRecipeCategoryViewModel : RecipeAggregateViewModels, IInfoViewModel<Guid>
    {
        public Guid Id { get; init; } 
        public Guid CategoryId { get; set; }
        // Display Properties
        public string CategoryName { get; set; } = string.Empty;
    }
}
