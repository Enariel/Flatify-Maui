using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts a hex color string to a Color object.
/// </summary>
public class HexToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string hexColor || string.IsNullOrWhiteSpace(hexColor))
            return Colors.Transparent;

        try
        {
            return Color.FromArgb(hexColor);
        }
        catch
        {
            return Colors.Transparent;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Color color)
            return "#000000";

        return $"#{color.ToArgbHex()}";
    }
}