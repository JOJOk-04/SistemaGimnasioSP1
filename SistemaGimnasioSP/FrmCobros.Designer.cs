namespace SistemaGimnasioSP
{
    partial class FrmCobros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCobros));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.txtBusquedaId = new System.Windows.Forms.TextBox();
            this.BtnRegistrarPago = new System.Windows.Forms.Button();
            this.gbDeportes = new System.Windows.Forms.GroupBox();
            this.btnRitmos = new System.Windows.Forms.Button();
            this.Heterofilia = new System.Windows.Forms.Button();
            this.btnTaekwondo = new System.Windows.Forms.Button();
            this.btnFutbol = new System.Windows.Forms.Button();
            this.btnAcondicionamiento = new System.Windows.Forms.Button();
            this.gbPaquetes = new System.Windows.Forms.GroupBox();
            this.btnPaquetef2 = new System.Windows.Forms.Button();
            this.btnPaquetef1 = new System.Windows.Forms.Button();
            this.gbLigasDeportivas = new System.Windows.Forms.GroupBox();
            this.btnEquipoSoftball = new System.Windows.Forms.Button();
            this.btnLigasdeFutbol = new System.Windows.Forms.Button();
            this.btnMensualidad = new System.Windows.Forms.Button();
            this.gbCampamento = new System.Windows.Forms.GroupBox();
            this.btnAgregarHno = new System.Windows.Forms.Button();
            this.btnCampamento = new System.Windows.Forms.Button();
            this.gbAlbercaPublica = new System.Windows.Forms.GroupBox();
            this.btnAdulto = new System.Windows.Forms.Button();
            this.btnNiño = new System.Windows.Forms.Button();
            this.gbDeportes.SuspendLayout();
            this.gbPaquetes.SuspendLayout();
            this.gbLigasDeportivas.SuspendLayout();
            this.gbCampamento.SuspendLayout();
            this.gbAlbercaPublica.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(539, 172);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 43);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del Cliente";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(718, 71);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(718, 124);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(51, 20);
            this.lblEdad.TabIndex = 3;
            this.lblEdad.Text = "Edad:";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(718, 195);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(79, 20);
            this.lblMunicipio.TabIndex = 4;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Location = new System.Drawing.Point(210, 1007);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(103, 20);
            this.lblTotalPagar.TabIndex = 5;
            this.lblTotalPagar.Text = "Total a Pagar";
            // 
            // txtBusquedaId
            // 
            this.txtBusquedaId.Location = new System.Drawing.Point(214, 172);
            this.txtBusquedaId.Name = "txtBusquedaId";
            this.txtBusquedaId.Size = new System.Drawing.Size(265, 26);
            this.txtBusquedaId.TabIndex = 6;
            this.txtBusquedaId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaId_KeyDown);
            // 
            // BtnRegistrarPago
            // 
            this.BtnRegistrarPago.Location = new System.Drawing.Point(760, 969);
            this.BtnRegistrarPago.Name = "BtnRegistrarPago";
            this.BtnRegistrarPago.Size = new System.Drawing.Size(485, 96);
            this.BtnRegistrarPago.TabIndex = 7;
            this.BtnRegistrarPago.Text = "Registrar Pago";
            this.BtnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // gbDeportes
            // 
            this.gbDeportes.BackColor = System.Drawing.Color.Transparent;
            this.gbDeportes.Controls.Add(this.btnRitmos);
            this.gbDeportes.Controls.Add(this.Heterofilia);
            this.gbDeportes.Controls.Add(this.btnTaekwondo);
            this.gbDeportes.Controls.Add(this.btnFutbol);
            this.gbDeportes.Controls.Add(this.btnAcondicionamiento);
            this.gbDeportes.Location = new System.Drawing.Point(87, 349);
            this.gbDeportes.Name = "gbDeportes";
            this.gbDeportes.Size = new System.Drawing.Size(564, 327);
            this.gbDeportes.TabIndex = 8;
            this.gbDeportes.TabStop = false;
            this.gbDeportes.Text = "Deportes";
            // 
            // btnRitmos
            // 
            this.btnRitmos.Location = new System.Drawing.Point(286, 216);
            this.btnRitmos.Name = "btnRitmos";
            this.btnRitmos.Size = new System.Drawing.Size(172, 78);
            this.btnRitmos.TabIndex = 4;
            this.btnRitmos.Text = "Ritmos Latinos\r\nCardio Dance";
            this.btnRitmos.UseVisualStyleBackColor = true;
            this.btnRitmos.Click += new System.EventHandler(this.btnRitmos_Click);
            // 
            // Heterofilia
            // 
            this.Heterofilia.Location = new System.Drawing.Point(103, 216);
            this.Heterofilia.Name = "Heterofilia";
            this.Heterofilia.Size = new System.Drawing.Size(160, 78);
            this.Heterofilia.TabIndex = 3;
            this.Heterofilia.Text = "Heterofilia";
            this.Heterofilia.UseVisualStyleBackColor = true;
            this.Heterofilia.Click += new System.EventHandler(this.Heterofilia_Click);
            // 
            // btnTaekwondo
            // 
            this.btnTaekwondo.Location = new System.Drawing.Point(382, 59);
            this.btnTaekwondo.Name = "btnTaekwondo";
            this.btnTaekwondo.Size = new System.Drawing.Size(155, 94);
            this.btnTaekwondo.TabIndex = 2;
            this.btnTaekwondo.Text = "Taekwondo";
            this.btnTaekwondo.UseVisualStyleBackColor = true;
            this.btnTaekwondo.Click += new System.EventHandler(this.btnTaekwondo_Click);
            // 
            // btnFutbol
            // 
            this.btnFutbol.Location = new System.Drawing.Point(200, 59);
            this.btnFutbol.Name = "btnFutbol";
            this.btnFutbol.Size = new System.Drawing.Size(158, 94);
            this.btnFutbol.TabIndex = 1;
            this.btnFutbol.Text = "Futbol";
            this.btnFutbol.UseVisualStyleBackColor = true;
            this.btnFutbol.Click += new System.EventHandler(this.btnFutbol_Click);
            // 
            // btnAcondicionamiento
            // 
            this.btnAcondicionamiento.Location = new System.Drawing.Point(18, 59);
            this.btnAcondicionamiento.Name = "btnAcondicionamiento";
            this.btnAcondicionamiento.Size = new System.Drawing.Size(162, 94);
            this.btnAcondicionamiento.TabIndex = 0;
            this.btnAcondicionamiento.Text = "Acondicionamiento Fisico";
            this.btnAcondicionamiento.UseVisualStyleBackColor = true;
            this.btnAcondicionamiento.Click += new System.EventHandler(this.btnAcondicionamiento_Click);
            // 
            // gbPaquetes
            // 
            this.gbPaquetes.BackColor = System.Drawing.Color.Transparent;
            this.gbPaquetes.Controls.Add(this.btnPaquetef2);
            this.gbPaquetes.Controls.Add(this.btnPaquetef1);
            this.gbPaquetes.Location = new System.Drawing.Point(718, 349);
            this.gbPaquetes.Name = "gbPaquetes";
            this.gbPaquetes.Size = new System.Drawing.Size(564, 327);
            this.gbPaquetes.TabIndex = 9;
            this.gbPaquetes.TabStop = false;
            this.gbPaquetes.Text = "Paquetes";
            // 
            // btnPaquetef2
            // 
            this.btnPaquetef2.Location = new System.Drawing.Point(333, 36);
            this.btnPaquetef2.Name = "btnPaquetef2";
            this.btnPaquetef2.Size = new System.Drawing.Size(180, 117);
            this.btnPaquetef2.TabIndex = 2;
            this.btnPaquetef2.Text = "Paquete Familiar\r\n(3 a 5 personas) ";
            this.btnPaquetef2.UseVisualStyleBackColor = true;
            // 
            // btnPaquetef1
            // 
            this.btnPaquetef1.Location = new System.Drawing.Point(42, 36);
            this.btnPaquetef1.Name = "btnPaquetef1";
            this.btnPaquetef1.Size = new System.Drawing.Size(189, 117);
            this.btnPaquetef1.TabIndex = 1;
            this.btnPaquetef1.Text = "Paquete Familiar\r\n(2 personas)";
            this.btnPaquetef1.UseVisualStyleBackColor = true;
            // 
            // gbLigasDeportivas
            // 
            this.gbLigasDeportivas.BackColor = System.Drawing.Color.Transparent;
            this.gbLigasDeportivas.Controls.Add(this.btnEquipoSoftball);
            this.gbLigasDeportivas.Controls.Add(this.btnLigasdeFutbol);
            this.gbLigasDeportivas.Location = new System.Drawing.Point(87, 760);
            this.gbLigasDeportivas.Name = "gbLigasDeportivas";
            this.gbLigasDeportivas.Size = new System.Drawing.Size(368, 163);
            this.gbLigasDeportivas.TabIndex = 9;
            this.gbLigasDeportivas.TabStop = false;
            this.gbLigasDeportivas.Text = "Ligas Deportivas";
            // 
            // btnEquipoSoftball
            // 
            this.btnEquipoSoftball.Location = new System.Drawing.Point(179, 40);
            this.btnEquipoSoftball.Name = "btnEquipoSoftball";
            this.btnEquipoSoftball.Size = new System.Drawing.Size(163, 93);
            this.btnEquipoSoftball.TabIndex = 1;
            this.btnEquipoSoftball.Text = "Inscripcion de equipo\r\nSoftball\r\n";
            this.btnEquipoSoftball.UseVisualStyleBackColor = true;
            // 
            // btnLigasdeFutbol
            // 
            this.btnLigasdeFutbol.Location = new System.Drawing.Point(23, 40);
            this.btnLigasdeFutbol.Name = "btnLigasdeFutbol";
            this.btnLigasdeFutbol.Size = new System.Drawing.Size(150, 93);
            this.btnLigasdeFutbol.TabIndex = 0;
            this.btnLigasdeFutbol.Text = "Inscripcion de equipo\r\nLIga de Futbol\r\n";
            this.btnLigasdeFutbol.UseVisualStyleBackColor = true;
            // 
            // btnMensualidad
            // 
            this.btnMensualidad.Location = new System.Drawing.Point(565, 253);
            this.btnMensualidad.Name = "btnMensualidad";
            this.btnMensualidad.Size = new System.Drawing.Size(133, 44);
            this.btnMensualidad.TabIndex = 10;
            this.btnMensualidad.Text = "Mensualidad";
            this.btnMensualidad.UseVisualStyleBackColor = true;
            // 
            // gbCampamento
            // 
            this.gbCampamento.BackColor = System.Drawing.Color.Transparent;
            this.gbCampamento.Controls.Add(this.btnAgregarHno);
            this.gbCampamento.Controls.Add(this.btnCampamento);
            this.gbCampamento.Location = new System.Drawing.Point(493, 760);
            this.gbCampamento.Name = "gbCampamento";
            this.gbCampamento.Size = new System.Drawing.Size(426, 163);
            this.gbCampamento.TabIndex = 10;
            this.gbCampamento.TabStop = false;
            this.gbCampamento.Text = "Campamento de Verano";
            // 
            // btnAgregarHno
            // 
            this.btnAgregarHno.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarHno.Location = new System.Drawing.Point(209, 47);
            this.btnAgregarHno.Name = "btnAgregarHno";
            this.btnAgregarHno.Size = new System.Drawing.Size(196, 79);
            this.btnAgregarHno.TabIndex = 6;
            this.btnAgregarHno.Text = "Agregar Hermano \r\na \r\nCampamento de Verano ";
            this.btnAgregarHno.UseVisualStyleBackColor = false;
            // 
            // btnCampamento
            // 
            this.btnCampamento.Location = new System.Drawing.Point(31, 47);
            this.btnCampamento.Name = "btnCampamento";
            this.btnCampamento.Size = new System.Drawing.Size(136, 79);
            this.btnCampamento.TabIndex = 2;
            this.btnCampamento.Text = "Campamento de Verano";
            this.btnCampamento.UseVisualStyleBackColor = true;
            // 
            // gbAlbercaPublica
            // 
            this.gbAlbercaPublica.BackColor = System.Drawing.Color.Transparent;
            this.gbAlbercaPublica.Controls.Add(this.btnAdulto);
            this.gbAlbercaPublica.Controls.Add(this.btnNiño);
            this.gbAlbercaPublica.Location = new System.Drawing.Point(954, 760);
            this.gbAlbercaPublica.Name = "gbAlbercaPublica";
            this.gbAlbercaPublica.Size = new System.Drawing.Size(369, 163);
            this.gbAlbercaPublica.TabIndex = 11;
            this.gbAlbercaPublica.TabStop = false;
            this.gbAlbercaPublica.Text = "Alberca Publica (Marzo - Agosto)";
            // 
            // btnAdulto
            // 
            this.btnAdulto.BackColor = System.Drawing.Color.Transparent;
            this.btnAdulto.Location = new System.Drawing.Point(179, 45);
            this.btnAdulto.Name = "btnAdulto";
            this.btnAdulto.Size = new System.Drawing.Size(142, 57);
            this.btnAdulto.TabIndex = 6;
            this.btnAdulto.Text = "Adulto";
            this.btnAdulto.UseVisualStyleBackColor = false;
            // 
            // btnNiño
            // 
            this.btnNiño.Location = new System.Drawing.Point(18, 45);
            this.btnNiño.Name = "btnNiño";
            this.btnNiño.Size = new System.Drawing.Size(138, 57);
            this.btnNiño.TabIndex = 2;
            this.btnNiño.Text = "Niño";
            this.btnNiño.UseVisualStyleBackColor = true;
            // 
            // FrmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 1110);
            this.Controls.Add(this.gbAlbercaPublica);
            this.Controls.Add(this.gbCampamento);
            this.Controls.Add(this.btnMensualidad);
            this.Controls.Add(this.gbLigasDeportivas);
            this.Controls.Add(this.gbPaquetes);
            this.Controls.Add(this.gbDeportes);
            this.Controls.Add(this.BtnRegistrarPago);
            this.Controls.Add(this.txtBusquedaId);
            this.Controls.Add(this.lblTotalPagar);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCobros";
            this.Text = "FrmCobro";
            this.gbDeportes.ResumeLayout(false);
            this.gbPaquetes.ResumeLayout(false);
            this.gbLigasDeportivas.ResumeLayout(false);
            this.gbCampamento.ResumeLayout(false);
            this.gbAlbercaPublica.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.TextBox txtBusquedaId;
        private System.Windows.Forms.Button BtnRegistrarPago;
        private System.Windows.Forms.GroupBox gbDeportes;
        private System.Windows.Forms.GroupBox gbPaquetes;
        private System.Windows.Forms.Button btnRitmos;
        private System.Windows.Forms.Button Heterofilia;
        private System.Windows.Forms.Button btnTaekwondo;
        private System.Windows.Forms.Button btnFutbol;
        private System.Windows.Forms.Button btnAcondicionamiento;
        private System.Windows.Forms.Button btnPaquetef2;
        private System.Windows.Forms.Button btnPaquetef1;
        private System.Windows.Forms.GroupBox gbLigasDeportivas;
        private System.Windows.Forms.Button btnEquipoSoftball;
        private System.Windows.Forms.Button btnLigasdeFutbol;
        private System.Windows.Forms.Button btnMensualidad;
        private System.Windows.Forms.GroupBox gbCampamento;
        private System.Windows.Forms.Button btnAgregarHno;
        private System.Windows.Forms.Button btnCampamento;
        private System.Windows.Forms.GroupBox gbAlbercaPublica;
        private System.Windows.Forms.Button btnAdulto;
        private System.Windows.Forms.Button btnNiño;
    }
}