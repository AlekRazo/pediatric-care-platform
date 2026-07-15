using Estadisticas.BusinessLogic;
using Helpers.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Estadisticas.DataAccess
{
    class EstadisticaDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static List<EstadisticaDiagnostico> obtenerEstadisticasDiagnostico (DateTime fechaInicio, DateTime fechaFin, int idPaciente)
        {
            List<EstadisticaDiagnostico> estadisticas = new List<EstadisticaDiagnostico>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN c.Motivo IS NULL OR c.Motivo = '' " +
                    "THEN 'SIN MOTIVO' " +
                    "ELSE UPPER(Diagnostico) END AS Motivo" +
                    ", COUNT(c.Motivo) AS Cantidad " +
                    "FROM Consulta c " +
                    "RIGHT JOIN Paciente p " +
                    "ON c.idPaciente = p.idPaciente " +
                    "WHERE p.idPaciente = @idPaciente " +
                    "AND c.FechaConsulta BETWEEN @fechaInicio AND @fechaFin " +
                    "GROUP BY c.Motivo " +
                    "ORDER BY Cantidad DESC");

                cmd.Parameters.Add(new SqlParameter("@idPaciente", idPaciente));
                cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    EstadisticaDiagnostico estadistica = new EstadisticaDiagnostico();
                    estadistica.Motivo = reader.GetString(0);
                    estadistica.Cantidad = reader.GetInt32(1);
                    estadisticas.Add(estadistica);
                }

                conn.Close();

                return estadisticas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<DiagnosticoPatologia> obtenerDiagnosticosPorPatologia(DateTime fechaInicio, DateTime fechaFin)
        {
            List <DiagnosticoPatologia> diagnosticos = new List<DiagnosticoPatologia>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN Diagnostico IS NULL OR Diagnostico = '' " +
                    "THEN 'SIN DIAGNOSTICO' " +
                    "ELSE UPPER(Diagnostico) END AS Patologia" +
                    ", COUNT(Diagnostico) AS Cantidad " +
                    "FROM Consulta " +
                    "WHERE FechaConsulta BETWEEN @fechaInicio AND @fechaFin " +
                    "GROUP BY Diagnostico " +
                    "ORDER BY Cantidad DESC");

                cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DiagnosticoPatologia diagnostico = new DiagnosticoPatologia();
                    diagnostico.Patologia = reader.GetString(0);
                    diagnostico.Cantidad = reader.GetInt32(1);
                    diagnosticos.Add(diagnostico);
                }

                conn.Close();

                return diagnosticos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<PuntoCrecimiento> obtenerCurvaCrecimiento(int idPaciente)
        {
            List<PuntoCrecimiento> lista = new List<PuntoCrecimiento>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.FechaConsulta" +
                    ", p.FechaNacimiento" +
                    ", ISNULL(c.Peso, 0.0) AS Peso" +
                    ", c.Talla " +
                    "FROM Consulta c " +
                    "RIGHT JOIN Paciente p " +
                    "ON c.idPaciente = p.idPaciente " +
                    "WHERE p.idPaciente = 1 " +
                    "ORDER BY c.FechaConsulta ASC");

                cmd.Parameters.Add(new SqlParameter("idPaciente", idPaciente));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PuntoCrecimiento crecimiento = new PuntoCrecimiento();
                    DateTime fechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    DateTime fechaConsulta = SeguridadDeTipos.GetSafeDateTime(reader, "FechaConsulta");

                    crecimiento.IdPaciente = idPaciente;
                    crecimiento.FechaConsulta = fechaConsulta;
                    crecimiento.Peso = SeguridadDeTipos.GetSafeDouble(reader, "Peso");
                    crecimiento.Talla = SeguridadDeTipos.GetSafeDouble(reader, "Talla");

                    lista.Add(crecimiento);
                }

                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
