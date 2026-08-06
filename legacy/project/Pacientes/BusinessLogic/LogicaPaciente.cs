using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pacientes.DataAccess;

namespace Pacientes.BusinessLogic
{
    class LogicaPaciente
    {
        public static int registrarPaciente(Alergias objAlergias, Alimentacion objAlimentacion, AntecedentesMadre objAntecedentesMadre, AntecedentesPadre objAntecedentesPadre, CuidadoPrenatal objCuidadoPrenatal, CuidadoNatal objCuidadoNatal, CuidadoPosnatal objCuidadoPosnatal, Paciente objPaciente, Psicomotor objPsicomotor, Vacunacion objVacunacion)
        {
            //Valida que el nombre del Paciente no esté vacío (Error -1 si no cumple)
            if (String.IsNullOrWhiteSpace(objPaciente.NombrePaciente))
            {
                return -1;
            }
            else
            {
                //Valida que el nombre de la madre no esté vacío (Error -2 si no cumple)
                if (String.IsNullOrWhiteSpace(objPaciente.NombreMadre))
                {
                    return -2;
                }
                else
                {
                    //Inserta datos en la base de datos (Mensaje 1 si ha éxito, Mensaje 0 si fracasa)
                    if (PacienteDatos.registrarDatosDePaciente(objAlergias, objAlimentacion, objAntecedentesMadre, objAntecedentesPadre, objCuidadoPrenatal, objCuidadoNatal, objCuidadoPosnatal, objPaciente, objPsicomotor, objVacunacion))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static int modificarPaciente(Alergias objAlergias, Alimentacion objAlimentacion, AntecedentesMadre objAntecedentesMadre, AntecedentesPadre objAntecedentesPadre, CuidadoPrenatal objCuidadoPrenatal, CuidadoNatal objCuidadoNatal, CuidadoPosnatal objCuidadoPosnatal, Paciente objPaciente, Psicomotor objPsicomotor, Vacunacion objVacunacion)
        {
            //Valida que el nombre del Paciente no esté vacío (Error -1 si no cumple)
            if (String.IsNullOrWhiteSpace(objPaciente.NombrePaciente))
            {
                return -1;
            }
            else
            {
                //Valida que el nombre de la madre no esté vacío (Error -2 si no cumple)
                if (String.IsNullOrWhiteSpace(objPaciente.NombreMadre))
                {
                    return -2;
                }
                else
                {
                    //Inserta datos en la base de datos (Mensaje 1 si ha éxito, Mensaje 0 si fracasa)
                    if (PacienteDatos.modificarDatosDePaciente(objAlergias, objAlimentacion, objAntecedentesMadre, objAntecedentesPadre, objCuidadoPrenatal, objCuidadoNatal, objCuidadoPosnatal, objPaciente, objPsicomotor, objVacunacion))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static bool eliminarPaciente(int idPaciente)
        {
            return PacienteDatos.eliminarDatosDePaciente(idPaciente);
        }
    }
}
