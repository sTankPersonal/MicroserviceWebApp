using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeService.Domain.Entities;

namespace RecipeService.Infrastructure.Persistence.Configurations
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(ri => ri.Id);

            builder.Property(ri => ri.Quantity)
                .IsRequired();

            builder.HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ri => ri.Unit)
                .WithMany(u => u.RecipeIngredients)
                .HasForeignKey(ri => ri.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
