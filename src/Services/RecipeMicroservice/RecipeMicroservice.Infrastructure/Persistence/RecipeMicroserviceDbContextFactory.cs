using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipeMicroservice.Infrastructure.Persistence
{
    public class RecipeMicroserviceDbContextFactory : IDesignTimeDbContextFactory<RecipeMicroserviceDbContext>
    {
        public RecipeMicroserviceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeMicroserviceDbContext>();

            // Dummy connection string — database doesn't need to exist to generate migrations
            optionsBuilder.UseNpgsql("Host=localhost;Database=DummyDb;Username=sa;Password=sa");

            return new RecipeMicroserviceDbContext(optionsBuilder.Options);
        }
    }
}
