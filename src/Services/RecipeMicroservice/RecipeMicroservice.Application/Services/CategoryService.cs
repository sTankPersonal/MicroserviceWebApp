using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using BuildingBlocks.SharedKernel.DomainServices;

namespace RecipeMicroservice.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : BasicCrudService<Category, Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto, FilterCategory>(categoryRepository), ICategoryService
    {
        protected override Category ToEntity(CreateCategoryDto dto) => dto.ToEntity();
        protected override void ToEntity(UpdateCategoryDto dto, Category entity) => _ = dto.ToEntity(entity);
        protected override CategoryDto ToDto(Category entity) => entity.ToDto();

    }
}
