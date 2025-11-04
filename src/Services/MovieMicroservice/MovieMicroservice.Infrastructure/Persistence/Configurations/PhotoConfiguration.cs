using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Infrastructure.Persistence.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(p => p.Movie)
                .WithMany(m => m.Photos)
                .HasForeignKey(p => p.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
