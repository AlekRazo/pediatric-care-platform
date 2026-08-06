using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pacientes.BusinessLogic;

namespace Pacientes.Presentation
{
    public partial class FormAgregarPaciente : Form
    {
        bool modificar = false;
        Alergias objAlergias;
        Alimentacion objAlimentacion;
        AntecedentesMadre objAntecedentesMadre;
        AntecedentesPadre objAntecedentesPadre;
        CuidadoPrenatal objCuidadoPrenatal;
        CuidadoNatal objCuidadoNatal;
        CuidadoPosnatal objCuidadoPosnatal;
        Paciente objPaciente;
        Psicomotor objPsicomotor;
        Vacunacion objVacunacion;

        public FormAgregarPaciente()
        {
            InitializeComponent();
        }

        public FormAgregarPaciente(bool modificar, Paciente objPaciente)
        {
            InitializeComponent();
            this.modificar = modificar;
            this.Text = "Modificar Paciente";
            this.objPaciente = objPaciente;
        }

        private void FormAgregarPaciente_Load(object sender, EventArgs e)
        {
            if (modificar == true)
            {
                objAlergias = LogicaBusquedas.obtenerAlergias(objPaciente.IdPaciente);
                objAlimentacion = LogicaBusquedas.obtenerAlimentacion(objPaciente.IdPaciente);
                objAntecedentesMadre = LogicaBusquedas.obtenerAntecedentesMadre(objPaciente.IdPaciente);
                objAntecedentesPadre = LogicaBusquedas.obtenerAntecedentesPadre(objPaciente.IdPaciente);
                objCuidadoPrenatal = LogicaBusquedas.obtenerCuidadoPrenatal(objPaciente.IdPaciente);
                objCuidadoNatal = LogicaBusquedas.obtenerCuidadoNatal(objPaciente.IdPaciente);
                objCuidadoPosnatal = LogicaBusquedas.obtenerCuidadoPosatal(objPaciente.IdPaciente);
                objPsicomotor = LogicaBusquedas.obtenerDatosPsicomotor(objPaciente.IdPaciente);
                objVacunacion = LogicaBusquedas.obtenerDatosVacunacion(objPaciente.IdPaciente);

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

                if(objPaciente.Afiliacion == "PEMEX")
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

                if (objPaciente.TipoSangre == "A-"){
                    comboBoxTipoSangre.SelectedIndex = 1;
                }

                if (objPaciente.TipoSangre == "B+")
                {
                    comboBoxTipoSangre.SelectedIndex = 2;
                }
                if (objPaciente.TipoSangre == "B-"){
                    comboBoxTipoSangre.SelectedIndex = 3;
                }

                if (objPaciente.TipoSangre == "AB+")
                {
                    comboBoxTipoSangre.SelectedIndex = 4;
                }
                if (objPaciente.TipoSangre == "AB-"){
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
            }
        }

        private void buttonCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void buttonGuardar_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxTipoSangre.SelectedIndex.Equals(-1))
            {

                MessageBox.Show("Seleccione tipo de sangre");
            }
            else
            {
                if (comboBoxTipoNac.SelectedIndex.Equals(-1))
                {

                    MessageBox.Show("Seleccione tipo de nacimiento");
                }
                else
                {
                    if (radioButtonFemenino.Checked == false && radioButtonMasculino.Checked == false)
                    {
                        MessageBox.Show("Seleccione sexo");
                    }
                    else
                    {
                        string sexo = "";

                        if (radioButtonFemenino.Checked == true)
                        {
                            sexo = "Femenino";
                        }
                        if (radioButtonMasculino.Checked == true)
                        {
                            sexo = "Masculino";
                        }
                        if (radioButtonSiPlaneado.Checked == false && radioButtonNoPlaneado.Checked == false)
                        {
                            MessageBox.Show("Seleccione si fue Planeado o No Planeado");
                        }
                        else
                        {
                            bool planeado = true;
                            if (radioButtonSiPlaneado.Checked == true)
                            {
                                planeado = true;
                            }
                            else
                            {
                                planeado = false;
                            }
                            if (radioButtonSiVigilancia.Checked == false && radioButtonNoVigilancia.Checked == false)
                            {
                                MessageBox.Show("Seleccione si necesitó o no vigilancia");
                            }
                            else
                            {
                                bool vigilancia = true;
                                if (radioButtonSiVigilancia.Checked == true)
                                {
                                    vigilancia = true;
                                }
                                else
                                {
                                    vigilancia = false;
                                }
                                if (radioButtonSiRespirador.Checked == false && radioButtonNoRespirador.Checked == false)
                                {
                                    MessageBox.Show("Seleccione si necesitó o no respirador");
                                }
                                else
                                {
                                    bool respirador = true;
                                    if (radioButtonSiRespirador.Checked == true)
                                    {
                                        respirador = true;
                                    }
                                    else
                                    {
                                        respirador = false;
                                    }
                                    if (radioButtonSiIncubadora.Checked == false && radioButtonNoIncubadora.Checked == false)
                                    {
                                        MessageBox.Show("Seleccione si necesitó o no incubadora");
                                    }
                                    else
                                    {
                                        bool incubadora = true;
                                        if (radioButtonSiIncubadora.Checked == true)
                                        {
                                            incubadora = true;
                                        }
                                        else
                                        {
                                            incubadora = false;
                                        }

                                        ///////////////////////// Objeto Paciente /////////////////////////////
                                        if (modificar == false)
                                        {
                                            objPaciente = new Paciente();
                                        }

                                        objPaciente.NombrePaciente = textBoxNombre.Text;
                                        objPaciente.NombreMadre = textBoxNombreMadre.Text;
                                        objPaciente.NombrePadre = textBoxNombrePadre.Text;
                                        objPaciente.Domicilio = textBoxDomicilio.Text;
                                        objPaciente.CodigoPostal = textBoxCP.Text;
                                        objPaciente.FechaNacimiento = dateTimePickerFechaNac.Value;
                                        objPaciente.TelefonoCasa = textBoxTelCasa.Text;
                                        objPaciente.TelefonoCelular = textBoxTelCel.Text;
                                        objPaciente.Sexo = sexo;
                                        objPaciente.LugarNacimiento = textBoxLugarNac.Text;
                                        objPaciente.TipoSangre = comboBoxTipoSangre.SelectedItem.ToString();
                                        objPaciente.Observaciones = textBoxObservaciones.Text;
                                        objPaciente.NombreTutor = textBoxTutor.Text;
                                        objPaciente.NumeroSeguro = textBoxSeguro.Text;

                                        if (checkBoxOtro.Checked == true)
                                        {
                                            objPaciente.Afiliacion = textBoxOtro.Text;
                                        }
                                        else
                                        {
                                            if (comboBoxAfiliacion.SelectedIndex.Equals(-1))
                                            {
                                                objPaciente.Afiliacion = "Ninguna";
                                            }
                                            else
                                            {
                                                objPaciente.Afiliacion = comboBoxAfiliacion.SelectedItem.ToString();
                                            }
                                        }

                                        ///////////////////////// Objeto Alimentacion /////////////////////////////
                                        objAlimentacion = new Alimentacion();
                                        objAlimentacion.Pecho = checkBoxPecho.Checked;
                                        objAlimentacion.MesInicioPecho = Int32.Parse(numericUpDownMesPecho.Value.ToString());
                                        objAlimentacion.TipoFormula = textBoxTipoFormula.Text;
                                        objAlimentacion.MesInicioFormula = Int32.Parse(numericUpDownMesFormula.Value.ToString());
                                        objAlimentacion.Cereal = checkBoxCereal.Checked;
                                        objAlimentacion.MesInicioCereal = Int32.Parse(numericUpDownMesCereal.Value.ToString());
                                        objAlimentacion.Frutas = checkBoxFrutas.Checked;
                                        objAlimentacion.InicioFrutas = Int32.Parse(numericUpDownMesFrutas.Value.ToString());
                                        objAlimentacion.InicioCitricos = Int32.Parse(numericUpDownCitricos.Value.ToString());
                                        objAlimentacion.Verduras = checkBoxVerduras.Checked;
                                        objAlimentacion.InicioVerduras = Int32.Parse(numericUpDownMesVerduras.Value.ToString());
                                        objAlimentacion.InicioTomate = Int32.Parse(numericUpDownMesTomate.Value.ToString());

                                        ///////////////////////// Objeto Psicomotor /////////////////////////////    
                                        objPsicomotor = new Psicomotor();
                                        objPsicomotor.SostieneCabeza = checkBoxSostieneCabeza.Checked;
                                        objPsicomotor.Sentado = checkBoxSentarse.Checked;
                                        objPsicomotor.InicioSentado = Int32.Parse(numericUpDownMesSentarse.Value.ToString());
                                        objPsicomotor.Gateo = checkBoxGatear.Checked;
                                        objPsicomotor.InicioGateo = Int32.Parse(numericUpDownMesGatear.Value.ToString());
                                        objPsicomotor.ControlEsfinter = checkBoxControlEsfinteres.Checked;
                                        objPsicomotor.InicioControlEsfinter = Int32.Parse(numericUpDownMesEsfinteres.Value.ToString());
                                        objPsicomotor.Rodado = checkBoxRodar.Checked;
                                        objPsicomotor.InicioRodado = Int32.Parse(numericUpDownMesRodar.Value.ToString());
                                        objPsicomotor.Bipedestacion = checkBoxBipedestacion.Checked;
                                        objPsicomotor.InicioBipedestacion = Int32.Parse(numericUpDownMesBipedestacion.Value.ToString());
                                        objPsicomotor.Deambulacion = checkBoxDeambulacion.Checked;
                                        objPsicomotor.InicioDeambulacion = Int32.Parse(numericUpDownMesDeambulacion.Value.ToString());

                                        ///////////////////////// Objeto AntecedentesMadre /////////////////////////////
                                        objAntecedentesMadre = new AntecedentesMadre();
                                        objAntecedentesMadre.FechaNacimiento = dateTimePickerFechaNacMadre.Value;
                                        objAntecedentesMadre.Ocupacion = textBoxOcupacionMadre.Text;
                                        objAntecedentesMadre.Tabaquismo = checkBoxTabaquismoMadre.Checked;
                                        objAntecedentesMadre.Alcoholismo = checkBoxAlcoholismoMadre.Checked;
                                        objAntecedentesMadre.Hipertension = checkBoxHipertensionMadre.Checked;
                                        objAntecedentesMadre.Dismorfologicos = textBoxDismorfologicosMadre.Text;
                                        objAntecedentesMadre.Toxicomanias = textBoxToxicomaniasMadre.Text;
                                        objAntecedentesMadre.Alergias = textBoxAlergiasMadre.Text;
                                        objAntecedentesMadre.Diabetes = checkBoxDiabetesMadre.Checked;
                                        objAntecedentesMadre.Cancer = checkBoxCancerMadre.Checked;
                                        objAntecedentesMadre.TiposCancer = textBoxTipoCancerMadre.Text;
                                        objAntecedentesMadre.Otros = textBoxOtrosMadre.Text;
                                        objAntecedentesMadre.Medicamentos = textBoxMedicamentoActualMadre.Text;
                                        objAntecedentesMadre.EstadoActual = textBoxEstadoSaludActualMadre.Text;
                                        objAntecedentesMadre.Embarazos = numericUpDownNumEmbarazo.DecimalPlaces;
                                        objAntecedentesMadre.Partos = Int32.Parse(numericUpDownNumPartos.Value.ToString());
                                        objAntecedentesMadre.Cesareas = Int32.Parse(numericUpDownNumCesarea.Value.ToString());
                                        objAntecedentesMadre.Abortos = Int32.Parse(numericUpDownNumAborto.Value.ToString());

                                        ///////////////////////// Objeto AntecedentesPadre /////////////////////////////
                                        objAntecedentesPadre = new AntecedentesPadre();
                                        objAntecedentesPadre.FechaNacimiento = dateTimePickerFechaNacPadre.Value;
                                        objAntecedentesPadre.Ocupacion = textBoxOcupacionPadre.Text;
                                        objAntecedentesPadre.Tabaquismo = checkBoxTabaquismoPadre.Checked;
                                        objAntecedentesPadre.Alcoholismo = checkBoxAlcoholismoPadre.Checked;
                                        objAntecedentesPadre.Hipertension = checkBoxHipertensionPadre.Checked;
                                        objAntecedentesPadre.Dismorfologicos = textBoxDismorfologicosPadre.Text;
                                        objAntecedentesPadre.Toxicomanias = textBoxToxicomaniasPadre.Text;
                                        objAntecedentesPadre.Alergias = textBoxAlergiasPadre.Text;
                                        objAntecedentesPadre.Diabetes = checkBoxDiabetesPadre.Checked;
                                        objAntecedentesPadre.Cancer = checkBoxCancerPadre.Checked;
                                        objAntecedentesPadre.TiposCancer = textBoxTipoCancerPadre.Text;
                                        objAntecedentesPadre.Otros = textBoxOtrosPadre.Text;
                                        objAntecedentesPadre.Medicamentos = textBoxMedicamentoActualPadre.Text;
                                        objAntecedentesPadre.EstadoActual = textBoxEstadoSaludActualPadre.Text;

                                        ///////////////////////// Objeto CuidadoPrenatal /////////////////////////////
                                        objCuidadoPrenatal = new CuidadoPrenatal();
                                        /*********************  Como punto importante es el bool planeado  *******************/
                                        objCuidadoPrenatal.Planeado = planeado;
                                        if (comboBoxMetFertilizacion.SelectedIndex.Equals(-1))
                                        {
                                            objCuidadoPrenatal.MetodoFertilizacion = "Ninguno";
                                        }
                                        else
                                        {
                                            objCuidadoPrenatal.MetodoFertilizacion = comboBoxMetFertilizacion.SelectedItem.ToString();
                                        }
                                        objCuidadoPrenatal.InicioControl = Int32.Parse(numericUpDownMesControl.Value.ToString());
                                        objCuidadoPrenatal.Responsable = textBoxResponsableControl.Text;
                                        objCuidadoPrenatal.Enfermedades = textBoxEnfermedades.Text;

                                        ///////////////////////// Objeto CuidadoNatal /////////////////////////////
                                        objCuidadoNatal = new CuidadoNatal();
                                        objCuidadoNatal.Hospital = textBoxHospital.Text;
                                        objCuidadoNatal.TipoNacimiento = comboBoxTipoNac.SelectedItem.ToString();
                                        objCuidadoNatal.Multiple = checkBoxMultiple.Checked;
                                        objCuidadoNatal.PesoNacimiento = Double.Parse(textBoxPesoNac.Text);
                                        objCuidadoNatal.TallaNacimiento = Double.Parse(textBoxTallaNac.Text);
                                        objCuidadoNatal.Indicaciones = textBoxIndicaciones.Text;

                                        ///////////////////////// Objeto CuidadoPosnatal /////////////////////////////
                                        objCuidadoPosnatal = new CuidadoPosnatal();
                                        objCuidadoPosnatal.NecesidadVigilancia = vigilancia;
                                        objCuidadoPosnatal.Respirador = respirador;
                                        objCuidadoPosnatal.Incubadora = incubadora;
                                        objCuidadoPosnatal.Fototerapias = textBoxFototerapias.Text;
                                        objCuidadoPosnatal.Otros = textBoxOtrosPosnatal.Text;

                                        ///////////////////////// Objeto Vacunacion /////////////////////////////
                                        objVacunacion = new Vacunacion();
                                        objVacunacion.HepatitisA = checkBoxHepatitisA.Checked;
                                        objVacunacion.HepatitisB = checkBoxHepatitisB.Checked;
                                        objVacunacion.HIB = checkBoxHIB.Checked;
                                        objVacunacion.Meningococo = checkBoxMeningococo.Checked;
                                        objVacunacion.BPT = checkBoxBPT.Checked;
                                        objVacunacion.Poliomielitis = checkBoxPoliomelitis.Checked;
                                        objVacunacion.Rotavirus = checkBoxRotavirus.Checked;
                                        objVacunacion.Neumococo = checkBoxNeumococo.Checked;
                                        objVacunacion.Influenza = checkBoxInfluenza.Checked;
                                        objVacunacion.MMR = checkBoxMMR.Checked;
                                        objVacunacion.Varicela = checkBoxVaricela.Checked;
                                        objVacunacion.HPV = checkBoxHPV.Checked;
                                        objVacunacion.Tuberculosis = checkBoxTuberculosis.Checked;

                                        ///////////////////////// Objeto Alergias /////////////////////////////
                                        objAlergias = new Alergias();
                                        objAlergias.AlergiaMedicamentos = checkBoxAlergiaMedicamento.Checked;
                                        objAlergias.Medicamentos = textBoxAlergiaMedicamento.Text;
                                        objAlergias.AlergiaAlimentos = checkBoxAlergiaAlimentos.Checked;
                                        objAlergias.Alimentos = textBoxAlergiaAlimentos.Text;
                                        objAlergias.AlergiaFlora = checkBoxAlergiaFlora.Checked;
                                        objAlergias.Flora = textBoxAlergiaFlora.Text;
                                        objAlergias.AlergiaRopa = checkBoxAlergiaRopa.Checked;
                                        objAlergias.Ropa = textBoxAlergiaRopa.Text;

                                        if (modificar == true)
                                        {
                                            int resultado = LogicaPaciente.modificarPaciente(objAlergias, objAlimentacion, objAntecedentesMadre, objAntecedentesPadre, objCuidadoPrenatal, objCuidadoNatal, objCuidadoPosnatal, objPaciente, objPsicomotor, objVacunacion);

                                            if (resultado > 0)
                                            {
                                                MessageBox.Show("Datos de paciente actualizados");
                                                Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se pudo actualizar los datos del Paciente");
                                            }
                                        }
                                        else
                                        {
                                            int resultado = LogicaPaciente.registrarPaciente(objAlergias, objAlimentacion, objAntecedentesMadre, objAntecedentesPadre, objCuidadoPrenatal, objCuidadoNatal, objCuidadoPosnatal, objPaciente, objPsicomotor, objVacunacion);

                                            if (resultado > 0)
                                            {
                                                MessageBox.Show("Paciente Registrado");
                                                Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se pudo Registrar Paciente");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void checkBoxTutor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTutor.Checked == true)
            {
                textBoxTutor.Visible = true;
            }
            else
            {
                textBoxTutor.Visible = false;
            }
        }

        private void checkBoxOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOtro.Checked == true)
            {
                textBoxOtro.Visible = true;
            }
            else
            {
                textBoxOtro.Visible = false;
            }
        }

        private void checkBoxAlergiaMedicamento_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlergiaMedicamento.Enabled = checkBoxAlergiaMedicamento.Checked;

            if (checkBoxAlergiaMedicamento.Checked == false)
            {
                textBoxAlergiaMedicamento.Clear();
            }
        }

        private void checkBoxAlergiaAlimentos_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlergiaAlimentos.Enabled = checkBoxAlergiaAlimentos.Checked;

            if (checkBoxAlergiaAlimentos.Checked == false)
            {
                textBoxAlergiaAlimentos.Clear();
            }
        }

        private void checkBoxAlergiaFlora_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlergiaFlora.Enabled = checkBoxAlergiaFlora.Checked;

            if (checkBoxAlergiaFlora.Checked == false)
            {
                textBoxAlergiaFlora.Clear();
            }
        }

        private void checkBoxAlergiaRopa_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlergiaRopa.Enabled = checkBoxAlergiaRopa.Checked;

            if (checkBoxAlergiaRopa.Checked == false)
            {
                textBoxAlergiaRopa.Clear();
            }
        }           
    }
}
