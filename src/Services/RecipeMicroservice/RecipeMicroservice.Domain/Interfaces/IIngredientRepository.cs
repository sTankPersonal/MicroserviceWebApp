using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<PagedResult<Ingredient>> GetAllAsync(FilterIngredient query);
    }
}
