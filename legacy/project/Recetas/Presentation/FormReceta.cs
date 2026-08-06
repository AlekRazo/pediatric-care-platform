using Helpers.Helpers;
using Recetas.BusinessLogic;
using System;
using System.Drawing;
using System.Drawing.Printing;
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
        bool recetaImpresa;
        bool recetaGuardada;

        public FormReceta(string nombrePaciente, int idPaciente, int idConsulta, double peso, double talla, DateTime fechaConsulta)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
            this.idConsulta = idConsulta;
            this.peso = peso;
            this.talla = talla;
            this.fechaConsulta = fechaConsulta;
            this.nombrePaciente = nombrePaciente;
            recetaImpresa = false;
            recetaGuardada = false;
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
            if (Validaciones.esNumeroDecimal(textBoxPeso.Text))
            {
                if (Validaciones.esNumeroDecimal(textBoxTalla.Text))
                {
                    if (dateTimePickerFecha.Value.Date >= DateTime.Today.Date)
                    {
                        if (recetaGuardada == false)
                        {
                            DialogResult result1 = MessageBox.Show("¿Está seguro que desea guardar la receta?", "Receta", MessageBoxButtons.YesNo);

                            if (result1 == DialogResult.Yes)
                            {
                                Receta objReceta = new Receta();
                                objReceta.IdPaciente = idPaciente;
                                objReceta.IdConsulta = idConsulta;
                                objReceta.FechaConsulta = dateTimePickerFecha.Value;
                                objReceta.Peso = Double.Parse(textBoxPeso.Text);
                                objReceta.Talla = Double.Parse(textBoxTalla.Text);
                                objReceta.Descripcion = textBoxReceta.Text;

                                try
                                {
                                    int result = LogicaReceta.nuevaReceta(objReceta);

                                    if (result > 0)
                                    {
                                        MessageBox.Show("Receta registrada");
                                        recetaGuardada = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo registrar la receta. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se pudo guardar la receta. Intenta de nuevo.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                return; // decidió no guardar todavía; no hay nada más que hacer en este clic
                            }
                        }

                        if (recetaImpresa == false)
                        {
                            DialogResult result2 = MessageBox.Show("¿Está seguro que desea salir sin imprimir la receta?", "Receta", MessageBoxButtons.YesNo);

                            if(result2 == DialogResult.Yes)
                            {
                                Close();
                            }
                        }
                        else
                        {
                            Close();
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

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog dialogoImprimir = new PrintDialog();
            dialogoImprimir.Document = printDocumentReceta;

            if (dialogoImprimir.ShowDialog() == DialogResult.OK)
            {
                printDocumentReceta.Print();
                recetaImpresa = true;
            }
        }

        private void printDocumentReceta_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontTitulo = new Font("Arial", 16, FontStyle.Bold);
            Font fontTexto = new Font("Arial", 11);

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            e.Graphics.DrawString("Receta Médica", fontTitulo, Brushes.Black, x, y);
            y += 40;

            e.Graphics.DrawString("Paciente: " + nombrePaciente, fontTexto, Brushes.Black, x, y);
            y += 25;
            e.Graphics.DrawString("Fecha: " + dateTimePickerFecha.Value.ToString("dd/MM/yyyy"), fontTexto, Brushes.Black, x, y);
            y += 25;
            e.Graphics.DrawString("Peso: " + textBoxPeso.Text + " kg", fontTexto, Brushes.Black, x, y);
            y += 25;
            e.Graphics.DrawString("Talla: " + textBoxTalla.Text + " cm", fontTexto, Brushes.Black, x, y);
            y += 35;

            e.Graphics.DrawString("Indicaciones:", fontTexto, Brushes.Black, x, y);
            y += 25;

            RectangleF areaTexto = new RectangleF(x, y, e.MarginBounds.Width, e.MarginBounds.Bottom - y);
            e.Graphics.DrawString(textBoxReceta.Text, fontTexto, Brushes.Black, areaTexto);
        }
    }
}
