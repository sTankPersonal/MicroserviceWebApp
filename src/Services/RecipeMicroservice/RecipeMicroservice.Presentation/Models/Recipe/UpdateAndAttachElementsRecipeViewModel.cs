namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class UpdateAndAttachElementsRecipeViewModel : BaseIdViewModel<Guid>
    {
        public required UpdateRecipeViewModel Edit { get; init; }
        public required AttachElementsRecipeViewModel AttachElements { get; init; }
    }
}
