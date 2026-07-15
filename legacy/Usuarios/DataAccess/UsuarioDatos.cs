using Helpers.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Usuarios.BusinessLogic;

namespace Usuarios.DataAccess
{
    class UsuarioDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static Usuario obtenerDetallesLogin(Usuario objUsuario)
        {
            string nombre = objUsuario.Nombre;
            string contrasena = objUsuario.Contrasena;
            Usuario objUsuarioRetorno = new Usuario();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Contrasena FROM Usuario WHERE Nombre = @Nombre AND Contrasena = @Contrasena", conn);
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objUsuarioRetorno.Nombre = SeguridadDeTipos.GetSafeString(reader, "Nombre");
                    objUsuarioRetorno.Contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                }

                reader.Close();
                conn.Close();

                return objUsuarioRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Usuario obtenerDatosDeUsuario(Usuario objUsuario)
        {
            string nombre = objUsuario.Nombre;
            string contrasena = objUsuario.Contrasena;
            Usuario objUsuarioRetorno = new Usuario();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE Nombre = @Nombre AND Contrasena = @Contrasena", conn);
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", contrasena));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objUsuarioRetorno.IdUsuario = SeguridadDeTipos.GetSafeInt(reader, "idUsuario");
                    objUsuarioRetorno.Nombre = SeguridadDeTipos.GetSafeString(reader, "Nombre");
                    objUsuarioRetorno.Contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                    objUsuarioRetorno.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    objUsuarioRetorno.FechaRegistro = SeguridadDeTipos.GetSafeDateTime(reader, "FechaRegistro");
                    objUsuarioRetorno.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    objUsuarioRetorno.TipoUsuario = SeguridadDeTipos.GetSafeInt(reader, "TipoUsuario");
                    objUsuarioRetorno.Cedula = SeguridadDeTipos.GetSafeString(reader, "Cedula");
                    objUsuarioRetorno.Correo = SeguridadDeTipos.GetSafeString(reader, "CorreoElectronico");
                }

                reader.Close();
                conn.Close();

                return objUsuarioRetorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string obtenerContrasenaDeUsuario(string nombre)
        {
            string contrasena = "";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Contrasena FROM Usuario WHERE Nombre = @Nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                }

                reader.Close();
                conn.Close();

                return contrasena;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string obtenerCorreoDeUsuario(string nombre)
        {
            string correo = "";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CorreoElectronico FROM Usuario WHERE Nombre = @Nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    correo = SeguridadDeTipos.GetSafeString(reader, "CorreoElectronico");
                }

                reader.Close();
                conn.Close();

