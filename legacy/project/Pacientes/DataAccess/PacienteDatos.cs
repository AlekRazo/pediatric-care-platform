using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pacientes.BusinessLogic;
using System.Data.SqlClient;
using System.Data;

namespace Pacientes.DataAccess
{
    class PacienteDatos
    {
        private static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Pediatria; Integrated Security=True");

        public static bool registrarDatosDePaciente(Alergias objAlergias, Alimentacion objAlimentacion, AntecedentesMadre objAntecedentesMadre, AntecedentesPadre objAntecedentesPadre, CuidadoPrenatal objCuidadoPrenatal, CuidadoNatal objCuidadoNatal, CuidadoPosnatal objCuidadoPosnatal, Paciente objPaciente, Psicomotor objPsicomotor, Vacunacion objVacunacion)
        {
            bool resultado = false;
            SqlTransaction transaction;

            conn.Open();
            transaction = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("AltaPaciente", conn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Datos Paciente

                cmd.Parameters.AddWithValue("@nombre", objPaciente.NombrePaciente);
                cmd.Parameters.AddWithValue("@nombreMadre", objPaciente.NombreMadre);
                cmd.Parameters.AddWithValue("@nombrePadre", objPaciente.NombrePadre);
                cmd.Parameters.AddWithValue("@nombreTutor", objPaciente.NombreTutor);
                cmd.Parameters.AddWithValue("@afiliacion", objPaciente.Afiliacion);
                cmd.Parameters.AddWithValue("@numeroSeguro", objPaciente.NumeroSeguro);
                cmd.Parameters.AddWithValue("@domicilio", objPaciente.Domicilio);
                cmd.Parameters.AddWithValue("@codigoPostal", objPaciente.CodigoPostal);
                cmd.Parameters.AddWithValue("@fechaNac", objPaciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@lugarNac", objPaciente.LugarNacimiento);
                cmd.Parameters.AddWithValue("@telefonoCasa", objPaciente.TelefonoCasa);
                cmd.Parameters.AddWithValue("@telefonoCel", objPaciente.TelefonoCelular);
                cmd.Parameters.AddWithValue("@sexo", objPaciente.Sexo);
                cmd.Parameters.AddWithValue("@tipoSangre", objPaciente.TipoSangre);
                //cmd.Parameters.AddWithValue("@fotografia", objPaciente.Fotografia);
                cmd.Parameters.AddWithValue("@observaciones", objPaciente.Observaciones);

                //Alergias
                
                cmd.Parameters.AddWithValue("@alergiaMedicamentos", objAlergias.AlergiaAlimentos);
                cmd.Parameters.AddWithValue("@medicamentos", objAlergias.Medicamentos);
                cmd.Parameters.AddWithValue("@alergiaAlimentos", objAlergias.AlergiaAlimentos);
                cmd.Parameters.AddWithValue("@alimentos", objAlergias.Alimentos);
                cmd.Parameters.AddWithValue("@alergiaFlora", objAlergias.AlergiaFlora);
                cmd.Parameters.AddWithValue("@flora", objAlergias.Flora);
                cmd.Parameters.AddWithValue("@alergiaRopa", objAlergias.AlergiaRopa);
                cmd.Parameters.AddWithValue("@ropa", objAlergias.Ropa);

                //Alimentacion
                
                cmd.Parameters.AddWithValue("@pecho", objAlimentacion.Pecho);
                cmd.Parameters.AddWithValue("@inicioPecho", objAlimentacion.MesInicioPecho);
                cmd.Parameters.AddWithValue("@tipoFormula", objAlimentacion.TipoFormula);
                cmd.Parameters.AddWithValue("@inicioFormula", objAlimentacion.MesInicioFormula);
                cmd.Parameters.AddWithValue("@cereal", objAlimentacion.Cereal);
                cmd.Parameters.AddWithValue("@inicioCereal", objAlimentacion.MesInicioCereal);
                cmd.Parameters.AddWithValue("@frutas", objAlimentacion.Frutas);
                cmd.Parameters.AddWithValue("@inicioFrutas", objAlimentacion.InicioFrutas);
                cmd.Parameters.AddWithValue("@inicioCitricos", objAlimentacion.InicioCitricos);
                cmd.Parameters.AddWithValue("@verduras", objAlimentacion.Verduras);
                cmd.Parameters.AddWithValue("@inicioVerduras", objAlimentacion.InicioVerduras);
                cmd.Parameters.AddWithValue("@inicioTomate", objAlimentacion.InicioTomate);

                //AntecedentesMadre
                
                cmd.Parameters.AddWithValue("@fechaNacMadre", objAntecedentesMadre.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ocupacionMadre", objAntecedentesMadre.Ocupacion);
                cmd.Parameters.AddWithValue("@tabaquismoMadre", objAntecedentesMadre.Tabaquismo);
                cmd.Parameters.AddWithValue("@alcoholismoMadre", objAntecedentesMadre.Alcoholismo);
                cmd.Parameters.AddWithValue("@toxicomaniasMadre", objAntecedentesMadre.Toxicomanias);
                cmd.Parameters.AddWithValue("@alergiasMadre", objAntecedentesMadre.Alergias);
                cmd.Parameters.AddWithValue("@diabetesMadre", objAntecedentesMadre.Diabetes);
                cmd.Parameters.AddWithValue("@hipertensionMadre", objAntecedentesMadre.Hipertension);
                cmd.Parameters.AddWithValue("@dismorfologicosMadre", objAntecedentesMadre.Dismorfologicos);
                cmd.Parameters.AddWithValue("@cancerMadre", objAntecedentesMadre.Cancer);
                cmd.Parameters.AddWithValue("@tiposCancerMadre", objAntecedentesMadre.TiposCancer);
                cmd.Parameters.AddWithValue("@otrosMadre", objAntecedentesMadre.Otros);
                cmd.Parameters.AddWithValue("@medicamentosMadre", objAntecedentesMadre.Medicamentos);
                cmd.Parameters.AddWithValue("@estadoActualMadre", objAntecedentesMadre.EstadoActual);
                cmd.Parameters.AddWithValue("@embarazos", objAntecedentesMadre.Embarazos);
                cmd.Parameters.AddWithValue("@partos", objAntecedentesMadre.Partos);
                cmd.Parameters.AddWithValue("@abortos", objAntecedentesMadre.Abortos);
                cmd.Parameters.AddWithValue("@cesareas", objAntecedentesMadre.Cesareas);

                //Antecedentes Padre

                cmd.Parameters.AddWithValue("@fechaNacPadre", objAntecedentesPadre.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ocupacionPadre", objAntecedentesPadre.Ocupacion);
                cmd.Parameters.AddWithValue("@tabaquismoPadre", objAntecedentesPadre.Tabaquismo);
                cmd.Parameters.AddWithValue("@alcoholismoPadre", objAntecedentesPadre.Alcoholismo);
                cmd.Parameters.AddWithValue("@toxicomaniasPadre", objAntecedentesPadre.Toxicomanias);
                cmd.Parameters.AddWithValue("@alergiasPadre", objAntecedentesPadre.Alergias);
                cmd.Parameters.AddWithValue("@diabetesPadre", objAntecedentesPadre.Diabetes);
                cmd.Parameters.AddWithValue("@hipertensionPadre", objAntecedentesPadre.Hipertension);
                cmd.Parameters.AddWithValue("@dismorfologicosPadre", objAntecedentesPadre.Dismorfologicos);
                cmd.Parameters.AddWithValue("@cancerPadre", objAntecedentesPadre.Cancer);
                cmd.Parameters.AddWithValue("@tiposCancerPadre", objAntecedentesPadre.TiposCancer);
                cmd.Parameters.AddWithValue("@otrosPadre", objAntecedentesPadre.Otros);
                cmd.Parameters.AddWithValue("@medicamentosPadre", objAntecedentesPadre.Medicamentos);
                cmd.Parameters.AddWithValue("@estadoActualPadre", objAntecedentesMadre.EstadoActual);

                //Cuidado Prenatal

                cmd.Parameters.AddWithValue("@planeado", objCuidadoPrenatal.Planeado);
                cmd.Parameters.AddWithValue("@metodoFertilizacion", objCuidadoPrenatal.MetodoFertilizacion);
                cmd.Parameters.AddWithValue("@mesInicioControl", objCuidadoPrenatal.InicioControl);
                cmd.Parameters.AddWithValue("@responsable", objCuidadoPrenatal.Responsable);
                cmd.Parameters.AddWithValue("@enfermedades", objCuidadoPrenatal.Enfermedades);

                //Cuidado Natal

                cmd.Parameters.AddWithValue("@hospital", objCuidadoNatal.Hospital);
                cmd.Parameters.AddWithValue("@tipoNacimiento", objCuidadoNatal.TipoNacimiento);
                cmd.Parameters.AddWithValue("@multiple", objCuidadoNatal.Multiple);
                cmd.Parameters.AddWithValue("@pesoNac", objCuidadoNatal.PesoNacimiento);
                cmd.Parameters.AddWithValue("@tallaNac", objCuidadoNatal.TallaNacimiento);
                cmd.Parameters.AddWithValue("@indicaciones", objCuidadoNatal.Indicaciones);

                //Cuidado Posnatal
                
                cmd.Parameters.AddWithValue("@necesidadVigilancia", objCuidadoPosnatal.NecesidadVigilancia);
                cmd.Parameters.AddWithValue("@respirador", objCuidadoPosnatal.Respirador);
                cmd.Parameters.AddWithValue("@incubadora", objCuidadoPosnatal.Incubadora);
                cmd.Parameters.AddWithValue("@fototerapia", objCuidadoPosnatal.Fototerapias);
                cmd.Parameters.AddWithValue("@otros", objCuidadoPosnatal.Otros);

                //Psicomotor
                
                cmd.Parameters.AddWithValue("@sostieneCabeza", objPsicomotor.SostieneCabeza);
                cmd.Parameters.AddWithValue("@sentado", objPsicomotor.Sentado);
                cmd.Parameters.AddWithValue("@inicioSentado", objPsicomotor.Sentado);
                cmd.Parameters.AddWithValue("@gateo", objPsicomotor.Gateo);
                cmd.Parameters.AddWithValue("@inicioGateo", objPsicomotor.InicioGateo);
                cmd.Parameters.AddWithValue("@controlEsfinter", objPsicomotor.ControlEsfinter);
                cmd.Parameters.AddWithValue("@inicioControlEsfinter", objPsicomotor.InicioControlEsfinter);
                cmd.Parameters.AddWithValue("@rodado", objPsicomotor.Rodado);
                cmd.Parameters.AddWithValue("@inicioRodado", objPsicomotor.InicioRodado);
                cmd.Parameters.AddWithValue("@bipedestacion", objPsicomotor.Bipedestacion);
                cmd.Parameters.AddWithValue("@inicioBipedestacion", objPsicomotor.InicioBipedestacion);
                cmd.Parameters.AddWithValue("@deambulacion", objPsicomotor.Deambulacion);
                cmd.Parameters.AddWithValue("@inicioDeambulacion", objPsicomotor.InicioDeambulacion);

                //Vacunacion
                
                cmd.Parameters.AddWithValue("@hepatitisA", objVacunacion.HepatitisA);
                cmd.Parameters.AddWithValue("@hepatitisB", objVacunacion.HepatitisB);
                cmd.Parameters.AddWithValue("@hib", objVacunacion.HIB);
                cmd.Parameters.AddWithValue("@meningococo", objVacunacion.Meningococo);
                cmd.Parameters.AddWithValue("@bpt", objVacunacion.BPT);
                cmd.Parameters.AddWithValue("@poliomielitis", objVacunacion.Poliomielitis);
                cmd.Parameters.AddWithValue("@rotavirus", objVacunacion.Rotavirus);
                cmd.Parameters.AddWithValue("@neumococo", objVacunacion.Neumococo);
                cmd.Parameters.AddWithValue("@influenza", objVacunacion.Influenza);
                cmd.Parameters.AddWithValue("@mmr", objVacunacion.MMR);
                cmd.Parameters.AddWithValue("@varicela", objVacunacion.Varicela);
                cmd.Parameters.AddWithValue("@hpv", objVacunacion.HPV);
                cmd.Parameters.AddWithValue("@tuberculosis", objVacunacion.Tuberculosis);

                int columnasNuevas = cmd.ExecuteNonQuery();

                if (columnasNuevas > 0)
                {
                    transaction.Commit();
                    resultado = true;
                    cmd.Dispose();
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
            }

            
            conn.Close();

            return resultado;
        }

        public static bool modificarDatosDePaciente(Alergias objAlergias, Alimentacion objAlimentacion, AntecedentesMadre objAntecedentesMadre, AntecedentesPadre objAntecedentesPadre, CuidadoPrenatal objCuidadoPrenatal, CuidadoNatal objCuidadoNatal, CuidadoPosnatal objCuidadoPosnatal, Paciente objPaciente, Psicomotor objPsicomotor, Vacunacion objVacunacion)
        {
            bool resultado = false;
            SqlTransaction transaction;

            conn.Open();
            transaction = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("ModificaPaciente", conn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Datos Paciente

                cmd.Parameters.AddWithValue("@idPaciente", objPaciente.IdPaciente);
                cmd.Parameters.AddWithValue("@nombre", objPaciente.NombrePaciente);
                cmd.Parameters.AddWithValue("@nombreMadre", objPaciente.NombreMadre);
                cmd.Parameters.AddWithValue("@nombrePadre", objPaciente.NombrePadre);
                cmd.Parameters.AddWithValue("@nombreTutor", objPaciente.NombreTutor);
                cmd.Parameters.AddWithValue("@afiliacion", objPaciente.Afiliacion);
                cmd.Parameters.AddWithValue("@numeroSeguro", objPaciente.NumeroSeguro);
                cmd.Parameters.AddWithValue("@domicilio", objPaciente.Domicilio);
                cmd.Parameters.AddWithValue("@codigoPostal", objPaciente.CodigoPostal);
                cmd.Parameters.AddWithValue("@fechaNac", objPaciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@lugarNac", objPaciente.LugarNacimiento);
                cmd.Parameters.AddWithValue("@telefonoCasa", objPaciente.TelefonoCasa);
                cmd.Parameters.AddWithValue("@telefonoCel", objPaciente.TelefonoCelular);
                cmd.Parameters.AddWithValue("@sexo", objPaciente.Sexo);
                cmd.Parameters.AddWithValue("@tipoSangre", objPaciente.TipoSangre);
                //cmd.Parameters.AddWithValue("@fotografia", objPaciente.Fotografia);
                cmd.Parameters.AddWithValue("@observaciones", objPaciente.Observaciones);

                //Alergias
                
                cmd.Parameters.AddWithValue("@alergiaMedicamentos", objAlergias.AlergiaAlimentos);
                cmd.Parameters.AddWithValue("@medicamentos", objAlergias.Medicamentos);
                cmd.Parameters.AddWithValue("@alergiaAlimentos", objAlergias.AlergiaAlimentos);
                cmd.Parameters.AddWithValue("@alimentos", objAlergias.Alimentos);
                cmd.Parameters.AddWithValue("@alergiaFlora", objAlergias.AlergiaFlora);
                cmd.Parameters.AddWithValue("@flora", objAlergias.Flora);
                cmd.Parameters.AddWithValue("@alergiaRopa", objAlergias.AlergiaRopa);
                cmd.Parameters.AddWithValue("@ropa", objAlergias.Ropa);

                //Alimentacion
                
                cmd.Parameters.AddWithValue("@pecho", objAlimentacion.Pecho);
                cmd.Parameters.AddWithValue("@inicioPecho", objAlimentacion.MesInicioPecho);
                cmd.Parameters.AddWithValue("@tipoFormula", objAlimentacion.TipoFormula);
                cmd.Parameters.AddWithValue("@inicioFormula", objAlimentacion.MesInicioFormula);
                cmd.Parameters.AddWithValue("@cereal", objAlimentacion.Cereal);
                cmd.Parameters.AddWithValue("@inicioCereal", objAlimentacion.MesInicioCereal);
                cmd.Parameters.AddWithValue("@frutas", objAlimentacion.Frutas);
                cmd.Parameters.AddWithValue("@inicioFrutas", objAlimentacion.InicioFrutas);
                cmd.Parameters.AddWithValue("@inicioCitricos", objAlimentacion.InicioCitricos);
                cmd.Parameters.AddWithValue("@verduras", objAlimentacion.Verduras);
                cmd.Parameters.AddWithValue("@inicioVerduras", objAlimentacion.InicioVerduras);
                cmd.Parameters.AddWithValue("@inicioTomate", objAlimentacion.InicioTomate);

                //AntecedentesMadre
                
                cmd.Parameters.AddWithValue("@fechaNacMadre", objAntecedentesMadre.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ocupacionMadre", objAntecedentesMadre.Ocupacion);
                cmd.Parameters.AddWithValue("@tabaquismoMadre", objAntecedentesMadre.Tabaquismo);
                cmd.Parameters.AddWithValue("@alcoholismoMadre", objAntecedentesMadre.Alcoholismo);
                cmd.Parameters.AddWithValue("@toxicomaniasMadre", objAntecedentesMadre.Toxicomanias);
                cmd.Parameters.AddWithValue("@alergiasMadre", objAntecedentesMadre.Alergias);
                cmd.Parameters.AddWithValue("@diabetesMadre", objAntecedentesMadre.Diabetes);
                cmd.Parameters.AddWithValue("@hipertensionMadre", objAntecedentesMadre.Hipertension);
                cmd.Parameters.AddWithValue("@dismorfologicosMadre", objAntecedentesMadre.Dismorfologicos);
                cmd.Parameters.AddWithValue("@cancerMadre", objAntecedentesMadre.Cancer);
                cmd.Parameters.AddWithValue("@tiposCancerMadre", objAntecedentesMadre.TiposCancer);
                cmd.Parameters.AddWithValue("@otrosMadre", objAntecedentesMadre.Otros);
                cmd.Parameters.AddWithValue("@medicamentosMadre", objAntecedentesMadre.Medicamentos);
                cmd.Parameters.AddWithValue("@estadoActualMadre", objAntecedentesMadre.EstadoActual);
                cmd.Parameters.AddWithValue("@embarazos", objAntecedentesMadre.Embarazos);
                cmd.Parameters.AddWithValue("@partos", objAntecedentesMadre.Partos);
                cmd.Parameters.AddWithValue("@abortos", objAntecedentesMadre.Abortos);
                cmd.Parameters.AddWithValue("@cesareas", objAntecedentesMadre.Cesareas);

                //Antecedentes Padre

                cmd.Parameters.AddWithValue("@fechaNacPadre", objAntecedentesPadre.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ocupacionPadre", objAntecedentesPadre.Ocupacion);
                cmd.Parameters.AddWithValue("@tabaquismoPadre", objAntecedentesPadre.Tabaquismo);
                cmd.Parameters.AddWithValue("@alcoholismoPadre", objAntecedentesPadre.Alcoholismo);
                cmd.Parameters.AddWithValue("@toxicomaniasPadre", objAntecedentesPadre.Toxicomanias);
                cmd.Parameters.AddWithValue("@alergiasPadre", objAntecedentesPadre.Alergias);
                cmd.Parameters.AddWithValue("@diabetesPadre", objAntecedentesPadre.Diabetes);
                cmd.Parameters.AddWithValue("@hipertensionPadre", objAntecedentesPadre.Hipertension);
                cmd.Parameters.AddWithValue("@dismorfologicosPadre", objAntecedentesPadre.Dismorfologicos);
                cmd.Parameters.AddWithValue("@cancerPadre", objAntecedentesPadre.Cancer);
                cmd.Parameters.AddWithValue("@tiposCancerPadre", objAntecedentesPadre.TiposCancer);
                cmd.Parameters.AddWithValue("@otrosPadre", objAntecedentesPadre.Otros);
                cmd.Parameters.AddWithValue("@medicamentosPadre", objAntecedentesPadre.Medicamentos);
                cmd.Parameters.AddWithValue("@estadoActualPadre", objAntecedentesMadre.EstadoActual);

                //Cuidado Prenatal

                cmd.Parameters.AddWithValue("@planeado", objCuidadoPrenatal.Planeado);
                cmd.Parameters.AddWithValue("@metodoFertilizacion", objCuidadoPrenatal.MetodoFertilizacion);
                cmd.Parameters.AddWithValue("@mesInicioControl", objCuidadoPrenatal.InicioControl);
                cmd.Parameters.AddWithValue("@responsable", objCuidadoPrenatal.Responsable);
                cmd.Parameters.AddWithValue("@enfermedades", objCuidadoPrenatal.Enfermedades);

                //Cuidado Natal

                cmd.Parameters.AddWithValue("@hospital", objCuidadoNatal.Hospital);
                cmd.Parameters.AddWithValue("@tipoNacimiento", objCuidadoNatal.TipoNacimiento);
                cmd.Parameters.AddWithValue("@multiple", objCuidadoNatal.Multiple);
                cmd.Parameters.AddWithValue("@pesoNac", objCuidadoNatal.PesoNacimiento);
                cmd.Parameters.AddWithValue("@tallaNac", objCuidadoNatal.TallaNacimiento);
                cmd.Parameters.AddWithValue("@indicaciones", objCuidadoNatal.Indicaciones);

                //Cuidado Posnatal
                
                cmd.Parameters.AddWithValue("@necesidadVigilancia", objCuidadoPosnatal.NecesidadVigilancia);
                cmd.Parameters.AddWithValue("@respirador", objCuidadoPosnatal.Respirador);
                cmd.Parameters.AddWithValue("@incubadora", objCuidadoPosnatal.Incubadora);
                cmd.Parameters.AddWithValue("@fototerapia", objCuidadoPosnatal.Fototerapias);
                cmd.Parameters.AddWithValue("@otros", objCuidadoPosnatal.Otros);

                //Psicomotor
                
                cmd.Parameters.AddWithValue("@sostieneCabeza", objPsicomotor.SostieneCabeza);
                cmd.Parameters.AddWithValue("@sentado", objPsicomotor.Sentado);
                cmd.Parameters.AddWithValue("@inicioSentado", objPsicomotor.Sentado);
                cmd.Parameters.AddWithValue("@gateo", objPsicomotor.Gateo);
                cmd.Parameters.AddWithValue("@inicioGateo", objPsicomotor.InicioGateo);
                cmd.Parameters.AddWithValue("@controlEsfinter", objPsicomotor.ControlEsfinter);
                cmd.Parameters.AddWithValue("@inicioControlEsfinter", objPsicomotor.InicioControlEsfinter);
                cmd.Parameters.AddWithValue("@rodado", objPsicomotor.Rodado);
                cmd.Parameters.AddWithValue("@inicioRodado", objPsicomotor.InicioRodado);
                cmd.Parameters.AddWithValue("@bipedestacion", objPsicomotor.Bipedestacion);
                cmd.Parameters.AddWithValue("@inicioBipedestacion", objPsicomotor.InicioBipedestacion);
                cmd.Parameters.AddWithValue("@deambulacion", objPsicomotor.Deambulacion);
                cmd.Parameters.AddWithValue("@inicioDeambulacion", objPsicomotor.InicioDeambulacion);

                //Vacunacion
                
                cmd.Parameters.AddWithValue("@hepatitisA", objVacunacion.HepatitisA);
                cmd.Parameters.AddWithValue("@hepatitisB", objVacunacion.HepatitisB);
                cmd.Parameters.AddWithValue("@hib", objVacunacion.HIB);
                cmd.Parameters.AddWithValue("@meningococo", objVacunacion.Meningococo);
                cmd.Parameters.AddWithValue("@bpt", objVacunacion.BPT);
                cmd.Parameters.AddWithValue("@poliomielitis", objVacunacion.Poliomielitis);
                cmd.Parameters.AddWithValue("@rotavirus", objVacunacion.Rotavirus);
                cmd.Parameters.AddWithValue("@neumococo", objVacunacion.Neumococo);
                cmd.Parameters.AddWithValue("@influenza", objVacunacion.Influenza);
                cmd.Parameters.AddWithValue("@mmr", objVacunacion.MMR);
                cmd.Parameters.AddWithValue("@varicela", objVacunacion.Varicela);
                cmd.Parameters.AddWithValue("@hpv", objVacunacion.HPV);
                cmd.Parameters.AddWithValue("@tuberculosis", objVacunacion.Tuberculosis);

                int columnasModificadas = cmd.ExecuteNonQuery();

                if (columnasModificadas > 0)
                {
                    transaction.Commit();
                    resultado = true;
                    cmd.Dispose();
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
            }

            conn.Close();

            return resultado;
        }

        public static bool eliminarDatosDePaciente(int idPaciente)
        {
            bool resultado = false;
            SqlTransaction transaction;

            conn.Open();
            transaction = conn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarPaciente", conn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

                int columnasEliminadas = cmd.ExecuteNonQuery();

                if (columnasEliminadas > 0)
                {
                    transaction.Commit();
                    resultado = true;
                    cmd.Dispose();
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
            }

            conn.Close();

            return resultado;
        }
    }
}
