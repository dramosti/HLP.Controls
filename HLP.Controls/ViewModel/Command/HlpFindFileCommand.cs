using HLP.Controls.Base;
using HLP.Controls.Component;
using HLP.Controls.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        void ExecuteAcaoFind(object ctr)
        {
            HlpFindFile controle = ctr as HlpFindFile;
            switch (controle.Finder)
            {
                case HLP.Controls.Enum.EnumControls.stFind.File:
                    {
                        System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
                        file.CheckFileExists = true;
                        file.Title = controle.Title;

                        if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            controle.Text = file.FileName;
                        }
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFind.Folder:
                    {
                        System.Windows.Forms.FolderBrowserDialog fole = new System.Windows.Forms.FolderBrowserDialog();
                        fole.Description = controle.Title;
                        if (fole.ShowDialog() == DialogResult.OK)
                        {
                            controle.Text = fole.SelectedPath;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
