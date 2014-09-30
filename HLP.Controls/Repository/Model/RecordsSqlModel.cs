using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.Model
{
    public class RecordsSqlModel : modelBase
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                this.NotifyPropertyChanged(propertyName: "id");
            }
        }

        private string _display;

        public string display
        {
            get { return _display.ToUpper(); }
            set
            {
                _display = value;
                this.NotifyPropertyChanged(propertyName: "display");
            }
        }
   
    }
}
