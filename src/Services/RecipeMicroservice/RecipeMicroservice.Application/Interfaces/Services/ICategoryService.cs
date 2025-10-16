using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Category;

namespace RecipeService.Application.Interfaces.Services
{
    public interface ICategoryService : IBasicCrudService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        public Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategoryDto filter);
    }
}
