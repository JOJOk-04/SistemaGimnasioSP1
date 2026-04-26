using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static SistemaGimnasioSP.FrmPaquetes;

namespace SistemaGimnasioSP
{
    public partial class FrmCobros : Form
    {
        // === BOLSAS DE MEMORIA ===

        // Bolsa 1: Para los deportes individuales (Acondicionamiento, Box, etc)
        List<int> deportesSeleccionados = new List<int>();
        decimal subtotalDeportes = 0;

        // Bolsa 2: Para los servicios y equipos (Ligas, Alberca, Campamentos)
        List<int> serviciosSeleccionados = new List<int>();
        decimal subtotalServicios = 0;

        List<InscripcionTemporal> carritoFamiliarPendiente = new List<InscripcionTemporal>();

        public FrmCobros()
        {
            InitializeComponent();
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
                        // Busca en tu nueva tabla SERVICIOS
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
        // =====================================================================
        // INTERRUPTORES (TOGGLES) PARA LOS BOTONES
        // =====================================================================

        // 🔘 Este es el interruptor para los DEPORTES NORMALES (Box, Ritmos, etc)
        private void ToggleDeporte(Button btn, int idDeporte)
        {
            if (deportesSeleccionados.Contains(idDeporte))
            {
                deportesSeleccionados.Remove(idDeporte);
                btn.BackColor = Color.White;
            }
            else
            {
                deportesSeleccionados.Add(idDeporte);
                btn.BackColor = Color.LightGreen; // Se pinta verde
            }

            // Despierta al Cerebro 1
            CalcularSubtotalDeportes();
        }

        // 🔘 Este es el interruptor para los SERVICIOS Y EQUIPOS (Softball, Alberca, etc)
        private void ToggleServicioExtra(Button btn, int idServicio)
        {
            if (serviciosSeleccionados.Contains(idServicio))
            {
                serviciosSeleccionados.Remove(idServicio);
                btn.BackColor = Color.White;
            }
            else
            {
                serviciosSeleccionados.Add(idServicio);
                btn.BackColor = Color.LightSkyBlue; // Se pinta azulito para diferenciarlos
            }

            // Despierta al Cerebro 2
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void btnAcondicionamiento_Click(object sender, EventArgs e) 
        {
            ToggleDeporte((Button)sender, 1);
        }

        private void btnFutbol_Click(object sender, EventArgs e)
        {
            ToggleDeporte((Button)sender, 2);
        }

        private void btnTaekwondo_Click(object sender, EventArgs e)
        {
            ToggleDeporte((Button)sender, 3);
        }

        private void Heterofilia_Click(object sender, EventArgs e)
        {
            ToggleDeporte((Button)sender, 4);
        }

        private void btnRitmos_Click(object sender, EventArgs e)
        {
            ToggleDeporte((Button)sender, 5);
        }

        private void btnPaquetef1_Click(object sender, EventArgs e)
        {
            ProcesarPaqueteFamiliar(1);
        }
        // 1. Liga de futbol por equipo (ID: 13)
        private void btnLigasdeFutbol_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 13);
        }

        // 2. Inscripción Equipo Softball (ID: 14)
        private void btnEquipoSoftball_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 14);
        }

        // 3. Campamento de verano (ID: 16)
        private void btnCampamento_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 16);
        }

        // 4. Campamento de verano hermano (ID: 17)
        private void btnAgregarhno_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 17);
        }

        // 5. Alberca pública niño (ID: 18)
        private void btnNiño_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 18);
        }

        // 6. Alberca pública adulto (ID: 19)
        private void btnAdulto_Click(object sender, EventArgs e)
        {
            ToggleServicioExtra((Button)sender, 19);
        }

        private void btnPaquetef2_Click(object sender, EventArgs e)
        {

            // Solo mandamos el ID 2 (El paquete de 3 a 5 personas). 
            // ¡La función maestra y MySQL se encargan de todo lo demás!
            ProcesarPaqueteFamiliar(2);
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            // 1. EL SEMÁFORO: Validar que haya algo para cobrar
            if (deportesSeleccionados.Count == 0 && carritoFamiliarPendiente.Count == 0)
            {
                MessageBox.Show("No hay actividades seleccionadas para cobrar.", "Aviso de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idClientePrincipal = txtBusquedaId.Text.Trim();

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
                    // 🛡️ ¡Iniciamos la burbuja de seguridad!
                    transaccion = conexion.BeginTransaction();

                    // =================================================================
                    // ESCENARIO A: COBRO DE PAQUETE FAMILIAR (La Manada)
                    // =================================================================
                    if (carritoFamiliarPendiente.Count > 0)
                    {
                        foreach (var item in carritoFamiliarPendiente)
                        {
                            // A.1 Inscribir al deporte (PARCHADO CON FECHA DE VENCIMIENTO)
                            string queryInscripcion = "INSERT INTO inscripciones (id_cliente, id_deporte, fecha_pago, fecha_vencimiento) VALUES (@idC, @idD, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 1 MONTH))";
                            MySqlCommand cmdInsc = new MySqlCommand(queryInscripcion, conexion, transaccion);
                            cmdInsc.Parameters.AddWithValue("@idC", item.IdCliente);
                            cmdInsc.Parameters.AddWithValue("@idD", item.IdDeporte);
                            cmdInsc.ExecuteNonQuery();

                            // A.2 Crear o Actualizar el Lazo Familiar
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
                            // ¡A la nueva tabla! (Sin monto y sin fecha de vencimiento)
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

        // 🧹 Función para resetear tu pantalla
        private void LimpiarPantallaCobros()
        {
            txtBusquedaId.Clear();
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