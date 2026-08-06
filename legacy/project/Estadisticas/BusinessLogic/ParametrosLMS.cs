using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class ParametrosLMS
    {
        private string indicador;
        private int mesEdad;
        private double l;
        private double m;
        private double s;
        private string medicion;

        public string Indicador
        {
            get
            {
                return indicador;
            }
            set
            {
                indicador = value;
            }
        }

        public int MesEdad
        {
            get
            {
                return mesEdad;
            }
            set
            {
                mesEdad = value;
            }
        }

        public double L
        {
            get
            {
                return l;
            }
            set
            {
                l = value;
            }
        }

        public double M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }

        public double S
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        public string Medicion
        {
            get
            {
                return medicion;
            }
            set
            {
                medicion = value;
            }
        }
    }
}
