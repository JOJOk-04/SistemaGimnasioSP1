using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace SistemaGimnasioSP
{
    public partial class FrmConsultas : Form
    {
        private bool busquedaRealizada = false;

        public FrmConsultas()
        {
            InitializeComponent();
            txtBuscar.TextChanged += (s, e) => busquedaRealizada = false;
        }

        private void LimpiarFicha()
        {
            lblNombreResultado.Text = "Nombre: ---";
            lblMunicipioResultado.Text = "Municipio: ---";
            lblEstatusResultado.Text = "Estatus: ---";
            lblEdadResultado.Text = "Edad: ---";
            lblEstatusResultado.ForeColor = System.Drawing.Color.Black;
            busquedaRealizada = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(texto)) return;

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();
            if (conexion == null) return;

            try
            {
                string query = "SELECT c.nombre, c.fecha_nacimiento, c.municipio, i.estatus FROM Clientes c " +
                               "LEFT JOIN Inscripciones i ON c.id_cliente = i.id_cliente " +
                               "WHERE c.id_cliente LIKE @b OR c.nombre LIKE @b LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@b", "%" + texto + "%");

                using (MySqlDataReader lector = cmd.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        lblNombreResultado.Text = $"Nombre: {lector["nombre"]}";
                        lblMunicipioResultado.Text = $"Municipio: {lector["municipio"]}";

                        // RESTAURADO: Verificación de registro
                        string estatusSocio = lector["estatus"] != DBNull.Value ? lector["estatus"].ToString() : "Sin registro";
                        lblEstatusResultado.Text = $"Estatus: {estatusSocio}";

                        DateTime fechaNac = Convert.ToDateTime(lector["fecha_nacimiento"]);
                        int edad = DateTime.Today.Year - fechaNac.Year;
                        if (fechaNac.Date > DateTime.Today.AddYears(-edad)) edad--;

                        lblEdadResultado.Text = $"Edad: {edad} años";
                        busquedaRealizada = true;
                    }
                    else
                    {
                        MessageBox.Show("Socio no encontrado.");
                        LimpiarFicha();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { baseDatos.CerrarConexion(); }
        }

        private void GenerarGafetePDF()
        {
            string id = txtBuscar.Text.Trim();
            string ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Gafete_{id}.pdf");

            try
            {
                using (PdfWriter writer = new PdfWriter(ruta))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf, new PageSize(241, 156));
                    doc.SetMargins(0, 0, 0, 0);

                    PdfFont fBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    // Header
                    doc.Add(new Table(1).SetWidth(UnitValue.CreatePercentValue(100))
                        .AddCell(new Cell().Add(new Paragraph("MEMBRESÍA GYM").SetFont(fBold).SetFontSize(14).SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE))
                        .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.DARK_GRAY).SetTextAlignment(TextAlignment.CENTER).SetPadding(8).SetBorder(iText.Layout.Borders.Border.NO_BORDER)));

                    doc.Add(new Paragraph("\n"));

                    // Nombre y Datos
                    doc.Add(new Paragraph(lblNombreResultado.Text.Replace("Nombre: ", "")).SetFont(fBold).SetFontSize(15).SetTextAlignment(TextAlignment.CENTER).SetFontColor(iText.Kernel.Colors.ColorConstants.BLUE));

                    Table info = new Table(1).SetWidth(UnitValue.CreatePercentValue(85)).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    info.AddCell(new Cell().Add(new Paragraph(lblMunicipioResultado.Text).SetFont(fNormal).SetFontSize(9)).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    info.AddCell(new Cell().Add(new Paragraph(lblEdadResultado.Text).SetFont(fNormal).SetFontSize(9)).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    // Estado con color dinámico
                    string textoEstatus = lblEstatusResultado.Text.Replace("Estatus: ", "");
                    iText.Kernel.Colors.Color colorPdf = textoEstatus.ToLower().Contains("activo") ? iText.Kernel.Colors.ColorConstants.GREEN : iText.Kernel.Colors.ColorConstants.RED;

                    info.AddCell(new Cell().Add(new Paragraph("ESTADO: " + textoEstatus.ToUpper()).SetFont(fBold).SetFontSize(10).SetFontColor(colorPdf)).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    doc.Add(info);
                    doc.Add(new Paragraph($"ID: {id}").SetFont(fNormal).SetFontSize(7).SetFontColor(iText.Kernel.Colors.ColorConstants.GRAY).SetFixedPosition(10, 10, 221).SetTextAlignment(TextAlignment.RIGHT));
                    doc.Close();
                }

                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
                Thread.Sleep(2000);

                if (System.IO.File.Exists(ruta))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(ruta, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error PDF: " + ex.Message); }
        }

        private void btnGenerarGafete_Click(object sender, EventArgs e)
        {
            if (!busquedaRealizada || string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Busque un socio válido primero.");
                return;
            }
            GenerarGafetePDF();
        }
    }
}