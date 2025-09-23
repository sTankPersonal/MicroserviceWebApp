
namespace BuildingBlocks.SharedKernel.Guards
{
    public static class Guard
    {
        public static void AgainstNull<T>(T value, string parameterName)
        {
            if (value is null)
                throw new ArgumentNullException(parameterName, $"{parameterName} cannot be null.");
        }

        public static void AgainstNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
        }

        public static void AgainstOutOfRange(int value, int min, int max, string parameterName)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be between {min} and {max}.");
        }

        public static void AgainstEmptyCollection<T>(IEnumerable<T> collection, string parameterName)
        {
            if (collection == null || !collection.Any())
                throw new ArgumentException($"{parameterName} cannot be empty.", parameterName);
        }

        public static void Against<TException>(bool condition, string message) where TException : Exception, new()
        {
            if (condition)
                throw (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
    }
}
