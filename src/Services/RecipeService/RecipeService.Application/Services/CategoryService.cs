using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Category;
using RecipeService.Application.Interfaces.Services;
using RecipeService.Application.Queries.Category;

namespace RecipeService.Application.Services
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

        public Task<PagedResult<CategoryDto>> GetAllAsync(GetIngredientQuery query)
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
