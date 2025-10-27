using RecipeMicroservice.Application.DTOs.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class EditIngredientViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        public static EditIngredientViewModel FromDto(IngredientDto dto)
        {
            return new EditIngredientViewModel
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
