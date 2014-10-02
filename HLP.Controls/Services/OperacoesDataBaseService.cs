using HLP.Controls.Base;
using HLP.Controls.Repository.ADO;
using HLP.Controls.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Services
{
    public class OperacoesDataBaseService
    {     
        wcfDbFunctions.IdbFunctionsToComponentsClient wcf = null;

        public DataTable qrySeekRet(string sExpressao) 
        {
            switch (Util.EmRedeLocal())
            {
                case TipoConexao.enumInternet:
                    {
                        if (wcf == null)
                            wcf = new wcfDbFunctions.IdbFunctionsToComponentsClient();

                        return wcf.qrySeekRet(sExpressao: sExpressao);
                    }
                case TipoConexao.enumRede:
                    {
                        return HlpDbFuncoes.qrySeekRet(sExpressao: sExpressao);
                    }
                default:
                    {
                        return null;
                    }
            }

        }

        public String qrySeekValue(string sTabela, string sCampo, string sWhere) 
        {
            switch (Util.EmRedeLocal())
            {
                case TipoConexao.enumInternet:
                    {
                        if (wcf == null)
                            wcf = new wcfDbFunctions.IdbFunctionsToComponentsClient();

                        return wcf.qrySeekValue(sTabela, sCampo, sWhere);
                    }
                case TipoConexao.enumRede:
                    {
                        return HlpDbFuncoes.qrySeekValue(sTabela, sCampo, sWhere);
                    }
                default:
                    {
                        return null;
                    }
            }

        }

    }
}
