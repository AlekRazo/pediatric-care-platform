using Estadisticas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estadisticas.BusinessLogic
{
    class LogicaPercentiles
    {
        public static double calcularZ(double valor, ParametrosLMS lms)
        {
            if (lms.L == 0)
            {
                return Math.Log(valor / lms.M) / lms.S;
            }
            else
            {
                return (Math.Pow((valor / lms.M), lms.L) - 1) / (lms.L * lms.S);
            }
        }

        public static double calcularPercentil(double z)
        {
            double t = 1 / (1 + 0.2316419 * Math.Abs(z));
            double phiZ = (1 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-z * z / 2.0);
            double b1 = 0.319381530;
            double b2 = -0.356563782;
            double b3 = 1.781477937;
            double b4 = -1.821255978;
            double b5 = 1.330274429;

            double fz = 1 - phiZ * (b1 * t + b2 * Math.Pow(t, 2) + b3 * Math.Pow(t, 3) + b4 * Math.Pow(t, 4) + b5 * Math.Pow(t, 5));

            if (z >= 0)
            {
                return fz * 100;

            }
            else
            {
                return (1 - fz) * 100;
            }
        }

        public static double obtenerValorEsperado(double z, ParametrosLMS lms)
        {
            if (lms.L == 0)
            {
                return lms.M * Math.Exp(lms.S * z);
            }
            else
            {
                return lms.M * Math.Pow((1 + lms.L * lms.S * z), (1 / lms.L));
            }
        }
    }
}
