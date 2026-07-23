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

            //Limpieza y preparación de las gráficas
            chartPesoPaciente.Series.Clear();

            int edadMeses = LogicaPercentiles.calcularEdadMeses(paciente.FechaNacimiento, DateTime.Now);

            if (edadMeses > 24)
            {
                edadMeses = 24;
            }

            List<ParametrosLMS> parametrosLMS = LogicaPercentiles.obtenerParametrosLMS("Peso", edadMeses, paciente.Sexo);
            List<PuntoCrecimiento> crecimiento = LogicaEstadisticas.obtenerCurvaCrecimiento(idPaciente);

            if (crecimiento.Count > 0)
            {

                for (int i = 0; i <= 4; i++)
                {
                    double z = LogicaPercentiles.valoresZPercentiles[i];
                    string nombre = LogicaPercentiles.nombresPercentiles[i];
                    Series seriePesoReferencia = new Series(nombre);
                    seriePesoReferencia.ChartArea = chartPesoPaciente.ChartAreas[0].Name;
                    seriePesoReferencia.ChartType = SeriesChartType.Line;
                    seriePesoReferencia.IsValueShownAsLabel = false;

                    for (int mes = 0; mes <= edadMeses; mes++)
                    {
                        ParametrosLMS lms = LogicaPercentiles.seleccionarParametroPorMes(parametrosLMS, "Peso", mes);
                        double pesoEsperado = LogicaPercentiles.obtenerValorEsperado(z, lms);
                        seriePesoReferencia.Points.AddXY(mes, pesoEsperado);
                    }

                    chartPesoPaciente.Series.Add(seriePesoReferencia);
                }

                Series seriePeso = new Series(paciente.NombrePaciente);
                seriePeso.ChartArea = chartPesoPaciente.ChartAreas[0].Name;
                seriePeso.ChartType = SeriesChartType.Line;
                seriePeso.IsValueShownAsLabel = true;

                foreach (PuntoCrecimiento punto in crecimiento)
                {
                    seriePeso.Points.AddXY(punto.EdadMeses, punto.Peso);
                }

                chartPesoPaciente.Series.Add(seriePeso);
                chartPesoPaciente.ChartAreas[0].AxisX.Interval = 1;
                chartPesoPaciente.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            }
            else
            {
                MessageBox.Show("No hay datos para mostrar.");
            }
        }
    }
}
