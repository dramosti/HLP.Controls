﻿using HLP.Controls.Base;
using HLP.Controls.ViewModel.ViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

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
            this.GotKeyboardFocus += HlpTextBox_GotFocus;
        }


        #region Properties
        private HLP.Controls.Enum.EnumControls.stValidacao _validacao = Enum.EnumControls.stValidacao.Text;
        [Category("HLP.Base")]
        public HLP.Controls.Enum.EnumControls.stValidacao Validacao
        {
            get { return _validacao; }
            set { _validacao = value; base.NotifyPropertyChanged("Validacao"); this.CreateBinding(); }
        }

        public int casasDecimais
        {
            get { return (int)GetValue(casasDecimaisProperty); }
            set { SetValue(casasDecimaisProperty, value); }
        }
        [Category("HLP.Base")]
        // Using a DependencyProperty as the backing store for casasDecimais.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty casasDecimaisProperty =
            DependencyProperty.Register("casasDecimais", typeof(int), typeof(HlpTextBox), new PropertyMetadata(2));


        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Mask.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(string), typeof(HlpTextBox), new PropertyMetadata(""));



        public string xContentTXT
        {
            get { return (string)GetValue(xContentTXTProperty); }
            set { SetValue(xContentTXTProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xContentTXT.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xContentTXTProperty =
            DependencyProperty.Register("xContentTXT", typeof(string), typeof(HlpTextBox), new PropertyMetadata(""));
        
        #endregion


       


        private void CreateBinding()
        {
                                                                    

            this.xContentTXT = "";
            switch (this.Validacao)
            {
                case HLP.Controls.Enum.EnumControls.stValidacao.Int:
                    {
                        this.Mask = "0:#,0.";                        
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Decimal:
                    {
                        this.Mask = string.Format("0:#,0.{0}##", "0".PadLeft(this.casasDecimais, '0'));
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Moeda:
                    {
                        this.Mask = string.Format("0:#,0.{0}##", "0".PadLeft(this.casasDecimais, '0'));
                        this.xContentTXT = "R$";
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Porcentagem:
                    {
                        this.Mask = string.Format("0:#,0.{0}##", "0".PadLeft(this.casasDecimais, '0'));
                        this.xContentTXT = "%";
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stValidacao.Text:
                    {
                        this.Mask = "";                        
                    }
                    break;
                default:
                    break;
            }

        }

        //private void CreateBinding()
        //{
        //    Binding b = new System.Windows.Data.Binding();

        //    RelativeSource r = new RelativeSource();
        //    r.Mode = RelativeSourceMode.FindAncestor;
        //    r.AncestorType = typeof(HlpTextBox);

        //    PropertyPath p = new PropertyPath(path: "Text", pathParameters: new object[] { });
        //    b.Path = p;
        //    b.RelativeSource = r;

        //    switch (this.Validacao)
        //    {
        //        case HLP.Controls.Enum.EnumControls.stValidacao.Int:
        //            {
        //                IntegerConvert conv = new IntegerConvert();
        //                b.Converter = conv;
        //                b.ConverterParameter = this.casasDecimais;
        //                b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        //            }
        //            break;
        //        case HLP.Controls.Enum.EnumControls.stValidacao.Decimal:
        //            {
        //                decimalConverter conv = new decimalConverter();
        //                b.Converter = conv;
        //                b.ConverterParameter = this.casasDecimais;
        //                b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        //            }
        //            break;
        //        case HLP.Controls.Enum.EnumControls.stValidacao.Porcentagem:
        //            {
        //                PorcentagemConverter conv = new PorcentagemConverter();
        //                b.Converter = conv;
        //                b.ConverterParameter = this.casasDecimais;
        //                b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        //            }
        //            break;
        //        case HLP.Controls.Enum.EnumControls.stValidacao.Moeda:
        //            {
        //                MoedaConverter conv = new MoedaConverter();
        //                b.Converter = conv;
        //                b.ConverterParameter = this.casasDecimais;
        //                b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        //            }
        //            break;
        //        case HLP.Controls.Enum.EnumControls.stValidacao.Text:
        //            break;
        //        default:
        //            break;
        //    }

        //    BindingOperations.SetBinding(target: this.txt, dp: TextBox.TextProperty, binding: b);
        //    //this.ApplyTemplate();
        //}


        #region Events
        void HlpTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txt.Focus();
            this.txt.SelectAll();
        }
        private void compBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt.Focus();
        }

        private void UserControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBinding();
        }
        
        #endregion




        public HLPTextBoxViewModel CustomViewModel { get; set; }

      



    }
}
