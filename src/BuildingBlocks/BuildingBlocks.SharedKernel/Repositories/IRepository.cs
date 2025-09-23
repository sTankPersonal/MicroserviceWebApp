
namespace BuildingBlocks.SharedKernel.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<PagedResult<T>> GetAllAsync(PagedQuery query);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
