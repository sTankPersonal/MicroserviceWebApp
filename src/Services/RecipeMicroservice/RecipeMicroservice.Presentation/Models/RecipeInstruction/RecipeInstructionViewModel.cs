using RecipeMicroservice.Application.DTOs.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class RecipeInstructionViewModel
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        public static RecipeInstructionViewModel FromDto(RecipeInstructionDto dto)
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
