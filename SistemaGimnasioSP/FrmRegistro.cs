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
            // 1. Creamos el objeto de tu clase ConexionDB
            ConexionDB baseDatos = new ConexionDB();

            // 2. Usamos tu método exacto para abrir la puerta a MySQL
            MySqlConnection conexion = baseDatos.AbrirConexion();

            // Si la conexión devolvió "null" (ej. si olvidaste prender XAMPP/MySQL), 
            // detenemos el guardado aquí mismo para que el programa no explote.
            if (conexion == null)
            {
                return;
            }

            try
            {
                // ---------------------------------------------------------
                // FASE 1: Generar el ID Numérico Automático (Ej. 00001)
                // ---------------------------------------------------------
                string nuevoId = "00001";
                string queryId = "SELECT MAX(id_cliente) FROM Clientes";
                MySqlCommand cmdId = new MySqlCommand(queryId, conexion);
                object resultado = cmdId.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    int numero = int.Parse(resultado.ToString()) + 1;
                    nuevoId = numero.ToString("D5"); // Formato de 5 dígitos
                }

                // ---------------------------------------------------------
                // FASE 2: Insertar datos a MySQL
                // ---------------------------------------------------------
                string queryInsert = @"INSERT INTO Clientes 
            (id_cliente, nombre, fecha_nacimiento, direccion, municipio, telefono, contacto_emergencia, estatus) 
            VALUES (@id, @nombre, @fecha, @direccion, @municipio, @telefono, @contacto, 'Inactivo')";

                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion);

                // Asignamos las variables de tu diseño
                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text);

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
                // 3. Usamos tu método exacto para cerrar la conexión limpiamente
                baseDatos.CerrarConexion();
            }
        }

        // =========================================================================
        // MÉTODOS DE SEGURIDAD (No los borres para evitar que se caiga el diseñador)
        // =========================================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void FmrRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
