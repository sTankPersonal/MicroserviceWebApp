using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class UpdateCategoryViewModel : BaseIdViewModel<Guid>
    {
        [Required(ErrorMessage = "Please enter a name for the Category.")]
        [Display(Name = "Category Name")]
        [StringLength(200, ErrorMessage = "Category name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
