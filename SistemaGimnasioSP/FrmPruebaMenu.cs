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
    public partial class FrmPruebaMenu : Form
    {
        public FrmPruebaMenu()
        {
            InitializeComponent();
            // Iniciamos maximizado para aprovechar el espacio
            this.WindowState = FormWindowState.Maximized;
        }

        // =====================================================================
        // MÉTODO DE INYECCIÓN (Asegúrate de que el panel se llame PanelCentral)
        // =====================================================================
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // 1. Limpiamos el panel de cualquier control o formulario previo
            if (this.PanelCentral.Controls.Count > 0)
            {
                // Usamos una lista temporal para evitar errores al modificar la colección mientras se recorre
                Control controlAnterior = this.PanelCentral.Controls[0];
                if (controlAnterior is Form frmAnterior)
                {
                    frmAnterior.Close();
                    frmAnterior.Dispose();
                }
                this.PanelCentral.Controls.Clear();
            }

            // 2. Configuramos el nuevo formulario hijo
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // 3. Lo agregamos al panel y lo mostramos
            this.PanelCentral.Controls.Add(formularioHijo);
            this.PanelCentral.Tag = formularioHijo;
            formularioHijo.Show();
        }

        // =====================================================================
        // BOTONES DEL MENÚ (Asegúrate de que los eventos Click estén vinculados)
        // =====================================================================

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRegistro());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmConsultas());
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmPruebaCobros());
        }

        private void BtnAfluencias_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmAfluencia());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmCortes());
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro que deseas salir del sistema?",
                                                     "Cerrar Sesión",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // =====================================================================
        // ESTÉTICA DEL TEXTBOX (Evitar el cursor parpadeante)
        // =====================================================================
        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            // Quita el foco del TextBox para que no se vea el cursor
            this.ActiveControl = null;
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}