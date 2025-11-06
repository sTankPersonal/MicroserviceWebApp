using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Infrastructure.Persistence.Configurations
{
    public class RecipeInstructionConfiguration : IEntityTypeConfiguration<RecipeInstruction>
    {
        public void Configure(EntityTypeBuilder<RecipeInstruction> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.StepNumber)
                .IsRequired();
            builder.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(i => i.Recipe)
                .WithMany(r => r.RecipeInstructions)
                .HasForeignKey(i => i.RecipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
