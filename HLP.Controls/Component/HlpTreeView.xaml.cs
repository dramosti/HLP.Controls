using HLP.Controls.Base;
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
            this.lSelectSearchChields = new ObservableCollection<string>();
            this.lSelectSearchParent = new ObservableCollection<string>();

            bwTreeView = new BackgroundWorker();
            bwTreeView.WorkerSupportsCancellation = true;
            bwTreeView.DoWork += bwTreeView_DoWork;
            bwTreeView.RunWorkerCompleted += bwTreeView_RunWorkerCompleted;
        }

        private ObservableCollection<string> _lSelectSearchParent;

        public ObservableCollection<string> lSelectSearchParent
        {
            get { return _lSelectSearchParent; }
            set { _lSelectSearchParent = value; }
        }

        private ObservableCollection<string> _lSelectSearchChields;

        public ObservableCollection<string> lSelectSearchChields
        {
            get { return _lSelectSearchChields; }
            set { _lSelectSearchChields = value; }
        }



        public string labelText
        {
            get { return (string)GetValue(labelTextProperty); }
            set { SetValue(labelTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for labelText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty labelTextProperty =
            DependencyProperty.Register("labelText", typeof(string), typeof(HlpTreeView), new PropertyMetadata(null));



        private string _selectSearchNodeBase;

        public string selectSearchNodeBase
        {
            get { return _selectSearchNodeBase; }
            set { _selectSearchNodeBase = value; }
        }

        public Nullable<int> selectedId
        {
            get { return (Nullable<int>)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(Nullable<int>), typeof(HlpTreeView), new PropertyMetadata(defaultValue: null,
                propertyChangedCallback: new PropertyChangedCallback(SelectIdChanged)));

        public static void SelectIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue != null)
            {
                (d as HlpTreeView).BeginLoad();
            }
            else
                (d as HlpTreeView).stOperacaoTreeView = TipoOperacaoTreeView.enumLivre;
        }

        public ObservableCollection<treeviewModel> items
        {
            get { return (ObservableCollection<treeviewModel>)GetValue(itemsProperty); }
            set { SetValue(itemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemsProperty =
            DependencyProperty.Register("items", typeof(ObservableCollection<treeviewModel>), typeof(HlpTreeView), new PropertyMetadata(null));

        public DataTemplate templateItems
        {
            get { return (DataTemplate)GetValue(templateItemsProperty); }
            set { SetValue(templateItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for templateItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty templateItemsProperty =
            DependencyProperty.Register("templateItems", typeof(DataTemplate), typeof(HlpTreeView), new PropertyMetadata(null));



        public TipoOperacaoTreeView stOperacaoTreeView
        {
            get { return (TipoOperacaoTreeView)GetValue(stOperacaoTreeViewProperty); }
            set { SetValue(stOperacaoTreeViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for stOperacaoTreeView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty stOperacaoTreeViewProperty =
            DependencyProperty.Register("stOperacaoTreeView", typeof(TipoOperacaoTreeView), typeof(HlpTreeView), new PropertyMetadata(TipoOperacaoTreeView.enumLivre));



        public void BeginLoad()
        {
            if (objService == null)
            {
                objService = new OperacoesDataBaseService();
            }

            this.stOperacaoTreeView = TipoOperacaoTreeView.enumCarregando;

            if (bwTreeView.IsBusy)
            {
                throw new Exception(message: "Já está sendo carregado uma hierarquia, por favor, tente mais tarde!");
            }
            else
                this.bwTreeView.RunWorkerAsync(argument: this.selectedId);
        }

        void bwTreeView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.items = new ObservableCollection<treeviewModel>(collection:
                e.Result as IEnumerable<treeviewModel>);

            this.stOperacaoTreeView = TipoOperacaoTreeView.enumFinalizado;
        }

        void bwTreeView_DoWork(object sender, DoWorkEventArgs e)
        {
            List<treeviewModel> lResult = new List<treeviewModel>();
            treeviewModel nodeBase = null;
            treeviewModel nodeAux = null;

            var resultBase = objService.qrySeekRet(sExpressao: string.Format(format: this.selectSearchNodeBase,
                arg0: e.Argument));

            if (resultBase != null)
            {
                nodeBase = resultBase.AsEnumerable().Select(
                    i => new treeviewModel
                    {
                        idPk = (i[columnName: "idPk"] as int?) ?? 0,
                        idFk = resultBase.Columns[name: "idFk"] != null ? (i[columnName: "idFk"] as int?) ?? 0 : 0,
                        xDisplay = i[columnName: "xDisplay"].ToString()
                    }).FirstOrDefault();

                #region Montagem de treeview em busca de Parents (para cima)
                if (this.lSelectSearchParent.Count() > 0)
                {
                    object _arg0 = nodeBase.idFk;

                    foreach (string qr in this.lSelectSearchParent)
                    {
                        var result =
                     objService.qrySeekRet(sExpressao:
                        string.Format(format: qr, arg0: _arg0));

                        if (result != null)
                        {
                            nodeAux = result.AsEnumerable()
                                .Select(
                                i => new treeviewModel
                                {
                                    idPk = (i[columnName: "idPk"] as int?) ?? 0,
                                    idFk = result.Columns[name: "idFk"] != null ? (i[columnName: "idFk"] as int?) ?? 0 : 0,
                                    xDisplay = i[columnName: "xDisplay"].ToString()
                                }).FirstOrDefault();

                            nodeAux.lItens.Add(item: nodeBase);
                            nodeBase = nodeAux;
                        }

                        _arg0 = nodeAux.idFk;
                    }
                    lResult.Add(item: nodeAux);
                }
                #endregion

                #region Montagem de treeview em busca de Chields (para baixo)
                if (this.lSelectSearchChields.Count() > 0)
                {
                    object _arg0 = e.Argument;

                    var result = objService.qrySeekRet(sExpressao:
                        string.Format(format: this.lSelectSearchChields.FirstOrDefault(), arg0: _arg0));

                    nodeBase.lItens =
                        new ObservableCollection<treeviewModel>(collection:
                            result.AsEnumerable().Select(i => new treeviewModel
                            {
                                idPk = (i[columnName: "idPk"] as int?) ?? 0,
                                xDisplay = i[columnName: "xDisplay"].ToString(),
                                idFk = result.Columns[name: "idFk"] != null ? (i[columnName: "idFk"] as int?) ?? 0 : 0
                            }).ToList());

                    lResult.Add(item: nodeBase);

                    if (this.lSelectSearchChields.Count > 1)
                        BuildChieldTreeView(lItems: nodeBase.lItens, countInteration: 0, lQuerys: this.lSelectSearchChields);
                }
                #endregion

                e.Result = lResult;
            }
        }

        void BuildChieldTreeView(IEnumerable<treeviewModel> lItems, int countInteration, IEnumerable<string> lQuerys)
        {
            countInteration += 1;

            foreach (treeviewModel nd in lItems)
            {
                var result = objService.qrySeekRet(sExpressao:
                        string.Format(format: this.lSelectSearchChields[index: countInteration], arg0: nd.idPk));

                if (result != null)
                {
                    nd.lItens = new ObservableCollection<treeviewModel>(collection:
                            result.AsEnumerable().Select(i => new treeviewModel
                            {
                                idPk = (i[columnName: "idPk"] as int?) ?? 0,
                                xDisplay = i[columnName: "xDisplay"].ToString(),
                                idFk = result.Columns[name: "idFk"] != null ? (i[columnName: "idFk"] as int?) ?? 0 : 0
                            }).ToList());

                    if ((countInteration + 1) < lQuerys.Count())
                        this.BuildChieldTreeView(lItems: nd.lItens, countInteration: countInteration, lQuerys: lQuerys);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.BeginLoad();
        }

    }
}
