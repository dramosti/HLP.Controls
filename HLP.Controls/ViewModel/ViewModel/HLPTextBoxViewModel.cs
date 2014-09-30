using HLP.Controls.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class HLPTextBoxViewModel : INotifyPropertyChanged
    {
        public ICommand searchCommand { get; set; }
        HLPTextBoxCommands command;

        public HLPTextBoxViewModel() 
        {
            command = new HLPTextBoxCommands(viewModel_: this);

        }



        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
