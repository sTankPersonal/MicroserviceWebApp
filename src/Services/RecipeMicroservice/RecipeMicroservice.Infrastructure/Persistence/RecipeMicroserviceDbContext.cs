using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Infrastructure.Persistence.Configurations;

namespace RecipeMicroservice.Infrastructure.Persistence
{
    public class RecipeMicroserviceDbContext(DbContextOptions<RecipeMicroserviceDbContext> options) : DbContext(options)
    {
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Unit> Units => Set<Unit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeInstructionConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
