using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesosGimnasioSP1
{
    public partial class FrmAcceso : Form
    {
        public FrmAcceso()
        {
            InitializeComponent();
        }

        // =====================================================================
        // ATRAPAMOS EL DISPARO DEL LECTOR DE CÓDIGO DE BARRAS
        // =====================================================================
        // CORRECCIÓN: Se agregó la palabra 'void' aquí 
        private void txtEscaner_KeyDown(object sender, KeyEventArgs e)
        {
            // Si la tecla que se presionó es el "Enter"...
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que suene el "ding" molesto de Windows

                string gafete = txtEscaner.Text.Trim();

                if (!string.IsNullOrWhiteSpace(gafete))
                {
                    VerificarAcceso(gafete);
                }
            }
        }

        // =====================================================================
        // EL CEREBRO DEL TORNIQUETE
        // =====================================================================
        // CORRECCIÓN: Se agregó la palabra 'void' aquí 
        private void VerificarAcceso(string idCliente)
        {
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null)
            {
                lblMensaje.Text = "ERROR DE RED";
                lblMensaje.ForeColor = Color.Orange;
                return;
            }

            try
            {
                // 1. Buscamos al cliente (Versión Flexible con LIKE)
                string queryBuscar = "SELECT nombre, estatus FROM Clientes WHERE id_cliente LIKE @id LIMIT 1";
                MySqlCommand cmdBuscar = new MySqlCommand(queryBuscar, conexion);
                cmdBuscar.Parameters.AddWithValue("@id", "%" + idCliente + "%");

                MySqlDataReader lector = cmdBuscar.ExecuteReader();

                if (lector.Read())
                {
                    string estatus = lector["estatus"].ToString().Trim();
                    string nombre = lector["nombre"].ToString().Trim();

                    lector.Close(); // Cerramos el lector para poder hacer el INSERT abajo

                    if (estatus == "Activo")
                    {
                        // 🟢 TIENE PAGADO: Lo dejamos pasar y lo registramos en el Historial
                        lblMensaje.Text = "¡ACCESO CONCEDIDO!";
                        lblMensaje.ForeColor = Color.LimeGreen;
                        lblNombre.Text = "Bienvenido, " + nombre;

                        // Guardamos a qué hora entró en la tabla accesos diarios
                        // (NOW() es un comando de MySQL que pone la fecha y hora exacta actual)
                        string queryIngreso = "INSERT INTO accesos_diarios (id_cliente, fecha_hora) VALUES (@id, NOW())";
                        MySqlCommand cmdIngreso = new MySqlCommand(queryIngreso, conexion);
                        cmdIngreso.Parameters.AddWithValue("@id", idCliente);
                        cmdIngreso.ExecuteNonQuery();
                    }
                    else
                    {
                        // 🔴 NO HA PAGADO: Bloqueamos el paso
                        lblMensaje.Text = "ACCESO DENEGADO\nFAVOR DE PASAR A CAJA";
                        lblMensaje.ForeColor = Color.Red;
                        lblNombre.Text = nombre + " (Inactivo)";
                    }
                }
                else
                {
                    // 🟡 EL GAFETE NO EXISTE EN LA BASE DE DATOS
                    lblMensaje.Text = "GAFETE NO RECONOCIDO";
                    lblMensaje.ForeColor = Color.Orange;
                    lblNombre.Text = "---";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el torniquete: " + ex.Message);
            }
            finally
            {
                baseDatos.CerrarConexion();

                // Limpiamos el buscador y lo dejamos listo para la siguiente persona
                txtEscaner.Clear();
                txtEscaner.Focus();
            }
        }

        // CORRECCIÓN: Se agregó la palabra 'void' a todos estos eventos también
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string gafete = txtEscaner.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gafete))
            {
                VerificarAcceso(gafete);
            }
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEscaner_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
