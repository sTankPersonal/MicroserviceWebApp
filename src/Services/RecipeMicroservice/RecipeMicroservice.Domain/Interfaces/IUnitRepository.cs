using BuildingBlocks.SharedKernel.InfrastructureServices;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IUnitRepository : IRepository<Unit, Guid, FilterUnit>
    {
    }
}
