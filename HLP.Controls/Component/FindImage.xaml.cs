using HLP.Controls.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Controls.Component
{
    /// <summary>
    /// Interaction logic for FindFile.xaml
    /// </summary>
    public partial class FindImage : UserControlBase
    {
        public FindImage()
        {
            InitializeComponent();
        }

        public string xPathImage
        {
            get { return (string)GetValue(xPathImageProperty); }
            set { SetValue(xPathImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xPathImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xPathImageProperty =
            DependencyProperty.Register("xPathImage", typeof(string), typeof(FindImage), new PropertyMetadata(
                defaultValue: string.Empty, propertyChangedCallback: new PropertyChangedCallback(pathImgChanged)));

        public static void pathImgChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue != null)
            {
                if (File.Exists(path: args.NewValue.ToString()))
                {
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.DecodePixelHeight = bmp.DecodePixelWidth = 200;
                    bmp.UriSource = new Uri(uriString: args.NewValue.ToString());

                    bmp.EndInit();

                    (d as FindImage).img = bmp;

                    if ((d as FindImage).popUpImg.IsOpen == false
                && File.Exists(path: args.NewValue.ToString())
                        && (d as FindImage).IsReadOnly == false)
                    {
                        (d as FindImage).popUpImg.IsOpen = true;
                        return;
                    }
                }
            }

            (d as FindImage).popUpImg.IsOpen = false;
        }

        public BitmapImage img
        {
            get { return (BitmapImage)GetValue(imgProperty); }
            set { SetValue(imgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for img.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty imgProperty =
            DependencyProperty.Register("img", typeof(BitmapImage), typeof(FindImage), new PropertyMetadata(null));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SearchImage();
        }

        private void SearchImage()
        {
            OpenFileDialog findImage = new OpenFileDialog();

            findImage.Filter = "Image Files|*.jpg;*.jpeg;*.png; *.bmp;";

            if (findImage.ShowDialog() == true)
            {
                this.xPathImage = findImage.FileName;
            }
        }

        private void txtPath_MouseLeave(object sender, MouseEventArgs e)
        {
            this.popUpImg.IsOpen = false;
        }

        private void txtPath_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.popUpImg.IsOpen == false
                && File.Exists(path: this.txtPath.Text)
                && this.IsReadOnly == false)
            {
                this.popUpImg.IsOpen = true;
            }
        }

        private void txtPath_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.popUpImg.IsOpen == false
                && File.Exists(path: this.txtPath.Text)
                && this.IsReadOnly == false)
            {
                this.popUpImg.IsOpen = true;
            }
        }

        private void txtPath_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.popUpImg.IsOpen = false;
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                this.SearchImage();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.OpenImg();
        }

        private void OpenImg()
        {
            if (File.Exists(path: this.txtPath.Text))
                System.Diagnostics.Process.Start(this.txtPath.Text);
        }

        private void txtPath_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Control)
                && e.Key == Key.O)
            {
                this.OpenImg();
            }
        }
    }
}
