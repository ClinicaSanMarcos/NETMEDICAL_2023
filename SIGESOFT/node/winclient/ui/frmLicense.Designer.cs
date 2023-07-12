namespace Sigesoft.Node.WinClient.UI
{
    partial class frmLicense
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
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.btnLicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLicense
            // 
            this.txtLicense.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtLicense.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtLicense.Location = new System.Drawing.Point(13, 12);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(27, 18);
            this.txtLicense.TabIndex = 0;
            this.txtLicense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLicense.Visible = false;
            // 
            // btnLicense
            // 
            this.btnLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicense.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.add;
            this.btnLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLicense.Location = new System.Drawing.Point(111, 21);
            this.btnLicense.Name = "btnLicense";
            this.btnLicense.Size = new System.Drawing.Size(133, 36);
            this.btnLicense.TabIndex = 1;
            this.btnLicense.Text = "Confirmar";
            this.btnLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLicense.UseVisualStyleBackColor = true;
            this.btnLicense.Click += new System.EventHandler(this.btnLicense_Click);
            // 
            // frmLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 69);
            this.ControlBox = false;
            this.Controls.Add(this.btnLicense);
            this.Controls.Add(this.txtLicense);
            this.Name = "frmLicense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Licencia";
            this.Load += new System.EventHandler(this.frmLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Button btnLicense;
    }
}