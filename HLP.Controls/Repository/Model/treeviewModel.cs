using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.Model
{
    public class treeviewModel : modelBase
    {
        public treeviewModel()
        {
            this.lItens = new ObservableCollection<treeviewModel>();
        }

        private int _idPk;

        public int idPk
        {
            get { return _idPk; }
            set
            {
                _idPk = value;
                base.NotifyPropertyChanged(propertyName: "idPk");
            }
        }

        private string _xDisplay;

        public string xDisplay
        {
            get { return _xDisplay; }
            set
            {
                _xDisplay = value;
                base.NotifyPropertyChanged(propertyName: "xDisplay");
            }
        }

        private ObservableCollection<treeviewModel> _lItens;

        public ObservableCollection<treeviewModel> lItens
        {
            get { return _lItens; }
            set
            {
                _lItens = value;
                base.NotifyPropertyChanged(propertyName: "lItens");
            }
        }

    }
}
