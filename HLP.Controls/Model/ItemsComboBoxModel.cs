using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Model
{
    public class ItemsComboBoxModel : modelBase
    {
        private object _index;
        public object index
        {
            get { return _index; }
            set { _index = value; base.NotifyPropertyChanged("index"); }
        }

        private string _display;
        public string display
        {
            get { return _display; }
            set { _display = value; base.NotifyPropertyChanged("display"); }
        }
        
        
    }
}
