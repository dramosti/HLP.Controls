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

namespace HLP.Controls.Component
{
    /// <summary>
    /// Interaction logic for HlpTimePicker.xaml
    /// </summary>
    public partial class HlpTimePicker : UserControlBase
    {
        public HlpTimePicker()
        {
            InitializeComponent();
        }



        public Nullable<TimeSpan> time
        {
            get { return (Nullable<TimeSpan>)GetValue(timeProperty); }
            set { SetValue(timeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty timeProperty =
            DependencyProperty.Register("time", typeof(Nullable<TimeSpan>), typeof(HlpTimePicker), new PropertyMetadata(new TimeSpan(0, 0, 0)));


    }
}
