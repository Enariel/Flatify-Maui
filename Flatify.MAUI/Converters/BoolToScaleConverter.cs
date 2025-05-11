using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts a boolean to a scale.
/// </summary>
public class BoolToScaleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isChecked)
        {
            if (parameter is string paramString && paramString.Contains(','))
            {
                var parts = paramString.Split(',');
                if (parts.Length == 2 &&
                    double.TryParse(parts[0], out double falseValue) &&
                    double.TryParse(parts[1], out double trueValue))
                {
                    return isChecked ? trueValue : falseValue;
                }
            }
            return isChecked ? 1.0 : 0.0;
        }
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}