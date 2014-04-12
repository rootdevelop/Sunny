using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace Sunny.Core.Converters
{
    public class InverseBooleanConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }
    }
}
