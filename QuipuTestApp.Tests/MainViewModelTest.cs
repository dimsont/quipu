

namespace QuipuTestApp.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void CalculateIncome_WithValidInput_ExpectedIncomeIsCalculatedCorrectly()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Amount = 1000m,
                TermInMonths = 12,
                InterestRate = 5.0,
                IsCapitalized = true,
                SelectedCurrency = "USD"
            };

            // Act
            viewModel.CalculateCommand.Execute(null);

            // Assert
            Assert.Equal("51.16 USD", viewModel.ExpectedIncome); // Adjust expected value as appropriate
        }

        [Fact]
        public void CalculateIncome_WithNegativeAmount_ExpectedIncomeShouldBeEmpty()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Amount = -1000m,
                TermInMonths = 12,
                InterestRate = 5.0,
                IsCapitalized = true,
                SelectedCurrency = "USD"
            };

            // Act
            viewModel.CalculateCommand.Execute(null);

            // Assert
            Assert.Equal(string.Empty, viewModel.ExpectedIncome);
        }

        [Fact]
        public void CalculateIncome_WithZeroInterestRate_ExpectedIncomeShouldBeZero()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Amount = 1000m,
                TermInMonths = 12,
                InterestRate = 0.0,
                IsCapitalized = true,
                SelectedCurrency = "USD"
            };

            // Act
            viewModel.CalculateCommand.Execute(null);

            // Assert
            Assert.Equal("0.00 USD", viewModel.ExpectedIncome);
        }
    }
}
