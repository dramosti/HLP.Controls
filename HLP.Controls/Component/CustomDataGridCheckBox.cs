using HLP.Controls.Converters.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.Component
{
    public class CustomDataGridCheckBox : DataGridBoundColumn
    {

        protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            CustomCheckBox chk = new CustomCheckBox();

            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            chk.SetBinding(dp: CustomCheckBox.IsCheckedProperty, binding: b);

            return chk;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            base.PrepareCellForEdit(editingElement, editingEventArgs);

            FocusManager.SetFocusedElement(element: editingElement, value: (editingElement as CustomCheckBox));

            return editingElement;
        }

        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            CustomCheckBox chk = new CustomCheckBox();
            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            chk.SetBinding(dp: CustomCheckBox.IsCheckedProperty, binding: b);
            return chk;
        }
    }
}
