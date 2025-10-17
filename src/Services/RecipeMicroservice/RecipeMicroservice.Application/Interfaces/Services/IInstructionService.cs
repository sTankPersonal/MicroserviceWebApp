using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IInstructionService : IBasicCrudService<Guid, InstructionDto, CreateInstructionDto, UpdateInstructionDto>
    {
        public Task<PagedResult<InstructionDto>> GetAllAsync(FilterInstruction filter);
    }
}
