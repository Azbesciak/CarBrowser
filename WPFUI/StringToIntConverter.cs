using System;
using System.Windows.Data;

namespace Kups.CarBrowser.WPFUI
{
    [ValueConversion(typeof(int), typeof(string))]
    public class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => value?.ToString() ?? "";

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            int.TryParse(value?.ToString(), out var res);
            return res;
        }
    }
}