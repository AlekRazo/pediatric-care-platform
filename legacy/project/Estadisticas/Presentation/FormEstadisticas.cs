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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Estadisticas.Presentation
{
    public partial class FormEstadisticas : Form
    {
        private List<EstadisticaDiagnostico> diagnosticosActuales;
        private List<DiagnosticoPatologia> patologiasActuales;
        private bool diagnosticosVigentes = false;
        private bool graficaVigente = false;

        public FormEstadisticas()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicioEstadisticas.Value;
            DateTime fin = dateTimeFinEstadisticas.Value;
            string filtroPaciente = textBoxFiltroPaciente.Text;

            diagnosticosActuales = LogicaEstadisticas.obtenerEstadisticasDiagnostico(inicio, fin, filtroPaciente);

            if (diagnosticosActuales.Count == 0)
            {
                MessageBox.Show("No hay diagnósticos en el rango de fechas o filtro seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                diagnosticosVigentes = false;
            }
            else
            {
                diagnosticosVigentes = true;
            }
            
            dataGridViewEstadisticas.DataSource = diagnosticosActuales;
            buttonGenerarReporteDiagnostico.Enabled = diagnosticosVigentes;
        }

        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            DateTime inicio = dateTimeInicioGrafica.Value;
            DateTime fin = dateTimeFinGrafica.Value;

            if (Validaciones.esRangoFechasValido(inicio, fin))
            {
                patologiasActuales = LogicaEstadisticas.obtenerDiagnosticosPorPatologia(inicio, fin);
                chartPatologia.Series.Clear();

                if(patologiasActuales.Count == 0)
                {
                    chartPatologia.Visible = false;
                    MessageBox.Show("No hay diagnósticos en el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    graficaVigente = false;
                }
                else
                {
                    chartPatologia.Visible = true;

                    Series seriePatologia = new Series("Diagnosticos");
                    seriePatologia.ChartArea = chartPatologia.ChartAreas[0].Name;
                    seriePatologia.ChartType = SeriesChartType.Column;
                    seriePatologia.IsValueShownAsLabel = true;

                    foreach(DiagnosticoPatologia obj in patologiasActuales)
                    {
                        seriePatologia.Points.AddXY(obj.Patologia, obj.Cantidad);
                    }

                    chartPatologia.Series.Add(seriePatologia);
                    chartPatologia.ChartAreas[0].AxisX.Interval = 1;
                    chartPatologia.ChartAreas[0].AxisY.LabelStyle.Angle = -45;

                    graficaVigente = true;
                }
            }
            else
            {
                MessageBox.Show("El rango de fechas no es válido. La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                graficaVigente = false;
            }

            buttonGenerarReportePatologia.Enabled = graficaVigente;
        }

        private void buttonGenerarReportePatologia_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialogo.FileName = "Patologia_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
            dialogo.Title = "Guardar reporte de patología";

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string carpetaTrabajo = Path.GetDirectoryName(dialogo.FileName);
            List<string> imagenesTemporal = new List<string>();

            Document documento = crearDocumentoBase("Reporte de Patologías");
            agregarEncabezadoSeccion(documento, "Gráfica de Patologías", dateTimeInicioGrafica.Value, dateTimeFinGrafica.Value, null);

            byte[] imagenPatologia = exportarComoImagen(chartPatologia);
            imagenesTemporal.Add(agregarImagen(documento, imagenPatologia, 16, carpetaTrabajo));

            guardarPdf(documento, dialogo.FileName, imagenesTemporal);

            System.Diagnostics.Process.Start(dialogo.FileName);
        }

        private void buttonGenerarReporteDiagnostico_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
            dialogo.FileName = "Diagnosticos_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
            dialogo.Title = "Guardar reporte de estadísticas de diagnóstico";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                Document documento = crearDocumentoBase("Reporte de Estadísticas de Diagnóstico");
                agregarEncabezadoSeccion(documento, "Diagnósticos", dateTimeInicioEstadisticas.Value, dateTimeFinEstadisticas.Value, textBoxFiltroPaciente.Text);
                agregarTablaDiagnosticos(documento, diagnosticosActuales);

                guardarPdf(documento, dialogo.FileName, new List<string>());

                System.Diagnostics.Process.Start(dialogo.FileName);
            }
        }

        private void dateTimeInicioEstadisticas_ValueChanged(object sender, EventArgs e)
        {
            diagnosticosVigentes = false;
            buttonGenerarReporteDiagnostico.Enabled = false;
        }

        private void dateTimeFinEstadisticas_ValueChanged(object sender, EventArgs e)
        {
            diagnosticosVigentes = false;
            buttonGenerarReporteDiagnostico.Enabled = false;
        }

        private void textBoxFiltroPaciente_TextChanged(object sender, EventArgs e)
        {
            diagnosticosVigentes = false;
            buttonGenerarReporteDiagnostico.Enabled = false;
        }

        private void dateTimeInicioGrafica_ValueChanged(object sender, EventArgs e)
        {
            graficaVigente = false;
            buttonGenerarReportePatologia.Enabled = false;
        }

        private void dateTimeFinGrafica_ValueChanged(object sender, EventArgs e)
        {
            graficaVigente = false;
            buttonGenerarReportePatologia.Enabled = false;
        }

        private Document crearDocumentoBase(string tituloReporte)
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

                Paragraph fechaGeneracion = seccion.AddParagraph();
                fechaGeneracion.AddFormattedText("Fecha del reporte: ", TextFormat.Bold);
                fechaGeneracion.AddText(DateTime.Now.ToString("dd/MM/yyyy"));
                fechaGeneracion.Format.SpaceAfter = "0.7cm";

                return documento;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void agregarEncabezadoSeccion(Document documento, string tituloSeccion, DateTime inicio, DateTime fin, string filtroPaciente)
        {
            try
            {
                Section seccion = documento.LastSection;

                Paragraph encabezado = seccion.AddParagraph(tituloSeccion);
                encabezado.Format.Font.Size = 13;
                encabezado.Format.Font.Bold = true;
                encabezado.Format.SpaceBefore = "0.5cm";
                encabezado.Format.SpaceAfter = "0.3cm";

                Paragraph criterios = seccion.AddParagraph();
                criterios.AddFormattedText("Rango: ", TextFormat.Bold);
                criterios.AddText(inicio.ToString("dd/MM/yyyy") + " - " + fin.ToString("dd/MM/yyyy"));

                if (!string.IsNullOrEmpty(filtroPaciente))
                {
                    criterios.AddLineBreak();
                    criterios.AddFormattedText("Filtro de paciente: ", TextFormat.Bold);
                    criterios.AddText(filtroPaciente);
                }

                criterios.Format.SpaceAfter = "0.4cm";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void agregarTablaDiagnosticos(Document documento, List<EstadisticaDiagnostico> diagnosticos)
        {
            try
            {
                Section seccion = documento.LastSection;

                Table tabla = seccion.AddTable();
                tabla.Borders.Width = 0.5;
                tabla.Borders.Color = Colors.Gray;

                Column colMotivo = tabla.AddColumn(Unit.FromCentimeter(10));
                Column colCantidad = tabla.AddColumn(Unit.FromCentimeter(4));
                colCantidad.Format.Alignment = ParagraphAlignment.Center;

                Row filaEncabezado = tabla.AddRow();
                filaEncabezado.Shading.Color = Colors.LightGray;
                filaEncabezado.Format.Font.Bold = true;
                filaEncabezado.Cells[0].AddParagraph("Motivo");
                filaEncabezado.Cells[1].AddParagraph("Cantidad");

                foreach (EstadisticaDiagnostico diag in diagnosticos)
                {
                    Row fila = tabla.AddRow();
                    fila.Cells[0].AddParagraph(diag.Motivo);
                    fila.Cells[1].AddParagraph(diag.Cantidad.ToString());
                }

                Paragraph espacio = seccion.AddParagraph();
                espacio.Format.SpaceAfter = "0.7cm";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void guardarPdf(Document documento, string rutaDestino, List<string> imagenesTemporal)
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
    }
}
