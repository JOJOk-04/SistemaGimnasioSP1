namespace SistemaGimnasioSP
{
    partial class FrmPaquetes
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
            this.gbDeportes = new System.Windows.Forms.GroupBox();
            this.btnRitmos = new System.Windows.Forms.Button();
            this.btnHeterofilia = new System.Windows.Forms.Button();
            this.btnTaekwondo = new System.Windows.Forms.Button();
            this.btnFutbol = new System.Windows.Forms.Button();
            this.btnAcondicionamiento = new System.Windows.Forms.Button();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMiembros = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDeportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDeportes
            // 
            this.gbDeportes.BackColor = System.Drawing.Color.Transparent;
            this.gbDeportes.Controls.Add(this.btnRitmos);
            this.gbDeportes.Controls.Add(this.btnHeterofilia);
            this.gbDeportes.Controls.Add(this.btnTaekwondo);
            this.gbDeportes.Controls.Add(this.btnFutbol);
            this.gbDeportes.Controls.Add(this.btnAcondicionamiento);
            this.gbDeportes.Location = new System.Drawing.Point(55, 299);
            this.gbDeportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeportes.Name = "gbDeportes";
            this.gbDeportes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeportes.Size = new System.Drawing.Size(1200, 328);
            this.gbDeportes.TabIndex = 17;
            this.gbDeportes.TabStop = false;
            this.gbDeportes.Text = "Deportes";
            // 
            // btnRitmos
            // 
            this.btnRitmos.Location = new System.Drawing.Point(635, 207);
            this.btnRitmos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRitmos.Name = "btnRitmos";
            this.btnRitmos.Size = new System.Drawing.Size(389, 78);
            this.btnRitmos.TabIndex = 4;
            this.btnRitmos.Text = "Ritmos Latinos\r\nCardio Dance";
            this.btnRitmos.UseVisualStyleBackColor = true;
            this.btnRitmos.Click += new System.EventHandler(this.btnRitmos_Click);
            // 
            // btnHeterofilia
            // 
            this.btnHeterofilia.Location = new System.Drawing.Point(192, 207);
            this.btnHeterofilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHeterofilia.Name = "btnHeterofilia";
            this.btnHeterofilia.Size = new System.Drawing.Size(377, 78);
            this.btnHeterofilia.TabIndex = 3;
            this.btnHeterofilia.Text = "Heterofilia";
            this.btnHeterofilia.UseVisualStyleBackColor = true;
            this.btnHeterofilia.Click += new System.EventHandler(this.btnHeterofilia_Click);
            // 
            // btnTaekwondo
            // 
            this.btnTaekwondo.Location = new System.Drawing.Point(806, 59);
            this.btnTaekwondo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaekwondo.Name = "btnTaekwondo";
            this.btnTaekwondo.Size = new System.Drawing.Size(372, 94);
            this.btnTaekwondo.TabIndex = 2;
            this.btnTaekwondo.Text = "Taekwondo";
            this.btnTaekwondo.UseVisualStyleBackColor = true;
            this.btnTaekwondo.Click += new System.EventHandler(this.btnTaekwondo_Click);
            // 
            // btnFutbol
            // 
            this.btnFutbol.Location = new System.Drawing.Point(415, 59);
            this.btnFutbol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFutbol.Name = "btnFutbol";
            this.btnFutbol.Size = new System.Drawing.Size(375, 94);
            this.btnFutbol.TabIndex = 1;
            this.btnFutbol.Text = "Futbol";
            this.btnFutbol.UseVisualStyleBackColor = true;
            this.btnFutbol.Click += new System.EventHandler(this.btnFutbol_Click);
            // 
            // btnAcondicionamiento
            // 
            this.btnAcondicionamiento.Location = new System.Drawing.Point(21, 59);
            this.btnAcondicionamiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcondicionamiento.Name = "btnAcondicionamiento";
            this.btnAcondicionamiento.Size = new System.Drawing.Size(379, 94);
            this.btnAcondicionamiento.TabIndex = 0;
            this.btnAcondicionamiento.Text = "Acondicionamiento Fisico";
            this.btnAcondicionamiento.UseVisualStyleBackColor = true;
            this.btnAcondicionamiento.Click += new System.EventHandler(this.btnAcondicionamiento_Click);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(747, 184);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(79, 20);
            this.lblMunicipio.TabIndex = 15;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(747, 113);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(51, 20);
            this.lblEdad.TabIndex = 14;
            this.lblEdad.Text = "Edad:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(747, 46);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccionar Integrante";
            // 
            // cmbMiembros
            // 
            this.cmbMiembros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMiembros.FormattingEnabled = true;
            this.cmbMiembros.Location = new System.Drawing.Point(222, 133);
            this.cmbMiembros.Name = "cmbMiembros";
            this.cmbMiembros.Size = new System.Drawing.Size(340, 28);
            this.cmbMiembros.Sorted = true;
            this.cmbMiembros.TabIndex = 20;
            this.cmbMiembros.SelectedIndexChanged += new System.EventHandler(this.cmbMiembros_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 698);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 74);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnGuardar.Location = new System.Drawing.Point(842, 679);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(314, 112);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 842);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbMiembros);
            this.Controls.Add(this.gbDeportes);
            this.Controls.Add(this.lblMunicipio);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmPaquetes";
            this.Text = "FrmPaquetes";
            this.gbDeportes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbDeportes;
        private System.Windows.Forms.Button btnRitmos;
        private System.Windows.Forms.Button btnHeterofilia;
        private System.Windows.Forms.Button btnTaekwondo;
        private System.Windows.Forms.Button btnFutbol;
        private System.Windows.Forms.Button btnAcondicionamiento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMiembros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGuardar;
    }
}