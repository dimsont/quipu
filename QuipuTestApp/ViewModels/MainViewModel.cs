using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuipuTestApp.Enums;
using QuipuTestApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace QuipuTestApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IncomeCalculatorService _incomeCalculatorService;

        // Input fields
        [ObservableProperty]
        private decimal? amount;

        partial void OnAmountChanged(decimal? value)
        {
            CalculateCommand.NotifyCanExecuteChanged();
            ValidateAmount();
        }

        [ObservableProperty]
        private int? termInMonths;

        partial void OnTermInMonthsChanged(int? value)
        {
            CalculateCommand.NotifyCanExecuteChanged();
            ValidateTermInMonths();
        }

        [ObservableProperty]
        private double? interestRate;

        partial void OnInterestRateChanged(double? value)
        {
            CalculateCommand.NotifyCanExecuteChanged();
            ValidateInterestRate();
        }

        [ObservableProperty]
        private bool isCapitalized;

        [ObservableProperty]
        private string selectedCurrency;

        partial void OnSelectedCurrencyChanged(string value)
        {
            CalculateCommand.NotifyCanExecuteChanged();
            ValidateCurrencySelection();
        }

        [ObservableProperty]
        private ObservableCollection<string> currencies;

        // Output field
        [ObservableProperty]
        private string expectedIncome;

        // Command to calculate expected income
        public IRelayCommand CalculateCommand { get; }

        // Brush properties for validation
        [ObservableProperty]
        private Brush amountBorderBrush = Brushes.Red;

        [ObservableProperty]
        private Brush termInMonthsBorderBrush = Brushes.Red;

        [ObservableProperty]
        private Brush interestRateBorderBrush = Brushes.Red;

        [ObservableProperty]
        private Brush selectedCurrencyBorderBrush = Brushes.Red;

        public MainViewModel()
        {
            _incomeCalculatorService = new IncomeCalculatorService();

            CalculateCommand = new RelayCommand(CalculateIncome, CanCalculate);

            Currencies = new ObservableCollection<string>(Enum.GetNames(typeof(Currency)));
            ValidateFields();
        }

        // Calculation logic now uses IncomeCalculatorService
        private void CalculateIncome()
        {
            if (Amount == null || TermInMonths == null || InterestRate == null || Amount <= 0 || InterestRate <= 0 || TermInMonths <= 0)
            {
                ExpectedIncome = string.Empty; // If inputs are invalid, set income to empty
                return;
            }

            var income = _incomeCalculatorService.CalculateIncome(Amount.Value, TermInMonths.Value, InterestRate.Value, IsCapitalized);

            // Set Expected Income with currency
            ExpectedIncome = $"{income:0.00} {SelectedCurrency}";
        }

        private bool CanCalculate()
        {
            return Amount.HasValue && TermInMonths.HasValue && InterestRate.HasValue &&
                   Amount > 0 && TermInMonths > 0 && InterestRate > 0 &&
                   !string.IsNullOrEmpty(SelectedCurrency);
        }

        private void ValidateFields()
        {
            ValidateAmount();
            ValidateTermInMonths();
            ValidateInterestRate();
            ValidateCurrencySelection();
        }

        private void ValidateAmount()
        {
            if (Amount == null || Amount <= 0)
            {
                AmountBorderBrush = Brushes.Red;
            }
            else
            {
                AmountBorderBrush = Brushes.Gray;
            }
        }

        private void ValidateTermInMonths()
        {
            if (TermInMonths == null || TermInMonths <= 0)
            {
                TermInMonthsBorderBrush = Brushes.Red;
            }
            else
            {
                TermInMonthsBorderBrush = Brushes.Gray;
            }
        }

        private void ValidateInterestRate()
        {
            if (InterestRate == null || InterestRate <= 0)
            {
                InterestRateBorderBrush = Brushes.Red;
            }
            else
            {
                InterestRateBorderBrush = Brushes.Gray;
            }
        }

        private void ValidateCurrencySelection()
        {
            if (string.IsNullOrEmpty(SelectedCurrency))
            {
                SelectedCurrencyBorderBrush = Brushes.Red;
            }
            else
            {
                SelectedCurrencyBorderBrush = Brushes.Gray;
            }
        }
    }
}
