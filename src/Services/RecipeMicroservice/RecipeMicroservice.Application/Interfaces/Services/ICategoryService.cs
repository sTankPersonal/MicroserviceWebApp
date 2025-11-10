using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface ICategoryService : IBasicCrudService<Guid, CategoryDto, CreateCategoryDto, UpdateCategoryDto, FilterCategory>
    {
    }
}
