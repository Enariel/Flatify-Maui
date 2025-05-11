using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts a DateTime to a string.
/// </summary>
public class DateTimeToStringConverter : IValueConverter
{
    /// <summary>
    /// You can specify a custom date format.
    /// </summary>
    public string DateFormat { get; set; } = "dd-MM-yyyy HH:mm:ss";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dt)
        {
            string format = parameter as string ?? DateFormat;
            return dt.ToString(format, culture);
        }
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            if (DateTime.TryParseExact(s, parameter as string ?? DateFormat, culture, DateTimeStyles.None, out var result))
                return result;
            if (DateTime.TryParse(s, culture, DateTimeStyles.None, out result))
                return result;
        }
        return DateTime.UnixEpoch;
    }
}