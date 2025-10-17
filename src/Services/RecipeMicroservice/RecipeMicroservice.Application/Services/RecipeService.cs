using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class RecipeService : IRecipeService
    {
        public Task<Guid> CreateAsync(CreateRecipeDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipe filter)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<RecipeDto>> GetAllAsync(PagedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateRecipeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
