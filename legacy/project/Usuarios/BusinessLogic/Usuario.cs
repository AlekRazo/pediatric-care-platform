using System;

namespace Usuarios.BusinessLogic
{
    public class Usuario
    {
        int idUsuario;
        string nombre;
        string contrasena;
        DateTime fechaNacimiento;
        DateTime fechaRegistro;
        string sexo;
        int tipoUsuario;
        string cedula;
        string correo;

        public Usuario()
        {
        }

        public Usuario(int id, string nombre, string contrasena, DateTime fechaNacimiento, DateTime fechaRegistro, string sexo, int tipoUsuario, string cedula, string correo)
        {
            this.idUsuario = id;
            this.nombre = nombre;
            this.contrasena = contrasena;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaRegistro = fechaRegistro;
            this.sexo = sexo;
            this.tipoUsuario = tipoUsuario;
            this.cedula = cedula;
            this.correo = correo;
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                contrasena = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                fechaNacimiento = value;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }
            set
            {
                fechaRegistro = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public int TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
            set
            {
                tipoUsuario = value;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }
            set
            {
                cedula = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                correo = value;
            }
        }
    }
}
