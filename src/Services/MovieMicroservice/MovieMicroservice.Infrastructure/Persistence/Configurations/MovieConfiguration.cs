using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMicroservice.Domain.Aggregates;

namespace MovieMicroservice.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.HasWatched)
                .IsRequired();

            // Relationships
            builder.HasMany(m => m.MovieCategories)
                .WithOne(mc => mc.Movie)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Photos)
                .WithOne(p => p.Movie)
                .HasForeignKey(p => p.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
