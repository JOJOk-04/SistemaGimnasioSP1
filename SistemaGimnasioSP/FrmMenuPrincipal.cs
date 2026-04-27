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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // =====================================================================
        // EL TRUCO DEL INGENIERO: Método universal para inyectar ventanas
        // =====================================================================
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // 1. Si ya hay una ventana abierta, la quitamos para hacer espacio
            if (this.PanelCentral.Controls.Count > 0)
            {
                this.PanelCentral.Controls.RemoveAt(0);
            }

            // 2. Configuramos la nueva ventana para que se comporte como un panel
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill; // Rellena todo el espacio

            // 3. La agregamos al PanelCentral y la mostramos
            this.PanelCentral.Controls.Add(formularioHijo);
            formularioHijo.Show();
        }

        // =====================================================================
        // CLICS DE LOS BOTONES DEL MENÚ
        // =====================================================================

        // BOTÓN 1: REGISTRO
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // Llamamos a tu ventana de registro que ya programamos
            AbrirFormularioHijo(new FrmRegistro());
        }

        // BOTÓN 2: CONSULTAR USUARIO
        private void btnConsultar_Click(object sender, EventArgs e)
        {
           
           AbrirFormularioHijo(new FrmConsultas());
        }

        // BOTÓN 3: TESORERÍA / COBROS
        private void btnCobros_Click(object sender, EventArgs e)
        {
             AbrirFormularioHijo(new FrmCobros());
        }

        // BOTÓN 4: CERRAR SESIÓN
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro que deseas salir del sistema?",
                                                     "Cerrar Sesión",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                // Cierra la aplicación por completo
                Application.Exit();
            }
        }

        // =====================================================================
        // MÉTODOS DE SEGURIDAD (Eventos vacíos para que no llore el diseñador)
        // =====================================================================
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}