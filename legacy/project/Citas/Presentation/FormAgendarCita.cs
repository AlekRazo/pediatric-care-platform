using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Citas.BusinessLogic;
using Helpers.Helpers;

namespace Citas.Presentation
{
    public partial class FormAgendarCita : Form
    {
        Cita objCita = new Cita();
        bool modificar = false;

        public FormAgendarCita()
        {
            InitializeComponent();
        }

        public FormAgendarCita(Cita objCita, bool modificar)
        {
            InitializeComponent();
            this.modificar = true;
            this.objCita = objCita;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Length > 0)
            {
                if (textBoxTelefono.Text.Length > 0)
                {
                    if (Validaciones.esCadena(textBoxNombre.Text))
                    {
                        if (Validaciones.esNumeroEntero(textBoxTelefono.Text))
                        {
                            objCita.NombrePaciente = textBoxNombre.Text;
                            objCita.FechaCita = dateTimePickerFecha.Value;

                            try
                            {
                                objCita.HoraCita = DateTime.Parse(maskedTextBoxHora.Text).TimeOfDay;
                            }
                            catch (Exception ex)
                            {
                                objCita.HoraCita = new TimeSpan(0, 0, 0);
                            }

                            objCita.PrimeraVez = checkBoxPrimeraVez.Checked;
                            objCita.Telefono = textBoxTelefono.Text;

                            if (radioButtonCarlsJr.Checked == true)
                            {
                                objCita.Afiliacion = radioButtonCarlsJr.Text;
                            }
                            if (radioButtonPemex.Checked == true)
                            {
                                objCita.Afiliacion = radioButtonPemex.Text;
                            }
                            if (radioButtonNinguno.Checked == true)
                            {
                                objCita.Afiliacion = radioButtonNinguno.Text;
                            }

                            if (modificar == true)
                            {
                                int resultado = LogicaCitas.actualizarCita(objCita);

                                if (resultado >= 0)
                                {
                                    MessageBox.Show("Cita reagendada");
                                    Close();
                                }
                                else
                                {
                                    if (resultado == -1)
                                    {
                                        MessageBox.Show("No se puede agendar antes de la fecha actual.");
                                    }
                                    if (resultado == -2)
                                    {
                                        MessageBox.Show("No se puede agendar a más de 60 días después de la fecha actual.");
                                    }
                                    if (resultado == -3)
                                    {
                                        MessageBox.Show("No se puede agendar en domingo.");
                                    }
                                    if (resultado == -4)
                                    {
                                        MessageBox.Show("Fecha no disponible.");
                                    }
                                    if (resultado == -5)
                                    {
                                        MessageBox.Show("Solo se puede agendar cada 20 minutos.");
                                    }
                                    if (resultado == -6)
                                    {
                                        MessageBox.Show("Inserte una hora válida.");
                                    }
                                    if (resultado == -7)
                                    {
                                        MessageBox.Show("Ya existe otra cita.");
                                    }
                                }
                            }
                            else
                            {
                                int resultado = LogicaCitas.capturarCita(objCita);

                                if (resultado >= 0)
                                {
                                    MessageBox.Show("Cita capturada");
                                }
                                else
                                {
                                    if (resultado == -1)
                                    {
                                        MessageBox.Show("No se puede agendar antes de la fecha actual.");
                                    }
                                    if (resultado == -2)
                                    {
                                        MessageBox.Show("No se puede agendar a más de 60 días después de la fecha actual.");
                                    }
                                    if (resultado == -3)
                                    {
                                        MessageBox.Show("No se puede agendar en domingo.");
                                    }
                                    if (resultado == -4)
                                    {
                                        MessageBox.Show("Fecha no disponible.");
                                    }
                                    if (resultado == -5)
                                    {
                                        MessageBox.Show("Solo se puede agendar cada 20 minutos.");
                                    }
                                    if (resultado == -6)
                                    {
                                        MessageBox.Show("Inserte una hora válida.");
                                    }
                                    if (resultado == -7)
                                    {
                                        MessageBox.Show("Ya existe otra cita.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El teléfono solo puede contener números");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario solo puede contener letras y espacio");
                    }
                }
                else
                {
                    MessageBox.Show("Inserte teléfono");
                }
            }
            else
            {
                MessageBox.Show("Inserte nombre");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAgendarCita_Load(object sender, EventArgs e)
        {
            if (modificar == true)
            {
                textBoxNombre.Text = objCita.NombrePaciente;
                dateTimePickerFecha.Value = objCita.FechaCita;
                maskedTextBoxHora.Text = objCita.HoraCita.ToString();
                checkBoxPrimeraVez.Checked = objCita.PrimeraVez;
                textBoxTelefono.Text = objCita.Telefono;

                if (objCita.Afiliacion == "Carls Jr.")
                {
                    radioButtonCarlsJr.Checked = true;
                }
                if (objCita.Afiliacion == "PEMEX")
                {
                    radioButtonPemex.Checked = true;
                }
                if (objCita.Afiliacion == "Ninguna")
                {
                    radioButtonNinguno.Checked = true;
                }
            }
        }
    }
}
