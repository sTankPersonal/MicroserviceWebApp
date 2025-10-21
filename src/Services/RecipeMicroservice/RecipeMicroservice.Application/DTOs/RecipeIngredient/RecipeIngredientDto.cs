namespace RecipeMicroservice.Application.DTOs.RecipeIngredient
{
    public class RecipeIngredientDto
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string UnitName { get; set; } = string.Empty;

        // Read-only property for display
        public string FormattedQuantity => FormatAmount(Quantity);

        private static string FormatAmount(decimal amount)
        {
            int wholeNumber = (int)Math.Floor(amount);
            decimal fraction = amount - wholeNumber;

            string fractionString = DecimalToFraction(fraction);

            if (wholeNumber == 0 && string.IsNullOrEmpty(fractionString))
                return "0";
            else if (wholeNumber == 0)
                return fractionString;
            else if (string.IsNullOrEmpty(fractionString))
                return wholeNumber.ToString();
            else
                return $"{wholeNumber} {fractionString}";
        }

        private static string DecimalToFraction(decimal value, int maxDenominator = 16)
        {
            if (value == 0)
                return "";

            int bestNumerator = 0;
            int bestDenominator = 1;
            decimal smallestError = decimal.MaxValue;

            for (int denominator = 1; denominator <= maxDenominator; denominator++)
            {
                int numerator = (int)Math.Round(value * denominator);
                decimal error = Math.Abs(value - (decimal)numerator / denominator);

                if (error < smallestError)
                {
                    bestNumerator = numerator;
                    bestDenominator = denominator;
                    smallestError = error;
                }

                if (error == 0)
                    break;
            }

            return $"{bestNumerator}/{bestDenominator}";
        }
    }
}
