namespace Sigesoft.Node.WinClient.UI.Operations
{
    partial class frmAntecedentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntecedentes));
            this.txtAntFamiliares = new System.Windows.Forms.TextBox();
            this.label170 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.txtAntPersonales = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAntFamiliares
            // 
            this.txtAntFamiliares.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAntFamiliares.Location = new System.Drawing.Point(12, 116);
            this.txtAntFamiliares.Multiline = true;
            this.txtAntFamiliares.Name = "txtAntFamiliares";
            this.txtAntFamiliares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntFamiliares.Size = new System.Drawing.Size(464, 72);
            this.txtAntFamiliares.TabIndex = 212;
            this.txtAntFamiliares.Text = "NO REFIERE ANTECEDENTES";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.BackColor = System.Drawing.Color.Linen;
            this.label170.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.ForeColor = System.Drawing.Color.Navy;
            this.label170.Location = new System.Drawing.Point(11, 100);
            this.label170.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(65, 13);
            this.label170.TabIndex = 211;
            this.label170.Text = "FAMILIARES:";
            this.label170.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.BackColor = System.Drawing.Color.Linen;
            this.label169.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.ForeColor = System.Drawing.Color.Navy;
            this.label169.Location = new System.Drawing.Point(11, 9);
            this.label169.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(68, 13);
            this.label169.TabIndex = 210;
            this.label169.Text = "PERSONALES:";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAntPersonales
            // 
            this.txtAntPersonales.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAntPersonales.Location = new System.Drawing.Point(12, 25);
            this.txtAntPersonales.Multiline = true;
            this.txtAntPersonales.Name = "txtAntPersonales";
            this.txtAntPersonales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntPersonales.Size = new System.Drawing.Size(464, 72);
            this.txtAntPersonales.TabIndex = 209;
            this.txtAntPersonales.Text = "NO REFIERE ANTECEDENTES";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(396, 192);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 214;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::Sigesoft.Node.WinClient.UI.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(312, 192);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 213;
            this.btnOK.Text = "Guardar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmAntecedentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 226);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAntFamiliares);
            this.Controls.Add(this.label170);
            this.Controls.Add(this.label169);
            this.Controls.Add(this.txtAntPersonales);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAntecedentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAntecedentes";
            this.Load += new System.EventHandler(this.frmAntecedentes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAntFamiliares;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.TextBox txtAntPersonales;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}