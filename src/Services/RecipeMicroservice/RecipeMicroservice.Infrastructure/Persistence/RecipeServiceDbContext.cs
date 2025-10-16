using Microsoft.EntityFrameworkCore;
using RecipeService.Domain.Aggregates;
using RecipeService.Domain.Entities;
using RecipeService.Infrastructure.Persistence.Configurations;

namespace RecipeService.Infrastructure.Persistence
{
    public class RecipeServiceDbContext : DbContext
    {
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Unit> Units => Set<Unit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Recipe>(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Ingredient>(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration<RecipeCategory>(new RecipeCategoryConfiguration());
            modelBuilder.ApplyConfiguration<RecipeIngredient>(new RecipeIngredientConfiguration());
            modelBuilder.ApplyConfiguration<Unit>(new UnitConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
