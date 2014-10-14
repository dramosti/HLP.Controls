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
         CustomCheckBox chk{ get; set; }

        protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            if (chk == null)
            {
                chk = new CustomCheckBox();
                Binding b = new Binding();
                b.Path = (this.Binding as Binding).Path;
                b.Mode = BindingMode.TwoWay;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                chk.SetBinding(dp: CustomCheckBox.IsCheckedProperty, binding: b);
            }
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
            CustomTextBlock txt = new CustomTextBlock();
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.OneWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BoolToTextConverter conv = new BoolToTextConverter();
            b.Converter = conv;
            txt.SetBinding(dp: CustomTextBlock.TextProperty, binding: b);
            return txt;
        }
    }

    class CustomCheckBox : CheckBox
    {
        static CustomCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCheckBox), new FrameworkPropertyMetadata(typeof(CustomCheckBox)));
        }
    }
}
