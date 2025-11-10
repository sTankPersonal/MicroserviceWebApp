using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterUnit : PagedQuery
    {
        public string? SearchName { get; init; } = string.Empty;
    }
}
