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

            this.objViewModel.returnedId = objService.GetIdRecordToQuickSearch(
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
    }
}
