using BuildingBlocks.CrossCutting.Utils;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Application.DTOs.MovieCategory;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Application.Mappers;
using MovieMicroservice.Domain.Aggregates;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Interfaces;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Application.Services
{
    public class MovieService(IMovieRepository movieRepository, IPhotoFileStorage photoFileStorage) : IMovieService
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly IPhotoFileStorage _photoFileStorage = photoFileStorage;
        public async Task<Guid> CreateAsync(CreateMovieDto dto)
        {
            Movie movie = dto.ToEntity();
            await _movieRepository.AddAsync(movie);
            return movie.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id).ThrowIfNullAsync<Movie>();
            foreach (Photo photo in movie.Photos)
                await _photoFileStorage.DeleteFileAsync(photo);
            
            await _movieRepository.DeleteAsync(movie);
        }

        public async Task<PagedResult<MovieDto>> GetAllAsync(FilterMovie filter)
        {
            PagedResult<Movie> pagedRecipes = await _movieRepository.GetAllAsync(filter);
            return pagedRecipes.Map(r => r.ToDto());
        }

        public async Task<PagedResult<MovieDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Movie> pagedRecipes = await _movieRepository.GetAllAsync(query);
            return pagedRecipes.Map(r => r.ToDto());
        }

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            Movie? movie = await _movieRepository.GetByIdAsync(id);
            return movie?.ToDto();
        }

        public async Task UpdateAsync(Guid id, UpdateMovieDto dto)
        {
            Movie movie = await _movieRepository.GetByIdAsync(id).ThrowIfNullAsync<Movie>();
            Movie updatedMovie = dto.ToEntity(movie);
            await _movieRepository.UpdateAsync(updatedMovie);
        }

        
        public async Task<Guid> CreateMovieCategoryAsync(Guid recipeId, Guid categoryId, CreateMovieCategoryDto dto)
        {
            Movie movie = await _movieRepository.GetByIdAsync(recipeId).ThrowIfNullAsync<Movie>();
            MovieCategory movieCategory = dto.ToEntity(movie.Id, categoryId);

            await _movieRepository.AddMovieCategoryAsync(movie, movieCategory);
            return movieCategory.Id;
        }
        public async Task UpdateMovieCategoryAsync(Guid recipeId, Guid recipeCategoryId, UpdateMovieCategoryDto dto)
        {
            Movie movie = await _movieRepository.GetByIdAsync(recipeId).ThrowIfNullAsync<Movie>();
            MovieCategory movieCategory = movie.MovieCategories.FirstOrDefault(rc => rc.Id == recipeCategoryId).ThrowIfNull<MovieCategory>();

            MovieCategory updatedMovieCategory = dto.ToEntity(movieCategory);
            await _movieRepository.UpdateMovieCategoryAsync(movie, updatedMovieCategory);
        }
        public async Task DeleteMovieCategoryAsync(Guid recipeId, Guid recipeCategoryId)
        {
            Movie movie = await _movieRepository.GetByIdAsync(recipeId).ThrowIfNullAsync<Movie>();
            MovieCategory movieCategory = movie.MovieCategories.FirstOrDefault(rc => rc.Id == recipeCategoryId).ThrowIfNull<MovieCategory>();

            await _movieRepository.DeleteMovieCategoryAsync(movie, movieCategory);
        }
    }
}
