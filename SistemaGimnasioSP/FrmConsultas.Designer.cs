namespace SistemaGimnasioSP
{
    partial class FrmConsultas
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerarGafete = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.lblEdadResultado = new System.Windows.Forms.Label();
            this.lblEstatusResultado = new System.Windows.Forms.Label();
            this.lblMunicipioResultado = new System.Windows.Forms.Label();
            this.lblNombreResultado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblAlergiasResultado = new System.Windows.Forms.Label();
            this.lblSangreResultado = new System.Windows.Forms.Label();
            this.lblTelefonoResultado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(433, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 29);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(69, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del cliente";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(475, 142);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(189, 30);
            this.txtBuscar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblAlergiasResultado);
            this.panel1.Controls.Add(this.lblSangreResultado);
            this.panel1.Controls.Add(this.lblTelefonoResultado);
            this.panel1.Controls.Add(this.btnGenerarGafete);
            this.panel1.Controls.Add(this.lblEdadResultado);
            this.panel1.Controls.Add(this.lblEstatusResultado);
            this.panel1.Controls.Add(this.lblMunicipioResultado);
            this.panel1.Controls.Add(this.lblNombreResultado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(248, 218);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 355);
            this.panel1.TabIndex = 3;
            // 
            // btnGenerarGafete
            // 
            this.btnGenerarGafete.BorderRadius = 15;
            this.btnGenerarGafete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarGafete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarGafete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerarGafete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerarGafete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerarGafete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            this.btnGenerarGafete.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            this.btnGenerarGafete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarGafete.ForeColor = System.Drawing.Color.White;
            this.btnGenerarGafete.Location = new System.Drawing.Point(468, 2);
            this.btnGenerarGafete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarGafete.Name = "btnGenerarGafete";
            this.btnGenerarGafete.Size = new System.Drawing.Size(178, 46);
            this.btnGenerarGafete.TabIndex = 5;
            this.btnGenerarGafete.Text = "Generar Gafet";
            this.btnGenerarGafete.Click += new System.EventHandler(this.btnGenerarGafete_Click);
            // 
            // lblEdadResultado
            // 
            this.lblEdadResultado.AutoSize = true;
            this.lblEdadResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdadResultado.ForeColor = System.Drawing.Color.Black;
            this.lblEdadResultado.Location = new System.Drawing.Point(67, 177);
            this.lblEdadResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEdadResultado.Name = "lblEdadResultado";
            this.lblEdadResultado.Size = new System.Drawing.Size(0, 23);
            this.lblEdadResultado.TabIndex = 4;
            // 
            // lblEstatusResultado
            // 
            this.lblEstatusResultado.AutoSize = true;
            this.lblEstatusResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatusResultado.ForeColor = System.Drawing.Color.Black;
            this.lblEstatusResultado.Location = new System.Drawing.Point(67, 143);
            this.lblEstatusResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstatusResultado.Name = "lblEstatusResultado";
            this.lblEstatusResultado.Size = new System.Drawing.Size(0, 23);
            this.lblEstatusResultado.TabIndex = 3;
            // 
            // lblMunicipioResultado
            // 
            this.lblMunicipioResultado.AutoSize = true;
            this.lblMunicipioResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipioResultado.ForeColor = System.Drawing.Color.Black;
            this.lblMunicipioResultado.Location = new System.Drawing.Point(67, 110);
            this.lblMunicipioResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMunicipioResultado.Name = "lblMunicipioResultado";
            this.lblMunicipioResultado.Size = new System.Drawing.Size(0, 23);
            this.lblMunicipioResultado.TabIndex = 2;
            // 
            // lblNombreResultado
            // 
            this.lblNombreResultado.AutoSize = true;
            this.lblNombreResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreResultado.ForeColor = System.Drawing.Color.Black;
            this.lblNombreResultado.Location = new System.Drawing.Point(67, 83);
            this.lblNombreResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreResultado.Name = "lblNombreResultado";
            this.lblNombreResultado.Size = new System.Drawing.Size(0, 23);
            this.lblNombreResultado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Datos del Cliente";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnBuscar);
            this.guna2Panel1.Location = new System.Drawing.Point(287, 124);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(569, 59);
            this.guna2Panel1.TabIndex = 5;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.btnBuscar;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(503, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consultas";
            // 
            // lblAlergiasResultado
            // 
            this.lblAlergiasResultado.AutoSize = true;
            this.lblAlergiasResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlergiasResultado.ForeColor = System.Drawing.Color.Black;
            this.lblAlergiasResultado.Location = new System.Drawing.Point(67, 270);
            this.lblAlergiasResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlergiasResultado.Name = "lblAlergiasResultado";
            this.lblAlergiasResultado.Size = new System.Drawing.Size(0, 23);
            this.lblAlergiasResultado.TabIndex = 8;
            // 
            // lblSangreResultado
            // 
            this.lblSangreResultado.AutoSize = true;
            this.lblSangreResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSangreResultado.ForeColor = System.Drawing.Color.Black;
            this.lblSangreResultado.Location = new System.Drawing.Point(67, 237);
            this.lblSangreResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSangreResultado.Name = "lblSangreResultado";
            this.lblSangreResultado.Size = new System.Drawing.Size(0, 23);
            this.lblSangreResultado.TabIndex = 7;
            // 
            // lblTelefonoResultado
            // 
            this.lblTelefonoResultado.AutoSize = true;
            this.lblTelefonoResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoResultado.ForeColor = System.Drawing.Color.Black;
            this.lblTelefonoResultado.Location = new System.Drawing.Point(67, 210);
            this.lblTelefonoResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefonoResultado.Name = "lblTelefonoResultado";
            this.lblTelefonoResultado.Size = new System.Drawing.Size(0, 23);
            this.lblTelefonoResultado.TabIndex = 6;
            // 
            // FrmConsultas
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(924, 694);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FrmConsultas";
            this.Text = "FrmConsultar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEdadResultado;
        private System.Windows.Forms.Label lblEstatusResultado;
        private System.Windows.Forms.Label lblMunicipioResultado;
        private System.Windows.Forms.Label lblNombreResultado;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientTileButton btnGenerarGafete;
        private System.Windows.Forms.Label lblAlergiasResultado;
        private System.Windows.Forms.Label lblSangreResultado;
        private System.Windows.Forms.Label lblTelefonoResultado;
    }
}