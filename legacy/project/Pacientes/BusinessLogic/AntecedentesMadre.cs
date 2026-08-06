using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacientes.BusinessLogic
{
    class AntecedentesMadre : AntecedentesPadre
    {
        int embarazos;
        int partos;
        int abortos;
        int cesareas;

        public AntecedentesMadre()
        {
        }

        //Getters, Setters
        public int Embarazos
        {
            get
            {
                return embarazos;
            }
            set
            {
                embarazos = value;
            }
        }

        public int Partos
        {
            get
            {
                return partos;
            }
            set
            {
                partos = value;
            }
        }

        public int Abortos
        {
            get
            {
                return abortos;
            }
            set
            {
                abortos = value;
            }
        }

        public int Cesareas
        {
            get
            {
                return cesareas;
            }
            set
            {
                cesareas = value;
            }
        }
    }
}
