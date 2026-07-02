using System;
using System.Collections.Generic;
using Usuarios.DataAccess;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Usuarios.BusinessLogic
{
    class LogicaUsuario
    {
        public static Boolean validarInicioDeSesion(Usuario objUsuario)
        {
            Boolean estado;

            Usuario objUsuarioRetorno = new Usuario();
            objUsuarioRetorno = UsuarioDatos.obtenerDetallesLogin(objUsuario);

            string nombreUsuario = objUsuario.Nombre;
            string contraUsuario = objUsuario.Contrasena;

            nombreUsuario = nombreUsuario.Trim().ToLower();
            contraUsuario = contraUsuario.Trim().ToLower();

            string nombreRetorno = objUsuarioRetorno.Nombre;
            string contraRetorno = objUsuarioRetorno.Contrasena;

            if (nombreRetorno != null && contraRetorno != null)
            {
                nombreRetorno = nombreRetorno.Trim().ToLower();
                contraRetorno = contraRetorno.Trim().ToLower();
            }

            if (nombreUsuario.Equals(nombreRetorno) && contraUsuario.Equals(contraRetorno))
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }

        public static Usuario obtenerUsuario(Usuario objUsuario)
        {
            return UsuarioDatos.obtenerDatosDeUsuario(objUsuario);
        }

        public static string obtenerContrasenaUsuario(string nombre)
        {
            return UsuarioDatos.obtenerContrasenaDeUsuario(nombre);
        }

        public static List<Usuario> obtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = UsuarioDatos.obtenerDatosDeUsuarios();
            return listaUsuarios;
        }

        public static List<Usuario> obtenerUsuariosPorNombre(string nombre)
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario = UsuarioDatos.obtenerDatosDeUsuarioPorNombre(nombre);
            return listaUsuario;
        }

        public static List<Usuario> obtenerUsuariosPorTipo(int tipo)
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario = UsuarioDatos.obtenerDatosDeUsuariosPorTipo(tipo);
            return listaUsuario;
        }

        public static int actualizarUsuario(Usuario objUsuario)
        {
            int resultado = UsuarioDatos.modificarDatosDeUsuario(objUsuario);
            return resultado;
        }

        public static int capturarUsuario(Usuario objUsuario)
        {
            int resultado = UsuarioDatos.registrarDatosDeUsuario(objUsuario);
            return resultado;
        }

        public static int eliminarUsuario(int idUsuario)
        {
            int resultado = UsuarioDatos.eliminarDatosDeUsuario(idUsuario);
            return resultado;
        }

        public static bool enviarCorreo(string nombre, string direccionCorreo)
        {
            bool resultado = false;
            string correoUsuario = UsuarioDatos.obtenerCorreoDeUsuario(nombre);

            if (direccionCorreo == correoUsuario)
            {
                MailMessage correo = new MailMessage();
                string contrasena = obtenerContrasenaUsuario(nombre);


                correo.From = new MailAddress("soporte.uabcpediatric@gmail.com"); //de que correo (De) textBoxDe.Text
                correo.To.Add(direccionCorreo);  //para quien va a ser el correo (Para)
                correo.Subject = "Recuperar Contraseña";  //asunto del correo textBoxAsunto.Text
                correo.Body = nombre + ":\r\nEste es un correo de Soporte Tecnico, su contraseña es " + contrasena;  //contenido del correo textBoxContenido.Text
                correo.IsBodyHtml = false;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                //textBoxDe.Text, textBoxContrasena.Text
                smtp.Credentials = new NetworkCredential("soporte.uabcpediatric@gmail.com", "ingenieriaencomputacion");

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(correo);
                    resultado = true;
                }
                catch
                {
                    resultado = false;
                }

                correo.Dispose();
            }
            else
            {
                MessageBox.Show("El correo introducido no corresponde con el registrado.");
                resultado = false;
            }

            return resultado;
        }
    }
}
