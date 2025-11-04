using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedResult<Category>> GetAllAsync(FilterCategory query);
    }
}
