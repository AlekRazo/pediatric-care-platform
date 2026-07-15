using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers.Helpers
{
    public class Validaciones
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

        public static bool esNumeroDecimal(String cadena)
        {
            Regex patronDecimal = new Regex(@"^[0-9]{1,9}([\.\,][0-9]{1,3})?$");
            return patronDecimal.IsMatch(cadena);
        }

        public static bool esFraccionario(String cadena)
        {
            Regex patronDecimal = new Regex(@"^[0-9]{1,9}([/][0-9]{1,3})?$");
            return patronDecimal.IsMatch(cadena);
        }

        public static bool esCorreoElectronico(String cadena)
        {
            Regex regex = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            return regex.IsMatch(cadena);
        }
    }
}
