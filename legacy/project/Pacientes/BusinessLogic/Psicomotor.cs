using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class Psicomotor
    {
        int idPsicomotor;
        int idPaciente;
        
        bool sostieneCabeza;
        
        bool sentado;
        int inicioSentado;
        
        bool gateo;
        int inicioGateo;
        
        bool controlEsfinter;
        int inicioControlEsfinter;
        
        bool rodado;
        int inicioRodado;
        
        bool bipedestacion;
        int inicioBipedestacion;
        
        bool deambulacion;
        int inicioDeambulacion;

        public Psicomotor()
        {
        }

        //Getter, Setters
        public int IdPsicomotor
        {
            get
            {
                return idPsicomotor;
            }
            set
            {
                idPsicomotor = value;
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

        public bool SostieneCabeza
        {
            get
            {
                return sostieneCabeza;
            }
            set
            {
                sostieneCabeza = value;
            }
        }

        public bool Sentado
        {
            get
            {
                return sentado;
            }
            set
            {
                sentado = value;
            }
        }

        public int InicioSentado
        {
            get
            {
                return inicioSentado;
            }
            set
            {
                inicioSentado = value;
            }
        }

        public bool Gateo
        {
            get
            {
                return gateo;
            }
            set
            {
                gateo = value;
            }
        }

        public int InicioGateo
        {
            get
            {
                return inicioGateo;
            }
            set
            {
                inicioGateo = value;
            }
        }

        public bool ControlEsfinter
        {
            get
            {
                return controlEsfinter;
            }
            set
            {
                controlEsfinter = value;
            }
        }

        public int InicioControlEsfinter
        {
            get
            {
                return inicioControlEsfinter;
            }
            set
            {
                inicioControlEsfinter = value;
            }
        }

        public bool Rodado
        {
            get
            {
                return rodado;
            }
            set
            {
                rodado = value;
            }
        }

        public int InicioRodado
        {
            get
            {
                return inicioRodado;
            }
            set
            {
                inicioRodado = value;
            }
        }

        public bool Bipedestacion
        {
            get
            {
                return bipedestacion;
            }
            set
            {
                bipedestacion = value;
            }
        }

        public int InicioBipedestacion
        {
            get
            {
                return inicioBipedestacion;
            }
            set
            {
                inicioBipedestacion = value;
            }
        }

        public bool Deambulacion
        {
            get
            {
                return deambulacion;
            }
            set
            {
                deambulacion = value;
            }
        }

        public int InicioDeambulacion
        {
            get
            {
                return inicioDeambulacion;
            }
            set
            {
                inicioDeambulacion = value;
            }
        }
    }
}
