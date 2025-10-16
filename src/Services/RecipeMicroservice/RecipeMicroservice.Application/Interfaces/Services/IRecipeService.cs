using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Recipe;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipeDto filter);
    }
}
