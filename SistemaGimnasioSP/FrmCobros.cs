using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    public partial class FrmCobros : Form
    {
        // Aquí guardaremos los IDs de los deportes que el cajero vaya seleccionando
        List<int> deportesSeleccionados = new List<int>();

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
    }
}