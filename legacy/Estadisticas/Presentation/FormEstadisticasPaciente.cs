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
    public partial class FormEstadisticasPaciente : Form
    {
        private int idPaciente;
        private Paciente paciente;

        public FormEstadisticasPaciente(int idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
        }

        private void FormEstadisticasPaciente_Load(object sender, EventArgs e)
        {
            paciente = LogicaPercentiles.obtenerPacientePorId(idPaciente);
            labelPaciente.Text += " " + paciente.NombrePaciente;
            int edadMeses  = LogicaPercentiles.calcularEdadMeses(paciente.FechaNacimiento, DateTime.Now);

            //Limpieza y preparación de las gráficas
            generarCurvasPeso(paciente);
            generarCurvasTalla(paciente);

            if (edadMeses > LogicaPercentiles.edadMesesMaxima)
            {
                labelLimitePeso.Text = "Gráficos hasta los 5 años.";
                labelLimiteTalla.Text = "Gráficos hasta los 5 años.";
            }
        }

        private void generarCurvasPeso(Paciente paciente)
        {
            List<CurvaPercentil> curvas = LogicaPercentiles.generarCurvasReferencia(paciente, "Peso");

            chartPesoPaciente.Series.Clear();

            if (curvas.Count > 0)
            {
                foreach (CurvaPercentil curva in curvas)
                {
                    Series seriePesoReferencia = new Series(curva.Nombre);
                    seriePesoReferencia.ChartArea = chartPesoPaciente.ChartAreas[0].Name;
                    seriePesoReferencia.ChartType = SeriesChartType.Line;
                    seriePesoReferencia.IsValueShownAsLabel = curva.EsPaciente;

                    foreach (PuntoReferencia punto in curva.Puntos)
                    {
                        seriePesoReferencia.Points.AddXY(punto.MesEdad, punto.Valor);
                    }

                    chartPesoPaciente.Series.Add(seriePesoReferencia);
                }

                chartPesoPaciente.ChartAreas[0].AxisX.Interval = 1;
                chartPesoPaciente.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            }
            else
            {
                labelLimitePeso.Text = "No hay datos para mostrar.";
            }
        }

        private void generarCurvasTalla(Paciente paciente)
        {
            List<CurvaPercentil> curvas = LogicaPercentiles.generarCurvasReferencia(paciente, "Talla");

            chartTallaPaciente.Series.Clear();

            if (curvas.Count > 0)
            {
                foreach (CurvaPercentil curva in curvas)
                {
                    Series serieTallaReferencia = new Series(curva.Nombre);
                    serieTallaReferencia.ChartArea = chartTallaPaciente.ChartAreas[0].Name;
                    serieTallaReferencia.ChartType = SeriesChartType.Line;
                    serieTallaReferencia.IsValueShownAsLabel = curva.EsPaciente;

                    foreach (PuntoReferencia punto in curva.Puntos)
                    {
                        serieTallaReferencia.Points.AddXY(punto.MesEdad, punto.Valor);
                    }

                    chartTallaPaciente.Series.Add(serieTallaReferencia);
                }

                chartTallaPaciente.ChartAreas[0].AxisX.Interval = 1;
                chartTallaPaciente.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            }
            else
            {
                labelLimiteTalla.Text = "No hay datos para mostrar.";
            }
        }
    }
}
