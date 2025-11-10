namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class ListRecipeInstructionViewModel : BaseListViewModel<RecipeInstructionViewModel>
    {
        public string? SearchDescription { get; set; } = null;
    }
}
