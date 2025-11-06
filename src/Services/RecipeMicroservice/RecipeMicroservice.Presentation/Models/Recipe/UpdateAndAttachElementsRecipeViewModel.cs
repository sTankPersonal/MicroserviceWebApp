using RecipeMicroservice.Application.Interfaces.ViewModels;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class UpdateAndAttachElementsRecipeViewModel : IInfoViewModel<Guid>
    {
        public Guid Id { get; init; }
        public required UpdateRecipeViewModel Edit { get; init; }
        public required AttachElementsRecipeViewModel AttachElements { get; init; }
    }
}
