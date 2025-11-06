using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    internal interface IExampleRepository : IRepository<ExampleEntity, Guid, PagedQuery>
    {
    }
}
