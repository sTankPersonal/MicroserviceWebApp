using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterUnit(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}
