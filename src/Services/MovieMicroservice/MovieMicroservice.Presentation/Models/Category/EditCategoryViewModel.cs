using MovieMicroservice.Application.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.Category
{
    public class EditCategoryViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the Category.")]
        [Display(Name = "Category Name")]
        [StringLength(200, ErrorMessage = "Category name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        public static EditCategoryViewModel FromDto(CategoryDto categoryDto)
        {
            return new EditCategoryViewModel
            {
                Name = categoryDto.Name
            };
        }
    }
}
