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

        private void Button1_Click(object sender, EventArgs e)
        {
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null) return;

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

                // ---------------------------------------------------------
                // FASE 2: Insertar datos en tabla Clientes (Sin estatus)
                // ---------------------------------------------------------
                string queryInsert = @"INSERT INTO Clientes 
            (id_cliente, nombre, fecha_nacimiento, direccion, municipio, telefono, contacto_emergencia) 
            VALUES (@id, @nombre, @fecha, @direccion, @municipio, @telefono, @contacto)";

                // CORRECCIÓN: Creamos correctamente el comando cmdInsert
                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion, transaccion);

                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim()); // Trim quita espacios vacíos al inicio/final
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text.Trim());

                // CORRECCIÓN: Ejecutamos el insert de Clientes
                cmdInsert.ExecuteNonQuery();

                // ---------------------------------------------------------
                // FASE 3: Insertar estatus inicial en tabla Inscripciones
                // ---------------------------------------------------------
                // CORRECCIÓN: Creamos correctamente las variables para Inscripciones
                string queryInscripcion = @"INSERT INTO Inscripciones (id_cliente, estatus, fecha_inicio) 
                                            VALUES (@id, 'Inactivo', NOW())";

                MySqlCommand cmdInscripcion = new MySqlCommand(queryInscripcion, conexion, transaccion);
                cmdInscripcion.Parameters.AddWithValue("@id", nuevoId);

                // CORRECCIÓN: Ejecutamos el insert de Inscripciones
                cmdInscripcion.ExecuteNonQuery();

                // Si llegamos aquí sin errores, guardamos los cambios permanentemente
                transaccion.Commit();

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
                // Si algo falla, deshacemos todo
                transaccion.Rollback();
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
        }

        // Métodos requeridos por el diseñador (no borrar)
        private void Label1_Click(object sender, EventArgs e) { }
        private void Label2_Click(object sender, EventArgs e) { }
        private void Label5_Click(object sender, EventArgs e) { }
        private void Label6_Click(object sender, EventArgs e) { }
        private void Label7_Click(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }
        private void FrmRegistro_Load(object sender, EventArgs e) { }
    }
}