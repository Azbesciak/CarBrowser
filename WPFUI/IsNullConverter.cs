using System;
using System.Windows.Data;

namespace WPFUI
{

    [ValueConversion(typeof(object), typeof(bool))]
    public class IsNullToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => (value == null) ? "Hidden" : "Visible";

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => Binding.DoNothing;
    }
}