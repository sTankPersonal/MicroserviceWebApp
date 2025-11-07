using RecipeMicroservice.Application.Interfaces.ViewModels;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class FilterUnitViewModel: IViewModelToDto<FilterUnitViewModel, FilterUnit>, IViewModelFromDto<FilterUnitViewModel, FilterUnit>
    {
        public string? SearchName { get; set; }
        public static FilterUnitViewModel FromDto(FilterUnit dto) => new() { SearchName = dto.SearchName };
        public static FilterUnit ToDto(FilterUnitViewModel viewModel) => new() { SearchName = viewModel.SearchName };
    }
}
