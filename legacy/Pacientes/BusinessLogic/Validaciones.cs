using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pacientes.BusinessLogic
{
    class Validaciones
    {
        public static bool esNumeroEntero(String cadena)
        {
            Regex patronNumerico = new Regex("[^0-9]");
            return !patronNumerico.IsMatch(cadena);
        }

        public static bool esAlfabetico(String cadena)
        {
            Regex patronAlfabetico = new Regex("[^a-zA-Z]");
            return !patronAlfabetico.IsMatch(cadena);
        }

        public static bool esAlfanumerico(String cadena)
        {
            Regex patronAlfanumerico = new Regex("[^a-zA-Z0-9]");
            return !patronAlfanumerico.IsMatch(cadena);
        }

        public static bool esCadena(String cadena)
        {
            Regex patronAlfabetico = new Regex(@"^[^ ][a-zA-Z ]+[^ ]$");
            return patronAlfabetico.IsMatch(cadena);
        }
    }
}
