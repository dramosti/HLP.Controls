using HLP.Controls.Repository.ADO;
using HLP.Controls.Repository.Model;
using HLP.Controls.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for HlpTreeView.xaml
    /// </summary>
    public partial class HlpTreeView : UserControl
    {
        BackgroundWorker bwTreeView;
        OperacoesDataBaseService objService;

        public HlpTreeView()
        {
            InitializeComponent();

            bwTreeView = new BackgroundWorker();
            bwTreeView.WorkerSupportsCancellation = true;
            bwTreeView.DoWork += bwTreeView_DoWork;
            bwTreeView.RunWorkerCompleted += bwTreeView_RunWorkerCompleted;

            this.lQuerySql = new ObservableCollection<querySql>();
        }

        private ObservableCollection<querySql> _lQuerySql;

        public ObservableCollection<querySql> lQuerySql
        {
            get { return _lQuerySql; }
            set { _lQuerySql = value; }
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

        private string _fieldsDisplay;

        public string fieldsDisplay
        {
            get { return _fieldsDisplay; }
            set { _fieldsDisplay = value; }
        }

        private string _xTable;

        public string xTable
        {
            get { return _xTable; }
            set { _xTable = value; }
        }

        private treeviewModel _nodeBase;

        public treeviewModel nodeBase
        {
            get { return _nodeBase; }
            set { _nodeBase = value; }
        }




        public Nullable<int> selectedId
        {
            get { return (Nullable<int>)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(Nullable<int>), typeof(HlpTreeView), new PropertyMetadata(null));



        public void BeginLoad()
        {
            if (objService == null)
            {
                objService = new OperacoesDataBaseService();
                this.nodeBase = new treeviewModel();
            }

            this.bwTreeView.RunWorkerAsync();
        }

        void bwTreeView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void bwTreeView_DoWork(object sender, DoWorkEventArgs e)
        {
            string xFields = string.Empty;
            string xQuery = string.Empty;
            int currentId = this.selectedId ?? 0;

            foreach (querySql qrSql in this.lQuerySql)
            {
                if (string.IsNullOrEmpty(value: xFields))
                {
                    foreach (string item in fieldsDisplay.Split(separator: ';'))
                    {
                        xFields += string.IsNullOrEmpty(value: item) ?
                            xFields : item == fieldsDisplay.Split(separator: ';').Last()
                            ? item : string.Format(format: "{0}, ' - '");
                    }

                    xQuery = string.Format(format: "select {0} as id, {1} as display, {3} as fieldHierarquia from {2} "
                        + " where {3} = {4}", args: new object[]
                        {
                            this.propPk,
                            xFields,
                            this.xTable,
                            this.propHierarquia,
                            currentId
                        });

                    var retBD = HlpDbFuncoes.qrySeekRet(sExpressao: xQuery);

                    currentId = (retBD.AsEnumerable().FirstOrDefault()[columnName: "fieldHierarquia"] as int?)
                        ?? 0;
                }

                xFields = string.Empty;
            }
        }
    }

    public struct querySql
    {
        private string _propPk;

        public string propPk
        {
            get { return _propPk; }
            set { _propPk = value; }
        }

        private string _propHierarquia;

        public string propHierarquia
        {
            get { return _propHierarquia; }
            set { _propHierarquia = value; }
        }


        private string _fieldsDisplay;

        public string fieldsDisplay
        {
            get { return _fieldsDisplay; }
            set { _fieldsDisplay = value; }
        }

        private string _xTable;

        public string xTable
        {
            get { return _xTable; }
            set { _xTable = value; }
        }

    }
}
