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
        {
            if (ValidarCampos())
            {
                GuardarRegistroCompleto();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) return MostrarAdvertencia("Ingrese el nombre completo.", txtNombre);
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) return MostrarAdvertencia("Ingrese la dirección.", txtDireccion);
            if (cmbMunicipio.SelectedIndex == -1) return MostrarAdvertencia("Seleccione un municipio.", cmbMunicipio);
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) return MostrarAdvertencia("Ingrese el teléfono.", txtTelefono);
            if (string.IsNullOrWhiteSpace(txtContactoEmergencia.Text)) return MostrarAdvertencia("Ingrese el contacto de emergencia.", txtContactoEmergencia);
            if (string.IsNullOrWhiteSpace(txtCURP.Text)) return MostrarAdvertencia("Ingrese la CURP.", txtCURP);
            if (string.IsNullOrWhiteSpace(txtRFC.Text)) return MostrarAdvertencia("Ingrese el RFC.", txtRFC);
            if (cmbGenero.SelectedIndex == -1) return MostrarAdvertencia("Seleccione un género.", cmbGenero);
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) return MostrarAdvertencia("Ingrese el email.", txtEmail);
            if (string.IsNullOrWhiteSpace(txtColonia.Text)) return MostrarAdvertencia("Ingrese la colonia.", txtColonia);
            if (string.IsNullOrWhiteSpace(txtPeso.Text)) return MostrarAdvertencia("Ingrese el peso.", txtPeso);
            if (cmbTipoSangre.SelectedIndex == -1) return MostrarAdvertencia("Seleccione el tipo de sangre.", cmbTipoSangre);
            if (string.IsNullOrWhiteSpace(txtAlergias.Text)) return MostrarAdvertencia("Ingrese las alergias.", txtAlergias);
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text)) return MostrarAdvertencia("Ingrese la nacionalidad.", txtNacionalidad);
            if (string.IsNullOrWhiteSpace(txtPadecimiento.Text)) return MostrarAdvertencia("Ingrese el padecimiento.", txtPadecimiento);

            return true;
        }

        private bool MostrarAdvertencia(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Campo Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private void GuardarRegistroCompleto()
        {
            ConexionDB baseDatos = new ConexionDB();
            MySqlConnection conexion = baseDatos.AbrirConexion();

            if (conexion == null)
            {
                MessageBox.Show("Error de conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction();

                // FASE 1: Generar ID Automático
                string nuevoId = "00001";
                string queryId = "SELECT MAX(id_cliente) FROM clientes";
                MySqlCommand cmdId = new MySqlCommand(queryId, conexion, transaccion);
                object resultado = cmdId.ExecuteScalar();

                if (resultado != DBNull.Value && resultado != null)
                {
                    int numero = int.Parse(resultado.ToString()) + 1;
                    nuevoId = numero.ToString("D5");
                }

                // FASE 2: Insertar en Tabla Clientes
                string queryInsertCliente = @"INSERT INTO clientes 
                    (id_cliente, nombre, fecha_nacimiento, direccion, municipio, telefono, contacto_emergencia, 
                      curp, rfc, genero, email, colonia, peso, tipo_sangre, alergias, padecimiento)
                    VALUES 
                    (@id, @nom, @fec, @dir, @mun, @tel, @con, @curp, @rfc, @gen, @mail, @col, @peso, @san, @ale, @pad)";

                MySqlCommand cmd = new MySqlCommand(queryInsertCliente, conexion, transaccion);

                cmd.Parameters.AddWithValue("@id", nuevoId);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@fec", dtpFechaNacimiento.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dir", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@mun", cmbMunicipio.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@con", txtContactoEmergencia.Text.Trim());
                cmd.Parameters.AddWithValue("@curp", txtCURP.Text.Trim());
                cmd.Parameters.AddWithValue("@rfc", txtRFC.Text.Trim());
                cmd.Parameters.AddWithValue("@gen", cmbGenero.Text);
                cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@col", txtColonia.Text.Trim());
                cmd.Parameters.AddWithValue("@peso", txtPeso.Text.Trim());
                cmd.Parameters.AddWithValue("@Nacion", txtNacionalidad.Text.Trim());
                cmd.Parameters.AddWithValue("@san", cmbTipoSangre.Text.Trim());
                cmd.Parameters.AddWithValue("@ale", txtAlergias.Text.Trim());
                cmd.Parameters.AddWithValue("@pad", txtPadecimiento.Text.Trim());

                cmd.ExecuteNonQuery();

                // LA FASE 3 SE ELIMINÓ PARA EVITAR EL ERROR DE 'ESTATUS'

                transaccion.Commit();

                MessageBox.Show($"¡Registro exitoso!\nID asignado: {nuevoId}", "Sistema SP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTodo();
            }
            catch (Exception ex)
            {
                if (transaccion != null) transaccion.Rollback();
                MessageBox.Show("Error crítico: " + ex.Message, "Falla de Inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baseDatos.CerrarConexion();
            }
        }

        private void LimpiarTodo()
        {
            txtNombre.Clear(); txtDireccion.Clear(); txtTelefono.Clear();
            txtContactoEmergencia.Clear(); txtCURP.Clear(); txtRFC.Clear();
            txtEmail.Clear(); txtColonia.Clear();
            txtPeso.Clear(); cmbTipoSangre.SelectedIndex = -1; 
            txtAlergias.Clear();
            txtPadecimiento.Clear();
            txtNacionalidad.Clear();
            cmbMunicipio.SelectedIndex = -1;
            cmbGenero.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}