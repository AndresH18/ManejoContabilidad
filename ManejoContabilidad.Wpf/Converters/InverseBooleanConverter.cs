using System;
using System.Globalization;
using System.Windows.Data;

namespace ManejoContabilidad.Wpf.Converters;

public class InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType == typeof(bool))
            return (bool) value;
        throw new ArgumentException("Target value must be bool");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}