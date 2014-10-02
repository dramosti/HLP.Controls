using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Enum
{
    public class EnumControls
    {
        public enum stFilterQuickSearch
        {
            equal,
            startWith,
            contains
        }

        public enum stFind
        {
            File,
            Folder
        }

        public enum stValidacao 
        {
            Int,
            Decimal,
            Moeda,
            Porcentagem,
            Text
        }
    }
}
