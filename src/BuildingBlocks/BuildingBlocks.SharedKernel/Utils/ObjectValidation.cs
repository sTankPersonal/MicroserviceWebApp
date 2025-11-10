namespace BuildingBlocks.SharedKernel.Utils
{
    public static class ObjectValidation
    {
        public static T ThrowIfNull<T>(this T? value) where T : class
        {
            return value is null ? throw new ArgumentNullException(nameof(T), "Object parameter cannot be null.") : value;
        }

        public static async Task<T> ThrowIfNullAsync<T>(this Task<T?> valueTask) where T : class
        {
            T? value = await valueTask;
            return value is null ? throw new ArgumentNullException(nameof(T), "Object parameter cannot be null.") : value;
        }
    }
}