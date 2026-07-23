using Estadisticas.BusinessLogic;
using Helpers.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Estadisticas.Presentation
{
    public partial class FormEstadisticas : Form
    {
        public FormEstadisticas()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicioEstadisticas.Value;
            DateTime fin = dateTimeFinEstadisticas.Value;
            string filtroPaciente = textBoxFiltroPaciente.Text;

            List<EstadisticaDiagnostico> diagnosticos = LogicaEstadisticas.obtenerEstadisticasDiagnostico(inicio, fin, filtroPaciente);

            if (diagnosticos.Count == 0)
            {
                MessageBox.Show("No hay diagnósticos en el rango de fechas o filtro seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            dataGridViewEstadisticas.DataSource = diagnosticos;
        }

        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicioGrafica.Value;
            DateTime fin = dateTimeFinGrafica.Value;

            if (Validaciones.esRangoFechasValido(inicio, fin))
            {
                List<DiagnosticoPatologia> diagnosticos = LogicaEstadisticas.obtenerDiagnosticosPorPatologia(inicio, fin);
                chartPatologia.Series.Clear();

                if(diagnosticos.Count == 0)
                {
                    chartPatologia.Visible = false;
                    MessageBox.Show("No hay diagnósticos en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    chartPatologia.Visible = true;

                    Series seriePatologia = new Series("Diagnosticos");
                    seriePatologia.ChartArea = chartPatologia.ChartAreas[0].Name;
                    seriePatologia.ChartType = SeriesChartType.Column;
                    seriePatologia.IsValueShownAsLabel = true;

                    foreach(DiagnosticoPatologia obj in diagnosticos)
                    {
                        seriePatologia.Points.AddXY(obj.Patologia, obj.Cantidad);
                    }

                    chartPatologia.Series.Add(seriePatologia);
                    chartPatologia.ChartAreas[0].AxisX.Interval = 1;
                    chartPatologia.ChartAreas[0].AxisY.LabelStyle.Angle = -45;

                }
            }
            else
            {
                MessageBox.Show("El rango de fechas no es válido. La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
