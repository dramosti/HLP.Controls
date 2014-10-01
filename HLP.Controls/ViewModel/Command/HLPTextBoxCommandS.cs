using HLP.Controls.Base;
using HLP.Controls.Static;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Controls.ViewModel.Command
{
    public class HLPTextBoxCommands
    {
        HLPTextBoxViewModel viewModel;

        public HLPTextBoxCommands(HLPTextBoxViewModel viewModel_)
        {
            this.viewModel = viewModel_;

            this.viewModel.searchCommand = new RelayCommand(
                execute: e => this.SearchExecute(o: e), canExecute: eC => this.SearchCanExecute(eC));
        }

        private void SearchExecute(object o)
        {
            Controls.Component.HlpTextBox txt = (o as Controls.Component.HlpTextBox);


            object _dataContext = o.GetType().GetProperty(name: "DataContext").GetValue(obj: o);
            PropertyInfo _modelType = null;

            if (_dataContext != null)
            {
                if (o != null)
                    _modelType = _dataContext.GetType().GetProperty(name: "currentModel");

                object[] _params = new object[] { _modelType.PropertyType, o };

                object _return = Util.ExecuteMethodByReflection(xNamespace: "HLP.Components.View.WPF",
                    xType: "wdQuickSearch", xMethod: "ShowDialogWdQuickSearch",
                                parameters: _params);

                _dataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _dataContext, value: _return);


                if ((int?)_return > 0)
                {
                    PropertyInfo currentModelProperty =
                _dataContext.GetType().GetProperty(name: "currentModel");


                    if (currentModelProperty != null)
                        currentModelProperty.SetValue(obj: _dataContext, value: null);

                    PropertyInfo navigatePesquisa =
                        _dataContext.GetType().GetProperty(name: "navigatePesquisa");

                    if (navigatePesquisa != null)
                        navigatePesquisa.SetValue(obj: _dataContext, value: null);

                    _dataContext.GetType().GetProperty(name: "bIsEnabled")
                        .SetValue(obj: _dataContext, value: false);

                    BackgroundWorker bw = _dataContext.GetType().GetProperty(
                        name: "bWorkerPesquisa").GetValue(obj: _dataContext) as BackgroundWorker;

                    if (bw != null)
                    {
                        bw.RunWorkerAsync();
                    }
                }
            }

        }

        private bool SearchCanExecute(object o)
        {
            Controls.Component.HlpTextBox txt = (o as Controls.Component.HlpTextBox);

<<<<<<< HEAD
            if (txt != null)
            {
                if (txt.IsReadOnly)
                    return true;
                else
                    return false;
            }
=======
            if (txt == null)
                return true;
            else if (txt.IsReadOnly)
                return true;
>>>>>>> 1903ecd26a14775d80cdec2b9c74e24e0351670f
            else
                return true;

            //if (o == null)
            //    return true;

            //if ((o as Control).DataContext == null)
            //    return true;

            //PropertyInfo piModel = (o as Control).DataContext.GetType().GetProperty(
            //    name: "currentModel");

            //if (piModel == null)
            //    return true;

            //Button btn = (o as Control).Template.FindName(name: "btn", templatedParent: (o as FrameworkElement)) as Button;

            //object _value = piModel.GetValue(obj: (o as Control).DataContext);

            //if (_value == null)
            //{
            //    btn.Visibility = Visibility.Visible;
            //    return true;
            //}


            //bool retorno = (_value as modelBase).GetOperationModel()
            //     != OperationModel.updating;

            //(o as Control).ApplyTemplate();

            //PropertyInfo stVisibilityBtnQuickSearchProperty
            //    = o.GetType().GetProperty(name: "stVisibilityBtnQuickSearch");

            //StVisibilityButtonQuickSearch stVisibilityBtnQuickSearch = StVisibilityButtonQuickSearch._default;

            //if (stVisibilityBtnQuickSearchProperty != null)
            //    stVisibilityBtnQuickSearch = (StVisibilityButtonQuickSearch)stVisibilityBtnQuickSearchProperty.GetValue(
            //        obj: o);

            //if ((btn != null && !retorno)
            //    || stVisibilityBtnQuickSearch == StVisibilityButtonQuickSearch.notVisible)
            //{
            //    btn.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    btn.Visibility = Visibility.Visible;
            //}

            return true;
        }
    }
}
