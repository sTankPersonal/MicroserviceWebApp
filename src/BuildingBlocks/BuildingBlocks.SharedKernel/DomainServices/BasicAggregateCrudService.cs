using BuildingBlocks.SharedKernel.Entities;
using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using BuildingBlocks.SharedKernel.Utils;

namespace BuildingBlocks.SharedKernel.DomainServices
{
    public abstract class BasicAggregateCrudService<TAggregate, TId, TDto, TCreateDto, TUpdateDto, TFilterQuery>(IRepository<TAggregate, TId, TFilterQuery> repository)
        : BasicCrudService<TAggregate, TId, TDto, TCreateDto, TUpdateDto, TFilterQuery>(repository)
        where TAggregate : BaseEntity<TId>
        where TFilterQuery : PagedQuery
    {
        protected async Task<TChildId> AddChildAsync<TChild, TChildId, TChildCreateDto>(
            TId aggregateId,
            Func<TChildCreateDto, TChild> map,
            Func<TAggregate, TChild,Task> addAction,
            TChildCreateDto dto)
            where TChild : BaseEntity<TChildId>
        {
            TAggregate aggregate = await _repository.GetByIdAsync(aggregateId).ThrowIfNullAsync();
            TChild child = map(dto);
            await addAction(aggregate, child);
            return child.Id;
        }

        protected async Task UpdateChildAsync<TChild, TChildId, TChildUpdateDto>(
            TId aggregateId,
            TChildId childId,
            Func<TAggregate, IEnumerable<TChild>> childSelector,
            Func<TChildUpdateDto, TChild, TChild> map,
            Func<TAggregate, TChild, Task> updateAction,
            TChildUpdateDto dto)
            where TChild : BaseEntity<TChildId>
        {
            TAggregate aggregate = await _repository.GetByIdAsync(aggregateId).ThrowIfNullAsync();
            TChild child = childSelector(aggregate).FirstOrDefault(c => c.Id!.Equals(childId)).ThrowIfNull();
            _ = map(dto, child);
            await updateAction(aggregate, child);
        }

        protected async Task DeleteChildAsync<TChild, TChildId>(
            TId aggregateId,
            TChildId childId,
            Func<TAggregate, IEnumerable<TChild>> childSelector,
            Func<TAggregate, TChild, Task> deleteAction)
            where TChild : BaseEntity<TChildId>
        {
            TAggregate aggregate = await _repository.GetByIdAsync(aggregateId).ThrowIfNullAsync();
            TChild child = childSelector(aggregate).FirstOrDefault(c => c.Id!.Equals(childId)).ThrowIfNull();
            await deleteAction(aggregate, child);
        }
    }
}
