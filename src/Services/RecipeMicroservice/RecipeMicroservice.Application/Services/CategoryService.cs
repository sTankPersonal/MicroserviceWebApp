using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
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
            Category category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
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
            return (await _categoryRepository.GetByIdAsync(id) ?? null)?.ToDto();
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            category.Name = dto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
