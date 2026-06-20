using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using static SistemaGimnasioSP.FrmPaquetes;

namespace SistemaGimnasioSP
{
    public partial class FrmPruebaCobros : Form
    {
        // === BOLSAS DE MEMORIA ===
        string idClientePrincipal = "";
        string usuarioAutorizoTicket = ""; // ✨ Memoria para el nombre de quien dio la beca/colaborador

        // Bolsa 1: Para los deportes individuales (Acondicionamiento, Box, etc)
        List<int> deportesSeleccionados = new List<int>();
        decimal subtotalDeportes = 0;

        // Bolsa 2: Para los servicios y equipos (Ligas, Alberca, Campamentos)
        List<int> serviciosSeleccionados = new List<int>();
        decimal subtotalServicios = 0;

        List<InscripcionTemporal> carritoFamiliarPendiente = new List<InscripcionTemporal>();


        public FrmPruebaCobros()
        {
            InitializeComponent();
        }

        private void FrmPruebaCobros_Load(object sender, EventArgs e)
        {
            if (tabMenuTesoreria != null)
            {
                tabMenuTesoreria.Alignment = TabAlignment.Top;

                this.ResumeLayout(true);
                int numeroDePestañas = 5;
                if (tabMenuTesoreria.TabPages.Count > 0)
                {
                    numeroDePestañas = tabMenuTesoreria.TabPages.Count;
                }

                int anchoPorPestaña = (tabMenuTesoreria.Width / numeroDePestañas) - 2;

                tabMenuTesoreria.ItemSize = new Size(anchoPorPestaña, 60);
            }
        }

        private void CalcularSubtotalDeportes()
        {
            subtotalDeportes = 0;

            if (deportesSeleccionados.Count == 0)
            {
                ActualizarGranTotal();
                return;
            }

            string municipioPuro = lblMunicipio.Text.Replace("Municipio:", "").Trim();
            bool esLocal = (municipioPuro == "San Pedro Garza García");
            string columnaPrecio = esLocal ? "precio_local" : "precio_foraneo";

            decimal costoExtra = esLocal ? 100 : 200;

            int edad = 0;
            string edadTexto = lblEdad.Text.Replace("Edad:", "").Replace("años", "").Trim();
            int.TryParse(edadTexto, out edad);
            bool esSenior = (edad >= 60);

            // ✨ LE PREGUNTAMOS A MYSQL SI YA TIENE BENEFICIOS
            bool yaTieneBeneficio = TieneBeneficioActivo(txtBusquedaId.Text.Trim());

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    for (int i = 0; i < deportesSeleccionados.Count; i++)
                    {
                        // Si es el primero de la lista y NO tiene beneficios, paga completo
                        if (i == 0 && !yaTieneBeneficio)
                        {
                            int idDeportePrincipal = deportesSeleccionados[i];
                            string query = $"SELECT {columnaPrecio} FROM deportes WHERE id_deporte = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conexion);
                            cmd.Parameters.AddWithValue("@id", idDeportePrincipal);

                            decimal precioBase = Convert.ToDecimal(cmd.ExecuteScalar());

                            if (esSenior) { precioBase = 0; }

                            subtotalDeportes += precioBase;
                        }
                        else
                        {
                            // A partir del segundo, o si ya tenía paquete, paga 100 o 200
                            if (!esSenior)
                            {
                                subtotalDeportes += costoExtra;
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error en cálculo de deportes: " + ex.Message); }
                finally { baseDatos.CerrarConexion(); }
            }

            ActualizarGranTotal();
        }

        private void CalcularSubtotalServicios()
        {
            subtotalServicios = 0;

            if (serviciosSeleccionados.Count == 0)
            {
                ActualizarGranTotal();
                return;
            }

            string municipioPuro = lblMunicipio.Text.Replace("Municipio:", "").Trim();
            bool esLocal = (municipioPuro == "San Pedro Garza García");
            string columnaPrecio = esLocal ? "precio_local" : "precio_foraneo";

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    foreach (int idServicio in serviciosSeleccionados)
                    {
                        string query = $"SELECT {columnaPrecio} FROM servicios WHERE id_servicio = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idServicio);

                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null)
                        {
                            subtotalServicios += Convert.ToDecimal(resultado);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error calculando servicios: " + ex.Message); }
                finally { bd.CerrarConexion(); }
            }

            ActualizarGranTotal();
        }

        private void ActualizarGranTotal()
        {
            decimal granTotal = subtotalDeportes + subtotalServicios;
            lblTotalPagar.Text = $"Total a Pagar: {granTotal:C}";
        }

        // =====================================================================
        // MÉTODO DE VALIDACIÓN (NUEVO)
        // =====================================================================
        private bool TieneMembresiaActiva(string idCliente, int idDeporte)
        {
            bool activa = false;
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    string query = "SELECT fecha_vencimiento FROM inscripciones WHERE id_cliente = @idC AND id_deporte = @idD AND fecha_vencimiento > CURDATE() LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idC", idCliente);
                    cmd.Parameters.AddWithValue("@idD", idDeporte);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        DateTime fechaVencimiento = Convert.ToDateTime(resultado);
                        MessageBox.Show($"¡Atención!\n\nEste cliente ya tiene este deporte activo.\nLa membresía actual vence el: {fechaVencimiento.ToString("dd/MM/yyyy")}.\n\nNo es necesario cobrar hasta después de esa fecha.",
                                        "Suscripción Activa Detectada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        activa = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar estatus: " + ex.Message);
                    activa = true;
                }
                finally
                {
                    bd.CerrarConexion();
                }
            }
            return activa;
        }

