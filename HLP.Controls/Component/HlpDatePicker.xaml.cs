using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HLP.Controls.Base;

namespace HLP.Controls.Component
{
    /// <summary>
    /// Interaction logic for HlpDatePicker.xaml
    /// </summary>
    public partial class HlpDatePicker : UserControlBase
    {
        public HlpDatePicker()
        {
            InitializeComponent();
            this.btnCalendar.Content = DateTime.Now.Day;
        }

        public TipoDateTime stDateTime
        {
            get { return (TipoDateTime)GetValue(stDateTimeProperty); }
            set { SetValue(stDateTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for stDateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty stDateTimeProperty =
            DependencyProperty.Register("stDateTime", typeof(TipoDateTime),
            typeof(HlpDatePicker), new PropertyMetadata(defaultValue: TipoDateTime.enumDateTime,
                propertyChangedCallback: new PropertyChangedCallback(StDateTimeChanged)));

        public static void StDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue != null)
            {
                TipoDateTime stDateTime = (TipoDateTime)args.NewValue;
                (d as HlpDatePicker).btnCalendar.Visibility = (d as HlpDatePicker).txtDate.Visibility =
                    (d as HlpDatePicker).txtTime.Visibility = Visibility.Collapsed;

                if (stDateTime == Base.TipoDateTime.enumDate || stDateTime == Base.TipoDateTime.enumDateTime)
                {
                    (d as HlpDatePicker).btnCalendar.Visibility = (d as HlpDatePicker).txtDate.Visibility = Visibility.Visible;
                }

                if (stDateTime == Base.TipoDateTime.enumTime || stDateTime == Base.TipoDateTime.enumDateTime)
                {
                    (d as HlpDatePicker).txtTime.Visibility = Visibility.Visible;
                }
            }
        }

        public Nullable<DateTime> xDate
        {
            get { return (Nullable<DateTime>)GetValue(xDateProperty); }
            set { SetValue(xDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xDateProperty =
            DependencyProperty.Register("xDate", typeof(Nullable<DateTime>), typeof(HlpDatePicker), new PropertyMetadata(null));

        public Nullable<TimeSpan> xTime
        {
            get { return (Nullable<TimeSpan>)GetValue(xTimeProperty); }
            set { SetValue(xTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xTimeProperty =
            DependencyProperty.Register("xTime", typeof(Nullable<TimeSpan>), typeof(HlpDatePicker), new PropertyMetadata(null));

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            this.mainCalendar.IsOpen = true;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtDate.Text = (sender as Calendar).SelectedDate.Value.Date.ToShortDateString();
            this.txtTime.Text = (sender as Calendar).SelectedDate.Value.Date.ToLongTimeString();
            this.mainCalendar.IsOpen = false;

            if (txtDate.Visibility == System.Windows.Visibility.Visible)
                this.txtDate.Focus();
            else if (txtTime.Visibility == System.Windows.Visibility.Visible)
                this.txtTime.Focus();
        }


    }
}
