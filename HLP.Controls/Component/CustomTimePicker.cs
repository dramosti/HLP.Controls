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
    ///     <MyNamespace:CustomTimePicker/>
    ///
    /// </summary>
    public class CustomTimePicker : TextBox
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
            DependencyProperty.Register("time", typeof(TimeSpan), typeof(CustomTimePicker), new PropertyMetadata(new TimeSpan(0,0,0)));

        
    }
}
