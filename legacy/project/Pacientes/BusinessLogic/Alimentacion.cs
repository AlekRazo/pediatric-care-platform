using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class Alimentacion
    {
        int idAlimentacion;
        int idPaciente;
        
        bool pecho;
        int mesInicioPecho;
        
        string tipoFormula;
        int mesInicioFormula;
        
        bool cereal;
        int mesInicioCereal;
        
        bool frutas;
        int inicioFrutas;
        int inicioCitricos;
        
        bool verduras;
        int inicioVerduras;
        int inicioTomate;

        public Alimentacion()
        {
        }

        //Getters, Setters
        public int IdAlimentacion
        {
            get
            {
                return idAlimentacion;
            }
            set
            {
                idAlimentacion = value;
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

        public bool Pecho
        {
            get
            {
                return pecho;
            }
            set
            {
                pecho = value;
            }
        }

        public int MesInicioPecho
        {
            get
            {
                return mesInicioPecho;
            }
            set
            {
                mesInicioPecho = value;
            }
        }

        public string TipoFormula
        {
            get
            {
                return tipoFormula;
            }
            set
            {
                tipoFormula = value;
            }
        }

        public int MesInicioFormula
        {
            get
            {
                return mesInicioFormula;
            }
            set
            {
                mesInicioFormula = value;
            }
        }

        public bool Cereal
        {
            get
            {
                return cereal;
            }
            set
            {
                cereal = value;
            }
        }

        public int MesInicioCereal
        {
            get
            {
                return mesInicioCereal;
            }
            set
            {
                mesInicioCereal = value;
            }
        }

        public bool Frutas
        {
            get
            {
                return frutas;
            }
            set
            {
                frutas = value;
            }
        }

        public int InicioFrutas
        {
            get
            {
                return inicioFrutas;
            }
            set
            {
                inicioFrutas = value;
            }
        }

        public int InicioCitricos
        {
            get
            {
                return inicioCitricos;
            }
            set
            {
                inicioCitricos = value;
            }
        }

        public bool Verduras
        {
            get
            {
                return verduras;
            }
            set
            {
                verduras = value;
            }
        }

        public int InicioVerduras
        {
            get
            {
                return inicioVerduras;
            }
            set
            {
                inicioVerduras = value;
            }
        }

        public int InicioTomate
        {
            get
            {
                return inicioTomate;
            }
            set
            {
                inicioTomate = value;
            }
        }
    }
}
