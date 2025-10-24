using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class CreateUnitViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the Unit.")]
        [Display(Name = "Unit Name")]
        [StringLength(200, ErrorMessage = "Unit name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
