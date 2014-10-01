using HLP.Controls.Repository.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Controls.Base;
using HLP.Controls.Static;

namespace HLP.Controls.Services
{
    public class HlpPesqPadraoService
    {
        wcfDbFunctions.IdbFunctionsToComponentsClient wcf = null;

        public HlpPesqPadraoService()
        {
        }

        public DataTable GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {

            switch (Util.EmRedeLocal())
            {
                case TipoConexao.enumInternet:
                    {
                        if (wcf == null)
                            wcf = new wcfDbFunctions.IdbFunctionsToComponentsClient();

                        return wcf.GetData(sSelect: sSelect);
                    }
                case TipoConexao.enumRede:
                    {
                        return HlpDbFuncoes.qrySeekRet(sExpressao: sSelect);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
