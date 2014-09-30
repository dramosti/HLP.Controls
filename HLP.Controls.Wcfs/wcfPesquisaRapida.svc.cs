using HLP.Controls.Models.Dependencies;
using HLP.Controls.Models.Repositories.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Controls.Wcfs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcfPesquisaRapida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcfPesquisaRapida.svc or wcfPesquisaRapida.svc.cs at the Solution Explorer and start debugging.
    public class wcfPesquisaRapida : IwcfPesquisaRapida
    {
        [Inject]
        public IHlpPesquisaRapidaRepository iHlpPesquisaRapidaRepository { get; set; }

        public wcfPesquisaRapida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
        }

        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            try
            {
                return iHlpPesquisaRapidaRepository.GetValorDisplay(_TableView, _Items, _FieldPesquisa, idEmpresa, _iValorPesquisa);
            }
            catch (Exception ex)
            {
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
