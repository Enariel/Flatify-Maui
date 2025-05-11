using System.Collections;
using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Returns true if the list is not null and has at least one item.
/// </summary>
public class IsListNotNullOrEmptyConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IEnumerable enumerable)
            return enumerable.Cast<object>().Any();
        return false;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException($"{nameof(IsListNotNullOrEmptyConverter)} does not support ConvertBack.");
}