using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class CreateRecipeCategoryViewModel
    {
        [Required]
        public Guid CategoryId { get; set; }
    }
}
