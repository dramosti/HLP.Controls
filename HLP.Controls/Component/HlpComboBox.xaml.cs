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
    /// Interaction logic for HlpComboBox.xaml
    /// </summary>
    public partial class HlpComboBox : UserControlBase
    {
        public HlpComboBox()
        {
            InitializeComponent();
        }



        public Nullable<int> ucSelectedIndex
        {
            get { return (Nullable<int>)GetValue(ucSelectedIndexProperty); }
            set { SetValue(ucSelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucSelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucSelectedIndexProperty =
            DependencyProperty.Register("ucSelectedIndex", typeof(Nullable<int>), typeof(HlpComboBox),
            new PropertyMetadata(defaultValue: null));

        public object ucSelectedValue
        {
            get { return (object)GetValue(ucSelectedValueProperty); }
            set { SetValue(ucSelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucSelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucSelectedValueProperty =
            DependencyProperty.Register("ucSelectedValue", typeof(object), typeof(HlpComboBox), new PropertyMetadata(null));



        public string ucSelectedValuePath
        {
            get { return (string)GetValue(ucSelectedValuePathProperty); }
            set { SetValue(ucSelectedValuePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucSelectedValuePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucSelectedValuePathProperty =
            DependencyProperty.Register("ucSelectedValuePath", typeof(string), typeof(HlpComboBox), new PropertyMetadata(defaultValue: string.Empty));



        public System.Collections.IEnumerable ucItemsSource
        {
            get { return (System.Collections.IEnumerable)GetValue(ucItemsSourceProperty); }
            set { SetValue(ucItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucItemsSourceProperty =
            DependencyProperty.Register("ucItemsSource", typeof(System.Collections.IEnumerable),
            typeof(HlpComboBox), new PropertyMetadata(defaultValue: null));

        private DataTemplate _ucTemplateCbx;

        public DataTemplate ucTemplateCbx
        {
            get { return _ucTemplateCbx; }
            set
            {
                _ucTemplateCbx = value;

                if (value != null)
                {
                    cbx.ItemTemplate = value;
                }
            }
        }

    }
}
