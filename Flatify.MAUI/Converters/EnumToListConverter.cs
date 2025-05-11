using System.Globalization;

namespace Flatify.MAUI.Converters;

/// <summary>
/// Converts an enum to a list of enum values.
/// </summary>
public class EnumToListConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;
        
        Type enumType;
        if (value is Enum enumValue)
            enumType = enumValue.GetType();
        else
            enumType = value as Type ?? value.GetType();
        
        if (!enumType.IsEnum)
            return null;
        
        var enumValues = Enum.GetValues(enumType);
        var result = new List<object>();

        foreach (var item in enumValues) 
            result.Add(item);

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}