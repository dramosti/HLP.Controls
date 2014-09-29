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

        public DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            SqlDataBaseOperations sqlRepository = new SqlDataBaseOperations();
            return sqlRepository.GetData(xQuery: sSelect);
        }
    }
}
