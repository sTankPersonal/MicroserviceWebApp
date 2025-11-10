using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeInstructionMapper
    {
        public static RecipeInstruction ToEntity(this CreateRecipeInstructionDto dto, Guid recipeId) => new()
        {
            RecipeId = recipeId,
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
            RecipeId = entity.RecipeId,
            StepNumber = entity.StepNumber,
            Description = entity.Description,
            RecipeName = entity.Recipe != null ? entity.Recipe.Name : string.Empty
        };
        public static IEnumerable<RecipeInstructionDto> ToDtos(this IEnumerable<RecipeInstruction> entities) =>
            entities.Select(e => e.ToDto());
    }
}
