namespace BuildingBlocks.SharedKernel.Pagination
{
    public static class PagedResultMapper
    {
        public static PagedResult<TDestination> Map<TSource, TDestination>(this PagedResult<TSource> source, Func<TSource, TDestination> mapFunc)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(mapFunc);

            IEnumerable<TDestination> mappedItems = source.Items.Select(mapFunc);
            return new PagedResult<TDestination>(
                mappedItems,
                source.TotalItems,
                source.PageNumber,
                source.PageSize);
        }
    }
}
