using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class CreateRecipeInstructionViewModel : RecipeAggregateViewModels
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for step number.")]
        [Display(Name = "Step Number")]
        public int StepNumber { get; set; } = 0;
        [Required(ErrorMessage = "Please enter a description for the instruction.")]
        [Display(Name = "Step Instruction", Prompt =  "Enter a description for this step...")]
        [StringLength(2000, ErrorMessage = "Instruction name cannot be longer than 2000 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}
