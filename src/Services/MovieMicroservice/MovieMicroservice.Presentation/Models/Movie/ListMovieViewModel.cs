using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.Movie;
using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.Movie
{
    public class ListMovieViewModel : BaseListViewModel<MovieViewModel>
    {
        [Display(Name = "Search Recipe Name")]
        public string? SearchName { get; set; } = null;
        [Display(Name = "Search Categories")]
        public Guid? SearchCategoryId { get; set; } = null;

        public static ListMovieViewModel FromPagedResult(PagedResult<MovieDto> pagedResult) => new()
        {
            Items = [.. pagedResult.Items.Select(MovieViewModel.FromDto)],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static ListMovieViewModel FromPagedResult(PagedResult<MovieDto> pagedResult, string? searchName, Guid? searchCategoryId) => new()
        {
            Items = [.. pagedResult.Items.Select(MovieViewModel.FromDto)],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems,
            SearchName = searchName,
            SearchCategoryId = searchCategoryId
        };
    }
}
