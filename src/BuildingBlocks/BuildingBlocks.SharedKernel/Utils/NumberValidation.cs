namespace BuildingBlocks.SharedKernel.Utils
{
    public static class NumberValidation
    {
        public static int ThrowIfNegative(this int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Numeric parameter cannot be negative.");
            }
            return value;
        }
        public static int ThrowIfNegativeOrZero(this int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Numeric parameter must be greater than zero.");
            }
            return value;
        }
    }
}
