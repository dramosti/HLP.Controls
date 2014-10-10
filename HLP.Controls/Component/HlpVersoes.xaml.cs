using HLP.Controls.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
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
    /// Interaction logic for HlpVersoes.xaml
    /// </summary>
    public partial class HlpVersoes : UserControl
    {
        BackgroundWorker bwQuery;
        OperacoesDataBaseService objService;
        private Style defStyleSeparator;
        private Style defStyleButton;

        public HlpVersoes()
        {
            InitializeComponent();
            bwQuery = new BackgroundWorker();
            bwQuery.WorkerSupportsCancellation = true;
            bwQuery.DoWork += bwQuery_DoWork;
            bwQuery.RunWorkerCompleted += bwQuery_RunWorkerCompleted;
            defStyleSeparator = this.FindResource(resourceKey: "btn_Separador") as Style;
            defStyleButton = this.FindResource(resourceKey: "btn_Hierarquia") as Style;
        }

        void bwQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.stk.Children.Clear();
            foreach (int id in e.Result as List<int>)
            {
                if (this.stk.Children.Count > 0)
                    this.stk.Children.Add(element: new Button
                    {
                        Style = this.styleSeparator == null ? this.defStyleSeparator : this.styleSeparator
                    });

                this.stk.Children.Add(element: new Button
                {
                    Content = id,
                    Style = this.styleBtnHierarquia == null ? this.defStyleButton : this.styleBtnHierarquia
                });
            }
        }

        void bwQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> lHierarquias = new List<int>();
            string xQuery = string.Empty;
            int? currentValue = e.Argument as int?;

            var recBase = objService.qrySeekRet(sExpressao:
                string.Format(format: "select {0} as _value, {1} as _valueHier from {2} where {0} = {3}",
                    args: new object[]{
                    this.propPk,
                    this.propHierarquia,
                    this.propTable,
                    currentValue
                    }));

            if (recBase != null)
            {
                lHierarquias.Add(item: (int)currentValue);

                currentValue = recBase.AsEnumerable().FirstOrDefault()[columnName: "_valueHier"] as int?;

                while (true)
                {
                    if (currentValue == null)
                        break;

                    xQuery = string.Format(format: "select {0} as _value, {1} as _valueHier from {2} where {0} = {3}",
                        args: new object[]{
                    this.propPk,
                    this.propHierarquia,
                    this.propTable,
                    currentValue
                    });

                    var ret = objService.qrySeekRet(sExpressao: xQuery);

                    if (ret == null)
                        break;
                    else
                    {
                        if (ret.AsEnumerable().FirstOrDefault() == null)
                            break;
                        else
                        {
                            currentValue = ret.AsEnumerable().FirstOrDefault()[columnName: "_valueHier"] as int?;

                            lHierarquias.Insert(index: 0, item: (int)ret.AsEnumerable().FirstOrDefault()[columnName: "_value"]);
                        }
                    }
                }

                currentValue = e.Argument as int?;

                while (true)
                {
                    xQuery = string.Format(format: "select {0} as _value from {2} where {1} = {3}",
                        args: new object[]{
                    this.propPk,
                    this.propHierarquia,
                    this.propTable,
                    currentValue
                    });

                    var ret = objService.qrySeekRet(sExpressao: xQuery);

                    if (ret == null)
                        break;
                    else
                    {
                        if (ret.AsEnumerable().FirstOrDefault() == null)
                            break;
                        else
                        {
                            currentValue = ret.AsEnumerable().FirstOrDefault()[columnName: "_value"] as int?;

                            lHierarquias.Add(item: (int)ret.AsEnumerable().FirstOrDefault()[columnName: "_value"]);

                            if (currentValue == null)
                                break;
                        }
                    }
                }
            }
            e.Result = lHierarquias;
        }

        public void BeginLoad()
        {
            if (objService == null)
            {
                objService = new OperacoesDataBaseService();
            }

            this.bwQuery.RunWorkerAsync(argument: this.selectedId);
        }

        private Style _styleSeparator;

        public Style styleSeparator
        {
            get { return _styleSeparator; }
            set { _styleSeparator = value; }
        }

        private Style _styleBtnHierarquia;

        public Style styleBtnHierarquia
        {
            get { return _styleBtnHierarquia; }
            set { _styleBtnHierarquia = value; }
        }

        private string _propHierarquia;

        public string propHierarquia
        {
            get { return _propHierarquia; }
            set { _propHierarquia = value; }
        }

        private string _propPk;

        public string propPk
        {
            get { return _propPk; }
            set { _propPk = value; }
        }

        private string _propTable;

        public string propTable
        {
            get { return _propTable; }
            set { _propTable = value; }
        }

        public int? selectedId
        {
            get { return (int?)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int?), typeof(HlpVersoes), new PropertyMetadata(
                defaultValue: null, propertyChangedCallback: new PropertyChangedCallback(SelectedIdChanged)));

        public static void SelectedIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                (d as HlpVersoes).BeginLoad();
            }
        }

        private double _maxScrollWidth;

        public double maxScrollWidth
        {
            get { return _maxScrollWidth; }
            set
            {
                this.scroll.Width = _maxScrollWidth = value;
            }
        }
    }
}
