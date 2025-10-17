using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipe filter);

        //Aggregate Child - Instructions
        public Task<InstructionDto?> GetInstructionByIdAsync(Guid recipeId, Guid instructionId);
        public Task<PagedResult<InstructionDto>> GetAllInstructionsAsync(Guid recipeId, PagedQuery query);
        public Task<PagedResult<InstructionDto>> GetAllInstructionsAsync(Guid recipeId, FilterInstruction filter);
        public Task<Guid> CreateInstructionAsync(Guid recipeId, CreateInstructionDto dto);
        public Task UpdateInstructionAsync(Guid recipeId, Guid instructionId, UpdateInstructionDto dto);
        public Task DeleteInstructionAsync(Guid recipeId,  Guid instructionId);
    }
}
