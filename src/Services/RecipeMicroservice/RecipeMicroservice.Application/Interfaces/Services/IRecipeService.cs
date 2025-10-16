using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Recipe;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipeDto filter);
    }
}
