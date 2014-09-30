using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.ADO
{
    public class HlpDbFuncoesGeral
    {
        public static DataTable QrySeekRet(SqlConnection conexao,
         string sExpressaoSql)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sExpressaoSql, conexao);
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                DataSet ds = new DataSet("dadoshlp");
                da.Fill(ds, "registro");
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }

        public static void QrySeekUpdate(SqlConnection conexao,
        string sExpressaoSql)
        {
            try
            {
                SqlCommand cmdUpDateMoviPend = new SqlCommand();
                cmdUpDateMoviPend.CommandText = sExpressaoSql;
                cmdUpDateMoviPend.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                cmdUpDateMoviPend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static void QrySeekInsert(SqlConnection conexao,
       string sExpressaoSql)
        {
            try
            {
                SqlCommand cmdUpDateMoviPend = new SqlCommand();
                cmdUpDateMoviPend.CommandText = sExpressaoSql;
                cmdUpDateMoviPend.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                cmdUpDateMoviPend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static SqlDataReader QrySeekReader(SqlConnection conexao,
    string sExpressaoSql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sExpressaoSql;
                cmd.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                return Reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }

        public static string MontaStringConexao()
        {
            try
            {
                //StringBuilder sbConexao = new StringBuilder();
                //sbConexao.Append("User =");
                //sbConexao.Append("SYSDBA");
                //sbConexao.Append(";");
                //sbConexao.Append("Password=");
                //sbConexao.Append("masterkey");
                //sbConexao.Append(";");
                //string sPorta = Acesso.PORTA;
                //if (sPorta.Trim() != "")
                //{
                //    sbConexao.Append("Port=" + sPorta + ";");
                //}
                //sbConexao.Append("Database=");
                //string sdatabase = Acesso.CAMINHO_BANCO_DADOS;
                //sbConexao.Append(sdatabase);
                //sbConexao.Append(";");
                //sbConexao.Append("DataSource=");
                //sbConexao.Append(Acesso.NM_SERVIDOR);
                //sbConexao.Append(";");
                //sbConexao.Append("Dialect=3; Charset=NONE;Role=;Connection lifetime=15;Pooling=true; MinPoolSize=0;MaxPoolSize=2000;Packet Size=8192;ServerType=0;");
                //return (string)sbConexao.ToString();
                return HlpDbFuncoesGeral.stringConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static SqlConnection _conexao;
        public static SqlConnection conexao
        {
            get
            {
                //if (HlpDbFuncoesGeral._conexao == null)
                //{
                //    HlpDbFuncoesGeral._conexao = new FbConnection(MontaStringConexao());
                //}
                //return HlpDbFuncoesGeral._conexao;
                return new SqlConnection(MontaStringConexao());
            }
            set
            {
                HlpDbFuncoesGeral._conexao = value;
            }
        }

        public static void NovaConexao()
        {
            HlpDbFuncoesGeral._conexao = null;
        }

        private static string _stringConnection = @"Data Source=HLPSRV\SQLSERVER14;Initial Catalog=BD_MAGNIFICUS_ATUAL;User Id=sa;Password=H029060tSql;pooling=false";
        public static string stringConnection
        {
            get { return _stringConnection; }
            set { _stringConnection = value; }
        }
        

    }
}
