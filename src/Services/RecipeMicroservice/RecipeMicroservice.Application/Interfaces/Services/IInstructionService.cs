using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Instruction;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IInstructionService : IBasicCrudService<Guid, InstructionDto, CreateInstructionDto, UpdateInstructionDto>
    {
        public Task<PagedResult<InstructionDto>> GetAllAsync(FilterInstructionDto filter);
    }
}
