using BuildingBlocks.SharedKernel.Entities;

namespace RecipeMicroservice.Domain.Entities
{
    public class Photo : BaseEntity<Guid>
    {
        public string Url { get; set; } = string.Empty;
    }
}
