

namespace BuildingBlocks.SharedKernel.Repositories
{
    public abstract class PagedQuery
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public PagedQuery(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page number must be greater than zero.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be greater than zero.");
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int Skip => (PageNumber - 1) * PageSize;
        public int Take => PageSize;
    }
}
