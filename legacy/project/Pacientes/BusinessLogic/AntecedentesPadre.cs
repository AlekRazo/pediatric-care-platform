using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class AntecedentesPadre
    {
        int idAntecedente;
        int idPaciente;
        string nombre;
        DateTime fechaNacimiento;
        string ocupacion;
        bool tabaquismo;
        bool alcoholismo;
        bool hipertension;
        string dismorfologicos;
        string toxicomanias;
        
        bool diabetes;
        bool cancer;
        string tiposCancer;
        string alergias;
        string otros;                
        string medicamentos;
        string estadoActual;

        public AntecedentesPadre()
        {
        }

        //Getters, Setters
        //Getters, Setters
        public int IdAntecedente
        {
            get
            {
                return idAntecedente;
            }
            set
            {
                idAntecedente = value;
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

        public string Ocupacion
        {
            get
            {
                return ocupacion;
            }
            set
            {
                ocupacion = value;
            }
        }

        public bool Tabaquismo
        {
            get
            {
                return tabaquismo;
            }
            set
            {
                tabaquismo = value;
            }
        }

        public bool Alcoholismo
        {
            get
            {
                return alcoholismo;
            }
            set
            {
                alcoholismo = value;
            }
        }

        public string Toxicomanias
        {
            get
            {
                return toxicomanias;
            }
            set
            {
                toxicomanias = value;
            }
        }

        public string Alergias
        {
            get
            {
                return alergias;
            }
            set
            {
                alergias = value;
            }
        }

        public bool Diabetes
        {
            get
            {
                return diabetes;
            }
            set
            {
                diabetes = value;
            }
        }

        public bool Hipertension
        {
            get
            {
                return hipertension;
            }
            set
            {
                hipertension = value;
            }
        }

        public string Dismorfologicos
        {
            get
            {
                return dismorfologicos;
            }
            set
            {
                dismorfologicos = value;
            }
        }

        public bool Cancer
        {
            get
            {
                return cancer;
            }
            set
            {
                cancer = value;
            }
        }

        public string TiposCancer
        {
            get
            {
                return tiposCancer;
            }
            set
            {
                tiposCancer = value;
            }
        }

        public string Otros
        {
            get
            {
                return otros;
            }
            set
            {
                otros = value;
            }
        }

        public string Medicamentos
        {
            get
            {
                return medicamentos;
            }
            set
            {
                medicamentos = value;
            }
        }

        public string EstadoActual
        {
            get
            {
                return estadoActual;
            }
            set
            {
                estadoActual = value;
            }
        }
    }
}
