namespace BuildingBlocks.SharedKernel.Pagination
{
    public static class PagedResultMapper
    {
        public static PagedResult<TDestination> Map<TSource, TDestination>(this PagedResult<TSource> source, Func<TSource, TDestination> mapFunc)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(mapFunc);

            IEnumerable<TDestination> mappedItems = source.Items.Select(mapFunc);
            return new PagedResult<TDestination>()
            {
                Items = mappedItems,
                TotalItems = source.TotalItems,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize
            };
        }
        public static PagedResult<TDestination> Map<TSource, TDestination>(this ICollection<TSource> source, Func<TSource, TDestination> mapFunc)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(mapFunc);
            IEnumerable<TDestination> mappedItems = source.Select(mapFunc);
            return new PagedResult<TDestination>()
            {
                Items = mappedItems,
                TotalItems = mappedItems.Count(),
                PageNumber = 1,
                PageSize = mappedItems.Count()
            };
        }
    }
}
