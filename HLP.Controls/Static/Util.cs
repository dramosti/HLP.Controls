using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Static
{
    public class Util
    {
        public static bool IsDesignTime() 
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
        }
    }
}
