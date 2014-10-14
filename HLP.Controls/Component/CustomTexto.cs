using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Controls.Component
{
    public class CustomTexto : TextBox
    {
        public CustomTexto() 
        {
            this.Loaded += CustomTexto_Loaded;
        }

        void CustomTexto_Loaded(object sender, RoutedEventArgs e)
        {
            Binding b = new Binding();
            RelativeSource r = new RelativeSource();
            r.Mode = RelativeSourceMode.Self;

            PropertyPath p = new PropertyPath(path: "texto", pathParameters: new object[] { });
            b.Path = p; 
            b.RelativeSource = r;
           
            BindingOperations.SetBinding(this, CustomTexto.TextProperty, b);
        }


      


        public string texto
        {
            get { return (string)GetValue(textoProperty); }
            set { SetValue(textoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for texto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty textoProperty =
            DependencyProperty.Register("texto", typeof(string), typeof(CustomTexto), new PropertyMetadata(string.Empty));



    }
}
