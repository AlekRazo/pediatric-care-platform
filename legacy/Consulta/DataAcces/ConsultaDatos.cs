using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas.BusinessLogic;
using System.Data.SqlClient;

namespace Consultas.DataAcces
{
    class ConsultaDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static int GuardarDatosDeConsulta(Consulta objConsulta)
        {
            try
            {
                int idPaciente = objConsulta.IdPaciente;
                DateTime fechaConsulta = objConsulta.FechaConsulta;
                string motivo = objConsulta.Motivo;
                string responsabilidad = objConsulta.Responsabilidad;
                int frecuenciaCardiaca = objConsulta.FrecuenciaCardiaca;
                int frecuenciaRespiratoria  = objConsulta.FrecuenciaRespiratoria;
                string tensionArterial = objConsulta.TensionArterial;
                double temperatura = objConsulta.Temperatura;
                double peso = objConsulta.Peso;
                double talla = objConsulta.Talla;
                string diagnostico = objConsulta.Diagnostico;

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Consulta VALUES (@idPaciente, @fecha, @motivo, @responsabilidad, @frecuenciaCardiaca, @frecuenciaRespiratoria, @tensionArterial, @temperatura, @peso, @talla, @diagnostico)", conn);

                cmd.Parameters.Add(new SqlParameter("@idPaciente", idPaciente));
                cmd.Parameters.Add(new SqlParameter("@fecha", fechaConsulta));
                cmd.Parameters.Add(new SqlParameter("@motivo", motivo));
                cmd.Parameters.Add(new SqlParameter("@responsabilidad", responsabilidad));
                cmd.Parameters.Add(new SqlParameter("@frecuenciaCardiaca", frecuenciaCardiaca));
                cmd.Parameters.Add(new SqlParameter("@frecuenciaRespiratoria", frecuenciaRespiratoria));
                cmd.Parameters.Add(new SqlParameter("@tensionArterial", tensionArterial));
                cmd.Parameters.Add(new SqlParameter("@temperatura", temperatura));
                cmd.Parameters.Add(new SqlParameter("@peso", peso));
                cmd.Parameters.Add(new SqlParameter("@talla", talla));
                cmd.Parameters.Add(new SqlParameter("@diagnostico", diagnostico));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
