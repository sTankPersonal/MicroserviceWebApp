using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Category;
using RecipeService.Application.Queries.Category;
namespace RecipeService.Application.Interfaces.Services
{
    public interface ICategoryService : IBasicCrudService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        public Task<PagedResult<CategoryDto>> GetAllAsync(GetIngredientQuery query);
    }
}
