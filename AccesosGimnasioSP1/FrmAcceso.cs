using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void txtEscaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string gafete = txtEscaner.Text.Trim();

                if (!string.IsNullOrWhiteSpace(gafete))
                {
                    VerificarAcceso(gafete);
                }
            }
        }

        private void VerificarAcceso(string idCliente)
        {
            // ✨ EL TRUCO DE LOS CEROS: Por si lo escriben a mano en vez de escanear
            if (idCliente.Length > 5 && int.TryParse(idCliente, out int idNumerico))
            {
                idCliente = idNumerico.ToString("D5");
            }

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
                // ✨ EL SQL MAESTRO: Calcula el estatus leyendo la fecha de vencimiento
                string queryBuscar = @"
                    SELECT c.nombre, 
                           IF(i.fecha_vencimiento >= CURDATE(), 'Activo', 'Inactivo') AS estatus_calculado 
                    FROM Clientes c 
                    INNER JOIN Inscripciones i ON c.id_cliente = i.id_cliente 
                    WHERE c.id_cliente = @id 
                    ORDER BY i.fecha_vencimiento DESC LIMIT 1";

                MySqlCommand cmdBuscar = new MySqlCommand(queryBuscar, conexion);
                cmdBuscar.Parameters.AddWithValue("@id", idCliente);

                MySqlDataReader lector = cmdBuscar.ExecuteReader();

                if (lector.Read()) // Si el cliente existe y tiene inscripciones
                {
                    string estatus = lector["estatus_calculado"].ToString();
                    string nombre = lector["nombre"].ToString().Trim();

                    // ¡Súper importante cerrar el lector antes de hacer el INSERT!
                    lector.Close();

                    if (estatus == "Activo")
                    {
                        lblMensaje.Text = "¡ACCESO CONCEDIDO!";
                        lblMensaje.ForeColor = Color.LimeGreen;
                        lblNombre.Text = "Bienvenido, " + nombre;

                        // Registro del ingreso en la bitácora
                        string queryIngreso = "INSERT INTO accesos_diarios (id_cliente, fecha_hora) VALUES (@id, NOW())";
                        MySqlCommand cmdIngreso = new MySqlCommand(queryIngreso, conexion);
                        cmdIngreso.Parameters.AddWithValue("@id", idCliente);
                        cmdIngreso.ExecuteNonQuery();
                    }
                    else
                    {
                        // Cuando SÍ lo encuentra pero su fecha ya pasó
                        lblMensaje.Text = "MENSUALIDAD VENCIDA";
                        lblMensaje.ForeColor = Color.Red;
                        lblNombre.Text = nombre;
                    }
                }
                else
                {
                    // Cuando NO existe el cliente o nunca ha pagado nada
                    lblMensaje.Text = "GAFETE NO VÁLIDO";
                    lblMensaje.ForeColor = Color.Orange;
                    lblNombre.Text = "---";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema: " + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
                txtEscaner.Clear();
                txtEscaner.Focus(); // Regresamos el cursor para el siguiente escaneo
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string gafete = txtEscaner.Text.Trim();
            if (!string.IsNullOrWhiteSpace(gafete))
            {
                VerificarAcceso(gafete);
            }
        }

        private void lblNombre_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtEscaner_TextChanged(object sender, EventArgs e) { }
    }
}