using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class UnitViewModel : BaseIdViewModel<Guid>, IViewModelFromDto<UnitViewModel, UnitDto>, IViewModelToDto<UnitViewModel, UnitDto>
    {
        [Required(ErrorMessage = "Please enter a name for the Ingredient.")]
        [Display(Name = "Ingredient Name")]
        [StringLength(200, ErrorMessage = "Ingredient name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
        
        public static UnitViewModel FromDto(UnitDto dto) => new() { Id = dto.Id, Name = dto.Name };
        public static UnitDto ToDto(UnitViewModel viewModel) => new() { Id = viewModel.Id, Name = viewModel.Name };
    }
}
