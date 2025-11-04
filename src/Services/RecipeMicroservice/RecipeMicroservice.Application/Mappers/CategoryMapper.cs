using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class CategoryMapper 
    {
        public static Category ToEntity(this CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                Name = createCategoryDto.Name
            };
        }
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public static IEnumerable<CategoryDto> ToDtos(this IEnumerable<Category> categories)
        {
            return categories.Select(c => c.ToDto());
        }
    }
}
