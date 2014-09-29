using HLP.Controls.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Controls.Models.Repositories.Implementation
{
    public class HlpPesquisaPadraoRepository : IHlpPesquisaPadraoRepository
    {
        public object GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            try
            {
                if (sWhere != "")
                {
                    if (sSelect.ToUpper().Contains("WHERE"))
                    {
                        sSelect += " and " + sWhere;
                    }
                    else
                    {
                        sSelect += " where " + sWhere;
                    }
                }
                if (sSelect.Contains("DISPLAY") && bOrdena)
                {
                    sSelect += " ORDER BY DISPLAY";
                }
                DbCommand cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sSelect);


                IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(cmd);

                DataTable dt = new DataTable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                if (addDefault)
                {
                    dt.Rows.Add(0, "...");
                }
                while (reader.Read())
                {
                    object[] array = new object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader[i].ToString() != "")
                        {
                            array[i] = reader[i].ToString().ToUpper();
                        }
                        else
                        {
                            if (reader[i].GetType() == typeof(string) || reader[i].GetType() == typeof(char))
                            {
                                array[i] = reader[i].ToString().ToUpper();
                            }
                        }
                    }
                    dt.Rows.Add(array);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
