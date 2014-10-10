using HLP.Controls.Base;
using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    ///     <MyNamespace:CustomIntellisenseColumn/>
    ///
    /// </summary>
    public class CustomIntellisenseColumn : DataGridBoundColumn
    {
        public CustomIntellisenseColumn()
        {
            this.pup = new Popup();

            DataGrid dg = new DataGrid();
            dg.MouseDoubleClick += dg_MouseDoubleClick;
            dg.PreviewKeyDown += dg_PreviewKeyDown;

            dg.GridLinesVisibility = DataGridGridLinesVisibility.None;
            dg.IsReadOnly = true;

            dg.SetBinding(dp: DataGrid.SelectedItemProperty, binding: new Binding
            {
                Path = new PropertyPath(path: "selectedItem", pathParameters: new object[] { })
            });

            dg.SetBinding(dp: DataGrid.ItemsSourceProperty, binding: new Binding
            {
                Path = new PropertyPath(path: "cvs", pathParameters: new object[] { })
            });

            this.pup.Child = dg;
            this.pup.PreviewKeyDown += pup_PreviewKeyDown;

            this.customViewModel = new CustomTextBoxIntellisenseViewModel(popUp: pup);

            this.pup.DataContext = this.customViewModel;
        }

        void pup_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.SelectItem();
                e.Handled = true;
            }
        }

        void dg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DataGridOwner.Focus();

                this.DataGridOwner.MoveFocus(request: new TraversalRequest(focusNavigationDirection: FocusNavigationDirection.Next));

                this.DataGridOwner.BeginEdit();
            }
            else if (e.Key == Key.Enter)
            {
                this.SelectItem();
            }
        }

        #region Eventos

        void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.SelectItem();
        }

        #endregion

        #region Local Componentes

        private Popup _pup;

        public Popup pup
        {
            get { return _pup; }
            set { _pup = value; }
        }

        #endregion

        #region Propriedades

        private CustomTextBoxIntellisenseViewModel _customViewModel;

        public CustomTextBoxIntellisenseViewModel customViewModel
        {
            get { return _customViewModel; }
            set { _customViewModel = value; }
        }

        private string _xNameView;

        public string xNameView
        {
            get { return _xNameView; }
            set
            {
                _xNameView = value;
            }
        }

        #endregion

        #region Overriden

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            TextBox txt = new TextBox();

            AutoSelectTextBoxAttachedProperty.SetAutoSelect(obj: txt, value: true);

            this.customViewModel.xNameView = this.xNameView;

            this.customViewModel.GetResult();

            txt.DataContext = this.customViewModel;

            txt.SetBinding(dp: TextBox.TextProperty, binding: new Binding
            {
                UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged,
                Path = new PropertyPath(path: "xTextSearch", pathParameters: new object[] { })
            });

            Point p = Util.GetBottomPositionComponentInMainWindow(comp: cell, addHeight: 23);

            pup.HorizontalOffset = p.X;
            pup.VerticalOffset = p.Y;

            pup.IsOpen = true;
            pup.StaysOpen = true;

            if (cell.Content.GetType() == typeof(TextBlock))
            {
                txt.Text = (cell.Content as TextBlock).Text;
            }

            return txt;
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock lbl = new TextBlock();

            if (cell.Content != null)
                if (cell.Content.GetType() == typeof(TextBox))
                {
                    lbl.Text = (cell.Content as TextBox).Text;
                }

            return lbl;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {

            base.PrepareCellForEdit(editingElement, editingEventArgs);

            (editingElement as TextBox).Focus();

            return editingElement;
        }

        #endregion

        #region Propriedades de Dependencia

        public int? selectedId
        {
            get { return (int?)GetValue(selectedIdProperty); }
            set
            {
                SetValue(selectedIdProperty, value);
            }
        }

        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int?), typeof(CustomIntellisenseColumn), new PropertyMetadata(
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
                    DataGridCell _cell = (d as CustomIntellisenseColumn).GetCurrentCell();

                    if (_cell != null)
                    {
                        if (_cell.Content.GetType() == typeof(TextBlock))
                            (_cell.Content as TextBlock).Text = String.Empty;
                        else if (_cell.Content.GetType() == typeof(TextBox))
                            (_cell.Content as TextBox).Text = string.Empty;
                    }
                    //(d as HlpIntellisense).txt.Text = String.Empty;

                    if (((d as CustomIntellisenseColumn).customViewModel.cvs != null))
                    {
                        ((d as CustomIntellisenseColumn).customViewModel.cvs as BindingListCollectionView)
                            .CustomFilter = String.Format(format: "Id = {0}", arg0: args.NewValue);

                        (d as CustomIntellisenseColumn).customViewModel.cvs.MoveCurrentToFirst();

                        if ((d as CustomIntellisenseColumn).customViewModel.cvs.CurrentItem != null)
                        {
                            string xText = String.Empty;

                            foreach (object item in ((d as CustomIntellisenseColumn).customViewModel.cvs.CurrentItem as DataRowView).Row.ItemArray)
                            {
                                if (item != null)
                                    xText += xText == "" ?
                                        item.ToString() : " - " + item.ToString();
                            }

                            //(d as HlpIntellisense).txt.Text = xText;

                            if (_cell != null)
                            {
                                if (_cell.Content.GetType() == typeof(TextBlock))
                                    (_cell.Content as TextBlock).Text = xText;
                                else if (_cell.Content.GetType() == typeof(TextBox))
                                    (_cell.Content as TextBox).Text = xText;
                            }

                            //if ((d as CustomIntellisenseColumn).DataGridOwner.DataContext != null)
                            //{
                            //    PropertyInfo piCurrentModel = (d as CustomIntellisenseColumn).DataGridOwner.DataContext.GetType()
                            //        .GetProperty(name: "currentModel");

                            //    if (piCurrentModel != null)
                            //    {
                            //        Binding b = BindingOperations.GetBinding(target: d,
                            //            dp: CustomIntellisenseColumn.selectedIdProperty);

                            //        (d as HlpIntellisense).SetModelObjectFromId(objUsedFromReflection: piCurrentModel.GetValue(obj: (d as HlpIntellisense).DataContext),
                            //            xPath: b.Path.Path);
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        private DataGridCell GetCurrentCell()
        {
            DataGridCell c = null;

            DataGridRow r = this.DataGridOwner.ItemContainerGenerator.ContainerFromItem(
                item: this.DataGridOwner.CurrentCell.Item) as DataGridRow;

            if (r != null)
            {
                c = Util.GetCell(grid: this.DataGridOwner, row: r, column: this.DisplayIndex);
            }

            return c;
        }

        public string ucText
        {
            get { return (string)GetValue(ucTextProperty); }
            set { SetValue(ucTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucTextProperty =
            DependencyProperty.Register("ucText", typeof(string), typeof(CustomIntellisenseColumn), new PropertyMetadata(""));

        #endregion

        #region Métodos

        private void SelectItem()
        {
            this.pup.IsOpen = false;

            this.DataGridOwner.Focus();

            this.DataGridOwner.BeginEdit();

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

        #endregion
    }
}