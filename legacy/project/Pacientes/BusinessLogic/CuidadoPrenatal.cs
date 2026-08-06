using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class CuidadoPrenatal
    {
        int idPrenatal;
        int idPaciente;
        bool planeado;
        string metodoFertilizacion;
        int mesInicioControl;
        string responsableDeControl;
        string enfermedades;

        public CuidadoPrenatal()
        {
        }

        //Getters, Setters

        public int IdPrenatal
        {
            get
            {
                return idPrenatal;
            }
            set
            {
                idPrenatal = value;
            }
        }

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

        public bool Planeado
        {
            get
            {
                return planeado;
            }
            set
            {
                planeado = value;
            }
        }

        public string MetodoFertilizacion
        {
            get
            {
                return metodoFertilizacion;
            }
            set
            {
                metodoFertilizacion = value;
            }
        }

        public int InicioControl
        {
            get
            {
                return mesInicioControl;
            }
            set
            {
                mesInicioControl = value;
            }
        }

        public string Responsable
        {
            get
            {
                return responsableDeControl;
            }
            set
            {
                responsableDeControl = value;
            }
        }

        public string Enfermedades
        {
            get
            {
                return enfermedades;
            }
            set
            {
                enfermedades = value;
            }
        }
    }
}
