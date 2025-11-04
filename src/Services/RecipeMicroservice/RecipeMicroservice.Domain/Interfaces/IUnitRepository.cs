using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IUnitRepository : IRepository<Unit>
    {
        Task<PagedResult<Unit>> GetAllAsync(FilterUnit query);
    }
}
