using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Dependencies
{
    public class Parameters : IParameterMapper
    {
        private class ParameterDefinition
        {
            public string Name { get; set; }
            public DbType DatabaseType { get; set; }
        }

        private readonly Database db;

        private List<ParameterDefinition> Campos =
            new List<ParameterDefinition>();


        public Parameters(Database db)
        {
            this.db = db;
        }

        public Parameters AddParameter<T>(string parameterName)
        {
            ParameterDefinition parameter = new ParameterDefinition();
            parameter.Name = parameterName;
            parameter.DatabaseType = GetDbType<T>();
            this.Campos.Add(parameter);

            return this;
        }

        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            try
            {
                string sParamName;
                int iPosition = 0;
                foreach (ParameterDefinition campo in this.Campos)
                {
                    sParamName = "@" + campo.Name;
                    if (!command.Parameters.Contains(sParamName))
                    {
                        db.AddInParameter(command, sParamName, campo.DatabaseType);
                    }
                    db.SetParameterValue(command, sParamName, parameterValues[iPosition]);
                    iPosition++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private DbType GetDbType<T>()
        {
            DbType retorno = DbType.Object;
            switch (typeof(T).Name)
            {
                case "Int16":
                    retorno = DbType.Int16;
                    break;

                case "Int32":
                    retorno = DbType.Int32;
                    break;

                case "Int64":
                    retorno = DbType.Int64;
                    break;

                case "String":
                    retorno = DbType.String;
                    break;

                case "Object":
                    retorno = DbType.Object;
                    break;

                case "DateTime":
                    retorno = DbType.DateTime;
                    break;

                case "Decimal":
                    retorno = DbType.Decimal;
                    break;

                case "Double":
                    retorno = DbType.Double;
                    break;

                case "Byte":
                    retorno = DbType.Binary;
                    break;

                case "Boolean":
                    retorno = DbType.Boolean;
                    break;
            }
            return retorno;
        }
    }

}
