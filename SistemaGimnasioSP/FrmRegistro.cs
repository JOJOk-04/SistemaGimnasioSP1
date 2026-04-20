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
            // 1. Validar que al menos el nombre esté lleno antes de hacer nada
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese al menos el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Crear objeto y abrir la conexión
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            // Si la conexión falla (ej. si olvidaste encender el servicio de MySQL en tu laptop)
            if (conexion == null)
            {
                MessageBox.Show("Error al conectar con la base de datos. Verifica que el servicio MySQL esté encendido.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Declaramos la transacción fuera del try para poder acceder a ella en el catch
            MySqlTransaction transaccion = null;

            try
            {
                // Iniciar la transacción de manera oficial
                transaccion = conexion.BeginTransaction();

                // ---------------------------------------------------------
                // FASE 1: Generar el ID Numérico Automático
                // ---------------------------------------------------------
                string nuevoId = "00001";
                string queryId = "SELECT MAX(id_cliente) FROM Clientes";

                // Le pasamos la conexión y la transacción al comando
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
                    VALUES (@id, @nombre, @fecha, @direccion, @municipio, @telefono, @contacto)"; //'Inactivo' se eliminó de esta línea

                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexion, transaccion);

                cmdInsert.Parameters.AddWithValue("@id", nuevoId);
                cmdInsert.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@municipio", cmbMunicipio.Text);
                cmdInsert.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@contacto", txtContactoEmergencia.Text.Trim());

                // EJECUTAR EL COMANDO (Esta línea faltaba en tu código original)
                cmdInsert.ExecuteNonQuery();

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
                // Si algo falla, deshacemos todo para no dejar datos a medias
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
                MessageBox.Show("Error crítico al guardar: " + ex.Message, "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Siempre asegurarnos de cerrar la conexión
                baseDatos.CerrarConexion();
            }
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