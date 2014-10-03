using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for HlpStatus.xaml
    /// </summary>
    public partial class HlpStatus : UserControl
    {
        private Style defStyleEnabled;
        private Style defStyleDisabled;
        private Style defStyleOptional;

        public HlpStatus()
        {
            InitializeComponent();
            this.lOptionalStatus = new ObservableCollection<byte>();
            this.lStatus = new ObservableCollection<string>();
            this.lStatus.CollectionChanged += lStatus_CollectionChanged;

            defStyleEnabled = this.FindResource(resourceKey: "statusEnabled") as Style;
            defStyleDisabled = this.FindResource(resourceKey: "statusDisabled") as Style;
            defStyleOptional = this.FindResource(resourceKey: "statusOptional") as Style;
        }

        void lStatus_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.NewItems != null)
            {
                Button btnChildren = null;

                foreach (string st in e.NewItems)
                {
                    this.mainGrid.ColumnDefinitions.Add(
                        value: new ColumnDefinition
                        {
                            Width = new GridLength(value: 15, type: GridUnitType.Pixel)
                        });

                    this.mainGrid.ColumnDefinitions.Add(
                        value: new ColumnDefinition
                        {
                            Width = new GridLength(value: 45, type: GridUnitType.Pixel)
                        });

                    btnChildren = new Button
                    {
                        Content = st,
                        Width = 45,
                        Height = 45
                    };

                    this.mainGrid.Children.Add(element: btnChildren);

                    Grid.SetRow(element: btnChildren, value: 0);
                    Grid.SetRowSpan(element: btnChildren, value: 3);
                    Grid.SetColumn(element: btnChildren,
                        value: this.mainGrid.ColumnDefinitions.Count - 1);
                    Grid.SetColumnSpan(element: this.ucLine2, value: this.mainGrid.ColumnDefinitions.Count);
                }
            }
        }

        private ObservableCollection<string> _lStatus;

        public ObservableCollection<string> lStatus
        {
            get { return _lStatus; }
            set { _lStatus = value; }
        }

        public byte? selectStatus
        {
            get { return (byte?)GetValue(selectStatusProperty); }
            set { SetValue(selectStatusProperty, value); }
        }

        private ObservableCollection<byte> _lOptionalStatus;

        public ObservableCollection<byte> lOptionalStatus
        {
            get { return _lOptionalStatus; }
            set { _lOptionalStatus = value; }
        }


        // Using a DependencyProperty as the backing store for selectStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectStatusProperty =
            DependencyProperty.Register("selectStatus", typeof(byte?), typeof(HlpStatus),
            new PropertyMetadata(defaultValue: null, propertyChangedCallback: new PropertyChangedCallback(SelectStatusChanged)));

        public static void SelectStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            byte selectedStatus = (byte)0;
            byte cont = 0;

            if (args.NewValue != null)
            {
                selectedStatus = Convert.ToByte(value: args.NewValue);
            }

            foreach (UIElement _st in (d as HlpStatus).mainGrid.Children)
            {
                if (_st.GetType() == typeof(Button))
                {
                    if (cont <= selectedStatus)
                    {
                        if ((d as HlpStatus).lOptionalStatus.Contains(item: cont))
                        {
                            (_st as Button).Style = (d as HlpStatus).stEnabledStyle != null ?
                                (d as HlpStatus).stEnabledStyle :
                                (d as HlpStatus).defStyleEnabled != null ?
                                (d as HlpStatus).defStyleOptional : (d as HlpStatus).defStyleEnabled;
                        }
                        else
                        {
                            (_st as Button).Style = (d as HlpStatus).stEnabledStyle != null ?
                                (d as HlpStatus).stEnabledStyle : (d as HlpStatus).defStyleEnabled;
                        }

                        if ((d as HlpStatus).ucLine.Visibility != Visibility.Visible)
                            (d as HlpStatus).ucLine.Visibility = Visibility.Visible;

                        Grid.SetColumnSpan(element: (d as HlpStatus).ucLine, value: (cont + 1) * 2);
                    }
                    else
                    {
                        (_st as Button).Style = (d as HlpStatus).stDisabledStyle != null ?
                            (d as HlpStatus).stDisabledStyle : (d as HlpStatus).defStyleDisabled;
                    }
                    cont++;
                }

            }
        }

        private Style _stEnabledStyle;

        public Style stEnabledStyle
        {
            get { return _stEnabledStyle; }
            set { _stEnabledStyle = value; }
        }

        private Style _stDisabledStyle;

        public Style stDisabledStyle
        {
            get { return _stDisabledStyle; }
            set { _stDisabledStyle = value; }
        }

        private Style _stOptionalStyle;

        public Style stOptionalStyle
        {
            get { return _stOptionalStyle; }
            set { _stOptionalStyle = value; }
        }

    }
}
