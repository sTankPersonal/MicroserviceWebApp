
using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            builder.HasMany(c => c.MovieCategories)
                .WithOne(mc => mc.Category)
                .HasForeignKey(mc => mc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
