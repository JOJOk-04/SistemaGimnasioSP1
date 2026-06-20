using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using QRCoder;

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
            // Datos originales
            lblNombreResultado.Text = "Nombre: ---";
            lblMunicipioResultado.Text = "Municipio: ---";
            lblEstatusResultado.Text = "Estatus: ---";
            lblEdadResultado.Text = "Edad: ---";
            lblEstatusResultado.ForeColor = System.Drawing.Color.Black;

            // Datos nuevos agregados
            label10.Text = "Dirección: ---";
            label9.Text = "Colonia: ---";
            lblTelefonoResultado.Text = "Teléfono: ---";
            label7.Text = "Emergencia: ---";
            label6.Text = "CURP: ---";
            label5.Text = "RFC: ---";
            label4.Text = "Género: ---";
            label8.Text = "Correo: ---";
            lblSangreResultado.Text = "Sangre: ---";
            lblAlergiasResultado.Text = "Alergias: ---";

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
                string query = @"SELECT c.nombre, c.fecha_nacimiento, c.municipio, 
                                        c.direccion, c.colonia, c.telefono, c.contacto_emergencia,
                                        c.curp, c.rfc, c.genero, c.email, c.peso, 
                                        c.tipo_sangre, c.alergias, c.padecimiento,
                                        IF(i.fecha_vencimiento IS NULL, 'Sin registro', 
                                           IF(i.fecha_vencimiento >= CURDATE(), 'Activo', 'Inactivo')) AS estatus_calculado 
                                 FROM clientes c 
                                 LEFT JOIN inscripciones i ON c.id_cliente = i.id_cliente 
                                 WHERE c.id_cliente LIKE @b OR c.nombre LIKE @b 
                                 ORDER BY i.fecha_vencimiento DESC 
                                 LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@b", "%" + texto + "%");

                using (MySqlDataReader lector = cmd.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        // Llenado de datos
                        lblNombreResultado.Text = $"Nombre: {lector["nombre"]}";
                        lblMunicipioResultado.Text = $"Municipio: {lector["municipio"]}";
                        label10.Text = $"Dirección: {lector["direccion"]}";
                        label9.Text = $"Colonia: {lector["colonia"]}";
                        lblTelefonoResultado.Text = $"Teléfono: {lector["telefono"]}";
                        label7.Text = $"Emergencia: {lector["contacto_emergencia"]}";
                        label6.Text = $"CURP: {lector["curp"]}";
                        label5.Text = $"RFC: {lector["rfc"]}";
                        label4.Text = $"Género: {lector["genero"]}";
                        label8.Text = $"Correo: {lector["email"]}";
                        lblSangreResultado.Text = $"Sangre: {lector["tipo_sangre"]}";
                        lblAlergiasResultado.Text = $"Alergias: {lector["alergias"]}";

                        // Lógica de Estatus
                        string estatusSocio = lector["estatus_calculado"].ToString();
                        lblEstatusResultado.Text = $"Estatus: {estatusSocio}";

                        if (estatusSocio == "Activo")
                            lblEstatusResultado.ForeColor = System.Drawing.Color.Green;
                        else if (estatusSocio == "Inactivo")
                            lblEstatusResultado.ForeColor = System.Drawing.Color.Red;
                        else
                            lblEstatusResultado.ForeColor = System.Drawing.Color.DarkOrange;

                        // Lógica de Edad
                        DateTime fechaNac = Convert.ToDateTime(lector["fecha_nacimiento"]);
                        int edad = DateTime.Today.Year - fechaNac.Year;
                        if (fechaNac.Date > DateTime.Today.AddYears(-edad)) edad--;

                        lblEdadResultado.Text = $"Edad: {edad} años";
                        busquedaRealizada = true;
                    }
                    else
                    {
                        MessageBox.Show("Socio no encontrado.", "Búsqueda de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFicha();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { baseDatos.CerrarConexion(); }
        }

        private void GenerarGafetePDF()
        {
            string id = txtBuscar.Text.Trim();
            string ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Gafete_{id}.pdf");

            string nombreImagen = "OsosSanPedro.png";
            string rutaImagen = System.IO.Path.Combine(Application.StartupPath, nombreImagen);

            try
            {
                PageSize tamanoGafete = new PageSize(260, 380);

                using (PdfWriter writer = new PdfWriter(ruta))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf, tamanoGafete);
                    doc.SetMargins(20, 20, 20, 20);

                    PdfFont fBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    iText.Kernel.Colors.Color grisOscuro = new iText.Kernel.Colors.DeviceRgb(45, 52, 54);
                    iText.Kernel.Colors.Color grisClaro = new iText.Kernel.Colors.DeviceRgb(236, 240, 241);
                    iText.Kernel.Colors.Color grisTexto = new iText.Kernel.Colors.DeviceRgb(127, 140, 141);
                    iText.Kernel.Colors.Color azulOscuro = new iText.Kernel.Colors.DeviceRgb(39, 60, 117);

                    // ==========================================
                    // --- PÁGINA 1: GAFETE FRONTAL ---
                    // ==========================================

                    if (File.Exists(rutaImagen))
                    {
                        ImageData data = ImageDataFactory.Create(rutaImagen);
                        iText.Layout.Element.Image imgFondo = new iText.Layout.Element.Image(data);
                        imgFondo.SetOpacity(0.30f).SetWidth(420).SetFixedPosition(1, -80, -105);
                        doc.Add(imgFondo);
                    }

                    Table header = new Table(1).UseAllAvailableWidth();
                    header.AddCell(new Cell().Add(new Paragraph("GAFETE DE ACCESO")
                        .SetFont(fBold).SetFontSize(14).SetFontColor(iText.Kernel.Colors.ColorConstants.WHITE))
                        .SetBackgroundColor(azulOscuro).SetTextAlignment(TextAlignment.CENTER).SetPadding(8).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    doc.Add(header);

                    // --- CORRECCIÓN 1 AQUÍ ---
                    Table photoFrame = new Table(1).SetWidth(90).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    photoFrame.SetMarginTop(15);
                    photoFrame.AddCell(new Cell().Add(new Paragraph("FOTO\nPERFIL").SetFont(fNormal).SetFontColor(grisTexto).SetFontSize(10))
                        .SetHeight(100).SetBackgroundColor(grisClaro).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetBorder(new iText.Layout.Borders.SolidBorder(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY, 1)));
                    doc.Add(photoFrame);

                    string nombreLimpio = lblNombreResultado.Text.Replace("Nombre: ", "");
                    doc.Add(new Paragraph(nombreLimpio)
                        .SetFont(fBold).SetFontSize(16).SetFontColor(grisOscuro)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginTop(10).SetMarginBottom(0));

                    string municipio = lblMunicipioResultado.Text;
                    string edad = lblEdadResultado.Text;
                    doc.Add(new Paragraph($"{municipio} | {edad}")
                        .SetFont(fNormal).SetFontSize(10).SetFontColor(grisTexto)
                        .SetTextAlignment(TextAlignment.CENTER).SetMarginTop(2));

                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    {
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
                        using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                        {
                            byte[] qrBytes = qrCode.GetGraphic(20);
                            ImageData qrImageData = ImageDataFactory.Create(qrBytes);
                            iText.Layout.Element.Image imgQR = new iText.Layout.Element.Image(qrImageData);

                            imgQR.SetWidth(75);
                            // --- CORRECCIÓN 2 AQUÍ ---
                            imgQR.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            imgQR.SetMarginTop(10);
                            doc.Add(imgQR);
                        }
                    }

                    Paragraph pId = new Paragraph($"ID: {id}")
                        .SetFont(fBold).SetFontSize(11).SetFontColor(grisTexto)
                        .SetFixedPosition(1, 0, 15, 260)
                        .SetTextAlignment(TextAlignment.CENTER);
                    doc.Add(pId);

                    // ==========================================
                    // --- PÁGINA 2: FICHA TRASERA SIMPLIFICADA ---
                    // ==========================================

                    doc.Add(new AreaBreak()); // Mantiene el tamaño exacto del gafete

                    doc.Add(new Paragraph("FICHA DE EMERGENCIAS")
                        .SetFont(fBold).SetFontSize(14).SetFontColor(azulOscuro)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginBottom(10)
                        .SetMarginTop(10));

                    // Datos seleccionados para mostrar en la parte trasera
                    string[] info = {
                        lblNombreResultado.Text,
                        lblEdadResultado.Text,
                        label4.Text,  // Género
                        lblSangreResultado.Text,
                        label10.Text, // Dirección
                        label9.Text,  // Colonia
                        lblTelefonoResultado.Text,
                        label7.Text,  // Emergencia
                        
                    };

                    foreach (string item in info)
                    {
                        int separador = item.IndexOf(':');
                        if (separador > 0)
                        {
                            // Separa la palabra clave del valor para poner la clave en negritas
                            string clave = item.Substring(0, separador + 1);
                            string valor = item.Substring(separador + 1);

                            Paragraph p = new Paragraph()
                                .Add(new Text(clave).SetFont(fBold).SetFontSize(9).SetFontColor(grisOscuro))
                                .Add(new Text(valor).SetFont(fNormal).SetFontSize(9).SetFontColor(grisOscuro))
                                .SetMarginBottom(3); // Espacio pequeño entre lineas
                            doc.Add(p);
                        }
                        else
                        {
                            doc.Add(new Paragraph(item).SetFont(fNormal).SetFontSize(9).SetFontColor(grisOscuro).SetMarginBottom(3));
                        }
                    }

                    doc.Close();
                }

                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
                Thread.Sleep(2000);

                if (System.IO.File.Exists(ruta))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(ruta, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}