using Citas.BusinessLogic;
using Consultas.BusinessLogic;
using Pacientes.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacientes.Presentation
{
    public partial class FormHistorial : Form
    {
        private int idPaciente;
        private Alergias objAlergias;
        private Alimentacion objAlimentacion;
        private AntecedentesMadre objAntecedentesMadre;
        private AntecedentesPadre objAntecedentesPadre;
        private CuidadoPrenatal objCuidadoPrenatal;
        private CuidadoNatal objCuidadoNatal;
        private CuidadoPosnatal objCuidadoPosnatal;
        private Paciente objPaciente;
        private Psicomotor objPsicomotor;
        private Vacunacion objVacunacion;
        private List<Historial> historial;

        public FormHistorial(Paciente objPaciente)
        {
            InitializeComponent();
            this.objPaciente = objPaciente;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            #region ObtenerDatosPaciente
            objAlergias = LogicaBusquedas.obtenerAlergias(objPaciente.IdPaciente);
            objAlimentacion = LogicaBusquedas.obtenerAlimentacion(objPaciente.IdPaciente);
            objAntecedentesMadre = LogicaBusquedas.obtenerAntecedentesMadre(objPaciente.IdPaciente);
            objAntecedentesPadre = LogicaBusquedas.obtenerAntecedentesPadre(objPaciente.IdPaciente);
            objCuidadoPrenatal = LogicaBusquedas.obtenerCuidadoPrenatal(objPaciente.IdPaciente);
            objCuidadoNatal = LogicaBusquedas.obtenerCuidadoNatal(objPaciente.IdPaciente);
            objCuidadoPosnatal = LogicaBusquedas.obtenerCuidadoPosatal(objPaciente.IdPaciente);
            objPsicomotor = LogicaBusquedas.obtenerDatosPsicomotor(objPaciente.IdPaciente);
            objVacunacion = LogicaBusquedas.obtenerDatosVacunacion(objPaciente.IdPaciente);

            historial = LogicaBusquedas.obtenerHistorialPaciente(objPaciente.IdPaciente);
            #endregion

            #region DatosPaciente
            textBoxNombre.Text = objPaciente.NombrePaciente;
            textBoxNombreMadre.Text = objPaciente.NombreMadre;
            textBoxNombrePadre.Text = objPaciente.NombrePadre;
            textBoxTutor.Text = objPaciente.NombreTutor;
            textBoxDomicilio.Text = objPaciente.Domicilio;
            textBoxCP.Text = objPaciente.CodigoPostal;
            textBoxSeguro.Text = objPaciente.NumeroSeguro;
            textBoxNombreMadre.Text = objPaciente.NombreMadre;
            textBoxNombrePadre.Text = objPaciente.NombrePadre;
            textBoxTelCasa.Text = objPaciente.TelefonoCasa;
            textBoxTelCel.Text = objPaciente.TelefonoCelular;
            textBoxLugarNac.Text = objPaciente.LugarNacimiento;
            textBoxObservaciones.Text = objPaciente.Observaciones;

            dateTimePickerFechaNac.Value = objPaciente.FechaNacimiento;

            if (objPaciente.Sexo == "Masculino")
            {
                radioButtonMasculino.Checked = true;
            }

            if (objPaciente.Sexo == "Femenino")
            {
                radioButtonFemenino.Checked = true;
            }

            if (objPaciente.Afiliacion == "PEMEX")
            {
                comboBoxAfiliacion.SelectedIndex = 0;
            }

            if (objPaciente.Afiliacion == "Carl's Jr")
            {
                comboBoxAfiliacion.SelectedIndex = 1;
            }

            if (objPaciente.Afiliacion != "PEMEX" || objPaciente.Afiliacion == "Carl's Jr")
            {
                textBoxOtro.Text = objPaciente.Afiliacion;
                checkBoxOtro.Checked = true;
            }

            if (objPaciente.TipoSangre == "A+")
            {
                comboBoxTipoSangre.SelectedIndex = 0;
            }

            if (objPaciente.TipoSangre == "A-")
            {
                comboBoxTipoSangre.SelectedIndex = 1;
            }

            if (objPaciente.TipoSangre == "B+")
            {
                comboBoxTipoSangre.SelectedIndex = 2;
            }
            if (objPaciente.TipoSangre == "B-")
            {
                comboBoxTipoSangre.SelectedIndex = 3;
            }

            if (objPaciente.TipoSangre == "AB+")
            {
                comboBoxTipoSangre.SelectedIndex = 4;
            }
            if (objPaciente.TipoSangre == "AB-")
            {
                comboBoxTipoSangre.SelectedIndex = 5;
            }

            if (objPaciente.TipoSangre == "O+")
            {
                comboBoxTipoSangre.SelectedIndex = 6;
            }
            if (objPaciente.TipoSangre == "O-")
            {
                comboBoxTipoSangre.SelectedIndex = 7;
            }

            #endregion

            //Antecedentes Madre

            dateTimePickerFechaNacMadre.Value = objAntecedentesMadre.FechaNacimiento;

            textBoxOcupacionMadre.Text = objAntecedentesMadre.Ocupacion;
            textBoxDismorfologicosMadre.Text = objAntecedentesMadre.Dismorfologicos;
            textBoxToxicomaniasMadre.Text = objAntecedentesMadre.Toxicomanias;
            textBoxTipoCancerMadre.Text = objAntecedentesMadre.TiposCancer;
            textBoxAlergiasMadre.Text = objAntecedentesMadre.Alergias;
            textBoxOtrosMadre.Text = objAntecedentesMadre.Otros;
            textBoxMedicamentoActualMadre.Text = objAntecedentesMadre.Medicamentos;
            textBoxEstadoSaludActualMadre.Text = objAntecedentesMadre.EstadoActual;

            checkBoxAlcoholismoMadre.Checked = objAntecedentesMadre.Alcoholismo;
            checkBoxHipertensionMadre.Checked = objAntecedentesMadre.Hipertension;
            checkBoxTabaquismoMadre.Checked = objAntecedentesMadre.Tabaquismo;
            checkBoxCancerMadre.Checked = objAntecedentesMadre.Cancer;
            checkBoxDiabetesMadre.Checked = objAntecedentesMadre.Diabetes;
            checkBoxDismorfologicosMadre.Checked = !(String.IsNullOrEmpty(objAntecedentesMadre.Dismorfologicos));

            numericUpDownNumEmbarazo.Value = objAntecedentesMadre.Embarazos;
            numericUpDownNumPartos.Value = objAntecedentesMadre.Partos;
            numericUpDownNumAborto.Value = objAntecedentesMadre.Abortos;
            numericUpDownNumCesarea.Value = objAntecedentesMadre.Cesareas;

            //Antecedentes Padre

            dateTimePickerFechaNacPadre.Value = objAntecedentesPadre.FechaNacimiento;

            textBoxOcupacionPadre.Text = objAntecedentesPadre.Ocupacion;
            textBoxDismorfologicosPadre.Text = objAntecedentesPadre.Dismorfologicos;
            textBoxToxicomaniasPadre.Text = objAntecedentesPadre.Toxicomanias;
            textBoxTipoCancerPadre.Text = objAntecedentesPadre.TiposCancer;
            textBoxAlergiasPadre.Text = objAntecedentesPadre.Alergias;
            textBoxOtrosPadre.Text = objAntecedentesPadre.Otros;
            textBoxMedicamentoActualPadre.Text = objAntecedentesPadre.Medicamentos;
            textBoxEstadoSaludActualPadre.Text = objAntecedentesPadre.EstadoActual;

            checkBoxAlcoholismoPadre.Checked = objAntecedentesPadre.Alcoholismo;
            checkBoxHipertensionPadre.Checked = objAntecedentesPadre.Hipertension;
            checkBoxTabaquismoPadre.Checked = objAntecedentesPadre.Tabaquismo;
            checkBoxCancerPadre.Checked = objAntecedentesPadre.Cancer;
            checkBoxDiabetesPadre.Checked = objAntecedentesPadre.Diabetes;
            checkBoxDismorfologicosPadre.Checked = !(String.IsNullOrEmpty(objAntecedentesPadre.Dismorfologicos));

            //Alimentos

            checkBoxPecho.Checked = objAlimentacion.Pecho;
            checkBoxCereal.Checked = objAlimentacion.Cereal;
            checkBoxFrutas.Checked = objAlimentacion.Frutas;
            checkBoxVerduras.Checked = objAlimentacion.Verduras;

            numericUpDownMesPecho.Value = objAlimentacion.MesInicioPecho;
            numericUpDownMesFormula.Value = objAlimentacion.MesInicioFormula;
            numericUpDownMesCereal.Value = objAlimentacion.MesInicioCereal;
            numericUpDownMesFrutas.Value = objAlimentacion.InicioFrutas;
            numericUpDownCitricos.Value = objAlimentacion.InicioCitricos;
            numericUpDownMesVerduras.Value = objAlimentacion.InicioVerduras;
            numericUpDownMesTomate.Value = objAlimentacion.InicioTomate;

            textBoxTipoFormula.Text = objAlimentacion.TipoFormula;

            //Psicomotor

            checkBoxSostieneCabeza.Checked = objPsicomotor.SostieneCabeza;
            checkBoxSentarse.Checked = objPsicomotor.Sentado;
            checkBoxGatear.Checked = objPsicomotor.Gateo;
            checkBoxRodar.Checked = objPsicomotor.Rodado;
            checkBoxControlEsfinteres.Checked = objPsicomotor.ControlEsfinter;
            checkBoxBipedestacion.Checked = objPsicomotor.Bipedestacion;
            checkBoxDeambulacion.Checked = objPsicomotor.Deambulacion;

            numericUpDownMesSentarse.Value = objPsicomotor.InicioSentado;
            numericUpDownMesGatear.Value = objPsicomotor.InicioGateo;
            numericUpDownMesRodar.Value = objPsicomotor.InicioRodado;
            numericUpDownMesEsfinteres.Value = objPsicomotor.InicioControlEsfinter;
            numericUpDownMesBipedestacion.Value = objPsicomotor.InicioBipedestacion;
            numericUpDownMesDeambulacion.Value = objPsicomotor.InicioDeambulacion;

            //Cuidado Prenatal

            if (objCuidadoPrenatal.Planeado == true)
            {
                radioButtonSiPlaneado.Checked = true;
            }

            if (objCuidadoPrenatal.Planeado == false)
            {
                radioButtonNoPlaneado.Checked = true;
            }

            if (objCuidadoPrenatal.MetodoFertilizacion == "Fecundación In Vitro")
            {
                comboBoxMetFertilizacion.SelectedIndex = 0;
            }

            if (objCuidadoPrenatal.MetodoFertilizacion == "Inseminación Artificial")
            {
                comboBoxMetFertilizacion.SelectedIndex = 0;
            }

            numericUpDownMesControl.Value = objCuidadoPrenatal.InicioControl;
            textBoxResponsableControl.Text = objCuidadoPrenatal.Responsable;
            textBoxEnfermedades.Text = objCuidadoPrenatal.Enfermedades;

            //Cuidado Natal

            textBoxHospital.Text = objCuidadoNatal.Hospital;
            textBoxPesoNac.Text = objCuidadoNatal.PesoNacimiento.ToString();
            textBoxTallaNac.Text = objCuidadoNatal.TallaNacimiento.ToString();
            textBoxIndicaciones.Text = objCuidadoNatal.Indicaciones;

            if (objCuidadoNatal.TipoNacimiento == "Natural")
            {
                comboBoxTipoNac.SelectedIndex = 0;
            }
            if (objCuidadoNatal.TipoNacimiento == "Cesárea")
            {
                comboBoxTipoNac.SelectedIndex = 1;
            }

            checkBoxMultiple.Checked = objCuidadoNatal.Multiple;

            //Cuidado Posnatal

            if (objCuidadoPosnatal.NecesidadVigilancia == true)
            {
                radioButtonSiVigilancia.Checked = true;
            }
            if (objCuidadoPosnatal.NecesidadVigilancia == false)
            {
                radioButtonNoVigilancia.Checked = true;
            }

            if (objCuidadoPosnatal.Respirador == true)
            {
                radioButtonSiRespirador.Checked = true;
            }
            if (objCuidadoPosnatal.Respirador == false)
            {
                radioButtonNoRespirador.Checked = true;
            }

            if (objCuidadoPosnatal.Incubadora == true)
            {
                radioButtonSiIncubadora.Checked = true;
            }
            if (objCuidadoPosnatal.Incubadora == false)
            {
                radioButtonNoIncubadora.Checked = true;
            }

            textBoxFototerapias.Text = objCuidadoPosnatal.Fototerapias;
            textBoxOtrosPosnatal.Text = objCuidadoPosnatal.Otros;

            //Vacunas

            checkBoxHepatitisA.Checked = objVacunacion.HepatitisA;
            checkBoxHepatitisB.Checked = objVacunacion.HepatitisB;
            checkBoxHIB.Checked = objVacunacion.HIB;
            checkBoxMeningococo.Checked = objVacunacion.Meningococo;
            checkBoxBPT.Checked = objVacunacion.BPT;
            checkBoxPoliomelitis.Checked = objVacunacion.Poliomielitis;
            checkBoxRotavirus.Checked = objVacunacion.Rotavirus;
            checkBoxNeumococo.Checked = objVacunacion.Neumococo;
            checkBoxInfluenza.Checked = objVacunacion.Influenza;
            checkBoxMMR.Checked = objVacunacion.MMR;
            checkBoxVaricela.Checked = objVacunacion.Varicela;
            checkBoxHPV.Checked = objVacunacion.HPV;
            checkBoxTuberculosis.Checked = objVacunacion.Tuberculosis;

            //Alergias

            checkBoxAlergiaMedicamento.Checked = objAlergias.AlergiaMedicamentos;
            checkBoxAlergiaAlimentos.Checked = objAlergias.AlergiaAlimentos;
            checkBoxAlergiaFlora.Checked = objAlergias.AlergiaFlora;
            checkBoxAlergiaRopa.Checked = objAlergias.AlergiaRopa;

            if (checkBoxAlergiaMedicamento.Checked == true)
            {
                textBoxAlergiaMedicamento.Enabled = true;
                textBoxAlergiaMedicamento.Text = objAlergias.Medicamentos;
            }

            if (checkBoxAlergiaAlimentos.Checked == true)
            {
                textBoxAlergiaAlimentos.Enabled = true;
                textBoxAlergiaAlimentos.Text = objAlergias.Alimentos;
            }

            if (checkBoxAlergiaFlora.Checked == true)
            {
                textBoxAlergiaFlora.Enabled = true;
                textBoxAlergiaFlora.Text = objAlergias.Flora;
            }
            if (checkBoxAlergiaRopa.Checked == true)
            {
                textBoxAlergiaRopa.Enabled = true;
                textBoxAlergiaRopa.Text = objAlergias.Ropa;
            }
            
            dataGridViewHistorial.DataSource = historial;

        }
    }
}
