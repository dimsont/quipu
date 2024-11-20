namespace QuipuTestApp.Services
{
    public class IncomeCalculatorService
    {
        public decimal CalculateIncome(decimal amount, int termInMonths, double interestRate, bool isCapitalized)
        {
            double ratePerMonth = interestRate / 100 / 12;
            decimal income;

            if (isCapitalized)
            {
                // Compound interest calculation
                income = amount * (decimal)Math.Pow(1 + ratePerMonth, termInMonths) - amount;
            }
            else
            {
                // Simple interest calculation with monthly payout
                income = amount * (decimal)(ratePerMonth * termInMonths);
            }

            return income;
        }
    }
}

