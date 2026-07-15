using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Citas.BusinessLogic;
using System.Data;

namespace Citas.DataAccess
{
    class CitaDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static List<Cita> obtenerDatosDeCitas()
        {
            List<Cita> listaCitas = new List<Cita>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cita", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cita objCita = new Cita();

                    objCita.IdCita = SeguridadDeTipos.GetSafeInt(reader, "idCita");
                    objCita.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objCita.FechaCita = SeguridadDeTipos.GetSafeDateTime(reader, "Fecha");
                    objCita.HoraCita = TimeSpan.Parse(SeguridadDeTipos.GetSafeString(reader, "Hora");
                    objCita.PrimeraVez = Boolean.Parse(SeguridadDeTipos.GetSafeString(reader, "PrimeraVez");
                    objCita.Telefono = SeguridadDeTipos.GetSafeString(reader, "Telefono");
                    objCita.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");

                    listaCitas.Add(objCita);
                }

                reader.Close();
                conn.Close();

                return listaCitas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Cita> obtenerDatosDeCitasPorFecha(DateTime fechaBusqueda)
        {
            List<Cita> listaCitas = new List<Cita>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cita WHERE Fecha = @fecha", conn);
                cmd.Parameters.Add(new SqlParameter("@fecha", fechaBusqueda));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cita objCita = new Cita();

                    objCita.IdCita = SeguridadDeTipos.GetSafeInt(reader, "idCita");
                    objCita.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objCita.FechaCita = SeguridadDeTipos.GetSafeDateTime(reader, "Fecha");
                    objCita.HoraCita = TimeSpan.Parse(SeguridadDeTipos.GetSafeString(reader, "Hora");
                    objCita.PrimeraVez = Boolean.Parse(SeguridadDeTipos.GetSafeString(reader, "PrimeraVez");
                    objCita.Telefono = SeguridadDeTipos.GetSafeString(reader, "Telefono");
                    objCita.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");

                    listaCitas.Add(objCita);
                }

                reader.Close();
                conn.Close();

                return listaCitas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Cita> obtenerDatosDeCitasPorPaciente(int idPaciente)
        {
            List<Cita> listaCitas = new List<Cita>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cita WHERE idPaciente = @idPaciente", conn);
                cmd.Parameters.Add(new SqlParameter("@idPaciente", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cita objCita = new Cita();

                    objCita.IdCita = SeguridadDeTipos.GetSafeInt(reader, "idCita");
                    objCita.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objCita.FechaCita = SeguridadDeTipos.GetSafeDateTime(reader, "Fecha");
                    objCita.HoraCita = TimeSpan.Parse(SeguridadDeTipos.GetSafeString(reader, "Hora");
                    objCita.PrimeraVez = Boolean.Parse(SeguridadDeTipos.GetSafeString(reader, "PrimeraVez");
                    objCita.Telefono = SeguridadDeTipos.GetSafeString(reader, "Telefono");
                    objCita.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");

                    listaCitas.Add(objCita);
                }

                reader.Close();
                conn.Close();

                return listaCitas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Cita obtenerDatosDeCitasPorFechaYHora(DateTime fechaBusqueda, TimeSpan hora)
        {
            Cita objCitaRetorno = new Cita();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Fecha, Hora FROM Cita WHERE Fecha = @fecha and Hora = @hora", conn);
                cmd.Parameters.Add(new SqlParameter("@fecha", fechaBusqueda));
                cmd.Parameters.Add(new SqlParameter("@hora", hora));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    objCitaRetorno.FechaCita = SeguridadDeTipos.GetSafeDateTime(reader, "Fecha");
                    objCitaRetorno.HoraCita = TimeSpan.Parse(SeguridadDeTipos.GetSafeString(reader, "Hora");
                }

                reader.Close();
                conn.Close();

                return objCitaRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int registrarDatosDeCita(Cita objCita)
        {
            try
            {
                string nombre = objCita.NombrePaciente;
                DateTime fecha = objCita.FechaCita;
                TimeSpan hora = objCita.HoraCita;
                bool primeraVez = objCita.PrimeraVez;
                string telefono = objCita.Telefono;
                string afiliacion = objCita.Afiliacion;

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Cita VALUES (@nombre, @fecha, @hora, @primeraVez, @telefono, @afiliacion)", conn);

                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@hora", hora));
                cmd.Parameters.Add(new SqlParameter("@primeraVez", primeraVez));
                cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@afiliacion", afiliacion));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int modificarDatosDeCita(Cita objCita)
        {
            try
            {
                int id = objCita.IdCita;
                string nombre = objCita.NombrePaciente;
                DateTime fecha = objCita.FechaCita;
                TimeSpan hora = objCita.HoraCita;
                bool primeraVez = objCita.PrimeraVez;
                string telefono = objCita.Telefono;
                string afiliacion = objCita.Afiliacion;

                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cita SET NombrePaciente = @nombre, Fecha = @fecha, Hora = @hora, PrimeraVez = @primeraVez, Telefono = @telefono, Afiliacion = @afiliacion WHERE idCita = @id", conn);

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                cmd.Parameters.Add(new SqlParameter("@hora", hora));
                cmd.Parameters.Add(new SqlParameter("@primeraVez", primeraVez));
                cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@afiliacion", afiliacion));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int eliminarDatosDeCita(int idCita)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Cita WHERE idCita = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idCita));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public static List<Fecha> obtenerFechasNoHabiles()
        {
            List<Fecha> listaFechas = new List<Fecha>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FechaNoHabil FROM FechasNoHabiles GROUP BY FechaNoHabil", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    listaFechas.Add(new Fecha(SeguridadDeTipos.GetSafeDateTime(reader, "FechaNoHabil"].ToString())));
                }

                reader.Close();
                conn.Close();

                return listaFechas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DateTime obtenerFecha(DateTime fecha){
            DateTime fechaRetorno = new DateTime();

            try{
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FechaNoHabil FROM FechasNoHabiles WHERE FechaNoHabil = @fecha", conn);
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha.Date));

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()){
                    fechaRetorno = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNoHabil");
                }
                reader.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                throw;
            }

            return fechaRetorno;
        }

        public static int agregarFechaNoHabil(DateTime fecha)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO FechasNoHabiles VALUES (@fecha)", conn);

                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int agregarFechasNoHablesPorRango(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertarFechas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                int resultado = cmd.ExecuteNonQuery();

                cmd.Dispose();
                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int eliminarFechaHabil(DateTime fecha)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM FechasNoHabiles WHERE FechaNoHabil = @fecha", conn);

                cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
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
