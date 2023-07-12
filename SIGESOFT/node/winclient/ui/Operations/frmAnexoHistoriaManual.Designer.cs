namespace Sigesoft.Node.WinClient.UI.Operations
{
    partial class frmAnexoHistoriaManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexoHistoriaManual));
            this.panelMensaje = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.pdfAnexoAdjunto = new AxAcroPDFLib.AxAcroPDF();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelMensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfAnexoAdjunto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMensaje
            // 
            this.panelMensaje.Controls.Add(this.label31);
            this.panelMensaje.Controls.Add(this.label32);
            this.panelMensaje.Location = new System.Drawing.Point(28, 65);
            this.panelMensaje.Name = "panelMensaje";
            this.panelMensaje.Size = new System.Drawing.Size(932, 605);
            this.panelMensaje.TabIndex = 107;
            this.panelMensaje.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(200, 341);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(498, 25);
            this.label31.TabIndex = 51;
            this.label31.Text = "CARGUE EL ARCHIVO EN LA PARTE SUPERIOR";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(287, 261);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(335, 25);
            this.label32.TabIndex = 50;
            this.label32.Text = "SIN DOCUMENTO A MOSTRAR.";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(861, 17);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 31);
            this.btnAceptar.TabIndex = 106;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFileName.Location = new System.Drawing.Point(85, 22);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(732, 20);
            this.txtFileName.TabIndex = 105;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(25, 26);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(44, 13);
            this.label30.TabIndex = 104;
            this.label30.Text = "Nombre";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowser.Image")));
            this.btnBrowser.Location = new System.Drawing.Point(823, 17);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(32, 31);
            this.btnBrowser.TabIndex = 103;
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // pdfAnexoAdjunto
            // 
            this.pdfAnexoAdjunto.Enabled = true;
            this.pdfAnexoAdjunto.Location = new System.Drawing.Point(28, 65);
            this.pdfAnexoAdjunto.Name = "pdfAnexoAdjunto";
            this.pdfAnexoAdjunto.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfAnexoAdjunto.OcxState")));
            this.pdfAnexoAdjunto.Size = new System.Drawing.Size(932, 605);
            this.pdfAnexoAdjunto.TabIndex = 102;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAnexoHistoriaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 697);
            this.Controls.Add(this.panelMensaje);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.pdfAnexoAdjunto);
            this.Name = "frmAnexoHistoriaManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAnexoHistoriaManual";
            this.Load += new System.EventHandler(this.frmAnexoHistoriaManual_Load);
            this.panelMensaje.ResumeLayout(false);
            this.panelMensaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfAnexoAdjunto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMensaje;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnBrowser;
        private AxAcroPDFLib.AxAcroPDF pdfAnexoAdjunto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}