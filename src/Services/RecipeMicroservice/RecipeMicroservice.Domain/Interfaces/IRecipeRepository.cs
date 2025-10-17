using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<PagedResult<Recipe>> GetAllAsync(FilterRecipe query);
    }
}
