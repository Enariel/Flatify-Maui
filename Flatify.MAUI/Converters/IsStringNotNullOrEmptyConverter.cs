using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// If a string is empty this returns true. 
/// </summary>
/// <remarks>
/// This can be inverted with a parameter of "Invert=true".
/// Can be used to hide elements if a string is empty.
/// </remarks>
public class IsStringNotNullOrEmptyConverter : IValueConverter
{
    /// <summary>
    /// If true, this will count whitespace as empty/null.
    /// </summary>
    public bool WhitespaceIsNull { get; set; }
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (WhitespaceIsNull)
            return !string.IsNullOrWhiteSpace(value as string);
        return !string.IsNullOrEmpty(value as string);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException($"{nameof(IsStringNotNullOrEmptyConverter)} does not support ConvertBack.");
}