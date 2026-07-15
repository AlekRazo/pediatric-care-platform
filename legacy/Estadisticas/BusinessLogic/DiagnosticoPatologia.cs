using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class DiagnosticoPatologia
    {
        string patologia;
        int cantidad;

        public DiagnosticoPatologia() 
        {
        }

        public string Patologia
        {
            get
            {
                return patologia;
            }
            set
            {
                patologia = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
    }
}
