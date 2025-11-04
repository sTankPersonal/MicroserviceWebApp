using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class RecipeInstructionMapper
    {
        //public static RecipeInstruction ToEntity(this CreateRecipeInstructionDto dto)
        //{
        //    return new RecipeInstruction
        //    {
        //        StepNumber = dto.StepNumber,
        //        Description = dto.Description
        //    };
        //}
        public static RecipeInstructionDto ToDto(this RecipeInstruction entity)
        {
            return new RecipeInstructionDto
            {
                Id = entity.Id,
                StepNumber = entity.StepNumber,
                Description = entity.Description
            };
        }
        public static IEnumerable<RecipeInstructionDto> ToDtos(this IEnumerable<RecipeInstruction> entities)
        {
            return entities.Select(e => e.ToDto());
        }
    }
}
