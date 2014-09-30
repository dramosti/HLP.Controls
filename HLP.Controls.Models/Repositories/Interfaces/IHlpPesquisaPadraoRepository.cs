using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Repositories.Interfaces
{
    public interface IHlpPesquisaPadraoRepository
    {
        object GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true);
    }
}
