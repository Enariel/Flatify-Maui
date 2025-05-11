namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts a boolean to an ImageSource.
/// </summary>
/// <remarks>
/// This is usually used to change an icon on a toggle button.
/// </remarks>
public class BoolToImageSourceConverter : IValueConverter
{
    /// <summary>
    /// The image to use when the value is true.
    /// </summary>
    public ImageSource TrueSource { get; set; }
    
    /// <summary>
    /// The image to use when the value is false.
    /// </summary>
    public ImageSource FalseSource { get; set; }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is bool b)
            return b ? TrueSource : FalseSource;
        return FalseSource;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}