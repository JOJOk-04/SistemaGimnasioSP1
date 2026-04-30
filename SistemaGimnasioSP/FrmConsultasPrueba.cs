using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace SistemaGimnasioSP
{
    public partial class FrmConsultasPrueba : Form
    {
        public FrmConsultasPrueba()
        {
            InitializeComponent();
        }

        // === ESTE ES EL EVENTO QUE CORRIGE EL DISEÑO ===
        // Se ejecuta justo antes de que el formulario se muestre
        private void FrmPruebaTesoreria_Load(object sender, EventArgs e)
        {
            // Ojo: Asegúrate de que 'tabMenuTesoreria' sea el nombre de tu control principal
            if (tabMenuTesoreria != null)
            {
                // 1. Alineación arriba
                tabMenuTesoreria.Alignment = TabAlignment.Top;

                // 2. Cálculo del ancho
                this.ResumeLayout(true);
                int numeroDePestañas = 5;
                if (tabMenuTesoreria.TabPages.Count > 0)
                {
                    numeroDePestañas = tabMenuTesoreria.TabPages.Count;
                }

                int anchoPorPestaña = (tabMenuTesoreria.Width / numeroDePestañas) - 2;

                // 3. Aplicar el tamaño para que no se encimen
                tabMenuTesoreria.ItemSize = new Size(anchoPorPestaña, 60);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAcondicionamiento_Click(object sender, EventArgs e)
        {
        }

        private void btnRitmos_Click(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void btnRitmos_Click_1(object sender, EventArgs e)
        {
        }

        private void btnTaekwondo_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPagar_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void btnLigasdeFutbol_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
