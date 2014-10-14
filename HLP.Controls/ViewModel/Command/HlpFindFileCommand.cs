using HLP.Controls.Base;
using HLP.Controls.Component;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HLP.Controls.Static;

namespace HLP.Controls.ViewModel.Command
{
    public class HlpFindFileCommand
    {
        public HlpFindFileViewModel viewModel { get; set; }

        public HlpFindFileCommand(HlpFindFileViewModel viewModel)
        {
            this.viewModel = viewModel;

            this.viewModel.ExecFind = new RelayCommand(
               execute: e => this.ExecuteAcaoFind(ctr: e), canExecute: eC => true);
        }


        public void ExecuteAcaoFind(object ctr)
        {
            HLP.Controls.Enum.EnumControls.stFind f = (HLP.Controls.Enum.EnumControls.stFind)ctr.GetPropertyValue("Finder");
            string sTitle = ctr.GetPropertyValue("Title").ToString();
            string sReturn = "";

            switch (f)
            {
                case HLP.Controls.Enum.EnumControls.stFind.File:
                    {
                        System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
                        file.CheckFileExists = true;
                        file.Title = sTitle;

                        if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            sReturn = file.FileName;
                        }
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFind.Folder:
                    {
                        System.Windows.Forms.FolderBrowserDialog fole = new System.Windows.Forms.FolderBrowserDialog();
                        fole.Description = sTitle;
                        if (fole.ShowDialog() == DialogResult.OK)
                        {
                            sReturn = fole.SelectedPath;
                        }
                    }
                    break;
                default:
                    break;
            }

            ctr.SetPropertyValue("Text", sReturn);
        }
    }
}
