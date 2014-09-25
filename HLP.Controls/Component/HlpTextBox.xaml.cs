using HLP.Controls.Base;
using HLP.Controls.Converters.Component;
using HLP.Controls.Static;
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

            if (!Util.IsDesignTime())
            {
                Binding bindingManual = new Binding();

                RelativeSource r = new RelativeSource();
                r.Mode = RelativeSourceMode.Self;

                PropertyPath p = new PropertyPath(path: "IsReadOnly", pathParameters: new object[] { });

                bindingManual.Path = p;
                bindingManual.RelativeSource = r;

                TextboxStyleSelectorConverter txtConverter = new TextboxStyleSelectorConverter();
                bindingManual.Converter = txtConverter;

                BindingOperations.SetBinding(target: this.txt,
                    dp: HlpTextBox.StyleProperty, binding: bindingManual);
            }
        }
    }
}
