using HLP.Controls.Model;
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

    public class CustomDataGridComboboxColumn : DataGridBoundColumn
    {
        private CustomComboBox _cbx = new CustomComboBox();
        public CustomComboBox cbx
        {
            get { return _cbx; }
            set { _cbx = value; }
        }


        private string _xItemsList;

        public string xItemsList
        {
            get { return _xItemsList; }
            set
            {
                _xItemsList = value;
                this.cbx.xItemsList = value;
            }
        }


        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            
            if (this.Binding != null)
                this.cbx.SetBinding(dp: CustomComboBox.SelectedValueProperty, binding: this.Binding);
            return cbx;
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock txt = new TextBlock();

            if (this.cbx != null)
            {
                if (this.cbx.SelectedIndex >= 0)
                {
                    var text = (this.cbx.SelectedItem as ItemsComboBoxModel).display.ToString();// ucItemSource.Cast<object>().ToArray()[this.cbx.SelectedIndex];
                    txt.Text = text.ToString();
                }
            }
            return txt;
        }
    }


}
