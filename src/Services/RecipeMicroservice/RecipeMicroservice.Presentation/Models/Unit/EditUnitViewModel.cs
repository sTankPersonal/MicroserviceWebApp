using RecipeMicroservice.Application.DTOs.Unit;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class EditUnitViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        public static EditUnitViewModel FromDto(UnitDto dto)
        {
            return new EditUnitViewModel
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
