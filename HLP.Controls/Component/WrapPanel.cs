using HLP.Controls.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Controls.Component
{
    public class WrapPanel : System.Windows.Controls.WrapPanel, INotifyPropertyChanged
    {        

        #region Property
        private double _WidthComp1 = 0;
        public double WidthComp1
        {
            get { return _WidthComp1; }
            set { _WidthComp1 = value; this.NotifyPropertyChanged("WidthComp1"); SetAllComponentsParameter(); }
        }
        #endregion

        #region Override
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            if (visualAdded != null)
                SetParameter(visualAdded as Control);
        }
        public override void EndInit()
        {
            base.EndInit();
            SetAllComponentsParameter();
        }
        #endregion

        #region Methods
        void SetAllComponentsParameter()
        {
            foreach (var ctr in this.Children)
            {
                SetParameter(ctr as Control);
            }
        }
        void SetParameter(Control visualAdded)
        {

            if (visualAdded.GetType().BaseType == typeof(UserControlBase))
            {

                if ((visualAdded as UserControlBase).Orientation == System.Windows.Controls.Orientation.Vertical)
                    (visualAdded as UserControlBase).WidthComp1 = this.Width;
                else
                {
                    (visualAdded as UserControlBase).WidthComp1 = this.WidthComp1;
                }
                (visualAdded as UserControlBase).Width = this.Width;
                (visualAdded as UserControlBase).WidthComp1Parent = this.WidthComp1;
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
