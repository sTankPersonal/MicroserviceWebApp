using MovieMicroservice.Application.DTOs.Category;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Application.Mappers
{
    public static class CategoryMapper 
    {
        public static Category ToEntity(this CreateCategoryDto createCategoryDto) => new()
        {
            Name = createCategoryDto.Name
        };
        public static CategoryDto ToDto(this Category category) => new()
        {
            Id = category.Id,
            Name = category.Name
        };
        public static IEnumerable<CategoryDto> ToDtos(this IEnumerable<Category> categories) =>
            categories.Select(c => c.ToDto());
    }
}
