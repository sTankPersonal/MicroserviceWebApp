using Microsoft.EntityFrameworkCore;
using RecipeService.Domain.Entities;
using RecipeService.Infrastructure.Persistence.Configurations;

namespace RecipeService.Infrastructure.Persistence
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<ExampleEntity> Examples => Set<ExampleEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ExampleEntity>(new ExampleConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
