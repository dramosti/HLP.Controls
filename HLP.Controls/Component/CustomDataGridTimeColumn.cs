using HLP.Controls.Converters.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.Component
{
    public class CustomDataGridTimeColumn : DataGridBoundColumn
    {
        protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            CustomTimePicker dtp = new CustomTimePicker();

            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            dtp.SetBinding(dp: CustomTimePicker.timeProperty, binding: b);

            return dtp;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            base.PrepareCellForEdit(editingElement, editingEventArgs);

            FocusManager.SetFocusedElement(element: editingElement, value: (editingElement as CustomTimePicker));

            return editingElement;
        }

        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            CustomTextBlock txt = new CustomTextBlock();
            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.OneWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TimeSpanToString conv = new TimeSpanToString();
            b.Converter = conv;
            txt.SetBinding(dp: CustomTextBlock.TextProperty, binding: b);
            return txt;
        }
    }

    class CustomTimePicker : TextBox
    {
        public CustomTimePicker()
        {
            Binding b = new Binding();
            RelativeSource r = new RelativeSource();
            r.Mode = RelativeSourceMode.Self;
            PropertyPath p = new PropertyPath(path: "time", pathParameters: new object[] { });
            b.Path = p;
            b.RelativeSource = r;
            TimeSpanToString conv = new TimeSpanToString();
            b.Converter = conv;
            BindingOperations.SetBinding(target: this, dp: CustomTimePicker.TextProperty, binding: b);
        }

        static CustomTimePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTimePicker), new FrameworkPropertyMetadata(typeof(CustomTimePicker)));
        }

        public TimeSpan time
        {
            get { return (TimeSpan)GetValue(timeProperty); }
            set { SetValue(timeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty timeProperty =
            DependencyProperty.Register("time", typeof(TimeSpan), typeof(CustomTimePicker), new PropertyMetadata(new TimeSpan(0, 0, 0)));


    }
}
