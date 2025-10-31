using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using System.Reflection.Metadata.Ecma335;

namespace RecipeMicroservice.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        public async Task<Guid> CreateAsync(CreateCategoryDto dto)
        {
            Category category = new()
            {
                Name = dto.Name
            };
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<PagedResult<CategoryDto>> GetAllAsync(FilterCategory query)
        {
            PagedResult<Category> pagedCategories =  await _categoryRepository.GetAllAsync(query);
            List<CategoryDto> categoryDtos = [.. pagedCategories.Items
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })];
            return new PagedResult<CategoryDto>(
                categoryDtos,
                pagedCategories.TotalItems,
                pagedCategories.PageNumber,
                pagedCategories.PageSize);
        }

        public async Task<PagedResult<CategoryDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Category> pagedCategories =  await _categoryRepository.GetAllAsync(query);
            List<CategoryDto> categoryDtos = [.. pagedCategories.Items
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })];
            return new PagedResult<CategoryDto>(
                categoryDtos,
                pagedCategories.TotalItems,
                pagedCategories.PageNumber,
                pagedCategories.PageSize);
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return null;
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name =  category.Name
            };
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            category.Name = dto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
