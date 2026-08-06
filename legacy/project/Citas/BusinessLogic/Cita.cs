using System;

namespace Citas.BusinessLogic
{
    public class Cita
    {
        int idCita;
        string nombrePaciente;
        DateTime fechaCita;
        TimeSpan horaCita;
        bool primeraVez;
        string telefono;
        string afiliacion;

        public Cita()
        {
        }

        public Cita(int id, string nombre, DateTime fechaCita, TimeSpan horaCita, bool primeraVez, string telefono, string afiliacion)
        {
        }

        public int IdCita
        {
            get
            {
                return idCita;
            }
            set
            {
                this.idCita = value;
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
                this.nombrePaciente = value;
            }
        }

        public DateTime FechaCita
        {
            get
            {
                return fechaCita;
            }
            set
            {
                this.fechaCita = value;
            }
        }

        public TimeSpan HoraCita
        {
            get
            {
                return horaCita;
            }
            set
            {
                this.horaCita = value;
            }
        }
        
        public bool PrimeraVez
        {
            get
            {
                return primeraVez;
            }
            set
            {
                this.primeraVez = value;
            }
        }
        
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                this.telefono = value;
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
                this.afiliacion = value;
            }
        }
    }
}
