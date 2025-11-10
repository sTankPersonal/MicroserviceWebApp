using RecipeMicroservice.Presentation.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class UpdateUnitViewModel : IHasEntity<UpdateUnitViewModel, Guid>
    {
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public UpdateUnitViewModel WithId(Guid id) => (Id = id, this).Item2;
    }
}
