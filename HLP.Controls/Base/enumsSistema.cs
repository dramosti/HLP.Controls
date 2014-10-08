using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Base
{
    public enum TipoConexao
    {
        enumInternet,
        enumRede,
        enumOff
    }

    public enum TipoDateTime
    {
        enumDate,
        enumTime,
        enumDateTime
    }

    public enum StatusOperacaoTreeView
    {
        enumNenhum,
        enumCarregando,
        enumTerminado
    }

    public enum TipoOperacaoTreeView
    {
        enumCarregando,
        enumLivre,
        enumFinalizado
    }
}
