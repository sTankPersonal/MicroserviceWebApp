using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Infrastructure.Persistence.Configurations
{
    public class MovieCategoryConfiguration : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasKey(mc => mc.Id);

            // Foreign Keys
            builder.HasIndex(mc => new { mc.MovieId, mc.CategoryId })
                .IsUnique();

            // Relationships
            builder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
