using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class CurvaPercentil
    {
        private bool esPaciente;
        private string nombre;
        private List<PuntoReferencia> puntos;

        public bool EsPaciente
        {
            get
            {
                return esPaciente;
            }
            set
            {
                esPaciente = value;
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

        public List<PuntoReferencia> Puntos
        {
            get
            {
                return puntos;
            }
            set
            {
                puntos = value;
            }
        }
    }
}
