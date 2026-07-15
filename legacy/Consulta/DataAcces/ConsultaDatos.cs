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

        public static int guardarDatosDeConsulta(Consulta objConsulta)
        {
            try
            {
                int idPaciente = objConsulta.IdPaciente;
                DateTime fechaConsulta = objConsulta.FechaConsulta;
                string motivo = objConsulta.Motivo;
                string responsabilidad = objConsulta.Responsabilidad;
                int frecuenciaCardiaca = objConsulta.FrecuenciaCardiaca;
                int frecuenciaRespiratoria = objConsulta.FrecuenciaRespiratoria;
                string tensionArterial = objConsulta.TensionArterial;
                double temperatura = objConsulta.Temperatura;
                double peso = objConsulta.Peso;
                double talla = objConsulta.Talla;
                string diagnostico = objConsulta.Diagnostico;

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Consulta ([idPaciente],[FechaConsulta],[Motivo],[Responsabilidad],[FrecCardiaca],[FrecRespiratoria],[TensionArterial],[Temperatura],[Peso],[Talla],[Diagnostico]) OUTPUT INSERTED.idConsulta VALUES (@idPaciente, @fecha, @motivo, @responsabilidad, @frecuenciaCardiaca, @frecuenciaRespiratoria, @tensionArterial, @temperatura, @peso, @talla, @diagnostico)", conn);

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

                int idConsulta = 0;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idConsulta = int.Parse(reader["idConsulta"].ToString());
                }

                conn.Close();

                return idConsulta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Consulta obtenerConsulta(int idConsulta)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [idConsulta]" +
                    ",[idPaciente]" +
                    ",[FechaConsulta]" +
                    ",[Motivo]" +
                    ",[Responsabilidad]" +
                    ",[FrecCardiaca]" +
                    ",[FrecRespiratoria]" +
                    ",[TensionArterial]" +
                    ",[Temperatura]" +
                    ",[Peso]" +
                    ",[Talla]" +
                    ",[Diagnostico] " +
                    "FROM Consulta WHERE " +
                    "[idConsulta] = @idConsulta", conn);

                cmd.Parameters.Add(new SqlParameter("@idConsulta", idConsulta));

                Consulta consulta = new Consulta();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    consulta.IdConsulta = int.Parse(reader["idConsulta"].ToString());
                    consulta.IdPaciente = int.Parse(reader["idPaciente"].ToString());
                    consulta.FechaConsulta = DateTime.Parse(reader["FechaConsulta"].ToString());
                    consulta.Motivo = reader["Motivo"].ToString();
                    consulta.Responsabilidad = reader["Responsabilidad"].ToString();
                    consulta.FrecuenciaCardiaca = int.Parse(reader["FrecCardiaca"].ToString());
                    consulta.FrecuenciaRespiratoria = int.Parse(reader["FrecRespiratoria"].ToString());
                    consulta.TensionArterial = reader["TensionArterial"].ToString();
                    consulta.Temperatura = double.Parse(reader["Temperatura"].ToString());
                    consulta.Peso = double.Parse(reader["Peso"].ToString());
                    consulta.Talla = double.Parse(reader["Talla"].ToString());
                    consulta.Diagnostico = reader["Diagnostico"].ToString();
                }

                conn.Close();

                return consulta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
