namespace QuipuTestApp.Tests.Services
{
    public class IncomeCalculatorServiceTests
    {
        [Fact]
        public void CalculateIncome_WithCapitalization_ShouldReturnCorrectIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = 12;
            double interestRate = 5;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.True(result > 0);
            Assert.Equal(51.16m, result, 2); // Expecting compound interest, rounded to 2 decimal places
        }

        [Fact]
        public void CalculateIncome_WithMonthlyPayout_ShouldReturnCorrectIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = 12;
            double interestRate = 5;
            bool isCapitalized = false;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.True(result > 0);
            Assert.Equal(50.00m, result, 2); // Expecting simple interest, rounded to 2 decimal places
        }

        [Fact]
        public void CalculateIncome_WithZeroAmount_ShouldReturnZeroIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 0;
            int termInMonths = 12;
            double interestRate = 5;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateIncome_WithNegativeInterestRate_ShouldReturnZeroIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = 12;
            double interestRate = -5;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateIncome_WithNegativeTerm_ShouldReturnZeroIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = -12;
            double interestRate = 5;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateIncome_WithZeroInterestRate_ShouldReturnZeroIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = 12;
            double interestRate = 0;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateIncome_WithOneMonthTerm_ShouldReturnCorrectIncome()
        {
            // Arrange
            var incomeCalculatorService = new IncomeCalculatorService();
            decimal amount = 1000;
            int termInMonths = 1;
            double interestRate = 5;
            bool isCapitalized = true;

            // Act
            var result = incomeCalculatorService.CalculateIncome(amount, termInMonths, interestRate, isCapitalized);

            // Assert
            Assert.True(result > 0);
            Assert.Equal(4.17m, result, 2); // Expecting compound interest for one month, rounded to 2 decimal places
        }
    }
}
