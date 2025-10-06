using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Instruction;
using RecipeService.Application.Interfaces.Services;

namespace RecipeService.Application.Services
{
    public class InstructionService : IInstructionService
    {
        public Task<InstructionDto> CreateAsync(CreateInstructionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<InstructionDto>> GetAllAsync()
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
