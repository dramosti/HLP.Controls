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

        public static object GetPropertyValue(this object value, string sNameProperty)
        {
            try
            {
                return value.GetType().GetProperty(sNameProperty).GetValue(value, null);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao buscar a propriedade {0} do objeto:{1}{3}Erro:", sNameProperty, value.GetType().Name, Environment.NewLine) + ex.Message);
            }
        }
    }
}
