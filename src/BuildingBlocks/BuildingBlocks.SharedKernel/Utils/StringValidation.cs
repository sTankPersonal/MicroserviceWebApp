namespace BuildingBlocks.SharedKernel.Utils
{
    public static class StringValidation
    {
        public static string ThrowIfNullOrEmpty(this string? value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("String parameter cannot be null or empty.", parameterName);
            }
            return value;
        }
    }
}
