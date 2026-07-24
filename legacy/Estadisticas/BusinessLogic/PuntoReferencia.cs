using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class PuntoReferencia
    {
        private double mesEdad;
        private double valor;

        public double MesEdad {
            get
            {
                return mesEdad;
            }
            set
            {
                mesEdad = value;
            }
        }

        public double Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
    }
}
