using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Consultas.DataAcces;

namespace Consultas.BusinessLogic
{
    class LogicaConsulta
    {
        public static int nuevaConsulta(Consulta objConsulta)
        {
            return ConsultaDatos.guardarDatosDeConsulta(objConsulta);
        }

        public static Consulta obtenerConsulta(int idConsulta)
        {
            return ConsultaDatos.obtenerConsulta(idConsulta);
        }
    }
}
