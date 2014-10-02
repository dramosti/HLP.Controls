using HLP.Controls.Repository.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Controls.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "dbFunctionsToComponents" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select dbFunctionsToComponents.svc or dbFunctionsToComponents.svc.cs at the Solution Explorer and start debugging.
    public class dbFunctionsToComponents : IdbFunctionsToComponents
    {
        public dbFunctionsToComponents()
        {

        }

        public DataTable qrySeekRet(string sExpressao)
        {
            return HlpDbFuncoes.qrySeekRet(sExpressao);
        }

        //public System.Data.SqlClient.SqlDataReader qrySeekReader(string sExpressao)
        //{
        //    return HlpDbFuncoes.qrySeekReader(sExpressao);
        //}

        public DataTable qrySeekRet2(string sTabela, string sCampos = "")
        {
            return HlpDbFuncoes.qrySeekRet(sTabela, sCampos);
        }

        public DataTable qrySeekRet3(string sTabela, string sCampos, string sWhere)
        {
            return HlpDbFuncoes.qrySeekRet(sTabela, sCampos, sWhere);
        }

        public string qrySeekValue(string sTabela, string sCampo, string sWhere)
        {
            return HlpDbFuncoes.qrySeekValue(sTabela, sCampo, sWhere);
        }

        //public bool qrySeek(string sTabela, string[] sCampos, string[] sValores)
        //{

        //    return HlpDbFuncoes.qrySeek(sTabela, sCampos, sValores);
        //}

        //public bool qrySeek(string sExpressao)
        //{
        //    return HlpDbFuncoes.qrySeek(sExpressao);
        //}

        //public void qrySeekUpdate(string sExpressao)
        //{
        //    HlpDbFuncoes.qrySeekUpdate(sExpressao);
        //}

        //public void qrySeekInsert(string sExpressao)
        //{
        //    HlpDbFuncoes.qrySeekInsert(sExpressao);
        //}

        public bool fExisteCampo(string sNomeCampo, string sTabela)
        {
            return HlpDbFuncoes.fExisteCampo(sNomeCampo, sTabela);
        }

        public int GetRecord(string xNameTable, string xCampo, string xValue, Enum.EnumControls.stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {
            return HlpDbFuncoes.GetRecord(xNameTable, xCampo, xValue, stFilterQS, idEmpresa);
        }
    }
}
