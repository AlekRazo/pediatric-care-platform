using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class CuidadoNatal
    {
        int idNatal;
        int idPaciente;
        string hospital;
        string tipoNacimiento;
        bool multiple;
        double pesoNacimiento;
        double tallaNacimiento;
        string indicaciones;

        public CuidadoNatal()
        {
        }

        //Getters, Setters

        public int IdNatal
        {
            get
            {
                return idNatal;
            }
            set
            {
                idNatal = value;
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

        public string Hospital
        {
            get
            {
                return hospital;
            }
            set
            {
                hospital = value;
            }
        }

        public string TipoNacimiento
        {
            get
            {
                return tipoNacimiento;
            }
            set
            {
                tipoNacimiento = value;
            }
        }

        public bool Multiple
        {
            get
            {
                return multiple;
            }
            set
            {
                multiple = value;
            }
        }

        public double PesoNacimiento
        {
            get
            {
                return pesoNacimiento;
            }
            set
            {
                pesoNacimiento = value;
            }
        }

        public double TallaNacimiento
        {
            get
            {
                return tallaNacimiento;
            }
            set
            {
                tallaNacimiento = value;
            }
        }

        public string Indicaciones
        {
            get
            {
                return indicaciones;
            }
            set
            {
                indicaciones = value;
            }
        }
    }
}
