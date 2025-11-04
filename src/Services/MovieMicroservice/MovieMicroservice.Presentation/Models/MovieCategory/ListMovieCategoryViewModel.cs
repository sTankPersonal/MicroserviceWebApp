using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.MovieCategory;

namespace MovieMicroservice.Presentation.Models.MovieCategory
{
    public class ListMovieCategoryViewModel : BaseListViewModel<MovieCategoryViewModel>
    {
        public string ? SearchName { get; set; } = null;
        public static ListMovieCategoryViewModel FromPagedResult(PagedResult<MovieCategoryDto> pagedResult)
        {
            return new ListMovieCategoryViewModel
            {
                Items = [.. pagedResult.Items.Select(MovieCategoryViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}
