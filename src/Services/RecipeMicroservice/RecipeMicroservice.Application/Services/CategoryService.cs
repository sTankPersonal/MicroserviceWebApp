using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class CategoryService() : ICategoryService
    {
        public Task<Guid> CreateAsync(CreateCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategory query)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<CategoryDto>> GetAllAsync(BuildingBlocks.SharedKernel.Repositories.PagedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
