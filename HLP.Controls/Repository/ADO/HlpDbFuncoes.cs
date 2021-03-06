﻿using HLP.Controls.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Repository.ADO
{
    public static class HlpDbFuncoes
    {

        public static DataTable qrySeekRet(string sExpressao)
        {
            DataTable dt = HlpDbFuncoesGeral.QrySeekRet(HlpDbFuncoesGeral.conexao, sExpressao);
            return dt;
        }

        public static SqlDataReader qrySeekReader(string sExpressao)
        {
            SqlDataReader dr = HlpDbFuncoesGeral.QrySeekReader(HlpDbFuncoesGeral.conexao, sExpressao);
            return dr;
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos = "")
        {
            return (qrySeekRet(sTabela, sCampos, String.Empty, String.Empty));
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos, string sWhere)
        {
            return (qrySeekRet(sTabela, sCampos, sWhere, String.Empty));
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos, string sWhere, string sOrdem, List<ListaCampos> lCampos = null)
        {
            if (lCampos != null)
            {
                sCampos = MontaStringCampos(lCampos);
            }
            StringBuilder strExpressao = new StringBuilder();
            strExpressao.Append("SELECT ");
            if (sCampos.Trim() == String.Empty)
                strExpressao.Append("*");
            else
                strExpressao.Append(sCampos);
            strExpressao.Append(" FROM " + sTabela);

            StringBuilder strWhere = new StringBuilder();
            if ((sWhere != null) && (sWhere.Trim() != String.Empty))
                strWhere.Append(sWhere);
            //if ((fExisteCampo(sTabela, "CD_EMPRESA")) &&
            //    (sWhere.ToUpper().IndexOf("CD_EMPRESA") < 0))
            //{
            //    if (strWhere.Length > 0)
            //        strWhere.Append(" AND ");
            //    strWhere.Append("(CD_EMPRESA = '" + Acesso.CD_EMPRESA + "')");
            //}
            if (strWhere.Length > 0)
            {
                strWhere.Insert(0, " WHERE ");
                strExpressao.Append(strWhere.ToString());
            }

            if ((sOrdem != null) && (sOrdem.Trim() != String.Empty))
                strExpressao.Append(" ORDER BY " + sOrdem);

            DataTable dt = HlpDbFuncoesGeral.QrySeekRet(HlpDbFuncoesGeral.conexao, strExpressao.ToString());
            return dt;
        }

        public static string qrySeekValue(string sTabela, string sCampo,
            string sWhere)
        {
            return qrySeekValue(sTabela, sCampo, sWhere, false);
        }

        private static string qrySeekValue(string sTabela, string sCampo, string sWhere, bool bGeraErroSemRegistros)
        {

            DataTable dt = qrySeekRet(sTabela, sCampo, sWhere, null);
            String svalor = null;
            if (dt.Rows.Count > 0)
            {
                DataRow registro = dt.Rows[0];
                //svalor = registro[sCampo].ToString();
                svalor = registro[0].ToString();
            }
            else
            {
                if (bGeraErroSemRegistros)
                    throw new Exception("Não foram encontrados registros válidos!");
            }
            if (svalor == null)
                svalor = String.Empty;
            return svalor;
        }

        public static bool qrySeek(string sTabela, string[] sCampos, string[] sValores)
        {
            StringBuilder strCampos = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            string sCampo;

            for (int i = 0; i < sCampos.Length; i++)
            {
                if (strCampos.Length > 0)
                {
                    strCampos.Append(", ");
                    strWhere.Append(" AND ");
                }
                sCampo = sCampos[i];
                strCampos.Append(sCampo);
                strWhere.Append("(" + sCampo + " = '" + sValores[i].Trim() + "')");
            }

            DataTable dt = qrySeekRet(sTabela, strWhere.ToString(), strCampos.ToString(), null);

            return (dt.Rows.Count > 0);
        }

        public static bool qrySeek(string sExpressao)
        {
            DataTable dt = qrySeekRet(sExpressao);
            return (dt.Rows.Count > 0);
        }

        public static void qrySeekUpdate(string sExpressao)
        {
            HlpDbFuncoesGeral.QrySeekUpdate(HlpDbFuncoesGeral.conexao, sExpressao);
        }

        public static void qrySeekInsert(string sExpressao)
        {
            HlpDbFuncoesGeral.QrySeekInsert(HlpDbFuncoesGeral.conexao, sExpressao);
        }

        public static bool fExisteCampo(string sNomeCampo, string sTabela)
        {
            try
            {
                string sQuery = "SELECT " +
                "RDB$FIELD_NAME CAMPO " +
                "FROM " +
                "RDB$RELATION_FIELDS " +
                "WHERE " +
                " RDB$FIELD_NAME = '{0}' AND" +
                " RDB$RELATION_NAME = '{1}'";

                SqlConnection cx = HlpDbFuncoesGeral.conexao;
                if (cx.State != ConnectionState.Open)
                {
                    cx.Open();
                }
                SqlCommand cmd = new SqlCommand(string.Format(sQuery, sNomeCampo.ToUpper(), sTabela.ToUpper()), cx);
                object iResult = cmd.ExecuteScalar();
                cx.Close();
                if (iResult == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public struct ListaCampos
        {
            public string sCampo { get; set; }
            public string sCoalesce { get; set; }
            public string sAlias { get; set; }
        }

        private static string MontaStringCampos(List<ListaCampos> objlCampos)
        {
            string sCampos = string.Empty;

            foreach (ListaCampos item in objlCampos)
            {
                string Campo = item.sCampo == "" ? "''" : item.sCampo;

                sCampos += (item.sCoalesce == null ? Campo :
                    string.Format("coalesce({0},'{1}')",
                    Campo, item.sCoalesce)) + " " + (item.sAlias == null ? Campo : item.sAlias) + ",";
            }
            sCampos = sCampos.Remove(sCampos.Length - 1, 1);
            return sCampos;
        }


        public static List<RecordsSqlModel> GetRegistros(string xQuery)
        {
            try
            {
                List<RecordsSqlModel> lRet = new List<RecordsSqlModel>();
                lRet = HlpDbFuncoes.qrySeekRet(xQuery).AsEnumerable().Select(c => new RecordsSqlModel
                {
                    display = c["display"].ToString(),
                    id = Convert.ToInt32(c["id"].ToString())
                }).ToList();
                return lRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetRecord(string xNameTable, string xCampo, string xValue, HLP.Controls.Enum.EnumControls.stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {
            string queryGetPkField = string.Format(format: "SELECT COLUMN_NAME FROM " +
        "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
        "where TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')", arg0: xNameTable);

            object nameFieldPk = HlpDbFuncoes.qrySeekValue("INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE", "COLUMN_NAME",
                string.Format("TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')", xNameTable));

            string sWhere = string.Empty;

            switch (stFilterQS)
            {
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.equal:
                    {
                        sWhere = string.Format(format: " {0} = '{1}'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.startWith:
                    {
                        sWhere = string.Format(format: " {0} LIKE'{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case HLP.Controls.Enum.EnumControls.stFilterQuickSearch.contains:
                    {
                        sWhere = string.Format(format: " {0} LIKE'%{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                default:
                    break;
            }

            string query = string.Format(format: "SELECT {0} FROM {1} {2}",
                arg0: nameFieldPk, arg1: xNameTable, arg2: sWhere);

            if (idEmpresa > 0)
            {
                sWhere += string.Format(format: "{0} and idEmpresa = {1}", arg0: query, arg1: idEmpresa);
            }

            string record = HlpDbFuncoes.qrySeekValue(xNameTable, nameFieldPk.ToString(), sWhere);
            int iRet = 0;
            int.TryParse(record, out iRet);
            return iRet;
        }

    }
}
