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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.VntnFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.VntnFechaFinal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.BtnConsultas = new Guna.UI2.WinForms.Guna2Button();
            this.BtnGenPDF = new Guna.UI2.WinForms.Guna2Button();
            this.VntnDatosCorte = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VntnDatosCorte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
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
            this.VntnFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.VntnFechaInicio.BorderRadius = 10;
            this.VntnFechaInicio.Checked = true;
            this.VntnFechaInicio.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.VntnFechaInicio.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.VntnFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaInicio.Location = new System.Drawing.Point(316, 70);
            this.VntnFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaInicio.Name = "VntnFechaInicio";
            this.VntnFechaInicio.Size = new System.Drawing.Size(341, 32);
            this.VntnFechaInicio.TabIndex = 0;
            this.VntnFechaInicio.UseTransparentBackground = true;
            this.VntnFechaInicio.Value = new System.DateTime(2026, 4, 30, 23, 29, 33, 937);
            // 
            // VntnFechaFinal
            // 
            this.VntnFechaFinal.Animated = true;
            this.VntnFechaFinal.BackColor = System.Drawing.Color.Transparent;
            this.VntnFechaFinal.BorderRadius = 10;
            this.VntnFechaFinal.Checked = true;
            this.VntnFechaFinal.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.VntnFechaFinal.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.VntnFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaFinal.Location = new System.Drawing.Point(719, 70);
            this.VntnFechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaFinal.Name = "VntnFechaFinal";
            this.VntnFechaFinal.Size = new System.Drawing.Size(340, 32);
            this.VntnFechaFinal.TabIndex = 1;
            this.VntnFechaFinal.UseTransparentBackground = true;
            this.VntnFechaFinal.Value = new System.DateTime(2026, 4, 30, 23, 29, 39, 155);
            // 
            // BtnConsultas
            // 
            this.BtnConsultas.Animated = true;
            this.BtnConsultas.BackColor = System.Drawing.Color.Transparent;
            this.BtnConsultas.BorderRadius = 20;
            this.BtnConsultas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnConsultas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnConsultas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnConsultas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnConsultas.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.BtnConsultas.ForeColor = System.Drawing.Color.White;
            this.BtnConsultas.Location = new System.Drawing.Point(1256, 153);
            this.BtnConsultas.Name = "BtnConsultas";
            this.BtnConsultas.Size = new System.Drawing.Size(247, 69);
            this.BtnConsultas.TabIndex = 2;
            this.BtnConsultas.Text = "Consulta";
            this.BtnConsultas.UseTransparentBackground = true;
            this.BtnConsultas.Click += new System.EventHandler(this.BtnConsultas_Click);
            // 
            // BtnGenPDF
            // 
            this.BtnGenPDF.Animated = true;
            this.BtnGenPDF.BackColor = System.Drawing.Color.Transparent;
            this.BtnGenPDF.BorderRadius = 20;
            this.BtnGenPDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenPDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnGenPDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnGenPDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnGenPDF.Font = new System.Drawing.Font("Bahnschrift", 16.2F, System.Drawing.FontStyle.Bold);
            this.BtnGenPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGenPDF.Location = new System.Drawing.Point(1256, 600);
            this.BtnGenPDF.Name = "BtnGenPDF";
            this.BtnGenPDF.Size = new System.Drawing.Size(247, 69);
            this.BtnGenPDF.TabIndex = 3;
            this.BtnGenPDF.Text = "Generar PDF";
            this.BtnGenPDF.UseTransparentBackground = true;
            this.BtnGenPDF.Click += new System.EventHandler(this.BtnGenPDF_Click);
            // 
            // VntnDatosCorte
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.VntnDatosCorte.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VntnDatosCorte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.VntnDatosCorte.ColumnHeadersHeight = 4;
            this.VntnDatosCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VntnDatosCorte.DefaultCellStyle = dataGridViewCellStyle6;
            this.VntnDatosCorte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.VntnDatosCorte.Location = new System.Drawing.Point(37, 153);
            this.VntnDatosCorte.Name = "VntnDatosCorte";
            this.VntnDatosCorte.RowHeadersVisible = false;
            this.VntnDatosCorte.RowHeadersWidth = 51;
            this.VntnDatosCorte.RowTemplate.Height = 24;
            this.VntnDatosCorte.Size = new System.Drawing.Size(1164, 516);
            this.VntnDatosCorte.TabIndex = 4;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.VntnDatosCorte.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "Asistencias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(312, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Desde :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(715, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hasta :";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::SistemaGimnasioSP.Properties.Resources.OsosSanPedro;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(1454, 670);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(209, 230);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 12;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // FrmAfluencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(1699, 945);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaFinal;
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaInicio;
        private Guna.UI2.WinForms.Guna2DataGridView VntnDatosCorte;
        private Guna.UI2.WinForms.Guna2Button BtnGenPDF;
        private Guna.UI2.WinForms.Guna2Button BtnConsultas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}