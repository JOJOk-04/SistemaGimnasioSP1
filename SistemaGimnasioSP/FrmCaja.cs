using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGimnasioSP
{
    public partial class FrmCaja : Form
    {
        public decimal TotalAPagar { get; set; }
        // ✨ Ahora guardamos el motivo exacto en lugar de solo un Verdadero/Falso
        public string TipoAutorizacion { get; set; } = "Ninguno";
        // 1. Agrega esta propiedad arriba, junto a TipoAutorizacion
        public string UsuarioAutorizo { get; set; } = ""; // ✨ NUEVO: Guarda el nombre real (Ej. "Joha Guevara")


        public FrmCaja(decimal total)
        {
            InitializeComponent();
            TotalAPagar = total;
            lblTotal.Text = $"TOTAL: {TotalAPagar:C}";
            btnConfirmar.Enabled = false; // Desactivado hasta que metan dinero suficiente
        }

        // Evento: Dar doble clic al txtEfectivo para crear el evento TextChanged
        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            decimal efectivo = 0;
            decimal.TryParse(txtEfectivo.Text, out efectivo);

            decimal cambio = efectivo - TotalAPagar;

            if (cambio >= 0)
            {
                lblCambio.Text = $"Cambio a entregar: {cambio:C}";
                lblCambio.ForeColor = System.Drawing.Color.Green;
                btnConfirmar.Enabled = true; // Ya pagó completo
            }
            else
            {
                lblCambio.Text = $"Faltan: {Math.Abs(cambio):C}";
                lblCambio.ForeColor = System.Drawing.Color.Red;
                btnConfirmar.Enabled = false; // Le falta lana
            }
        }

        // Evento del Botón Beca / Servidor Público
        // =========================================================
        // FUNCIÓN NUEVA: Crea una ventanita bonita con asteriscos
        // =========================================================
        private string PedirContrasenaConAsteriscos()
        {
            Form ventanita = new Form()
            {
                Width = 350,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Autorización Especial",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label etiqueta = new Label() { Left = 20, Top = 20, Text = "Ingrese contraseña de gerente/cajero:", Width = 300 };

            // ✨ LA MAGIA DE LOS ASTERISCOS ESTÁ AQUÍ ✨
            TextBox cajaTexto = new TextBox() { Left = 20, Top = 50, Width = 290, PasswordChar = '*' };

            Button btnConfirmar = new Button() { Text = "Autorizar", Left = 190, Width = 120, Top = 80, DialogResult = DialogResult.OK };

            ventanita.Controls.Add(etiqueta);
            ventanita.Controls.Add(cajaTexto);
            ventanita.Controls.Add(btnConfirmar);
            ventanita.AcceptButton = btnConfirmar; // Permite darle "Enter" para aceptar

            return ventanita.ShowDialog() == DialogResult.OK ? cajaTexto.Text.Trim() : "";
        }
        private bool EsPasswordDeGerente(string passwordIngresada)
        {
            bool esValido = false;
            ConexionDB miBD = new ConexionDB();
            MySqlConnection conn = miBD.AbrirConexion();

            if (conn != null)
            {
                try
                {
                    // Traemos TODOS los hashes de los que sean Gerentes y estén Activos
                    string query = "SELECT contrasena FROM Usuarios WHERE rol = 'Gerente' AND estatus = 'Activo'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string hashGuardado = reader["contrasena"].ToString();

                                // Si la contraseña ingresada coincide con el hash de algún gerente...
                                if (BCrypt.Net.BCrypt.Verify(passwordIngresada, hashGuardado))
                                {
                                    esValido = true;
                                    break; // ¡Bingo! Encontramos a un gerente, detenemos la búsqueda
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar gerente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    miBD.CerrarConexion();
                }
            }
            return esValido; // Retorna true si era de un gerente, o false si se equivocó
        }
        // =========================================================
        // TU BOTÓN DE BECA ACTUALIZADO
        // =========================================================
        // =========================================================
        // MÉTODO CENTRAL DE AUTORIZACIÓN
        // =========================================================
        private void AutorizarDescuento(string tipoDescuento)
        {
            string passwordIngresada = PedirContrasenaConAsteriscos();

            if (string.IsNullOrWhiteSpace(passwordIngresada)) return;

            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();

            if (conexion != null)
            {
                try
                {
                    // ✨ TRAEMOS EL NOMBRE: Buscamos el nombre del empleado dueño de esa clave
                    string query = "SELECT nombre_completo FROM usuarios WHERE contrasena = @pass LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@pass", passwordIngresada);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        string nombreEmpleado = resultado.ToString();

                        MessageBox.Show($"{tipoDescuento} autorizado por {nombreEmpleado}. El cobro será de $0.00", "Autorización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TipoAutorizacion = tipoDescuento;
                        UsuarioAutorizo = nombreEmpleado; // ✨ Guardamos el nombre para el ticket

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta o usuario no encontrado. Se denegó la operación.", "🚨 Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error de seguridad: " + ex.Message); }
                finally { bd.CerrarConexion(); }
            }
        }

        // =========================================================
        // EVENTOS DE TUS DOS BOTONES
        // =========================================================
        private void btnBeca_Click(object sender, EventArgs e)
        {
            AutorizarDescuento("Becado");
        }

        private void btnColaborador_Click(object sender, EventArgs e)
        {
            AutorizarDescuento("Colaborador");
        }

        // Evento del Botón Confirmar Pago Normal
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
