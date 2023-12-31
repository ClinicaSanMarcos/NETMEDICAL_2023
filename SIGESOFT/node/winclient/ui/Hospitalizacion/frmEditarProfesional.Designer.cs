﻿namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    partial class frmEditarProfesional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProfesional));
            this.ddlUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreProfesional = new System.Windows.Forms.Label();
            this.ddlServiceTypeId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.txtClinica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.uvPacient = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ddlMasterServiceId = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbMedTratante = new System.Windows.Forms.RadioButton();
            this.rbMedSolicitante = new System.Windows.Forms.RadioButton();
            this.Observaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uvPacient)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlUsuario
            // 
            this.ddlUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUsuario.FormattingEnabled = true;
            this.ddlUsuario.Location = new System.Drawing.Point(92, 11);
            this.ddlUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.ddlUsuario.Name = "ddlUsuario";
            this.ddlUsuario.Size = new System.Drawing.Size(274, 21);
            this.ddlUsuario.TabIndex = 32;
            this.uvPacient.GetValidationSettings(this.ddlUsuario).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvPacient.GetValidationSettings(this.ddlUsuario).IsRequired = true;
            this.ddlUsuario.SelectedValueChanged += new System.EventHandler(this.ddlUsuario_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Usuario";
            // 
            // lblNombreProfesional
            // 
            this.lblNombreProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProfesional.ForeColor = System.Drawing.Color.Black;
            this.lblNombreProfesional.Location = new System.Drawing.Point(22, 47);
            this.lblNombreProfesional.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProfesional.Name = "lblNombreProfesional";
            this.lblNombreProfesional.Size = new System.Drawing.Size(344, 20);
            this.lblNombreProfesional.TabIndex = 33;
            this.lblNombreProfesional.Text = "Nombres y Apellidos del Profesional";
            // 
            // ddlServiceTypeId
            // 
            this.ddlServiceTypeId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlServiceTypeId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlServiceTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlServiceTypeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlServiceTypeId.FormattingEnabled = true;
            this.ddlServiceTypeId.Location = new System.Drawing.Point(92, 69);
            this.ddlServiceTypeId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlServiceTypeId.Name = "ddlServiceTypeId";
            this.ddlServiceTypeId.Size = new System.Drawing.Size(274, 21);
            this.ddlServiceTypeId.TabIndex = 35;
            this.uvPacient.GetValidationSettings(this.ddlServiceTypeId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvPacient.GetValidationSettings(this.ddlServiceTypeId).IsRequired = true;
            this.ddlServiceTypeId.SelectedIndexChanged += new System.EventHandler(this.cboTipoServicio_SelectedIndexChanged);
            this.ddlServiceTypeId.TextChanged += new System.EventHandler(this.ddlServiceTypeId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tipo Servicio";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMedico);
            this.groupBox1.Controls.Add(this.txtClinica);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(22, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 51);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Porcentajes %";
            // 
            // txtMedico
            // 
            this.txtMedico.Location = new System.Drawing.Point(237, 23);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Size = new System.Drawing.Size(100, 20);
            this.txtMedico.TabIndex = 40;
            this.uvPacient.GetValidationSettings(this.txtMedico).DataType = typeof(decimal);
            this.uvPacient.GetValidationSettings(this.txtMedico).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvPacient.GetValidationSettings(this.txtMedico).IsRequired = true;
            // 
            // txtClinica
            // 
            this.txtClinica.Location = new System.Drawing.Point(50, 23);
            this.txtClinica.Name = "txtClinica";
            this.txtClinica.Size = new System.Drawing.Size(100, 20);
            this.txtClinica.TabIndex = 39;
            this.uvPacient.GetValidationSettings(this.txtClinica).DataType = typeof(decimal);
            this.uvPacient.GetValidationSettings(this.txtClinica).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvPacient.GetValidationSettings(this.txtClinica).IsRequired = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(181, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Médico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Clínica";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::Sigesoft.Node.WinClient.UI.Resources.bullet_cross;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(209, 347);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(76, 28);
            this.btnSalir.TabIndex = 106;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ForeColor = System.Drawing.Color.Black;
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(289, 347);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(76, 28);
            this.btnGrabar.TabIndex = 105;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // ddlMasterServiceId
            // 
            this.ddlMasterServiceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMasterServiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMasterServiceId.FormattingEnabled = true;
            this.ddlMasterServiceId.Location = new System.Drawing.Point(91, 94);
            this.ddlMasterServiceId.Margin = new System.Windows.Forms.Padding(2);
            this.ddlMasterServiceId.Name = "ddlMasterServiceId";
            this.ddlMasterServiceId.Size = new System.Drawing.Size(274, 21);
            this.ddlMasterServiceId.TabIndex = 32;
            this.uvPacient.GetValidationSettings(this.ddlMasterServiceId).Condition = new Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.NotEquals, "--Seleccionar--", true, typeof(string));
            this.uvPacient.GetValidationSettings(this.ddlMasterServiceId).IsRequired = true;
            this.ddlMasterServiceId.SelectedIndexChanged += new System.EventHandler(this.ddlMasterServiceId_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Servicio";
            // 
            // rbMedTratante
            // 
            this.rbMedTratante.AutoSize = true;
            this.rbMedTratante.Location = new System.Drawing.Point(33, 134);
            this.rbMedTratante.Name = "rbMedTratante";
            this.rbMedTratante.Size = new System.Drawing.Size(92, 17);
            this.rbMedTratante.TabIndex = 41;
            this.rbMedTratante.TabStop = true;
            this.rbMedTratante.Text = "Med. Tratante";
            this.rbMedTratante.UseVisualStyleBackColor = true;
            // 
            // rbMedSolicitante
            // 
            this.rbMedSolicitante.AutoSize = true;
            this.rbMedSolicitante.Location = new System.Drawing.Point(226, 134);
            this.rbMedSolicitante.Name = "rbMedSolicitante";
            this.rbMedSolicitante.Size = new System.Drawing.Size(101, 17);
            this.rbMedSolicitante.TabIndex = 42;
            this.rbMedSolicitante.TabStop = true;
            this.rbMedSolicitante.Text = "Med. Solicitante";
            this.rbMedSolicitante.UseVisualStyleBackColor = true;
            // 
            // Observaciones
            // 
            this.Observaciones.AutoSize = true;
            this.Observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Observaciones.ForeColor = System.Drawing.Color.Black;
            this.Observaciones.Location = new System.Drawing.Point(27, 211);
            this.Observaciones.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Size = new System.Drawing.Size(78, 13);
            this.Observaciones.TabIndex = 108;
            this.Observaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(21, 227);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(345, 100);
            this.txtObservaciones.TabIndex = 41;
            this.txtObservaciones.Text = "- - -";
            this.uvPacient.GetValidationSettings(this.txtObservaciones).DataType = typeof(decimal);
            this.uvPacient.GetValidationSettings(this.txtObservaciones).EmptyValueCriteria = Infragistics.Win.Misc.EmptyValueCriteria.NullOrEmptyString;
            this.uvPacient.GetValidationSettings(this.txtObservaciones).IsRequired = true;
            // 
            // frmEditarProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 386);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.Observaciones);
            this.Controls.Add(this.rbMedSolicitante);
            this.Controls.Add(this.ddlMasterServiceId);
            this.Controls.Add(this.rbMedTratante);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ddlServiceTypeId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNombreProfesional);
            this.Controls.Add(this.ddlUsuario);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditarProfesional";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profesional";
            this.Load += new System.EventHandler(this.frmEditarProfesional_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uvPacient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreProfesional;
        private System.Windows.Forms.ComboBox ddlServiceTypeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMedico;
        private System.Windows.Forms.TextBox txtClinica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private Infragistics.Win.Misc.UltraValidator uvPacient;
        private System.Windows.Forms.ComboBox ddlMasterServiceId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbMedSolicitante;
        private System.Windows.Forms.RadioButton rbMedTratante;
        private System.Windows.Forms.Label Observaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}