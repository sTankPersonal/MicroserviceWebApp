using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<PagedResult<Recipe>> GetAllAsync(FilterRecipe query);

        //Aggregate Child - Instructions
        Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, PagedQuery query);
        Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, FilterInstruction filter);
        Task<Instruction?> GetInstructionByIdAsync(Recipe recipe, Guid instructionId);
        Task AddInstructionAsync(Recipe recipe, Instruction instruction);
        Task UpdateInstructionAsync(Recipe recipe, Instruction instruction);
        Task DeleteInstructionByIdAsync(Recipe recipe, Instruction instruction);
    }
}
