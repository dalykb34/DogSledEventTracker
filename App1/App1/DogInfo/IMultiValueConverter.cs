using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace App1.DogInfo
{
    interface IMultiValueConverter
    {
        object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
        object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
    }
}
