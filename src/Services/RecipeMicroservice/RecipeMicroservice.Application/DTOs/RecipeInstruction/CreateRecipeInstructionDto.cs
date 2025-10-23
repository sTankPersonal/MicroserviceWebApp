namespace RecipeMicroservice.Application.DTOs.Instruction
{
    public class CreateRecipeInstructionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
