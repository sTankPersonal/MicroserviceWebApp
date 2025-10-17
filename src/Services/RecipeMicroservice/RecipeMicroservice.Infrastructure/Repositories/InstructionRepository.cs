
using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure.Repositories
{
    public class InstructionRepository(RecipeMicroserviceDbContext dbContext) : IInstructionRepository
    {
        private readonly RecipeMicroserviceDbContext _dbContext = dbContext;
        public async Task AddAsync(Instruction entity)
        {
            _dbContext.Instructions.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Instruction entity)
        {
            _dbContext.Instructions.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Instruction>> GetAllAsync(FilterInstruction query)
        {
            IQueryable<Instruction> instructions = _dbContext.Instructions.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchDescription))
            {
                instructions = instructions.Where(i => i.Description.Contains(query.SearchDescription));
            }
            int totalItems = await instructions.CountAsync();
            List<Instruction> items = await instructions.OrderBy(i => i.StepNumber).ThenBy(i => i.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Instruction>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Instruction>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Instruction> instructions = _dbContext.Instructions.AsQueryable();
            int totalItems = await instructions.CountAsync();
            List<Instruction> items = await instructions.OrderBy(i => i.StepNumber).ThenBy(i => i.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Instruction>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<Instruction?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Instructions.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Instruction entity)
        {
            _dbContext.Instructions.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
