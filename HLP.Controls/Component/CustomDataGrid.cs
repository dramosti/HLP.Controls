using HLP.Controls.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.Component
{
    public class CustomDataGrid : DataGrid
    {

        public CustomDataGrid()
        {
            this.CanUserAddRows = true;
        }

        protected override void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
        {
            base.OnCellEditEnding(e);

            if (e.Column.GetType() == typeof(DataGridTemplateColumn))
            {
                var popup = Util.GetVisualChild<Popup>(e.EditingElement);
                if (popup != null && popup.IsOpen)
                {
                    e.Cancel = true;
                }
            }
        }

        protected override void OnBeginningEdit(DataGridBeginningEditEventArgs e)
        {
            base.OnBeginningEdit(e);

            try
            {
                if (this.CurrentCell.Column != null)
                {
                    if (this.CurrentCell.Column.Header != null)
                    {
                        if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                            if (this.CurrentItem != null)
                                this.CurrentItem.SetPropertyValue("bCanFindCep", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnExecutedCommitEdit(System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            base.OnExecutedCommitEdit(e);

            if (this.CurrentCell.Column != null)
            {
                if (this.CurrentCell.Column.Header != null)
                {
                    if (this.CurrentCell.Column.Header.ToString().ToUpper().Equals("CEP"))
                    {
                        if (this.CurrentItem != null)
                        {
                            this.CurrentItem.SetPropertyValue("bCanFindCep", false);
                        }
                    }
                }
            }
        }

        #region Tratamento de pressionamento de teclas

        private bool handledOnPreviewKeyDown = false;

        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (this.Items.Count == 0)
                this.BeginEdit();

            bool bPermiteKeyDown = true;

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.CancelEdit();
            }
            else
                if (this.CurrentItem.ToString().Contains(value: "NewItemPlaceholder"))
                {
                    DataGridRow r = this.ItemContainerGenerator.ContainerFromItem(item: this.CurrentItem) as DataGridRow;

                    DataGridCell c = null;

                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        c = Util.GetCell(grid: this, row: r,
                            column: i);

                        if (c != null)
                            if (c.IsReadOnly == false && c.Visibility == System.Windows.Visibility.Visible)
                                break;
                    }


                    this.SelectedCells.Clear();
                    c.Focus();
                    this.BeginEdit();
                    bPermiteKeyDown = false;
                }
                else
                {
                    if (this.CurrentCell.Column.GetType() == typeof(CustomIntellisenseColumn))
                    {
                        if (e.Key == System.Windows.Input.Key.Down)
                        {
                            DataGridRow r = this.ItemContainerGenerator.ContainerFromItem(item: this.CurrentItem) as DataGridRow;

                            DataGridCell c = Util.GetCell(grid: this, row: r, column: this.CurrentCell.Column.DisplayIndex);

                            if (c.IsEditing && c.Content.GetType() == typeof(HlpIntellisense))
                            {
                                (c.Content as HlpIntellisense).popUp.IsOpen = true;

                                if (r != null)
                                    r.MoveFocus(request: new TraversalRequest(focusNavigationDirection: FocusNavigationDirection.Next));

                                //((c.Content as HlpIntellisense).popUp.Child as DataGrid).SelectedIndex =
                                //    (c.Content as HlpIntellisense).customViewModel.cvs.Count > 0 ? 0 : -1;

                                bPermiteKeyDown = false;
                            }
                        }
                    }
                    else
                    {

                        var lastMethods = typeof(System.Linq.Enumerable)
                            .GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .Where(ext => ext.Name == "Last");
                        object lastItem = null;
                        Type typeItens = null;

                        foreach (MethodInfo extLast in lastMethods)
                        {
                            if (extLast.GetParameters().Count() == 1)
                            {
                                if (this.ItemsSource.GetType() == typeof(CollectionViewSource) || this.ItemsSource.GetType().BaseType == typeof(CollectionView))
                                {
                                    typeItens = (this.ItemsSource as CollectionView).SourceCollection.GetType();

                                    PropertyInfo piItensCount = (this.ItemsSource as System.Windows.Data.CollectionView).SourceCollection.GetType().GetProperty("Count");

                                    if (piItensCount != null)
                                    {
                                        int? itensCount = piItensCount.GetValue(
                                        (this.ItemsSource as System.Windows.Data.CollectionView).SourceCollection) as int?;

                                        if (itensCount != null)
                                            if (itensCount > 0)
                                                lastItem = (this.ItemsSource as CollectionView).GetItemAt(index: (int)itensCount - 1);
                                    }
                                }
                                else
                                {
                                    typeItens = this.ItemsSource.GetType().GetGenericArguments()[0];

                                    lastItem = extLast.MakeGenericMethod(typeArguments: typeItens)
                                    .Invoke(obj: this.ItemsSource, parameters: new object[] { this.ItemsSource });
                                }

                                break;
                            }
                        }
                        if (lastItem == this.CurrentItem)
                        {
                            if (e.Key == System.Windows.Input.Key.Enter)
                            {
                                this.ValidateModel(bPermiteKeyDown: out bPermiteKeyDown);
                            }
                            else if (e.Key == System.Windows.Input.Key.Up ||
                                e.Key == System.Windows.Input.Key.Down)
                            {
                                DataGridRow r = this.ItemContainerGenerator.ContainerFromItem(item: this.CurrentItem) as DataGridRow;

                                DataGridCell c = Util.GetCell(grid: this, row: r,
                                        column: this.Columns.IndexOf(item: this.CurrentColumn));

                                if (this.IsComboBoxColumn(c: c))
                                    bPermiteKeyDown = true;
                                else
                                    this.ValidateModel(bPermiteKeyDown: out bPermiteKeyDown);
                            }
                            else if (e.Key == System.Windows.Input.Key.Tab)
                            {
                                if (this.CurrentColumn == this.Columns.LastOrDefault(i => i.Visibility == System.Windows.Visibility.Visible))
                                {
                                    bPermiteKeyDown = false;
                                }
                            }
                        }
                    }
                }

            if (bPermiteKeyDown)
            {
                this.handledOnPreviewKeyDown = false;
                base.OnPreviewKeyDown(e);
            }
            else
            {
                this.handledOnPreviewKeyDown = e.Handled = true;
            }
        }

        protected override void OnPreviewKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            if (this.handledOnPreviewKeyDown == false)
                base.OnPreviewKeyUp(e);
            else
                e.Handled = true;
        }

        protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            DataGridRow r = this.ItemContainerGenerator.ContainerFromItem(item: this.CurrentItem) as DataGridRow;

            DataGridCell c = Util.GetCell(grid: this, row: r,
                    column: this.Columns.IndexOf(item: this.CurrentColumn));

            if (c != null)
                if (e.Key == System.Windows.Input.Key.Left ||
                    e.Key == System.Windows.Input.Key.Right ||
                    e.Key == System.Windows.Input.Key.Down ||
                    e.Key == System.Windows.Input.Key.Up)
                {
                    if (c.IsEditing)
                    {
                        int indexColumn = 0;
                        if (e.Key == System.Windows.Input.Key.Left)
                        {
                            indexColumn = this.Columns.FirstOrDefault(i => i.Visibility == System.Windows.Visibility.Visible)
                                == this.CurrentColumn ? this.Columns.IndexOf(item: this.CurrentColumn) :
                                this.Columns.IndexOf(item: this.CurrentColumn) - 1;
                        }
                        else if (e.Key == System.Windows.Input.Key.Right)
                        {
                            indexColumn = this.CurrentColumn == this.Columns.LastOrDefault(i => i.Visibility == System.Windows.Visibility.Visible)
                                ? this.Columns.IndexOf(item: this.CurrentColumn) : this.Columns.IndexOf(item: this.CurrentColumn) + 1;
                        }
                        else if (e.Key == System.Windows.Input.Key.Down)
                        {
                            if (this.IsComboBoxColumn(c: c))
                                return;

                            int index = this.Items.IndexOf(item: this.CurrentItem);

                            r = this.ItemContainerGenerator.ContainerFromIndex(index: index + 1 < this.Items.Count ?
                                index + 1 : index) as DataGridRow;
                            indexColumn = this.Columns.IndexOf(item: this.CurrentColumn);
                        }
                        else if (e.Key == System.Windows.Input.Key.Up)
                        {
                            if (this.IsComboBoxColumn(c: c))
                                return;

                            int index = this.Items.IndexOf(item: this.CurrentItem);

                            r = this.ItemContainerGenerator.ContainerFromIndex(index: index == 0 ?
                                0 : index - 1) as DataGridRow;
                            indexColumn = this.Columns.IndexOf(item: this.CurrentColumn);
                        }

                        this.SelectedCells.Clear();

                        DataGridCell cellToFocus = Util.GetCell(grid: this, row: r,
                                column: indexColumn);

                        if (cellToFocus != null)
                            cellToFocus.Focus();

                        this.BeginEdit();
                    }
                    else
                    {
                        this.BeginEdit();
                    }
                }
                else if (e.Key == System.Windows.Input.Key.Enter)
                {
                    if (this.CurrentColumn == this.Columns.LastOrDefault(i => i.Visibility == System.Windows.Visibility.Visible))
                    {
                        this.SelectedCells.Clear();
                        DataGridCell cellToFocus = null;

                        for (int i = 0; i < this.Columns.Count; i++)
                        {
                            cellToFocus = Util.GetCell(grid: this, row: r,
                                column: i);
                            if (cellToFocus != null)
                                if (cellToFocus.IsReadOnly == false && cellToFocus.Visibility == System.Windows.Visibility.Visible)
                                    break;
                        }

                        cellToFocus.Focus();
                        this.BeginEdit();
                    }
                }
                else if (e.Key == System.Windows.Input.Key.Tab)
                {
                    this.BeginEdit();
                }
        }

        protected override void OnPreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            DataGrid d = Util.FindParent<DataGrid>(child: (e.NewFocus as DependencyObject));

            if (d == null)
            {
                bool bPermiteKeyDown = true;

                this.ValidateModel(bPermiteKeyDown: out bPermiteKeyDown);

                if (!bPermiteKeyDown)
                    e.Handled = true;
                else
                    base.OnPreviewLostKeyboardFocus(e);
            }
            else
            {
                DataGridCell currentCell = e.NewFocus.GetType() == typeof(DataGridCell) ? e.NewFocus as DataGridCell :
                    Util.FindParent<DataGridCell>(child: e.NewFocus as DependencyObject);

                DataGridCell lostFocusCell = e.OldFocus.GetType() == typeof(DataGridCell) ? e.OldFocus as DataGridCell :
                    Util.FindParent<DataGridCell>(child: e.OldFocus as DependencyObject);

                if (currentCell == null || lostFocusCell == null)
                    base.OnPreviewLostKeyboardFocus(e);
                else
                    if (currentCell.DataContext != lostFocusCell.DataContext
                        && !lostFocusCell.DataContext.ToString().Contains(value: "NewItemPlaceholder"))
                    {
                        bool bPermiteKeyDown = true;
                        this.ValidateModel(bPermiteKeyDown: out bPermiteKeyDown);

                        if (!bPermiteKeyDown)
                            e.Handled = true;
                        else
                            base.OnPreviewLostKeyboardFocus(e);
                    }
                    else
                        base.OnPreviewLostKeyboardFocus(e);
            }
        }

        private void ValidateModel(out bool bPermiteKeyDown)
        {
#warning No "senão" implementar se current window não possui erros,
            // Será feito depois, após definição de como será populada lista de erros na Aba de erros

            if (this.CurrentItem == null)
                bPermiteKeyDown = true;
            else if (this.CurrentItem.ToString().Contains(value: "NewItemPlaceholder"))
                bPermiteKeyDown = true;
            else
                bPermiteKeyDown = true;
        }
        #endregion

        private bool IsComboBoxColumn(DataGridCell c)
        {
            if (c.Column.GetType() == typeof(DataGridTemplateColumn))
            {
                var element = ((c.Content as ContentPresenter).ContentTemplate as DataTemplate).LoadContent();
                var lComboBox = Util.FindVisualChildren<ComboBox>(depObj: element);

                if (lComboBox.Count() > 0)
                    return true;
            }
            else if (c.Column.GetType() == typeof(DataGridComboBoxColumn))
                return true;
            else if (c.GetType() == typeof(ComboBox))
                return true;

            return false;
        }

        #region Dependency Properties

        public DataGridColumn lastColumn
        {
            get { return (DataGridColumn)GetValue(lastColumnProperty); }
            set { SetValue(lastColumnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for lastColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lastColumnProperty =
            DependencyProperty.Register("lastColumn", typeof(DataGridColumn),
            typeof(CustomDataGrid), new PropertyMetadata(null));

        public bool IsReadOnlyUserControl
        {
            get { return (bool)GetValue(IsReadOnlyUserControlProperty); }
            set { SetValue(IsReadOnlyUserControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnlyUserControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyUserControlProperty =
            DependencyProperty.Register("IsReadOnlyUserControl", typeof(bool), typeof(CustomDataGrid),
            new PropertyMetadata(defaultValue: true));

        #endregion

    }

}
