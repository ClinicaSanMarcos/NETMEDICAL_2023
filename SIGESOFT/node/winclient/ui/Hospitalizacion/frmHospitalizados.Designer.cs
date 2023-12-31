﻿namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    partial class frmHospitalizados
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_HopitalizacionId", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_NroLiquidacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Paciente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_DocNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_Years");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaIngreso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaAlta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_PrecioTotal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Comentario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_PagoMedico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedicoPago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_PagoPaciente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PacientePago");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_MedicoTratante");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Servicio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Servicios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Habitaciones");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Servicios", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ServiceId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_ServiceDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_ProtocolName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaAlta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tickets");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Componentes");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Tickets", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_TicketId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Fecha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TicketInterno", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaAlta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Productos");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Productos", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_Descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Cantidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDespachado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_PrecioVenta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Componentes", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Categoria");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Componente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MedicoTratante");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaAlta");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ServiceComponentId");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Habitaciones", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NroHabitacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_StartDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_EndDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_Precio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("d_FechaAlta");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn1 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("d_CreationDate");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn2 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("d_ServiceDate");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn3 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_UpdateUser");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn4 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("d_UpdateDate");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn5 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_MasterServiceName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn6 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_ServiceStatusName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn7 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_OrganizationName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn8 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_LocationName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn9 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_ServiceTypeName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn10 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_ProtocolName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn11 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_Pacient");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn12 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("v_AptitudeStatusName");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn13 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("d_FechaEntrega");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn14 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Liq");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn15 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn16 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Valor");
            Infragistics.Win.UltraWinDataSource.UltraDataColumn ultraDataColumn17 = new Infragistics.Win.UltraWinDataSource.UltraDataColumn("Diagnosticos");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHospitalizados));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPacient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dptDateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTimeStar = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.grdData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            this.ultraGridExcelExporter1 = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bntEliminarExamen = new System.Windows.Forms.Button();
            this.btnEditExamen = new System.Windows.Forms.Button();
            this.btnVerHabitaciones = new System.Windows.Forms.Button();
            this.btnImprimirTicket = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.btnEliminarHabitacion = new System.Windows.Forms.Button();
            this.btnGenerarLiq = new System.Windows.Forms.Button();
            this.btnDarAlta = new System.Windows.Forms.Button();
            this.btnReportePDF = new System.Windows.Forms.Button();
            this.btnEditarHabitacion = new System.Windows.Forms.Button();
            this.btnAsignarHabitacion = new System.Windows.Forms.Button();
            this.btnAgregarExamenes = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEliminarTicket = new System.Windows.Forms.Button();
            this.btnEditarTicket = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnRemoverEsamen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLimpieza = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrarHabitacion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEditarExamen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.txtPacient);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dptDateTimeEnd);
            this.groupBox1.Controls.Add(this.dtpDateTimeStar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1270, 54);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtPacient
            // 
            this.txtPacient.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacient.Location = new System.Drawing.Point(470, 17);
            this.txtPacient.Margin = new System.Windows.Forms.Padding(2);
            this.txtPacient.Name = "txtPacient";
            this.txtPacient.Size = new System.Drawing.Size(230, 21);
            this.txtPacient.TabIndex = 9;
            this.txtPacient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHospitalizados_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(335, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Paciente / Nro Documento";
            // 
            // dptDateTimeEnd
            // 
            this.dptDateTimeEnd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptDateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptDateTimeEnd.Location = new System.Drawing.Point(209, 17);
            this.dptDateTimeEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dptDateTimeEnd.Name = "dptDateTimeEnd";
            this.dptDateTimeEnd.Size = new System.Drawing.Size(95, 21);
            this.dptDateTimeEnd.TabIndex = 3;
            this.dptDateTimeEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calendar2Hospitalizados_KeyPress);
            // 
            // dtpDateTimeStar
            // 
            this.dtpDateTimeStar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTimeStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTimeStar.Location = new System.Drawing.Point(96, 17);
            this.dtpDateTimeStar.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateTimeStar.Name = "dtpDateTimeStar";
            this.dtpDateTimeStar.Size = new System.Drawing.Size(95, 21);
            this.dtpDateTimeStar.TabIndex = 2;
            this.dtpDateTimeStar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.calendar1Hospitalizados_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Atención";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lblRecordCount);
            this.groupBox2.Controls.Add(this.grdData);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(6, 68);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1128, 450);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Hopitalizados";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblRecordCount.Location = new System.Drawing.Point(886, 8);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(231, 19);
            this.lblRecordCount.TabIndex = 52;
            this.lblRecordCount.Text = "No se ha realizado la búsqueda aún.";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.CausesValidation = false;
            this.grdData.ContextMenuStrip = this.contextMenuStrip2;
            this.grdData.DataMember = null;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdData.DisplayLayout.Appearance = appearance1;
            ultraGridColumn2.Header.Caption = "Nro. Hospitalización";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.Width = 177;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Caption = "Nombre de Paciente";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 117;
            ultraGridColumn5.Header.Caption = "N° Doc";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.Caption = "Edad";
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.Header.Caption = "Fecha Ingreso";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.Caption = "Fecha Alta";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.Caption = "Precio Total";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn15.Header.VisiblePosition = 9;
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn17.Header.VisiblePosition = 15;
            ultraGridColumn18.Header.VisiblePosition = 16;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18});
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Width = 117;
            ultraGridColumn22.Header.VisiblePosition = 3;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.VisiblePosition = 4;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 5;
            ultraGridColumn24.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            ultraGridColumn25.Header.Caption = "Ticket Id";
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn26.Header.Caption = "Fecha";
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn27.Header.Caption = "Ticket Interno";
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Width = 117;
            ultraGridColumn28.Header.VisiblePosition = 3;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.VisiblePosition = 4;
            ultraGridColumn29.Hidden = true;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29});
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridColumn32.Header.VisiblePosition = 2;
            ultraGridColumn32.Width = 117;
            ultraGridColumn34.Header.VisiblePosition = 3;
            ultraGridColumn35.Header.VisiblePosition = 4;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn34,
            ultraGridColumn35});
            ultraGridColumn36.Header.VisiblePosition = 0;
            ultraGridColumn37.Header.VisiblePosition = 1;
            ultraGridColumn38.Header.VisiblePosition = 2;
            ultraGridColumn38.Width = 117;
            ultraGridColumn40.Header.VisiblePosition = 3;
            ultraGridColumn41.Header.VisiblePosition = 4;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.VisiblePosition = 5;
            ultraGridColumn42.Hidden = true;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42});
            ultraGridColumn43.Header.VisiblePosition = 0;
            ultraGridColumn44.Header.VisiblePosition = 1;
            ultraGridColumn45.Header.VisiblePosition = 2;
            ultraGridColumn45.Width = 117;
            ultraGridColumn46.Header.VisiblePosition = 3;
            ultraGridColumn89.Header.VisiblePosition = 4;
            ultraGridColumn90.Header.VisiblePosition = 5;
            ultraGridColumn90.Hidden = true;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn89,
            ultraGridColumn90});
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.grdData.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.grdData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.InterBandSpacing = 10;
            this.grdData.DisplayLayout.MaxColScrollRegions = 1;
            this.grdData.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdData.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.grdData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdData.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdData.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdData.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdData.DisplayLayout.Override.CellAppearance = appearance3;
            this.grdData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.LightGray;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.DarkGray;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdData.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.AlphaLevel = ((short)(187));
            appearance5.BackColor = System.Drawing.Color.Gainsboro;
            appearance5.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdData.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdData.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.grdData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.FontData.BoldAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.grdData.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grdData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.grdData.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdData.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdData.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdData.Location = new System.Drawing.Point(14, 29);
            this.grdData.Margin = new System.Windows.Forms.Padding(2);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1103, 407);
            this.grdData.TabIndex = 44;
            this.grdData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdData_InitializeLayout);
            this.grdData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.grdData_InitializeRow);
            this.grdData.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.grdData_AfterRowUpdate);
            this.grdData.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.grd_AfterSelectChange);
            this.grdData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdData_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoverEsamen,
            this.itemLimpieza,
            this.itemCerrarHabitacion,
            this.itemEditarExamen});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(233, 92);
            // 
            // ultraDataSource1
            // 
            this.ultraDataSource1.Band.Columns.AddRange(new object[] {
            ultraDataColumn1,
            ultraDataColumn2,
            ultraDataColumn3,
            ultraDataColumn4,
            ultraDataColumn5,
            ultraDataColumn6,
            ultraDataColumn7,
            ultraDataColumn8,
            ultraDataColumn9,
            ultraDataColumn10,
            ultraDataColumn11,
            ultraDataColumn12,
            ultraDataColumn13,
            ultraDataColumn14,
            ultraDataColumn15,
            ultraDataColumn16,
            ultraDataColumn17});
            // 
            // bntEliminarExamen
            // 
            this.bntEliminarExamen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntEliminarExamen.BackColor = System.Drawing.SystemColors.Control;
            this.bntEliminarExamen.Enabled = false;
            this.bntEliminarExamen.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bntEliminarExamen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bntEliminarExamen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bntEliminarExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntEliminarExamen.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntEliminarExamen.ForeColor = System.Drawing.Color.Black;
            this.bntEliminarExamen.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.delete;
            this.bntEliminarExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntEliminarExamen.Location = new System.Drawing.Point(1138, 292);
            this.bntEliminarExamen.Margin = new System.Windows.Forms.Padding(2);
            this.bntEliminarExamen.Name = "bntEliminarExamen";
            this.bntEliminarExamen.Size = new System.Drawing.Size(128, 32);
            this.bntEliminarExamen.TabIndex = 161;
            this.bntEliminarExamen.Text = "Eliminar Examen";
            this.bntEliminarExamen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntEliminarExamen.UseVisualStyleBackColor = false;
            this.bntEliminarExamen.Click += new System.EventHandler(this.bntEliminarExamen_Click);
            // 
            // btnEditExamen
            // 
            this.btnEditExamen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditExamen.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditExamen.Enabled = false;
            this.btnEditExamen.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEditExamen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditExamen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExamen.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditExamen.ForeColor = System.Drawing.Color.Black;
            this.btnEditExamen.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.pencil;
            this.btnEditExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditExamen.Location = new System.Drawing.Point(1138, 256);
            this.btnEditExamen.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditExamen.Name = "btnEditExamen";
            this.btnEditExamen.Size = new System.Drawing.Size(128, 32);
            this.btnEditExamen.TabIndex = 160;
            this.btnEditExamen.Text = "Editar Examen";
            this.btnEditExamen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditExamen.UseVisualStyleBackColor = false;
            this.btnEditExamen.Click += new System.EventHandler(this.btnEditExamen_Click);
            // 
            // btnVerHabitaciones
            // 
            this.btnVerHabitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerHabitaciones.BackColor = System.Drawing.SystemColors.Control;
            this.btnVerHabitaciones.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnVerHabitaciones.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVerHabitaciones.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVerHabitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerHabitaciones.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerHabitaciones.ForeColor = System.Drawing.Color.Black;
            this.btnVerHabitaciones.Image = global::Sigesoft.Node.WinClient.UI.Resources.system_search;
            this.btnVerHabitaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerHabitaciones.Location = new System.Drawing.Point(956, 538);
            this.btnVerHabitaciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerHabitaciones.Name = "btnVerHabitaciones";
            this.btnVerHabitaciones.Size = new System.Drawing.Size(128, 32);
            this.btnVerHabitaciones.TabIndex = 157;
            this.btnVerHabitaciones.TabStop = false;
            this.btnVerHabitaciones.Text = "Ver Habitaciones";
            this.btnVerHabitaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerHabitaciones.UseVisualStyleBackColor = false;
            this.btnVerHabitaciones.Click += new System.EventHandler(this.btnVerHabitaciones_Click);
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirTicket.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimirTicket.Enabled = false;
            this.btnImprimirTicket.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnImprimirTicket.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImprimirTicket.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirTicket.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.Black;
            this.btnImprimirTicket.Image = global::Sigesoft.Node.WinClient.UI.Resources.printer_color;
            this.btnImprimirTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirTicket.Location = new System.Drawing.Point(1140, 184);
            this.btnImprimirTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(128, 32);
            this.btnImprimirTicket.TabIndex = 157;
            this.btnImprimirTicket.Text = "Imprimir Ticket";
            this.btnImprimirTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirTicket.UseVisualStyleBackColor = false;
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLiberar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.Go_back;
            this.btnLiberar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiberar.Location = new System.Drawing.Point(1138, 502);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(128, 32);
            this.btnLiberar.TabIndex = 156;
            this.btnLiberar.Text = "Liberar Registro";
            this.btnLiberar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnEliminarHabitacion
            // 
            this.btnEliminarHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarHabitacion.Enabled = false;
            this.btnEliminarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.delete;
            this.btnEliminarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarHabitacion.Location = new System.Drawing.Point(1138, 411);
            this.btnEliminarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarHabitacion.Name = "btnEliminarHabitacion";
            this.btnEliminarHabitacion.Size = new System.Drawing.Size(128, 32);
            this.btnEliminarHabitacion.TabIndex = 155;
            this.btnEliminarHabitacion.Text = "Eliminar Habitación";
            this.btnEliminarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarHabitacion.UseVisualStyleBackColor = false;
            this.btnEliminarHabitacion.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerarLiq
            // 
            this.btnGenerarLiq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerarLiq.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerarLiq.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGenerarLiq.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGenerarLiq.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGenerarLiq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarLiq.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarLiq.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarLiq.Image = global::Sigesoft.Node.WinClient.UI.Resources.application_osx_start;
            this.btnGenerarLiq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarLiq.Location = new System.Drawing.Point(6, 524);
            this.btnGenerarLiq.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarLiq.Name = "btnGenerarLiq";
            this.btnGenerarLiq.Size = new System.Drawing.Size(134, 46);
            this.btnGenerarLiq.TabIndex = 154;
            this.btnGenerarLiq.Text = "Generar Liquidación Hospitalización";
            this.btnGenerarLiq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarLiq.UseVisualStyleBackColor = false;
            this.btnGenerarLiq.Visible = false;
            this.btnGenerarLiq.Click += new System.EventHandler(this.btnGenerarLiq_Click);
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDarAlta.BackColor = System.Drawing.SystemColors.Control;
            this.btnDarAlta.Enabled = false;
            this.btnDarAlta.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDarAlta.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDarAlta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDarAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarAlta.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarAlta.ForeColor = System.Drawing.Color.Black;
            this.btnDarAlta.Image = global::Sigesoft.Node.WinClient.UI.Resources.alta_medica_400x400_3;
            this.btnDarAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDarAlta.Location = new System.Drawing.Point(1138, 452);
            this.btnDarAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(128, 45);
            this.btnDarAlta.TabIndex = 108;
            this.btnDarAlta.Text = "Alta";
            this.btnDarAlta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDarAlta.UseVisualStyleBackColor = false;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // btnReportePDF
            // 
            this.btnReportePDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportePDF.BackColor = System.Drawing.SystemColors.Control;
            this.btnReportePDF.Enabled = false;
            this.btnReportePDF.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReportePDF.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReportePDF.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReportePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportePDF.ForeColor = System.Drawing.Color.Black;
            this.btnReportePDF.Image = global::Sigesoft.Node.WinClient.UI.Resources.page_white_acrobat;
            this.btnReportePDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportePDF.Location = new System.Drawing.Point(1138, 539);
            this.btnReportePDF.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportePDF.Name = "btnReportePDF";
            this.btnReportePDF.Size = new System.Drawing.Size(128, 31);
            this.btnReportePDF.TabIndex = 107;
            this.btnReportePDF.Text = "Reporte";
            this.btnReportePDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportePDF.UseVisualStyleBackColor = false;
            this.btnReportePDF.Click += new System.EventHandler(this.btnReportePDF_Click);
            // 
            // btnEditarHabitacion
            // 
            this.btnEditarHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarHabitacion.Enabled = false;
            this.btnEditarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEditarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Resources.book_edit;
            this.btnEditarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarHabitacion.Location = new System.Drawing.Point(1138, 375);
            this.btnEditarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarHabitacion.Name = "btnEditarHabitacion";
            this.btnEditarHabitacion.Size = new System.Drawing.Size(128, 32);
            this.btnEditarHabitacion.TabIndex = 106;
            this.btnEditarHabitacion.Text = "Editar Habitación";
            this.btnEditarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarHabitacion.UseVisualStyleBackColor = false;
            this.btnEditarHabitacion.Click += new System.EventHandler(this.btnEditarHabitacion_Click);
            // 
            // btnAsignarHabitacion
            // 
            this.btnAsignarHabitacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnAsignarHabitacion.Enabled = false;
            this.btnAsignarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAsignarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAsignarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAsignarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnAsignarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Resources.book_open;
            this.btnAsignarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarHabitacion.Location = new System.Drawing.Point(1138, 339);
            this.btnAsignarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarHabitacion.Name = "btnAsignarHabitacion";
            this.btnAsignarHabitacion.Size = new System.Drawing.Size(128, 32);
            this.btnAsignarHabitacion.TabIndex = 105;
            this.btnAsignarHabitacion.Text = "Asignar Habitación";
            this.btnAsignarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarHabitacion.UseVisualStyleBackColor = false;
            this.btnAsignarHabitacion.Click += new System.EventHandler(this.btnAsignarHabitacion_Click);
            // 
            // btnAgregarExamenes
            // 
            this.btnAgregarExamenes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarExamenes.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarExamenes.Enabled = false;
            this.btnAgregarExamenes.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAgregarExamenes.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAgregarExamenes.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgregarExamenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarExamenes.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarExamenes.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarExamenes.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.add;
            this.btnAgregarExamenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarExamenes.Location = new System.Drawing.Point(1138, 220);
            this.btnAgregarExamenes.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarExamenes.Name = "btnAgregarExamenes";
            this.btnAgregarExamenes.Size = new System.Drawing.Size(128, 32);
            this.btnAgregarExamenes.TabIndex = 104;
            this.btnAgregarExamenes.Text = "Agregar Examenes";
            this.btnAgregarExamenes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarExamenes.UseVisualStyleBackColor = false;
            this.btnAgregarExamenes.Click += new System.EventHandler(this.btnAgregarExamenes_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Image = global::Sigesoft.Node.WinClient.UI.Resources.page_excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(741, 524);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 47);
            this.btnExport.TabIndex = 103;
            this.btnExport.Text = "Exportar a Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEliminarTicket
            // 
            this.btnEliminarTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarTicket.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarTicket.Enabled = false;
            this.btnEliminarTicket.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminarTicket.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminarTicket.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTicket.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTicket.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarTicket.Image = global::Sigesoft.Node.WinClient.UI.Resources.application_delete;
            this.btnEliminarTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarTicket.Location = new System.Drawing.Point(1140, 148);
            this.btnEliminarTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarTicket.Name = "btnEliminarTicket";
            this.btnEliminarTicket.Size = new System.Drawing.Size(128, 32);
            this.btnEliminarTicket.TabIndex = 53;
            this.btnEliminarTicket.Text = "Eliminar Ticket";
            this.btnEliminarTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarTicket.UseVisualStyleBackColor = false;
            this.btnEliminarTicket.Click += new System.EventHandler(this.btnEliminarTicket_Click);
            // 
            // btnEditarTicket
            // 
            this.btnEditarTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarTicket.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarTicket.Enabled = false;
            this.btnEditarTicket.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEditarTicket.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditarTicket.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarTicket.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarTicket.ForeColor = System.Drawing.Color.Black;
            this.btnEditarTicket.Image = global::Sigesoft.Node.WinClient.UI.Resources.application_edit;
            this.btnEditarTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarTicket.Location = new System.Drawing.Point(1140, 112);
            this.btnEditarTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarTicket.Name = "btnEditarTicket";
            this.btnEditarTicket.Size = new System.Drawing.Size(128, 32);
            this.btnEditarTicket.TabIndex = 52;
            this.btnEditarTicket.Text = "Editar       Ticket";
            this.btnEditarTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarTicket.UseVisualStyleBackColor = false;
            this.btnEditarTicket.Click += new System.EventHandler(this.btnEditarTicket_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTicket.BackColor = System.Drawing.SystemColors.Control;
            this.btnTicket.Enabled = false;
            this.btnTicket.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnTicket.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTicket.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicket.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.ForeColor = System.Drawing.Color.Black;
            this.btnTicket.Image = global::Sigesoft.Node.WinClient.UI.Resources.application_form_add;
            this.btnTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicket.Location = new System.Drawing.Point(1140, 76);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(2);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(128, 32);
            this.btnTicket.TabIndex = 51;
            this.btnTicket.Text = "Nuevo        Ticket";
            this.btnTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnRemoverEsamen
            // 
            this.btnRemoverEsamen.Enabled = false;
            this.btnRemoverEsamen.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverEsamen.Image")));
            this.btnRemoverEsamen.Name = "btnRemoverEsamen";
            this.btnRemoverEsamen.Size = new System.Drawing.Size(232, 22);
            this.btnRemoverEsamen.Text = "Remover Examen";
            this.btnRemoverEsamen.Click += new System.EventHandler(this.btnRemoverEsamen_Click);
            // 
            // itemLimpieza
            // 
            this.itemLimpieza.Enabled = false;
            this.itemLimpieza.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.pencil;
            this.itemLimpieza.Name = "itemLimpieza";
            this.itemLimpieza.Size = new System.Drawing.Size(232, 22);
            this.itemLimpieza.Text = "Poner Habitación en Limpieza";
            this.itemLimpieza.Click += new System.EventHandler(this.itemLimpieza_Click);
            // 
            // itemCerrarHabitacion
            // 
            this.itemCerrarHabitacion.Enabled = false;
            this.itemCerrarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Resources.door_out;
            this.itemCerrarHabitacion.Name = "itemCerrarHabitacion";
            this.itemCerrarHabitacion.Size = new System.Drawing.Size(232, 22);
            this.itemCerrarHabitacion.Text = "Cerrar Habitación";
            this.itemCerrarHabitacion.Click += new System.EventHandler(this.itemCerrarHabitacion_Click);
            // 
            // itemEditarExamen
            // 
            this.itemEditarExamen.Enabled = false;
            this.itemEditarExamen.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.pencil;
            this.itemEditarExamen.Name = "itemEditarExamen";
            this.itemEditarExamen.Size = new System.Drawing.Size(232, 22);
            this.itemEditarExamen.Text = "Editar Examen";
            this.itemEditarExamen.Click += new System.EventHandler(this.editarExamenToolStripMenuItem_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.Control;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Image = global::Sigesoft.Node.WinClient.UI.Resources.find;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(730, 16);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 24);
            this.btnFilter.TabIndex = 106;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // frmHospitalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 581);
            this.Controls.Add(this.bntEliminarExamen);
            this.Controls.Add(this.btnEditExamen);
            this.Controls.Add(this.btnVerHabitaciones);
            this.Controls.Add(this.btnImprimirTicket);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnEliminarHabitacion);
            this.Controls.Add(this.btnGenerarLiq);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.btnReportePDF);
            this.Controls.Add(this.btnEditarHabitacion);
            this.Controls.Add(this.btnAsignarHabitacion);
            this.Controls.Add(this.btnAgregarExamenes);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEliminarTicket);
            this.Controls.Add(this.btnEditarTicket);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHospitalizados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospitalizados y Aseguradoras";
            this.Load += new System.EventHandler(this.frmHospitalizados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtPacient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dptDateTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpDateTimeStar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.ComboBox ddlCalendarStatusId;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnEditarTicket;
        private System.Windows.Forms.Button btnEliminarTicket;
        private System.Windows.Forms.Button btnExport;
        private Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ultraGridExcelExporter1;
        private System.Windows.Forms.Button btnAgregarExamenes;
        private System.Windows.Forms.Button btnAsignarHabitacion;
        private System.Windows.Forms.Button btnEditarHabitacion;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnReportePDF;
        private System.Windows.Forms.Button btnDarAlta;
        private System.Windows.Forms.Button btnGenerarLiq;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnRemoverEsamen;
        private System.Windows.Forms.Button btnEliminarHabitacion;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdData;
        private System.Windows.Forms.Button btnLiberar;

        private System.Windows.Forms.Button btnVerHabitaciones;
        private System.Windows.Forms.ToolStripMenuItem itemLimpieza;

        private System.Windows.Forms.Button btnImprimirTicket;
        private System.Windows.Forms.ToolStripMenuItem itemCerrarHabitacion;
        private System.Windows.Forms.ToolStripMenuItem itemEditarExamen;
        private System.Windows.Forms.Button bntEliminarExamen;
        private System.Windows.Forms.Button btnEditExamen;

    }
}