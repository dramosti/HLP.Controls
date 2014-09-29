using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Controls.Wcfs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwcfPesquisaRapida" in both code and config file together.
    [ServiceContract]
    public interface IwcfPesquisaRapida
    {
        [OperationContract]
        string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa);
    }
}
