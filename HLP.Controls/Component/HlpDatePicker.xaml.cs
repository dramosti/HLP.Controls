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
            calendar = new Calendar();
            calendar.PreviewKeyDown += Calendar_PreviewKeyDown;
            calendar.MouseDoubleClick += Calendar_MouseDoubleClick;
            this.txtDate.GotFocus += HlpDatePicker_GotFocus;
            this.txtDate.KeyDown += txtDate_KeyDown;
            this.mainCalendar.Child = calendar;
        
        }

        public Calendar calendar { get; set; }

        void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                this.mainCalendar.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                this.mainCalendar.IsOpen = true;
                this.calendar.SelectedDate = DateTime.Today;
                this.calendar.Focus();
            }
        }
        private void Calendar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                this.ClosePopup();
            }
        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.ClosePopup();
        }

        void HlpDatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            this.mainCalendar.IsOpen = false;
        }

        private void ClosePopup()
        {
            this.txtDate.Text = this.calendar.SelectedDate.Value.Date.ToShortDateString();
            this.mainCalendar.IsOpen = false;
            if (this.Visibility == System.Windows.Visibility.Visible)
                this.txtDate.Focus();
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
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtDate.Text = (sender as Calendar).SelectedDate.Value.Date.ToShortDateString();
            this.mainCalendar.IsOpen = false;

            if (txtDate.Visibility == System.Windows.Visibility.Visible)
                this.txtDate.Focus();
        }

       


    }
}
