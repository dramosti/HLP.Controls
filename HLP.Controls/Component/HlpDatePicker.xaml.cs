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
using System.ComponentModel;
using HLP.Controls.ViewModel.ViewModel;

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
            CustomViewModel = new HlpDatePickerViewModel();
        }

        public HlpDatePickerViewModel CustomViewModel { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int day
        {
            get { return (int)GetValue(dayProperty); }
            set { SetValue(dayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for day.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dayProperty =
            DependencyProperty.Register("day", typeof(int), typeof(HlpDatePicker), new PropertyMetadata(DateTime.Now.Day));

        

        public Nullable<DateTime> xDate
        {
            get { return (Nullable<DateTime>)GetValue(xDateProperty); }
            set { SetValue(xDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xDateProperty =
            DependencyProperty.Register("xDate", typeof(Nullable<DateTime>), typeof(HlpDatePicker), new PropertyMetadata(DateTime.Today));

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            this.mainCalendar.IsOpen = true;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtDate.Text = (sender as Calendar).SelectedDate.Value.Date.ToShortDateString();
            this.mainCalendar.IsOpen = false;

            if (txtDate.Visibility == System.Windows.Visibility.Visible)
                this.txtDate.Focus();
        }


    }
}
