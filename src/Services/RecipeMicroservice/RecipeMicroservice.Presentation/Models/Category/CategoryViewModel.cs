using RecipeMicroservice.Application.DTOs.Category;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static CategoryViewModel FromDto(CategoryDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
}
