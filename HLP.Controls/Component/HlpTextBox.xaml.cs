using HLP.Controls.Base;
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

        private void CreateBinding()
        {
            Binding b = new System.Windows.Data.Binding();

            RelativeSource r = new RelativeSource();
            r.Mode = RelativeSourceMode.FindAncestor;
            r.AncestorType = typeof(HlpTextBox);

            PropertyPath p = new PropertyPath(path: "Text", pathParameters: new object[] { });
            b.Path = p;
            b.RelativeSource = r;


            switch (this.Validacao)
            {
                case HLP.Controls.Enum.EnumControls.stValidacao.Int:
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Decimal:
                    {
                        decimalConverter conv = new decimalConverter();
                        b.Converter = conv;
                        b.ConverterParameter = this.casasDecimais;
                        b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Porcentagem:
                    {
                        PorcentagemConverter conv = new PorcentagemConverter();
                        b.Converter = conv;
                        b.ConverterParameter = this.casasDecimais;
                        b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Moeda:
                    {
                        MoedaConverter conv = new MoedaConverter();
                        b.Converter = conv;
                        b.ConverterParameter = this.casasDecimais;
                        b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Text:
                    break;
                default:
                    break;
            }
            
            BindingOperations.SetBinding(target: this.txt, dp: TextBox.TextProperty, binding: b);
            //this.ApplyTemplate();
        }


        private HLP.Controls.Enum.EnumControls.stValidacao _validacao = Enum.EnumControls.stValidacao.Text;
        [Category("HLP.Base")]
        public HLP.Controls.Enum.EnumControls.stValidacao Validacao
        {
            get { return _validacao; }
            set { _validacao = value; base.NotifyPropertyChanged("Validacao"); }
        }



        public int casasDecimais
        {
            get { return (int)GetValue(casasDecimaisProperty); }
            set { SetValue(casasDecimaisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for casasDecimais.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty casasDecimaisProperty =
            DependencyProperty.Register("casasDecimais", typeof(int), typeof(HlpTextBox), new PropertyMetadata(2));



        private HLPTextBoxViewModel _hlpTextBoxViewModelViewModel;
        public HLPTextBoxViewModel CustomViewModel
        {
            get { return _hlpTextBoxViewModelViewModel; }
            set { _hlpTextBoxViewModelViewModel = value; }
        }

        private void compBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt.Focus();
        }

        private void UserControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBinding();
        }



    }
}
