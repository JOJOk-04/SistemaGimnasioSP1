using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SistemaGimnasioSP
{
    public partial class FrmAfluencia : Form
    {
        ConexionDB con = new ConexionDB();

        public FrmAfluencia()
        {
            InitializeComponent();
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_cliente, fecha_hora FROM accesos_diarios " +
                           "WHERE DATE(fecha_hora) BETWEEN @inicio AND @fin " +
                           "ORDER BY fecha_hora DESC";

            MySqlParameter[] parametros = {
                new MySqlParameter("@inicio", VntnFechaInicio.Value.ToString("yyyy-MM-dd")),
                new MySqlParameter("@fin", VntnFechaFinal.Value.ToString("yyyy-MM-dd"))
            };

            try
            {
                VntnDatosCorte.DataSource = con.Consultar(query, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void BtnGenPDF_Click(object sender, EventArgs e)
        {
            if (VntnDatosCorte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (*.pdf)|*.pdf";
            save.FileName = "Reporte_Afluencia_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        doc.Add(new Paragraph("REPORTE DE AFLUENCIA - SISTEMA GIMNASIO SP"));
                        doc.Add(new Paragraph($"Periodo: {VntnFechaInicio.Value.ToShortDateString()} al {VntnFechaFinal.Value.ToShortDateString()}"));
                        doc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(VntnDatosCorte.Columns.Count);
                        foreach (DataGridViewColumn col in VntnDatosCorte.Columns)
                            table.AddCell(new Phrase(col.HeaderText));

                        foreach (DataGridViewRow row in VntnDatosCorte.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                                table.AddCell(cell.Value?.ToString() ?? "");
                        }

                        doc.Add(table);
                        doc.Close();
                    }
                    MessageBox.Show("PDF generado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message);
                }
            }
        }
    }
}