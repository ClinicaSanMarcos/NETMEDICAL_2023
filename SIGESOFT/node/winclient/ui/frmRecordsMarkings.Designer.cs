namespace Sigesoft.Node.WinClient.UI
{
    partial class frmRecordsMarkings
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPuntuales = new System.Windows.Forms.RadioButton();
            this.rdoHorasExtras = new System.Windows.Forms.RadioButton();
            this.rdoTardanzas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.txtTopRegistros = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 110);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(781, 300);
            this.chart1.TabIndex = 180;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPuntuales);
            this.groupBox1.Controls.Add(this.rdoHorasExtras);
            this.groupBox1.Controls.Add(this.rdoTardanzas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Controls.Add(this.txtTopRegistros);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 65);
            this.groupBox1.TabIndex = 181;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // rdoPuntuales
            // 
            this.rdoPuntuales.AutoSize = true;
            this.rdoPuntuales.Location = new System.Drawing.Point(550, 21);
            this.rdoPuntuales.Name = "rdoPuntuales";
            this.rdoPuntuales.Size = new System.Drawing.Size(72, 17);
            this.rdoPuntuales.TabIndex = 187;
            this.rdoPuntuales.TabStop = true;
            this.rdoPuntuales.Text = "Puntuales";
            this.rdoPuntuales.UseVisualStyleBackColor = true;
            // 
            // rdoHorasExtras
            // 
            this.rdoHorasExtras.AutoSize = true;
            this.rdoHorasExtras.Location = new System.Drawing.Point(459, 21);
            this.rdoHorasExtras.Name = "rdoHorasExtras";
            this.rdoHorasExtras.Size = new System.Drawing.Size(85, 17);
            this.rdoHorasExtras.TabIndex = 186;
            this.rdoHorasExtras.Text = "Horas Extras";
            this.rdoHorasExtras.UseVisualStyleBackColor = true;
            // 
            // rdoTardanzas
            // 
            this.rdoTardanzas.AutoSize = true;
            this.rdoTardanzas.Checked = true;
            this.rdoTardanzas.Location = new System.Drawing.Point(378, 20);
            this.rdoTardanzas.Name = "rdoTardanzas";
            this.rdoTardanzas.Size = new System.Drawing.Size(75, 17);
            this.rdoTardanzas.TabIndex = 185;
            this.rdoTardanzas.TabStop = true;
            this.rdoTardanzas.Text = "Tardanzas";
            this.rdoTardanzas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 184;
            this.label2.Text = "Mes";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SETIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cboMes.Location = new System.Drawing.Point(87, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 183;
            // 
            // txtTopRegistros
            // 
            this.txtTopRegistros.Location = new System.Drawing.Point(261, 19);
            this.txtTopRegistros.Name = "txtTopRegistros";
            this.txtTopRegistros.Size = new System.Drawing.Size(100, 20);
            this.txtTopRegistros.TabIndex = 182;
            this.txtTopRegistros.Text = "6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Top";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::Sigesoft.Node.WinClient.UI.Resources.find;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(700, 16);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 180;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::Sigesoft.Node.WinClient.UI.Resources.color_swatch;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(13, 84);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 23);
            this.btnExportar.TabIndex = 182;
            this.btnExportar.Text = "Exportar Imagen";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmRecordsMarkings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 422);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Name = "frmRecordsMarkings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Records de marcaciones";
            this.Load += new System.EventHandler(this.frmRecordsMarkings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.TextBox txtTopRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.RadioButton rdoPuntuales;
        private System.Windows.Forms.RadioButton rdoHorasExtras;
        private System.Windows.Forms.RadioButton rdoTardanzas;
        private System.Windows.Forms.Button btnExportar;

    }
}