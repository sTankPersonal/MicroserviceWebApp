using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedResult<Category>> GetAllAsync(FilterCategory query);
    }
}
