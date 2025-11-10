using BuildingBlocks.SharedKernel.Pagination;

namespace BuildingBlocks.SharedKernel.DomainServices
{
    public interface IBasicCrudService<TId, TDto, TCreateDto, TUpdateDto, in TFilterQuery> : IDomainService where TFilterQuery : PagedQuery
    {
        Task<PagedResult<TDto>> GetAllAsync(TFilterQuery query);
        Task<TDto?> GetByIdAsync(TId id);
        Task<TId> CreateAsync(TCreateDto dto);
        Task UpdateAsync(TId id, TUpdateDto dto);
        Task DeleteAsync(TId id);
    }
}
