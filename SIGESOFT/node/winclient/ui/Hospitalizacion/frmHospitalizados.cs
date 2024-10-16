﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid.DocumentExport;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Sigesoft.Node.Contasol.Integration;
using NetPdf;
using System.Data.SqlClient;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmHospitalizados : Form
    {
        string strFilterExpression;
        List<HospitalizacionList> _objData = new List<HospitalizacionList>();
        List<HospSopList> _objData2 = new List<HospSopList>();
        List<EmergenciapList> _objData3 = new List<EmergenciapList>();

        HospitalizacionBL _objHospBL = new HospitalizacionBL();
        List<string> ListaComponentes = new List<string>();
        private string _ticketId;
        private List<TicketList> _tempTicket = null;
        private TicketBL _ticketlBL = new TicketBL();
        private HospitalizacionBL _hospitBL = new HospitalizacionBL();

        private ServiceBL _serviceBL = new ServiceBL();
        private PacientBL _pacientBL = new PacientBL();
        private OperationResult _objOperationResult = new OperationResult();
        private List<PersonList> personalList;
        private List<HospitalizacionList> hospitalizacionlList;
        private List<HospitalizacionServiceList> hospitalizacionServicelList;
        private List<TicketList> ticketlList;
        private List<TicketDetalleList> ticketdetallelList;
        private List<TicketDetalleList> _tempticketdetallelList = null;

        List<TicketDetalleList> ListaTickets = new List<TicketDetalleList>();
        string _serviceId;
        string _EmpresaClienteId;
        string _pacientId;
        string _customerOrganizationName;
        string _personFullName;
        string ruta;
        int _edad;
        private string v_ProtocoloId;

        private hospitalizacionserviceDto hospser = new hospitalizacionserviceDto();
        private ticketDto Ticket = new ticketDto();
        private protocolDto prot = new protocolDto();
        private serviceDto serv = new serviceDto();

        List<HospSopList> _HospSopList = new List<HospSopList>();
        List<EmergenciapList> _EmergenciapList = new List<EmergenciapList>();
        public frmHospitalizados()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Get the filters from the UI
            List<string> Filters = new List<string>();
            if (!string.IsNullOrEmpty(txtPacient.Text)) Filters.Add("v_Paciente.Contains(\"" + txtPacient.Text.Trim() + "\")");

            Filters.Add("i_IsDeleted==0");
            strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    strFilterExpression = strFilterExpression + item + " && ";
                }
                strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
            }

            string tabName = tabControl1.SelectedTab.Text;

            if (tabName == "HOSPITALIZADOS / SOP")
            {
                this.BindGrid(); 
            }
            else
            {
                this.BindGridEmergencia();
            }
            

           
           btnTicket.Enabled = false;
           btnAgregarExamenes.Enabled = false;
           btnAsignarHabitacion.Enabled = false;
           btnReportePDF.Enabled = false;
           btnReportePDF.Enabled = false;
           btnDarAlta.Enabled = false;
           btnGenerarLiq.Enabled = false;
           btnEditExamen.Enabled = false;
           bntEliminarExamen.Enabled = false;

        }
        //
        private void BindGrid()
        {
            var objData = GetData(0, null, "v_HopitalizacionId ASC", strFilterExpression);
            _HospSopList = objData;
            grdData.DataSource = objData;
            
            lblRecordCount.Text = string.Format("Se encontraron {0} registros.", objData.Count());
            if (objData.Count() >= 1)
            {
                btnExport.Enabled = true;
            }
            else
            {
                btnExport.Enabled = false;
            }

        }

        private void BindGridEmergencia()
        {
            var objData = GetDataEmrg(0, null, "v_HopitalizacionId ASC", strFilterExpression);
            _EmergenciapList = objData;
            ultraGrid1.DataSource = objData;

            label3.Text = string.Format("Se encontraron {0} registros.", objData.Count());
            if (objData.Count() >= 1)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

            //this.ultraGrid1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
          
        }

        private List<HospSopList> GetData(int pintPageIndex, int? pintPageSize, string pstrSortExpression, string pstrFilterExpression)
        {
            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            _objData2 = _objHospBL.GetHospitalizacionPagedAndFiltered(ref objOperationResult, pdatBeginDate, pdatEndDate);

            
            if (objOperationResult.Success != 1)
            {
                MessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _objData2;
        }

        private List<EmergenciapList> GetDataEmrg(int pintPageIndex, int? pintPageSize, string pstrSortExpression, string pstrFilterExpression)
        {
            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            _objData3 = _objHospBL.GetHospitalizacionPagedAndFilteredEmrg(ref objOperationResult, pdatBeginDate, pdatEndDate);


            if (objOperationResult.Success != 1)
            {
                MessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _objData3;
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            // obtener serviceId y protocolId
            var ServiceId = grdData.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            var protocolId = grdData.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();

            #region Conexion SAM Obtener Plan
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + protocolId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            string plan = "";
            while (lector.Read()){plan = lector.GetValue(0).ToString();}
            lector.Close();
            conectasam.closesigesoft();
            string modoMasterService;
            if (plan != ""){modoMasterService = "ASEGU";}
            else{modoMasterService = "HOSPI";}
            #endregion
            // construir formulario ticket
            frmTicket ticket = new frmTicket(_tempTicket, ServiceId, string.Empty, "New", protocolId, modoMasterService);
            ticket.ShowDialog();
            btnFilter_Click(sender, e);
            btnTicket.Enabled = false;
        }

        private void txtHospitalizados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFilter_Click(null, null);
            }
        }

        private void calendar1Hospitalizados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFilter_Click(null, null);
            }
        }

        private void calendar2Hospitalizados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFilter_Click(null, null);
            }
        }

        private void btnEditarTicket_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            var ServiceId = grdData.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            var ticketId = grdData.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();
            #region Conexion SAM
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion
            var cadena1 = "select PL.i_PlanId from service SR inner join protocol PR on SR.v_ProtocolId = PR.v_ProtocolId inner join [dbo].[plan] PL on PR.v_ProtocolId = PL.v_ProtocoloId where SR.v_ServiceId ='" + ServiceId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            string plan = "";
            string protocolId = "";
            while (lector.Read())
            {
                plan = lector.GetValue(0).ToString();
            }
            lector.Close();
            conectasam.closesigesoft();
            ServiceList personData = _serviceBL.GetServicePersonData(ref objOperationResult, ServiceId);
            string modoMasterService;
            if (plan != "")
            {
                modoMasterService = "ASEGU";
            }
            else
            {
                modoMasterService = "HOSPI";
            }
            _ticketId = ticketId;
            frmTicket ticket = new frmTicket(_tempTicket, ServiceId, _ticketId, "Edit", personData.v_ProtocolId, modoMasterService);
            ticket.ShowDialog();

            btnFilter_Click(sender, e);
        }

        private void grd_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            bool activador = false;
            foreach (UltraGridRow rowSelected in this.grdData.Selected.Rows)
            {
                if (rowSelected.Band.Index.ToString() == "0")
                {
                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = false;    
                    if (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value != null)
                    {
                        btnTicket.Enabled = false;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnImprimirTicket.Enabled = false;
                        btnAgregarExamenes.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnDarAlta.Enabled = false;
                        activador = true;
                        contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                        btnReportePDF.Enabled = true;

                    }
                    else
                    {
                        btnAsignarHabitacion.Enabled = true;
                        btnImprimirTicket.Enabled = false;
                        btnReportePDF.Enabled = true;
                        btnDarAlta.Enabled = true;
                        btnReportePDF.Enabled = true;
                        contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                    }
                    
                }

                if (rowSelected.Band.Index.ToString() == "1")
                {
                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = false;    
                    contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                    if (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value != null)
                    {
                        btnTicket.Enabled = false;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnImprimirTicket.Enabled = false;
                        btnAgregarExamenes.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnDarAlta.Enabled = false;
                        activador = true;
                        btnGenerarLiq.Enabled = false;
                        btnReportePDF.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;

                    }
                    else
                    {
                        btnTicket.Enabled = true;
                        btnAgregarExamenes.Enabled = true;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnImprimirTicket.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnDarAlta.Enabled = false;
                        btnReportePDF.Enabled = false;

                    }
                }

                if (rowSelected.Band.Index.ToString() == "2")
                {
                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = false;    
                    contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                    if (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value != null)
                    {
                        btnTicket.Enabled = false;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnImprimirTicket.Enabled = true;
                        btnAgregarExamenes.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;
                        btnDarAlta.Enabled = false;
                        btnGenerarLiq.Enabled = false;
                        activador = true;
                        btnReportePDF.Enabled = false;

                    }
                    else
                    {
                        btnEditarTicket.Enabled = true;
                        btnEliminarTicket.Enabled = true;
                        btnImprimirTicket.Enabled = true;
                        btnTicket.Enabled = false;
                        btnAgregarExamenes.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnDarAlta.Enabled = false;
                        btnReportePDF.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;

                    }
                }

                if (rowSelected.Band.Index.ToString() == "3")
                {
                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = false;    
                    contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                    btnTicket.Enabled = false;
                    btnEditarTicket.Enabled = false;
                    btnEliminarTicket.Enabled = false;
                    btnImprimirTicket.Enabled = false;
                    btnAgregarExamenes.Enabled = false;
                    btnAsignarHabitacion.Enabled = false;
                    btnEditarHabitacion.Enabled = false;
                    btnEliminarHabitacion.Enabled = false;
                    btnDarAlta.Enabled = false;
                    btnEditExamen.Enabled = false;
                    bntEliminarExamen.Enabled = false;
                    activador = true;
                    btnReportePDF.Enabled = false;

                }
                if (rowSelected.Band.Index.ToString() == "4")
                {
                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = false;                    
                    contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
                    contextMenuStrip2.Items["itemEditarExamen"].Enabled = true;
                    btnTicket.Enabled = false;
                    btnEditarTicket.Enabled = false;
                    btnEliminarTicket.Enabled = false;
                    btnImprimirTicket.Enabled = false;
                    btnAgregarExamenes.Enabled = false;
                    if (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value != null)
                    {
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;
                    }
                    else
                    {
                        btnEditExamen.Enabled = true;
                        bntEliminarExamen.Enabled = true;
                    }
                    btnAsignarHabitacion.Enabled = false;
                    btnEditarHabitacion.Enabled = false;
                    btnEliminarHabitacion.Enabled = false;
                    btnDarAlta.Enabled = false;
                    activador = true;
                    btnReportePDF.Enabled = false;

                }
                else
                {
                    contextMenuStrip2.Items["itemEditarExamen"].Enabled = false;
                }

                if (rowSelected.Band.Index.ToString() == "5")
                {

                    contextMenuStrip2.Items["itemCerrarHabitacion"].Enabled = true;
                    contextMenuStrip2.Items["itemLimpieza"].Enabled = true;
                    if (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value != null)
                    {
                        btnTicket.Enabled = false;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnImprimirTicket.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;
                        btnAgregarExamenes.Enabled = false;
                        btnAsignarHabitacion.Enabled = false;
                        btnEditarHabitacion.Enabled = false;
                        btnEliminarHabitacion.Enabled = false;
                        btnDarAlta.Enabled = false;
                        activador = true;
                        btnReportePDF.Enabled = false;

                    }
                    else
                    {
                        btnEditarHabitacion.Enabled = true;
                        btnEliminarHabitacion.Enabled = true;
                        btnTicket.Enabled = false;
                        btnEditarTicket.Enabled = false;
                        btnEliminarTicket.Enabled = false;
                        btnEditExamen.Enabled = false;
                        bntEliminarExamen.Enabled = false;
                        btnImprimirTicket.Enabled = false;
                        btnAgregarExamenes.Enabled = false;
                        btnDarAlta.Enabled = false;
                        btnReportePDF.Enabled = false;
                    }
                }

                


            }

            if (grdData.Selected.Rows.Count == 0)
                 return;

            btnExport.Enabled = grdData.Rows.Count > 0;
        }

        private void btnAsignarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                var v_HopitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                
                #region Conexion SIGESOFT Obtener Protocolo
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "select PR.v_ProtocolId " +
                              "from hospitalizacionservice HS " +
                              "inner join service SR on SR.v_ServiceId= HS.v_ServiceId " +
                              "inner join protocol PR on SR.v_ProtocolId=PR.v_ProtocolId " +
                              "where v_HopitalizacionId='"+v_HopitalizacionId+"'";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                v_ProtocoloId = "";
                while (lector.Read()) { v_ProtocoloId = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion

                #region Conexion SIGESOFT Obtener Plan
                conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + v_ProtocoloId + "'";
                comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                lector = comando.ExecuteReader();
                string plan = "";
                while (lector.Read()) { plan = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion
                string modoMasterService;
                if (plan != "") { modoMasterService = "ASEGU"; }
                else { modoMasterService = "HOSPI"; }
                //var hospitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                //frmHabitacion frm = new frmHabitacion(hospitalizacionId, "New" + modoMasterService, "", v_ProtocoloId);
                var frm = new frmHabitaciones(v_HopitalizacionId, "New" + modoMasterService, "", v_ProtocoloId);
                frm.ShowDialog();
                btnFilter_Click(sender, e);
                btnAsignarHabitacion.Enabled = false;

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MessageBox.Show("NO SE PUEDE DAR DE ALTA - YA ASIGNADO", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //throw;
            }

        }

        private void btnEditarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                var v_HopitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();

                #region Conexion SIGESOFT Obtener Protocolo
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "select PR.v_ProtocolId " +
                              "from hospitalizacionservice HS " +
                              "inner join service SR on SR.v_ServiceId= HS.v_ServiceId " +
                              "inner join protocol PR on SR.v_ProtocolId=PR.v_ProtocolId " +
                              "where v_HopitalizacionId='" + v_HopitalizacionId + "'";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                v_ProtocoloId = "";
                while (lector.Read()) { v_ProtocoloId = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion

                #region Conexion SIGESOFT Obtener Plan
                conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + v_ProtocoloId + "'";
                comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                lector = comando.ExecuteReader();
                string plan = "";
                while (lector.Read()) { plan = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion
                string modoMasterService;
                if (plan != "") { modoMasterService = "ASEGU"; }
                else { modoMasterService = "HOSPI"; }
                var hospitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                var hospitalizacionHabitacionId = grdData.Selected.Rows[0].Cells["v_HospitalizacionHabitacionId"].Value.ToString();

                frmHabitaciones frm = new frmHabitaciones(hospitalizacionId, "Edit" + modoMasterService, hospitalizacionHabitacionId, v_ProtocoloId);


                //frmHabitacion frm = new frmHabitacion(hospitalizacionId, "Edit" + modoMasterService, hospitalizacionHabitacionId, v_ProtocoloId);
                //frmHabitacion frm = new frmHabitacion(hospitalizacionId, "Edit", hospitalizacionHabitacionId, v_ProtocoloId);

                frm.ShowDialog();
                btnFilter_Click(sender, e);
                btnEditarHabitacion.Enabled = false;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MessageBox.Show("NO SE PUEDE EDITAR HABITACIÓN - YA ASIGNADO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Hospitalización del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text;
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grdData, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //saveFileDialog1.FileName = string.Empty;
            //saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.ultraGridExcelExporter1.Export(this.grdData, saveFileDialog1.FileName);
            //    MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}      
        }

        private void btnAgregarExamenes_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            var serviceId = grdData.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            var protocolId = grdData.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();
            var NroHospitalizacion = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
            var dni = grdData.Selected.Rows[0].Cells["v_DocNumber"].Value.ToString();
            #region Conexion SAM
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion
            var cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + protocolId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            string plan = "";
            while (lector.Read())
            {
                plan = lector.GetValue(0).ToString();
            }
            lector.Close();
            conectasam.closesigesoft();

            var ListServiceComponent = new ServiceBL().GetServiceComponents_(ref objOperationResult, serviceId);
            ListaComponentes = new List<string>();
            foreach (var item in ListServiceComponent)
            {
                ListaComponentes.Add(item.v_ComponentId);
            }

            if (plan != "")
            {
                var frm = new frmAddExam(ListaComponentes, "ASEGU", protocolId, "Asegu", NroHospitalizacion, dni, serviceId, null) { _serviceId = serviceId };
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    btnFilter_Click(sender, e);
            }
            else
            {
                var frm = new frmAddExam(ListaComponentes, "HOSPI", protocolId, "Hospi", NroHospitalizacion, dni, serviceId, null) { _serviceId = serviceId };
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    btnFilter_Click(sender, e);
            }
            
                
        }

        private void btnReportePDF_Click(object sender, EventArgs e)
        {
            var hospitId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();

            frmLiquidacionReport liquidacionReport = new frmLiquidacionReport(hospitId);
            liquidacionReport.ShowDialog();

               
        }

        private void frmHospitalizados_Load(object sender, EventArgs e)
        {
            //btnExport.Enabled = false;
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                var hospitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                DateTime? fechaAlta = (DateTime?) (grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value == null
                    ? (ValueType) null
                    : DateTime.Parse(grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value.ToString()));
                var comentario = grdData.Selected.Rows[0].Cells["v_Comentario"].Value == null
                    ? ""
                    : grdData.Selected.Rows[0].Cells["v_Comentario"].Value.ToString();
                var frm = new frmDarAlta(hospitalizacionId, "Edit", fechaAlta, comentario);
                frm.ShowDialog();
                btnFilter_Click(sender, e);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MessageBox.Show("NO SE PUEDE DAR DE ALTA - YA ASIGNADO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }
        }

        private void grdData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.grdData.Rows)
            {
                var banda = e.Row.Band.Index.ToString();

                if (banda == "0")
                {
                    if (rowSelected.Band.Index.ToString() == "0")
                    {
                        if (e.Row.Cells["d_FechaAlta"].Value != null)
                        {

                            e.Row.Appearance.BackColor = Color.Yellow;

                            e.Row.Appearance.BackColor2 = Color.White;
                            btnTicket.Enabled = false;
                            btnEditarTicket.Enabled = false;
                            btnEliminarTicket.Enabled = false;
                            btnImprimirTicket.Enabled = false;
                            btnAgregarExamenes.Enabled = false;
                            btnEditExamen.Enabled = false;
                            bntEliminarExamen.Enabled = false;
                            btnAsignarHabitacion.Enabled = false;
                            btnEditarHabitacion.Enabled = false;
                            btnEliminarHabitacion.Enabled = false;
                            btnDarAlta.Enabled = false;
                            //btnLiberar.Enabled = false;
                            //Y doy el efecto degradado vertical
                            e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;

                            if (e.Row.Cells["MedicoPago"].Value.ToString() == "SR" && e.Row.Cells["PacientePago"].Value.ToString() == "SR")//MedicoPago PacientePago
                            {
                                e.Row.Appearance.BackColor = Color.Red;

                                e.Row.Appearance.BackColor2 = Color.White;
                                btnTicket.Enabled = false;
                                btnEditarTicket.Enabled = false;
                                btnEliminarTicket.Enabled = false;
                                btnImprimirTicket.Enabled = false;
                                btnAgregarExamenes.Enabled = false;
                                btnEditExamen.Enabled = false;
                                bntEliminarExamen.Enabled = false;
                                btnAsignarHabitacion.Enabled = false;
                                btnEditarHabitacion.Enabled = false;
                                btnEliminarHabitacion.Enabled = false;
                                btnDarAlta.Enabled = false;
                                //btnLiberar.Enabled = false;
                                //Y doy el efecto degradado vertical
                                e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;

                            }
                            

                            //if (decimal.Parse(e.Row.Cells["d_MontoPagado"].Value.ToString()) != 0)
                            //{
                            //    e.Row.Appearance.BackColor = Color.GreenYellow;

                            //    e.Row.Appearance.BackColor2 = Color.White;
                            //    btnTicket.Enabled = false;
                            //    btnEditarTicket.Enabled = false;
                            //    btnEliminarTicket.Enabled = false;
                            //    btnImprimirTicket.Enabled = false;
                            //    btnAgregarExamenes.Enabled = false;
                            //    btnEditExamen.Enabled = false;
                            //    bntEliminarExamen.Enabled = false;
                            //    btnAsignarHabitacion.Enabled = false;
                            //    btnEditarHabitacion.Enabled = false;
                            //    btnEliminarHabitacion.Enabled = false;
                            //    btnDarAlta.Enabled = false;
                            //    btnLiberar.Enabled = false;
                            //    //Y doy el efecto degradado vertical
                            //    e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                            //}
                        }


                    }
                }
                

            }           
        }

        private void btnEliminarTicket_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("¿Está seguro de eliminar el ticket?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                OperationResult objOperationResult = new OperationResult();
                TicketBL oTicketBL = new TicketBL();

                var ServiceId = grdData.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                var ticketId = grdData.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();
                oTicketBL.DeleteTicket(ticketId, Globals.ClientSession.GetAsList());

            }
        }

        private void btnGenerarLiq_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            var HopitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
            
            _serviceBL.GenerarLiquidacionHospitalizacion(ref objOperationResult, HopitalizacionId, Globals.ClientSession.GetAsList());

            btnFilter_Click(sender, e);

        }

        private void grdData_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new System.Drawing.Point(e.X, e.Y);
            Infragistics.Win.UIElement uiElement = ((Infragistics.Win.UltraWinGrid.UltraGridBase)sender).DisplayLayout.UIElement.ElementFromPoint(point);

            if (uiElement == null || uiElement.Parent == null)
                return;

            Infragistics.Win.UltraWinGrid.UltraGridRow row = (Infragistics.Win.UltraWinGrid.UltraGridRow)uiElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (row != null)
            {
                contextMenuStrip2.Items["btnRemoverEsamen"].Enabled = true;
            }
            else
            {
                contextMenuStrip2.Items["btnRemoverEsamen"].Enabled = false;
                contextMenuStrip2.Items["itemLimpieza"].Enabled = false;
            }

        }

        private void btnRemoverEsamen_Click(object sender, EventArgs e)
        {
            CalendarBL _objCalendarBL = new CalendarBL();
             if (grdData.Selected.Rows.Count == 0)
                return;

            ServiceBL oServiceBL = new ServiceBL();
            DialogResult Result = MessageBox.Show("¿Está seguro de eliminar este registro?", "ADVERTENCIA!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.OK)
            {
                var _auxiliaryExams = new List<ServiceComponentList>();
                OperationResult objOperationResult = new OperationResult();

                string v_ServiceComponentId = grdData.Selected.Rows[0].Cells["ServiceComponentId"].Value.ToString();
                string v_ServiceId = grdData.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();


                ServiceComponentList auxiliaryExam = new ServiceComponentList();
                auxiliaryExam.v_ServiceComponentId = v_ServiceComponentId;
                _auxiliaryExams.Add(auxiliaryExam);

                _objCalendarBL.UpdateAdditionalExam(_auxiliaryExams, v_ServiceId, (int?)SiNo.NO, Globals.ClientSession.GetAsList());
                btnFilter_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            var hospitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
            var hospitalizacionHabitacionId = grdData.Selected.Rows[0].Cells["v_HospitalizacionHabitacionId"].Value.ToString();

            var habtacion = new HospitalizacionHabitacionBL().GetHabitacion(ref objOperationResult, hospitalizacionHabitacionId);

            habtacion.i_IsDeleted = 1;
            habtacion.i_EstateRoom = 3;

            DialogResult Result = MessageBox.Show("¿Está seguro de eliminar habitación?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                new HospitalizacionHabitacionBL().UpdateHospitalizacionHabitacion(ref objOperationResult, habtacion, Globals.ClientSession.GetAsList());

                //this.Close();
               
               btnFilter_Click(sender, e);
            }
            //else
            //{
            //    this.Close();

            //}

            //btnFilter_Click(sender, e);
            //btnEliminarHabitacion.Enabled = false;
        }

        private void grdData_AfterRowUpdate(object sender, RowEventArgs e)
        {

        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            var v_HopitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();

            bool HabitacionEnUso = new HabitacionBL().GetHabitacionByHabitacionId(v_HopitalizacionId);



            #region Conexion SAM
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion

            var cadena1 = "update hospitalizacion set " +
                          "d_FechaAlta = NULL " +
                          "where v_HopitalizacionId='"+v_HopitalizacionId+"' ";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            lector.Close();
            btnFilter_Click(sender, e);
            MessageBox.Show("Se liberó el registro exitosamente.", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void btnVerHabitaciones_Click(object sender, EventArgs e)
        {
            //var v_HopitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
            var frm = new frmHabitaciones("", "View", "", "");
            frm.ShowDialog();
        }

        private void itemLimpieza_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
                return;
            var fechaFin = grdData.Selected.Rows[0].Cells["d_EndDate"].Value;
            if (fechaFin == null)
            {
                MessageBox.Show("La habitación está ocupada y no puede pasar a limpieza directamente.",
                    "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var v_HopitalizacionId = grdData.Selected.Rows[0].ParentCollection[0].Cells["v_HopitalizacionId"].Value.ToString();
            var nroHabitacion = grdData.Selected.Rows[0].Cells["NroHabitacion"].Value.ToString();
            
            var DialogResult = MessageBox.Show("Se pondrá en limpieza la habitación, ¿desea continuar?",
                "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                new HabitacionBL().UpdateEstateHabitacionLimpieza(v_HopitalizacionId, nroHabitacion);
            }
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            OperationResult _objOperationResult = new OperationResult();
            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                this.Enabled = false;

                var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

                var ticketId = grdData.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();

                var lista = _hospitBL.BuscarTicketsDetalle(ticketId);

                //var serviceId = lista.SelectMany(p => p.Servicios.Select(q=>q.v_ServiceId));
                //int doctor = 1;
                Ticket = _hospitBL.GetHospitServTicket(ticketId);
                hospser = _hospitBL.GetHospitServwithTicekt(Ticket.v_ServiceId);

                serv = _hospitBL.GetService(Ticket.v_ServiceId);
                prot = _hospitBL.GetProtocol(serv.v_ProtocolId);

                var datosP = _pacientBL.DevolverDatosPaciente(Ticket.v_ServiceId);

                string ruta = Common.Utils.GetApplicationConfigValue("rutaTicketsH").ToString();
                ServiceList personData = _serviceBL.GetServicePersonData(ref _objOperationResult, hospser.v_ServiceId);

                var hospitalizacion = _hospitBL.GetHospitalizacion(ref _objOperationResult, hospser.v_HopitalizacionId);
                var hospitalizacionhabitacion = _hospitBL.GetHospitalizacionHabitacion(ref _objOperationResult, hospser.v_HopitalizacionId);
                var medicoTratante = new ServiceBL().GetMedicoTratante(Ticket.v_ServiceId);
                
                string nombre = "Ticket N° " + ticketId + "_" + personData.v_DocNumber;

                TicketHosp.CreateTicket(ruta + nombre + ".pdf", MedicalCenter, lista, datosP, hospitalizacion, hospitalizacionhabitacion, medicoTratante, Ticket, prot);

                this.Enabled = true;
            }
            //this.Close();

        }

        private void itemCerrarHabitacion_Click(object sender, EventArgs e)
        {
            var v_HopitalizacionId = grdData.Selected.Rows[0].ParentCollection[0].Cells["v_HopitalizacionId"].Value.ToString();
            bool IsUpdateHabitacion = new HabitacionBL().UpdateEstateHabitacionByHospId(v_HopitalizacionId);
            if (IsUpdateHabitacion)
            {
                MessageBox.Show(
                    "El estado de la habitación será de 'En Limpieza', por favor dar aviso al personal correspondiente",
                    "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid();
            }
            else
            {
                MessageBox.Show(
                    "Sucedió un error, por favor vuelva a intentar.",
                    "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editarExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string serviceComponentId = grdData.Selected.Rows[0].Cells["ServiceComponentId"].Value.ToString();
            string serviceComponentName = grdData.Selected.Rows[0].Cells["Componente"].Value.ToString();
            frmEditServiceComponent from = new frmEditServiceComponent(serviceComponentId, serviceComponentName);
            from.ShowDialog();
            btnFilter_Click(sender, e);
        }

        private void btnEditExamen_Click(object sender, EventArgs e)
        {
            var ServiceComponentId = grdData.Selected.Rows[0].Cells["ServiceComponentId"].Value.ToString();
            Hospitalizacion.CargoExamen from = new Hospitalizacion.CargoExamen(ServiceComponentId);
            from.ShowDialog();
        }

        private void bntEliminarExamen_Click(object sender, EventArgs e)
        {
            var ServiceComponentId = grdData.Selected.Rows[0].Cells["ServiceComponentId"].Value.ToString();
            #region CONSULTA
            ConexionSigesoft conectasam_1 = new ConexionSigesoft();
            conectasam_1.opensigesoft();
            var cadena1_1 = "select c.v_Name from [dbo].[servicecomponent] sc join [dbo].[component] c on sc.v_ComponentId = c.v_ComponentId  where sc.v_ServiceComponentId = '" + ServiceComponentId + "'";
            SqlCommand comando_1 = new SqlCommand(cadena1_1, connection: conectasam_1.conectarsigesoft);
            SqlDataReader lector_1 = comando_1.ExecuteReader();
            string Componente = "";
            while (lector_1.Read())
            {
                Componente = lector_1.GetValue(0).ToString();
            }
            lector_1.Close();
            conectasam_1.closesigesoft();

            #endregion
            DialogResult Result = MessageBox.Show("¿Está seguro de eliminar el servicio " + Componente + " ? ", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "update [dbo].[servicecomponent] set i_IsRequiredId = 0 , i_IsDeleted  = 1 where v_ServiceComponentId = '" + ServiceComponentId + "'";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                lector.Close();
                conectasam.closesigesoft();
            }
            btnFilter_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            string tabName = tabControl1.SelectedTab.Text;

            if (tabName == "HOSPITALIZADOS / SOP")
            {
                var HospId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                var Pac = grdData.Selected.Rows[0].Cells["v_Paciente"].Value.ToString();
                var Dni = grdData.Selected.Rows[0].Cells["v_DocNumber"].Value.ToString();
                var Edad = grdData.Selected.Rows[0].Cells["Edad"].Value.ToString();
                var Medico = grdData.Selected.Rows[0].Cells["v_MedicoTratante"].Value.ToString();
                var Cie10 = grdData.Selected.Rows[0].Cells["v_Cie10"].Value.ToString();
                var Dx = grdData.Selected.Rows[0].Cells["v_Diagnostico"].Value.ToString();
                var Procedencia = grdData.Selected.Rows[0].Cells["TipoDeIngreso"].Value.ToString();
                //var Hosp = grdData.Selected.Rows[0].Cells["Hosp"].Value.ToString();
                //var Sop = grdData.Selected.Rows[0].Cells["Sop"].Value.ToString();
                var FechaAlta = grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value == null ? "" : grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value.ToString();

                //var Comentarios = grdData.Selected.Rows[0].Cells["v_Comentario"].Value == null ? "" : grdData.Selected.Rows[0].Cells["v_Comentario"].Value.ToString();
                var PersonId = grdData.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();


                var Cie10Salida = grdData.Selected.Rows[0].Cells["v_CIE10IdSalida"].Value.ToString();
                var DxSalida = grdData.Selected.Rows[0].Cells["v_DiseasesNameSalida"].Value.ToString();
                var ProcedimientoId = grdData.Selected.Rows[0].Cells["i_ProcedimientoSOP"].Value == null ? "- - -" : grdData.Selected.Rows[0].Cells["i_ProcedimientoSOP"].Value.ToString();
                var ProcedimientoDesc = grdData.Selected.Rows[0].Cells["v_ProcedimientoSOP"].Value.ToString();

                frmRegistroHospSop ticket = new frmRegistroHospSop(HospId, Pac, Dni, Edad, Medico, Cie10, Dx, Procedencia, "Hosp", "Sop", FechaAlta, "Comentarios", PersonId, Cie10Salida, DxSalida, ProcedimientoId, ProcedimientoDesc);
                ticket.ShowDialog();
            }
            else
            {
                var HospId = ultraGrid1.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                var Pac = ultraGrid1.Selected.Rows[0].Cells["v_Paciente"].Value.ToString();
                var Dni = ultraGrid1.Selected.Rows[0].Cells["v_DocNumber"].Value.ToString();
                var Edad = ultraGrid1.Selected.Rows[0].Cells["Edad"].Value.ToString();
                var Medico = ultraGrid1.Selected.Rows[0].Cells["v_MedicoTratante"].Value.ToString();
                var Cie10 = grdData.Selected.Rows[0].Cells["v_Cie10"].Value.ToString();
                var Dx = grdData.Selected.Rows[0].Cells["v_Diagnostico"].Value.ToString();
                var Procedencia = ultraGrid1.Selected.Rows[0].Cells["TipoDeIngreso"].Value.ToString();

                //var Hosp = grdData.Selected.Rows[0].Cells["Hosp"].Value.ToString();
                //var Sop = grdData.Selected.Rows[0].Cells["Sop"].Value.ToString();
                var FechaAlta = ultraGrid1.Selected.Rows[0].Cells["d_FechaAlta"].Value == null ? "" : grdData.Selected.Rows[0].Cells["d_FechaAlta"].Value.ToString();

                //var Comentarios = grdData.Selected.Rows[0].Cells["v_Comentario"].Value == null ? "" : grdData.Selected.Rows[0].Cells["v_Comentario"].Value.ToString();
                var PersonId = grdData.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();


                var Cie10Salida = ultraGrid1.Selected.Rows[0].Cells["v_CIE10IdSalida"].Value.ToString();
                var DxSalida = ultraGrid1.Selected.Rows[0].Cells["v_DiseasesNameSalida"].Value.ToString();
                var ProcedimientoId = ultraGrid1.Selected.Rows[0].Cells["i_ProcedimientoSOP"].Value == null ? "- - -" : ultraGrid1.Selected.Rows[0].Cells["i_ProcedimientoSOP"].Value.ToString();
                var ProcedimientoDesc = ultraGrid1.Selected.Rows[0].Cells["v_ProcedimientoSOP"].Value.ToString();

                frmRegistroHospSop ticket = new frmRegistroHospSop(HospId, Pac, Dni, Edad, Medico, Cie10, Dx, Procedencia, "Hosp", "Sop", FechaAlta, "Comentarios", PersonId, Cie10Salida, DxSalida, ProcedimientoId, ProcedimientoDesc);
                ticket.ShowDialog();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Emergencias del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text;
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.ultraGrid1, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTipoPacClin_Click(object sender, EventArgs e)
        {
            string tabName = tabControl1.SelectedTab.Text;


            if (tabName == "HOSPITALIZADOS / SOP")
            {
                var hospitalizacionId = grdData.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                frmInformacionComplementaria frm = new frmInformacionComplementaria(hospitalizacionId);
                frm.ShowDialog();

                this.BindGrid(); 
            }
            else
            {
                var hospitalizacionId = ultraGrid1.Selected.Rows[0].Cells["v_HopitalizacionId"].Value.ToString();
                frmInformacionComplementariaEmergencia frm = new frmInformacionComplementariaEmergencia(hospitalizacionId);
                frm.ShowDialog();

                this.BindGridEmergencia(); 
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frmAdministracionCamas();
            frm.ShowDialog();
        }

        private void txtPacient_KeyUp(object sender, KeyEventArgs e)
        {
            string tabName = tabControl1.SelectedTab.Text;

            if (tabName == "HOSPITALIZADOS / SOP")
            {
                if (txtPacient.Text != string.Empty)
                {
                    List<HospSopList> listnew = new List<HospSopList>();

                    listnew = new List<HospSopList>(_HospSopList.Where(p => p.v_Paciente.Contains(txtPacient.Text.ToUpper()) || p.v_DocNumber.Contains(txtPacient.Text.ToUpper())));

                    var listBinding = new BindingList<HospSopList>(listnew);

                    grdData.DataSource = listBinding;

                    if (listBinding != null)
                    {
                        lblRecordCount.Text = string.Format("Se encontraron {0} registros.", listBinding.Count());

                    }

                }
                else
                {
                    grdData.DataSource = _HospSopList;
                    if (grdData != null)
                    {
                        lblRecordCount.Text = string.Format("Se encontraron {0} registros.", _HospSopList.Count());

                    }
                }
            }
            else
            {
                if (txtPacient.Text != string.Empty)
                {
                    List<EmergenciapList> listnew = new List<EmergenciapList>();

                    listnew = new List<EmergenciapList>(_EmergenciapList.Where(p => p.v_Paciente.Contains(txtPacient.Text.ToUpper()) || p.v_DocNumber.Contains(txtPacient.Text.ToUpper())));

                    var listBinding = new BindingList<EmergenciapList>(listnew);

                    ultraGrid1.DataSource = listBinding;

                    if (listBinding != null)
                    {
                        label3.Text = string.Format("Se encontraron {0} registros.", listBinding.Count());

                    }

                }
                else
                {
                    ultraGrid1.DataSource = _EmergenciapList;
                    if (ultraGrid1 != null)
                    {
                        label3.Text = string.Format("Se encontraron {0} registros.", _EmergenciapList.Count());

                    }
                }
            }
            
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
                grdData.DataSource = _HospSopList;
                if (grdData != null)
                    {
                        lblRecordCount.Text = string.Format("Se encontraron {0} registros.", _HospSopList.Count());
                    }
            }
        }

        private void rbHosp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHosp.Checked == true)
            {
                List<HospSopList> listnew = new List<HospSopList>();

                listnew = new List<HospSopList>(_HospSopList.Where(p => p.v_Servicio == "HOSPITALIZACIÓN"));

                var listBinding = new BindingList<HospSopList>(listnew);

                grdData.DataSource = listBinding;

                if (listBinding != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", listBinding.Count());

                }
            }
        }

        private void rbSop_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSop.Checked == true)
            {
                List<HospSopList> listnew = new List<HospSopList>();

                listnew = new List<HospSopList>(_HospSopList.Where(p => p.v_Servicio != "HOSPITALIZACIÓN"));

                var listBinding = new BindingList<HospSopList>(listnew);

                grdData.DataSource = listBinding;

                if (listBinding != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", listBinding.Count());

                }
            }
        }           

    }
}
