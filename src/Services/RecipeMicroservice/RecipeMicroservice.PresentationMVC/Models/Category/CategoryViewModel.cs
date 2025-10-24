using RecipeMicroservice.Application.DTOs.Category;

namespace RecipeMicroservice.PresentationMVC.Models.Category
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
