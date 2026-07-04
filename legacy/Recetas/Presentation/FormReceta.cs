using Recetas.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recetas.Presentation
{
    public partial class FormReceta : Form
    {
        int idPaciente;
        int idConsulta;
        double peso;
        double talla;
        DateTime fechaConsulta;
        string nombrePaciente;

        public FormReceta(string nombrePaciente, int idPaciente, int idConsulta, double peso, double talla, DateTime fechaConsulta)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
            this.idConsulta = idConsulta;
            this.peso = peso;
            this.talla = talla;
            this.fechaConsulta = fechaConsulta;
            this.nombrePaciente = nombrePaciente;
        }

        private void FormReceta_Load(object sender, EventArgs e)
        {
            labelNomPaciente.Text += nombrePaciente;
            textBoxPeso.Text = peso.ToString();
            textBoxTalla.Text = talla.ToString();
            dateTimePickerFecha.Value = fechaConsulta;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Receta objReceta = new Receta();

            if (Validaciones.esNumeroDecimal(textBoxPeso.Text))
            {
                if (Validaciones.esNumeroDecimal(textBoxTalla.Text))
                {
                    if (dateTimePickerFecha.Value.Date >= DateTime.Today.Date)
                    {
                        objReceta.IdPaciente = idPaciente;
                        objReceta.IdConsulta = idConsulta;
                        objReceta.FechaConsulta = dateTimePickerFecha.Value;
                        objReceta.Peso = Double.Parse(textBoxPeso.Text);
                        objReceta.Talla = Double.Parse(textBoxTalla.Text);
                        objReceta.Descripcion = textBoxReceta.Text;

                        DialogResult result1 = MessageBox.Show("¿Está seguro que desea guardar la consulta?", "Consulta", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {
                            int result = LogicaReceta.nuevaReceta(objReceta);

                            if (result > 0)
                            {
                                MessageBox.Show("Receta registrada");

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
                    MessageBox.Show("Talla solo admite numeros enteros y decimales.");
                }
            }
            else
            {
                MessageBox.Show("Peso solo admite numeros enteros y decimales.");
            }
        }

        private void FormReceta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
