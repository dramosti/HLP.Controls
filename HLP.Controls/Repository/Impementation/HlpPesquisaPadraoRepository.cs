using HLP.Controls.Repository.ADO;
using HLP.Controls.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.Impementation
{
    public class HlpPesquisaPadraoRepository
    {
        public List<RecordsSqlModel> GetRecordsFKUsed(string xTabela, string xCampo, string valor, int idEmpresa)
        {
            List<PesquisaPadraoModelContract> lCampos = this.getCamposSqlNotNull(
                xTabela: xTabela);

            string xDisplay = "";
            string xId = "";

            foreach (var item in lCampos)
            {
                if (item.DATA_TYPE == "PK")
                    xId += item.COLUMN_NAME;

                if (item.COLUMN_NAME.StartsWith(value: "x"))
                {
                    if (xDisplay == "")
                    {
                        xDisplay += item.COLUMN_NAME;
                    }
                    else
                    {
                        xDisplay += "+' - ', " + item.COLUMN_NAME;
                        break;
                    }

                }
            }

            try
            {
                string xWhere = string.Format(format: "where {0} = {1}", arg0: xCampo, arg1: valor);

                if (HlpDbFuncoes.fExisteCampo(sNomeCampo: "idEmpresa", sTabela: xTabela))
                {
                    xWhere += string.Format(format: " and idEmpresa = {0}", arg0: idEmpresa);
                }

                string xSelect = string.Format(format:
                    "select {0} from {1} {2}", arg0: string.Format(format: "{0} as id, CONCAT({1}) as display", arg0: xId, arg1: xDisplay), arg1: xTabela, arg2: xWhere);

                return HlpDbFuncoes.GetRegistros(xQuery: xSelect);
            }
            catch (Exception)
            {
                return new List<RecordsSqlModel>();
            }

        }

        private List<PesquisaPadraoModelContract> getCamposSqlNotNull(string xTabela)
        {
            List<PesquisaPadraoModelContract> lRet = new List<PesquisaPadraoModelContract>();

            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("select c.COLUMN_NAME, c.IS_NULLABLE, c.CHARACTER_MAXIMUM_LENGTH, keyC.type as DATA_TYPE from INFORMATION_SCHEMA.COLUMNS c ");
            sQuery.Append("left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE const ");
            sQuery.Append("on c.COLUMN_NAME = const.COLUMN_NAME and c.TABLE_NAME = const.TABLE_NAME ");
            sQuery.Append("left join sys.all_objects keyC ");
            sQuery.Append("on keyC.name = const.CONSTRAINT_NAME ");
            sQuery.Append("where c.TABLE_NAME = '" + xTabela + "'");

            DataTable dtRet = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            if (dtRet.Rows.Count > 0)
            {
                lRet = dtRet.AsEnumerable().Select(c => new PesquisaPadraoModelContract
                   {
                       CHARACTER_MAXIMUM_LENGTH = Convert.ToInt32(c["CHARACTER_MAXIMUM_LENGTH"]),
                       COLUMN_NAME = c["COLUMN_NAME"].ToString(),
                       DATA_TYPE = c["DATA_TYPE"].ToString(),
                       IS_NULLABLE = c["IS_NULLABLE"].ToString()
                   }).ToList();
            }

            return lRet;
        }
    }
}
