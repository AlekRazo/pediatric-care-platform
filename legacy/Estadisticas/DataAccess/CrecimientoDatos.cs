using Estadisticas.BusinessLogic;
using Helpers.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.DataAccess
{
    public class CrecimientoDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");
            
        public static List<ParametrosLMS> obtenerParametrosLMS(string indicador, int meses, string sexo)
        {
            List<ParametrosLMS> listaParametros = new List<ParametrosLMS>();
            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [Indicador], [MesEdad], [L], [M], [S], [Medicion] " +
                    "FROM [dbo].[CrecimientoOMS] " +
                    "WHERE [Indicador] = @indicador AND [Sexo] = @sexo AND [MesEdad] <= @edad " +
                    "ORDER BY [MesEdad]", conn);

                cmd.Parameters.Add(new SqlParameter("@indicador", indicador));
                cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
                cmd.Parameters.Add(new SqlParameter("@edad", meses));

                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ParametrosLMS lmsObj = new ParametrosLMS();
                    lmsObj.Indicador = SeguridadDeTipos.GetSafeString(reader, "Indicador");
                    lmsObj.MesEdad = SeguridadDeTipos.GetSafeInt(reader, "MesEdad");
                    lmsObj.L = SeguridadDeTipos.GetSafeDouble(reader, "L");
                    lmsObj.M = SeguridadDeTipos.GetSafeDouble(reader, "M");
                    lmsObj.S = SeguridadDeTipos.GetSafeDouble(reader, "S");
                    lmsObj.Medicion = SeguridadDeTipos.GetSafeString(reader, "Medicion");
                    listaParametros.Add(lmsObj);
                }

                conn.Close();

                return listaParametros;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
