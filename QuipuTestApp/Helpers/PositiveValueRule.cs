using System.Globalization;
using System.Windows.Controls;

namespace QuipuTestApp.Validation.Helpers
{
    public class PositiveValueRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value.ToString(), out decimal result) && result > 0)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Value must be positive.");
        }
    }
}
