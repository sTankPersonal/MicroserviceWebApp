namespace RecipeMicroservice.Application.DTOs.RecipeInstruction
{
    public class UpdateRecipeInstructionDto
    {
        public required Guid Id { get; set; }
        public required int StepNumber { get; set; }
        public required string Description { get; set; }
    }
}
