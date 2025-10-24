using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.PresentationMVC.Models.RecipeInstruction
{
    public class EditRecipeInstructionViewModel
    {
        public Guid RecipeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for step number.")]
        [Display(Name = "Step Number")]
        public int StepNumber { get; set; } = 0;
        [Required(ErrorMessage = "Please enter a description for the instruction.")]
        [Display(Name = "Step Instruction")]
        public string Description { get; set; } = string.Empty;

        public static EditRecipeInstructionViewModel FromDto(RecipeInstructionDto dto)
        {
            return new EditRecipeInstructionViewModel
            {
                RecipeId = dto.Id,
                StepNumber = dto.StepNumber,
                Description = dto.Description
            };
        }
    }
}
