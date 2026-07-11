using Estadisticas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    public class LogicaEstadisticas
    {
        public static double calcularIMC(double peso, double talla)
        {
            if (talla <= 0)
            {
                return 0;
            }
            double imc = peso / (talla * talla);
            return Math.Round(imc, 2);
        }

        public static int calcularPercentil(int tipo, int meses, string sexo, double valor)
        {
            string parametro = "";

            if (tipo == 1)
            {
                parametro = "Talla";
            }
            if(tipo == 2)
            {
                parametro = "Peso";
            }
            if(tipo == 3)
            {
                parametro = "PerimetroCefalico";
            }
            else
            {
                return -1;
            }

            LMS lms = EstadisticaDatos.obtenerParametrosPercentil(parametro, meses, sexo, valor);

            double z = (Math.Pow((valor / lms.M), lms.L) - 1) / (lms.L * lms.S);
            return (int) (z* 100);
        }
    }
}
