using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Application.Interfaces.Services;

namespace RecipeMicroservice.Application.Services
{
    public class InstructionService : IInstructionService
    {
        public Task<Guid> CreateAsync(CreateInstructionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<InstructionDto>> GetAllAsync(FilterInstructionDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<InstructionDto>> GetAllAsync(PagedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<InstructionDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateInstructionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
