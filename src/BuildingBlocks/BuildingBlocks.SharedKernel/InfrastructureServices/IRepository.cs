using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.Pagination;

namespace BuildingBlocks.SharedKernel.InfrastructureServices
{
    public interface IRepository<TEntity, TId, in TFilterQuery> : IInfrastructureService where TEntity : BaseEntity<TId> where TFilterQuery : PagedQuery
    {
        Task<PagedResult<TEntity>> GetAllAsync(TFilterQuery query);
        Task<TEntity?> GetByIdAsync(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
