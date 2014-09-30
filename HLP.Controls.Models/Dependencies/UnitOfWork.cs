using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Dependencies
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Database _dbPrincipal;

        //private DbTransaction _transaction; **comentei esta linha pq não tem sentido uma variável privada e a mesma não ser utilizada em nenhum lugar

        public override Database dbPrincipal
        {
            get
            {
                return _dbPrincipal;
            }
        }

        public UnitOfWork()
        {
            try
            {
                Configuration config =
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                this._dbPrincipal = DatabaseFactory.CreateDatabase(config.ConnectionStrings.ConnectionStrings["dbPrincipal"].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
