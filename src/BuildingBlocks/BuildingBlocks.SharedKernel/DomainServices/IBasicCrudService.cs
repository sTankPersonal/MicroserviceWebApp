using BuildingBlocks.SharedKernel.Pagination;

namespace BuildingBlocks.SharedKernel.DomainServices
{
    public interface IBasicCrudService<TId, TDto, TCreateDto, TUpdateDto> : IDomainService
    {
        Task<PagedResult<TDto>> GetAllAsync(PagedQuery query);
        Task<TDto?> GetByIdAsync(TId id);
        Task<TId> CreateAsync(TCreateDto dto);
        Task UpdateAsync(TId id, TUpdateDto dto);
        Task DeleteAsync(TId id);
    }
}
