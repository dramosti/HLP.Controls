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
    /// Interaction logic for TESTE.xaml
    /// </summary>
    public partial class TESTE : UserControl
    {
        public TESTE()
        {
            InitializeComponent();
        }




        public bool IsReadyOnly
        {
            get { return (bool)GetValue(IsReadyOnlyProperty); }
            set { SetValue(IsReadyOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadyOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadyOnlyProperty =
            DependencyProperty.Register("IsReadyOnly", typeof(bool), typeof(TESTE), new PropertyMetadata(false));

        
    }
}
