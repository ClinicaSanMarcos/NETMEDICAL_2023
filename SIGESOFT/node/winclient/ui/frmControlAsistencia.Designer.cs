namespace Sigesoft.Node.WinClient.UI
{
    partial class frmControlAsistencia
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_PersonId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Dialing");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_PersonName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_UserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_TypeMarking");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_ExtraHours");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_HoursAgainst");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ScheduleId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_StartHour");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_StartBreakHour");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_EndBreakHour");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_EndHour");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlAsistencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.gbIngesar = new System.Windows.Forms.GroupBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.btnGrupos = new System.Windows.Forms.Button();
            this.grdDataGroupControl = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnPagarHoras = new System.Windows.Forms.Button();
            this.btnVacaciones = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnSystemUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbIngesar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataGroupControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Location = new System.Drawing.Point(283, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTime.Location = new System.Drawing.Point(12, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 39);
            this.lblTime.TabIndex = 0;
            // 
            // gbIngesar
            // 
            this.gbIngesar.Controls.Add(this.btnRegistrar);
            this.gbIngesar.Controls.Add(this.label1);
            this.gbIngesar.Controls.Add(this.txtNroDoc);
            this.gbIngesar.Location = new System.Drawing.Point(13, 3);
            this.gbIngesar.Name = "gbIngesar";
            this.gbIngesar.Size = new System.Drawing.Size(264, 110);
            this.gbIngesar.TabIndex = 1;
            this.gbIngesar.TabStop = false;
            this.gbIngesar.Text = "Registrar";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(124, 65);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(119, 23);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nro de Documento";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(124, 20);
            this.txtNroDoc.MaxLength = 8;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(119, 20);
            this.txtNroDoc.TabIndex = 0;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDoc_KeyPress);
            // 
            // btnGrupos
            // 
            this.btnGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrupos.Location = new System.Drawing.Point(15, 595);
            this.btnGrupos.Name = "btnGrupos";
            this.btnGrupos.Size = new System.Drawing.Size(160, 36);
            this.btnGrupos.TabIndex = 2;
            this.btnGrupos.Text = "Gestionar Horarios de trabajo";
            this.btnGrupos.UseVisualStyleBackColor = true;
            this.btnGrupos.Click += new System.EventHandler(this.btnGrupos_Click);
            // 
            // grdDataGroupControl
            // 
            this.grdDataGroupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDataGroupControl.CausesValidation = false;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdDataGroupControl.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Format = "MM/dd/yyyy HH:mm:ss";
            ultraGridColumn2.Header.Caption = "Fecha - Hora";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 126;
            ultraGridColumn5.Header.Caption = "Trabajador";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 297;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn13.Header.Caption = "Usuario";
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn13.Width = 90;
            ultraGridColumn19.Header.Caption = "Tipo Marcación";
            ultraGridColumn19.Header.VisiblePosition = 5;
            ultraGridColumn19.Width = 142;
            ultraGridColumn20.Header.Caption = "Hrs Extras";
            ultraGridColumn20.Header.VisiblePosition = 6;
            ultraGridColumn21.Header.Caption = "Hrs Tardanza";
            ultraGridColumn21.Header.VisiblePosition = 7;
            ultraGridColumn3.Header.VisiblePosition = 8;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 9;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 10;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.VisiblePosition = 11;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 12;
            ultraGridColumn24.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn13,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdDataGroupControl.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdDataGroupControl.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdDataGroupControl.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            this.grdDataGroupControl.DisplayLayout.GroupByBox.Prompt = " ";
            this.grdDataGroupControl.DisplayLayout.InterBandSpacing = 10;
            this.grdDataGroupControl.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDataGroupControl.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdDataGroupControl.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdDataGroupControl.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdDataGroupControl.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdDataGroupControl.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdDataGroupControl.DisplayLayout.Override.CellAppearance = appearance3;
            this.grdDataGroupControl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.LightGray;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.DarkGray;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdDataGroupControl.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdDataGroupControl.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.AlphaLevel = ((short)(187));
            appearance5.BackColor = System.Drawing.Color.Gainsboro;
            appearance5.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdDataGroupControl.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdDataGroupControl.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.grdDataGroupControl.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.grdDataGroupControl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.FontData.BoldAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.grdDataGroupControl.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grdDataGroupControl.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdDataGroupControl.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdDataGroupControl.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDataGroupControl.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDataGroupControl.DisplayLayout.UseFixedHeaders = true;
            this.grdDataGroupControl.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdDataGroupControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDataGroupControl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grdDataGroupControl.Location = new System.Drawing.Point(15, 180);
            this.grdDataGroupControl.Margin = new System.Windows.Forms.Padding(2);
            this.grdDataGroupControl.Name = "grdDataGroupControl";
            this.grdDataGroupControl.Size = new System.Drawing.Size(911, 402);
            this.grdDataGroupControl.TabIndex = 160;
            this.grdDataGroupControl.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdDataGroupControl_InitializeRow);
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(63, 148);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(101, 20);
            this.dtDesde.TabIndex = 162;
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(239, 148);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(101, 20);
            this.dtHasta.TabIndex = 163;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 164;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Hasta";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(389, 146);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 166;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::Sigesoft.Node.WinClient.UI.Resources.page_excel;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(850, 595);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 36);
            this.btnExportar.TabIndex = 167;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnPagarHoras
            // 
            this.btnPagarHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagarHoras.Image = global::Sigesoft.Node.WinClient.UI.Resources.money;
            this.btnPagarHoras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagarHoras.Location = new System.Drawing.Point(198, 595);
            this.btnPagarHoras.Name = "btnPagarHoras";
            this.btnPagarHoras.Size = new System.Drawing.Size(94, 36);
            this.btnPagarHoras.TabIndex = 161;
            this.btnPagarHoras.Text = "Pagar Horas";
            this.btnPagarHoras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagarHoras.UseVisualStyleBackColor = true;
            this.btnPagarHoras.Click += new System.EventHandler(this.btnPagarHoras_Click);
            // 
            // btnVacaciones
            // 
            this.btnVacaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVacaciones.Image = global::Sigesoft.Node.WinClient.UI.Resources.user_home;
            this.btnVacaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVacaciones.Location = new System.Drawing.Point(312, 595);
            this.btnVacaciones.Name = "btnVacaciones";
            this.btnVacaciones.Size = new System.Drawing.Size(152, 36);
            this.btnVacaciones.TabIndex = 168;
            this.btnVacaciones.Text = "Personal en Vacaciones";
            this.btnVacaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVacaciones.UseVisualStyleBackColor = true;
            this.btnVacaciones.Click += new System.EventHandler(this.btnVacaciones_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecords.Image = global::Sigesoft.Node.WinClient.UI.Resources.chart_bar;
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(492, 595);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(84, 36);
            this.btnRecords.TabIndex = 169;
            this.btnRecords.Text = "Records";
            this.btnRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnSystemUser
            // 
            this.btnSystemUser.Image = global::Sigesoft.Node.WinClient.UI.Resources.group_add;
            this.btnSystemUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemUser.Location = new System.Drawing.Point(599, 595);
            this.btnSystemUser.Name = "btnSystemUser";
            this.btnSystemUser.Size = new System.Drawing.Size(135, 36);
            this.btnSystemUser.TabIndex = 170;
            this.btnSystemUser.Text = "Usuarios del sistema";
            this.btnSystemUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSystemUser.UseVisualStyleBackColor = true;
            this.btnSystemUser.Click += new System.EventHandler(this.btnSystemUser_Click);
            // 
            // frmControlAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 643);
            this.Controls.Add(this.btnSystemUser);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.btnVacaciones);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.btnPagarHoras);
            this.Controls.Add(this.grdDataGroupControl);
            this.Controls.Add(this.btnGrupos);
            this.Controls.Add(this.gbIngesar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmControlAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de asistencia y refrigerios";
            this.Load += new System.EventHandler(this.frmControlAsistencia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbIngesar.ResumeLayout(false);
            this.gbIngesar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataGroupControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox gbIngesar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnGrupos;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDataGroupControl;
        private System.Windows.Forms.Button btnPagarHoras;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFiltrar;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVacaciones;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnSystemUser;
    }
}