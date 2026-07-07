using Consultas.BusinessLogic;
using Pacientes.BusinessLogic;
using System;
using System.Collections.Generic;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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

                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPaciente.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPaciente.NombreMadre = reader["NombreMadre"].ToString();
                    objPaciente.NombrePadre = reader["NombrePadre"].ToString();
                    objPaciente.NombreTutor = reader["NombreTutor"].ToString();
                    objPaciente.Afiliacion = reader["Afiliacion"].ToString();
                    objPaciente.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPaciente.Domicilio = reader["Domicilio"].ToString();
                    objPaciente.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPaciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPaciente.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPaciente.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPaciente.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPaciente.Sexo = reader["Sexo"].ToString();
                    objPaciente.TipoSangre = reader["TipoSangre"].ToString();
                    objPaciente.Observaciones = reader["Observaciones"].ToString();

                    listaPacientes.Add(objPaciente);
                }

                reader.Close();
                conn.Close();

                return listaPacientes;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objPacienteRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPacienteRetorno.NombrePaciente = reader["NombrePaciente"].ToString();
                    objPacienteRetorno.NombreMadre = reader["NombreMadre"].ToString();
                    objPacienteRetorno.NombrePadre = reader["NombrePadre"].ToString();
                    objPacienteRetorno.NombreTutor = reader["NombreTutor"].ToString();
                    objPacienteRetorno.Afiliacion = reader["Afiliacion"].ToString();
                    objPacienteRetorno.NumeroSeguro = reader["NumeroSeguro"].ToString();
                    objPacienteRetorno.Domicilio = reader["Domicilio"].ToString();
                    objPacienteRetorno.CodigoPostal = reader["CodigoPostal"].ToString();
                    objPacienteRetorno.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objPacienteRetorno.LugarNacimiento = reader["LugarNacimiento"].ToString();
                    objPacienteRetorno.TelefonoCasa = reader["TelefonoCasa"].ToString();
                    objPacienteRetorno.TelefonoCelular = reader["TelefonoCelular"].ToString();
                    objPacienteRetorno.Sexo = reader["Sexo"].ToString();
                    objPacienteRetorno.TipoSangre = reader["TipoSangre"].ToString();
                    //objPacienteRetorno.Fotografia = (byte[]) reader["Fotografia"];
                    objPacienteRetorno.Observaciones = reader["Observaciones"].ToString();
                }

                reader.Close();
                conn.Close();

                return objPacienteRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objAlergiasRetorno.IdAlergias = Convert.ToInt32(reader["idAlergias"]);
                    objAlergiasRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objAlergiasRetorno.AlergiaMedicamentos = Convert.ToBoolean(reader["AlergiaMedicamentos"]);
                    objAlergiasRetorno.Medicamentos = reader["Medicamentos"].ToString();
                    objAlergiasRetorno.AlergiaAlimentos = Convert.ToBoolean(reader["AlergiaAlimentos"]);
                    objAlergiasRetorno.Alimentos = reader["Alimentos"].ToString();
                    objAlergiasRetorno.AlergiaFlora = Convert.ToBoolean(reader["AlergiaFlora"]);
                    objAlergiasRetorno.Flora = reader["Flora"].ToString();
                    objAlergiasRetorno.AlergiaRopa = Convert.ToBoolean(reader["AlergiaRopa"]);
                    objAlergiasRetorno.Ropa = reader["Ropa"].ToString();
                }

                reader.Close();
                conn.Close();

                return objAlergiasRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objAlimentacionRetorno.IdAlimentacion = Convert.ToInt32(reader["idAlimentos"]);
                    objAlimentacionRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objAlimentacionRetorno.Pecho = Convert.ToBoolean(reader["Pecho"]);
                    objAlimentacionRetorno.MesInicioPecho = Convert.ToInt32(reader["InicioPecho"]);
                    objAlimentacionRetorno.TipoFormula = reader["TipoFormula"].ToString();
                    objAlimentacionRetorno.MesInicioFormula = Convert.ToInt32(reader["InicioFormula"]);
                    objAlimentacionRetorno.Cereal = Convert.ToBoolean(reader["Cereal"]);
                    objAlimentacionRetorno.MesInicioCereal = Convert.ToInt32(reader["InicioCereal"]);
                    objAlimentacionRetorno.Frutas = Convert.ToBoolean(reader["Frutas"]);
                    objAlimentacionRetorno.InicioFrutas = Convert.ToInt32(reader["InicioFrutas"]);
                    objAlimentacionRetorno.InicioCitricos = Convert.ToInt32(reader["InicioCitricos"]);
                    objAlimentacionRetorno.Verduras = Convert.ToBoolean(reader["Verduras"]);
                    objAlimentacionRetorno.InicioVerduras = Convert.ToInt32(reader["InicioVerduras"]);
                    objAlimentacionRetorno.InicioTomate = Convert.ToInt32(reader["InicioTomate"]);
                }

                reader.Close();
                conn.Close();

                return objAlimentacionRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objAntecedentesRetorno.IdAntecedente = Convert.ToInt32(reader["idAntecedenteMadre"]);
                    objAntecedentesRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objAntecedentesRetorno.Nombre = reader["NombreMadre"].ToString();
                    objAntecedentesRetorno.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objAntecedentesRetorno.Ocupacion = reader["Ocupacion"].ToString();
                    objAntecedentesRetorno.Tabaquismo = Convert.ToBoolean(reader["Tabaquismo"]);
                    objAntecedentesRetorno.Alcoholismo = Convert.ToBoolean(reader["Alcoholismo"]);
                    objAntecedentesRetorno.Toxicomanias = reader["Toxicomanias"].ToString();
                    objAntecedentesRetorno.Alergias = reader["Alergias"].ToString();
                    objAntecedentesRetorno.Diabetes = Convert.ToBoolean(reader["Diabetes"]);
                    objAntecedentesRetorno.Hipertension = Convert.ToBoolean(reader["Hipertension"]);
                    objAntecedentesRetorno.Dismorfologicos = reader["Dismorfologicos"].ToString();
                    objAntecedentesRetorno.Cancer = Convert.ToBoolean(reader["Cancer"]);
                    objAntecedentesRetorno.TiposCancer = reader["TiposCancer"].ToString();
                    objAntecedentesRetorno.Otros = reader["Otros"].ToString();
                    objAntecedentesRetorno.Medicamentos = reader["Medicamentos"].ToString();
                    objAntecedentesRetorno.EstadoActual = reader["EstadoActual"].ToString();
                    objAntecedentesRetorno.Embarazos = Convert.ToInt32(reader["Embarazos"]);
                    objAntecedentesRetorno.Partos = Convert.ToInt32(reader["Partos"]);
                    objAntecedentesRetorno.Abortos = Convert.ToInt32(reader["Abortos"]);
                    objAntecedentesRetorno.Cesareas = Convert.ToInt32(reader["Cesareas"]);
                }

                reader.Close();
                conn.Close();

                return objAntecedentesRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objAntecedentesRetorno.IdAntecedente = Convert.ToInt32(reader["idAntecedentePadre"]);
                    objAntecedentesRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objAntecedentesRetorno.Nombre = reader["NombrePadre"].ToString();
                    objAntecedentesRetorno.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    objAntecedentesRetorno.Ocupacion = reader["Ocupacion"].ToString();
                    objAntecedentesRetorno.Tabaquismo = Convert.ToBoolean(reader["Tabaquismo"]);
                    objAntecedentesRetorno.Alcoholismo = Convert.ToBoolean(reader["Alcoholismo"]);
                    objAntecedentesRetorno.Toxicomanias = reader["Toxicomanias"].ToString();
                    objAntecedentesRetorno.Alergias = reader["Alergias"].ToString();
                    objAntecedentesRetorno.Diabetes = Convert.ToBoolean(reader["Diabetes"]);
                    objAntecedentesRetorno.Hipertension = Convert.ToBoolean(reader["Hipertension"]);
                    objAntecedentesRetorno.Dismorfologicos = reader["Dismorfologicos"].ToString();
                    objAntecedentesRetorno.Cancer = Convert.ToBoolean(reader["Cancer"]);
                    objAntecedentesRetorno.TiposCancer = reader["TiposCancer"].ToString();
                    objAntecedentesRetorno.Otros = reader["Otros"].ToString();
                    objAntecedentesRetorno.Medicamentos = reader["Medicamentos"].ToString();
                    objAntecedentesRetorno.EstadoActual = reader["EstadoActual"].ToString();
                }

                reader.Close();
                conn.Close();

                return objAntecedentesRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objCuidadosRetorno.IdPrenatal = Convert.ToInt32(reader["idPrenatal"]);
                    objCuidadosRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objCuidadosRetorno.Planeado = Convert.ToBoolean(reader["Planeado"]);
                    objCuidadosRetorno.MetodoFertilizacion = reader["MetodoFertilizacion"].ToString();
                    objCuidadosRetorno.InicioControl = Convert.ToInt32(reader["MesInicioControl"]);
                    objCuidadosRetorno.Responsable = reader["ResponsableDeControl"].ToString();
                    objCuidadosRetorno.Enfermedades = reader["Enfermedades"].ToString();
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objCuidadosRetorno.IdNatal = Convert.ToInt32(reader["idNatal"]);
                    objCuidadosRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objCuidadosRetorno.Hospital = reader["Hospital"].ToString();
                    objCuidadosRetorno.TipoNacimiento = reader["TipoNacimiento"].ToString();
                    objCuidadosRetorno.Multiple = Convert.ToBoolean(reader["Multiple"]);
                    objCuidadosRetorno.PesoNacimiento = Convert.ToDouble(reader["PesoNacimiento"]);
                    objCuidadosRetorno.TallaNacimiento = Convert.ToDouble(reader["TallaNacimiento"]);
                    objCuidadosRetorno.Indicaciones = reader["Indicaciones"].ToString();
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objCuidadosRetorno.IdPosnatal = Convert.ToInt32(reader["idPosnatal"]);
                    objCuidadosRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objCuidadosRetorno.NecesidadVigilancia = Convert.ToBoolean(reader["NecesidadVigilancia"]);
                    objCuidadosRetorno.Respirador = Convert.ToBoolean(reader["Respirador"]);
                    objCuidadosRetorno.Incubadora = Convert.ToBoolean(reader["Incubadora"]);
                    objCuidadosRetorno.Fototerapias = reader["Fototerapias"].ToString();
                    objCuidadosRetorno.Otros = reader["Otros"].ToString();
                }

                reader.Close();
                conn.Close();

                return objCuidadosRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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

                while (reader.Read())
                {
                    objPsicomotorRetorno.IdPsicomotor = Convert.ToInt32(reader["idPsicomotor"]);
                    objPsicomotorRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objPsicomotorRetorno.SostieneCabeza = Convert.ToBoolean(reader["SostieneCabeza"]);
                    objPsicomotorRetorno.Sentado = Convert.ToBoolean(reader["Sentado"]);
                    objPsicomotorRetorno.InicioSentado = Convert.ToInt32(reader["InicioSentado"]);
                    objPsicomotorRetorno.Gateo = Convert.ToBoolean(reader["Gateo"]);
                    objPsicomotorRetorno.InicioGateo = Convert.ToInt32(reader["InicioGateo"]);
                    objPsicomotorRetorno.ControlEsfinter = Convert.ToBoolean(reader["ControlEsfinter"]);
                    objPsicomotorRetorno.InicioControlEsfinter = Convert.ToInt32(reader["InicioControlEsfinter"]);
                    objPsicomotorRetorno.Rodado = Convert.ToBoolean(reader["Rodado"]);
                    objPsicomotorRetorno.InicioRodado = Convert.ToInt32(reader["InicioRodado"]);
                    objPsicomotorRetorno.Bipedestacion = Convert.ToBoolean(reader["Bipedestacion"]);
                    objPsicomotorRetorno.InicioBipedestacion = Convert.ToInt32(reader["InicioBipedestacion"]);
                    objPsicomotorRetorno.Deambulacion = Convert.ToBoolean(reader["Deambulacion"]);
                    objPsicomotorRetorno.InicioDeambulacion = Convert.ToInt32(reader["InicioDeambulacion"]);
                }

                reader.Close();
                conn.Close();

                return objPsicomotorRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objVacunacionRetorno.IdVacunacion = Convert.ToInt32(reader["idVacunacion"]);
                    objVacunacionRetorno.IdPaciente = Convert.ToInt32(reader["idPaciente"]);
                    objVacunacionRetorno.HepatitisA = Convert.ToBoolean(reader["HepatitisA"]);
                    objVacunacionRetorno.HepatitisB = Convert.ToBoolean(reader["HepatitisB"]);
                    objVacunacionRetorno.HIB = Convert.ToBoolean(reader["HIB"]);
                    objVacunacionRetorno.Meningococo = Convert.ToBoolean(reader["Meningococo"]);
                    objVacunacionRetorno.BPT = Convert.ToBoolean(reader["BPT"]);
                    objVacunacionRetorno.Poliomielitis = Convert.ToBoolean(reader["Poliomielitis"]);
                    objVacunacionRetorno.Rotavirus = Convert.ToBoolean(reader["Rotavirus"]);
                    objVacunacionRetorno.Neumococo = Convert.ToBoolean(reader["Neumococo"]);
                    objVacunacionRetorno.Influenza = Convert.ToBoolean(reader["InfluenzaEstacionaria"]);
                    objVacunacionRetorno.MMR = Convert.ToBoolean(reader["MMR"]);
                    objVacunacionRetorno.Varicela = Convert.ToBoolean(reader["Varicela"]);
                    objVacunacionRetorno.HPV = Convert.ToBoolean(reader["HPV"]);
                    objVacunacionRetorno.Tuberculosis = Convert.ToBoolean(reader["Tuberculosis"]);
                }

                reader.Close();
                conn.Close();

                return objVacunacionRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    historia.IdConsulta = int.Parse(reader["idConsulta"].ToString());
                    historia.IdPaciente = int.Parse(reader["idPaciente"].ToString());
                    historia.FechaConsulta = DateTime.Parse(reader["FechaConsulta"].ToString());
                    historia.Motivo = reader["Motivo"].ToString();
                    historia.Responsabilidad = reader["Responsabilidad"].ToString();
                    historia.FrecuenciaCardiaca = int.Parse(reader["FrecCardiaca"].ToString());
                    historia.FrecuenciaRespiratoria = int.Parse(reader["FrecRespiratoria"].ToString());
                    historia.TensionArterial = reader["TensionArterial"].ToString();
                    historia.Temperatura = double.Parse(reader["Temperatura"].ToString());
                    historia.Peso = double.Parse(reader["Peso"].ToString());
                    historia.Talla = double.Parse(reader["Talla"].ToString());
                    historia.Diagnostico = reader["Diagnostico"].ToString();
                    historia.Receta = reader["Descripcion"].ToString();
                    historial.Add(historia);
                }

                conn.Close();
                return historial;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
