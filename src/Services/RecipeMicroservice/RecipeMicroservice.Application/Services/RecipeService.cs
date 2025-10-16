using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Recipe;
using RecipeService.Application.Interfaces.Services;

namespace RecipeService.Application.Services
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

        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipeDto filter)
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
