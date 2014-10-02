using HLP.Controls.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class QuickSearchViewModel : INotifyPropertyChanged
    {
        public ICommand searchCommad { get; set; }
        public ICommand closeCommand { get; set; }
        public ICommand ChangeToEqualCommand { get; set; }
        public ICommand ChangeToStartWithCommand { get; set; }
        public ICommand ChangeToContainsCommand { get; set; }

        QuickSearchCommands comm;

        public QuickSearchViewModel(Type modelType, object sender)
        {

            BindingExpression bExp = (sender as HLP.Controls.Component.HlpTextBox).GetBindingExpression(dp: HLP.Controls.Component.HlpTextBox.TextProperty);

            this.modelType = modelType;


            if (bExp != null)
            {
                this.xNameBinding = bExp.ParentBinding.Path.Path.Replace(oldValue: "currentModel.", newValue: "");
                PropertyInfo piField = this.modelType.GetProperty(name: this.xNameBinding);

                this.fieldType = piField.PropertyType;

                if (this.fieldType.FullName.ToUpper().Contains(value: "INT"))
                {
                    this.stFilterQs = HLP.Controls.Enum.EnumControls.stFilterQuickSearch.equal;
                }
                else
                {
                    this.stFilterQs = HLP.Controls.Enum.EnumControls.stFilterQuickSearch.contains;
                }
            }

            if (modelType.GetProperties().Count(i => i.Name == "idEmpresa") > 1)
            {
              //  this.idEmpresa = CompanyData.idEmpresa;
                this.idEmpresa = 0;
#warning analisar como será passado o idempresa
            }
            else
            {
                this.idEmpresa = 0;
            }

            comm = new QuickSearchCommands(objViewModel: this);
        }

        private int _returnedId;

        public int returnedId
        {
            get { return _returnedId; }
            set { _returnedId = value; }
        }

        private object _sender;

        public object sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        private string _xNameBinding;

        public string xNameBinding
        {
            get { return _xNameBinding; }
            set { _xNameBinding = value; }
        }

        private string _xValue;

        public string xValue
        {
            get { return _xValue; }
            set
            {
                _xValue = value;
                this.NotifyPropertyChanged(propertyName: "xValue");
            }
        }

        private HLP.Controls.Enum.EnumControls.stFilterQuickSearch _stFilterQs;

        public HLP.Controls.Enum.EnumControls.stFilterQuickSearch stFilterQs
        {
            get { return _stFilterQs; }
            set
            {
                _stFilterQs = value;
                this.NotifyPropertyChanged(propertyName: "stFilterQs");
            }
        }

        private Type _modelType;

        public Type modelType
        {
            get { return _modelType; }
            set { _modelType = value; }
        }

        private int _idEmpresa;

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        private Type _fieldType;

        public Type fieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
