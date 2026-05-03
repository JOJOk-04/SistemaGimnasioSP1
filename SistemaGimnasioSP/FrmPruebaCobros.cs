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
        // Hasta arriba de tu FrmCobros.cs
        string idClientePrincipal = "";
  
        // ... etc
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

        // === ESTE ES EL EVENTO QUE CORRIGE EL DISEÑO ===
        // Se ejecuta justo antes de que el formulario se muestre
        private void FrmPruebaCobros_Load(object sender, EventArgs e)
        {
            // Ojo: Asegúrate de que 'tabMenuTesoreria' sea el nombre de tu control principal
            if (tabMenuTesoreria != null)
            {
                // 1. Alineación arriba
                tabMenuTesoreria.Alignment = TabAlignment.Top;

                // 2. Cálculo del ancho
                this.ResumeLayout(true);
                int numeroDePestañas = 5;
                if (tabMenuTesoreria.TabPages.Count > 0)
                {
                    numeroDePestañas = tabMenuTesoreria.TabPages.Count;
                }

                int anchoPorPestaña = (tabMenuTesoreria.Width / numeroDePestañas) - 2;

                // 3. Aplicar el tamaño para que no se encimen
                tabMenuTesoreria.ItemSize = new Size(anchoPorPestaña, 60);
            }
        }
            // =====================================================================
            // CEREBRO 1: DEPORTES (Este es el que ya tenías, lo dejé limpiecito)
            // =====================================================================
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

                ConexionDB baseDatos = new ConexionDB();
                MySqlConnection conexion = baseDatos.AbrirConexion();

                if (conexion != null)
                {
                    try
                    {
                        int idDeportePrincipal = deportesSeleccionados[0];
                        // Busca en la tabla DEPORTES
                        string query = $"SELECT {columnaPrecio} FROM deportes WHERE id_deporte = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idDeportePrincipal);

                        decimal precioBase = Convert.ToDecimal(cmd.ExecuteScalar());

                        if (esSenior) { precioBase = 0; }

                        subtotalDeportes += precioBase;

                        if (deportesSeleccionados.Count > 1)
                        {
                            int cantidadExtras = deportesSeleccionados.Count - 1;
                            subtotalDeportes += (cantidadExtras * costoExtra);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en cálculo de deportes: " + ex.Message); }
                    finally { baseDatos.CerrarConexion(); }
                }

                ActualizarGranTotal();
            }

            // =====================================================================
            // CEREBRO 2: SERVICIOS (El NUEVO, para los equipos, campamentos, etc.)
            // =====================================================================
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

            // =====================================================================
            // GRAN TOTAL (Suma ambos cerebros)
            // =====================================================================
            private void ActualizarGranTotal()
            {
                decimal granTotal = subtotalDeportes + subtotalServicios;
                lblTotalPagar.Text = $"Total a Pagar: {granTotal:C}";
            }
        // FrmPruebaCobros.cs
        private void ToggleDeporte(Control btn, int idDeporte)
        {
            // 1. Convertimos el control genérico a un botón de Guna
            Guna.UI2.WinForms.Guna2Button botonGuna = btn as Guna.UI2.WinForms.Guna2Button;

            if (botonGuna == null) return;

            if (deportesSeleccionados.Contains(idDeporte))
            {
                deportesSeleccionados.Remove(idDeporte);
                // 2. Usamos FillColor en lugar de BackColor
                botonGuna.FillColor = Color.White;
            }
            else
            {
                deportesSeleccionados.Add(idDeporte);
                // Usamos FillColor para que el botón se pinte por dentro
                botonGuna.FillColor = Color.LightGreen;
            }

            CalcularSubtotalDeportes();
        }

        // 🔘 Este es el interruptor para los SERVICIOS Y EQUIPOS (Softball, Alberca, etc)
        private void ToggleServicioExtra(Control btn, int idServicio)
        {
            // 1. Convertimos el control genérico a un botón de Guna
            Guna.UI2.WinForms.Guna2Button botonGuna = btn as Guna.UI2.WinForms.Guna2Button;

            if (botonGuna == null) return;

            if (serviciosSeleccionados.Contains(idServicio))
            {
                serviciosSeleccionados.Remove(idServicio);
                // 2. Usamos FillColor
                botonGuna.FillColor = Color.White;
            }
            else
            {
                serviciosSeleccionados.Add(idServicio);
                // Usamos FillColor
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
                int limitePersonasDB = 0; // ✨ Nueva variable para guardar el límite de la base de datos

                ConexionDB baseDatos = new ConexionDB();
                MySqlConnection conexion = baseDatos.AbrirConexion();

                if (conexion != null)
                {
                    try
                    {
                        // ✨ Ahora le pedimos a MySQL que también nos traiga el limite_personas
                        string query = $"SELECT {columnaPrecio}, nombre_paquete, limite_personas FROM paquetes WHERE id_paquete = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idPaquete);

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                precioBasePaquete = Convert.ToDecimal(lector[columnaPrecio]);
                                nombrePaqueteReal = lector["nombre_paquete"].ToString();

                                // ✨ Extraemos el límite directamente de MySQL
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

                // ✨ Le pasamos el límite de la Base de Datos a la ventanita
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
                // Si la tecla que presionó fue Enter...
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Esto quita el molesto sonido de "ding" de Windows
                    BuscarCliente(); // Llamamos a nuestra función maestra
                }
            }
            private void BuscarCliente()
            {
                string idBuscado = txtBusquedaId.Text.Trim();
            
                // 1. Validamos que no esté vacío
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
                        // 2. Buscamos al cliente en tu base de datos
                        string query = "SELECT nombre, fecha_nacimiento, municipio FROM clientes WHERE id_cliente = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idBuscado);

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read()) // Si encontró al cliente
                            {
                                // Extraemos los datos
                                string nombre = lector["nombre"].ToString();
                                DateTime fechaNacimiento = Convert.ToDateTime(lector["fecha_nacimiento"]);
                                string municipio = lector["municipio"].ToString();

                                // 3. Calculamos la edad exacta
                                int edad = DateTime.Today.Year - fechaNacimiento.Year;
                                // Si aún no cumple años este año, le restamos 1
                                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;

                                // 4. Actualizamos tus Labels (Asegúrate de ponerles estos nombres a tus labels)
                                lblNombre.Text = "Nombre: " + nombre;
                                lblEdad.Text = "Edad: " + edad.ToString();
                                lblMunicipio.Text = "Municipio: " + municipio;

                                // ✨ TOQUE PRO: Pintar la edad de verde si aplica descuento Senior
                                if (edad >= 60)
                                {
                                    lblEdad.ForeColor = Color.Green;
                                }
                                else
                                {
                                    lblEdad.ForeColor = Color.Black; // Color normal
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cliente no encontrado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // Limpiamos los labels por si había otro cliente antes
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
            // 1. Liga de futbol por equipo (ID: 13)
            private void btnLigasdeFutbol_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 13);
            }

            // 2. Inscripción Equipo Softbol (ID: 14)
            private void btnEquipoSoftbol_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 14);
            }

            // 3. Campamento de verano (ID: 16)
            private void btnCampamento_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 16);
            }

            // 4. Campamento de verano hermano (ID: 17)
            private void btnAgregarhno_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 17);
            }

            // 5. Alberca pública niño (ID: 18)
            private void btnNiño_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 18);
            }

            // 6. Alberca pública adulto (ID: 19)
            private void btnAdulto_Click(object sender, EventArgs e)
            {
                ToggleServicioExtra(sender as Control, 19);
            }

            private void btnPaquetef2_Click(object sender, EventArgs e)
            {

                // Solo mandamos el ID 2 (El paquete de 3 a 5 personas). 
                // ¡La función maestra y MySQL se encargan de todo lo demás!
                ProcesarPaqueteFamiliar(2);
            }
            private void btnCobrar_Click(object sender, EventArgs e)
            {

                if (deportesSeleccionados.Count == 0 && carritoFamiliarPendiente.Count == 0)
                {
                    MessageBox.Show("No hay actividades seleccionadas para cobrar.", "Aviso de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                idClientePrincipal = txtBusquedaId.Text.Trim();

                if (string.IsNullOrWhiteSpace(idClientePrincipal))
                {
                    MessageBox.Show("Falta seleccionar el ID del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ConexionDB bd = new ConexionDB();
                MySqlConnection conexion = bd.AbrirConexion();

                if (conexion != null)
                {
                    MySqlTransaction transaccion = null;
                    try
                    {

                        transaccion = conexion.BeginTransaction();


                        if (carritoFamiliarPendiente.Count > 0)
                        {
                            foreach (var item in carritoFamiliarPendiente)
                            {

                                string queryInscripcion = "INSERT INTO inscripciones (id_cliente, id_deporte, fecha_pago, fecha_vencimiento) VALUES (@idC, @idD, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 MONTH))";
                                MySqlCommand cmdInsc = new MySqlCommand(queryInscripcion, conexion, transaccion);
                                cmdInsc.Parameters.AddWithValue("@idC", item.IdCliente);
                                cmdInsc.Parameters.AddWithValue("@idD", item.IdDeporte);
                                cmdInsc.ExecuteNonQuery();


                                string queryFamilia = "UPDATE clientes SET id_titular_familia = @idTitular WHERE id_cliente = @idHijo AND id_cliente != @idTitular";
                                MySqlCommand cmdUpdate = new MySqlCommand(queryFamilia, conexion, transaccion);
                                cmdUpdate.Parameters.AddWithValue("@idTitular", idClientePrincipal);
                                cmdUpdate.Parameters.AddWithValue("@idHijo", item.IdCliente);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                        // =================================================================
                        // ESCENARIO B: COBRO INDIVIDUAL CON SUS EXTRAS (Lobo Solitario)
                        // =================================================================
                        else if (deportesSeleccionados.Count > 0)
                        {
                            foreach (int idDeporte in deportesSeleccionados)
                            {
                                // B.1 Inscribir a sus deportes individuales (PARCHADO CON FECHA DE VENCIMIENTO)
                                string queryInscripcion = "INSERT INTO inscripciones (id_cliente, id_deporte, fecha_pago, fecha_vencimiento) VALUES (@idC, @idD, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 MONTH))";
                                MySqlCommand cmdInsc = new MySqlCommand(queryInscripcion, conexion, transaccion);
                                cmdInsc.Parameters.AddWithValue("@idC", idClientePrincipal);
                                cmdInsc.Parameters.AddWithValue("@idD", idDeporte);
                                cmdInsc.ExecuteNonQuery();
                            }
                        }
                        // =================================================================
                        // ESCENARIO C: REGISTRO DE SERVICIOS ESPECIALES (Nueva Tabla)
                        // =================================================================
                        if (serviciosSeleccionados.Count > 0)
                        {
                            foreach (int idServicio in serviciosSeleccionados)
                            {
                                string queryInscServicio = @"INSERT INTO inscripciones_servicios 
                                               (id_cliente, id_servicio, fecha_pago) 
                                               VALUES (@idC, @idS, CURDATE())";

                                MySqlCommand cmdInscS = new MySqlCommand(queryInscServicio, conexion, transaccion);
                                cmdInscS.Parameters.AddWithValue("@idC", idClientePrincipal);
                                cmdInscS.Parameters.AddWithValue("@idS", idServicio);
                                cmdInscS.ExecuteNonQuery();
                            }
                        }

                        // 3. 🛡️ ¡CONFIRMAMOS LOS CAMBIOS EN MYSQL!
                        transaccion.Commit();

                        MessageBox.Show("¡Cobro realizado con éxito! Todos los datos fueron guardados correctamente.", "Venta Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ImprimirTicket();

                    // 4. Dejar la caja limpia para el siguiente cliente
                    LimpiarPantallaCobros();
                    }
                    catch (Exception ex)
                    {
                        // 🛡️ Intentamos hacer el Rollback de forma segura
                        if (transaccion != null && transaccion.Connection != null)
                        {
                            try { transaccion.Rollback(); } catch { /* Ignoramos si ya estaba cancelada */ }
                        }

                        // 🚨 AHORA SÍ: Nos mostrará el VERDADERO error que está causando el problema
                        MessageBox.Show("Ocurrió un error al guardar en la base de datos.\n\nEl sistema reporta: " + ex.Message,
                                        "Error de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        bd.CerrarConexion();
                    }
                }
            }
        // =====================================================================
        // MÓDULO DE IMPRESIÓN DE TICKETS
        // =====================================================================
        private void ImprimirTicket()
        {
            PrintDocument ticket = new PrintDocument();

            // Si quieres mandar la impresión a una impresora térmica en específico, descomenta esta línea y pon su nombre:
            // ticket.PrinterSettings.PrinterName = "NombreDeTuImpresoraTermica"; 

            // Le decimos a la impresora qué es lo que va a "dibujar"
            ticket.PrintPage += new PrintPageEventHandler(DibujarTicket);

            try
            {
                ticket.Print(); // ¡Fuego! 🔥 Manda la orden a la impresora
            }
            catch (Exception ex)
            {
                MessageBox.Show("El cobro se guardó, pero hubo un error al imprimir el ticket: " + ex.Message, "Aviso de Impresora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DibujarTicket(object sender, PrintPageEventArgs e)
        {
            Graphics graficos = e.Graphics;

            // Fuentes (Letras)
            Font fuenteTitulo = new Font("Courier New", 12, FontStyle.Bold);
            Font fuenteNormal = new Font("Courier New", 10, FontStyle.Regular);
            Font fuentePequeña = new Font("Courier New", 8, FontStyle.Regular);

            int y = 20; // Coordenada vertical inicial
            int margen = 10; // Margen izquierdo

            // 1. Encabezado del Gimnasio
            graficos.DrawString("GIMNASIO MUNICIPAL SP", fuenteTitulo, Brushes.Black, margen, y);
            y += 20;
            graficos.DrawString("San Pedro Garza García", fuenteNormal, Brushes.Black, margen, y);
            y += 30;

            // 2. Datos Generales del Ticket
            graficos.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            // 🆔 AQUÍ AGREGAMOS EL ID DEL CLIENTE
            // Nota: idClientePrincipal debe ser la variable donde guardaste el ID al buscarlo
            graficos.DrawString("ID Cliente: " + idClientePrincipal, fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            string nombreLimpio = lblNombre.Text.Replace("Nombre: ", "");
            graficos.DrawString("Cliente: " + nombreLimpio, fuenteNormal, Brushes.Black, margen, y);
            y += 20;
            graficos.DrawString("--------------------------------", fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            // 3. CONCEPTOS PAGADOS (Desglose)
            graficos.DrawString("CONCEPTOS PAGADOS:", fuenteTitulo, Brushes.Black, margen, y);
            y += 20;

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // Nombres de Deportes
                    foreach (int idD in deportesSeleccionados)
                    {
                        MySqlCommand cmdD = new MySqlCommand("SELECT nombre_deporte FROM deportes WHERE id_deporte = @id", conexion);
                        cmdD.Parameters.AddWithValue("@id", idD);
                        string nombreDep = cmdD.ExecuteScalar()?.ToString();
                        graficos.DrawString("- " + nombreDep, fuenteNormal, Brushes.Black, margen, y);
                        y += 20;
                    }

                    // Nombres de Servicios/Equipos
                    foreach (int idS in serviciosSeleccionados)
                    {
                        MySqlCommand cmdS = new MySqlCommand("SELECT nombre_servicio FROM servicios WHERE id_servicio = @id", conexion);
                        cmdS.Parameters.AddWithValue("@id", idS);
                        string nombreServ = cmdS.ExecuteScalar()?.ToString();
                        graficos.DrawString("- " + nombreServ, fuenteNormal, Brushes.Black, margen, y);
                        y += 20;
                    }
                }
                finally { bd.CerrarConexion(); }
            }

            graficos.DrawString("--------------------------------", fuenteNormal, Brushes.Black, margen, y);
            y += 20;

            // 4. El Gran Total (Desde el Label calculado)
            graficos.DrawString(lblTotalPagar.Text, fuenteTitulo, Brushes.Black, margen, y);
            y += 40;

            // 5. Pie de página
            graficos.DrawString("¡Gracias por fomentar el deporte!", fuentePequeña, Brushes.Black, margen, y);
            y += 15;
            graficos.DrawString("Conserve este ticket.", fuentePequeña, Brushes.Black, margen, y);
        }

        // 🧹 Función para resetear tu pantalla
        private void LimpiarPantallaCobros()
            {
                txtBusquedaId.Clear();
                idClientePrincipal = ""; // Reseteamos el ID
                lblNombre.Text = "Nombre: ---";
                lblEdad.Text = "Edad: ---";
                lblMunicipio.Text = "Municipio: ---";
                lblTotalPagar.Text = "Total a Pagar: $0.00";

                // Vaciamos la memoria RAM
                deportesSeleccionados.Clear();
                carritoFamiliarPendiente.Clear();
                subtotalDeportes = 0;

                // Regresamos los colores de los botones a la normalidad (Ajusta los nombres si se llaman distinto)
                btnAcondicionamiento.BackColor = Color.White;
                btnFutbol.BackColor = Color.White;
                btnTaekwondo.BackColor = Color.White;
                // btnHeterofilia.BackColor = Color.White; // Descomenta esta si tu botón se llama así
                btnRitmos.BackColor = Color.White;
            }

    }
}
