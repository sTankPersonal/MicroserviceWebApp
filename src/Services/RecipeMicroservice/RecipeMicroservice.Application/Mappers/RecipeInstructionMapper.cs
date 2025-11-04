using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeInstructionMapper
    {
        public static RecipeInstruction ToEntity(this CreateRecipeInstructionDto dto) => new()
        {
            StepNumber = dto.StepNumber,
            Description = dto.Description
        };
        public static RecipeInstruction ToEntity(this UpdateRecipeInstructionDto dto, RecipeInstruction entity)
        {
            entity.StepNumber = dto.StepNumber;
            entity.Description = dto.Description;
            return entity;
        }
        public static RecipeInstructionDto ToDto(this RecipeInstruction entity) => new()
        {
            Id = entity.Id,
            StepNumber = entity.StepNumber,
            Description = entity.Description
        };
        public static IEnumerable<RecipeInstructionDto> ToDtos(this IEnumerable<RecipeInstruction> entities) =>
            entities.Select(e => e.ToDto());
    }
}
