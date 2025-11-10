using BuildingBlocks.SharedKernel.Utils;

namespace BuildingBlocks.SharedKernel.Pagination
{
    public abstract record PagedQuery
    {
        private int pageNumber = 1;
        private int pageSize = 10;
        public int PageNumber
        {
            get => pageNumber;
            init => pageNumber = value.ThrowIfNegativeOrZero(nameof(PageNumber));
        }
        public int PageSize
        {             
            get => pageSize;
            init => pageSize = value.ThrowIfNegativeOrZero(nameof(PageSize));
        }
        public int Skip => (PageNumber - 1) * PageSize;
        public int Take => PageSize;
    }
}
