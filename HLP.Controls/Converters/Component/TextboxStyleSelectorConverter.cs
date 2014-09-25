using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Controls.Converters.Component
{
    public class TextboxStyleSelectorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Controls;component/Resources/Styles/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            if ((bool?)value == true)
            {
                return resource[key: "HLP_TextBox_Search"] as Style;
            }
            else
                return resource[key: "HLP_TextBox"] as Style;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
