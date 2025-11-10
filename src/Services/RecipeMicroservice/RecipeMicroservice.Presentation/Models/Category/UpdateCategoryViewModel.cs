using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class UpdateCategoryViewModel : IHasEntity<UpdateCategoryViewModel, Guid>
    {
        [Required(ErrorMessage = "Please enter a name for the Category.")]
        [Display(Name = "Category Name")]
        [StringLength(200, ErrorMessage = "Category name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public UpdateCategoryViewModel WithId(Guid id) => (Id = id, this).Item2;
    }
}
