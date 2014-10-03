using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Controls.Converters.Component
{
    public class IntegerConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int iValor = 0;
            if (value != null)
                Int32.TryParse(value.ToString(), out iValor);
            return iValor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int iValor = 0;
            if (value != null)
                Int32.TryParse(value.ToString(), out iValor);
            return iValor;
        }
    }
}
