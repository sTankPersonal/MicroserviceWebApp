namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class UpdateRecipeInstructionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
