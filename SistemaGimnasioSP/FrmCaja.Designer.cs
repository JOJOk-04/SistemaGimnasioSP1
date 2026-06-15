namespace SistemaGimnasioSP
{
    partial class FrmCaja
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
            this.btnBeca = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirmar = new Guna.UI2.WinForms.Guna2Button();
            this.txtEfectivo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCambio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnColaborador = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnBeca
            // 
            this.btnBeca.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBeca.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBeca.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBeca.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBeca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBeca.ForeColor = System.Drawing.Color.White;
            this.btnBeca.Location = new System.Drawing.Point(315, 642);
            this.btnBeca.Name = "btnBeca";
            this.btnBeca.Size = new System.Drawing.Size(180, 45);
            this.btnBeca.TabIndex = 0;
            this.btnBeca.Text = "BECADO";
            this.btnBeca.Click += new System.EventHandler(this.btnBeca_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirmar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirmar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(180, 379);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 45);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEfectivo.DefaultText = "";
            this.txtEfectivo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEfectivo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEfectivo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEfectivo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEfectivo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEfectivo.Location = new System.Drawing.Point(168, 199);
            this.txtEfectivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.PlaceholderText = "";
            this.txtEfectivo.SelectedText = "";
            this.txtEfectivo.Size = new System.Drawing.Size(219, 37);
            this.txtEfectivo.TabIndex = 2;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(95, 133);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(73, 30);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "TOTAL:";
            // 
            // lblCambio
            // 
            this.lblCambio.BackColor = System.Drawing.Color.Transparent;
            this.lblCambio.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(77, 269);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(91, 30);
            this.lblCambio.TabIndex = 4;
            this.lblCambio.Text = "CAMBIO:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(60, 201);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(108, 30);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "EFECTIVO:";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(223, 31);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(59, 30);
            this.guna2HtmlLabel2.TabIndex = 6;
            this.guna2HtmlLabel2.Text = "CAJA ";
            // 
            // btnColaborador
            // 
            this.btnColaborador.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnColaborador.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnColaborador.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnColaborador.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnColaborador.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnColaborador.ForeColor = System.Drawing.Color.White;
            this.btnColaborador.Location = new System.Drawing.Point(27, 642);
            this.btnColaborador.Name = "btnColaborador";
            this.btnColaborador.Size = new System.Drawing.Size(180, 45);
            this.btnColaborador.TabIndex = 7;
            this.btnColaborador.Text = "COLABORADOR";
            // 
            // FrmCaja
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 699);
            this.Controls.Add(this.btnColaborador);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnBeca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCaja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnBeca;
        private Guna.UI2.WinForms.Guna2Button btnConfirmar;
        private Guna.UI2.WinForms.Guna2TextBox txtEfectivo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCambio;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnColaborador;
    }
}