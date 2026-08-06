using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class Alergias
    {
        int idAlergias;
        int idPaciente;
        bool alergiaMedicamentos;
        string medicamentos;
        bool alergiaAlimentos;
        string alimentos;
        bool alergiaFlora;
        string flora;
        bool alergiaRopa;
        string ropa;

        public Alergias()
        {
        }

        //Getters, Setters
        public int IdAlergias
        {
            get
            {
                return idAlergias;
            }
            set
            {
                idAlergias = value;
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

        public bool AlergiaMedicamentos
        {
            get
            {
                return alergiaMedicamentos;
            }
            set
            {
                alergiaMedicamentos = value;
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

        public bool AlergiaAlimentos
        {
            get
            {
                return alergiaAlimentos;
            }
            set
            {
                alergiaAlimentos = value;
            }
        }

        public string Alimentos
        {
            get
            {
                return alimentos;
            }
            set
            {
                alimentos = value;
            }
        }

        public bool AlergiaFlora
        {
            get
            {
                return alergiaFlora;
            }
            set
            {
                alergiaFlora = value;
            }
        }

        public string Flora
        {
            get
            {
                return flora;
            }
            set
            {
                flora = value;
            }
        }

        public bool AlergiaRopa
        {
            get
            {
                return alergiaRopa;
            }
            set
            {
                alergiaRopa = value;
            }
        }

        public string Ropa
        {
            get
            {
                return ropa;
            }
            set
            {
                ropa = value;
            }
        }
    }
}
