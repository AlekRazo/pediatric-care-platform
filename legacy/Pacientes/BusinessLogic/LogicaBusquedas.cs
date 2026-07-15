using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Helpers;
using Pacientes.DataAccess;

namespace Pacientes.BusinessLogic
{
    class LogicaBusquedas
    {
        public static List<Paciente> obtenerTodosLosPacientes()
        {
            return PacienteBusqueda.obtenerDatosDeTodosLosPacientes();
        }

        public static List<Paciente> obtenerPacientesPorNombre(string nombre)
        {
            if (!(String.IsNullOrWhiteSpace(nombre)) && Validaciones.esCadena(nombre))
            {
                return PacienteBusqueda.obtenerDatosDePacientePorNombre(nombre);
            }
            else
            {
                return new List<Paciente>();
            }
        }

        public static List<Paciente> obtenerPacientesPorNombreMadre(string nombreMadre)
        {
            if (!(String.IsNullOrWhiteSpace(nombreMadre)) || Validaciones.esCadena(nombreMadre))
            {
                return new List<Paciente>();
            }
            else
            {
                return PacienteBusqueda.obtenerDatosDePacientePorNombreMadre(nombreMadre);
            }
        }

        public static List<Paciente> obtenerPacientesPorNombrePadre(string nombrePadre)
        {
            if (!(String.IsNullOrWhiteSpace(nombrePadre)) || Validaciones.esCadena(nombrePadre))
            {
                return new List<Paciente>();
            }
            else
            {
                return PacienteBusqueda.obtenerDatosDePacientePorNombrePadre(nombrePadre);
            }
        }

        public static List<Paciente> obtenerPacientesPorTipoSangre(string tipoSangre)
        {
            if (String.IsNullOrWhiteSpace(tipoSangre))
            {
                return new List<Paciente>();
            }
            else
            {
                if (tipoSangre == "A+" || tipoSangre == "A-" || tipoSangre == "B+" || tipoSangre == "B-" || tipoSangre == "AB+" || tipoSangre == "AB-" || tipoSangre == "O+" || tipoSangre == "O-")
                {
                    return PacienteBusqueda.obtenerDatosDePacientePorTipoSangre(tipoSangre);
                }
                else
                {
                    return new List<Paciente>();
                }
            }
        }

        public static List<Paciente> obtenerPacientesPorEdad(int edad)
        {
            return obtenerPacientesPorEdad(edad);
        }

        public static List<Paciente> obtenerPacientesPorSexo(string sexo)
        {
            if (String.IsNullOrWhiteSpace(sexo) || Validaciones.esAlfabetico(sexo))
            {
                return new List<Paciente>();
            }
            else
            {
                if (sexo == "Femenino" || sexo == "Masculino")
                {
                    return PacienteBusqueda.obtenerDatosDePacientePorSexo(sexo);
                }
                else
                {
                    return new List<Paciente>();
                }
            }
        }

        public static Paciente obtenerPaciente(int idPaciente)
        {
            return PacienteBusqueda.obtenerDatosDePaciente(idPaciente);
        }

        public static Alergias obtenerAlergias(int idPaciente)
        {
            return PacienteBusqueda.obtenerAlergiasDePaciente(idPaciente);
        }

        public static Alimentacion obtenerAlimentacion(int idPaciente)
        {
            return PacienteBusqueda.obtenerAlimentacionDePaciente(idPaciente);
        }

        public static AntecedentesMadre obtenerAntecedentesMadre(int idPaciente)
        {
            return PacienteBusqueda.obtenerAntecedentesMadreDePaciente(idPaciente);
        }

        public static AntecedentesPadre obtenerAntecedentesPadre(int idPaciente)
        {
            return PacienteBusqueda.obtenerAntecedentesPadreDePaciente(idPaciente);
        }

        public static CuidadoPrenatal obtenerCuidadoPrenatal(int idPaciente)
        {
            return PacienteBusqueda.obtenerCuidadoPrenatalDePaciente(idPaciente);
        }

        public static CuidadoNatal obtenerCuidadoNatal(int idPaciente)
        {
            return PacienteBusqueda.obtenerCuidadoNatalDePaciente(idPaciente);
        }

        public static CuidadoPosnatal obtenerCuidadoPosatal(int idPaciente)
        {
            return PacienteBusqueda.obtenerCuidadoPosnatalDePaciente(idPaciente);
        }

        public static Psicomotor obtenerDatosPsicomotor(int idPaciente)
        {
            return PacienteBusqueda.obtenerDatosPsicomotorDePaciente(idPaciente);
        }

        public static Vacunacion obtenerDatosVacunacion(int idPaciente)
        {
            return PacienteBusqueda.obtenerDatosVacunacionDePaciente(idPaciente);
        }

        public static List<Historial> obtenerHistorialPaciente(int idPaciente)
        {
            return PacienteBusqueda.obtenerHistorialDePaciente(idPaciente);
        }
    }
}
