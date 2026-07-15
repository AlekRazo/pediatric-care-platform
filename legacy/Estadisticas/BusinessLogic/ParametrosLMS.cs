using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class ParametrosLMS
    {
        private double l;
        private double m;
        private double s;

        public double L {
            get {
                return l;
            }
            set {
                l = value;
            }
        }

        public double M {
            get {
                return m;
            }
            set
            {
                m = value;
            }
        }

        public double S { get { return s; } set { s = value; } }
    }
}
