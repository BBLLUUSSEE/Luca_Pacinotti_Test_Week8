using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Esercitazione.Week8.WPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new InvalidProgramException("Il valore di binding non può essere nullo");

            if (!(value is bool))
                throw new InvalidProgramException($"Il valore di binding deve essere di tipo {typeof(bool).FullName}");

            bool boolValue = (bool)value;
            return boolValue ?
                Visibility.Collapsed :
                Visibility.Visible;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
