using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterCategory(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}
