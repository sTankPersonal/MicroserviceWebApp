using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Ingredient;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IIngredientService : IBasicCrudService<Guid, IngredientDto, CreateIngredientDto, UpdateIngredientDto>
    {
        public Task<PagedResult<IngredientDto>> GetAllAsync(FilterIngredientDto filter);
    }
}
