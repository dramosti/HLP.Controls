using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Controls.Component.Converter
{
    public class TimeSpanMaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = "";

            if (value != null)
                ret = value.ToString();

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan time = TimeSpan.Zero;
            TimeSpan timeMax = new TimeSpan(hours: 23, minutes: 59, seconds: 59);
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            char[] estrutTime = value.ToString().Replace(oldValue: ":", newValue: "").PadRight(totalWidth: 6, paddingChar: '0').ToArray();

            if (value != null)
            {
                int.TryParse(s: estrutTime[0].ToString() + estrutTime[1].ToString(),
                    result: out hours);

                int.TryParse(s: estrutTime[2].ToString() + estrutTime[3].ToString(),
                    result: out minutes);

                int.TryParse(s: estrutTime[4].ToString() + estrutTime[5].ToString(),
                    result: out seconds);

                time = new TimeSpan(hours: hours, minutes: minutes, seconds: seconds);

                if (time > timeMax)
                    time = timeMax;
            }
            return time;
        }
    }
}
