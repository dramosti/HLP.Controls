using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Dependencies
{
    public abstract class UnitOfWorkBase : IDisposable
    {
        public abstract Microsoft.Practices.EnterpriseLibrary.Data.Database dbPrincipal { get; }

        public DbTransaction dbTransaction
        {
            get
            {
                return _dbTransaction;
            }
        }

        private DbTransaction _dbTransaction;
        private DbConnection _transactConnection;

        public UnitOfWorkBase()
        {
        }

        public void AddParameterToCommand(DbCommand cmd, string parameterName, DbType type, object value)
        {
            DbParameter param = cmd.CreateParameter();

            param.ParameterName = parameterName;
            param.DbType = type;
            param.Value = value;

            cmd.Parameters.Add(param);
        }

        public void BeginTransaction()
        {
            if (this._dbTransaction != null ||
                this._transactConnection != null)
            {
                throw new Exception("Já existe uma transação aberta no banco de dados!");
            }

            this._transactConnection = this.dbPrincipal.CreateConnection();
            this._transactConnection.Open();
            this._dbTransaction = this._transactConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this._dbTransaction == null ||
                this._transactConnection == null)
            {
                throw new Exception("Não existe uma transação aberta no banco de dados!");
            }

            this._dbTransaction.Commit();
            this._dbTransaction = null;

            this._transactConnection.Close();
            this._transactConnection = null;
        }

        public void RollBackTransaction()
        {
            if (this._dbTransaction != null)
            {
                this._dbTransaction.Rollback();
                this._dbTransaction = null;

                this._transactConnection.Close();
                this._transactConnection = null;
            }
        }

        public void Dispose()
        {
            if (this._dbTransaction != null)
            {
                this._dbTransaction.Rollback();
                this._dbTransaction = null;
            }

            if (this._transactConnection != null)
            {
                this._transactConnection.Close();
                this._transactConnection = null;
            }
        }

        /// <summary>
        /// Verifica se uma Tabela ou uma View existe na base de dados
        /// </summary>
        /// <param name="nm_Table"></param>
        /// <returns></returns>
        public bool TableExistis(string nm_Table)
        {
            int iCount = (int)this.dbPrincipal.ExecuteScalar(
              "dbo.Proc_ExistsView", nm_Table);

            if (iCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// Verifica se uma Tabela ou uma View existe na base de dados
        /// </summary>
        /// <param name="nm_Table"></param>
        /// <returns></returns>
        public bool ViewExistis(string nm_View)
        {
            int iCount = (int)this.dbPrincipal.ExecuteScalar(
              "dbo.Proc_ExistsView", nm_View);

            if (iCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool FunctionExistis(string nm_Function)
        {
            int iCount = (int)this.dbPrincipal.ExecuteScalar(
              "dbo.Proc_ExistisFunction", nm_Function);

            if (iCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica se uma coluna existe na Tabela/View
        /// </summary>
        /// <param name="nm_Table"></param>
        /// <param name="nm_Coluna"></param>
        /// <returns></returns>
        public bool ColunaExistis(string nm_Table, string nm_Coluna)
        {
            int iCount = (int)this.dbPrincipal.ExecuteScalar(
               "dbo.Proc_Verifica_Coluna_Existe", nm_Table, nm_Coluna);

            if (iCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
