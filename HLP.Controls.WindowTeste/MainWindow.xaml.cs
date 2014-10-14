using HLP.Controls.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace HLP.Controls.WindowTeste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F6)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class MainWindowDataContext : INotifyPropertyChanged
    {

        private ObservableCollection<TesteModel> _ItemsIteste = new ObservableCollection<TesteModel>();
        public ObservableCollection<TesteModel> ItemsIteste
        {
            get { return _ItemsIteste; }
            set { _ItemsIteste = value; NotifyPropertyChanged("ItemsIteste"); }
        }

        private DateTime _dt;

        public DateTime dt
        {
            get { return _dt; }
            set
            {
                _dt = value;
                this.NotifyPropertyChanged(propertyName: "dt");
            }
        }

        private int _selectedFruta;

        public int selectedFruta
        {
            get { return _selectedFruta; }
            set
            {
                _selectedFruta = value;
                this.NotifyPropertyChanged(propertyName: "selectedFruta");
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
