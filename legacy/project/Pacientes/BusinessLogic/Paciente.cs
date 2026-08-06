using System;
using System.Drawing;

namespace Pacientes.BusinessLogic
{
    public class Paciente
    {
        int idPaciente;
        string nombrePaciente;
        string nombreMadre;
        string nombrePadre;
        string nombreTutor;
        string afiliacion;
        string numeroSeguro;
        string domicilio;
        string codigoPostal;
        DateTime fechaNacimiento;
        string lugarNacimiento;
        string telefonoCasa;
        string telefonoCelular;
        string sexo;
        string tipoSangre;
        //byte[] fotografia;
        string observaciones;

        public Paciente()
        {
        }


        //Getter, Setters
        public int IdPaciente
        {
            get
            {
                return idPaciente;
            }
            set
            {
                idPaciente = value;
            }
        }

        public string NombrePaciente
        {
            get
            {
                return nombrePaciente;
            }
            set
            {
                nombrePaciente = value;
            }
        }

        public string NombreMadre
        {
            get
            {
                return nombreMadre;
            }
            set
            {
                nombreMadre = value;
            }
        }

        public string NombrePadre
        {
            get
            {
                return nombrePadre;
            }
            set
            {
                nombrePadre = value;
            }
        }

        public string NombreTutor
        {
            get
            {
                return nombreTutor;
            }
            set
            {
                nombreTutor = value;
            }
        }

        public string Afiliacion
        {
            get
            {
                return afiliacion;
            }
            set
            {
                afiliacion = value;
            }
        }

        public string NumeroSeguro
        {
            get
            {
                return numeroSeguro;
            }
            set
            {
                numeroSeguro = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }
            set
            {
                domicilio = value;
            }
        }

        public string CodigoPostal
        {
            get
            {
                return codigoPostal;
            }
            set
            {
                codigoPostal = value;
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

        public string LugarNacimiento
        {
            get
            {
                return lugarNacimiento;
            }
            set
            {
                lugarNacimiento = value;
            }
        }

        public string TelefonoCasa
        {
            get
            {
                return telefonoCasa;
            }
            set
            {
                telefonoCasa = value;
            }
        }

        public string TelefonoCelular
        {
            get
            {
                return telefonoCelular;
            }
            set
            {
                telefonoCelular = value;
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

        public string TipoSangre
        {
            get
            {
                return tipoSangre;
            }
            set
            {
                tipoSangre = value;
            }
        }

        //public byte[] Fotografia
        //{
        //    get
        //    {
        //        return fotografia;
        //    }
        //    set
        //    {
        //        fotografia = value;
        //    }
        //}

        public string Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                observaciones = value;
            }
        }
    }
}
