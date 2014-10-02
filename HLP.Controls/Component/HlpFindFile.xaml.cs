using HLP.Controls.Base;
using HLP.Controls.Converters.Component;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for FindFile.xaml
    /// </summary>
    public partial class HlpFindFile : UserControlBase
    {
        public HlpFindFile()
        {
            InitializeComponent();
            this.CustomViewModel = new HlpFindFileViewModel();

        }

        public HlpFindFileViewModel CustomViewModel { get; set; }

       



        private HLP.Controls.Enum.EnumControls.stFind _finder = HLP.Controls.Enum.EnumControls.stFind.File;
        public HLP.Controls.Enum.EnumControls.stFind Finder
        {
            get { return _finder; }
            set { _finder = value; base.NotifyPropertyChanged("Finder"); }
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
            set { _title = value; base.NotifyPropertyChanged("Title"); }
        }


        #region Events
        private void compBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt.Focus();
        }

        private void txt_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFile();
        }

        private void txt_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                this.CustomViewModel.command.ExecuteAcaoFind(this);
        }

        private void txt_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                && e.Key == Key.O)
            {
                this.OpenFile();
            }
        }
        #endregion

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
