using BuildingBlocks.SharedKernel.Pagination;

namespace BuildingBlocks.SharedKernel.InfrastructureServices
{
    public interface IRepository<T> : IInfrastructureService
    {
        Task<PagedResult<T>> GetAllAsync(PagedQuery query);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
