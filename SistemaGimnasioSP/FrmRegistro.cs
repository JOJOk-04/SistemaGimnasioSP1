using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // Para manejo de fechas y culturas
using MySql.Data.MySqlClient; // Asegúrate de tener el paquete MySql.Data instalado para esto

namespace SistemaGimnasioSP
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        // Este es tu botón de Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            // ---------------------------------------------------------
            // FASE 0: Validación de Campos Obligatorios
            // ---------------------------------------------------------

            // Creamos una lista para ir guardando qué campos faltan
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el Nombre del cliente.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus(); // Pone el cursor en el error
                return; // Detiene la ejecución para que no guarde nada
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingrese la Dirección.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            if (cmbMunicipio.SelectedIndex == -1) // Verifica que se haya seleccionado algo del combo
            {
                MessageBox.Show("Por favor, seleccione un Municipio.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMunicipio.DroppedDown = true; // Despliega el combo automáticamente
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de Teléfono.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactoEmergencia.Text))
            {
                MessageBox.Show("Por favor, ingrese el Contacto de Emergencia.", "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactoEmergencia.Focus();
                return;
            }

            // ---------------------------------------------------------
            // FASE 1: Proceso de Guardado (Solo si pasó las validaciones)
            // ---------------------------------------------------------
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null)
            {
                return;
            }

            try
            {
                // Generar el ID Numérico Automático
                string nuevoId = "00001";
                string queryId = "SELECT MAX(id_cliente) FROM Clientes";
                MySqlCommand cmdId = new MySqlCommand(queryId, conexion);
                object resultado = cmdId.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    int numero = int.Parse(resultado.ToString()) + 1;
                    nuevoId = numero.ToString("D5");
                }

                // Insertar datos a MySQL
                string queryInsert = @"INSERT INTO Clientes 
            (id_cliente, nombre, fecha_nacimiento, direccion, municipio, telefono, contacto_emergencia, estatus) 
            VALUES (@id, @nombre, @fecha, @direccion, @municipio, @telefono, @contacto, 'Inactivo')";

                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion);

                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim()); // Trim quita espacios vacíos al inicio/final
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text.Trim());

                cmdInsert.ExecuteNonQuery();

                MessageBox.Show($"¡Registro exitoso!\n\nNúmero de Cliente / Gafete: {nuevoId}",
                                "Sistema de Gimnasio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la pantalla
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
                txtContactoEmergencia.Clear();
                cmbMunicipio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
        }
    }
}
