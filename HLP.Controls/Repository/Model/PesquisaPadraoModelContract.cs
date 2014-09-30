using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.Model
{
    public class PesquisaPadraoModelContract
    {
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string IS_NULLABLE { get; set; }
        public int CHARACTER_MAXIMUM_LENGTH { get; set; }
    }
}
