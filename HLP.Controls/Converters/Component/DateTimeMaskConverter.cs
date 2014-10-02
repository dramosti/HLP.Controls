using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Controls.Converters.Component
{
    public class DateTimeMaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = new DateTime();
            if (value != null)
                if (DateTime.TryParse(s: value.ToString(), result: out dt))
                    return dt.Date.ToShortDateString();

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                value = value.ToString().Replace(oldValue: "/", newValue: "");
                value = value.ToString().Replace(oldValue: ".", newValue: "");
                value = value.ToString().Replace(oldValue: "-", newValue: "");
                value = value.ToString().Replace(oldValue: " ", newValue: "");
                char[] v = new char[8];

                int day = 0;
                int month = 0;
                int year = 0;

                v = value.ToString().PadRight(totalWidth: 8, paddingChar: '0').ToArray();

                if (v.Count() > 0)
                {
                    month = int.Parse(s: (v[2].ToString() + v[3].ToString()).ToString());
                    day = int.Parse(s: (v[0].ToString() + v[1].ToString()).ToString());
                    year = int.Parse(s: (v[4].ToString() + v[5].ToString() + v[6].ToString() + v[7].ToString()).ToString());
                }

                DateTime dt = new DateTime();

                if (DateTime.TryParse(s:
                    day.ToString() + "/" + month.ToString() + "/" + year.ToString(), result: out dt))
                {
                    return dt;
                }

                return DateTime.Now;
            }
            return null;
        }
    }
}
