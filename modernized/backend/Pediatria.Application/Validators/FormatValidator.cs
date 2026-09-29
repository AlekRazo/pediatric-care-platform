using System.Text.RegularExpressions;

namespace Pediatria.Application.Validators;

public class Validaciones
{
    public static bool isInteger (String cadena)
    {
        Regex patronNumerico = new Regex("[^0-9]");
        return !patronNumerico.IsMatch(cadena);
    }

    public static bool isAlphabetic(String cadena)
    {
        Regex patronAlfabetico = new Regex("[^a-zA-Z]");
        return !patronAlfabetico.IsMatch(cadena);
    }

    public static bool isAlphanumeric(String cadena)
    {
        Regex patronAlfanumerico = new Regex("[^a-zA-Z0-9]");
        return !patronAlfanumerico.IsMatch(cadena);
    }

    public static bool isString(String cadena)
    {
        Regex patronAlfabetico = new Regex(@"^[^ ][a-zA-Z ]+[^ ]$");
        return patronAlfabetico.IsMatch(cadena);
    }

    public static bool isDecimal(String cadena)
    {
        Regex patronDecimal = new Regex(@"^[0-9]{1,9}([\.\,][0-9]{1,3})?$");
        return patronDecimal.IsMatch(cadena);
    }

    public static bool isFraction(String cadena)
    {
        Regex patronDecimal = new Regex(@"^[0-9]{1,9}([/][0-9]{1,3})?$");
        return patronDecimal.IsMatch(cadena);
    }

    public static bool isEmail(String cadena)
    {
        Regex regex = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
        return regex.IsMatch(cadena);
    }

    public static bool isValidDateRange(DateTime fechaInicio, DateTime fechaFin)
    {
        return fechaInicio.Date <= fechaFin.Date;
    }
}