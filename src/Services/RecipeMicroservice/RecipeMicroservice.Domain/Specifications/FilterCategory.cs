using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterCategory : PagedQuery
    {
        public string SearchName { get; init; } = string.Empty;
    }
}
