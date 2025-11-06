namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class CreateRecipeInstructionDto
    {
        public required int StepNumber { get; set; }
        public required string Description { get; set; }
    }
}
