using System;
using System.Globalization;
using System.Windows.Data;

namespace ManejoContabilidad.Wpf.Converters;

public class ObjectNullConverter : IValueConverter
{
    /// <summary>
    /// Returns <paramref name="value"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>Return <paramref name="value"/></returns>
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
    /// <summary>
    /// Returns <b>null</b>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns><b>null</b></returns>
    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}