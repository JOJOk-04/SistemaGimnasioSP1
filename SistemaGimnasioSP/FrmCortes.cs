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
                // 🚀 SQL SIMPLIFICADO: Solo dinero, clientes y cajeros.
                string query = @"
            SELECT 
                CONCAT('1-', LPAD(p.id_pago, 5, '0')) AS Folio,
                p.fecha_pago AS Fecha,
                c.nombre AS Cliente,
                
                -- ✨ Lógica directa: Si no hay dinero, es beca. Si hay, es normal.
                CASE 
                    WHEN p.monto_cobrado = 0 THEN 'CORTESÍA / BECA'
                    ELSE 'PAGO NORMAL' 
                END AS Concepto_Pagado,
                
                COALESCE(u.nombre_completo, 'Usuario Desconocido') AS Cobrado_Por,
                p.monto_cobrado AS Monto_Total
                
            FROM pagos p
            LEFT JOIN clientes c ON p.id_cliente = c.id_cliente
            LEFT JOIN usuarios u ON p.id_usuario = u.id_usuario
            
            WHERE DATE(p.fecha_pago) >= @inicio AND DATE(p.fecha_pago) <= @fin
            ORDER BY p.fecha_pago DESC";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@inicio", dtpDesde.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fin", dtpHasta.Value.ToString("yyyy-MM-dd"));

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                DataTable tablaCortes = new DataTable();
                adaptador.Fill(tablaCortes);

                // Sumamos la lana
                decimal granTotal = 0;
                foreach (DataRow fila in tablaCortes.Rows)
                {
                    if (fila["Monto_Total"] != DBNull.Value)
                    {
                        granTotal += Convert.ToDecimal(fila["Monto_Total"]);
                    }
                }

                // Llenamos tu tabla visual
                dgvCortes.DataSource = tablaCortes;

                // Le damos formato de billetes ($)
                if (dgvCortes.Columns.Contains("Monto_Total"))
                {
                    dgvCortes.Columns["Monto_Total"].HeaderText = "Monto Total";
                    dgvCortes.Columns["Monto_Total"].DefaultCellStyle.Format = "C2";
                }

                // Ajustamos los anchos
                if (dgvCortes.Columns.Contains("Concepto_Pagado")) dgvCortes.Columns["Concepto_Pagado"].Width = 180;
                if (dgvCortes.Columns.Contains("Cobrado_Por")) dgvCortes.Columns["Cobrado_Por"].Width = 180;

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
                // Ahora busca el máximo en la tabla de pagos reales
                string query = "SELECT MAX(id_pago) FROM pagos";
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

                    int columnasVisibles = 0;
                    foreach (DataGridViewColumn col in dgvCortes.Columns) if (col.Visible) columnasVisibles++;

                    PdfPTable tablaPdf = new PdfPTable(columnasVisibles);
                    tablaPdf.WidthPercentage = 100;

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
                                    string valor = celda.Value?.ToString() ?? "";
                                    // 🌟 Ajuste aquí: Ahora se llama Monto_Cobrado
                                    if (dgvCortes.Columns[celda.ColumnIndex].Name == "Monto_Cobrado" && decimal.TryParse(valor, out decimal monto))
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
        private void btnRespaldo_Click(object sender, EventArgs e)
        {
            // 1. Preparamos la ruta y el nombre del archivo (Ej. Respaldo_2026-06-19_15-30-00.sql)
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string rutaCarpeta = @"C:\Respaldos_Gimnasio";
            string rutaArchivo = $@"{rutaCarpeta}\Respaldo_{fechaHora}.sql";

            // 2. Si la carpeta "Respaldos_Gimnasio" no existe en el Disco C, la creamos
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            // 3. Traemos tu cadena de conexión (Asegúrate de que aquí vaya la de tu clase ConexionDB que apunta a Aiven)
            // Ejemplo: string cadena = "Server=mysql-blabla.aivencloud.com;Port=11306;Database=GimnasioSP1;Uid=avnadmin;Pwd=tu_pass;";
            string cadenaConexion = "AQUI_PON_TU_CADENA_DE_CONEXION_DE_AIVEN";

            try
            {
                // 4. Hacemos la magia de descargar la base de datos
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(rutaArchivo); // ¡Esta línea descarga y crea el archivo físico!
                            conn.Close();
                        }
                    }
                }

                // 5. Le avisamos al gerente que todo salió perfecto
                MessageBox.Show($"¡Respaldo generado con éxito!\n\nSe guardó una copia de la nube en la computadora local:\n{rutaArchivo}",
                                "Copia de Seguridad Exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al intentar hacer el respaldo: " + ex.Message,
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void btnGenerarCorte_Click(object sender, EventArgs e)
        {
            ExportarCortePDF();
        }
    }
}