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
                // CORRECCIÓN: Consulta con INNER JOIN para traer el estatus desde la tabla Inscripciones
                string queryBuscar = @"
                    SELECT c.nombre, i.estatus 
                    FROM Clientes c 
                    INNER JOIN Inscripciones i ON c.id_cliente = i.id_cliente 
                    WHERE c.id_cliente = @id 
                    ORDER BY i.id_inscripcion DESC LIMIT 1";

                MySqlCommand cmdBuscar = new MySqlCommand(queryBuscar, conexion);
                cmdBuscar.Parameters.AddWithValue("@id", idCliente);

                MySqlDataReader lector = cmdBuscar.ExecuteReader();

                if (lector.Read())
                {
                    string estatus = lector["estatus"].ToString().Trim();
                    string nombre = lector["nombre"].ToString().Trim();

                    lector.Close();

                    if (estatus.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                    {
                        lblMensaje.Text = "¡ACCESO CONCEDIDO!";
                        lblMensaje.ForeColor = Color.LimeGreen;
                        lblNombre.Text = "Bienvenido, " + nombre;

                        // Registro del ingreso
                        string queryIngreso = "INSERT INTO accesos_diarios (id_cliente, fecha_hora) VALUES (@id, NOW())";
                        MySqlCommand cmdIngreso = new MySqlCommand(queryIngreso, conexion);
                        cmdIngreso.Parameters.AddWithValue("@id", idCliente);
                        cmdIngreso.ExecuteNonQuery();
                    }
                    
                }
                else
                {
                    lblMensaje.Text = "MENSUALIDAD INACTIVA";
                    lblMensaje.ForeColor = Color.Orange;
                    lblNombre.Text = "Bienvenido";
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
                txtEscaner.Focus();
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