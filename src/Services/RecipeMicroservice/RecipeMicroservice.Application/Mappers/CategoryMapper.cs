using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class CategoryMapper 
    {
        public static Category ToEntity(this CreateCategoryDto createCategoryDto) => new()
        {
            Name = createCategoryDto.Name
        };
        public static Category ToEntity(this UpdateCategoryDto updateCategoryDto, Category category)
        {
            category.Name = updateCategoryDto.Name;
            return category;
        }
        public static CategoryDto ToDto(this Category category) => new()
        {
            Id = category.Id,
            Name = category.Name
        };
        public static IEnumerable<CategoryDto> ToDtos(this IEnumerable<Category> categories) =>
            categories.Select(c => c.ToDto());
    }
}
