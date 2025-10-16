
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;

namespace RecipeMicroservice.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<Category>> GetAllAsync(PagedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
