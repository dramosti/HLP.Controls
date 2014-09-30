using HLP.Controls.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class CustomTextBoxIntellisenseViewModel : INotifyPropertyChanged
    {
        public ICommand insertCommand { get; set; }
        public ICommand goToRecordCommand { get; set; }
        public ICommand searchCommand { get; set; }

        CustomTextBoxIntellisenseCommands comm;
        readonly Popup popUp;

        private CollectionView _cvs;
        public CollectionView cvs
        {
            get { return _cvs; }
            set
            {
                _cvs = value;
                this.NotifyPropertyChanged(propertyName: "cvs");
            }
        }

        private DataRowView _selectedItem;

        public DataRowView selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                this.NotifyPropertyChanged(propertyName: "selectedItem");
            }
        }

        public CustomTextBoxIntellisenseViewModel(Popup popUp)
        {
            comm = new CustomTextBoxIntellisenseCommands(
                objViewModel: this);

            this.popUp = popUp;

            this.lCampos = new List<string>();
        }

        public void GetResult()
        {
            this.comm.GetResult();
        }

        private string _xTextSearch;
        public string xTextSearch
        {
            get { return _xTextSearch; }
            set
            {
                _xTextSearch = value;

                if (string.IsNullOrEmpty(value: value) && cvs != null)
                {
                    (cvs as BindingListCollectionView).CustomFilter = null;
                    this.popUp.IsOpen = false;
                }
                else
                {
                    if (cvs != null)
                    {
                        this.popUp.IsOpen = true;
                        (cvs as BindingListCollectionView).CustomFilter = this.FilterItem();
                        int count = 0;
                        object vValueCell = null;
                        bool itemFound = false;
                        if (cvs.Count > 0)
                        {
                            foreach (var campo in (cvs as BindingListCollectionView).ItemProperties)
                            {
                                Type t = campo.PropertyType;

                                foreach (DataRowView r in (this.popUp.Child as DataGrid).Items)
                                {
                                    vValueCell = r.Row.ItemArray[count];
                                    if (t == typeof(int) || t == typeof(Nullable<int>))
                                    {
                                        int vValor = 0;

                                        if (int.TryParse(s: this.xTextSearch, result: out vValor))
                                        {
                                            int vIntValidated = 0;

                                            if (vValueCell != null)
                                            {
                                                int.TryParse(s: vValueCell.ToString(), result: out vIntValidated);
                                            }

                                            if (vIntValidated == vValor)
                                            {
                                                this.selectedItem = r;
                                                itemFound = true;
                                                break;
                                            }
                                        }
                                    }
                                    else if (t == typeof(string))
                                    {
                                        if (vValueCell.ToString().ToUpper().Contains(value: this.xTextSearch.ToUpper()))
                                        {
                                            this.selectedItem = r;
                                            itemFound = true;
                                            break;
                                        }
                                    }

                                }

                                if (itemFound)
                                    break;

                                count++;
                            }
                        }
                        if (this.cvs.Count == 0)
                            this.popUp.IsOpen = false;
                    }

                }
                this.NotifyPropertyChanged(propertyName: "xTextSearch");
            }
        }

        private string[] _lParameters;

        public string[] lParameters
        {
            get { return _lParameters; }
            set { _lParameters = value; }
        }

        private string _mainParameter;

        public string mainParameter
        {
            get { return _mainParameter; }
            set { _mainParameter = value; }
        }


        private string _xNameView;
        public string xNameView
        {
            get { return _xNameView; }
            set { _xNameView = value; }
        }

        private int _indexIdProperty;
        public int indexIdProperty
        {
            get { return _indexIdProperty; }
            set { _indexIdProperty = value; }
        }

        private List<string> _lCampos;
        public List<string> lCampos
        {
            get { return _lCampos; }
            set { _lCampos = value; }
        }

        public string FilterItem()
        {
            string xQuery = string.Empty;

            int count = 0;
            if (cvs != null)
                foreach (var campo in (cvs as BindingListCollectionView).ItemProperties)
                {

                    if (campo.Name.ToUpper() == "ID")
                        this.indexIdProperty = count;

                    Type t = campo.PropertyType;

                    if (t == typeof(int) || t == typeof(Nullable<int>))
                    {
                        int vValor = 0;

                        if (int.TryParse(s: this.xTextSearch, result: out vValor))
                            xQuery += xQuery == "" ? string.Format(format: "{0} = {1}", arg0: campo.Name, arg1: vValor)
                                : string.Format(format: " OR {0} = {1}", arg0: campo.Name, arg1: vValor);
                    }
                    else if (t == typeof(string))
                    {
                        xQuery += xQuery == "" ? string.Format(format: "{0} LIKE '%{1}%'", arg0: campo.Name, arg1: this.xTextSearch)
                            : string.Format(format: " OR {0} LIKE '%{1}%'", arg0: campo.Name, arg1: this.xTextSearch);
                    }
                    count++;
                }

            return xQuery;
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
