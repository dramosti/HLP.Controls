using HLP.Controls.Repository.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Services
{
    public class HlpPesqPadraoService
    {
        public HlpPesqPadraoService()
        {
        }

        public DataTable GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            return HlpDbFuncoes.qrySeekRet(sExpressao: sSelect);
        }
    }
}
