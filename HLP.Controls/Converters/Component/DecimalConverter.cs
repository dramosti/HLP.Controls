using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Controls.Converters.Component
{
    public class decimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal d;

            string nCasasDecimais = "";

            if (parameter != null)
                if (parameter != "")
                    nCasasDecimais = parameter.ToString();

            if (value == null)
            {
                d = decimal.Zero;
            }
            else if (!decimal.TryParse(s: value.ToString(), result: out d))
            {
                d = decimal.Zero;
            }

            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal valor;

            if (value != null)
            {
                if (decimal.TryParse(value.ToString(), out valor))
                    return valor;
            }

            return decimal.Zero;
        }
    }
}
