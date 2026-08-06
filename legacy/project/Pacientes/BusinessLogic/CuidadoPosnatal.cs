using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class CuidadoPosnatal
    {
        int idPosnatal;
        int idPaciente;
        bool necesidadVigilancia;
        bool respirador;
        bool incubadora;
        string fototerapias;
        string otros;

        public CuidadoPosnatal()
        {
        }

        //Getters, Setters
        public int IdPosnatal
        {
            get
            {
                return idPosnatal;
            }
            set
            {
                idPosnatal = value;
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

        public bool NecesidadVigilancia
        {
            get
            {
                return necesidadVigilancia;
            }
            set
            {
                necesidadVigilancia = value;
            }
        }

        public bool Respirador
        {
            get
            {
                return respirador;
            }
            set
            {
                respirador = value;
            }
        }

        public bool Incubadora
        {
            get
            {
                return incubadora;
            }
            set
            {
                incubadora = value;
            }
        }

        public string Fototerapias
        {
            get
            {
                return fototerapias;
            }
            set
            {
                fototerapias = value;
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
    }
}
