using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;
using Template.Infrastructure.Persistence.Configurations;

namespace Template.Infrastructure.Persistence
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
