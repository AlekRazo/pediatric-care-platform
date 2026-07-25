using Estadisticas.BusinessLogic;
using Helpers.Helpers;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
                        int index = seriePesoReferencia.Points.AddXY(punto.MesEdad, punto.Valor);

                        if (curva.EsPaciente)
                        {
                            seriePesoReferencia.Points[index].Label = punto.Valor + " (" + Math.Round(punto.Percentil, 2) + ")";
                        }
                    }

                    chartPesoPaciente.Series.Add(seriePesoReferencia);
                }

                chartPesoPaciente.ChartAreas[0].AxisX.Title = "Peso (kg)";
                chartPesoPaciente.ChartAreas[0].AxisX.Interval = 1;
                chartPesoPaciente.ChartAreas[0].AxisY.Title = "Edad (meses)";
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
                        int index = serieTallaReferencia.Points.AddXY(punto.MesEdad, punto.Valor);

                        if (curva.EsPaciente)
                        {
                            serieTallaReferencia.Points[index].Label = punto.Valor + " (" + Math.Round(punto.Percentil, 2) + ")";
                        }
                    }

                    chartTallaPaciente.Series.Add(serieTallaReferencia);
                }

                chartTallaPaciente.ChartAreas[0].AxisX.Title = "Talla (cm)";
                chartTallaPaciente.ChartAreas[0].AxisX.Interval = 1;
                chartTallaPaciente.ChartAreas[0].AxisY.Title = "Edad (meses)";
                chartTallaPaciente.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            }
            else
            {
                labelLimiteTalla.Text = "No hay datos para mostrar.";
            }
        }

        private void buttonGuardarGraficas_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialogo.FileName = "Percentiles_" + paciente.NombrePaciente + ".pdf";
            dialogo.Title = "Guardar reporte de percentiles";

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string carpetaTrabajo = Path.GetDirectoryName(dialogo.FileName);
            List<string> imagenesTemporal = new List<string>();

            byte[] imagenPeso = exportarComoImagen(chartPesoPaciente);
            byte[] imagenTalla = exportarComoImagen(chartTallaPaciente);

            Document documento = crearDocumentoBase(paciente, "Reporte de Percentiles");
            imagenesTemporal.Add(agregarImagen(documento, imagenPeso, 16, carpetaTrabajo));
            imagenesTemporal.Add(agregarImagen(documento, imagenTalla, 16, carpetaTrabajo));

            guardarPdf(documento, dialogo.FileName, imagenesTemporal);

            System.Diagnostics.Process.Start(dialogo.FileName);
        }

        private Document crearDocumentoBase(Paciente paciente, string tituloReporte)
        {
            try
            {
                Document documento = new Document();
                documento.Info.Title = tituloReporte;

                Section seccion = documento.AddSection();

                Paragraph titulo = seccion.AddParagraph(tituloReporte);
                titulo.Format.Font.Size = 16;
                titulo.Format.Font.Bold = true;
                titulo.Format.SpaceAfter = "0.5cm";

                Paragraph datosPaciente = seccion.AddParagraph();
                datosPaciente.AddFormattedText("Paciente: ", TextFormat.Bold);
                datosPaciente.AddText(paciente.NombrePaciente);
                datosPaciente.AddLineBreak();
                datosPaciente.AddFormattedText("Fecha de nacimiento: ", TextFormat.Bold);
                datosPaciente.AddText(paciente.FechaNacimiento.ToString("dd/MM/yyyy"));
                datosPaciente.AddLineBreak();
                datosPaciente.AddFormattedText("Sexo: ", TextFormat.Bold);
                datosPaciente.AddText(paciente.Sexo);
                datosPaciente.AddLineBreak();
                datosPaciente.AddFormattedText("Fecha del reporte: ", TextFormat.Bold);
                datosPaciente.AddText(DateTime.Now.ToString("dd/MM/yyyy"));
                datosPaciente.Format.SpaceAfter = "0.7cm";

                return documento;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Inserta una imagen (ej. la gráfica exportada) en el documento, escrita primero a disco temporal
        // porque MigraDoc no soporta imágenes directamente desde memoria.
        private string agregarImagen(Document documento, byte[] imagenBytes, double anchoCm, string carpetaTrabajo)
        {
            try
            {
                string rutaTemporal = Path.Combine(carpetaTrabajo, Guid.NewGuid().ToString() + ".png");
                File.WriteAllBytes(rutaTemporal, imagenBytes);

                Section seccion = documento.LastSection;
                MigraDoc.DocumentObjectModel.Shapes.Image imagen = seccion.AddImage(rutaTemporal);
                imagen.Width = Unit.FromCentimeter(anchoCm);
                imagen.LockAspectRatio = true;

                return rutaTemporal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Renderiza el documento y lo guarda como PDF en la ruta indicada.
        public void guardarPdf(Document documento, string rutaDestino, List<string> imagenesTemporal)
        {
            try
            {
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                renderer.Document = documento;
                renderer.RenderDocument();
                renderer.PdfDocument.Save(rutaDestino);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                foreach (string ruta in imagenesTemporal)
                {
                    if (File.Exists(ruta))
                    {
                        File.Delete(ruta);
                    }
                }
            }
        }

        // Convierte un Chart ya poblado en un arreglo de bytes PNG, listo para incrustar en el PDF.
        private byte[] exportarComoImagen(Chart chart)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    chart.SaveImage(stream, ChartImageFormat.Png);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void agregarTablaEstadisticas(Document documento, List<PuntoCrecimiento> crecimiento)
        {
            try
            {
                Section seccion = documento.LastSection;

                Table tabla = seccion.AddTable();
                tabla.Borders.Width = 0.5;
                tabla.Borders.Color = Colors.Gray;

                Column colMes = tabla.AddColumn(Unit.FromCentimeter(4));
                colMes.Format.Alignment = ParagraphAlignment.Center;

                Column colPeso = tabla.AddColumn(Unit.FromCentimeter(4));
                colPeso.Format.Alignment = ParagraphAlignment.Center;

                Column colTalla = tabla.AddColumn(Unit.FromCentimeter(4));
                colTalla.Format.Alignment = ParagraphAlignment.Center;

                Row filaEncabezado = tabla.AddRow();
                filaEncabezado.Shading.Color = Colors.LightGray;
                filaEncabezado.Format.Font.Bold = true;
                filaEncabezado.Cells[0].AddParagraph("Edad (meses)");
                filaEncabezado.Cells[1].AddParagraph("Peso (kg)");
                filaEncabezado.Cells[2].AddParagraph("Talla (cm)");

                foreach (PuntoCrecimiento punto in crecimiento)
                {
                    Row fila = tabla.AddRow();
                    fila.Cells[0].AddParagraph(punto.EdadMeses.ToString());
                    fila.Cells[1].AddParagraph(punto.Peso.ToString("F1"));
                    fila.Cells[2].AddParagraph(punto.Talla.ToString("F1"));
                }

                Paragraph espacio = seccion.AddParagraph();
                espacio.Format.SpaceAfter = "0.7cm";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void buttonGuardarEstadísticas_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialogo.FileName = "Estadisticas_" + paciente.NombrePaciente + ".pdf";
            dialogo.Title = "Guardar reporte de estadísticas de peso y estatura";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string carpetaTrabajo = Path.GetDirectoryName(dialogo.FileName);
                List<string> imagenesTemporal = new List<string>();
                List<PuntoCrecimiento> crecimiento = LogicaEstadisticas.obtenerCurvaCrecimiento(paciente.IdPaciente);
                byte[] imagenPeso = exportarComoImagen(chartPesoPaciente);
                byte[] imagenTalla = exportarComoImagen(chartTallaPaciente);

                Document documento = crearDocumentoBase(paciente, "Reporte de Estadísticas de Peso y Estatura");
                agregarTablaEstadisticas(documento, crecimiento);
                imagenesTemporal.Add(agregarImagen(documento, imagenPeso, 16, carpetaTrabajo));
                imagenesTemporal.Add(agregarImagen(documento, imagenTalla, 16, carpetaTrabajo));

                guardarPdf(documento, dialogo.FileName, imagenesTemporal);

                System.Diagnostics.Process.Start(dialogo.FileName);
            }
        }
    }
}
