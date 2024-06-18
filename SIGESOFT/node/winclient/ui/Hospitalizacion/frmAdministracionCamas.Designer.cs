namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    partial class frmAdministracionCamas
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Habitacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("i_HabitacionId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("v_HospHabitacionId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioCrea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCrea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioActualiza");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualiza");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Comentarios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioCreaId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UsuarioActualizaId");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnEditarHabitacion = new System.Windows.Forms.Button();
            this.btnEliminarHabitacion = new System.Windows.Forms.Button();
            this.btnAsignarHabitacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.grdDataHabitaciones = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnExport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRecordCountCalendar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditarHabitacion
            // 
            this.btnEditarHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEditarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.pencil;
            this.btnEditarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarHabitacion.Location = new System.Drawing.Point(852, 98);
            this.btnEditarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarHabitacion.Name = "btnEditarHabitacion";
            this.btnEditarHabitacion.Size = new System.Drawing.Size(97, 33);
            this.btnEditarHabitacion.TabIndex = 175;
            this.btnEditarHabitacion.Text = "Editar";
            this.btnEditarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarHabitacion.UseVisualStyleBackColor = false;
            this.btnEditarHabitacion.Click += new System.EventHandler(this.btnEditarHabitacion_Click);
            // 
            // btnEliminarHabitacion
            // 
            this.btnEliminarHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnEliminarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.delete;
            this.btnEliminarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarHabitacion.Location = new System.Drawing.Point(852, 134);
            this.btnEliminarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarHabitacion.Name = "btnEliminarHabitacion";
            this.btnEliminarHabitacion.Size = new System.Drawing.Size(97, 33);
            this.btnEliminarHabitacion.TabIndex = 176;
            this.btnEliminarHabitacion.Text = "Eliminar";
            this.btnEliminarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarHabitacion.UseVisualStyleBackColor = false;
            // 
            // btnAsignarHabitacion
            // 
            this.btnAsignarHabitacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAsignarHabitacion.BackColor = System.Drawing.SystemColors.Control;
            this.btnAsignarHabitacion.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAsignarHabitacion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAsignarHabitacion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAsignarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarHabitacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarHabitacion.ForeColor = System.Drawing.Color.Black;
            this.btnAsignarHabitacion.Image = global::Sigesoft.Node.WinClient.UI.Properties.Resources.add;
            this.btnAsignarHabitacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarHabitacion.Location = new System.Drawing.Point(852, 62);
            this.btnAsignarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarHabitacion.Name = "btnAsignarHabitacion";
            this.btnAsignarHabitacion.Size = new System.Drawing.Size(97, 33);
            this.btnAsignarHabitacion.TabIndex = 174;
            this.btnAsignarHabitacion.Text = "Agregar";
            this.btnAsignarHabitacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarHabitacion.UseVisualStyleBackColor = false;
            this.btnAsignarHabitacion.Click += new System.EventHandler(this.btnAsignarHabitacion_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Sigesoft.Node.WinClient.UI.Resources.system_search;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(458, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 173;
            this.button1.Text = "Filtrar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(88, 22);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(364, 20);
            this.txtBusqueda.TabIndex = 172;
            this.txtBusqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // grdDataHabitaciones
            // 
            this.grdDataHabitaciones.CausesValidation = false;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.Silver;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdDataHabitaciones.DisplayLayout.Appearance = appearance1;
            ultraGridColumn28.Header.VisiblePosition = 1;
            ultraGridColumn28.Width = 183;
            ultraGridColumn29.Header.VisiblePosition = 5;
            ultraGridColumn29.Width = 238;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn4.Header.VisiblePosition = 6;
            ultraGridColumn5.Header.VisiblePosition = 7;
            ultraGridColumn6.Header.VisiblePosition = 8;
            ultraGridColumn7.Header.VisiblePosition = 9;
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.Width = 225;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 11;
            ultraGridColumn10.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.grdDataHabitaciones.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdDataHabitaciones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdDataHabitaciones.DisplayLayout.InterBandSpacing = 10;
            this.grdDataHabitaciones.DisplayLayout.MaxColScrollRegions = 1;
            this.grdDataHabitaciones.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdDataHabitaciones.DisplayLayout.NewColumnLoadStyle = Infragistics.Win.UltraWinGrid.NewColumnLoadStyle.Hide;
            this.grdDataHabitaciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdDataHabitaciones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdDataHabitaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.grdDataHabitaciones.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdDataHabitaciones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdDataHabitaciones.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdDataHabitaciones.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.White;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.grdDataHabitaciones.DisplayLayout.Override.CellAppearance = appearance3;
            this.grdDataHabitaciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.LightGray;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.DarkGray;
            appearance4.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdDataHabitaciones.DisplayLayout.Override.HeaderAppearance = appearance4;
            this.grdDataHabitaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance5.AlphaLevel = ((short)(187));
            appearance5.BackColor = System.Drawing.Color.Gainsboro;
            appearance5.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForegroundAlpha = Infragistics.Win.Alpha.Opaque;
            this.grdDataHabitaciones.DisplayLayout.Override.RowAlternateAppearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdDataHabitaciones.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.grdDataHabitaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.BorderColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            appearance7.FontData.BoldAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.grdDataHabitaciones.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grdDataHabitaciones.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.grdDataHabitaciones.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdDataHabitaciones.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.grdDataHabitaciones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdDataHabitaciones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdDataHabitaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDataHabitaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDataHabitaciones.Location = new System.Drawing.Point(11, 62);
            this.grdDataHabitaciones.Margin = new System.Windows.Forms.Padding(2);
            this.grdDataHabitaciones.Name = "grdDataHabitaciones";
            this.grdDataHabitaciones.Size = new System.Drawing.Size(820, 401);
            this.grdDataHabitaciones.TabIndex = 171;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::Sigesoft.Node.WinClient.UI.Resources.page_excel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(692, 468);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(139, 24);
            this.btnExport.TabIndex = 177;
            this.btnExport.Text = "Exportar a Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 178;
            this.label5.Text = "Habitación";
            // 
            // lblRecordCountCalendar
            // 
            this.lblRecordCountCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordCountCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCountCalendar.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblRecordCountCalendar.Location = new System.Drawing.Point(600, 41);
            this.lblRecordCountCalendar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCountCalendar.Name = "lblRecordCountCalendar";
            this.lblRecordCountCalendar.Size = new System.Drawing.Size(231, 19);
            this.lblRecordCountCalendar.TabIndex = 179;
            this.lblRecordCountCalendar.Text = "No se ha realizado la búsqueda aún.";
            this.lblRecordCountCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAdministracionCamas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 504);
            this.Controls.Add(this.lblRecordCountCalendar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnEditarHabitacion);
            this.Controls.Add(this.btnEliminarHabitacion);
            this.Controls.Add(this.btnAsignarHabitacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.grdDataHabitaciones);
            this.Name = "frmAdministracionCamas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAdministracionCamas";
            this.Load += new System.EventHandler(this.frmAdministracionCamas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditarHabitacion;
        private System.Windows.Forms.Button btnEliminarHabitacion;
        private System.Windows.Forms.Button btnAsignarHabitacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdDataHabitaciones;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRecordCountCalendar;
    }
}