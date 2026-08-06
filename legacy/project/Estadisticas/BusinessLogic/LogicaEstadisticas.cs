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
            Paciente paciente = LogicaPercentiles.obtenerPacientePorId(idPaciente);
            List<PuntoCrecimiento> crecimiento = EstadisticaDatos.obtenerCurvaCrecimiento(idPaciente);

            foreach (PuntoCrecimiento item in crecimiento)
            {
                item.EdadMeses = LogicaPercentiles.calcularEdadMeses(paciente.FechaNacimiento, item.FechaConsulta);
            }

            return crecimiento;
        }
    }
}
