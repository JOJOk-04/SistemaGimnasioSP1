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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultas));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEdadResultado = new System.Windows.Forms.Label();
            this.lblEstatusResultado = new System.Windows.Forms.Label();
            this.lblMunicipioResultado = new System.Windows.Forms.Label();
            this.lblNombreResultado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(856, 326);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(132, 59);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(336, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del cliente";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(546, 334);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(282, 41);
            this.txtBuscar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblEdadResultado);
            this.panel1.Controls.Add(this.lblEstatusResultado);
            this.panel1.Controls.Add(this.lblMunicipioResultado);
            this.panel1.Controls.Add(this.lblNombreResultado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(218, 391);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 503);
            this.panel1.TabIndex = 3;
            // 
            // lblEdadResultado
            // 
            this.lblEdadResultado.AutoSize = true;
            this.lblEdadResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdadResultado.Location = new System.Drawing.Point(100, 272);
            this.lblEdadResultado.Name = "lblEdadResultado";
            this.lblEdadResultado.Size = new System.Drawing.Size(0, 34);
            this.lblEdadResultado.TabIndex = 4;
            // 
            // lblEstatusResultado
            // 
            this.lblEstatusResultado.AutoSize = true;
            this.lblEstatusResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatusResultado.Location = new System.Drawing.Point(100, 220);
            this.lblEstatusResultado.Name = "lblEstatusResultado";
            this.lblEstatusResultado.Size = new System.Drawing.Size(0, 34);
            this.lblEstatusResultado.TabIndex = 3;
            // 
            // lblMunicipioResultado
            // 
            this.lblMunicipioResultado.AutoSize = true;
            this.lblMunicipioResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMunicipioResultado.Location = new System.Drawing.Point(100, 170);
            this.lblMunicipioResultado.Name = "lblMunicipioResultado";
            this.lblMunicipioResultado.Size = new System.Drawing.Size(0, 34);
            this.lblMunicipioResultado.TabIndex = 2;
            // 
            // lblNombreResultado
            // 
            this.lblNombreResultado.AutoSize = true;
            this.lblNombreResultado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreResultado.Location = new System.Drawing.Point(100, 127);
            this.lblNombreResultado.Name = "lblNombreResultado";
            this.lblNombreResultado.Size = new System.Drawing.Size(0, 34);
            this.lblNombreResultado.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Datos del CLiente";
            // 
            // FrmConsultas
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1327, 924);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultas";
            this.Text = "FrmConsultar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}