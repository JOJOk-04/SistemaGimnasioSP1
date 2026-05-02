using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;
using System.Diagnostics;

namespace SistemaGimnasioSP
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void BtnGuardar1_Click(object sender, EventArgs e)
        {   //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //
            // --- BLOQUE DE VALIDACIÓN PERSONALIZADA ---
            // Solo el ID puede ignorarse (ya que se genera solo), los demás son obligatorios

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingrese la dirección.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            if (cmbMunicipio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un municipio.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMunicipio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, ingrese el número de teléfono.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactoEmergencia.Text))
            {
                MessageBox.Show("Por favor, ingrese el contacto de emergencia.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactoEmergencia.Focus();
                return;
            }
            // --- FIN DE VALIDACIÓN ---
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null)
            {
                MessageBox.Show("Error al conectar con la base de datos. Verifica que el servicio MySQL esté encendido.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction();

                // ---------------------------------------------------------
                // FASE 1: Generar el ID Numérico Automático
                // ---------------------------------------------------------
                string nuevoId = "00001";
                string queryId = "SELECT MAX(id_cliente) FROM Clientes";

                MySqlCommand cmdId = new MySqlCommand(queryId, conexion, transaccion);
                object resultado = cmdId.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    int numero = int.Parse(resultado.ToString()) + 1;
                    nuevoId = numero.ToString("D5");
                }

                // ---------------------------------------------------------
                // FASE 2: Insertar datos a MySQL
                // ---------------------------------------------------------
                // -AVISO Omar editó esta parte para eliminar el error al guardar un nuevo usuario en el apartado de registro
                //  hablando en especifico de el error "Error critico al guardar: Uknow column 'estatus' in field list
                //  que se corrijio eliminando la parte del código que hacia referencia a ese campo (estatus, 'Inactivo') que no
                //  existe en la tabla de clientes y tambien a algo que nisiquiera se necesitaba a el momento de insertar un nuevo
                //  cliente a el/la base de datos/registro
                // ---------------------------------------------------------------------------------------------------------------
                string queryInsert = @"INSERT INTO Clientes 
            (id_cliente, nombre, fecha_nacimiento, direccion, municipio, telefono, contacto_emergencia)
            VALUES (@id, @nombre, @fecha, @direccion, @municipio, @telefono, @contacto)";

                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion, transaccion);

                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text.Trim());
                // EJECUTAR EL COMANDO
                cmdInsert.ExecuteNonQuery();

                // Guardar cambios permanentemente
                transaccion.Commit();

                MessageBox.Show($"¡Registro exitoso!\n\nNúmero de Cliente / Gafete: {nuevoId}",
                                "Sistema de Gimnasio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la pantalla
                LimpiarTodo();
            }
            catch (Exception ex)
            {
                if (transaccion != null) transaccion.Rollback();
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
        }

        // Método para dejar el formulario listo para el siguiente registro
        private void LimpiarTodo()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtContactoEmergencia.Clear();
            cmbMunicipio.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtContactoEmergencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}