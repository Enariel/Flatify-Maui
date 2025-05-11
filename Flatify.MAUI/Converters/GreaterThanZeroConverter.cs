using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts numeric values to a boolean indicating whether the value is greater than zero.
/// This converter supports multiple numeric types (e.g., int, decimal, double).
/// </summary>
public class GreaterThanZeroConverter : IValueConverter
{
    /// <summary>
    /// You can set a threshold where the value must be greater than to return true.
    /// </summary>
    /// <remarks>Default is 0.</remarks>
    public double Threshold { get; set; } = 0;
    
    public object Convert(object value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            int i => i > Threshold,
            decimal d => d > (decimal)Threshold,
            double dbl => dbl > Threshold,
            float flt => flt > Threshold,
            long lng => lng > Threshold,
            short shrt => shrt > Threshold,
            _ => false
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue && boolValue)
            return System.Convert.ChangeType(1, targetType);

        return System.Convert.ChangeType(0, targetType);
    }
}