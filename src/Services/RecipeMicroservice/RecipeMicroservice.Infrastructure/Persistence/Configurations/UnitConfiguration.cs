
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Infrastructure.Persistence.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(u => u.RecipeIngredients)
                .WithOne(ri => ri.Unit)
                .HasForeignKey(ri => ri.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
