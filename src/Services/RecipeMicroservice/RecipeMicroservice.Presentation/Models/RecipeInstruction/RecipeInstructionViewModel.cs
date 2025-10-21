using RecipeMicroservice.Application.DTOs.Instruction;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class RecipeInstructionViewModel
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        public static RecipeInstructionViewModel FromDto(InstructionDto dto)
        {
            return new RecipeInstructionViewModel
            {
                Id = dto.Id,
                StepNumber = dto.StepNumber,
                Description = dto.Description
            };
        }
    }
}
