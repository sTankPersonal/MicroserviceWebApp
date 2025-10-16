using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Ingredient;
using RecipeService.Application.Interfaces.Services;

namespace RecipeService.Application.Services
{
    public class IngredientService : IIngredientService
    {
        public Task<Guid> CreateAsync(CreateIngredientDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<IngredientDto>> GetAllAsync(FilterIngredientDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<IngredientDto>> GetAllAsync(PagedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IngredientDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateIngredientDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
