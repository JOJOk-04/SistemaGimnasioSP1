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

namespace SistemaGimnasioSP
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("Por favor, ingrese al menos el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null) return;

            // Iniciamos una transacción para asegurar la integridad de los datos en ambas tablas
            MySqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                // ---------------------------------------------------------
                // FASE 1: Generar el ID Numérico Automático (Ej. 00001)
                // ---------------------------------------------------------
                string nuevoId = "00001";
                string queryId = "SELECT MAX(CAST(id_cliente AS UNSIGNED)) FROM Clientes";
                MySqlCommand cmdId = new MySqlCommand(queryId, conexion, transaccion);
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

                MySqlCommand cmdInscripcion = new MySqlCommand(queryInscripcion, conexion, transaccion);
                cmdInscripcion.Parameters.AddWithValue("@id", nuevoId);

                // Asignamos las variables de tu diseño
                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text);

                // Si llegamos aquí sin errores, guardamos los cambios permanentemente
                transaccion.Commit();

                MessageBox.Show($"¡Registro exitoso!\n\nID Cliente: {nuevoId}\nEstatus inicial: Inactivo",
                                "Sistema de Gimnasio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Si algo falla (ej. falta una columna), deshacemos todo
                transaccion.Rollback();
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtContactoEmergencia.Clear();
            if (cmbMunicipio.Items.Count > 0) cmbMunicipio.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            txtNombre.Focus();
        }

        // Métodos requeridos por el diseñador (no borrar)
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void FmrRegistro_Load(object sender, EventArgs e) { }
    }
}