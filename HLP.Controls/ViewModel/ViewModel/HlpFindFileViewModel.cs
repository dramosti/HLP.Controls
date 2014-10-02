using HLP.Controls.Base;
using HLP.Controls.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Controls.ViewModel.ViewModel
{
    public class HlpFindFileViewModel : modelBase
    {

        public ICommand ExecFind { get; set; }

        public HlpFindFileCommand command { get; set; }
        public HlpFindFileViewModel() 
        {
            command = new HlpFindFileCommand(this);
        }





    }
}
