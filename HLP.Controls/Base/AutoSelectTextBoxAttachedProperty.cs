using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Controls.Base
{
    public class AutoSelectTextBoxAttachedProperty
    {
        public static bool GetAutoSelect(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoSelectProperty);
        }

        public static void SetAutoSelect(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoSelectProperty, value);
        }

        public static readonly DependencyProperty AutoSelectProperty =
            DependencyProperty.RegisterAttached("AutoSelect", typeof(bool), typeof(AutoSelectTextBoxAttachedProperty),
                                                new FrameworkPropertyMetadata(false,
                                                                              new PropertyChangedCallback(
                                                                                  OnAutoSelectChanged)));


        private static void OnAutoSelectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = null;
            try
            {
                textBox = (TextBox)d;
            }
            catch
            {

                return;

            }

            if (textBox != null)
            {
                if ((bool)e.NewValue)
                {
                    textBox.GotKeyboardFocus += delegate { textBox.SelectAll(); };
                }
                return;
            }

        }
    }
}
