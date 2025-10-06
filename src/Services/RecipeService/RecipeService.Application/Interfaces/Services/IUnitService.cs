using BuildingBlocks.SharedKernel.DomainServices;
using RecipeService.Application.DTOs.Unit;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IUnitService : IBasicCrudService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto>
    {
    }
}
