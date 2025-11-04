using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Presentation.Models.Movie;
using MovieMicroservice.Presentation.Models.MovieCategory;

namespace MovieMicroservice.Presentation.Mappers
{
    public static class MovieMapper
    {
        public static CreateMovieViewModel ToCreateMovieViewModel(this MovieDto dto) => new()
        {
            Name = dto.Name
        };
        public static CreateMovieDto ToCreateMovieDto(this CreateMovieViewModel vm) => new()
        {
            Name = vm.Name
        };

        public static MovieViewModel ToMovieViewModel(this MovieDto dto) => new()
        {  
            Id = dto.Id,
            Name = dto.Name,
            HasWatched = dto.HasWatched,
            Categories = dto.Categories.Select(MovieCategoryViewModel.FromDto)
        };
        public static MovieDto ToMovieDto(this MovieViewModel vm) => new()
        {
            Id = vm.Id,
            Name = vm.Name,
            HasWatched = vm.HasWatched,
            Categories = vm.Categories.Select(c => c.ToDto())
        };

        public static UpdateMovieViewModel ToUpdateMovieViewModel(this MovieDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UpdateMovieDto ToUpdateMovieDto(this UpdateMovieViewModel vm) => new()
        {
            Id = vm.Id,
            Name = vm.Name
        };

    }
}
