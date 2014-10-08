using HLP.Controls.Base;
using HLP.Controls.Component;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace HLP.Controls.ViewModel.Command
{
    public sealed class HlpDatePickerCommand
    {

        public HlpDatePickerViewModel viewModel { get; set; }
        public HlpDatePickerCommand(HlpDatePickerViewModel viewModel_)
        {
            this.viewModel = viewModel_;

            this.viewModel.openPopupCommand = new RelayCommand(
                 execute: e => this.OpenPopup(popup: e), canExecute: eC => true);
        }



        public void OpenPopup(object popup)
        {
            (popup as HlpDatePicker).mainCalendar.IsOpen = true;
        }
    }
}
