using System.Collections.Immutable;

namespace BuildingBlocks.SharedKernel.Pagination
{
    public class PagedResult<T>(IEnumerable<T> items, int totalItems, int pageNumber, int pageSize)
    {
        public ImmutableArray<T> Items { get; } = [.. (items ?? throw new ArgumentNullException(nameof(items)))];
        public int TotalItems { get; } = totalItems >= 0 ? totalItems : throw new ArgumentOutOfRangeException(nameof(totalItems), totalItems, "Total items cannot be negative.");
        public int PageNumber { get; } = pageNumber > 0 ? pageNumber : throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page number must be greater than zero.");
        public int PageSize { get; } = pageSize > 0 ? pageSize : throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be greater than zero.");
    }
}
