using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Static
{
    public static class Extensions
    {
        public static void SetPropertyValue(this object containingObject, string propertyName, object newValue)
        {
            if (containingObject != null)
                containingObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, containingObject, new object[] { newValue });
        }
    }
}
