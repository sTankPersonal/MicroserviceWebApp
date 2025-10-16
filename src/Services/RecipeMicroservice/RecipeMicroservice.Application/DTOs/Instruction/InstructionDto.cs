namespace RecipeMicroservice.Application.DTOs.Instruction
{
    public class InstructionDto
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
