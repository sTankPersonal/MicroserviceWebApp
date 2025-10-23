namespace RecipeMicroservice.Application.DTOs.Instruction
{
    public class UpdateRecipeInstructionDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
