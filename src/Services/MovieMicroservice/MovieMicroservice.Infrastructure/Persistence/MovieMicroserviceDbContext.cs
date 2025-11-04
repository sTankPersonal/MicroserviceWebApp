using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Domain.Aggregates;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Infrastructure.Persistence.Configurations;

namespace MovieMicroservice.Infrastructure.Persistence
{
    public class MovieMicroserviceDbContext(DbContextOptions<MovieMicroserviceDbContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Category> Categories => Set<Category>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
