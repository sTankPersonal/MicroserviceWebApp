namespace BuildingBlocks.SharedKernel.Utils
{
    public static class ListValidation
    {
        public static IEnumerable<T> ValidateListNotEmpty<T>(this IEnumerable<T> list, string paramName)
        {
            if (list == null || !list.Any())
            {
                throw new ArgumentException("The list cannot be null or empty.", paramName);
            }
            return list;
        }
    }
}
