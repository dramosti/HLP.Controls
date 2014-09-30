using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Dependencies
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterOrder : System.Attribute
    {
        public int Order { get; set; }
    }
}
