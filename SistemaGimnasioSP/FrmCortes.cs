using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextFont = iTextSharp.text.Font;

namespace SistemaGimnasioSP
{
    public partial class FrmCortes : Form
    {
        public FrmCortes()
        {
            InitializeComponent();
        }

        private void FrmCortes_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            int diasRestar = (int)hoy.DayOfWeek - (int)DayOfWeek.Thursday;
            if (diasRestar < 0) diasRestar += 7;

            dtpDesde.Value = hoy.AddDays(-diasRestar);
            dtpHasta.Value = hoy;

            CargarProximoFolio();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            GenerarCorte();
        }

        private void GenerarCorte()
        {
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion == null) return;

            try
            {
                // SQL Optimizado: Agrupa por cliente y fecha, suma montos y concatena deportes.
                string query = @"
                    SELECT 
                        CONCAT('1-', LPAD(MIN(i.id_inscripcion), 5, '0')) AS Folio,
                        i.fecha_pago AS Fecha,
                        c.nombre AS Cliente,
                        GROUP_CONCAT(d.nombre_deporte SEPARATOR ', ') AS Conceptos,
                        (
                            IF(c.municipio = 'San Pedro Garza García', MAX(d.precio_local), MAX(d.precio_foraneo)) 
                            + (COUNT(i.id_inscripcion) - 1) * 200
                        ) AS Total_Pagado
                    FROM inscripciones i
                    INNER JOIN clientes c ON i.id_cliente = c.id_cliente
                    INNER JOIN deportes d ON i.id_deporte = d.id_deporte
                    WHERE i.fecha_pago >= @inicio AND i.fecha_pago <= @fin
                    GROUP BY i.id_cliente, i.fecha_pago, c.nombre, c.municipio
                    ORDER BY i.fecha_pago DESC, Folio ASC";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@inicio", dtpDesde.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fin", dtpHasta.Value.ToString("yyyy-MM-dd"));

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                DataTable tablaCortes = new DataTable();
                adaptador.Fill(tablaCortes);

                // Sumamos el Gran Total directo de la columna calculada por SQL
                decimal granTotal = 0;
                foreach (DataRow fila in tablaCortes.Rows)
                {
                    granTotal += Convert.ToDecimal(fila["Total_Pagado"]);
                }

                // Llenamos el DataGridView
                dgvCortes.DataSource = tablaCortes;

                // Formato visual para que se vea más profesional la tabla
                if (dgvCortes.Columns.Contains("Total_Pagado"))
                {
                    dgvCortes.Columns["Total_Pagado"].HeaderText = "Monto Total";
                    dgvCortes.Columns["Total_Pagado"].DefaultCellStyle.Format = "C2"; // Formato de moneda ($)
                }

                // Actualizamos el Label
                lblGranTotal.Text = $"GRAN TOTAL: {granTotal:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el corte: " + ex.Message, "Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bd.CerrarConexion();
            }
        }

        private void CargarProximoFolio()
        {
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();
            if (conexion == null) return;

            try
            {
                string query = "SELECT MAX(id_inscripcion) FROM inscripciones";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                object resultado = cmd.ExecuteScalar();
                int maxId = (resultado == DBNull.Value || resultado == null) ? 0 : Convert.ToInt32(resultado);
                lblFolioSiguiente.Text = $"Próximo Folio: 1-{(maxId + 1):D5}";
            }
            catch { }
            finally { bd.CerrarConexion(); }
        }

        private void ExportarCortePDF()
        {
            if (dgvCortes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardarDialogo = new SaveFileDialog();
            guardarDialogo.Filter = "Archivo PDF|*.pdf";
            guardarDialogo.FileName = "Corte_Gimnasio_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            if (guardarDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document documento = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(documento, new FileStream(guardarDialogo.FileName, FileMode.Create));
                    documento.Open();

                    iTextFont fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    iTextFont fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    iTextFont fuenteFirma = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    Paragraph titulo = new Paragraph("GIMNASIO MUNICIPAL SAN PEDRO\nReporte Oficial de Ingresos\n\n", fuenteTitulo);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    documento.Add(titulo);

                    // Contamos columnas visibles (aunque ahora todas deberían serlo)
                    int columnasVisibles = 0;
                    foreach (DataGridViewColumn col in dgvCortes.Columns) if (col.Visible) columnasVisibles++;

                    PdfPTable tablaPdf = new PdfPTable(columnasVisibles);
                    tablaPdf.WidthPercentage = 100;

                    // Ajustar anchos relativos (ejemplo: hacer la columna de Conceptos más ancha)
                    float[] anchos = new float[] { 1.5f, 2f, 3f, 4f, 2f };
                    if (columnasVisibles == 5) tablaPdf.SetWidths(anchos);

                    foreach (DataGridViewColumn columna in dgvCortes.Columns)
                    {
                        if (columna.Visible)
                        {
                            PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.HeaderText, fuenteFirma));
                            celdaEncabezado.BackgroundColor = new BaseColor(220, 220, 220);
                            celdaEncabezado.HorizontalAlignment = Element.ALIGN_CENTER;
                            tablaPdf.AddCell(celdaEncabezado);
                        }
                    }

                    foreach (DataGridViewRow fila in dgvCortes.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                if (dgvCortes.Columns[celda.ColumnIndex].Visible)
                                {
                                    // Validamos si es la columna de Total_Pagado para darle formato en el PDF
                                    string valor = celda.Value?.ToString() ?? "";
                                    if (dgvCortes.Columns[celda.ColumnIndex].Name == "Total_Pagado" && decimal.TryParse(valor, out decimal monto))
                                    {
                                        valor = monto.ToString("C2");
                                    }

                                    PdfPCell celdaDato = new PdfPCell(new Phrase(valor, fuenteNormal));
                                    celdaDato.HorizontalAlignment = Element.ALIGN_CENTER;
                                    tablaPdf.AddCell(celdaDato);
                                }
                            }
                        }
                    }
                    documento.Add(tablaPdf);

                    Paragraph total = new Paragraph($"\n\n{lblGranTotal.Text}", fuenteTitulo);
                    total.Alignment = Element.ALIGN_RIGHT;
                    documento.Add(total);

                    Paragraph firmas = new Paragraph("\n\n\n\n__________________________          __________________________\n          Firma del Cajero                       Firma de Tesorería", fuenteFirma);
                    firmas.Alignment = Element.ALIGN_CENTER;
                    documento.Add(firmas);

                    documento.Close();
                    MessageBox.Show("¡Corte exportado a PDF exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Error al exportar PDF: " + ex.Message); }
            }
        }

        private void btnGenerarCorte_Click(object sender, EventArgs e)
        {
            ExportarCortePDF();
        }
    }
}