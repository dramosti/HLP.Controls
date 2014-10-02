using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Controls.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IdbFunctionsToComponents" in both code and config file together.
    [ServiceContract]
    public interface IdbFunctionsToComponents
    {
        [OperationContract]
        DataTable qrySeekRet(string sExpressao);

        //[OperationContract]
        //SqlDataReader qrySeekReader(string sExpressao);

        [OperationContract]
        DataTable qrySeekRet2(string sTabela, string sCampos = "");

        [OperationContract]
        DataTable qrySeekRet3(string sTabela, string sCampos, string sWhere);

        [OperationContract]
        String qrySeekValue(string sTabela, string sCampo, string sWhere);

        //[OperationContract]
        //bool qrySeek(string sTabela, string[] sCampos, string[] sValores);

        //[OperationContract]
        //bool qrySeek(string sExpressao);

        //[OperationContract]
        //void qrySeekUpdate(string sExpressao);

        //[OperationContract]
        //void qrySeekInsert(string sExpressao);

        [OperationContract]
        bool fExisteCampo(string sNomeCampo, string sTabela);

        [OperationContract]
        int GetRecord(string xNameTable, string xCampo, string xValue, HLP.Controls.Enum.EnumControls.stFilterQuickSearch stFilterQS, int idEmpresa = 0);

    }
}
