using HLP.Controls.Converters.Component;
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

namespace HLP.Controls.Component
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Controls.Component"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Controls.Component;assembly=HLP.Controls.Component"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomDatePicker/>
    ///
    /// </summary>
    public class CustomDatePicker : TextBox
    {
        public CustomDatePicker()
        {
            Binding b = new Binding();
            RelativeSource r = new RelativeSource();
            r.Mode = RelativeSourceMode.Self;
            PropertyPath p = new PropertyPath(path: "date", pathParameters: new object[] { });
            b.Path = p;
            b.RelativeSource = r;
            DateTimeMaskConverter conv = new DateTimeMaskConverter();
            b.Converter = conv;
            BindingOperations.SetBinding(target: this, dp: CustomDatePicker.TextProperty, binding: b);
        }

        static CustomDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDatePicker), new FrameworkPropertyMetadata(typeof(CustomDatePicker)));
        }




        public DateTime date
        {
            get { return (DateTime)GetValue(dateProperty); }
            set { SetValue(dateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for date.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dateProperty =
            DependencyProperty.Register("date", typeof(DateTime), typeof(CustomDatePicker), new PropertyMetadata(DateTime.Today));


    }
}
