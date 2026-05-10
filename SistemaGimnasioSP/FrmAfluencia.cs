using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    public partial class FrmAfluencia : Form
    {
        ConexionDB bd = new ConexionDB();

        public FrmAfluencia()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                chartProcedencia.InnerRadius = 50;
                chartDeportes.InnerRadius = 0;
            };
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            ActualizarGraficaActual();
        }

        private void tabMenuAfluencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGraficaActual();
        }

        private void ActualizarGraficaActual()
        {
            int index = tabMenuAfluencia.SelectedIndex;
            if (index == 0) CargarDatos("Deportes");
            else if (index == 1) CargarDatos("Horarios");
            else if (index == 2) CargarDatos("Edades");
            else if (index == 3) CargarDatos("Procedencia");
        }

        private void CargarDatos(string tipo)
        {
            MySqlConnection conexion = bd.AbrirConexion();
            if (conexion == null) return;

            try
            {
                string queryGrafica = "";
                string queryTabla = "";
                DataGridView dgvActual = null;
                dynamic chartActual = null;

                switch (tipo)
                {
                    case "Deportes":
                        queryTabla = @"SELECT a.id_acceso AS Folio, c.nombre AS Cliente, d.nombre_deporte AS Deporte, a.fecha_hora AS 'Fecha y Hora'
                               FROM accesos_diarios a 
                               INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                               INNER JOIN deportes d ON a.id_deporte = d.id_deporte 
                               WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin";

                        queryGrafica = @"SELECT d.nombre_deporte AS Concepto, COUNT(a.id_acceso) AS Total 
                                 FROM accesos_diarios a 
                                 INNER JOIN deportes d ON a.id_deporte = d.id_deporte 
                                 WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin 
                                 GROUP BY d.nombre_deporte";
                        dgvActual = dgvDeportes;
                        chartActual = chartDeportes;
                        break;

                    case "Procedencia":
                        queryTabla = @"SELECT a.id_acceso AS Folio, c.nombre AS Cliente, c.municipio AS Municipio, a.fecha_hora AS 'Fecha y Hora'
                               FROM accesos_diarios a 
                               INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                               WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin";

                        queryGrafica = @"SELECT c.municipio AS Concepto, COUNT(*) AS Total 
                                 FROM accesos_diarios a 
                                 INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                                 WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin 
                                 GROUP BY c.municipio";
                        dgvActual = dgvProcedencia;
                        chartActual = chartProcedencia;
                        break;

                    case "Horarios":
                        queryTabla = @"SELECT id_acceso AS Folio, fecha_hora AS 'Hora de Entrada' 
                               FROM accesos_diarios 
                               WHERE DATE(fecha_hora) BETWEEN @inicio AND @fin";

                        // CORRECCIÓN: Ordenamos por la misma expresión que agrupamos para evitar el error de la imagen
                        queryGrafica = @"SELECT CONCAT(HOUR(fecha_hora), ':00') AS Concepto, COUNT(*) AS Total 
                                 FROM accesos_diarios 
                                 WHERE DATE(fecha_hora) BETWEEN @inicio AND @fin 
                                 GROUP BY Concepto
                                 ORDER BY MIN(HOUR(fecha_hora)) ASC";
                        dgvActual = dgvHorarios;
                        chartActual = chartHorarios;
                        break;

                    case "Edades":
                        queryTabla = @"SELECT c.nombre AS Cliente, c.fecha_nacimiento AS 'F. Nacimiento', 
                               (YEAR(CURDATE())-YEAR(c.fecha_nacimiento)) AS Edad
                               FROM accesos_diarios a 
                               INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                               WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin";

                        queryGrafica = @"SELECT CASE 
                                    WHEN (YEAR(CURDATE())-YEAR(fecha_nacimiento)) < 18 THEN 'Menores' 
                                    WHEN (YEAR(CURDATE())-YEAR(fecha_nacimiento)) BETWEEN 18 AND 59 THEN 'Adultos' 
                                    ELSE 'Seniors' END AS Concepto, COUNT(*) AS Total 
                                  FROM accesos_diarios a INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                                  WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin GROUP BY Concepto";
                        dgvActual = dgvEdades;
                        chartActual = chartEdades;
                        break;
                }

                MySqlCommand cmdTabla = new MySqlCommand(queryTabla, conexion);
                cmdTabla.Parameters.AddWithValue("@inicio", VntnFechaInicio.Value.ToString("yyyy-MM-dd"));
                cmdTabla.Parameters.AddWithValue("@fin", VntnFechaFinal.Value.ToString("yyyy-MM-dd"));

                DataTable dtTabla = new DataTable();
                new MySqlDataAdapter(cmdTabla).Fill(dtTabla);
                dgvActual.DataSource = dtTabla;

                MySqlCommand cmdGrafica = new MySqlCommand(queryGrafica, conexion);
                cmdGrafica.Parameters.AddWithValue("@inicio", VntnFechaInicio.Value.ToString("yyyy-MM-dd"));
                cmdGrafica.Parameters.AddWithValue("@fin", VntnFechaFinal.Value.ToString("yyyy-MM-dd"));

                DataTable dtGrafica = new DataTable();
                new MySqlDataAdapter(cmdGrafica).Fill(dtGrafica);

                if (tipo == "Deportes" || tipo == "Procedencia")
                {
                    SeriesCollection series = new SeriesCollection();
                    foreach (DataRow fila in dtGrafica.Rows)
                    {
                        series.Add(new PieSeries { Title = fila["Concepto"].ToString(), Values = new ChartValues<int> { Convert.ToInt32(fila["Total"]) }, DataLabels = true });
                    }
                    chartActual.Series = series;
                }
                else
                {
                    ChartValues<int> valores = new ChartValues<int>();
                    List<string> etiquetas = new List<string>();
                    foreach (DataRow fila in dtGrafica.Rows)
                    {
                        etiquetas.Add(fila["Concepto"].ToString());
                        valores.Add(Convert.ToInt32(fila["Total"]));
                    }
                    chartActual.Series = new SeriesCollection {
                        tipo == "Horarios"
                        ? (Series)new LineSeries { Title = "Visitas", Values = valores }
                        : (Series)new ColumnSeries { Title = "Visitas", Values = valores, DataLabels = true }
                    };
                    chartActual.AxisX.Clear();
                    chartActual.AxisX.Add(new Axis { Labels = etiquetas });
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { bd.CerrarConexion(); }
        }

        private void BtnGenPDF_Click(object sender, EventArgs e)
        {
            DataGridView dgvActual = null;
            string tituloReporte = "";
            string queryResumen = "";
            int index = tabMenuAfluencia.SelectedIndex;

            if (index == 0)
            {
                dgvActual = dgvDeportes; tituloReporte = "AFLUENCIA POR DEPORTES";
                queryResumen = @"SELECT d.nombre_deporte AS Concepto, COUNT(a.id_acceso) AS Total 
                         FROM accesos_diarios a 
                         INNER JOIN deportes d ON a.id_deporte = d.id_deporte 
                         WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin GROUP BY d.nombre_deporte";
            }
            else if (index == 1)
            {
                dgvActual = dgvHorarios; tituloReporte = "AFLUENCIA POR HORARIOS";
                // CORRECCIÓN TAMBIÉN AQUÍ: Usamos MIN() en el ORDER BY para cumplir con la regla de agregación
                queryResumen = @"SELECT CONCAT(HOUR(fecha_hora), ':00') AS Concepto, COUNT(*) AS Total 
                         FROM accesos_diarios WHERE DATE(fecha_hora) BETWEEN @inicio AND @fin 
                         GROUP BY Concepto ORDER BY MIN(HOUR(fecha_hora)) ASC";
            }
            else if (index == 2)
            {
                dgvActual = dgvEdades; tituloReporte = "AFLUENCIA POR EDADES";
                queryResumen = @"SELECT CASE WHEN (YEAR(CURDATE())-YEAR(fecha_nacimiento)) < 18 THEN 'Menores' 
                         WHEN (YEAR(CURDATE())-YEAR(fecha_nacimiento)) BETWEEN 18 AND 59 THEN 'Adultos' 
                         ELSE 'Seniors' END AS Concepto, COUNT(*) AS Total 
                         FROM accesos_diarios a INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                         WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin GROUP BY Concepto";
            }
            else if (index == 3)
            {
                dgvActual = dgvProcedencia; tituloReporte = "AFLUENCIA POR PROCEDENCIA";
                queryResumen = @"SELECT c.municipio AS Concepto, COUNT(*) AS Total 
                         FROM accesos_diarios a INNER JOIN clientes c ON a.id_cliente = c.id_cliente 
                         WHERE DATE(a.fecha_hora) BETWEEN @inicio AND @fin GROUP BY c.municipio";
            }

            if (dgvActual == null || dgvActual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos cargados para exportar.", "Aviso");
                return;
            }

            SaveFileDialog save = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = $"Reporte_{tituloReporte.Replace(" ", "_")}.pdf" };

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 30, 30, 40, 40);
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                        var fuenteBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                        Paragraph p1 = new Paragraph("REPORTE GIMNASIO SP", fuenteTitulo);
                        p1.Alignment = Element.ALIGN_CENTER; doc.Add(p1);

                        Paragraph p2 = new Paragraph(tituloReporte, fuenteBold);
                        p2.Alignment = Element.ALIGN_CENTER; doc.Add(p2);

                        Paragraph p3 = new Paragraph($"Periodo: {VntnFechaInicio.Value:dd/MM/yyyy} al {VntnFechaFinal.Value:dd/MM/yyyy}", fuenteNormal);
                        p3.Alignment = Element.ALIGN_CENTER; doc.Add(p3);
                        doc.Add(new Paragraph("\n"));

                        PdfPTable tablaResumen = new PdfPTable(3) { WidthPercentage = 80, HorizontalAlignment = Element.ALIGN_CENTER };
                        tablaResumen.SetWidths(new float[] { 50f, 25f, 25f });

                        tablaResumen.AddCell(new PdfPCell(new Phrase("Categoría", fuenteBold)) { BackgroundColor = new BaseColor(230, 230, 230), HorizontalAlignment = Element.ALIGN_CENTER });
                        tablaResumen.AddCell(new PdfPCell(new Phrase("Registros", fuenteBold)) { BackgroundColor = new BaseColor(230, 230, 230), HorizontalAlignment = Element.ALIGN_CENTER });
                        tablaResumen.AddCell(new PdfPCell(new Phrase("Porcentaje (%)", fuenteBold)) { BackgroundColor = new BaseColor(230, 230, 230), HorizontalAlignment = Element.ALIGN_CENTER });

                        MySqlConnection conexion = bd.AbrirConexion();
                        MySqlCommand cmdResumen = new MySqlCommand(queryResumen, conexion);
                        cmdResumen.Parameters.AddWithValue("@inicio", VntnFechaInicio.Value.ToString("yyyy-MM-dd"));
                        cmdResumen.Parameters.AddWithValue("@fin", VntnFechaFinal.Value.ToString("yyyy-MM-dd"));

                        DataTable dtResumen = new DataTable();
                        new MySqlDataAdapter(cmdResumen).Fill(dtResumen);

                        double totalGeneral = 0;
                        foreach (DataRow r in dtResumen.Rows) totalGeneral += Convert.ToDouble(r["Total"]);

                        foreach (DataRow fila in dtResumen.Rows)
                        {
                            double valor = Convert.ToDouble(fila["Total"]);
                            double porc = (totalGeneral > 0) ? (valor / totalGeneral) * 100 : 0;

                            tablaResumen.AddCell(new Phrase(fila["Concepto"].ToString(), fuenteNormal));
                            tablaResumen.AddCell(new PdfPCell(new Phrase(valor.ToString(), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                            tablaResumen.AddCell(new PdfPCell(new Phrase($"{porc:F1}%", fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        }
                        conexion.Close();
                        doc.Add(tablaResumen);

                        doc.Add(new Paragraph("\n" + new string('-', 100) + "\n"));
                        doc.Add(new Paragraph("DETALLE COMPLETO DE INGRESOS", fuenteBold));
                        doc.Add(new Paragraph("\n"));

                        PdfPTable tablaDetalle = new PdfPTable(dgvActual.Columns.Count) { WidthPercentage = 100 };
                        foreach (DataGridViewColumn col in dgvActual.Columns)
                        {
                            PdfPCell hCell = new PdfPCell(new Phrase(col.HeaderText, fuenteBold));
                            hCell.BackgroundColor = new BaseColor(245, 245, 245);
                            hCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            tablaDetalle.AddCell(hCell);
                        }

                        foreach (DataGridViewRow row in dgvActual.Rows)
                        {
                            if (row.IsNewRow) continue;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                tablaDetalle.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", fuenteNormal)));
                            }
                        }

                        doc.Add(tablaDetalle);
                        doc.Close();
                    }
                    MessageBox.Show("Reporte generado con éxito.", "Gimnasio SP");
                }
                catch (Exception ex) { MessageBox.Show("Error al generar PDF: " + ex.Message); }
            }
        }
    }
}