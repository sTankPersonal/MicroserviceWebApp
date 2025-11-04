using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Domain.Aggregates;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Domain.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<PagedResult<Movie>> GetAllAsync(FilterMovie query);

        // Aggregate Child - Categories
        Task AddMovieCategoryAsync(Movie movie, MovieCategory category);
        Task UpdateMovieCategoryAsync(Movie movie, MovieCategory category);
        Task DeleteMovieCategoryAsync(Movie movie, MovieCategory category);

        // Aggregate Child - Photos
        Task AddMoviePhotoAsync(Movie movie, Photo photo);
    }
}
