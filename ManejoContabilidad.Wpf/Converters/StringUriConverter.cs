using System;
using System.Globalization;
using System.Windows.Data;

namespace ManejoContabilidad.Wpf.Converters;

/// <summary>
/// Converts a <see cref="string"/> into an <see cref="Uri"/>
/// </summary>
public class StringUriConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType == typeof(Uri) && value is string str)
        {
            return string.IsNullOrWhiteSpace(str)
                ? null
                : new Uri(str);
        }

        return value;
        // throw new ArgumentException(
        //     $"The {nameof(targetType)} must be of type {typeof(Uri)} and {nameof(value)} must be of type {typeof(string)}");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Uri uri && targetType == typeof(string))
        {
            return uri.AbsolutePath;
        }

        return value;
    }
}