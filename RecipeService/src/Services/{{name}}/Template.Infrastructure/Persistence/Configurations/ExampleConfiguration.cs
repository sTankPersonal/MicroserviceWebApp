
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;

namespace Template.Infrastructure.Persistence.Configurations
{
    public class ExampleConfiguration : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Attribute)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
