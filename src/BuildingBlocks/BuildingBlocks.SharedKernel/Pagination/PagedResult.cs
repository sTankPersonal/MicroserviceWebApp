using System.Collections.Immutable;
using BuildingBlocks.SharedKernel.Utils;

namespace BuildingBlocks.SharedKernel.Pagination
{
    public class PagedResult<T>
    {
        public ImmutableArray<T> items;
        private int totalItems;
        private int pageNumber;
        private int pageSize;
        public IEnumerable<T> Items
        {
            get => items;
            init => items = ImmutableArray.CreateRange(value);
        }
        public int TotalItems
        {
            get => totalItems;
            init => totalItems = value.ThrowIfNegative(nameof(TotalItems));
        }
        public int PageNumber {
            get => pageNumber;
            init => pageNumber = value.ThrowIfNegative(nameof(PageNumber));
        }
        public int PageSize {
            get => pageSize;
            init => pageSize = value.ThrowIfNegative(nameof(PageSize));
        }
    }
}
