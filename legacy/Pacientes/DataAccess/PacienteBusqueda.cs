using Consultas.BusinessLogic;
using Helpers.Helpers;
using Pacientes.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Pacientes.DataAccess
{
    class PacienteBusqueda
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static List<Paciente> obtenerDatosDeTodosLosPacientes()
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorNombre(string nombre)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE NombrePaciente = @nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorNombreMadre(string nombreMadre)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE NombreMadre = @nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@nombre", nombreMadre));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorNombrePadre(string nombrePadre)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE NombrePadre = @nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@nombre", nombrePadre));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorTipoSangre(string tipoSangre)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE TipoSangre = @tipo", conn);
                cmd.Parameters.Add(new SqlParameter("@tipo", tipoSangre));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorEdad(int edad)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paciente WHERE Edad = @edad", conn);
                cmd.Parameters.Add(new SqlParameter("@edad", edad));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Paciente> obtenerDatosDePacientePorSexo(string sexo)
        {
            List<Paciente> listaPacientes = new List<Paciente>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cita WHERE Sexo = @sexo", conn);
                cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();

                    objPaciente.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPaciente.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPaciente.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPaciente.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPaciente.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPaciente.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPaciente.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPaciente.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPaciente.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPaciente.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPaciente.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPaciente.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPaciente.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPaciente.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPaciente.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    objPaciente.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Paciente obtenerDatosDePaciente(int idPaciente)
        {
            Paciente objPacienteRetorno = new Paciente();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cita WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objPacienteRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPacienteRetorno.NombrePaciente = SeguridadDeTipos.GetSafeString(reader, "NombrePaciente");
                    objPacienteRetorno.NombreMadre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objPacienteRetorno.NombrePadre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objPacienteRetorno.NombreTutor = SeguridadDeTipos.GetSafeString(reader, "NombreTutor");
                    objPacienteRetorno.Afiliacion = SeguridadDeTipos.GetSafeString(reader, "Afiliacion");
                    objPacienteRetorno.NumeroSeguro = SeguridadDeTipos.GetSafeString(reader, "NumeroSeguro");
                    objPacienteRetorno.Domicilio = SeguridadDeTipos.GetSafeString(reader, "Domicilio");
                    objPacienteRetorno.CodigoPostal = SeguridadDeTipos.GetSafeString(reader, "CodigoPostal");
                    objPacienteRetorno.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objPacienteRetorno.LugarNacimiento = SeguridadDeTipos.GetSafeString(reader, "LugarNacimiento");
                    objPacienteRetorno.TelefonoCasa = SeguridadDeTipos.GetSafeString(reader, "TelefonoCasa");
                    objPacienteRetorno.TelefonoCelular = SeguridadDeTipos.GetSafeString(reader, "TelefonoCelular");
                    objPacienteRetorno.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objPacienteRetorno.TipoSangre = SeguridadDeTipos.GetSafeString(reader, "TipoSangre");
                    //objPacienteRetorno.Fotografia = (byte[]) SeguridadDeTipos.GetSafeString(reader, "Fotografia"];
                    objPacienteRetorno.Observaciones = SeguridadDeTipos.GetSafeString(reader, "Observaciones");
                }

                reader.Close();
                conn.Close();

                return objPacienteRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Alergias obtenerAlergiasDePaciente(int idPaciente)
        {
            Alergias objAlergiasRetorno = new Alergias();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Alergias WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objAlergiasRetorno.IdAlergias = SeguridadDeTipos.GetSafeInt(reader, "idAlergias");
                    objAlergiasRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objAlergiasRetorno.AlergiaMedicamentos = SeguridadDeTipos.GetSafeBool(reader, "AlergiaMedicamentos");
                    objAlergiasRetorno.Medicamentos = SeguridadDeTipos.GetSafeString(reader, "Medicamentos");
                    objAlergiasRetorno.AlergiaAlimentos = SeguridadDeTipos.GetSafeBool(reader, "AlergiaAlimentos");
                    objAlergiasRetorno.Alimentos = SeguridadDeTipos.GetSafeString(reader, "Alimentos");
                    objAlergiasRetorno.AlergiaFlora = SeguridadDeTipos.GetSafeBool(reader, "AlergiaFlora");
                    objAlergiasRetorno.Flora = SeguridadDeTipos.GetSafeString(reader, "Flora");
                    objAlergiasRetorno.AlergiaRopa = SeguridadDeTipos.GetSafeBool(reader, "AlergiaRopa");
                    objAlergiasRetorno.Ropa = SeguridadDeTipos.GetSafeString(reader, "Ropa");
                }

                reader.Close();
                conn.Close();

                return objAlergiasRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Alimentacion obtenerAlimentacionDePaciente(int idPaciente)
        {
            Alimentacion objAlimentacionRetorno = new Alimentacion();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Alimentacion WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objAlimentacionRetorno.IdAlimentacion = SeguridadDeTipos.GetSafeInt(reader, "idAlimentos");
                    objAlimentacionRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objAlimentacionRetorno.Pecho = SeguridadDeTipos.GetSafeBool(reader, "Pecho");
                    objAlimentacionRetorno.MesInicioPecho = SeguridadDeTipos.GetSafeInt(reader, "InicioPecho");
                    objAlimentacionRetorno.TipoFormula = SeguridadDeTipos.GetSafeString(reader, "TipoFormula");
                    objAlimentacionRetorno.MesInicioFormula = SeguridadDeTipos.GetSafeInt(reader, "InicioFormula");
                    objAlimentacionRetorno.Cereal = SeguridadDeTipos.GetSafeBool(reader, "Cereal");
                    objAlimentacionRetorno.MesInicioCereal = SeguridadDeTipos.GetSafeInt(reader, "InicioCereal");
                    objAlimentacionRetorno.Frutas = SeguridadDeTipos.GetSafeBool(reader, "Frutas");
                    objAlimentacionRetorno.InicioFrutas = SeguridadDeTipos.GetSafeInt(reader, "InicioFrutas");
                    objAlimentacionRetorno.InicioCitricos = SeguridadDeTipos.GetSafeInt(reader, "InicioCitricos");
                    objAlimentacionRetorno.Verduras = SeguridadDeTipos.GetSafeBool(reader, "Verduras");
                    objAlimentacionRetorno.InicioVerduras = SeguridadDeTipos.GetSafeInt(reader, "InicioVerduras");
                    objAlimentacionRetorno.InicioTomate = SeguridadDeTipos.GetSafeInt(reader, "InicioTomate");
                }

                reader.Close();
                conn.Close();

                return objAlimentacionRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static AntecedentesMadre obtenerAntecedentesMadreDePaciente(int idPaciente)
        {
            AntecedentesMadre objAntecedentesRetorno = new AntecedentesMadre();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AntecedentesMadre WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objAntecedentesRetorno.IdAntecedente = SeguridadDeTipos.GetSafeInt(reader, "idAntecedenteMadre");
                    objAntecedentesRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objAntecedentesRetorno.Nombre = SeguridadDeTipos.GetSafeString(reader, "NombreMadre");
                    objAntecedentesRetorno.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objAntecedentesRetorno.Ocupacion = SeguridadDeTipos.GetSafeString(reader, "Ocupacion");
                    objAntecedentesRetorno.Tabaquismo = SeguridadDeTipos.GetSafeBool(reader, "Tabaquismo");
                    objAntecedentesRetorno.Alcoholismo = SeguridadDeTipos.GetSafeBool(reader, "Alcoholismo");
                    objAntecedentesRetorno.Toxicomanias = SeguridadDeTipos.GetSafeString(reader, "Toxicomanias");
                    objAntecedentesRetorno.Alergias = SeguridadDeTipos.GetSafeString(reader, "Alergias");
                    objAntecedentesRetorno.Diabetes = SeguridadDeTipos.GetSafeBool(reader, "Diabetes");
                    objAntecedentesRetorno.Hipertension = SeguridadDeTipos.GetSafeBool(reader, "Hipertension");
                    objAntecedentesRetorno.Dismorfologicos = SeguridadDeTipos.GetSafeString(reader, "Dismorfologicos");
                    objAntecedentesRetorno.Cancer = SeguridadDeTipos.GetSafeBool(reader, "Cancer");
                    objAntecedentesRetorno.TiposCancer = SeguridadDeTipos.GetSafeString(reader, "TiposCancer");
                    objAntecedentesRetorno.Otros = SeguridadDeTipos.GetSafeString(reader, "Otros");
                    objAntecedentesRetorno.Medicamentos = SeguridadDeTipos.GetSafeString(reader, "Medicamentos");
                    objAntecedentesRetorno.EstadoActual = SeguridadDeTipos.GetSafeString(reader, "EstadoActual");
                    objAntecedentesRetorno.Embarazos = SeguridadDeTipos.GetSafeInt(reader, "Embarazos");
                    objAntecedentesRetorno.Partos = SeguridadDeTipos.GetSafeInt(reader, "Partos");
                    objAntecedentesRetorno.Abortos = SeguridadDeTipos.GetSafeInt(reader, "Abortos");
                    objAntecedentesRetorno.Cesareas = SeguridadDeTipos.GetSafeInt(reader, "Cesareas");
                }

                reader.Close();
                conn.Close();

                return objAntecedentesRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static AntecedentesPadre obtenerAntecedentesPadreDePaciente(int idPaciente)
        {
            AntecedentesPadre objAntecedentesRetorno = new AntecedentesPadre();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AntecedentesPadre WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objAntecedentesRetorno.IdAntecedente = SeguridadDeTipos.GetSafeInt(reader, "idAntecedentePadre");
                    objAntecedentesRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objAntecedentesRetorno.Nombre = SeguridadDeTipos.GetSafeString(reader, "NombrePadre");
                    objAntecedentesRetorno.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objAntecedentesRetorno.Ocupacion = SeguridadDeTipos.GetSafeString(reader, "Ocupacion");
                    objAntecedentesRetorno.Tabaquismo = SeguridadDeTipos.GetSafeBool(reader, "Tabaquismo");
                    objAntecedentesRetorno.Alcoholismo = SeguridadDeTipos.GetSafeBool(reader, "Alcoholismo");
                    objAntecedentesRetorno.Toxicomanias = SeguridadDeTipos.GetSafeString(reader, "Toxicomanias");
                    objAntecedentesRetorno.Alergias = SeguridadDeTipos.GetSafeString(reader, "Alergias");
                    objAntecedentesRetorno.Diabetes = SeguridadDeTipos.GetSafeBool(reader, "Diabetes");
                    objAntecedentesRetorno.Hipertension = SeguridadDeTipos.GetSafeBool(reader, "Hipertension");
                    objAntecedentesRetorno.Dismorfologicos = SeguridadDeTipos.GetSafeString(reader, "Dismorfologicos");
                    objAntecedentesRetorno.Cancer = SeguridadDeTipos.GetSafeBool(reader, "Cancer");
                    objAntecedentesRetorno.TiposCancer = SeguridadDeTipos.GetSafeString(reader, "TiposCancer");
                    objAntecedentesRetorno.Otros = SeguridadDeTipos.GetSafeString(reader, "Otros");
                    objAntecedentesRetorno.Medicamentos = SeguridadDeTipos.GetSafeString(reader, "Medicamentos");
                    objAntecedentesRetorno.EstadoActual = SeguridadDeTipos.GetSafeString(reader, "EstadoActual");
                }

                reader.Close();
                conn.Close();

                return objAntecedentesRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static CuidadoPrenatal obtenerCuidadoPrenatalDePaciente(int idPaciente)
        {
            CuidadoPrenatal objCuidadosRetorno = new CuidadoPrenatal();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CuidadoPrenatal WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objCuidadosRetorno.IdPrenatal = SeguridadDeTipos.GetSafeInt(reader, "idPrenatal");
                    objCuidadosRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objCuidadosRetorno.Planeado = SeguridadDeTipos.GetSafeBool(reader, "Planeado");
                    objCuidadosRetorno.MetodoFertilizacion = SeguridadDeTipos.GetSafeString(reader, "MetodoFertilizacion");
                    objCuidadosRetorno.InicioControl = SeguridadDeTipos.GetSafeInt(reader, "MesInicioControl");
                    objCuidadosRetorno.Responsable = SeguridadDeTipos.GetSafeString(reader, "ResponsableDeControl");
                    objCuidadosRetorno.Enfermedades = SeguridadDeTipos.GetSafeString(reader, "Enfermedades");
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static CuidadoNatal obtenerCuidadoNatalDePaciente(int idPaciente)
        {
            CuidadoNatal objCuidadosRetorno = new CuidadoNatal();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CuidadoNatal WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objCuidadosRetorno.IdNatal = SeguridadDeTipos.GetSafeInt(reader, "idNatal");
                    objCuidadosRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objCuidadosRetorno.Hospital = SeguridadDeTipos.GetSafeString(reader, "Hospital");
                    objCuidadosRetorno.TipoNacimiento = SeguridadDeTipos.GetSafeString(reader, "TipoNacimiento");
                    objCuidadosRetorno.Multiple = SeguridadDeTipos.GetSafeBool(reader, "Multiple");
                    objCuidadosRetorno.PesoNacimiento = SeguridadDeTipos.GetSafeDouble(reader, "PesoNacimiento");
                    objCuidadosRetorno.TallaNacimiento = SeguridadDeTipos.GetSafeDouble(reader, "TallaNacimiento");
                    objCuidadosRetorno.Indicaciones = SeguridadDeTipos.GetSafeString(reader, "Indicaciones");
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static CuidadoPosnatal obtenerCuidadoPosnatalDePaciente(int idPaciente)
        {
            CuidadoPosnatal objCuidadosRetorno = new CuidadoPosnatal();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CuidadoPosnatal WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objCuidadosRetorno.IdPosnatal = SeguridadDeTipos.GetSafeInt(reader, "idPosnatal");
                    objCuidadosRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objCuidadosRetorno.NecesidadVigilancia = SeguridadDeTipos.GetSafeBool(reader, "NecesidadVigilancia");
                    objCuidadosRetorno.Respirador = SeguridadDeTipos.GetSafeBool(reader, "Respirador");
                    objCuidadosRetorno.Incubadora = SeguridadDeTipos.GetSafeBool(reader, "Incubadora");
                    objCuidadosRetorno.Fototerapias = SeguridadDeTipos.GetSafeString(reader, "Fototerapias");
                    objCuidadosRetorno.Otros = SeguridadDeTipos.GetSafeString(reader, "Otros");
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Psicomotor obtenerDatosPsicomotorDePaciente(int idPaciente)
        {
            Psicomotor objPsicomotorRetorno = new Psicomotor();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Psicomotor WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                //Borrar
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Now you can freely jump to any specific row or check the overall count
                int totalRows = dataTable.Rows.Count;
                DataRow firstRow = dataTable.Rows[0];


                while (reader.Read())
                {
                    objPsicomotorRetorno.IdPsicomotor = SeguridadDeTipos.GetSafeInt(reader, "idPsicomotor");
                    objPsicomotorRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objPsicomotorRetorno.SostieneCabeza = SeguridadDeTipos.GetSafeBool(reader, "SostieneCabeza");
                    objPsicomotorRetorno.Sentado = SeguridadDeTipos.GetSafeBool(reader, "Sentado");
                    objPsicomotorRetorno.InicioSentado = SeguridadDeTipos.GetSafeInt(reader, "InicioSentado");
                    objPsicomotorRetorno.Gateo = SeguridadDeTipos.GetSafeBool(reader, "Gateo");
                    objPsicomotorRetorno.InicioGateo = SeguridadDeTipos.GetSafeInt(reader, "InicioGateo");
                    objPsicomotorRetorno.ControlEsfinter = SeguridadDeTipos.GetSafeBool(reader, "ControlEsfinter");
                    objPsicomotorRetorno.InicioControlEsfinter = SeguridadDeTipos.GetSafeInt(reader, "InicioControlEsfinter");
                    objPsicomotorRetorno.Rodado = SeguridadDeTipos.GetSafeBool(reader, "Rodado");
                    objPsicomotorRetorno.InicioRodado = SeguridadDeTipos.GetSafeInt(reader, "InicioRodado");
                    objPsicomotorRetorno.Bipedestacion = SeguridadDeTipos.GetSafeBool(reader, "Bipedestacion");
                    objPsicomotorRetorno.InicioBipedestacion = SeguridadDeTipos.GetSafeInt(reader, "InicioBipedestacion");
                    objPsicomotorRetorno.Deambulacion = SeguridadDeTipos.GetSafeBool(reader, "Deambulacion");
                    objPsicomotorRetorno.InicioDeambulacion = SeguridadDeTipos.GetSafeInt(reader, "InicioDeambulacion");
                }

                reader.Close();
                conn.Close();

                return objPsicomotorRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Vacunacion obtenerDatosVacunacionDePaciente(int idPaciente)
        {
            Vacunacion objVacunacionRetorno = new Vacunacion();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Vacunas WHERE idPaciente = @id", conn);
                cmd.Parameters.Add(new SqlParameter("@id", idPaciente));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objVacunacionRetorno.IdVacunacion = SeguridadDeTipos.GetSafeInt(reader, "idVacunacion");
                    objVacunacionRetorno.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    objVacunacionRetorno.HepatitisA = SeguridadDeTipos.GetSafeBool(reader, "HepatitisA");
                    objVacunacionRetorno.HepatitisB = SeguridadDeTipos.GetSafeBool(reader, "HepatitisB");
                    objVacunacionRetorno.HIB = SeguridadDeTipos.GetSafeBool(reader, "HIB");
                    objVacunacionRetorno.Meningococo = SeguridadDeTipos.GetSafeBool(reader, "Meningococo");
                    objVacunacionRetorno.BPT = SeguridadDeTipos.GetSafeBool(reader, "BPT");
                    objVacunacionRetorno.Poliomielitis = SeguridadDeTipos.GetSafeBool(reader, "Poliomielitis");
                    objVacunacionRetorno.Rotavirus = SeguridadDeTipos.GetSafeBool(reader, "Rotavirus");
                    objVacunacionRetorno.Neumococo = SeguridadDeTipos.GetSafeBool(reader, "Neumococo");
                    objVacunacionRetorno.Influenza = SeguridadDeTipos.GetSafeBool(reader, "InfluenzaEstacionaria");
                    objVacunacionRetorno.MMR = SeguridadDeTipos.GetSafeBool(reader, "MMR");
                    objVacunacionRetorno.Varicela = SeguridadDeTipos.GetSafeBool(reader, "Varicela");
                    objVacunacionRetorno.HPV = SeguridadDeTipos.GetSafeBool(reader, "HPV");
                    objVacunacionRetorno.Tuberculosis = SeguridadDeTipos.GetSafeBool(reader, "Tuberculosis");
                }

                reader.Close();
                conn.Close();

                return objVacunacionRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Historial> obtenerHistorialDePaciente(int idPaciente)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT c.idConsulta" +
                    ",c.idPaciente" +
                    ",c.FechaConsulta" +
                    ",c.Motivo" +
                    ",c.Responsabilidad" +
                    ",c.FrecCardiaca" +
                    ",c.FrecRespiratoria" +
                    ",c.TensionArterial" +
                    ",c.Temperatura" +
                    ",c.Peso" +
                    ",c.Talla" +
                    ",c.Diagnostico" +
                    ",r.Descripcion " +
                    "FROM Consulta c LEFT JOIN Receta r " +
                    "ON c.idPaciente = r.idPaciente AND c.idConsulta = r.idConsulta " +
                    "WHERE c.idPaciente = @idPaciente", conn);
                cmd.Parameters.Add(new SqlParameter("@idPaciente", idPaciente));
                List<Historial> historial = new List<Historial>();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Historial historia = new Historial ();
                    historia.IdConsulta = SeguridadDeTipos.GetSafeInt(reader, "idConsulta");
                    historia.IdPaciente = SeguridadDeTipos.GetSafeInt(reader, "idPaciente");
                    historia.FechaConsulta = SeguridadDeTipos.GetSafeDateTime(reader, "FechaConsulta");
                    historia.Motivo = SeguridadDeTipos.GetSafeString(reader, "Motivo");
                    historia.Responsabilidad = SeguridadDeTipos.GetSafeString(reader, "Responsabilidad");
                    historia.FrecuenciaCardiaca = SeguridadDeTipos.GetSafeInt(reader, "FrecCardiaca");
                    historia.FrecuenciaRespiratoria = SeguridadDeTipos.GetSafeInt(reader, "FrecRespiratoria");
                    historia.TensionArterial = SeguridadDeTipos.GetSafeString(reader, "TensionArterial");
                    historia.Temperatura = SeguridadDeTipos.GetSafeDouble(reader, "Temperatura");
                    historia.Peso = SeguridadDeTipos.GetSafeDouble(reader, "Peso");
                    historia.Talla = SeguridadDeTipos.GetSafeDouble(reader, "Talla");
                    historia.Diagnostico = SeguridadDeTipos.GetSafeString(reader, "Diagnostico");
                    historia.Receta = SeguridadDeTipos.GetSafeString(reader, "Descripcion");
                    historial.Add(historia);
                }

                conn.Close();
                return historial;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