                return correo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Usuario> obtenerDatosDeUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = SeguridadDeTipos.GetSafeInt(reader, "idUsuario");
                    usuario.Nombre = SeguridadDeTipos.GetSafeString(reader, "Nombre");
                    usuario.Contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                    usuario.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    usuario.FechaRegistro = SeguridadDeTipos.GetSafeDateTime(reader, "FechaRegistro");
                    usuario.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    usuario.TipoUsuario = SeguridadDeTipos.GetSafeInt(reader, "TipoUsuario");
                    usuario.Cedula = SeguridadDeTipos.GetSafeString(reader, "Cedula");
                    usuario.Correo = SeguridadDeTipos.GetSafeString(reader, "CorreoElectronico");
                    listaUsuarios.Add(usuario);
                }

                reader.Close();
                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Usuario> obtenerDatosDeUsuarioPorNombre(string nombre)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE Nombre LIKE @Nombre", conn);
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = SeguridadDeTipos.GetSafeInt(reader, "idUsuario");
                    usuario.Nombre = SeguridadDeTipos.GetSafeString(reader, "Nombre");
                    usuario.Contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                    usuario.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    usuario.FechaRegistro = SeguridadDeTipos.GetSafeDateTime(reader, "FechaRegistro");
                    usuario.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    usuario.TipoUsuario = SeguridadDeTipos.GetSafeInt(reader, "TipoUsuario");
                    usuario.Cedula = SeguridadDeTipos.GetSafeString(reader, "Cedula");
                    usuario.Correo = SeguridadDeTipos.GetSafeString(reader, "CorreoElectronico");
                    listaUsuarios.Add(usuario);
                }

                reader.Close();
                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Usuario> obtenerDatosDeUsuariosPorTipo(int tipo)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE TipoUsuario = @Tipo", conn);
                cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = SeguridadDeTipos.GetSafeInt(reader, "idUsuario");
                    usuario.Nombre = SeguridadDeTipos.GetSafeString(reader, "Nombre");
                    usuario.Contrasena = SeguridadDeTipos.GetSafeString(reader, "Contrasena");
                    usuario.FechaNacimiento = SeguridadDeTipos.GetSafeDateTime(reader, "FechaNacimiento");
                    usuario.FechaRegistro = SeguridadDeTipos.GetSafeDateTime(reader, "FechaRegistro");
                    usuario.Sexo = SeguridadDeTipos.GetSafeString(reader, "Sexo");
                    usuario.TipoUsuario = SeguridadDeTipos.GetSafeInt(reader, "TipoUsuario");
                    usuario.Cedula = SeguridadDeTipos.GetSafeString(reader, "Cedula");
                    usuario.Correo = SeguridadDeTipos.GetSafeString(reader, "CorreoElectronico");
                    listaUsuarios.Add(usuario);
                }

                reader.Close();
                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int modificarDatosDeUsuario(Usuario objUsuario)
        {
            try
            {
                int id = objUsuario.IdUsuario;
                string nombre = objUsuario.Nombre;
                string contrasena = objUsuario.Contrasena;
                DateTime fechaNacimiento = objUsuario.FechaNacimiento;
                DateTime fechaRegistro = objUsuario.FechaRegistro;
                string sexo = objUsuario.Sexo;
                int tipoUsuario = objUsuario.TipoUsuario;
                string cedula = objUsuario.Cedula;
                string correo = objUsuario.Correo;

                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre = @nombre, Contrasena = @contrasena, FechaNacimiento = @fechaNac, FechaRegistro = @fechaReg, Sexo = @sexo, TipoUsuario = @tipo, Cedula = @cedula, CorreoElectronico = @correo WHERE idUsuario = @id", conn);

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@contrasena", contrasena));
                cmd.Parameters.Add(new SqlParameter("@fechaNac", fechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@fechaReg", fechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
                cmd.Parameters.Add(new SqlParameter("@tipo", tipoUsuario));
                cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
                cmd.Parameters.Add(new SqlParameter("@correo", correo));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int registrarDatosDeUsuario(Usuario objUsuario)
        {
            try
            {
                string nombre = objUsuario.Nombre;
                string contrasena = objUsuario.Contrasena;
                DateTime fechaNacimiento = objUsuario.FechaNacimiento;
                DateTime fechaRegistro = objUsuario.FechaRegistro;
                string sexo = objUsuario.Sexo;
                int tipoUsuario = objUsuario.TipoUsuario;
                string cedula = objUsuario.Cedula;
                string correo = objUsuario.Correo;

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuario VALUES (@nombre, @contrasena, @fechaNac, @fechaReg, @sexo, @tipo, @cedula, @correo)", conn);

                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@contrasena", contrasena));
                cmd.Parameters.Add(new SqlParameter("@fechaNac", fechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@fechaReg", fechaRegistro));
                cmd.Parameters.Add(new SqlParameter("@sexo", sexo));
                cmd.Parameters.Add(new SqlParameter("@tipo", tipoUsuario));
                cmd.Parameters.Add(new SqlParameter("@cedula", cedula));
                cmd.Parameters.Add(new SqlParameter("@correo", correo));

                int resultado = cmd.ExecuteNonQuery();

                conn.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int eliminarDatosDeUsuario(Int32 idUsuario)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE idUsuario = @id", conn);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = idUsuario;
                cmd.Parameters.Add(param);

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
