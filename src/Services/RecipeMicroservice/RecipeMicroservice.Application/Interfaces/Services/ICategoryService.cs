using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface ICategoryService : IBasicCrudService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        public Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategory filter);
    }
}
