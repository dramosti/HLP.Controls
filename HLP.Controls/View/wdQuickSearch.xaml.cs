using HLP.Controls.ViewModel.ViewModel;
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
using System.Windows.Shapes;

namespace HLP.Controls.View
{
    /// <summary>
    /// Interaction logic for wdQuickSearch.xaml
    /// </summary>
    public partial class wdQuickSearch : Window
    {
        public wdQuickSearch(Type modelType, object sender)
        {
            InitializeComponent();
            this.ViewModel = new QuickSearchViewModel(modelType: modelType, sender: sender);
        }

        public QuickSearchViewModel ViewModel
        {
            get
            {
                return this.DataContext as QuickSearchViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public static int ShowDialogWdQuickSearch(Type modelType, object sender)
        {
            wdQuickSearch wd = new wdQuickSearch(modelType: modelType, sender: sender);
            wd.ShowDialog();
            return wd.ViewModel.returnedId;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (this.ViewModel.searchCommad.CanExecute(parameter: null))
                    this.ViewModel.searchCommad.Execute(parameter: this);
            }
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
