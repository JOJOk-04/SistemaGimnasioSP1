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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAfluencia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VntnFechaInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.VntnFechaFinal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.BtnConsultas = new Guna.UI2.WinForms.Guna2Button();
            this.BtnGenPDF = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDeportes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tabMenuAfluencia = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabAsistencia = new System.Windows.Forms.TabPage();
            this.chartDeportes = new LiveCharts.WinForms.PieChart();
            this.label4 = new System.Windows.Forms.Label();
            this.tabHorarios = new System.Windows.Forms.TabPage();
            this.chartHorarios = new LiveCharts.WinForms.CartesianChart();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvHorarios = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabEdades = new System.Windows.Forms.TabPage();
            this.chartEdades = new LiveCharts.WinForms.CartesianChart();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEdades = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabMunicipios = new System.Windows.Forms.TabPage();
            this.chartProcedencia = new LiveCharts.WinForms.PieChart();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvProcedencia = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tabMenuAfluencia.SuspendLayout();
            this.tabAsistencia.SuspendLayout();
            this.tabHorarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.tabEdades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdades)).BeginInit();
            this.tabMunicipios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcedencia)).BeginInit();
            this.SuspendLayout();
            // 
            // VntnFechaInicio
            // 
            this.VntnFechaInicio.Animated = true;
            this.VntnFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.VntnFechaInicio.BorderRadius = 10;
            this.VntnFechaInicio.Checked = true;
            this.VntnFechaInicio.FillColor = System.Drawing.Color.DeepSkyBlue;
            resources.ApplyResources(this.VntnFechaInicio, "VntnFechaInicio");
            this.VntnFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaInicio.Name = "VntnFechaInicio";
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
            resources.ApplyResources(this.VntnFechaFinal, "VntnFechaFinal");
            this.VntnFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.VntnFechaFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.VntnFechaFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.VntnFechaFinal.Name = "VntnFechaFinal";
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
            this.BtnConsultas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            resources.ApplyResources(this.BtnConsultas, "BtnConsultas");
            this.BtnConsultas.ForeColor = System.Drawing.Color.White;
            this.BtnConsultas.Name = "BtnConsultas";
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
            this.BtnGenPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(46)))), ((int)(((byte)(96)))));
            resources.ApplyResources(this.BtnGenPDF, "BtnGenPDF");
            this.BtnGenPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGenPDF.Name = "BtnGenPDF";
            this.BtnGenPDF.UseTransparentBackground = true;
            this.BtnGenPDF.Click += new System.EventHandler(this.BtnGenPDF_Click);
            // 
            // dgvDeportes
            // 
            this.dgvDeportes.AllowUserToAddRows = false;
            this.dgvDeportes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDeportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeportes.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvDeportes, "dgvDeportes");
            this.dgvDeportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeportes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeportes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeportes.Name = "dgvDeportes";
            this.dgvDeportes.ReadOnly = true;
            this.dgvDeportes.RowHeadersVisible = false;
            this.dgvDeportes.RowTemplate.Height = 24;
            this.dgvDeportes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeportes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDeportes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDeportes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDeportes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDeportes.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvDeportes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeportes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDeportes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeportes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeportes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDeportes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDeportes.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvDeportes.ThemeStyle.ReadOnly = true;
            this.dgvDeportes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeportes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeportes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeportes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDeportes.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDeportes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeportes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::SistemaGimnasioSP.Properties.Resources.OsosSanPedro;
            this.guna2PictureBox1.ImageRotate = 0F;
            resources.ApplyResources(this.guna2PictureBox1, "guna2PictureBox1");
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // tabMenuAfluencia
            // 
            this.tabMenuAfluencia.Controls.Add(this.tabAsistencia);
            this.tabMenuAfluencia.Controls.Add(this.tabHorarios);
            this.tabMenuAfluencia.Controls.Add(this.tabEdades);
            this.tabMenuAfluencia.Controls.Add(this.tabMunicipios);
            resources.ApplyResources(this.tabMenuAfluencia, "tabMenuAfluencia");
            this.tabMenuAfluencia.Name = "tabMenuAfluencia";
            this.tabMenuAfluencia.SelectedIndex = 0;
            this.tabMenuAfluencia.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabMenuAfluencia.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabMenuAfluencia.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMenuAfluencia.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabMenuAfluencia.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabMenuAfluencia.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabMenuAfluencia.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabMenuAfluencia.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMenuAfluencia.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabMenuAfluencia.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabMenuAfluencia.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabMenuAfluencia.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabMenuAfluencia.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMenuAfluencia.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabMenuAfluencia.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabMenuAfluencia.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabMenuAfluencia.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabMenuAfluencia.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabMenuAfluencia.SelectedIndexChanged += new System.EventHandler(this.tabMenuAfluencia_SelectedIndexChanged);
            // 
            // tabAsistencia
            // 
            this.tabAsistencia.Controls.Add(this.chartDeportes);
            this.tabAsistencia.Controls.Add(this.label4);
            this.tabAsistencia.Controls.Add(this.dgvDeportes);
            resources.ApplyResources(this.tabAsistencia, "tabAsistencia");
            this.tabAsistencia.Name = "tabAsistencia";
            this.tabAsistencia.UseVisualStyleBackColor = true;
            // 
            // chartDeportes
            // 
            resources.ApplyResources(this.chartDeportes, "chartDeportes");
            this.chartDeportes.Name = "chartDeportes";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // tabHorarios
            // 
            this.tabHorarios.Controls.Add(this.chartHorarios);
            this.tabHorarios.Controls.Add(this.label5);
            this.tabHorarios.Controls.Add(this.dgvHorarios);
            resources.ApplyResources(this.tabHorarios, "tabHorarios");
            this.tabHorarios.Name = "tabHorarios";
            this.tabHorarios.UseVisualStyleBackColor = true;
            // 
            // chartHorarios
            // 
            resources.ApplyResources(this.chartHorarios, "chartHorarios");
            this.chartHorarios.Name = "chartHorarios";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Name = "label5";
            // 
            // dgvHorarios
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvHorarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHorarios.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.dgvHorarios, "dgvHorarios");
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHorarios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHorarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.RowHeadersVisible = false;
            this.dgvHorarios.RowTemplate.Height = 24;
            this.dgvHorarios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHorarios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHorarios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHorarios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHorarios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHorarios.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvHorarios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHorarios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHorarios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHorarios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHorarios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHorarios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHorarios.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvHorarios.ThemeStyle.ReadOnly = false;
            this.dgvHorarios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHorarios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHorarios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHorarios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHorarios.ThemeStyle.RowsStyle.Height = 24;
            this.dgvHorarios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHorarios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabEdades
            // 
            this.tabEdades.Controls.Add(this.chartEdades);
            this.tabEdades.Controls.Add(this.label6);
            this.tabEdades.Controls.Add(this.dgvEdades);
            resources.ApplyResources(this.tabEdades, "tabEdades");
            this.tabEdades.Name = "tabEdades";
            this.tabEdades.UseVisualStyleBackColor = true;
            // 
            // chartEdades
            // 
            resources.ApplyResources(this.chartEdades, "chartEdades");
            this.chartEdades.Name = "chartEdades";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Name = "label6";
            // 
            // dgvEdades
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvEdades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEdades.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEdades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dgvEdades, "dgvEdades");
            this.dgvEdades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEdades.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvEdades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEdades.Name = "dgvEdades";
            this.dgvEdades.RowHeadersVisible = false;
            this.dgvEdades.RowTemplate.Height = 24;
            this.dgvEdades.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEdades.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEdades.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEdades.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEdades.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEdades.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvEdades.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEdades.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEdades.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEdades.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEdades.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEdades.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvEdades.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvEdades.ThemeStyle.ReadOnly = false;
            this.dgvEdades.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEdades.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEdades.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEdades.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEdades.ThemeStyle.RowsStyle.Height = 24;
            this.dgvEdades.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEdades.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabMunicipios
            // 
            this.tabMunicipios.Controls.Add(this.chartProcedencia);
            this.tabMunicipios.Controls.Add(this.label7);
            this.tabMunicipios.Controls.Add(this.dgvProcedencia);
            resources.ApplyResources(this.tabMunicipios, "tabMunicipios");
            this.tabMunicipios.Name = "tabMunicipios";
            this.tabMunicipios.UseVisualStyleBackColor = true;
            // 
            // chartProcedencia
            // 
            resources.ApplyResources(this.chartProcedencia, "chartProcedencia");
            this.chartProcedencia.Name = "chartProcedencia";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Name = "label7";
            // 
            // dgvProcedencia
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvProcedencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProcedencia.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcedencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.dgvProcedencia, "dgvProcedencia");
            this.dgvProcedencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProcedencia.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProcedencia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProcedencia.Name = "dgvProcedencia";
            this.dgvProcedencia.RowHeadersVisible = false;
            this.dgvProcedencia.RowTemplate.Height = 24;
            this.dgvProcedencia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProcedencia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProcedencia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProcedencia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProcedencia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProcedencia.ThemeStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvProcedencia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProcedencia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvProcedencia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProcedencia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProcedencia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProcedencia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProcedencia.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvProcedencia.ThemeStyle.ReadOnly = false;
            this.dgvProcedencia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProcedencia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProcedencia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProcedencia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvProcedencia.ThemeStyle.RowsStyle.Height = 24;
            this.dgvProcedencia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvProcedencia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmAfluencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabMenuAfluencia);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGenPDF);
            this.Controls.Add(this.BtnConsultas);
            this.Controls.Add(this.VntnFechaFinal);
            this.Controls.Add(this.VntnFechaInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FrmAfluencia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.FrmAfluencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tabMenuAfluencia.ResumeLayout(false);
            this.tabAsistencia.ResumeLayout(false);
            this.tabAsistencia.PerformLayout();
            this.tabHorarios.ResumeLayout(false);
            this.tabHorarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.tabEdades.ResumeLayout(false);
            this.tabEdades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdades)).EndInit();
            this.tabMunicipios.ResumeLayout(false);
            this.tabMunicipios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcedencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaFinal;
        private Guna.UI2.WinForms.Guna2DateTimePicker VntnFechaInicio;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDeportes;
        private Guna.UI2.WinForms.Guna2Button BtnGenPDF;
        private Guna.UI2.WinForms.Guna2Button BtnConsultas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2TabControl tabMenuAfluencia;
        private System.Windows.Forms.TabPage tabAsistencia;
        private System.Windows.Forms.TabPage tabHorarios;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHorarios;
        private System.Windows.Forms.TabPage tabEdades;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEdades;
        private System.Windows.Forms.TabPage tabMunicipios;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProcedencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private LiveCharts.WinForms.PieChart chartProcedencia;
        private LiveCharts.WinForms.PieChart chartDeportes;
        private LiveCharts.WinForms.CartesianChart chartEdades;
        private LiveCharts.WinForms.CartesianChart chartHorarios;
    }
}