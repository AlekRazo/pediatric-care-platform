using Recetas.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.DataAccess
{
    class RecetasDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static int guardarDatosDeReceta(Receta objReceta)
        {
            try
            {
                int idConsulta = objReceta.IdConsulta;
                int idPaciente = objReceta.IdPaciente;
                DateTime fechaConsulta = objReceta.FechaConsulta;
                double peso = objReceta.Peso;
                double talla = objReceta.Talla;
                string descripcion = objReceta.Descripcion;

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Receta VALUES (@idPaciente, @idConsulta, @fechaEmision, @peso, @talla, @descripcion)", conn);

                cmd.Parameters.Add(new SqlParameter("@idPaciente", idPaciente));
                cmd.Parameters.Add(new SqlParameter("@idConsulta", idConsulta));
                cmd.Parameters.Add(new SqlParameter("@fechaEmision", fechaConsulta));
                cmd.Parameters.Add(new SqlParameter("@peso", peso));
                cmd.Parameters.Add(new SqlParameter("@talla", talla));
                cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
