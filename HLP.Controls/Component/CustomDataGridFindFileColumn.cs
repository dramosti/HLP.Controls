using HLP.Controls.Converters.Component;
using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    public class CustomDataGridFindFileColumn : DataGridBoundColumn
    {
        CustomFindFile txtFindFile { get; set; }

        public CustomDataGridFindFileColumn() 
        {
            txtFindFile = new CustomFindFile();
        }

        protected override System.Windows.FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            txtFindFile.SetBinding(dp: CustomFindFile.TextProperty, binding: b);
            return txtFindFile;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            base.PrepareCellForEdit(editingElement, editingEventArgs);

            FocusManager.SetFocusedElement(element: editingElement, value: (editingElement as CustomFindFile));

            return editingElement;
        }

        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            CustomTextBlock txt = new CustomTextBlock();
            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.OneWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            txt.SetBinding(dp: CustomTextBlock.TextProperty, binding: b);
            return txt;
        }
    }

    class CustomFindFile : TextBox
    {
        static CustomFindFile()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomFindFile), new FrameworkPropertyMetadata(typeof(CustomFindFile)));
        }

        public CustomFindFile()
        {
            this.CustomViewModel = new HlpFindFileViewModel();
            this.Text = string.Empty;
            this.MouseDoubleClick += CustomFindFile_MouseDoubleClick;
            this.KeyDown += CustomFindFile_KeyDown;
            this.KeyUp += CustomFindFile_KeyUp;
        }

        void CustomFindFile_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                && e.Key == Key.O)
            {
                this.OpenFile();
            }
        }

        void CustomFindFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                this.CustomViewModel.command.ExecuteAcaoFind(this);
        }

        void CustomFindFile_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFile();
        }

        private HLP.Controls.Enum.EnumControls.stFind _finder = HLP.Controls.Enum.EnumControls.stFind.File;
        public HLP.Controls.Enum.EnumControls.stFind Finder
        {
            get { return _finder; }
            set { _finder = value; }
        }

        private string _title = "";
        public string Title
        {
            get
            {
                if (_title == "")
                {
                    if (Finder == Enum.EnumControls.stFind.File)
                    {
                        return "HLP - PROCURAR ARQUIVO";
                    }
                    else
                    {
                        return "HLP - PRODUCAR PASTA";
                    }
                }
                else return _title;
            }
            set { _title = value; }
        }

        public HlpFindFileViewModel CustomViewModel { get; set; }

        #region Methods
        private void OpenFile()
        {
            switch (this.Finder)
            {
                case HLP.Controls.Enum.EnumControls.stFind.File:
                    if (File.Exists(this.Text))
                    {
                        System.Diagnostics.Process.Start(this.Text);
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFind.Folder:
                    if (Directory.Exists(this.Text))
                    {
                        System.Diagnostics.Process.Start(this.Text);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
