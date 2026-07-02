using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Consultas.BusinessLogic;

namespace Consultas.Presentation
{
    public partial class FormConsulta : Form
    {
        int idPaciente;
        string nombrePaciente;

        public FormConsulta(int idPaciente, string nombrePaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
            this.nombrePaciente = nombrePaciente;
        }

        private void buttonCancelar_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Consulta objConsulta = new Consulta();

            if (Validaciones.esNumeroDecimal(textBoxPeso.Text))
            {
                if (Validaciones.esNumeroDecimal(textBoxTalla.Text))
                {
                    if (Validaciones.esNumeroDecimal(textBoxTemperatura.Text))
                    {
                        if (Validaciones.esNumeroEntero(textBoxFrecCardiaca.Text))
                        {
                            if (Validaciones.esNumeroEntero(textBoxFrecRespiratoria.Text))
                            {
                                if (Validaciones.esCadena(textBoxResponsabilidad.Text))
                                {
                                    if (Validaciones.esFraccionario(textBoxPresionArt.Text))
                                    {
                                        if (dateTimePickerFecha.Value.Date >= DateTime.Today.Date)
                                        {
                                            objConsulta.IdPaciente = idPaciente;
                                            objConsulta.FechaConsulta = dateTimePickerFecha.Value;
                                            objConsulta.Motivo = textBoxMotivo.Text;
                                            objConsulta.Responsabilidad = textBoxResponsabilidad.Text;
                                            objConsulta.FrecuenciaCardiaca = Int32.Parse(textBoxFrecCardiaca.Text);
                                            objConsulta.FrecuenciaRespiratoria = Int32.Parse(textBoxFrecRespiratoria.Text);
                                            objConsulta.TensionArterial = textBoxPresionArt.Text;
                                            objConsulta.Peso = Double.Parse(textBoxPeso.Text);
                                            objConsulta.Talla = Double.Parse(textBoxTalla.Text);
                                            objConsulta.Temperatura = Double.Parse(textBoxTemperatura.Text);
                                            objConsulta.Diagnostico = textBoxDiagnostico.Text;

                                            DialogResult result1 = MessageBox.Show("¿Está seguro que desea guardar la consulta?", "Eliminar usuario", MessageBoxButtons.YesNo);

                                            if (result1 == DialogResult.Yes)
                                            {
                                                int result = LogicaConsulta.nuevaConsulta(objConsulta);

                                                if (result > 0)
                                                {
                                                    MessageBox.Show("Consulta registrada");

                                                    Close();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La fecha de consulta no puede ser anterior a la fecha de hoy.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La tensión arterial debe estar estar en fracción.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Responsabilidad solo admite caracteres alfabéticos y espacio.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Frecuencia cardiaca solo admite numeros enteros.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Frecuencia cardiaca solo admite numeros enteros.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Temperatura solo admite numeros enteros y decimales.");
                    }
                }
                else
                {
                    MessageBox.Show("Talla solo admite numeros enteros y decimales.");
                }
            }
            else
            {
                MessageBox.Show("Peso solo admite numeros enteros y decimales.");
            }
        }

        private void FormConsulta_Load(object sender, EventArgs e)
        {
            labelNomPaciente.Text += nombrePaciente;
        }
    }
}
