using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class UpdateRecipeInstructionViewModel : IHasEntity<UpdateRecipeInstructionViewModel, Guid>, IHasRecipeAggregate<UpdateRecipeInstructionViewModel>
    {
        // Properties
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for step number.")]
        [Display(Name = "Step Number")]
        public int StepNumber { get; set; } = 0;
        [Required(ErrorMessage = "Please enter a description for the instruction.")]
        [Display(Name = "Step Instruction")]
        public string Description { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public UpdateRecipeInstructionViewModel WithId(Guid entityId) => (Id = entityId, this).Item2;

        // IHasRecipeAggregate
        public required Guid AggregateId { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public UpdateRecipeInstructionViewModel WithAggregateId(Guid aggregateId) => (AggregateId = aggregateId, this).Item2;
    }
}
