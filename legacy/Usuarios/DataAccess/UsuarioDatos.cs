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
                    objUsuarioRetorno.Nombre = reader["Nombre"].ToString();
                    objUsuarioRetorno.Contrasena = reader["Contrasena"].ToString();
                }

                conn.Close();

                return objUsuarioRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    objUsuarioRetorno.IdUsuario = Int32.Parse(reader["idUsuario"].ToString());
                    objUsuarioRetorno.Nombre = reader["Nombre"].ToString();
                    objUsuarioRetorno.Contrasena = reader["Contrasena"].ToString();
                    objUsuarioRetorno.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                    objUsuarioRetorno.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                    objUsuarioRetorno.Sexo = reader["Sexo"].ToString();
                    objUsuarioRetorno.TipoUsuario = Int32.Parse(reader["TipoUsuario"].ToString());
                    objUsuarioRetorno.Cedula = reader["Cedula"].ToString();
                    objUsuarioRetorno.Correo = reader["CorreoElectronico"].ToString();
                }

                conn.Close();

                return objUsuarioRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    contrasena = reader["Contrasena"].ToString();
                }

                conn.Close();

                return contrasena;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    correo = reader["CorreoElectronico"].ToString();
                }

                conn.Close();

                return correo;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    listaUsuarios.Add(new Usuario(Int32.Parse(reader["idUsuario"].ToString()), reader["Nombre"].ToString(), reader["Contrasena"].ToString(), DateTime.Parse(reader["FechaNacimiento"].ToString()), DateTime.Parse(reader["FechaRegistro"].ToString()), reader["Sexo"].ToString(), Int32.Parse(reader["TipoUsuario"].ToString()), reader["Cedula"].ToString(), reader["CorreoElectronico"].ToString()));
                }

                reader.Close();
                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    listaUsuarios.Add(new Usuario(Int32.Parse(reader["idUsuario"].ToString()), reader["Nombre"].ToString(), reader["Contrasena"].ToString(), DateTime.Parse(reader["FechaNacimiento"].ToString()), DateTime.Parse(reader["FechaRegistro"].ToString()), reader["Sexo"].ToString(), Int32.Parse(reader["TipoUsuario"].ToString()), reader["Cedula"].ToString(), reader["CorreoElectronico"].ToString()));
                }

                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    listaUsuarios.Add(new Usuario(Int32.Parse(reader["idUsuario"].ToString()), reader["Nombre"].ToString(), reader["Contrasena"].ToString(), DateTime.Parse(reader["FechaNacimiento"].ToString()), DateTime.Parse(reader["FechaRegistro"].ToString()), reader["Sexo"].ToString(), Int32.Parse(reader["TipoUsuario"].ToString()), reader["Cedula"].ToString(), reader["CorreoElectronico"].ToString()));
                }

                reader.Close();
                conn.Close();

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }
    }
}
