using HLP.Controls.Converters.Component;
using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HLP.Controls.Component
{
    public class CustomDatePicker : TextBox
    {

        static CustomDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDatePicker), new FrameworkPropertyMetadata(typeof(CustomDatePicker)));
        }
        public CustomDatePicker()
        {
            this.ApplyTemplate();
            Binding b = new Binding();
            RelativeSource r = new RelativeSource();
            r.Mode = RelativeSourceMode.Self;
            PropertyPath p = new PropertyPath(path: "date", pathParameters: new object[] { });
            b.Path = p;
            b.RelativeSource = r;
            DateTimeMaskConverter conv = new DateTimeMaskConverter();
            b.Converter = conv;
            BindingOperations.SetBinding(target: this, dp: CustomDatePicker.TextProperty, binding: b);
            Binding bt = new Binding();

            this.popup = new System.Windows.Controls.Primitives.Popup();
            this.calendar = new Calendar();
            this.calendar.PreviewKeyDown += calendar_PreviewKeyDown;
            this.calendar.MouseDoubleClick += calendar_MouseDoubleClick;
            this.GotFocus += CustomDatePicker_GotFocus;
            this.popup.Child = calendar;

            CustomViewModel = new HlpDatePickerViewModel();
            var gesture = new KeyGesture(Key.F5, ModifierKeys.None);
            InputBinding ib = new InputBinding(this.CustomViewModel.openPopupCommand, gesture);
            ib.CommandParameter = this;
            this.InputBindings.Add(ib);
        }


        #region Events
        void CustomDatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false;
        }

        void calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClosePopup();
        }

        void calendar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ClosePopup();
                e.Handled = true;
            }
        }
        #endregion

        #region Methods
        private void ClosePopup()
        {
            this.Text = this.calendar.SelectedDate.Value.Date.ToShortDateString();
            this.popup.IsOpen = false;
            if (this.Visibility == System.Windows.Visibility.Visible)
                this.Focus();
        }
        #endregion

        #region properties
        public HlpDatePickerViewModel CustomViewModel { get; set; }
        public System.Windows.Controls.Primitives.Popup popup { get; set; }
        public Calendar calendar { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int day
        {
            get { return (int)GetValue(dayProperty); }
            set { SetValue(dayProperty, value); }
        }
        // Using a DependencyProperty as the backing store for day.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dayProperty =
            DependencyProperty.Register("day", typeof(int), typeof(CustomDatePicker), new PropertyMetadata(DateTime.Now.Day));

        public DateTime date
        {
            get { return (DateTime)GetValue(dateProperty); }
            set { SetValue(dateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for date.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dateProperty =
            DependencyProperty.Register("date", typeof(DateTime), typeof(CustomDatePicker), new PropertyMetadata(DateTime.Today));

        #endregion

    }
}
