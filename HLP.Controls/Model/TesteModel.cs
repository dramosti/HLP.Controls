using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Model
{
    public sealed class TesteModel : modelBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged("id"); }
        }

        private string _xNome;

        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; NotifyPropertyChanged("id"); }
        }

        private bool _bAtivo;

        public bool bAtivo
        {
            get { return _bAtivo; }
            set { _bAtivo = value; NotifyPropertyChanged("bAtivo"); }
        }

        private int _idSexo;
        public int idSexo
        {
            get { return _idSexo; }
            set { _idSexo = value; NotifyPropertyChanged("idSexo"); }
        }

        private string _xArquivo;

        public string xArquivo
        {
            get { return _xArquivo; }
            set { _xArquivo = value; NotifyPropertyChanged("xArquivo"); }
        }

        private DateTime _dtNascimento = DateTime.Now;

        public DateTime dtNascimento
        {
            get { return _dtNascimento; }
            set { _dtNascimento = value; NotifyPropertyChanged("dtNascimento"); }
        }

        private TimeSpan _time = new TimeSpan(0, 0, 0);

        public TimeSpan time
        {
            get { return _time ; }
            set { _time =  value; NotifyPropertyChanged("time"); }
        }

    }
}
