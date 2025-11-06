namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class RecipeInstructionDto
    {
        public required Guid Id { get; set; }
        public required int StepNumber { get; set; }
        public required string Description { get; set; }
        //Optional Display Fields
        public string RecipeName { get; set; } = string.Empty;
    }
}
