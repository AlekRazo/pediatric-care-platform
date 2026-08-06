using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class Paciente
    {
        int idPaciente;
        string nombrePaciente;
        DateTime fechaNacimiento;
        string sexo;

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
    }
}
