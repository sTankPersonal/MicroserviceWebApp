using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.Category;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Application.Interfaces.Services
{
    public interface ICategoryService : IBasicCrudService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        public Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategory filter);
    }
}
