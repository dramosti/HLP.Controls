using HLP.Controls.Base;
using HLP.Controls.Services;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.Command
{
    public class CustomTextBoxIntellisenseCommands
    {
        CustomTextBoxIntellisenseViewModel objViewModel;
        HlpPesqPadraoService objDataService;

        public CustomTextBoxIntellisenseCommands(CustomTextBoxIntellisenseViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objDataService = new HlpPesqPadraoService();

            this.objViewModel.insertCommand = new RelayCommand(
                execute: e => this.InsertExecute(o: e),
                canExecute: cE => this.InsertCanExecute(o: cE));

            this.objViewModel.goToRecordCommand = new RelayCommand(
                execute: e => this.GoToRecord(o: e),
                canExecute: cE => this.GoToRecordCanExecute(o: cE));

            this.objViewModel.searchCommand = new RelayCommand(
                execute: e => this.SearchExecute(o: e));
        }

        public void GetResult()
        {
            DataTable dt = null;

            if (this.objViewModel.mainParameter == null) //Está executando uma view Comum
                dt = objDataService.GetData(sSelect:
                string.Format(format: "select * from {0}", arg0: this.objViewModel.xNameView)).Tables[index: 0];
            else // Está executando uma Function que retorna uma Sql Table http://technet.microsoft.com/pt-br/library/ms177499(v=sql.105).aspx
            {
                if (this.objViewModel.lParameters == null)
                {
                    dt = objDataService.GetData(sSelect:
                        string.Format(format: "select * from {0} ({1})", arg0: this.objViewModel.xNameView, arg1: this.objViewModel.mainParameter)).Tables[index: 0];
                }
                else
                {
                    string xSelect = string.Format(format: "select * from {0} ({1}", arg0: this.objViewModel.xNameView, arg1: this.objViewModel.mainParameter);

                    foreach (string _param in this.objViewModel.lParameters)
                    {
                        xSelect += ", " + _param;
                    }

                    xSelect += ")";

                    dt = objDataService.GetData(sSelect:
                        xSelect).Tables[index: 0];
                }
            }

            if (dt != null)
                this.objViewModel.cvs = CollectionViewSource.GetDefaultView(
                        source: dt.DefaultView) as CollectionView;
        }

        private void InsertExecute(object o)
        {
            object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

            if (nameWindow != null)
            {
                ICommand AddCommand = Application.Current.MainWindow.DataContext.GetType()
                    .GetProperty(name: "AddWindowCommand").GetValue(obj: Application.Current.MainWindow.DataContext) as ICommand;


                if (AddCommand != null)
                {
                    AddCommand.Execute(parameter: nameWindow);

                    object winManPropertyValue = Application.Current.MainWindow.DataContext.GetType()
                                    .GetProperty(name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

                    object _currentTab = winManPropertyValue.GetType().GetProperty(name: "_currentTab")
                        .GetValue(obj: winManPropertyValue);

                    object _DataContext = _currentTab.GetType().GetProperty(name: "_currentDataContext")
                        .GetValue(obj: _currentTab);

                    ICommand comm = _DataContext.GetType().GetProperty(name: "commandNovo").GetValue(obj: _DataContext) as ICommand;

                    if (comm != null)
                        comm.Execute(parameter: null);
                    else
                        throw new Exception(message: "Command Novo não configurado para a tela corrente");
                }
            }
        }

        private bool InsertCanExecute(object o)
        {
            if (o == null)
                return false;

            object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

            return nameWindow != null;
        }

        private void GoToRecord(object o)
        {
            if (o != null)
            {
                object nameWindow = o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o);

                if (nameWindow != null)
                {
                    ICommand AddCommand = Application.Current.MainWindow.DataContext.GetType()
                        .GetProperty(name: "AddWindowCommand").GetValue(obj: Application.Current.MainWindow.DataContext) as ICommand;

                    if (AddCommand != null)
                    {
                        AddCommand.Execute(parameter: nameWindow);
                        int id = 0;
                        object _id = o.GetType().GetProperty(name: "selectedId").GetValue(
                            obj: o);

                        if (_id != null)
                        {
                            if (int.TryParse(s: _id.ToString(), result: out id))
                            {
                                object winManPropertyValue = Application.Current.MainWindow.DataContext.GetType()
                                    .GetProperty(name: "winMan").GetValue(obj: Application.Current.MainWindow.DataContext);

                                object _currentTab = winManPropertyValue.GetType().GetProperty(name: "_currentTab")
                                    .GetValue(obj: winManPropertyValue);

                                object _DataContext = _currentTab.GetType().GetProperty(name: "_currentDataContext")
                                    .GetValue(obj: _currentTab);

                                _DataContext.GetType().GetProperty(name: "currentID").SetValue(obj: _DataContext, value: id);


                                object currentModel =
                                    _DataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: _DataContext);

                                if (currentModel != null)
                                {

                                    //if (MessageHlp.Show(stMessage: StMessage.stYesNo,
                                    //    xMessageToUser: "Window está sendo utilizada no momento, deseja cancelar a operação corrente " +
                                    //    " e pesquisar o registro?") != MessageBoxResult.Yes)
                                    //{
                                    //    return;
                                    //}

                                    _DataContext.GetType().GetProperty(name: "currentModel").SetValue(obj:
                                        _DataContext, value: null);
                                }

                                //MethodInfo miSetOp = _DataContext.GetType().GetMethod(
                                //    name: "SetValorCurrentOp");

                                //object[] _params = new object[] { OperationModel.searching };

                                //miSetOp.Invoke(obj: _DataContext, parameters: _params);

                                _DataContext.GetType().GetProperty(name: "bIsEnabled")
                                    .SetValue(obj: _DataContext, value: false);

                                BackgroundWorker bw = _DataContext.GetType().GetProperty(
                                    name: "bWorkerPesquisa").GetValue(obj: _DataContext) as BackgroundWorker;

                                if (bw != null)
                                {
                                    bw.RunWorkerAsync();
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool GoToRecordCanExecute(object o)
        {
            if (o == null)
                return false;
            object id = o.GetType().GetProperty(name: "selectedId").GetValue(obj: o);

            if (id == null)
                return false;

            return !(string.IsNullOrEmpty(value: id.ToString()));
        }

        private void SearchExecute(object o)
        {
            //Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", Base.InterfacesBases.TipoExibeForm.Normal);

            //if (winPesquisa != null)
            //{
            //    winPesquisa.WindowState = WindowState.Maximized;
            //    winPesquisa.GetType().GetProperty(name: "NameView").SetValue(obj: winPesquisa, value:
            //        o.GetType().GetProperty(name: "TableView").GetValue(obj: o));
            //    winPesquisa.GetType().GetProperty(name: "NameWindowCadastro").SetValue(obj: winPesquisa,
            //        value: o.GetType().GetProperty(name: "NameWindowCadastro").GetValue(obj: o));

            //    winPesquisa.ShowDialog();

            //    if ((winPesquisa.GetType().GetProperty(name: "lResult").GetValue(obj: winPesquisa)
            //        as List<int>).Count > 0)
            //    {
            //        int result = (winPesquisa.GetType().GetProperty(name: "lResult").GetValue(obj: winPesquisa)
            //        as List<int>).FirstOrDefault();
            //        o.GetType().GetProperty(name: "selectedId").SetValue(
            //            obj: o, value: result);
            //    }
            //}
        }
    }

}
