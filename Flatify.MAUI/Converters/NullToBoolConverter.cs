using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts null to false, not null to true.
/// </summary>
/// <remarks>This can be inverted with a parameter of "Invert=true".</remarks>
public class NullToBoolConverter
{
    /// <summary>
    /// If true, reverses normal logic (null => true, not null => false).
    /// </summary>
    public bool Invert { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool result = value != null;
        if (Invert)
            result = !result;
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException($"{nameof(NullToBoolConverter)} does not support ConvertBack.");
}