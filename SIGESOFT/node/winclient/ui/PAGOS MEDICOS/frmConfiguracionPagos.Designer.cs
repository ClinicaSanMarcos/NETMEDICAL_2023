namespace Sigesoft.Node.WinClient.UI.PAGOS_MEDICOS
{
    partial class frmConfiguracionPagos
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_CategoryName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_CategoryId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentName", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ServiceComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Segus");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionPagos));
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_idPagoExam");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_IdConfPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Examen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Observaciones");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ObservacionesCambios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_IsDeleted");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_InsertUserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_InsertUserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_InsertDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_UpdateUserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UpdateUserId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_UpdateDate");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.gdDataExamsNew = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnRemoverExamenAuxiliar = new System.Windows.Forms.Button();
            this.btnAgregarExamenAuxiliar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.Observaciones = new System.Windows.Forms.Label();
            this.rbMedSolicitante = new System.Windows.Forms.RadioButton();
            this.rbMedTratante = new System.Windows.Forms.RadioButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.txtClinica = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbExamenesSeleccionados = new System.Windows.Forms.GroupBox();
            this.lvExamenesSeleccionados = new System.Windows.Forms.ListView();
            this.chExamen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMedicalExamId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chServiceComponentConcatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ddlUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbXTurno = new System.Windows.Forms.RadioButton();
            this.groupTurno = new System.Windows.Forms.GroupBox();
            this.txtMontoTurno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbXHora = new System.Windows.Forms.RadioButton();
            this.rbXExamen = new System.Windows.Forms.RadioButton();
            this.groupHora = new System.Windows.Forms.GroupBox();
            this.txtMontoHora = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupExamen = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkRecibo = new System.Windows.Forms.CheckBox();
            this.chkFactura = new System.Windows.Forms.CheckBox();
            this.chkBoleta = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdExamenes = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdDataExamsNew)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbExamenesSeleccionados.SuspendLayout();
            this.groupTurno.SuspendLayout();
            this.groupHora.SuspendLayout();
            this.groupExamen.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExamenes)).BeginInit();
            this.SuspendLayout();
            // 
            // gdDataExamsNew
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gdDataExamsNew.DisplayLayout.Appearance = appearance1;
            ultraGridColumn14.Header.Caption = "Categoría";
            ultraGridColumn14.Header.Fixed = true;
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn14.Width = 208;
            ultraGridColumn15.Header.Fixed = true;
            ultraGridColumn15.Header.VisiblePosition = 3;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Caption = "Examen";
            ultraGridColumn16.Header.Fixed = true;
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn16.Width = 302;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 5;
            ultraGridColumn18.Header.VisiblePosition = 0;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.Width = 57;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn18});
            ultraGridBand1.Expandable = false;
            ultraGridBand1.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.WithCellData;
            this.gdDataExamsNew.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gdDataExamsNew.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gdDataExamsNew.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False;
            this.gdDataExamsNew.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.gdDataExamsNew.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gdDataExamsNew.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.gdDataExamsNew.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gdDataExamsNew.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.gdDataExamsNew.DisplayLayout.MaxColScrollRegions = 1;
            this.gdDataExamsNew.DisplayLayout.MaxRowScrollRegions = 1;
            this.gdDataExamsNew.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gdDataExamsNew.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gdDataExamsNew.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.gdDataExamsNew.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.gdDataExamsNew.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.gdDataExamsNew.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.gdDataExamsNew.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.gdDataExamsNew.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gdDataExamsNew.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.gdDataExamsNew.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gdDataExamsNew.DisplayLayout.Override.CellAppearance = appearance8;
            this.gdDataExamsNew.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gdDataExamsNew.DisplayLayout.Override.CellPadding = 0;
            this.gdDataExamsNew.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row;
            this.gdDataExamsNew.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.gdDataExamsNew.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.gdDataExamsNew.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.gdDataExamsNew.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.gdDataExamsNew.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gdDataExamsNew.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.gdDataExamsNew.DisplayLayout.Override.RowAppearance = appearance11;
            this.gdDataExamsNew.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.gdDataExamsNew.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gdDataExamsNew.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.gdDataExamsNew.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gdDataExamsNew.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.gdDataExamsNew.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gdDataExamsNew.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.gdDataExamsNew.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gdDataExamsNew.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gdDataExamsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdDataExamsNew.Location = new System.Drawing.Point(10, 12);
            this.gdDataExamsNew.Name = "gdDataExamsNew";
            this.gdDataExamsNew.Size = new System.Drawing.Size(475, 270);
            this.gdDataExamsNew.TabIndex = 145;
            this.gdDataExamsNew.Text = "ultraGrid1";
            this.gdDataExamsNew.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.gdDataExamsNew_AfterSelectChange);
            // 
            // btnRemoverExamenAuxiliar
            // 
            this.btnRemoverExamenAuxiliar.Enabled = false;
            this.btnRemoverExamenAuxiliar.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverExamenAuxiliar.Image")));
            this.btnRemoverExamenAuxiliar.Location = new System.Drawing.Point(490, 140);
            this.btnRemoverExamenAuxiliar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverExamenAuxiliar.Name = "btnRemoverExamenAuxiliar";
            this.btnRemoverExamenAuxiliar.Size = new System.Drawing.Size(25, 22);
            this.btnRemoverExamenAuxiliar.TabIndex = 144;
            this.btnRemoverExamenAuxiliar.UseVisualStyleBackColor = true;
            this.btnRemoverExamenAuxiliar.Click += new System.EventHandler(this.btnRemoverExamenAuxiliar_Click);
            // 
            // btnAgregarExamenAuxiliar
            // 
            this.btnAgregarExamenAuxiliar.Enabled = false;
            this.btnAgregarExamenAuxiliar.Image = global::Sigesoft.Node.WinClient.UI.Resources.play_green;
            this.btnAgregarExamenAuxiliar.Location = new System.Drawing.Point(491, 97);
            this.btnAgregarExamenAuxiliar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarExamenAuxiliar.Name = "btnAgregarExamenAuxiliar";
            this.btnAgregarExamenAuxiliar.Size = new System.Drawing.Size(25, 22);
            this.btnAgregarExamenAuxiliar.TabIndex = 143;
            this.btnAgregarExamenAuxiliar.UseVisualStyleBackColor = true;
            this.btnAgregarExamenAuxiliar.Click += new System.EventHandler(this.btnAgregarExamenAuxiliar_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(8, 562);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(848, 68);
            this.txtObservaciones.TabIndex = 147;
            this.txtObservaciones.Text = "- - -";
            // 
            // Observaciones
            // 
            this.Observaciones.AutoSize = true;
            this.Observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Observaciones.ForeColor = System.Drawing.Color.Black;
            this.Observaciones.Location = new System.Drawing.Point(11, 543);
            this.Observaciones.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Size = new System.Drawing.Size(78, 13);
            this.Observaciones.TabIndex = 152;
            this.Observaciones.Text = "Observaciones";
            // 
            // rbMedSolicitante
            // 
            this.rbMedSolicitante.AutoSize = true;
            this.rbMedSolicitante.Location = new System.Drawing.Point(11, 51);
            this.rbMedSolicitante.Name = "rbMedSolicitante";
            this.rbMedSolicitante.Size = new System.Drawing.Size(101, 17);
            this.rbMedSolicitante.TabIndex = 149;
            this.rbMedSolicitante.TabStop = true;
            this.rbMedSolicitante.Text = "Med. Solicitante";
            this.rbMedSolicitante.UseVisualStyleBackColor = true;
            this.rbMedSolicitante.CheckedChanged += new System.EventHandler(this.rbMedSolicitante_CheckedChanged);
            // 
            // rbMedTratante
            // 
            this.rbMedTratante.AutoSize = true;
            this.rbMedTratante.Location = new System.Drawing.Point(11, 19);
            this.rbMedTratante.Name = "rbMedTratante";
            this.rbMedTratante.Size = new System.Drawing.Size(92, 17);
            this.rbMedTratante.TabIndex = 148;
            this.rbMedTratante.TabStop = true;
            this.rbMedTratante.Text = "Med. Tratante";
            this.rbMedTratante.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::Sigesoft.Node.WinClient.UI.Resources.bullet_cross;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(703, 635);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(76, 28);
            this.btnSalir.TabIndex = 151;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ForeColor = System.Drawing.Color.Black;
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(783, 635);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(76, 28);
            this.btnGrabar.TabIndex = 150;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.txtMedico);
            this.groupBox1.Controls.Add(this.txtClinica);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 51);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Porcentajes %";
            // 
            // txtMedico
            // 
            this.txtMedico.Location = new System.Drawing.Point(279, 19);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Size = new System.Drawing.Size(100, 20);
            this.txtMedico.TabIndex = 40;
            // 
            // txtClinica
            // 
            this.txtClinica.Location = new System.Drawing.Point(59, 19);
            this.txtClinica.Name = "txtClinica";
            this.txtClinica.Size = new System.Drawing.Size(100, 20);
            this.txtClinica.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Clínica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(223, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Médico";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbExamenesSeleccionados);
            this.groupBox2.Controls.Add(this.btnAgregarExamenAuxiliar);
            this.groupBox2.Controls.Add(this.gdDataExamsNew);
            this.groupBox2.Controls.Add(this.btnRemoverExamenAuxiliar);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(9, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(848, 294);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // gbExamenesSeleccionados
            // 
            this.gbExamenesSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExamenesSeleccionados.Controls.Add(this.lvExamenesSeleccionados);
            this.gbExamenesSeleccionados.Location = new System.Drawing.Point(521, 12);
            this.gbExamenesSeleccionados.Name = "gbExamenesSeleccionados";
            this.gbExamenesSeleccionados.Size = new System.Drawing.Size(321, 277);
            this.gbExamenesSeleccionados.TabIndex = 146;
            this.gbExamenesSeleccionados.TabStop = false;
            this.gbExamenesSeleccionados.Text = "Examenes seleccionados";
            // 
            // lvExamenesSeleccionados
            // 
            this.lvExamenesSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExamenesSeleccionados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chExamen,
            this.chMedicalExamId,
            this.chServiceComponentConcatId});
            this.lvExamenesSeleccionados.FullRowSelect = true;
            this.lvExamenesSeleccionados.Location = new System.Drawing.Point(7, 17);
            this.lvExamenesSeleccionados.Name = "lvExamenesSeleccionados";
            this.lvExamenesSeleccionados.Size = new System.Drawing.Size(308, 254);
            this.lvExamenesSeleccionados.TabIndex = 0;
            this.lvExamenesSeleccionados.UseCompatibleStateImageBehavior = false;
            this.lvExamenesSeleccionados.View = System.Windows.Forms.View.Details;
            // 
            // chExamen
            // 
            this.chExamen.Text = "Examen";
            this.chExamen.Width = 272;
            // 
            // chMedicalExamId
            // 
            this.chMedicalExamId.Text = "MedicalExamId";
            this.chMedicalExamId.Width = 0;
            // 
            // chServiceComponentConcatId
            // 
            this.chServiceComponentConcatId.Text = "ServiceComponentConcatId";
            this.chServiceComponentConcatId.Width = 0;
            // 
            // ddlUsuario
            // 
            this.ddlUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUsuario.FormattingEnabled = true;
            this.ddlUsuario.Location = new System.Drawing.Point(90, 11);
            this.ddlUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.ddlUsuario.Name = "ddlUsuario";
            this.ddlUsuario.Size = new System.Drawing.Size(770, 21);
            this.ddlUsuario.TabIndex = 156;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 155;
            this.label3.Text = "Usuario";
            // 
            // rbXTurno
            // 
            this.rbXTurno.AutoSize = true;
            this.rbXTurno.Checked = true;
            this.rbXTurno.Location = new System.Drawing.Point(17, 61);
            this.rbXTurno.Name = "rbXTurno";
            this.rbXTurno.Size = new System.Drawing.Size(91, 17);
            this.rbXTurno.TabIndex = 157;
            this.rbXTurno.TabStop = true;
            this.rbXTurno.Text = "Pago X Turno";
            this.rbXTurno.UseVisualStyleBackColor = true;
            this.rbXTurno.CheckedChanged += new System.EventHandler(this.rbXTurno_CheckedChanged);
            // 
            // groupTurno
            // 
            this.groupTurno.BackColor = System.Drawing.Color.Azure;
            this.groupTurno.Controls.Add(this.txtMontoTurno);
            this.groupTurno.Controls.Add(this.label5);
            this.groupTurno.Location = new System.Drawing.Point(114, 60);
            this.groupTurno.Name = "groupTurno";
            this.groupTurno.Size = new System.Drawing.Size(316, 66);
            this.groupTurno.TabIndex = 158;
            this.groupTurno.TabStop = false;
            this.groupTurno.Text = "CONFIGURACION POR TURNO";
            // 
            // txtMontoTurno
            // 
            this.txtMontoTurno.Location = new System.Drawing.Point(85, 26);
            this.txtMontoTurno.Name = "txtMontoTurno";
            this.txtMontoTurno.Size = new System.Drawing.Size(225, 20);
            this.txtMontoTurno.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Monto S/. ";
            // 
            // rbXHora
            // 
            this.rbXHora.AutoSize = true;
            this.rbXHora.Location = new System.Drawing.Point(17, 162);
            this.rbXHora.Name = "rbXHora";
            this.rbXHora.Size = new System.Drawing.Size(86, 17);
            this.rbXHora.TabIndex = 159;
            this.rbXHora.Text = "Pago X Hora";
            this.rbXHora.UseVisualStyleBackColor = true;
            this.rbXHora.CheckedChanged += new System.EventHandler(this.rbXHora_CheckedChanged);
            // 
            // rbXExamen
            // 
            this.rbXExamen.AutoSize = true;
            this.rbXExamen.Location = new System.Drawing.Point(445, 37);
            this.rbXExamen.Name = "rbXExamen";
            this.rbXExamen.Size = new System.Drawing.Size(112, 17);
            this.rbXExamen.TabIndex = 160;
            this.rbXExamen.Text = "Pago X Examenes";
            this.rbXExamen.UseVisualStyleBackColor = true;
            this.rbXExamen.CheckedChanged += new System.EventHandler(this.rbXExamen_CheckedChanged);
            // 
            // groupHora
            // 
            this.groupHora.BackColor = System.Drawing.Color.Azure;
            this.groupHora.Controls.Add(this.txtMontoHora);
            this.groupHora.Controls.Add(this.label1);
            this.groupHora.Location = new System.Drawing.Point(114, 149);
            this.groupHora.Name = "groupHora";
            this.groupHora.Size = new System.Drawing.Size(316, 69);
            this.groupHora.TabIndex = 159;
            this.groupHora.TabStop = false;
            this.groupHora.Text = "CONFIGURACION POR HORA";
            // 
            // txtMontoHora
            // 
            this.txtMontoHora.Location = new System.Drawing.Point(85, 31);
            this.txtMontoHora.Name = "txtMontoHora";
            this.txtMontoHora.Size = new System.Drawing.Size(225, 20);
            this.txtMontoHora.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Monto S/. ";
            // 
            // groupExamen
            // 
            this.groupExamen.Controls.Add(this.groupBox7);
            this.groupExamen.Controls.Add(this.groupBox6);
            this.groupExamen.Controls.Add(this.groupBox1);
            this.groupExamen.Location = new System.Drawing.Point(445, 60);
            this.groupExamen.Name = "groupExamen";
            this.groupExamen.Size = new System.Drawing.Size(405, 158);
            this.groupExamen.TabIndex = 159;
            this.groupExamen.TabStop = false;
            this.groupExamen.Text = "CONFIGURACION POR EXAMEN";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Azure;
            this.groupBox7.Controls.Add(this.chkRecibo);
            this.groupBox7.Controls.Add(this.chkFactura);
            this.groupBox7.Controls.Add(this.chkBoleta);
            this.groupBox7.Location = new System.Drawing.Point(212, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(181, 83);
            this.groupBox7.TabIndex = 151;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DESCONTAR IGV";
            // 
            // chkRecibo
            // 
            this.chkRecibo.AutoSize = true;
            this.chkRecibo.Location = new System.Drawing.Point(7, 60);
            this.chkRecibo.Name = "chkRecibo";
            this.chkRecibo.Size = new System.Drawing.Size(60, 17);
            this.chkRecibo.TabIndex = 2;
            this.chkRecibo.Text = "Recibo";
            this.chkRecibo.UseVisualStyleBackColor = true;
            // 
            // chkFactura
            // 
            this.chkFactura.AutoSize = true;
            this.chkFactura.Location = new System.Drawing.Point(7, 37);
            this.chkFactura.Name = "chkFactura";
            this.chkFactura.Size = new System.Drawing.Size(62, 17);
            this.chkFactura.TabIndex = 1;
            this.chkFactura.Text = "Factura";
            this.chkFactura.UseVisualStyleBackColor = true;
            // 
            // chkBoleta
            // 
            this.chkBoleta.AutoSize = true;
            this.chkBoleta.Location = new System.Drawing.Point(7, 14);
            this.chkBoleta.Name = "chkBoleta";
            this.chkBoleta.Size = new System.Drawing.Size(56, 17);
            this.chkBoleta.TabIndex = 0;
            this.chkBoleta.Text = "Boleta";
            this.chkBoleta.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Azure;
            this.groupBox6.Controls.Add(this.rbMedTratante);
            this.groupBox6.Controls.Add(this.rbMedSolicitante);
            this.groupBox6.Location = new System.Drawing.Point(14, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(132, 74);
            this.groupBox6.TabIndex = 150;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ORDEN";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 316);
            this.tabControl1.TabIndex = 161;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(848, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar Examenes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.grdExamenes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(848, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista de Examenes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdExamenes
            // 
            this.grdExamenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExamenes.CausesValidation = false;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BackColor2 = System.Drawing.Color.Silver;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdExamenes.DisplayLayout.Appearance = appearance13;
            ultraGridColumn23.Header.VisiblePosition = 0;
            ultraGridColumn23.Width = 117;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 2;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.VisiblePosition = 3;
            ultraGridColumn25.Width = 284;
            ultraGridColumn31.Header.VisiblePosition = 4;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 5;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 6;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.VisiblePosition = 7;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn17.Header.VisiblePosition = 8;
            ultraGridColumn19.Header.VisiblePosition = 9;
            ultraGridColumn20.Header.VisiblePosition = 10;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn26.Header.VisiblePosition = 11;
            ultraGridColumn27.Header.VisiblePosition = 12;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn23,
            ultraGridColumn1,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn31,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn17,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn26,
            ultraGridColumn27});
            this.grdExamenes.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdExamenes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdExamenes.DisplayLayout.InterBandSpacing = 10;
            this.grdExamenes.DisplayLayout.MaxColScrollRegions = 1;
            this.grdExamenes.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdExamenes.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.grdExamenes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdExamenes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdExamenes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdExamenes.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdExamenes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdExamenes.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance14.BackColor = System.Drawing.Color.Transparent;
            this.grdExamenes.DisplayLayout.Override.CardAreaAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.White;
            appearance15.BackColor2 = System.Drawing.Color.White;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdExamenes.DisplayLayout.Override.CellAppearance = appearance15;
            this.grdExamenes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.BackColor2 = System.Drawing.Color.LightGray;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BorderColor = System.Drawing.Color.DarkGray;
            appearance16.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdExamenes.DisplayLayout.Override.HeaderAppearance = appearance16;
            this.grdExamenes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance17.AlphaLevel = ((short)(187));
            appearance17.BackColor = System.Drawing.Color.Gainsboro;
            appearance17.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdExamenes.DisplayLayout.Override.RowAlternateAppearance = appearance17;
            appearance18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdExamenes.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.grdExamenes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance19.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance19.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance19.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance19.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance19.FontData.BoldAsString = "False";
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.grdExamenes.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.grdExamenes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdExamenes.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdExamenes.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdExamenes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdExamenes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdExamenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdExamenes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grdExamenes.Location = new System.Drawing.Point(8, 5);
            this.grdExamenes.Margin = new System.Windows.Forms.Padding(2);
            this.grdExamenes.Name = "grdExamenes";
            this.grdExamenes.Size = new System.Drawing.Size(759, 280);
            this.grdExamenes.TabIndex = 106;
            this.grdExamenes.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.grdExamenes_AfterSelectChange);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = global::Sigesoft.Node.WinClient.UI.Resources.bullet_cross;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(770, 5);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(76, 28);
            this.btnEliminar.TabIndex = 109;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmConfiguracionPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(871, 664);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupExamen);
            this.Controls.Add(this.groupHora);
            this.Controls.Add(this.rbXExamen);
            this.Controls.Add(this.rbXHora);
            this.Controls.Add(this.groupTurno);
            this.Controls.Add(this.rbXTurno);
            this.Controls.Add(this.ddlUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.Observaciones);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.Name = "frmConfiguracionPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmConfiguracionPagos";
            this.Load += new System.EventHandler(this.frmConfiguracionPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdDataExamsNew)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbExamenesSeleccionados.ResumeLayout(false);
            this.groupTurno.ResumeLayout(false);
            this.groupTurno.PerformLayout();
            this.groupHora.ResumeLayout(false);
            this.groupHora.PerformLayout();
            this.groupExamen.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExamenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid gdDataExamsNew;
        private System.Windows.Forms.Button btnRemoverExamenAuxiliar;
        private System.Windows.Forms.Button btnAgregarExamenAuxiliar;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label Observaciones;
        private System.Windows.Forms.RadioButton rbMedSolicitante;
        private System.Windows.Forms.RadioButton rbMedTratante;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMedico;
        private System.Windows.Forms.TextBox txtClinica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddlUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbXTurno;
        private System.Windows.Forms.GroupBox groupTurno;
        private System.Windows.Forms.TextBox txtMontoTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbXHora;
        private System.Windows.Forms.RadioButton rbXExamen;
        private System.Windows.Forms.GroupBox groupHora;
        private System.Windows.Forms.TextBox txtMontoHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupExamen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkRecibo;
        private System.Windows.Forms.CheckBox chkFactura;
        private System.Windows.Forms.CheckBox chkBoleta;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox gbExamenesSeleccionados;
        private System.Windows.Forms.ListView lvExamenesSeleccionados;
        private System.Windows.Forms.ColumnHeader chExamen;
        private System.Windows.Forms.ColumnHeader chMedicalExamId;
        private System.Windows.Forms.ColumnHeader chServiceComponentConcatId;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdExamenes;
        private System.Windows.Forms.Button btnEliminar;
    }
}