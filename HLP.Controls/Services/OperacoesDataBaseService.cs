using HLP.Controls.Repository.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Services
{
    public class OperacoesDataBaseService
    {
        public int GetIdRecordToQuickSearch(string xNameTable, string xCampo, string xValue, HLP.Controls.Enum.EnumControls.stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {
            return HlpDbFuncoes.GetRecord(
                             xNameTable: xNameTable, xCampo: xCampo, xValue: xValue, idEmpresa: idEmpresa, stFilterQS: stFilterQS);
        }
    }
}
