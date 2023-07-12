namespace Sigesoft.Node.Contasol.Integration
{
    partial class frmRecetaMedica
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiagnosticRepositoryId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiseasesId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiseasesName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_UpdateUser");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_AutoManualName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_RestrictionsName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_RecomendationsName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_PreQualificationName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_FinalQualificationName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DiagnosticTypeName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_IsSentToAntecedentName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_ExpirationDateDiagnostic");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_GenerateMedicalBreak");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_RecordStatus");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_RecordType");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RecipeDetail");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_AddRecipe", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecetaMedica));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("RecipeDetail", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedicamento", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Cantidad");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Posologia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Duracion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("t_FechaFin");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_IdReceta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_SaldoPaciente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_IdProductoDetalle");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_EditRecipe", 0);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("_DeleteRecipe", 1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridGroup ultraGridGroup1 = new Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup0", 80761891);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AccionFarmaco");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Presentacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Concentracion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UM");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Laboratorio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Ubicacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lote");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCaducidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PrincipioActivo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Almacen");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_PrecioMayorista");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoDetalle");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            this.grdTotalDiagnosticos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbBuscarMedicamento = new Infragistics.Win.Misc.UltraGroupBox();
            this.chekMedicinaExterna = new System.Windows.Forms.CheckBox();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.btnRegistrarMedicamento = new Infragistics.Win.Misc.UltraButton();
            this.btnAceptar = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.txtBuscarAccionF = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.txtBuscarNombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.gbReceta = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtIdReceta = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtIdProductoDetalle = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtNuevoPrecio = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDctoEPS = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPPS = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPrecio = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.txtUnidadProductiva = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.txtMedicamento = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtDuracion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPosologia = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCantidad = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmRecetaMedica_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.chkConsolidado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalDiagnosticos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBuscarMedicamento)).BeginInit();
            this.gbBuscarMedicamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarAccionF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbReceta)).BeginInit();
            this.gbReceta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdReceta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdProductoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDctoEPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadProductiva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosologia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmRecetaMedica_Fill_Panel.ClientArea.SuspendLayout();
            this.frmRecetaMedica_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTotalDiagnosticos
            // 
            this.grdTotalDiagnosticos.CausesValidation = false;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdTotalDiagnosticos.DisplayLayout.Appearance = appearance1;
            ultraGridColumn24.Header.VisiblePosition = 1;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.VisiblePosition = 2;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Caption = "Consultorio";
            ultraGridColumn26.Header.VisiblePosition = 3;
            ultraGridColumn26.Width = 95;
            ultraGridColumn27.Header.Caption = "Diagnóstico";
            ultraGridColumn27.Header.VisiblePosition = 4;
            ultraGridColumn27.Width = 204;
            ultraGridColumn69.Header.Caption = "Usuario Act.";
            ultraGridColumn69.Header.VisiblePosition = 5;
            ultraGridColumn69.Width = 95;
            ultraGridColumn28.Header.Caption = "Automatico?";
            ultraGridColumn28.Header.VisiblePosition = 6;
            ultraGridColumn28.Width = 95;
            ultraGridColumn29.Header.Caption = "Restricciones";
            ultraGridColumn29.Header.VisiblePosition = 7;
            ultraGridColumn29.Width = 146;
            ultraGridColumn30.Header.Caption = "Recomendaciones";
            ultraGridColumn30.Header.VisiblePosition = 8;
            ultraGridColumn30.Width = 143;
            ultraGridColumn31.Header.Caption = "Pre-Calificación";
            ultraGridColumn31.Header.VisiblePosition = 9;
            ultraGridColumn31.Width = 49;
            ultraGridColumn32.Header.Caption = "Calificación Final";
            ultraGridColumn32.Header.VisiblePosition = 10;
            ultraGridColumn32.Width = 52;
            ultraGridColumn33.Header.Caption = "Tipo DX";
            ultraGridColumn33.Header.VisiblePosition = 11;
            ultraGridColumn33.Width = 58;
            ultraGridColumn34.Header.Caption = "Enviar a Ant";
            ultraGridColumn34.Header.VisiblePosition = 12;
            ultraGridColumn34.Width = 38;
            ultraGridColumn35.Header.Caption = "Fec Vcto";
            ultraGridColumn35.Header.VisiblePosition = 13;
            ultraGridColumn35.Width = 45;
            ultraGridColumn36.Header.VisiblePosition = 14;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.Header.VisiblePosition = 15;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.VisiblePosition = 16;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.VisiblePosition = 17;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 18;
            ultraGridColumn13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn13.CellButtonAppearance = appearance2;
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn13.Width = 28;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn69,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn12,
            ultraGridColumn13});
            ultraGridColumn14.Header.Caption = "Medicamento";
            ultraGridColumn14.Header.VisiblePosition = 2;
            ultraGridColumn14.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(234, 0);
            ultraGridColumn14.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn14.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn14.Width = 106;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn16.CellAppearance = appearance3;
            ultraGridColumn16.Header.Caption = "Cantidad";
            ultraGridColumn16.Header.VisiblePosition = 3;
            ultraGridColumn16.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn16.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.Header.Caption = "Posología";
            ultraGridColumn17.Header.VisiblePosition = 4;
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.Header.Caption = "Duración";
            ultraGridColumn18.Header.VisiblePosition = 5;
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.Header.Caption = "Fecha Fin.";
            ultraGridColumn19.Header.VisiblePosition = 9;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn19.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn41.Header.VisiblePosition = 6;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.VisiblePosition = 7;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.VisiblePosition = 8;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn20.CellButtonAppearance = appearance4;
            ultraGridColumn20.Header.Caption = "";
            ultraGridColumn20.Header.VisiblePosition = 0;
            ultraGridColumn20.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn20.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn20.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn20.Width = 29;
            ultraGridColumn23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraGridColumn23.CellButtonAppearance = appearance5;
            ultraGridColumn23.Header.Caption = "";
            ultraGridColumn23.Header.VisiblePosition = 1;
            ultraGridColumn23.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn23.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn23.Width = 27;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn14,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn20,
            ultraGridColumn23});
            ultraGridGroup1.Header.Caption = "Receta";
            ultraGridGroup1.Key = "NewGroup0";
            ultraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1;
            ultraGridGroup1.RowLayoutGroupInfo.OriginX = 0;
            ultraGridGroup1.RowLayoutGroupInfo.OriginY = 0;
            ultraGridGroup1.RowLayoutGroupInfo.SpanX = 14;
            ultraGridGroup1.RowLayoutGroupInfo.SpanY = 4;
            ultraGridBand2.Groups.AddRange(new Infragistics.Win.UltraWinGrid.UltraGridGroup[] {
            ultraGridGroup1});
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.grdTotalDiagnosticos.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdTotalDiagnosticos.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdTotalDiagnosticos.DisplayLayout.InterBandSpacing = 10;
            this.grdTotalDiagnosticos.DisplayLayout.MaxColScrollRegions = 1;
            this.grdTotalDiagnosticos.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdTotalDiagnosticos.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdTotalDiagnosticos.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CardAreaAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BackColor2 = System.Drawing.Color.White;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CellAppearance = appearance7;
            this.grdTotalDiagnosticos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdTotalDiagnosticos.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.HeadersOnly;
            this.grdTotalDiagnosticos.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.CheckOnDisplay;
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.LightGray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.DarkGray;
            appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdTotalDiagnosticos.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.grdTotalDiagnosticos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance9.AlphaLevel = ((short)(187));
            appearance9.BackColor = System.Drawing.Color.Gainsboro;
            appearance9.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowAlternateAppearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grdTotalDiagnosticos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            appearance11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance11.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance11.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance11.FontData.BoldAsString = "False";
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.grdTotalDiagnosticos.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdTotalDiagnosticos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdTotalDiagnosticos.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdTotalDiagnosticos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdTotalDiagnosticos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdTotalDiagnosticos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdTotalDiagnosticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTotalDiagnosticos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTotalDiagnosticos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.grdTotalDiagnosticos.Location = new System.Drawing.Point(0, 0);
            this.grdTotalDiagnosticos.Margin = new System.Windows.Forms.Padding(2);
            this.grdTotalDiagnosticos.Name = "grdTotalDiagnosticos";
            this.grdTotalDiagnosticos.Size = new System.Drawing.Size(1173, 128);
            this.grdTotalDiagnosticos.TabIndex = 51;
            this.grdTotalDiagnosticos.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdTotalDiagnosticos_InitializeLayout);
            this.grdTotalDiagnosticos.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdTotalDiagnosticos_ClickCellButton);
            this.grdTotalDiagnosticos.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grdTotalDiagnosticos_ClickCell);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.splitContainer3);
            this.ultraGroupBox1.Controls.Add(this.splitContainer1);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1347, 703);
            this.ultraGroupBox1.TabIndex = 52;
            this.ultraGroupBox1.Text = "Receta por Diagnóstico";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.grdTotalDiagnosticos);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chkConsolidado);
            this.splitContainer3.Panel2.Controls.Add(this.ultraButton2);
            this.splitContainer3.Panel2.Controls.Add(this.ultraButton1);
            this.splitContainer3.Size = new System.Drawing.Size(1341, 128);
            this.splitContainer3.SplitterDistance = 1173;
            this.splitContainer3.TabIndex = 56;
            // 
            // ultraButton2
            // 
            this.ultraButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButton2.Location = new System.Drawing.Point(128, 3);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(31, 26);
            this.ultraButton2.TabIndex = 54;
            this.ultraButton2.Text = "Confirmar Despacho";
            this.ultraButton2.Visible = false;
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButton1.Location = new System.Drawing.Point(7, 51);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(134, 63);
            this.ultraButton1.TabIndex = 53;
            this.ultraButton1.Text = "MOSTRAR RECETA";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(3, 150);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbBuscarMedicamento);
            this.splitContainer1.Panel1.Controls.Add(this.gbReceta);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1341, 550);
            this.splitContainer1.SplitterDistance = 721;
            this.splitContainer1.TabIndex = 55;
            // 
            // gbBuscarMedicamento
            // 
            this.gbBuscarMedicamento.Controls.Add(this.chekMedicinaExterna);
            this.gbBuscarMedicamento.Controls.Add(this.lblRecordCount);
            this.gbBuscarMedicamento.Controls.Add(this.ultraButton3);
            this.gbBuscarMedicamento.Controls.Add(this.btnRegistrarMedicamento);
            this.gbBuscarMedicamento.Controls.Add(this.btnAceptar);
            this.gbBuscarMedicamento.Controls.Add(this.ultraButton4);
            this.gbBuscarMedicamento.Controls.Add(this.txtBuscarAccionF);
            this.gbBuscarMedicamento.Controls.Add(this.ultraLabel12);
            this.gbBuscarMedicamento.Controls.Add(this.txtBuscarNombre);
            this.gbBuscarMedicamento.Controls.Add(this.ultraLabel13);
            this.gbBuscarMedicamento.Controls.Add(this.ultraGrid1);
            this.gbBuscarMedicamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBuscarMedicamento.Location = new System.Drawing.Point(0, 0);
            this.gbBuscarMedicamento.Name = "gbBuscarMedicamento";
            this.gbBuscarMedicamento.Size = new System.Drawing.Size(721, 306);
            this.gbBuscarMedicamento.TabIndex = 56;
            this.gbBuscarMedicamento.Text = "Buscar Medicamento";
            // 
            // chekMedicinaExterna
            // 
            this.chekMedicinaExterna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chekMedicinaExterna.AutoSize = true;
            this.chekMedicinaExterna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chekMedicinaExterna.ForeColor = System.Drawing.Color.Red;
            this.chekMedicinaExterna.Location = new System.Drawing.Point(6, 278);
            this.chekMedicinaExterna.Name = "chekMedicinaExterna";
            this.chekMedicinaExterna.Size = new System.Drawing.Size(123, 17);
            this.chekMedicinaExterna.TabIndex = 70;
            this.chekMedicinaExterna.Text = "Medicina externa";
            this.chekMedicinaExterna.UseVisualStyleBackColor = true;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.Location = new System.Drawing.Point(474, 48);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(241, 19);
            this.lblRecordCount.TabIndex = 69;
            this.lblRecordCount.Text = "No se ha realizado la búsqueda aún.";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRecordCount.Visible = false;
            // 
            // ultraButton3
            // 
            this.ultraButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButton3.Location = new System.Drawing.Point(377, 272);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(75, 28);
            this.ultraButton3.TabIndex = 5;
            this.ultraButton3.Text = "&Salir";
            this.ultraButton3.Visible = false;
            // 
            // btnRegistrarMedicamento
            // 
            this.btnRegistrarMedicamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarMedicamento.Location = new System.Drawing.Point(547, 272);
            this.btnRegistrarMedicamento.Name = "btnRegistrarMedicamento";
            this.btnRegistrarMedicamento.Size = new System.Drawing.Size(168, 28);
            this.btnRegistrarMedicamento.TabIndex = 3;
            this.btnRegistrarMedicamento.Text = "&Registrar Medicamento";
            this.btnRegistrarMedicamento.Click += new System.EventHandler(this.btnRegistrarMedicamento_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(458, 272);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 28);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Visible = false;
            // 
            // ultraButton4
            // 
            this.ultraButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButton4.Location = new System.Drawing.Point(631, 17);
            this.ultraButton4.Name = "ultraButton4";
            this.ultraButton4.Size = new System.Drawing.Size(75, 23);
            this.ultraButton4.TabIndex = 2;
            this.ultraButton4.Text = "Buscar";
            this.ultraButton4.Click += new System.EventHandler(this.ultraButton4_Click);
            // 
            // txtBuscarAccionF
            // 
            this.txtBuscarAccionF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarAccionF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarAccionF.Location = new System.Drawing.Point(377, 18);
            this.txtBuscarAccionF.Name = "txtBuscarAccionF";
            this.txtBuscarAccionF.Size = new System.Drawing.Size(248, 21);
            this.txtBuscarAccionF.TabIndex = 1;
            this.txtBuscarAccionF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarAccionF_KeyUp);
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.AutoSize = true;
            this.ultraLabel12.Location = new System.Drawing.Point(286, 23);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(85, 14);
            this.ultraLabel12.TabIndex = 5;
            this.ultraLabel12.Text = "Acción fármaco:";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarNombre.Location = new System.Drawing.Point(97, 18);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(173, 21);
            this.txtBuscarNombre.TabIndex = 0;
            this.txtBuscarNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarNombre_KeyUp);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 23);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel13.TabIndex = 3;
            this.ultraLabel13.Text = "Nombre:";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraGrid1.DisplayLayout.Appearance = appearance12;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Width = 293;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.Header.Caption = "Accion Farmaco/Principio Activo";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 157;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn4.Width = 129;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn15.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn15.Header.VisiblePosition = 5;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn6.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn9.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn10.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn21.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn21.Header.VisiblePosition = 11;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn22.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn22.Header.VisiblePosition = 12;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn11.Header.Caption = "Precio sugerido (Kairos)";
            ultraGridColumn11.Header.VisiblePosition = 13;
            ultraGridColumn40.Header.VisiblePosition = 14;
            ultraGridColumn40.Hidden = true;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn15,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn1,
            ultraGridColumn11,
            ultraGridColumn40});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance13;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance14;
            this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.NewBandLoadStyle = Infragistics.Win.UltraWinGrid.NewBandLoadStyle.Hide;
            this.ultraGrid1.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance16;
            appearance17.BackColor = System.Drawing.SystemColors.Highlight;
            appearance17.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance17;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance19;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
            this.ultraGrid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance20.BackColor = System.Drawing.SystemColors.Control;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance20;
            appearance21.TextHAlignAsString = "Left";
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance21;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance22;
            this.ultraGrid1.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance23;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGrid1.Location = new System.Drawing.Point(6, 70);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(709, 196);
            this.ultraGrid1.TabIndex = 3;
            this.ultraGrid1.Text = "ultraGrid1";
            this.ultraGrid1.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ultraGrid1_InitializeRow);
            this.ultraGrid1.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.ultraGrid1_DoubleClickCell);
            // 
            // gbReceta
            // 
            this.gbReceta.Controls.Add(this.txtIdReceta);
            this.gbReceta.Controls.Add(this.txtIdProductoDetalle);
            this.gbReceta.Controls.Add(this.txtNuevoPrecio);
            this.gbReceta.Controls.Add(this.txtDctoEPS);
            this.gbReceta.Controls.Add(this.ultraLabel10);
            this.gbReceta.Controls.Add(this.txtPPS);
            this.gbReceta.Controls.Add(this.ultraLabel11);
            this.gbReceta.Controls.Add(this.ultraLabel9);
            this.gbReceta.Controls.Add(this.ultraLabel8);
            this.gbReceta.Controls.Add(this.txtPrecio);
            this.gbReceta.Controls.Add(this.ultraLabel7);
            this.gbReceta.Controls.Add(this.txtUnidadProductiva);
            this.gbReceta.Controls.Add(this.ultraLabel6);
            this.gbReceta.Controls.Add(this.txtMedicamento);
            this.gbReceta.Controls.Add(this.btnGuardar);
            this.gbReceta.Controls.Add(this.dtpFechaFin);
            this.gbReceta.Controls.Add(this.txtDuracion);
            this.gbReceta.Controls.Add(this.txtPosologia);
            this.gbReceta.Controls.Add(this.txtCantidad);
            this.gbReceta.Controls.Add(this.ultraLabel5);
            this.gbReceta.Controls.Add(this.ultraLabel4);
            this.gbReceta.Controls.Add(this.ultraLabel3);
            this.gbReceta.Controls.Add(this.ultraLabel2);
            this.gbReceta.Controls.Add(this.ultraLabel1);
            this.gbReceta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbReceta.Location = new System.Drawing.Point(0, 306);
            this.gbReceta.Name = "gbReceta";
            this.gbReceta.Size = new System.Drawing.Size(721, 244);
            this.gbReceta.TabIndex = 55;
            this.gbReceta.Text = "Detalle de Medicamento a Recetar";
            // 
            // txtIdReceta
            // 
            appearance24.TextHAlignAsString = "Right";
            this.txtIdReceta.Appearance = appearance24;
            this.txtIdReceta.Location = new System.Drawing.Point(498, 6);
            this.txtIdReceta.Name = "txtIdReceta";
            this.txtIdReceta.Size = new System.Drawing.Size(59, 21);
            this.txtIdReceta.TabIndex = 13;
            this.txtIdReceta.Visible = false;
            // 
            // txtIdProductoDetalle
            // 
            appearance25.TextHAlignAsString = "Right";
            this.txtIdProductoDetalle.Appearance = appearance25;
            this.txtIdProductoDetalle.Location = new System.Drawing.Point(219, 52);
            this.txtIdProductoDetalle.Name = "txtIdProductoDetalle";
            this.txtIdProductoDetalle.Size = new System.Drawing.Size(59, 21);
            this.txtIdProductoDetalle.TabIndex = 12;
            this.txtIdProductoDetalle.Visible = false;
            // 
            // txtNuevoPrecio
            // 
            appearance26.TextHAlignAsString = "Right";
            this.txtNuevoPrecio.Appearance = appearance26;
            this.txtNuevoPrecio.Enabled = false;
            this.txtNuevoPrecio.Location = new System.Drawing.Point(498, 216);
            this.txtNuevoPrecio.Name = "txtNuevoPrecio";
            this.txtNuevoPrecio.Size = new System.Drawing.Size(52, 21);
            this.txtNuevoPrecio.TabIndex = 10;
            this.txtNuevoPrecio.Visible = false;
            // 
            // txtDctoEPS
            // 
            appearance27.TextHAlignAsString = "Right";
            this.txtDctoEPS.Appearance = appearance27;
            this.txtDctoEPS.Enabled = false;
            this.txtDctoEPS.Location = new System.Drawing.Point(343, 216);
            this.txtDctoEPS.Name = "txtDctoEPS";
            this.txtDctoEPS.Size = new System.Drawing.Size(52, 21);
            this.txtDctoEPS.TabIndex = 10;
            this.txtDctoEPS.Visible = false;
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Location = new System.Drawing.Point(423, 220);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(72, 14);
            this.ultraLabel10.TabIndex = 11;
            this.ultraLabel10.Text = "Nuevo Precio";
            this.ultraLabel10.Visible = false;
            // 
            // txtPPS
            // 
            appearance28.TextHAlignAsString = "Right";
            this.txtPPS.Appearance = appearance28;
            this.txtPPS.Enabled = false;
            this.txtPPS.Location = new System.Drawing.Point(226, 217);
            this.txtPPS.Name = "txtPPS";
            this.txtPPS.Size = new System.Drawing.Size(52, 21);
            this.txtPPS.TabIndex = 10;
            this.txtPPS.Visible = false;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.AutoSize = true;
            this.ultraLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel11.Location = new System.Drawing.Point(398, 220);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(14, 14);
            this.ultraLabel11.TabIndex = 11;
            this.ultraLabel11.Text = "%";
            this.ultraLabel11.Visible = false;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.Location = new System.Drawing.Point(284, 220);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel9.TabIndex = 11;
            this.ultraLabel9.Text = "Dcto EPS";
            this.ultraLabel9.Visible = false;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Location = new System.Drawing.Point(131, 221);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(89, 14);
            this.ultraLabel8.TabIndex = 11;
            this.ultraLabel8.Text = "Precio Púb. Sug.";
            this.ultraLabel8.Visible = false;
            // 
            // txtPrecio
            // 
            appearance29.TextHAlignAsString = "Right";
            this.txtPrecio.Appearance = appearance29;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(377, 49);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(144, 21);
            this.txtPrecio.TabIndex = 10;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Location = new System.Drawing.Point(286, 56);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(85, 14);
            this.ultraLabel7.TabIndex = 11;
            this.ultraLabel7.Text = "Precio de Venta";
            // 
            // txtUnidadProductiva
            // 
            appearance30.TextHAlignAsString = "Right";
            this.txtUnidadProductiva.Appearance = appearance30;
            this.txtUnidadProductiva.Location = new System.Drawing.Point(596, 49);
            this.txtUnidadProductiva.Name = "txtUnidadProductiva";
            this.txtUnidadProductiva.Size = new System.Drawing.Size(110, 21);
            this.txtUnidadProductiva.TabIndex = 9;
            this.txtUnidadProductiva.Visible = false;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Location = new System.Drawing.Point(527, 52);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(66, 14);
            this.ultraLabel6.TabIndex = 8;
            this.ultraLabel6.Text = "Uni. Produc.";
            this.ultraLabel6.Visible = false;
            // 
            // txtMedicamento
            // 
            this.txtMedicamento.ButtonsRight.Add(editorButton1);
            this.txtMedicamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMedicamento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtMedicamento.Location = new System.Drawing.Point(103, 25);
            this.txtMedicamento.Name = "txtMedicamento";
            this.txtMedicamento.Size = new System.Drawing.Size(606, 21);
            this.txtMedicamento.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Image = global::Sigesoft.Node.Contasol.Integration.Properties.Resources.system_save;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(634, 204);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 28);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Agregar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(87, 214);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(38, 20);
            this.dtpFechaFin.TabIndex = 4;
            this.dtpFechaFin.Visible = false;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Location = new System.Drawing.Point(103, 152);
            this.txtDuracion.Multiline = true;
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(606, 46);
            this.txtDuracion.TabIndex = 3;
            // 
            // txtPosologia
            // 
            this.txtPosologia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosologia.Location = new System.Drawing.Point(103, 82);
            this.txtPosologia.Multiline = true;
            this.txtPosologia.Name = "txtPosologia";
            this.txtPosologia.Size = new System.Drawing.Size(606, 64);
            this.txtPosologia.TabIndex = 2;
            // 
            // txtCantidad
            // 
            appearance31.TextHAlignAsString = "Right";
            this.txtCantidad.Appearance = appearance31;
            this.txtCantidad.Location = new System.Drawing.Point(103, 52);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(110, 21);
            this.txtCantidad.TabIndex = 1;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Location = new System.Drawing.Point(6, 218);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(58, 14);
            this.ultraLabel5.TabIndex = 5;
            this.ultraLabel5.Text = "Fecha Fin:";
            this.ultraLabel5.Visible = false;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(22, 156);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel4.TabIndex = 4;
            this.ultraLabel4.Text = "Duración:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(22, 86);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(57, 14);
            this.ultraLabel3.TabIndex = 3;
            this.ultraLabel3.Text = "Posología:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(22, 56);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "Cantidad:";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(22, 29);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(75, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Medicamento:";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(616, 550);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmRecetaMedica_Fill_Panel
            // 
            // 
            // frmRecetaMedica_Fill_Panel.ClientArea
            // 
            this.frmRecetaMedica_Fill_Panel.ClientArea.Controls.Add(this.ultraGroupBox1);
            this.frmRecetaMedica_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmRecetaMedica_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmRecetaMedica_Fill_Panel.Location = new System.Drawing.Point(4, 28);
            this.frmRecetaMedica_Fill_Panel.Name = "frmRecetaMedica_Fill_Panel";
            this.frmRecetaMedica_Fill_Panel.Size = new System.Drawing.Size(1347, 703);
            this.frmRecetaMedica_Fill_Panel.TabIndex = 0;
            // 
            // _frmRecetaMedica_UltraFormManager_Dock_Area_Left
            // 
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 4;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.Name = "_frmRecetaMedica_UltraFormManager_Dock_Area_Left";
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(4, 703);
            // 
            // _frmRecetaMedica_UltraFormManager_Dock_Area_Right
            // 
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 4;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(1351, 28);
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.Name = "_frmRecetaMedica_UltraFormManager_Dock_Area_Right";
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(4, 703);
            // 
            // _frmRecetaMedica_UltraFormManager_Dock_Area_Top
            // 
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.Name = "_frmRecetaMedica_UltraFormManager_Dock_Area_Top";
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(1355, 28);
            // 
            // _frmRecetaMedica_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 4;
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 731);
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.Name = "_frmRecetaMedica_UltraFormManager_Dock_Area_Bottom";
            this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(1355, 4);
            // 
            // chkConsolidado
            // 
            this.chkConsolidado.AutoSize = true;
            this.chkConsolidado.Checked = true;
            this.chkConsolidado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsolidado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsolidado.ForeColor = System.Drawing.Color.Blue;
            this.chkConsolidado.Location = new System.Drawing.Point(7, 20);
            this.chkConsolidado.Name = "chkConsolidado";
            this.chkConsolidado.Size = new System.Drawing.Size(140, 17);
            this.chkConsolidado.TabIndex = 55;
            this.chkConsolidado.Text = "Receta Consolidada";
            this.chkConsolidado.UseVisualStyleBackColor = true;
            // 
            // frmRecetaMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 735);
            this.Controls.Add(this.frmRecetaMedica_Fill_Panel);
            this.Controls.Add(this._frmRecetaMedica_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmRecetaMedica_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmRecetaMedica_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmRecetaMedica_UltraFormManager_Dock_Area_Bottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecetaMedica";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RecetaMedica";
            this.Load += new System.EventHandler(this.frmRecetaMedica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalDiagnosticos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbBuscarMedicamento)).EndInit();
            this.gbBuscarMedicamento.ResumeLayout(false);
            this.gbBuscarMedicamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarAccionF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscarNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbReceta)).EndInit();
            this.gbReceta.ResumeLayout(false);
            this.gbReceta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdReceta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdProductoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDctoEPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadProductiva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosologia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmRecetaMedica_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmRecetaMedica_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdTotalDiagnosticos;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmRecetaMedica_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmRecetaMedica_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmRecetaMedica_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmRecetaMedica_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmRecetaMedica_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.Misc.UltraGroupBox gbReceta;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNuevoPrecio;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDctoEPS;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPPS;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPrecio;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUnidadProductiva;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMedicamento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDuracion;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPosologia;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCantidad;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraGroupBox gbBuscarMedicamento;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private Infragistics.Win.Misc.UltraButton btnRegistrarMedicamento;
        private Infragistics.Win.Misc.UltraButton btnAceptar;
        private Infragistics.Win.Misc.UltraButton ultraButton4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBuscarAccionF;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtBuscarNombre;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtIdProductoDetalle;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtIdReceta;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.CheckBox chekMedicinaExterna;
        private System.Windows.Forms.CheckBox chkConsolidado;
    }
}