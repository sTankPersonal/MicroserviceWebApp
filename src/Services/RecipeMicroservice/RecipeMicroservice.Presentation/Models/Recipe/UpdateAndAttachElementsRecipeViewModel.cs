namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class UpdateAndAttachElementsRecipeViewModel
    {
        public required UpdateRecipeViewModel UpdateRecipe { get; init; }
        public required AttachElementsRecipeViewModel AttachElements { get; init; }
    }
}
