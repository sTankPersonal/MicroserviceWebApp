using BuildingBlocks.SharedKernel.Pagination;

namespace MovieMicroservice.Domain.Specifications
{
    public record FilterMovie(string? SearchName = null, Guid? SearchCategoryId = null, int PageNumber = 1, int PageSize = 10) : PagedQuery(PageNumber, PageSize)
    {
        public string? SearchName { get; } = SearchName;
        public Guid? SearchCategoryId { get; } = SearchCategoryId;
    }
}
