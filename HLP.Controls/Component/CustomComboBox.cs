using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Controls.Component
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            this.CustomViewModel = new CustomComboBoxViewModel();
        }
        static CustomComboBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomComboBox), new FrameworkPropertyMetadata(typeof(CustomComboBox)));
        }
        public CustomComboBoxViewModel CustomViewModel { get; set; }

        private string _xItemsList = "";
        public string xItemsList
        {
            get { return _xItemsList; }
            set
            {
                _xItemsList = value;
                if (value != "")
                {
                    this.DisplayMemberPath = "display";
                    this.SelectedValuePath = "index";
                    if (!Util.IsDesignTime())
                        this.ItemsSource = this.CustomViewModel.GetItemsList2(value);
                }

            }
        }



    }
}
