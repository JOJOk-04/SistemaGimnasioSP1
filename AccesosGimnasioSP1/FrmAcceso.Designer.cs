namespace AccesosGimnasioSP1
{
    partial class FrmAcceso
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcceso));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEscaner = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(835, 183);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 89);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Bus";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del Cliente";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEscaner
            // 
            this.txtEscaner.Location = new System.Drawing.Point(429, 181);
            this.txtEscaner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEscaner.Name = "txtEscaner";
            this.txtEscaner.Size = new System.Drawing.Size(353, 22);
            this.txtEscaner.TabIndex = 2;
            this.txtEscaner.Click += new System.EventHandler(this.txtEscaner_TextChanged);
            this.txtEscaner.TextChanged += new System.EventHandler(this.txtEscaner_TextChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(564, 280);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 16);
            this.lblMensaje.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(398, 240);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            // 
            // FrmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1088, 433);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtEscaner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAcceso";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEscaner;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblNombre;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}

