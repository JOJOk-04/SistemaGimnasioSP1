namespace SistemaGimnasioSP
{
    partial class FrmAfluencia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.VntnFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.VntnFechaFinal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.BtnConsultas = new Guna.UI2.WinForms.Guna2Button();
            this.BtnGenPDF = new Guna.UI2.WinForms.Guna2Button();
            this.VntnDatosCorte = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.VntnDatosCorte)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // VntnFechaInicio
            // 
            this.VntnFechaInicio.Animated = true;
            this.VntnFechaInicio.AutoRoundedCorners = true;
            this.VntnFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.VntnFechaInicio.Checked = true;
            this.VntnFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.VntnFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaInicio.Location = new System.Drawing.Point(37, 26);
            this.VntnFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaInicio.Name = "VntnFechaInicio";
            this.VntnFechaInicio.Size = new System.Drawing.Size(241, 36);
            this.VntnFechaInicio.TabIndex = 0;
            this.VntnFechaInicio.UseTransparentBackground = true;
            this.VntnFechaInicio.Value = new System.DateTime(2026, 4, 30, 23, 29, 33, 937);
            // 
            // VntnFechaFinal
            // 
            this.VntnFechaFinal.Animated = true;
            this.VntnFechaFinal.AutoRoundedCorners = true;
            this.VntnFechaFinal.BackColor = System.Drawing.Color.Transparent;
            this.VntnFechaFinal.Checked = true;
            this.VntnFechaFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.VntnFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaFinal.Location = new System.Drawing.Point(329, 26);
            this.VntnFechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaFinal.Name = "VntnFechaFinal";
            this.VntnFechaFinal.Size = new System.Drawing.Size(248, 36);
            this.VntnFechaFinal.TabIndex = 1;
            this.VntnFechaFinal.UseTransparentBackground = true;
            this.VntnFechaFinal.Value = new System.DateTime(2026, 4, 30, 23, 29, 39, 155);
            // 
            // BtnConsultas
            // 
            this.BtnConsultas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnConsultas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnConsultas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnConsultas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnConsultas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnConsultas.ForeColor = System.Drawing.Color.White;
            this.BtnConsultas.Location = new System.Drawing.Point(662, 126);
            this.BtnConsultas.Name = "BtnConsultas";
            this.BtnConsultas.Size = new System.Drawing.Size(180, 45);
            this.BtnConsultas.TabIndex = 2;
            this.BtnConsultas.Text = "guna2Button1";
            this.BtnConsultas.Click += new System.EventHandler(this.BtnConsultas_Click);
            // 
            // BtnGenPDF
            // 
            this.BtnGenPDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenPDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenPDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnGenPDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnGenPDF.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnGenPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGenPDF.Location = new System.Drawing.Point(662, 200);
            this.BtnGenPDF.Name = "BtnGenPDF";
            this.BtnGenPDF.Size = new System.Drawing.Size(180, 45);
            this.BtnGenPDF.TabIndex = 3;
            this.BtnGenPDF.Text = "guna2Button2";
            this.BtnGenPDF.Click += new System.EventHandler(this.BtnGenPDF_Click);
            // 
            // VntnDatosCorte
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VntnDatosCorte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.VntnDatosCorte.ColumnHeadersHeight = 4;
            this.VntnDatosCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VntnDatosCorte.DefaultCellStyle = dataGridViewCellStyle3;
            this.VntnDatosCorte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.VntnDatosCorte.Location = new System.Drawing.Point(48, 95);
            this.VntnDatosCorte.Name = "VntnDatosCorte";
            this.VntnDatosCorte.RowHeadersVisible = false;
            this.VntnDatosCorte.RowHeadersWidth = 51;
            this.VntnDatosCorte.RowTemplate.Height = 24;
            this.VntnDatosCorte.Size = new System.Drawing.Size(529, 349);
            this.VntnDatosCorte.TabIndex = 4;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.VntnDatosCorte.ThemeStyle.HeaderStyle.Height = 4;
            this.VntnDatosCorte.ThemeStyle.ReadOnly = false;
            this.VntnDatosCorte.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.VntnDatosCorte.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VntnDatosCorte.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.VntnDatosCorte.ThemeStyle.RowsStyle.Height = 24;
            this.VntnDatosCorte.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.VntnDatosCorte.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmAfluencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 784);
            this.Controls.Add(this.VntnDatosCorte);
            this.Controls.Add(this.BtnGenPDF);
            this.Controls.Add(this.BtnConsultas);
            this.Controls.Add(this.VntnFechaFinal);
            this.Controls.Add(this.VntnFechaInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAfluencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAfluencia";
            ((System.ComponentModel.ISupportInitialize)(this.VntnDatosCorte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaFinal;
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaInicio;
        private Guna.UI2.WinForms.Guna2DataGridView VntnDatosCorte;
        private Guna.UI2.WinForms.Guna2Button BtnGenPDF;
        private Guna.UI2.WinForms.Guna2Button BtnConsultas;
    }
}