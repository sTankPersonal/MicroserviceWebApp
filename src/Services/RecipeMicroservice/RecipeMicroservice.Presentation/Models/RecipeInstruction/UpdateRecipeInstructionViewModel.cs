using RecipeMicroservice.Application.Interfaces.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class UpdateRecipeInstructionViewModel : RecipeAggregateViewModels, IInfoViewModel<Guid>
    {
        public Guid Id { get; init; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for step number.")]
        [Display(Name = "Step Number")]
        public int StepNumber { get; set; } = 0;
        [Required(ErrorMessage = "Please enter a description for the instruction.")]
        [Display(Name = "Step Instruction")]
        public string Description { get; set; } = string.Empty;
    }
}
