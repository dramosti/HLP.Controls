using HLP.Controls.Base;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for HlpIntellisense.xaml
    /// </summary>
    public partial class HlpIntellisense : UserControlBase
    {
        public HlpIntellisense()
        {
            InitializeComponent();

            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
            if (!designTime)
            {
                this.customViewModel = new CustomTextBoxIntellisenseViewModel(popUp: this.popUp);
                this.popUp.IsOpen = false;
                this.popUp.StaysOpen = false;

                AutoSelectTextBoxAttachedProperty.SetAutoSelect(obj: this.txt, value: true);
                this.txt.KeyDown += txt_KeyDown;
                this.txt.KeyUp += txt_KeyUp;
                this.popUp.Opened += popUp_Opened;
                (this.popUp.Child as DataGrid).PreviewKeyDown += ucDataGrid_PreviewKeyDown;
                (this.popUp.Child as DataGrid).MouseDoubleClick += ucTextBoxIntellisense_MouseDoubleClick;
                this.Loaded += ucTextBoxIntellisense_Loaded;

                if (this.txt.ContextMenu != null)
                    foreach (MenuItem item in this.txt.ContextMenu.Items)
                    {
                        if (item.Name == "insertItem")
                        {
                            item.Command = this.customViewModel.insertCommand;
                            item.CommandParameter = this;
                        }
                        else if (item.Name == "goItem")
                        {
                            item.Command = this.customViewModel.goToRecordCommand;
                            item.CommandParameter = this;
                        }
                    }
            }
        }

        private CustomTextBoxIntellisenseViewModel _customViewModel;

        public CustomTextBoxIntellisenseViewModel customViewModel
        {
            get { return _customViewModel; }
            set { _customViewModel = value; }
        }

        #region Custom Properties

        private string _xNameView;
        [Category("HLP.Owner")]
        public string xNameView
        {
            get { return this._xNameView; }
            set
            {
                this._xNameView = value;

                bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
                if (!designTime)
                {
                    this.customViewModel.xNameView = value;
                }
            }
        }

        #endregion

        #region Dependency Properties

        public int? selectedId
        {
            get { return (int?)GetValue(selectedIdProperty); }
            set
            {
                SetValue(selectedIdProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int?), typeof(HlpIntellisense), new PropertyMetadata(
                defaultValue: null, propertyChangedCallback: new PropertyChangedCallback(SelectedIdChanged)));

        public static void SelectedIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d != null)
            {
                if (args.NewValue == null)
                {
                    (d as HlpIntellisense).txt.Text = string.Empty;
                }
                else
                {
                    (d as HlpIntellisense).txt.Text = String.Empty;

                    if (((d as HlpIntellisense).customViewModel.cvs != null))
                    {
                        ((d as HlpIntellisense).customViewModel.cvs as BindingListCollectionView)
                            .CustomFilter = String.Format(format: "Id = {0}", arg0: args.NewValue);

                        (d as HlpIntellisense).customViewModel.cvs.MoveCurrentToFirst();

                        if ((d as HlpIntellisense).customViewModel.cvs.CurrentItem != null)
                        {
                            string xText = String.Empty;

                            foreach (object item in ((d as HlpIntellisense).customViewModel.cvs.CurrentItem as DataRowView).Row.ItemArray)
                            {
                                if (item != null)
                                    xText += xText == "" ?
                                        item.ToString() : " - " + item.ToString();
                            }

                            (d as HlpIntellisense).txt.Text = xText;


                            if ((d as HlpIntellisense).DataContext != null)
                            {
                                PropertyInfo piCurrentModel = (d as HlpIntellisense).DataContext.GetType()
                                    .GetProperty(name: "currentModel");

                                if (piCurrentModel != null)
                                {
                                    Binding b = BindingOperations.GetBinding(target: d,
                                        dp: HlpIntellisense.selectedIdProperty);

                                    (d as HlpIntellisense).SetModelObjectFromId(objUsedFromReflection: piCurrentModel.GetValue(obj: (d as HlpIntellisense).DataContext),
                                        xPath: b.Path.Path);
                                }
                            }
                        }
                    }
                }
            }
        }

        public Func<int, bool, object> refMethod
        {
            get { return (Func<int, bool, object>)GetValue(refMethodProperty); }
            set { SetValue(refMethodProperty, value); }
        }

        // Using a DependencyProperty as the backing store for refMethod.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty refMethodProperty =
            DependencyProperty.Register("refMethod", typeof(Func<int, bool, object>), typeof(HlpIntellisense), new PropertyMetadata(null));

        public object model
        {
            get { return (object)GetValue(modelProperty); }
            set { SetValue(modelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty modelProperty =
            DependencyProperty.Register("model", typeof(object), typeof(HlpIntellisense),
            new PropertyMetadata(defaultValue: null));

        private string _xNamePropertyModel;
        [Category("HLP.Owner")]
        public string xNamePropertyModel
        {
            get { return _xNamePropertyModel; }
            set { _xNamePropertyModel = value; }
        }

        #endregion

        #region Events

        void ucTextBoxIntellisense_Loaded(object sender, RoutedEventArgs e)
        {
            this.customViewModel.GetResult();
        }

        void popUp_Opened(object sender, EventArgs e)
        {
            if (this.customViewModel != null)
                this.customViewModel.GetResult();
        }

        public void SetModelObjectFromId(object objUsedFromReflection, string xPath)
        {
#if DEBUG
            if (refMethod == null)
            {
                Console.WriteLine(
                    string.Format(
                    format: "#Erro: Método de busca na ViewModel para a propriedade {0} não está configurada!",
                    arg0: xPath)
                    );
            }

#endif

            if (refMethod == null)
                return;

            string xNameProperty = null;

            if (objUsedFromReflection != null)
            {
                PropertyInfo piBinding = null;

                if (xPath.Split(separator: '.').Count() > 0)
                {
                    foreach (string path in xPath.Split(separator: '.'))
                    {
                        if (path == xPath.Split(separator: '.').Last())
                        {
                            xNameProperty = path;
                            break;
                        }
                        piBinding = objUsedFromReflection.GetType().GetProperty(name: path);

                        if (piBinding != null)
                            objUsedFromReflection = piBinding.GetValue(obj: objUsedFromReflection);
                    }

                }

                piBinding = null;
                if (objUsedFromReflection != null)
                    piBinding = objUsedFromReflection.GetType().GetProperty(name: xNameProperty);

                if (piBinding != null)
                {
                    int? id = piBinding.GetValue(obj: objUsedFromReflection) as int?;

                    object obj = this.refMethod.Invoke(arg1: id ?? 0, arg2: true);
                    if (obj != null)
                    {
                        if (!string.IsNullOrEmpty(value: this.xNamePropertyModel))
                            objUsedFromReflection.GetType().GetProperty(name: this.xNamePropertyModel).SetValue(obj: objUsedFromReflection,
                                value: obj);
                    }
                }
            }
        }

        private void SelectItem()
        {
            if (this.customViewModel.selectedItem != null)
            {
                int intValidated = 0;
                object vValue = this.customViewModel.selectedItem.Row.ItemArray[this.customViewModel.indexIdProperty];

                if (vValue != null)
                    if (int.TryParse(s: vValue.ToString(),
                        result: out intValidated))
                    {
                        this.selectedId = 0;
                        this.selectedId = intValidated;
                    }
            }
        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.popUp.IsOpen = false;
            }
            else if (e.Key == Key.Tab)
                this.SelectItem();
            else if (e.Key == Key.F5 && this.IsEnabled)
                this.customViewModel.searchCommand.Execute(parameter: this);
        }

        void ucTextBoxIntellisense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.SelectItem();
        }

        void ucDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.txt.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                this.SelectItem();
                this.txt.Focus();
            }
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                this.popUp.IsOpen = true;

                DataGridRow r = (this.popUp.Child as DataGrid).ItemContainerGenerator.ContainerFromIndex(index: 0) as DataGridRow;

                if (r != null)
                    r.MoveFocus(request: new TraversalRequest(focusNavigationDirection: FocusNavigationDirection.Next));

                (this.popUp.Child as DataGrid).SelectedIndex = this.customViewModel.cvs.Count > 0 ? 0 : -1;

            }

        }
        #endregion

    }
}
