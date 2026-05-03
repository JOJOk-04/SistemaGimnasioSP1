using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using iTextFont = iTextSharp.text.Font;

namespace SistemaGimnasioSP
{
    public partial class FrmCortes : Form
    {
        public FrmCortes()
        {
            InitializeComponent();
        }


            // 1. EVENTO LOAD: Se ejecuta al abrir la pantalla
            private void FrmCortes_Load(object sender, EventArgs e)
            {
                // 🌟 TRUCO PRO: Calcular automáticamente el "Jueves Pasado"
                DateTime hoy = DateTime.Today;
                int diasRestar = (int)hoy.DayOfWeek - (int)DayOfWeek.Thursday;
                if (diasRestar < 0) diasRestar += 7; // Si hoy es mar/mie, regresamos a la semana pasada

                dtpDesde.Value = hoy.AddDays(-diasRestar);
                dtpHasta.Value = hoy; // Hasta hoy

                // Mostramos el número de folio actual
                CargarProximoFolio();
            }

            // 2. BOTÓN CONSULTAR: El que hace la magia
            private void btnConsultar_Click(object sender, EventArgs e)
            {
                GenerarCorte();
            }

            // 3. EL CEREBRO: La consulta SQL con INNER JOIN
            private void GenerarCorte()
            {
                ConexionDB bd = new ConexionDB();
                MySqlConnection conexion = bd.AbrirConexion();

                if (conexion == null) return;

                try
                {
                    // ✨ LA MAGIA DEL SQL: 
                    // Viajamos de la tabla Inscripciones -> Clientes -> Deportes para armar el ticket.
                    // El IF() de MySQL decide el precio automáticamente leyendo el municipio.
                    string query = @"
                    SELECT 
                        CONCAT('1-', LPAD(i.id_inscripcion, 5, '0')) AS Folio,
                        i.fecha_pago AS Fecha,
                        c.nombre AS Cliente,
                        d.nombre_deporte AS Concepto,
                        IF(c.municipio = 'San Pedro Garza García', 'Local', 'Foráneo') AS Tipo,
                        IF(c.municipio = 'San Pedro Garza García', d.precio_local, d.precio_foraneo) AS Monto_Cobrado
                    FROM inscripciones i
                    INNER JOIN clientes c ON i.id_cliente = c.id_cliente
                    INNER JOIN deportes d ON i.id_deporte = d.id_deporte
                    WHERE i.fecha_pago >= @inicio AND i.fecha_pago <= @fin
                    ORDER BY i.fecha_pago DESC, i.id_inscripcion DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    // Le pasamos las fechas de los calendarios a MySQL
                    cmd.Parameters.AddWithValue("@inicio", dtpDesde.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@fin", dtpHasta.Value.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tablaCortes = new DataTable();
                    adaptador.Fill(tablaCortes);

                    // 1. Llenamos la tabla visual (DataGridView)
                    dgvCortes.DataSource = tablaCortes;

                    // 2. Calculamos el dinero contándolo directo de la tabla resultante
                    decimal granTotal = 0;
                    foreach (DataRow fila in tablaCortes.Rows)
                    {
                        granTotal += Convert.ToDecimal(fila["Monto_Cobrado"]);
                    }

                    // 3. Actualizamos la tarjeta verde gigante
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

            // 4. EL FOLIO: Para saber en qué recibo vamos (Arquitectura Multi-Sucursal)
            private void CargarProximoFolio()
            {
                ConexionDB bd = new ConexionDB();
                MySqlConnection conexion = bd.AbrirConexion();

                if (conexion != null)
                {
                    try
                    {
                        // Buscamos el ID más grande que exista y le sumamos 1
                        string query = "SELECT MAX(id_inscripcion) FROM inscripciones";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);

                        object resultado = cmd.ExecuteScalar();
                        int maxId = (resultado == DBNull.Value || resultado.ToString() == "") ? 0 : Convert.ToInt32(resultado);
                        int proximoId = maxId + 1;

                        // Formateamos para que se vea estilo ticket: 1-00025
                        lblFolioSiguiente.Text = $"Próximo Folio: 1-{proximoId:D5}";
                    }
                    catch { } // Ignoramos errores menores aquí
                    finally { bd.CerrarConexion(); }
                }
            }
        // =====================================================================
        // MÓDULO DE EXPORTACIÓN A PDF (Para Auditoría)
        // =====================================================================
        private void ExportarCortePDF()
        {
            if (dgvCortes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Haz una consulta primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardarDialogo = new SaveFileDialog();
            guardarDialogo.Filter = "Archivo PDF|*.pdf";
            guardarDialogo.FileName = "Corte_Gimnasio_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            if (guardarDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Usamos iTextSharp.text.Document explícitamente para evitar choques
                    iTextSharp.text.Document documento = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(documento, new FileStream(guardarDialogo.FileName, FileMode.Create));

                    documento.Open();

                    // 2. Definimos fuentes usando nuestro alias 'iTextFont'
                    iTextFont fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    iTextFont fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    iTextFont fuenteFirma = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    // 3. Títulos
                    Paragraph titulo = new Paragraph("GIMNASIO MUNICIPAL SAN PEDRO\nReporte Oficial de Ingresos\n\n", fuenteTitulo);
                    titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    documento.Add(titulo);

                    Paragraph info = new Paragraph($"Rango: {dtpDesde.Value.ToShortDateString()} al {dtpHasta.Value.ToShortDateString()}\nGenerado: {DateTime.Now.ToString()}\n\n", fuenteNormal);
                    documento.Add(info);

                    // 4. Tabla de Datos
                    PdfPTable tablaPdf = new PdfPTable(dgvCortes.Columns.Count);
                    tablaPdf.WidthPercentage = 100;

                    // Encabezados
                    foreach (DataGridViewColumn columna in dgvCortes.Columns)
                    {
                        PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.HeaderText, fuenteFirma));
                        celdaEncabezado.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
                        celdaEncabezado.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        tablaPdf.AddCell(celdaEncabezado);
                    }

                    // Filas de la tabla
                    foreach (DataGridViewRow fila in dgvCortes.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                string valor = celda.Value?.ToString() ?? "";
                                PdfPCell celdaDato = new PdfPCell(new Phrase(valor, fuenteNormal));
                                celdaDato.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                                tablaPdf.AddCell(celdaDato);
                            }
                        }
                    }
                    documento.Add(tablaPdf);

                    // 5. Gran Total
                    Paragraph total = new Paragraph($"\n\n{lblGranTotal.Text}", fuenteTitulo);
                    total.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    documento.Add(total);

                    // 6. Espacio para firmas
                    Paragraph firmas = new Paragraph("\n\n\n\n__________________________          __________________________\n          Firma del Cajero                     Firma de Tesorería", fuenteFirma);
                    firmas.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    documento.Add(firmas);

                    documento.Close();
                    MessageBox.Show("¡Corte exportado a PDF!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error de PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblFolioSiguiente_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalServicios_Click(object sender, EventArgs e)
        {

        }

        private void lblGranTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarCorte_Click(object sender, EventArgs e)
        {
            ExportarCortePDF();
        }
    }
}
