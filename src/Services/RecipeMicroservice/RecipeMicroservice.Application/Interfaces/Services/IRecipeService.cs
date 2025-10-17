using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
        public Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipe filter);
    }
}
