namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class RecipeInstructionViewModel : RecipeAggregateViewModels
    {
        public Guid Id { get; init;  }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
