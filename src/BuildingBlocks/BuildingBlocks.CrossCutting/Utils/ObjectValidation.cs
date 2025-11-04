namespace BuildingBlocks.CrossCutting.Utils
{
    public static class ObjectValidation
    {
        public static T ThrowIfNull<T>(this T? value) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(T), "Object parameter cannot be null.");
            }
            return value;
        }

        public static Task<T> ThrowIfNullAsync<T>(this Task<T?> valueTask) where T : class
        {
            return valueTask.ContinueWith(t =>
            {
                T? value = t.Result;
                return value is null ? throw new ArgumentNullException(nameof(T), "Object parameter cannot be null.") : value;
            });
        }
    }
}
