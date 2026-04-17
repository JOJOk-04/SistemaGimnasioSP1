using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    public partial class FrmCobros : Form
    {
        public FrmCobros()
        {
            InitializeComponent();
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

    }
}