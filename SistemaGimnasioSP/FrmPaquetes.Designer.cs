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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMiembros = new System.Windows.Forms.ComboBox();
            this.txtAgregar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRitmos = new Guna.UI2.WinForms.Guna2Button();
            this.btnAcondicionamiento = new Guna.UI2.WinForms.Guna2Button();
            this.btnHeterofilia = new Guna.UI2.WinForms.Guna2Button();
            this.btnFutbol = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaekwondo = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAgregar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccionar Integrante:";
            // 
            // cmbMiembros
            // 
            this.cmbMiembros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMiembros.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMiembros.FormattingEnabled = true;
            this.cmbMiembros.Location = new System.Drawing.Point(550, 71);
            this.cmbMiembros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMiembros.Name = "cmbMiembros";
            this.cmbMiembros.Size = new System.Drawing.Size(303, 32);
            this.cmbMiembros.Sorted = true;
            this.cmbMiembros.TabIndex = 20;
            this.cmbMiembros.SelectedIndexChanged += new System.EventHandler(this.cmbMiembros_SelectedIndexChanged);
            // 
            // txtAgregar
            // 
            this.txtAgregar.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgregar.Location = new System.Drawing.Point(450, 169);
            this.txtAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.Size = new System.Drawing.Size(303, 32);
            this.txtAgregar.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Agregar Integrante:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(512, 548);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(241, 74);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRitmos
            // 
            this.btnRitmos.Animated = true;
            this.btnRitmos.BackColor = System.Drawing.Color.Transparent;
            this.btnRitmos.BorderRadius = 20;
            this.btnRitmos.BorderThickness = 2;
            this.btnRitmos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnRitmos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRitmos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRitmos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRitmos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRitmos.FillColor = System.Drawing.Color.Transparent;
            this.btnRitmos.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnRitmos.ForeColor = System.Drawing.Color.Black;
            this.btnRitmos.Image = global::SistemaGimnasioSP.Properties.Resources.performance;
            this.btnRitmos.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRitmos.ImageSize = new System.Drawing.Size(40, 40);
            this.btnRitmos.Location = new System.Drawing.Point(654, 119);
            this.btnRitmos.Name = "btnRitmos";
            this.btnRitmos.Size = new System.Drawing.Size(311, 55);
            this.btnRitmos.TabIndex = 35;
            this.btnRitmos.Text = "Ritmos Latinos";
            this.btnRitmos.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRitmos.UseTransparentBackground = true;
            this.btnRitmos.Click += new System.EventHandler(this.btnRitmos_Click);
            // 
            // btnAcondicionamiento
            // 
            this.btnAcondicionamiento.Animated = true;
            this.btnAcondicionamiento.BackColor = System.Drawing.Color.Transparent;
            this.btnAcondicionamiento.BorderRadius = 20;
            this.btnAcondicionamiento.BorderThickness = 2;
            this.btnAcondicionamiento.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnAcondicionamiento.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAcondicionamiento.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAcondicionamiento.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAcondicionamiento.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAcondicionamiento.FillColor = System.Drawing.Color.Transparent;
            this.btnAcondicionamiento.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAcondicionamiento.ForeColor = System.Drawing.Color.Black;
            this.btnAcondicionamiento.Image = global::SistemaGimnasioSP.Properties.Resources.dumb_bell;
            this.btnAcondicionamiento.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAcondicionamiento.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAcondicionamiento.Location = new System.Drawing.Point(188, 119);
            this.btnAcondicionamiento.Name = "btnAcondicionamiento";
            this.btnAcondicionamiento.PressedColor = System.Drawing.Color.Transparent;
            this.btnAcondicionamiento.Size = new System.Drawing.Size(434, 55);
            this.btnAcondicionamiento.TabIndex = 31;
            this.btnAcondicionamiento.Text = "Acondicionamiento Fisico";
            this.btnAcondicionamiento.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAcondicionamiento.UseTransparentBackground = true;
            this.btnAcondicionamiento.Click += new System.EventHandler(this.btnAcondicionamiento_Click);
            // 
            // btnHeterofilia
            // 
            this.btnHeterofilia.Animated = true;
            this.btnHeterofilia.BackColor = System.Drawing.Color.Transparent;
            this.btnHeterofilia.BorderRadius = 20;
            this.btnHeterofilia.BorderThickness = 2;
            this.btnHeterofilia.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnHeterofilia.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHeterofilia.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHeterofilia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHeterofilia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHeterofilia.FillColor = System.Drawing.Color.Transparent;
            this.btnHeterofilia.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnHeterofilia.ForeColor = System.Drawing.Color.Black;
            this.btnHeterofilia.Image = global::SistemaGimnasioSP.Properties.Resources.fitness;
            this.btnHeterofilia.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHeterofilia.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHeterofilia.Location = new System.Drawing.Point(126, 42);
            this.btnHeterofilia.Name = "btnHeterofilia";
            this.btnHeterofilia.Size = new System.Drawing.Size(254, 55);
            this.btnHeterofilia.TabIndex = 34;
            this.btnHeterofilia.Text = "Halterofilia";
            this.btnHeterofilia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnHeterofilia.UseTransparentBackground = true;
            this.btnHeterofilia.Click += new System.EventHandler(this.btnHeterofilia_Click);
            // 
            // btnFutbol
            // 
            this.btnFutbol.Animated = true;
            this.btnFutbol.BackColor = System.Drawing.Color.Transparent;
            this.btnFutbol.BorderRadius = 20;
            this.btnFutbol.BorderThickness = 2;
            this.btnFutbol.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnFutbol.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFutbol.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFutbol.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFutbol.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFutbol.FillColor = System.Drawing.Color.Transparent;
            this.btnFutbol.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnFutbol.ForeColor = System.Drawing.Color.Black;
            this.btnFutbol.Image = global::SistemaGimnasioSP.Properties.Resources.football;
            this.btnFutbol.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFutbol.ImageSize = new System.Drawing.Size(40, 40);
            this.btnFutbol.Location = new System.Drawing.Point(428, 42);
            this.btnFutbol.Name = "btnFutbol";
            this.btnFutbol.Size = new System.Drawing.Size(242, 55);
            this.btnFutbol.TabIndex = 32;
            this.btnFutbol.Text = "Futbol";
            this.btnFutbol.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnFutbol.UseTransparentBackground = true;
            this.btnFutbol.Click += new System.EventHandler(this.btnFutbol_Click);
            // 
            // btnTaekwondo
            // 
            this.btnTaekwondo.Animated = true;
            this.btnTaekwondo.BackColor = System.Drawing.Color.Transparent;
            this.btnTaekwondo.BorderRadius = 20;
            this.btnTaekwondo.BorderThickness = 2;
            this.btnTaekwondo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnTaekwondo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaekwondo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaekwondo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaekwondo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaekwondo.FillColor = System.Drawing.Color.Transparent;
            this.btnTaekwondo.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnTaekwondo.ForeColor = System.Drawing.Color.Black;
            this.btnTaekwondo.Image = global::SistemaGimnasioSP.Properties.Resources.karate;
            this.btnTaekwondo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaekwondo.ImageSize = new System.Drawing.Size(40, 40);
            this.btnTaekwondo.Location = new System.Drawing.Point(736, 42);
            this.btnTaekwondo.Name = "btnTaekwondo";
            this.btnTaekwondo.Size = new System.Drawing.Size(274, 55);
            this.btnTaekwondo.TabIndex = 33;
            this.btnTaekwondo.Text = "Taekwondo";
            this.btnTaekwondo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnTaekwondo.UseTransparentBackground = true;
            this.btnTaekwondo.Click += new System.EventHandler(this.btnTaekwondo_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnRitmos);
            this.guna2Panel1.Controls.Add(this.btnAcondicionamiento);
            this.guna2Panel1.Controls.Add(this.btnHeterofilia);
            this.guna2Panel1.Controls.Add(this.btnFutbol);
            this.guna2Panel1.Controls.Add(this.btnTaekwondo);
            this.guna2Panel1.Location = new System.Drawing.Point(38, 229);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1154, 257);
            this.guna2Panel1.TabIndex = 36;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BorderRadius = 10;
            this.btnAgregar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAgregar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAgregar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(790, 160);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(178, 50);
            this.btnAgregar.TabIndex = 37;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // FrmPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 674);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgregar);
            this.Controls.Add(this.cmbMiembros);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPaquetes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPaquetes";
            this.Load += new System.EventHandler(this.FrmPaquetes_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMiembros;
        private System.Windows.Forms.TextBox txtAgregar;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnRitmos;
        private Guna.UI2.WinForms.Guna2Button btnAcondicionamiento;
        private Guna.UI2.WinForms.Guna2Button btnHeterofilia;
        private Guna.UI2.WinForms.Guna2Button btnFutbol;
        private Guna.UI2.WinForms.Guna2Button btnTaekwondo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnAgregar;
    }
}