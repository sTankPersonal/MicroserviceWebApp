using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IInstructionRepository : IRepository<Instruction>
    {
        Task<PagedResult<Instruction>> GetAllAsync(FilterInstruction query);
    }
}
