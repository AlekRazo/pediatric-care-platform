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
        public static double ObtenerPercentilPeso(double peso, DateTime fechaNacimiento, DateTime fechaConsulta, string sexo)
        {
            int mesEdad = Math.Min(CalcularEdadMeses(fechaNacimiento, fechaConsulta), 60);
            ParametrosLMS parametros = CrecimientoDatos.obtenerParametrosLMS("Peso", mesEdad, sexo, "Unica");

            if (parametros == null)
            {
                return -1;
            }

            double z = LogicaPercentiles.calcularZ(peso, parametros);
            return LogicaPercentiles.calcularPercentil(z);
        }

        public static double ObtenerPercentilTalla(double talla, DateTime fechaNacimiento, DateTime fechaConsulta, string sexo)
        {
            int mesEdad = Math.Min(CalcularEdadMeses(fechaNacimiento, fechaConsulta), 60);
            string medicion = "";

            if (mesEdad < 24)
            {
                medicion = "Acostado";
            }
            else
            {
                medicion = "De_pie";
            }

            ParametrosLMS parametros = CrecimientoDatos.obtenerParametrosLMS("Talla", mesEdad, sexo, medicion);

            if (parametros == null) return -1;

            double z = LogicaPercentiles.calcularZ(talla, parametros);
            return LogicaPercentiles.calcularPercentil(z);
        }

        private static int CalcularEdadMeses(DateTime fechaNacimiento, DateTime fechaConsulta)
        {
            int meses = (fechaConsulta.Year - fechaNacimiento.Year) * 12 + (fechaConsulta.Month - fechaNacimiento.Month);

            if (fechaConsulta.Day < fechaNacimiento.Day)
            {
                meses--;
            }

            return meses;
        }

        public static List<EstadisticaDiagnostico> obtenerEstadisticasDiagnostico(DateTime fechaInicio, DateTime fechaFin, string filtroPaciente)
        {
            return EstadisticaDatos.obtenerEstadisticasDiagnostico(fechaInicio, fechaFin, filtroPaciente);
        }

        public static List<DiagnosticoPatologia> obtenerDiagnosticosPorPatologia(DateTime fechaInicio, DateTime fechaFin)
        {
            return EstadisticaDatos.obtenerDiagnosticosPorPatologia(fechaInicio, fechaFin);
        }

        public static List<PuntoCrecimiento> obtenerCurvaCrecimiento(int idPaciente)
        {
            return EstadisticaDatos.obtenerCurvaCrecimiento(idPaciente);
        }
    }
}
