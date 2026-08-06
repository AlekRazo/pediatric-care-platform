using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Citas.DataAccess;

namespace Citas.BusinessLogic
{
    class LogicaFechas
    {
        public static List<Fecha> obtenerFechasNoHabiles()
        {
            return CitaDatos.obtenerFechasNoHabiles();
        }

        public static bool existeFecha(DateTime fecha)
        {
            DateTime fechaRetorno = CitaDatos.obtenerFecha(fecha);

            if (fecha == fechaRetorno)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int agregarFechaNoHabil(DateTime fecha)
        {
            return CitaDatos.agregarFechaNoHabil(fecha);
        }

        public static int agregarFechasPorRango(DateTime fechaInicio, DateTime fechaFinal)
        {
            return CitaDatos.agregarFechasNoHablesPorRango(fechaInicio, fechaFinal);
        }

        public static int eliminarFechaNoHabil(DateTime fecha)
        {
            return CitaDatos.eliminarFechaHabil(fecha);
        }
    }
}