        private void ToggleDeporte(Control btn, int idDeporte)
        {
            Guna.UI2.WinForms.Guna2Button botonGuna = btn as Guna.UI2.WinForms.Guna2Button;
            if (botonGuna == null) return;

            if (deportesSeleccionados.Contains(idDeporte))
            {
                deportesSeleccionados.Remove(idDeporte);
                botonGuna.FillColor = Color.White;
            }
            else
            {
                string idBuscado = txtBusquedaId.Text.Trim();
                if (string.IsNullOrWhiteSpace(idBuscado))
                {
                    MessageBox.Show("Busca primero al cliente para verificar su estatus.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TieneMembresiaActiva(idBuscado, idDeporte))
                {
                    return;
                }

                deportesSeleccionados.Add(idDeporte);
                botonGuna.FillColor = Color.LightGreen;
            }

            CalcularSubtotalDeportes();
        }

        private void ToggleServicioExtra(Control btn, int idServicio)
        {
            Guna.UI2.WinForms.Guna2Button botonGuna = btn as Guna.UI2.WinForms.Guna2Button;
            if (botonGuna == null) return;

            if (serviciosSeleccionados.Contains(idServicio))
            {
                serviciosSeleccionados.Remove(idServicio);
                botonGuna.FillColor = Color.White;
            }
            else
            {
                serviciosSeleccionados.Add(idServicio);
                botonGuna.FillColor = Color.LightSkyBlue;
            }

            CalcularSubtotalServicios();
        }

        private void ProcesarPaqueteFamiliar(int idPaquete)
        {
            string idDelTitular = txtBusquedaId.Text.Trim();
            if (string.IsNullOrWhiteSpace(idDelTitular) || lblMunicipio.Text == "Municipio: ---")
            {
                MessageBox.Show("Primero busca a un cliente válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string municipioPuro = lblMunicipio.Text.Replace("Municipio:", "").Trim();
            bool esLocal = (municipioPuro == "San Pedro Garza García");

            string columnaPrecio = esLocal ? "precio_local" : "precio_foraneo";
            decimal costoExtraPorDeporte = esLocal ? 100 : 200;

            decimal precioBasePaquete = 0;
            string nombrePaqueteReal = "";
            int limitePersonasDB = 0;

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    string query = $"SELECT {columnaPrecio}, nombre_paquete, limite_personas FROM paquetes WHERE id_paquete = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idPaquete);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            precioBasePaquete = Convert.ToDecimal(lector[columnaPrecio]);
                            nombrePaqueteReal = lector["nombre_paquete"].ToString();
                            limitePersonasDB = Convert.ToInt32(lector["limite_personas"]);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el paquete en la base de datos.", "Error");
                            return;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error consultando paquete: " + ex.Message); return; }
                finally { baseDatos.CerrarConexion(); }
            }

            FrmPaquetes ventanaPaquetes = new FrmPaquetes(idDelTitular, limitePersonasDB, municipioPuro);

            if (ventanaPaquetes.ShowDialog() == DialogResult.OK)
            {
                carritoFamiliarPendiente = ventanaPaquetes.ResultadoFinal;

                decimal totalExtras = 0;
                foreach (var item in carritoFamiliarPendiente)
                {
                    if (item.Monto > 0)
                    {
                        item.Monto = costoExtraPorDeporte;
                        totalExtras += costoExtraPorDeporte;
                    }
                }

                subtotalDeportes = precioBasePaquete + totalExtras;
                ActualizarGranTotal();

                MessageBox.Show($"{nombrePaqueteReal} configurado.\nLímite oficial: {limitePersonasDB} personas.\n- Paquete Base: {precioBasePaquete:C}\n- Costo Extras: {totalExtras:C}\n\nTotal del Paquete: {subtotalDeportes:C}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBusquedaId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarCliente();
            }
        }

        private void BuscarCliente()
        {
            string idBuscado = txtBusquedaId.Text.Trim();

            if (string.IsNullOrWhiteSpace(idBuscado))
            {
                MessageBox.Show("Por favor, ingresa un ID o escanea el gafete.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    string query = "SELECT nombre, fecha_nacimiento, municipio FROM clientes WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idBuscado);

                    using (MySqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            string nombre = lector["nombre"].ToString();
                            DateTime fechaNacimiento = Convert.ToDateTime(lector["fecha_nacimiento"]);
                            string municipio = lector["municipio"].ToString();

                            int edad = DateTime.Today.Year - fechaNacimiento.Year;
                            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;

                            lblNombre.Text = "Nombre: " + nombre;
                            lblEdad.Text = "Edad: " + edad.ToString();
                            lblMunicipio.Text = "Municipio: " + municipio;

                            if (edad >= 60)
                            {
                                lblEdad.ForeColor = Color.Green;
                            }
                            else
                            {
                                lblEdad.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cliente no encontrado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblNombre.Text = "Nombre: ---";
                            lblEdad.Text = "Edad: ---";
                            lblMunicipio.Text = "Municipio: ---";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message);
                }
                finally
                {
                    baseDatos.CerrarConexion();
                }
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void btnAcondicionamiento_Click(object sender, EventArgs e)
        {
            ToggleDeporte(sender as Control, 1);
        }

        private void btnFutbol_Click(object sender, EventArgs e)
        {
            ToggleDeporte(sender as Control, 2);
        }

        private void btnTaekwondo_Click(object sender, EventArgs e)
        {
            ToggleDeporte(sender as Control, 3);
        }

        private void Heterofilia_Click(object sender, EventArgs e)
        {
            ToggleDeporte(sender as Control, 4);
        }

        private void btnRitmos_Click(object sender, EventArgs e)
        {
            ToggleDeporte(sender as Control, 5);
        }

        private void btnPaquetef1_Click(object sender, EventArgs e)
        {
            ProcesarPaqueteFamiliar(1);
        }

        private void btnLigasdeFutbol_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 13);
        }

        private void btnEquipoSoftbol_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 14);
        }

        private void btnCampamento_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 16);
        }

