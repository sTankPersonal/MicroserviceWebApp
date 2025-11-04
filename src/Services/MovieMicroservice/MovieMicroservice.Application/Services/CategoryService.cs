using BuildingBlocks.CrossCutting.Utils;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.Category;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Application.Mappers;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Interfaces;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        public async Task<Guid> CreateAsync(CreateCategoryDto dto)
        {
            Category category = dto.ToEntity();
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Category category = (await _categoryRepository.GetByIdAsync(id)).ThrowIfNull<Category>();
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategory query)
        {
            PagedResult<Category> pagedCategories =  await _categoryRepository.GetAllAsync(query);
            return pagedCategories.Map(c => c.ToDto());
        }

        public async Task<PagedResult<CategoryDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Category> pagedCategories =  await _categoryRepository.GetAllAsync(query);
            return pagedCategories.Map(c => c.ToDto());
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id).ThrowIfNullAsync<Category>();
            return category.ToDto();
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            Category category = await _categoryRepository.GetByIdAsync(id).ThrowIfNullAsync<Category>();
            category.Name = dto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
