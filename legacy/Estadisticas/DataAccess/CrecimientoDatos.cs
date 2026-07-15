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
            
        public static ParametrosLMS obtenerParametrosLMS(string indicador, int meses, string sexo, string medicion)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [L], [M], [S] " +
                    "FROM [dbo].[CrecimientoOMS] " +
                    "WHERE [Indicador] = @indicador AND [Sexo] = @sexo AND [MesEdad] = @edad AND [Medicion] = @valor" +
                    "[idConsulta] = @idConsulta", conn);

                cmd.Parameters.Add(new SqlParameter("@indicador", indicador));
                cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
                cmd.Parameters.Add(new SqlParameter("@edad", meses));
                cmd.Parameters.Add(new SqlParameter("@medicion", medicion));

                ParametrosLMS lmsObj = new ParametrosLMS();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lmsObj.L = SeguridadDeTipos.GetSafeDouble(reader, "l");
                    lmsObj.M = SeguridadDeTipos.GetSafeDouble(reader, "m");
                    lmsObj.S = SeguridadDeTipos.GetSafeDouble(reader, "s");
                }

                conn.Close();

                return lmsObj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
