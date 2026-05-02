namespace SistemaGimnasioSP
{
    partial class FrmCortes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDesde = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpHasta = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnConsultar = new Guna.UI2.WinForms.Guna2Button();
            this.lblFolioSiguiente = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalDeportes = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGranTotal = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalServicios = new System.Windows.Forms.Label();
            this.dgvCortes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnGenerarCorte = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.BorderRadius = 5;
            this.dtpDesde.Checked = true;
            this.dtpDesde.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.dtpDesde.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDesde.Location = new System.Drawing.Point(51, 48);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 36);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.Value = new System.DateTime(2026, 5, 1, 15, 29, 52, 790);
            // 
            // dtpHasta
            // 
            this.dtpHasta.BorderRadius = 5;
            this.dtpHasta.Checked = true;
            this.dtpHasta.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.dtpHasta.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpHasta.Location = new System.Drawing.Point(301, 48);
            this.dtpHasta.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 36);
            this.dtpHasta.TabIndex = 1;
            this.dtpHasta.Value = new System.DateTime(2026, 5, 1, 15, 29, 52, 790);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Animated = true;
            this.btnConsultar.AutoRoundedCorners = true;
            this.btnConsultar.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultar.BorderRadius = 29;
            this.btnConsultar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConsultar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConsultar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConsultar.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnConsultar.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(553, 32);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(184, 60);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblFolioSiguiente
            // 
            this.lblFolioSiguiente.AutoSize = true;
            this.lblFolioSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.lblFolioSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioSiguiente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFolioSiguiente.Location = new System.Drawing.Point(769, 48);
            this.lblFolioSiguiente.Name = "lblFolioSiguiente";
            this.lblFolioSiguiente.Size = new System.Drawing.Size(169, 26);
            this.lblFolioSiguiente.TabIndex = 3;
            this.lblFolioSiguiente.Text = "Folio SIguiente :";
            this.lblFolioSiguiente.Click += new System.EventHandler(this.lblFolioSiguiente_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.Controls.Add(this.lblTotalDeportes);
            this.guna2Panel2.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.Location = new System.Drawing.Point(51, 179);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(263, 96);
            this.guna2Panel2.TabIndex = 5;
            // 
            // lblTotalDeportes
            // 
            this.lblTotalDeportes.AutoSize = true;
            this.lblTotalDeportes.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDeportes.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeportes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalDeportes.Location = new System.Drawing.Point(6, 19);
            this.lblTotalDeportes.Name = "lblTotalDeportes";
            this.lblTotalDeportes.Size = new System.Drawing.Size(254, 23);
            this.lblTotalDeportes.TabIndex = 2;
            this.lblTotalDeportes.Text = "Total Actividades FIsicas:";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.Controls.Add(this.lblGranTotal);
            this.guna2Panel3.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel3.FillColor = System.Drawing.Color.SpringGreen;
            this.guna2Panel3.Location = new System.Drawing.Point(688, 131);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(263, 166);
            this.guna2Panel3.TabIndex = 6;
            // 
            // lblGranTotal
            // 
            this.lblGranTotal.AutoSize = true;
            this.lblGranTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblGranTotal.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGranTotal.Location = new System.Drawing.Point(72, 25);
            this.lblGranTotal.Name = "lblGranTotal";
            this.lblGranTotal.Size = new System.Drawing.Size(115, 23);
            this.lblGranTotal.TabIndex = 0;
            this.lblGranTotal.Text = "Gran Total:";
            this.lblGranTotal.Click += new System.EventHandler(this.lblGranTotal_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.lblTotalServicios);
            this.guna2Panel1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.Location = new System.Drawing.Point(344, 179);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(272, 96);
            this.guna2Panel1.TabIndex = 6;
            // 
            // lblTotalServicios
            // 
            this.lblTotalServicios.AutoSize = true;
            this.lblTotalServicios.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalServicios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalServicios.Location = new System.Drawing.Point(60, 19);
            this.lblTotalServicios.Name = "lblTotalServicios";
            this.lblTotalServicios.Size = new System.Drawing.Size(158, 23);
            this.lblTotalServicios.TabIndex = 1;
            this.lblTotalServicios.Text = "Total Servicios: ";
            this.lblTotalServicios.Click += new System.EventHandler(this.lblTotalServicios_Click);
            // 
            // dgvCortes
            // 
            this.dgvCortes.AllowUserToAddRows = false;
            this.dgvCortes.AllowUserToDeleteRows = false;
            this.dgvCortes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvCortes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCortes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCortes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCortes.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCortes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.Location = new System.Drawing.Point(51, 358);
            this.dgvCortes.Name = "dgvCortes";
            this.dgvCortes.ReadOnly = true;
            this.dgvCortes.RowHeadersVisible = false;
            this.dgvCortes.RowHeadersWidth = 62;
            this.dgvCortes.RowTemplate.Height = 28;
            this.dgvCortes.Size = new System.Drawing.Size(892, 260);
            this.dgvCortes.TabIndex = 7;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCortes.ThemeStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCortes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCortes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCortes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCortes.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvCortes.ThemeStyle.ReadOnly = true;
            this.dgvCortes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCortes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCortes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCortes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCortes.ThemeStyle.RowsStyle.Height = 28;
            this.dgvCortes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCortes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnGenerarCorte
            // 
            this.btnGenerarCorte.BorderRadius = 20;
            this.btnGenerarCorte.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarCorte.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarCorte.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerarCorte.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerarCorte.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnGenerarCorte.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCorte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCorte.Location = new System.Drawing.Point(553, 658);
            this.btnGenerarCorte.Name = "btnGenerarCorte";
            this.btnGenerarCorte.Size = new System.Drawing.Size(385, 51);
            this.btnGenerarCorte.TabIndex = 8;
            this.btnGenerarCorte.Text = "Generar Corte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Desde :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(296, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hasta :";
            // 
            // FrmCortes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1037, 729);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarCorte);
            this.Controls.Add(this.dgvCortes);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.lblFolioSiguiente);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Name = "FrmCortes";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.FrmCortes_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDesde;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHasta;
        private Guna.UI2.WinForms.Guna2Button btnConsultar;
        private System.Windows.Forms.Label lblFolioSiguiente;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCortes;
        private Guna.UI2.WinForms.Guna2Button btnGenerarCorte;
        private System.Windows.Forms.Label lblTotalDeportes;
        private System.Windows.Forms.Label lblGranTotal;
        private System.Windows.Forms.Label lblTotalServicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}