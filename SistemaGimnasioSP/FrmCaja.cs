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
        public bool EsBecaAutorizada { get; set; } = false;

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
        private void btnBeca_Click(object sender, EventArgs e)
        {
            // Pedimos la contraseña al cajero
            string password = Interaction.InputBox("Autorización requerida. Ingrese su contraseña de cajero/gerente:", "Autorización de Beca", "", -1, -1);

            if (string.IsNullOrWhiteSpace(password)) return;

            // Verificamos en BD si la contraseña existe (Ajusta la tabla y columna a las tuyas)
            ConexionDB bd = new ConexionDB();
            MySqlConnection conexion = bd.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM usuarios WHERE contraseña = @pass";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@pass", password);
                    int autorizado = Convert.ToInt32(cmd.ExecuteScalar());

                    if (autorizado > 0)
                    {
                        MessageBox.Show("Beca autorizada correctamente. El cobro será de $0.00", "Autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EsBecaAutorizada = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta. Se denegó la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally { bd.CerrarConexion(); }
            }
        }

        // Evento del Botón Confirmar Pago Normal
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
    }
}
