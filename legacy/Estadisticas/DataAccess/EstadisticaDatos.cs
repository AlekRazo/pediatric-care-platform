using Estadisticas.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.DataAccess
{
    class EstadisticaDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static LMS obtenerParametrosPercentil(string indicador, int meses, string sexo, double valor)
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
                cmd.Parameters.Add(new SqlParameter("@medicion", valor));

                LMS lmsObj = new LMS();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lmsObj.L = double.Parse(reader["l"].ToString());
                    lmsObj.M = double.Parse(reader["m"].ToString());
                    lmsObj.S = double.Parse(reader["s"].ToString());
                }

                conn.Close();

                return lmsObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
