namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class CreateRecipeInstructionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
