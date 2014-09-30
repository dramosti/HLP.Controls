using HLP.Controls.Base;
using HLP.Controls.Converters.Component;
using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
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
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class HlpTextBox : UserControlBase
    {
        public HlpTextBox()
        {
            InitializeComponent();
            this.CustomViewModel = new HLPTextBoxViewModel();
            
        }

        private HLPTextBoxViewModel  _hlpTextBoxViewModelViewModel;
        public HLPTextBoxViewModel CustomViewModel  
        {
            get { return _hlpTextBoxViewModelViewModel; }
            set { _hlpTextBoxViewModelViewModel = value; }
        }
        

        
    }
}
