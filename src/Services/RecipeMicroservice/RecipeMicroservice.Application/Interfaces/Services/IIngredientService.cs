using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IIngredientService : IBasicCrudService<Guid, IngredientDto, CreateIngredientDto, UpdateIngredientDto>
    {
        public Task<PagedResult<IngredientDto>> GetAllAsync(FilterIngredient filter);

        //Aggregate Child: Instruction
        public Task<PagedResult<InstructionDto>> GetAllInstructionsAsync(PagedQuery query);
        public Task<PagedResult<InstructionDto>> GetAllInstructionsAsync(FilterInstruction filter);
        public Task<Guid> CreateInstructionAsync(Guid recipeId, CreateInstructionDto dto);
        public Task<Guid> UpdateInstructionAsync(Guid recipeId, UpdateInstructionDto dto);
        public Task DeleteInstructionAsync(Guid recipeId, Guid instructionId);
    }
}
