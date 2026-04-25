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
        // Aquí guardaremos los IDs de los deportes que el cajero vaya seleccionando
        List<int> deportesSeleccionados = new List<int>();
        List<InscripcionTemporal> carritoFamiliarPendiente = new List<InscripcionTemporal>();

        // Esta variable guardará el dinero de esta sección para sumarlo después con las demás
        decimal subtotalDeportes = 0;
        public FrmCobros()
        {
            InitializeComponent();
        }
        private void CalcularSubtotalDeportes()
        {

            subtotalDeportes = 0;

            if (deportesSeleccionados.Count == 0)
            {
                ActualizarGranTotal();
                return;
            }

            // 1. EXTRAER DATOS CON PRECISIÓN QUIRÚRGICA
            // Eliminamos el prefijo "Municipio: " para quedarnos solo con el nombre
            string municipioPuro = lblMunicipio.Text.Replace("Municipio:", "").Trim();

            // REGLA DE ORO: Solo si es exactamente igual a la opción del ComboBox
            bool esLocal = (municipioPuro == "San Pedro Garza García");

            string columnaPrecio = esLocal ? "precio_local" : "precio_foraneo";

            // Definimos el costo extra según el origen
            decimal costoExtra = esLocal ? 100 : 200;

            // Extraer edad
            int edad = 0;
            string edadTexto = lblEdad.Text.Replace("Edad:", "").Replace("años", "").Trim();
            int.TryParse(edadTexto, out edad);
            bool esSenior = (edad >= 60);

            // 2. CONSULTA A BASE DE DATOS
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // Deporte Principal (Posición 0 de la lista)
                    int idDeportePrincipal = deportesSeleccionados[0];
                    string query = $"SELECT {columnaPrecio} FROM deportes WHERE id_deporte = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idDeportePrincipal);

                    decimal precioBase = Convert.ToDecimal(cmd.ExecuteScalar());

                    // Si es Senior, el primero es gratis
                    if (esSenior) { precioBase = 0; }

                    subtotalDeportes += precioBase;

                    // 3. COBRO DE ACTIVIDADES EXTRAS
                    if (deportesSeleccionados.Count > 1)
                    {
                        int cantidadExtras = deportesSeleccionados.Count - 1;
                        subtotalDeportes += (cantidadExtras * costoExtra);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en cálculo: " + ex.Message);
                }
                finally { baseDatos.CerrarConexion(); }
            }

            ActualizarGranTotal();
        }
        // 🚨 Ahora el botón SOLO le manda el ID del paquete, nada más.
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
        private void ActualizarGranTotal()
        {
            // En el futuro será: subtotalDeportes + subtotalLigas + subtotalPaquetes...
            decimal granTotal = subtotalDeportes;

            // Mostramos el total con formato de moneda ($)
            lblTotalPagar.Text = $"Total a Pagar: {granTotal:C}";
        }
        private void ToggleDeporte(Button btn, int idDeporte)
        {
            if (deportesSeleccionados.Contains(idDeporte))
            {
                // Si ya estaba seleccionado, lo quitamos y regresamos el color a blanco/gris
                deportesSeleccionados.Remove(idDeporte);
                btn.BackColor = Color.White;
            }
            else
            {
                // Si no estaba, lo agregamos y lo pintamos de un color que resalte (ej. Verde Claro)
                deportesSeleccionados.Add(idDeporte);
                btn.BackColor = Color.LightGreen;
            }

            // Cada vez que tocamos un botón, recalculamos el dinero
            CalcularSubtotalDeportes();
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