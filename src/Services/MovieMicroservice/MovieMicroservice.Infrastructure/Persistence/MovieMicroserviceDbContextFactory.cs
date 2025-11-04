using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieMicroservice.Infrastructure.Persistence
{
    public class MovieMicroserviceDbContextFactory : IDesignTimeDbContextFactory<MovieMicroserviceDbContext>
    {
        public MovieMicroserviceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieMicroserviceDbContext>();

            // Dummy connection string — database doesn't need to exist to generate migrations
            optionsBuilder.UseNpgsql("Host=localhost;Database=DummyDb;Username=sa;Password=sa");

            return new MovieMicroserviceDbContext(optionsBuilder.Options);
        }
    }
}
