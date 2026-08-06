using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class PuntoCrecimiento
    {
        int idPaciente;
        DateTime fechaConsulta;
        int edadMeses;
        double peso;
        double talla;
        double perimetroCefalico;

        public PuntoCrecimiento()
        {
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

        public DateTime FechaConsulta
        {
            get
            {
                return fechaConsulta;
            }
            set
            {
                fechaConsulta = value;
            }
        }

        public int EdadMeses
        {
            get
            {
                return edadMeses;
            }
            set
            {
                edadMeses = value;
            }
        }

        public double Peso
        {
            get
            {
                return peso;
            }
            set
            {
                peso = value;
            }
        }

        public double Talla
        {
            get
            {
                return talla;
            }
            set
            {
                talla = value;
            }
        }

        public double PerimetroCefalico
        {
            get
            {
                return perimetroCefalico;
            }
            set
            {
                perimetroCefalico = value;
            }
        }
    }
}
