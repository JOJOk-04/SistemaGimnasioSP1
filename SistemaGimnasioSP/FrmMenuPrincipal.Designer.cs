namespace SistemaGimnasioSP
{
    partial class FrmMenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnTesoreria = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelCentral = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Transparent;
            this.PanelMenu.Controls.Add(this.btnCerrar);
            this.PanelMenu.Controls.Add(this.btnTesoreria);
            this.PanelMenu.Controls.Add(this.btnConsultar);
            this.PanelMenu.Controls.Add(this.btnRegistro);
            this.PanelMenu.Controls.Add(this.pictureBox1);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(355, 738);
            this.PanelMenu.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(2, 623);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(350, 112);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnTesoreria
            // 
            this.btnTesoreria.BackColor = System.Drawing.Color.Transparent;
            this.btnTesoreria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTesoreria.BackgroundImage")));
            this.btnTesoreria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTesoreria.FlatAppearance.BorderSize = 0;
            this.btnTesoreria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTesoreria.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTesoreria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTesoreria.Location = new System.Drawing.Point(2, 480);
            this.btnTesoreria.Margin = new System.Windows.Forms.Padding(2);
            this.btnTesoreria.Name = "btnTesoreria";
            this.btnTesoreria.Size = new System.Drawing.Size(350, 110);
            this.btnTesoreria.TabIndex = 4;
            this.btnTesoreria.Text = "Tesoreria/Cobros";
            this.btnTesoreria.UseVisualStyleBackColor = false;
            this.btnTesoreria.Click += new System.EventHandler(this.btnCobros_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConsultar.Location = new System.Drawing.Point(2, 321);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(350, 131);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar Usuario";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.AutoEllipsis = true;
            this.btnRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistro.BackgroundImage")));
            this.btnRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegistro.FlatAppearance.BorderSize = 0;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistro.Location = new System.Drawing.Point(2, 182);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(350, 112);
            this.btnRegistro.TabIndex = 2;
            this.btnRegistro.Text = "Registro";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(460, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 288);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unidad \r\nDeportiva \r\nOriente ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PanelCentral
            // 
            this.PanelCentral.BackColor = System.Drawing.Color.Transparent;
            this.PanelCentral.Controls.Add(this.label1);
            this.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentral.Location = new System.Drawing.Point(355, 0);
            this.PanelCentral.Margin = new System.Windows.Forms.Padding(2);
            this.PanelCentral.Name = "PanelCentral";
            this.PanelCentral.Size = new System.Drawing.Size(1187, 738);
            this.PanelCentral.TabIndex = 2;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1542, 738);
            this.Controls.Add(this.PanelCentral);
            this.Controls.Add(this.PanelMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenuPrincipal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelCentral.ResumeLayout(false);
            this.PanelCentral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnTesoreria;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelCentral;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}