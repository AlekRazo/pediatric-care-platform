using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Helpers
{
    public class SeguridadDeTipos
    {
        public static int GetSafeInt(SqlDataReader reader, string columnName, int valorPorDefecto = 0)
        {
            object valor = reader[columnName];
            return valor == DBNull.Value ? valorPorDefecto : Convert.ToInt32(valor);
        }

        public static bool GetSafeBool(SqlDataReader reader, string columnName, bool valorPorDefecto = false)
        {
            object valor = reader[columnName];
            return valor == DBNull.Value ? valorPorDefecto : Convert.ToBoolean(valor);
        }

        public static string GetSafeString(SqlDataReader reader, string columnName, string valorPorDefecto = "")
        {
            object valor = reader[columnName];
            return valor == DBNull.Value ? valorPorDefecto : valor.ToString();
        }

        public static double GetSafeDouble(SqlDataReader reader, string columnName, double valorPorDefecto = 0.0)
        {
            object valor = reader[columnName];
            return valor == DBNull.Value ? valorPorDefecto : Convert.ToDouble(valor);
        }

        public static DateTime GetSafeDateTime(SqlDataReader reader, string columnName, DateTime valorPorDefecto = default)
        {
            object valor = reader[columnName];
            return valor == DBNull.Value ? valorPorDefecto : Convert.ToDateTime(valor);
        }
    }
}
