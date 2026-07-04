using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recetas.BusinessLogic
{
    public class Receta
    {
        int idReceta;
        int idConsulta;
        int idPaciente;
        DateTime fechaConsulta;
        double peso;
        double talla;
        string descripcion;

        public Receta()
        {
        }

        public int IdRecete
        {
            get
            {
                return idReceta;
            }
            set
            {
                idReceta = value;
            }
        }

        public int IdConsulta
        {
            get
            {
                return idConsulta;
            }
            set
            {
                idConsulta = value;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }
    }
}
