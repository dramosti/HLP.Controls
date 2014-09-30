using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Controls.Base
{
    public class UserControlBase : UserControl, INotifyPropertyChanged
    {
        #region Property Dependecy
        [Category("HLP.Base")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UserControlBase), new PropertyMetadata(""));

        [Category("HLP.Base")]
        public string TextLabel
        {
            get { return (string)GetValue(TextLabelProperty); }
            set { SetValue(TextLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextLabelProperty =
            DependencyProperty.Register("TextLabel", typeof(string), typeof(UserControlBase), new PropertyMetadata("lbl"));

        [Category("HLP.Base")]
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(UserControlBase), new PropertyMetadata(false));

        #endregion

        #region Property
        private Orientation _Orientation = Orientation.Horizontal;

        [Category("HLP.Base")]
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                this.NotifyPropertyChanged("Orientation");
                this.Atualize();
            }
        }

        private double _WidthComp1Parent = 0;
        [Category("HLP.Base")]
        [Browsable(browsable: false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double WidthComp1Parent
        {
            get { return _WidthComp1Parent; }
            set { _WidthComp1Parent = value; this.NotifyPropertyChanged("WidthComp1Parent"); }
        }

        private double _WidthComp1 = 0;
        [Category("HLP.Base")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double WidthComp1
        {
            get { return _WidthComp1; }
            set { _WidthComp1 = value; this.NotifyPropertyChanged("WidthComp1"); }
        }

        private double _WidthComp2 = 0;
        [Category("HLP.Base")]
        [Browsable(browsable: false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double WidthComp2
        {
            get { return _WidthComp2; }
            set { _WidthComp2 = value - 5; this.NotifyPropertyChanged("WidthComp2"); }
        }

        public enum stWidthComp2 { Codigo, Full };
        private stWidthComp2 _WidthStatus = stWidthComp2.Codigo;
        [Category("HLP.Base")]
        public stWidthComp2 WidthStatus
        {
            get { return _WidthStatus; }
            set
            {
                _WidthStatus = value; this.NotifyPropertyChanged("WidthStatus");
                this.Atualize();
            }
        }

        #endregion

        #region Override
        //public override void EndInit()
        //{
        //    base.EndInit();
        //    this.Atualize();
        //}

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            this.Atualize();
        }
        #endregion

        #region Method
        private void Atualize()
        {
            switch (this.WidthStatus)
            {
                case stWidthComp2.Codigo:
                    this.WidthComp2 = 90;
                    break;
                case stWidthComp2.Full:
                    {
                        if (this._Orientation == System.Windows.Controls.Orientation.Vertical)
                        {
                            this.WidthComp1 = this.Width;
                            this.WidthComp2 = this.Width;
                        }
                        else
                        {
                            this.WidthComp1 = this.WidthComp1Parent;
                            this.WidthComp2 = this.Width - this.WidthComp1Parent;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
