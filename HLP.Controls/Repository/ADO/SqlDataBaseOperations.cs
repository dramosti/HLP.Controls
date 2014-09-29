using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Controls.Repository.ADO
{
    public class SqlDataBaseOperations
    {

        private string xConnectionString;

        public SqlDataBaseOperations()
        {
            xConnectionString = @"Data Source=HLPSRV\SQLSERVER14;Initial Catalog=BD_MAGNIFICUS_ATUAL;User Id=sa;Password=H029060tSql;pooling=false";
        }

        public DataSet GetData(string xQuery)
        {
            using (var conn = new SqlConnection(connectionString: xConnectionString))
            {
                SqlDataAdapter comm = new SqlDataAdapter(selectCommandText: xQuery,
                    selectConnection: conn);

                DataSet ds = new DataSet();
                comm.Fill(dataSet: ds);

                return ds;
            }
        }
    }
}
