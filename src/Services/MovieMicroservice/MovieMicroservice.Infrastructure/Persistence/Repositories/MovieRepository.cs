using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Domain.Aggregates;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Interfaces;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Infrastructure.Persistence.Repositories
{
    public class MovieRepository(MovieMicroserviceDbContext dbContext) : IMovieRepository
    {
        private readonly MovieMicroserviceDbContext _dbContext = dbContext;

        public async Task AddAsync(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Movie>> GetAllAsync(FilterMovie query)
        {
            IQueryable<Movie> movies = _dbContext.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .AsSplitQuery();

            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                movies = movies.Where(m => EF.Functions.ILike(m.Name, $"%{query.SearchName}%"));
            }
            if (query.SearchCategoryId.HasValue)
            {
                movies = movies.Where(m => m.MovieCategories.Any(mc => mc.CategoryId == query.SearchCategoryId.Value));
            }


            int totalItems = await movies.CountAsync();
            List<Movie> items = await movies
                .OrderBy(m => m.Name)
                .ThenBy(m => m.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync();

            return new PagedResult<Movie>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Movie>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Movie> movies = _dbContext.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .AsSplitQuery();

            int totalItems = await movies.CountAsync();
            List<Movie> items = await movies
                .OrderBy(m => m.Name)
                .ThenBy(m => m.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync();

            return new PagedResult<Movie>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Movies
                .Include(m => m.MovieCategories).ThenInclude(mc => mc.Category)
                .Include(m => m.Photos)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
        }


        // Categories
        public async Task AddMovieCategoryAsync(Movie movie, MovieCategory movieCategory)
        {
            _dbContext.Attach(movie);
            movie.MovieCategories.Add(movieCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovieCategoryAsync(Movie movie, MovieCategory movieCategory)
        {
            _dbContext.Attach(movie);
            _dbContext.Entry(movieCategory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovieCategoryAsync(Movie movie, MovieCategory movieCategory)
        {
            _dbContext.Attach(movie);
            movie.MovieCategories.Remove(movieCategory);
            await _dbContext.SaveChangesAsync();
        }

        // Photos
        public async Task AddMoviePhotoAsync(Movie movie, Photo photo)
        {
            _dbContext.Attach(movie);
            movie.Photos.Add(photo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