        private void btnAgregarhno_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 17);
        }

        private void btnNiño_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 18);
        }

        private void btnAdulto_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra(sender as Control, 19);
        }

        private void btnPaquetef2_Click(object sender, EventArgs e)
        {
            ProcesarPaqueteFamiliar(2);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones iniciales de seguridad
            if (deportesSeleccionados.Count == 0 && carritoFamiliarPendiente.Count == 0 && serviciosSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay actividades ni servicios seleccionados para cobrar.", "Aviso de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            idClientePrincipal = txtBusquedaId.Text.Trim();
            if (string.IsNullOrWhiteSpace(idClientePrincipal))
            {
                MessageBox.Show("Falta seleccionar el ID del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Extraer el gran total
            decimal totalLimpioTransaccion = 0;
            string totalLimpio = lblTotalPagar.Text.Replace("Total a Pagar:", "").Replace("$", "").Trim();
            decimal.TryParse(totalLimpio, out totalLimpioTransaccion);

            // =================================================================
            // 💸 PASO NUEVO: ABRIR CAJA ANTES DE CONECTAR A MYSQL
            // =================================================================
            FrmCaja ventanaCaja = new FrmCaja(totalLimpioTransaccion);

            if (ventanaCaja.ShowDialog() != DialogResult.OK)
            {
                return; // Si cancela la ventana, abortamos la misión
            }

            // ✨ CORRECCIÓN AQUÍ: Evaluamos la nueva propiedad de texto de la caja
            bool esGratisAutorizado = (ventanaCaja.TipoAutorizacion == "Becado" || ventanaCaja.TipoAutorizacion == "Colaborador");

            if (esGratisAutorizado)
            {
                totalLimpioTransaccion = 0; // Si puso contraseña, el total será gratis
            }
            // =================================================================

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                MySqlTransaction transaccion = null;
                try
                {
                    transaccion = conexion.BeginTransaction();

                    // Calculamos las edades y aplicamos el truco de la beca
                    int edad = 0;
                    string edadTexto = lblEdad.Text.Replace("Edad:", "").Replace("años", "").Trim();
                    int.TryParse(edadTexto, out edad);
                    bool esSenior = (edad >= 60);

                    if (esGratisAutorizado)
                    {
                        totalLimpioTransaccion = 0; // El total será gratis
                        usuarioAutorizoTicket = ventanaCaja.UsuarioAutorizo; // ✨ CAPTURAMOS EL NOMBRE DE LA VENTANA CAJA
                    }
                    else
                    {
                        usuarioAutorizoTicket = ""; // Si fue pago normal, se queda vacío
                    }
                    // ✨ PREPARACIÓN PARA LOS CORTES: Si es gratis, guardamos el motivo exacto, si no, 'Efectivo'
                    string metodoPagoReal = esGratisAutorizado ? ventanaCaja.TipoAutorizacion : "Efectivo";

                    // ✨ REGISTRAR EL FOLIO MAESTRO (YA SIN EL '1' FIJO)
                    string queryPagoMaestro = @"INSERT INTO pagos (id_cliente, monto_cobrado, fecha_pago, metodo_pago, id_usuario) 
                            VALUES (@idC, @monto, NOW(), @metodo, @idUsuario);
                            SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdPago = new MySqlCommand(queryPagoMaestro, conexion, transaccion);
                    cmdPago.Parameters.AddWithValue("@idC", idClientePrincipal);
                    cmdPago.Parameters.AddWithValue("@monto", totalLimpioTransaccion);
                    cmdPago.Parameters.AddWithValue("@metodo", metodoPagoReal);

                    // 🚨 AQUÍ ESTÁ LA MAGIA: Le pasamos el ID real
                    // Reemplaza "VariableDeTuSesion" por la variable global donde guardas quién hizo login
                    cmdPago.Parameters.AddWithValue("@idUsuario", UsuarioSesion.IdUsuario);

                    int idPagoGenerado = Convert.ToInt32(cmdPago.ExecuteScalar());

                    // Variables de descuentos
                    string municipioPuro = lblMunicipio.Text.Replace("Municipio:", "").Trim();
                    bool esLocal = (municipioPuro == "San Pedro Garza García");
                    decimal costoExtra = esLocal ? 100 : 200;

                    // PREGUNTAMOS SI EL CLIENTE YA TIENE BENEFICIOS 
                    bool yaTieneBeneficio = TieneBeneficioActivo(idClientePrincipal);

                    // =================================================================
                    // PASO B: REGISTRAR DEPORTES
                    // =================================================================
                    if (carritoFamiliarPendiente.Count > 0)
                    {
                        foreach (var item in carritoFamiliarPendiente)
                        {
                            string queryInscripcion = @"INSERT INTO inscripciones (id_cliente, id_deporte, id_pago, monto_cobrado, fecha_pago, fecha_vencimiento) 
                                                        VALUES (@idC, @idD, @idPago, @montoCobrado, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 MONTH))";
                            MySqlCommand cmdInsc = new MySqlCommand(queryInscripcion, conexion, transaccion);
                            cmdInsc.Parameters.AddWithValue("@idC", item.IdCliente);
                            cmdInsc.Parameters.AddWithValue("@idD", item.IdDeporte);
                            cmdInsc.Parameters.AddWithValue("@idPago", idPagoGenerado);

                            // Si es gratis se fuerza a 0, si no, respeta el monto familiar
                            cmdInsc.Parameters.AddWithValue("@montoCobrado", esGratisAutorizado ? 0 : item.Monto);
                            cmdInsc.ExecuteNonQuery();

                            string queryFamilia = "UPDATE clientes SET id_titular_familia = @idTitular WHERE id_cliente = @idHijo AND id_cliente != @idTitular";
                            MySqlCommand cmdUpdate = new MySqlCommand(queryFamilia, conexion, transaccion);
                            cmdUpdate.Parameters.AddWithValue("@idTitular", idClientePrincipal);
                            cmdUpdate.Parameters.AddWithValue("@idHijo", item.IdCliente);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else if (deportesSeleccionados.Count > 0)
                    {
                        for (int i = 0; i < deportesSeleccionados.Count; i++)
                        {
                            int idDeporte = deportesSeleccionados[i];
                            decimal montoCobradoRenglon = 0;

                            if (!esSenior)
                            {
                                if (i == 0 && !yaTieneBeneficio)
                                {
                                    string queryPrecio = $"SELECT {(esLocal ? "precio_local" : "precio_foraneo")} FROM deportes WHERE id_deporte = @id";
                                    MySqlCommand cmdPrecio = new MySqlCommand(queryPrecio, conexion, transaccion);
                                    cmdPrecio.Parameters.AddWithValue("@id", idDeporte);
                                    montoCobradoRenglon = Convert.ToDecimal(cmdPrecio.ExecuteScalar());
                                }
                                else
                                {
                                    montoCobradoRenglon = costoExtra;
                                }
                            }

                            string queryInscripcion = @"INSERT INTO inscripciones (id_cliente, id_deporte, id_pago, monto_cobrado, fecha_pago, fecha_vencimiento) 
                                                        VALUES (@idC, @idD, @idPago, @montoCobrado, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 MONTH))";

                            MySqlCommand cmdInsc = new MySqlCommand(queryInscripcion, conexion, transaccion);
                            cmdInsc.Parameters.AddWithValue("@idC", idClientePrincipal);
                            cmdInsc.Parameters.AddWithValue("@idD", idDeporte);
                            cmdInsc.Parameters.AddWithValue("@idPago", idPagoGenerado);
                            cmdInsc.Parameters.AddWithValue("@montoCobrado", montoCobradoRenglon);
                            cmdInsc.ExecuteNonQuery();
                        }
                    }

                    // =================================================================
                    // PASO C: SERVICIOS EXTRAS (Ligas, Alberca, etc.)
                    // =================================================================
                    if (serviciosSeleccionados.Count > 0)
                    {
                        foreach (int idService in serviciosSeleccionados)
                        {
                            string queryPrecioS = $"SELECT {(esLocal ? "precio_local" : "precio_foraneo")} FROM servicios WHERE id_servicio = @id";
                            MySqlCommand cmdPrecioS = new MySqlCommand(queryPrecioS, conexion, transaccion);
                            cmdPrecioS.Parameters.AddWithValue("@id", idService);
                            decimal montoServicio = Convert.ToDecimal(cmdPrecioS.ExecuteScalar());

                            if (esGratisAutorizado) montoServicio = 0; // Si es descuento especial baja a 0

                            string queryInscServicio = @"INSERT INTO inscripciones_servicios 
                                                         (id_cliente, id_servicio, id_pago, monto_cobrado, fecha_pago) 
                                                         VALUES (@idC, @idS, @idPago, @montoCobrado, CURDATE())";

                            MySqlCommand cmdInscS = new MySqlCommand(queryInscServicio, conexion, transaccion);
                            cmdInscS.Parameters.AddWithValue("@idC", idClientePrincipal);
                            cmdInscS.Parameters.AddWithValue("@idS", idService);
                            cmdInscS.Parameters.AddWithValue("@idPago", idPagoGenerado);
                            cmdInscS.Parameters.AddWithValue("@montoCobrado", montoServicio);
                            cmdInscS.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();

                    MessageBox.Show("¡Cobro realizado con éxito! ", "Venta Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ImprimirTicket();
                    LimpiarPantallaCobros();
                }
                catch (Exception ex)
                {
                    if (transaccion != null && transaccion.Connection != null)
                    {
                        try { transaccion.Rollback(); } catch { }
                    }
                    MessageBox.Show("Error al procesar el cobro: " + ex.Message, "Error de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    bd.CerrarConexion();
                }
            }
        }
        private void ImprimirTicket()
        {
            PrintDocument ticket = new PrintDocument();
            ticket.PrintPage += new PrintPageEventHandler(DibujarTicket);

            try
            {
                ticket.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El cobro se guardó, pero hubo un error al imprimir el ticket: " + ex.Message, "Aviso de Impresora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DibujarTicket(object sender, PrintPageEventArgs e)
        {
            Graphics graficos = e.Graphics;
            Font fuenteTitulo = new Font("Courier New", 12, FontStyle.Bold);
            Font fuenteNormal = new Font("Courier New", 10, FontStyle.Regular);
            Font fuentePequeña = new Font("Courier New", 8, FontStyle.Regular);

            int y = 20;
            int margen = 10;

            graficos.DrawString("GIMNASIO MUNICIPAL SP", fuenteTitulo, Brushes.Black, margen, y);
            y += 20;
            graficos.DrawString("San Pedro Garza García", fuenteNormal, Brushes.Black, margen, y);
            y += 30;

            graficos.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            graficos.DrawString("ID Cliente: " + idClientePrincipal, fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            string nombreLimpio = lblNombre.Text.Replace("Nombre: ", "");
            graficos.DrawString("Cliente: " + nombreLimpio, fuenteNormal, Brushes.Black, margen, y);
            y += 20;
            graficos.DrawString("--------------------------------", fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            graficos.DrawString("CONCEPTOS PAGADOS:", fuenteTitulo, Brushes.Black, margen, y);
            y += 20;

            // ✨ VARIABLE PARA SABER SI HUBO DESCUENTO
            string etiquetaDescuento = "";

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // 1. Imprime los deportes
                    foreach (int idD in deportesSeleccionados)
                    {
                        MySqlCommand cmdD = new MySqlCommand("SELECT nombre_deporte FROM deportes WHERE id_deporte = @id", conexion);
                        cmdD.Parameters.AddWithValue("@id", idD);
                        string nombreDep = cmdD.ExecuteScalar()?.ToString();
                        graficos.DrawString("- " + nombreDep, fuenteNormal, Brushes.Black, margen, y);
                        y += 20;
                    }

                    // 2. Imprime los servicios extra
                    foreach (int idS in serviciosSeleccionados)
                    {
                        MySqlCommand cmdS = new MySqlCommand("SELECT nombre_servicio FROM servicios WHERE id_servicio = @id", conexion);
                        cmdS.Parameters.AddWithValue("@id", idS);
                        string nombreServ = cmdS.ExecuteScalar()?.ToString();
                        graficos.DrawString("- " + nombreServ, fuenteNormal, Brushes.Black, margen, y);
                        y += 20;
                    }

                    // 3. ✨ CEREBRO DEL TICKET: Revisamos en BD si el pago que acabamos de guardar fue gratis
                    MySqlCommand cmdMetodo = new MySqlCommand("SELECT metodo_pago FROM pagos WHERE id_cliente = @idC ORDER BY id_pago DESC LIMIT 1", conexion);
                    cmdMetodo.Parameters.AddWithValue("@idC", idClientePrincipal);
                    string metodoPago = cmdMetodo.ExecuteScalar()?.ToString() ?? "Efectivo";

                    if (metodoPago == "Becado") etiquetaDescuento = "BECA DEPORTIVA (100% DESC)";
                    else if (metodoPago == "Colaborador") etiquetaDescuento = "PRESTACIÓN EMPLEADO (100% DESC)";
                }
                finally { bd.CerrarConexion(); }
            }

            // 4. ✨ REVISIÓN DE ADULTO MAYOR
            int edad = 0;
            string edadTexto = lblEdad.Text.Replace("Edad:", "").Replace("años", "").Trim();
            int.TryParse(edadTexto, out edad);

            if (edad >= 60 && etiquetaDescuento == "")
            {
                etiquetaDescuento = "INAPAM / ADULTO MAYOR (100% DESC)";
            }

            graficos.DrawString("--------------------------------", fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            // 5. ✨ IMPRESIÓN DEL TOTAL Y DE QUIÉN AUTORIZÓ
            if (etiquetaDescuento != "")
            {
                // Pinta el motivo (Beca, Colaborador, o INAPAM)
                graficos.DrawString("Motivo: " + etiquetaDescuento, fuentePequeña, Brushes.Black, margen, y);
                y += 15;

                // Pinta el nombre del gerente que metió la contraseña (si está vacío, no pinta nada)
                if (!string.IsNullOrEmpty(usuarioAutorizoTicket))
                {
                    graficos.DrawString("Autorizó: " + usuarioAutorizoTicket, fuentePequeña, Brushes.Black, margen, y);
                    y += 15;
                }

                // Como es 100% de descuento, forzamos la vista del ticket a cero
                graficos.DrawString("TOTAL PAGADO: $0.00", fuenteTitulo, Brushes.Black, margen, y);
            }
            else
            {
                // Si no hubo descuento, se cobra normal en efectivo
                string textoTotal = lblTotalPagar.Text.ToUpper().Replace("TOTAL A PAGAR", "TOTAL PAGADO");
                graficos.DrawString(textoTotal, fuenteTitulo, Brushes.Black, margen, y);
            }

            y += 40;

            graficos.DrawString("¡Gracias por fomentar el deporte!", fuentePequeña, Brushes.Black, margen, y);
            y += 15;
            graficos.DrawString("Conserve este ticket.", fuentePequeña, Brushes.Black, margen, y);
        }

        // =====================================================================
        // MÉTODO DE INTELIGENCIA DE PRECIOS (NUEVO)
        // =====================================================================
        // =====================================================================
        // MÉTODO DE INTELIGENCIA DE PRECIOS (CORREGIDO Y BLINDADO)
        // =====================================================================
        private bool TieneBeneficioActivo(string idCliente)
        {
            bool tieneBeneficio = false;
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // ✨ MAGIA AQUÍ: Ya no leemos si tiene familia. 
                    // Solo nos importa si HOY tiene al menos 1 deporte pagado y activo (sin vencer).
                    string query = "SELECT COUNT(*) FROM inscripciones WHERE id_cliente = @id AND fecha_vencimiento > CURDATE()";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    int coincidencias = Convert.ToInt32(cmd.ExecuteScalar());

                    if (coincidencias > 0)
                    {
                        // Como ya tiene algo activo (ya sea individual o por el paquete de su papá), 
                        // se le hace válido el precio barato de "Segundo Deporte".
                        tieneBeneficio = true;
                    }
                }
                catch { }
                finally { bd.CerrarConexion(); }
            }
            return tieneBeneficio;
        }
        private void LimpiarPantallaCobros()
        {
            // 1. Limpiar campos de texto y labels de información
            txtBusquedaId.Clear();
            idClientePrincipal = "";
            lblNombre.Text = "Nombre: ---";
            lblEdad.Text = "Edad: ---";
            lblEdad.ForeColor = Color.Black; // Quitamos el verde de adulto mayor por si acaso
            lblMunicipio.Text = "Municipio: ---";
            lblTotalPagar.Text = "Total a Pagar: $0.00";

            // 2. Vaciar las "bolsas" de memoria RAM
            deportesSeleccionados.Clear();
            serviciosSeleccionados.Clear(); // Limpiamos también las ligas y extras
            carritoFamiliarPendiente.Clear();
            subtotalDeportes = 0;
            subtotalServicios = 0;
            // Al final de tu método LimpiarPantallaCobros agregas:
            usuarioAutorizoTicket = ""; // Limpieza total

            // 3. ✨ EL SECRETO DE GUNA: Apagar los botones usando FillColor ✨

            // Apagamos los botones de Deportes
            if (btnAcondicionamiento is Guna.UI2.WinForms.Guna2Button btn1) btn1.FillColor = Color.White;
            if (btnFutbol is Guna.UI2.WinForms.Guna2Button btn2) btn2.FillColor = Color.White;
            if (btnTaekwondo is Guna.UI2.WinForms.Guna2Button btn3) btn3.FillColor = Color.White;
            if (btnHeterofilia is Guna.UI2.WinForms.Guna2Button btn4) btn4.FillColor = Color.White;
            if (btnRitmos is Guna.UI2.WinForms.Guna2Button btn5) btn5.FillColor = Color.White;

            // Apagamos los botones de Servicios Extras
            if (btnLigasdeFutbol is Guna.UI2.WinForms.Guna2Button btn6) btn6.FillColor = Color.White;
            if (btnEquipoSoftbol is Guna.UI2.WinForms.Guna2Button btn7) btn7.FillColor = Color.White;
            if (btnCampamento is Guna.UI2.WinForms.Guna2Button btn8) btn8.FillColor = Color.White;
            if (btnAgregarHno is Guna.UI2.WinForms.Guna2Button btn9) btn9.FillColor = Color.White;
            if (btnNiño is Guna.UI2.WinForms.Guna2Button btn10) btn10.FillColor = Color.White;
            if (btnAdulto is Guna.UI2.WinForms.Guna2Button btn11) btn11.FillColor = Color.White;
        }

    }
}