using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipe filter);

        //Aggregate Child - Instructions
        //public Task<RecipeInstructionDto?> GetInstructionByIdAsync(Guid recipeId, Guid instructionId);
        //public Task<PagedResult<RecipeInstructionDto>> GetAllInstructionsAsync(Guid recipeId, PagedQuery query);
        //public Task<PagedResult<RecipeInstructionDto>> GetAllInstructionsAsync(Guid recipeId, FilterInstruction filter);
        public Task<Guid> CreateInstructionAsync(Guid recipeId, CreateRecipeInstructionDto dto);
        public Task UpdateInstructionAsync(Guid recipeId, Guid instructionId, UpdateRecipeInstructionDto dto);
        public Task DeleteInstructionAsync(Guid recipeId,  Guid instructionId);
    }
}
