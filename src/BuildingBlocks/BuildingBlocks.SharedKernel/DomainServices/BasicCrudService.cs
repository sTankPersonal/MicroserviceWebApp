using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using BuildingBlocks.SharedKernel.Utils;

namespace BuildingBlocks.SharedKernel.DomainServices
{
    public abstract class BasicCrudService<TEntity, TId, TDto, TCreateDto, TUpdateDto, TFilterQuery>(IRepository<TEntity, TId, TFilterQuery> repository) : IBasicCrudService<TId, TDto, TCreateDto, TUpdateDto, TFilterQuery> where TEntity : BaseEntity<TId> where TFilterQuery : PagedQuery
    {
        protected readonly IRepository<TEntity, TId, TFilterQuery> _repository = repository;
        protected abstract TEntity ToEntity(TCreateDto dto);
        protected abstract void ToEntity(TUpdateDto dto, TEntity entity);
        protected abstract TDto ToDto(TEntity entity);



        public virtual async Task<TId> CreateAsync(TCreateDto dto)
        {
            TEntity entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }
        public virtual async Task DeleteAsync(TId id)
        {
            TEntity entity = await _repository.GetByIdAsync(id).ThrowIfNullAsync<TEntity>();
            await _repository.DeleteAsync(entity);
        }
        public virtual async Task<PagedResult<TDto>> GetAllAsync(TFilterQuery query)
        {
            PagedResult<TEntity> pagedEntities = await _repository.GetAllAsync(query);
            return pagedEntities.Map(e => ToDto(e));
        }
        public virtual async Task<TDto?> GetByIdAsync(TId id)
        {
            TEntity? entity = await _repository.GetByIdAsync(id);
            return entity == null ? default : ToDto(entity);
        }
        public virtual async Task UpdateAsync(TId id, TUpdateDto dto)
        {
            TEntity entity = await _repository.GetByIdAsync(id).ThrowIfNullAsync<TEntity>();
            ToEntity(dto, entity);
            await _repository.UpdateAsync(entity);
        }
    }
}
