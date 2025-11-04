using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class ListCategoryViewModel : BaseListViewModel<CategoryViewModel>
    {
        public string? SearchName { get; set; }
    }
}
