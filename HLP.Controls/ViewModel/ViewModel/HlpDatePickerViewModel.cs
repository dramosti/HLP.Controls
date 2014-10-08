using HLP.Controls.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class HlpDatePickerViewModel
    {
        public ICommand openPopupCommand { get; set; }
        public HlpDatePickerCommand command { get; set; }
        public HlpDatePickerViewModel() 
        {
            command = new HlpDatePickerCommand(viewModel_: this);
        }
    }
}
