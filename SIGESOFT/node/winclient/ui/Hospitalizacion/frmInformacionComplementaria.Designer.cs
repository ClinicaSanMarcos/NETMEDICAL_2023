namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    partial class frmInformacionComplementaria
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbEmergencia = new System.Windows.Forms.RadioButton();
            this.rbAmbulatorio = new System.Windows.Forms.RadioButton();
            this.rbAlquiler = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbNoQuirurgico = new System.Windows.Forms.RadioButton();
            this.rbQuirurgico = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "TIPO DE PROCEDIMIENTO DE PACIENTE";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(168, 171);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(311, 171);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 23);
            this.btnAceptar.TabIndex = 21;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "TIPO INGRESO DE PACIENTE";
            // 
            // rbEmergencia
            // 
            this.rbEmergencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbEmergencia.AutoSize = true;
            this.rbEmergencia.Location = new System.Drawing.Point(232, 53);
            this.rbEmergencia.Name = "rbEmergencia";
            this.rbEmergencia.Size = new System.Drawing.Size(96, 17);
            this.rbEmergencia.TabIndex = 19;
            this.rbEmergencia.Text = "EMERGENCIA";
            this.rbEmergencia.UseVisualStyleBackColor = true;
            // 
            // rbAmbulatorio
            // 
            this.rbAmbulatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAmbulatorio.AutoSize = true;
            this.rbAmbulatorio.Location = new System.Drawing.Point(51, 53);
            this.rbAmbulatorio.Name = "rbAmbulatorio";
            this.rbAmbulatorio.Size = new System.Drawing.Size(103, 17);
            this.rbAmbulatorio.TabIndex = 18;
            this.rbAmbulatorio.Text = "AMBULATORIO";
            this.rbAmbulatorio.UseVisualStyleBackColor = true;
            this.rbAmbulatorio.CheckedChanged += new System.EventHandler(this.rbAmbulatorio_CheckedChanged);
            // 
            // rbAlquiler
            // 
            this.rbAlquiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAlquiler.AutoSize = true;
            this.rbAlquiler.Location = new System.Drawing.Point(397, 53);
            this.rbAlquiler.Name = "rbAlquiler";
            this.rbAlquiler.Size = new System.Drawing.Size(78, 17);
            this.rbAlquiler.TabIndex = 26;
            this.rbAlquiler.Text = "ALQUILER";
            this.rbAlquiler.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbAlquiler);
            this.panel1.Controls.Add(this.rbEmergencia);
            this.panel1.Controls.Add(this.rbAmbulatorio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 84);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbNoQuirurgico);
            this.panel2.Controls.Add(this.rbQuirurgico);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 79);
            this.panel2.TabIndex = 28;
            // 
            // rbNoQuirurgico
            // 
            this.rbNoQuirurgico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbNoQuirurgico.AutoSize = true;
            this.rbNoQuirurgico.Location = new System.Drawing.Point(311, 51);
            this.rbNoQuirurgico.Name = "rbNoQuirurgico";
            this.rbNoQuirurgico.Size = new System.Drawing.Size(113, 17);
            this.rbNoQuirurgico.TabIndex = 25;
            this.rbNoQuirurgico.Text = "NO QUIRURGICO";
            this.rbNoQuirurgico.UseVisualStyleBackColor = true;
            // 
            // rbQuirurgico
            // 
            this.rbQuirurgico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbQuirurgico.AutoSize = true;
            this.rbQuirurgico.Location = new System.Drawing.Point(130, 51);
            this.rbQuirurgico.Name = "rbQuirurgico";
            this.rbQuirurgico.Size = new System.Drawing.Size(94, 17);
            this.rbQuirurgico.TabIndex = 24;
            this.rbQuirurgico.Text = "QUIRURGICO";
            this.rbQuirurgico.UseVisualStyleBackColor = true;
            // 
            // frmInformacionComplementaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 203);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmInformacionComplementaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInformacionComplementaria";
            this.Load += new System.EventHandler(this.frmInformacionComplementaria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbEmergencia;
        private System.Windows.Forms.RadioButton rbAmbulatorio;
        private System.Windows.Forms.RadioButton rbAlquiler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbNoQuirurgico;
        private System.Windows.Forms.RadioButton rbQuirurgico;
    }
}