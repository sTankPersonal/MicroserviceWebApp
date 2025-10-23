namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class RecipeInstructionDto
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
