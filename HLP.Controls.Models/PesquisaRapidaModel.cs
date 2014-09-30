using HLP.Controls.Models.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models
{
    public class PesquisaRapidaModel
    {
        [ParameterOrder(Order = 1)]
        public string Display { get; set; }

        [ParameterOrder(Order = 2)]
        public int Valor { get; set; }
    }
}
