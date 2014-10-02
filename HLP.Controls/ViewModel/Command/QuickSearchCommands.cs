using HLP.Controls.Base;
using HLP.Controls.Services;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Controls.ViewModel.Command
{
    public class QuickSearchCommands
    {
        QuickSearchViewModel objViewModel;
        OperacoesDataBaseService objService;

        public QuickSearchCommands(QuickSearchViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objService = new OperacoesDataBaseService();
            this.objViewModel.searchCommad = new RelayCommand(
                execute: e => this.SearchExecute(o: e), canExecute: cE => this.SearchCanExecute());

            this.objViewModel.ChangeToEqualCommand = new RelayCommand(
                execute: e => this.ChangeToEqualExecute(), canExecute: eC => this.ChangeToEqualCanExecute());

            this.objViewModel.ChangeToStartWithCommand = new RelayCommand(
                execute: e => this.ChangeToStartWithExecute(), canExecute: eC => this.ChangeToStartWithCanExecute());

            this.objViewModel.ChangeToContainsCommand = new RelayCommand(
                execute: e => this.ChangeToContainsExecute(), canExecute: eC => this.ChangeToContainsCanExecute());

            this.objViewModel.closeCommand = new RelayCommand(execute: e => this.CloseExecute(o: e));
           
        }


        private void ChangeToEqualExecute()
        {
            this.objViewModel.stFilterQs = HLP.Controls.Enum.EnumControls.stFilterQuickSearch.equal;
        }

        private bool ChangeToEqualCanExecute()
        {
            return true;
        }

        private void ChangeToStartWithExecute()
        {
            this.objViewModel.stFilterQs = HLP.Controls.Enum.EnumControls.stFilterQuickSearch.startWith;
        }

        private bool ChangeToStartWithCanExecute()
        {
            return this.objViewModel.fieldType.Name.ToUpper().Contains(value: "STRING");
        }

        private void ChangeToContainsExecute()
        {
            this.objViewModel.stFilterQs = HLP.Controls.Enum.EnumControls.stFilterQuickSearch.contains;
        }

        private bool ChangeToContainsCanExecute()
        {
            return this.objViewModel.fieldType.Name.ToUpper().Contains(value: "STRING");
        }

        private void SearchExecute(object o)
        {
            string xNameTable = this.objViewModel.modelType.Name.ToUpper()
                .Replace(oldValue: "MODEL", newValue: "");

            this.objViewModel.returnedId = this.GetRecord(
                xNameTable: xNameTable,
                xCampo: this.objViewModel.xNameBinding,
                xValue: this.objViewModel.xValue,
                stFilterQS: this.objViewModel.stFilterQs);

            (o as Window).DialogResult = true;
            (o as Window).Close();
        }

        private bool SearchCanExecute()
        {
            return !(string.IsNullOrEmpty(value: this.objViewModel.xValue));
        }

        private void CloseExecute(object o)
        {
            (o as Window).Close();
        }


        public int GetRecord(string xNameTable, string xCampo, string xValue, HLP.Controls.Enum.EnumControls.stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {
            string queryGetPkField = string.Format(format: "SELECT COLUMN_NAME FROM " +
        "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
        "where TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')", arg0: xNameTable);

            object nameFieldPk = objService.qrySeekValue("INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE", "COLUMN_NAME",
                string.Format("TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')", xNameTable));

            string sWhere = string.Empty;

            switch (stFilterQS)
            {
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.equal:
                    {
                        sWhere = string.Format(format: " {0} = '{1}'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.startWith:
                    {
                        sWhere = string.Format(format: " {0} LIKE'{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.contains:
                    {
                        sWhere = string.Format(format: " {0} LIKE'%{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                default:
                    break;
            }

            string query = string.Format(format: "SELECT {0} FROM {1} {2}",
                arg0: nameFieldPk, arg1: xNameTable, arg2: sWhere);

            if (idEmpresa > 0)
            {
                sWhere += string.Format(format: "{0} and idEmpresa = {1}", arg0: query, arg1: idEmpresa);
            }

            string record = objService.qrySeekValue(xNameTable, nameFieldPk.ToString(), sWhere);
            int iRet = 0;
            int.TryParse(record, out iRet);
            return iRet;
        }



    }
}
