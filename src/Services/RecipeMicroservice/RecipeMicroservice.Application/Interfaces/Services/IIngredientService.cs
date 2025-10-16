using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Ingredient;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IIngredientService : IBasicCrudService<Guid, IngredientDto, CreateIngredientDto, UpdateIngredientDto>
    {
        public Task<PagedResult<IngredientDto>> GetAllAsync(FilterIngredientDto filter);
    }
}
