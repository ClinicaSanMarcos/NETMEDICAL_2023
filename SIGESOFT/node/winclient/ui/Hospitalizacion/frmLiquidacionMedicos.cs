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
using Infragistics.Win.UltraWinGrid;

using Sigesoft.Node.Contasol.Integration;
using Sigesoft.Node.WinClient.BE;
using NetPdf;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmLiquidacionMedicos : Form
    {
        string strFilterExpression;
        string idMedico = null;
        public frmLiquidacionMedicos()
        {
            InitializeComponent();
        }
        
        private void frmLiquidacionMedicos_Load(object sender, EventArgs e)
        {
            OperationResult objOperationResult1 = new OperationResult();
            Utils.LoadDropDownList(ddlUsuario, "Value1", "Id", BLL.Utils.GetProfessionalName(ref objOperationResult1), DropDownListAction.All);

            UltraGridColumn c = grdData.DisplayLayout.Bands[1].Columns["Select"];
            c.CellActivation = Activation.AllowEdit;
            c.CellClickAction = CellClickAction.Edit;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<string> Filters = new List<string>();
            if (ddlUsuario.SelectedValue.ToString() != "-1") Filters.Add("MedicoTratanteId==" + ddlUsuario.SelectedValue);

            strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    strFilterExpression = strFilterExpression + item + " && ";
                }
                strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
            }

            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                this.BindGrid();
            };
        }

        
        private void BindGrid()
        {
            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            HospitalizacionBL o = new HospitalizacionBL();
              var data  =o.LiquidacionMedicos(strFilterExpression, pdatBeginDate, pdatEndDate, chkPagados.Checked == true ? 1 : 0);       
              grdData.DataSource = data;

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            UltraGridBand band = this.grdData.DisplayLayout.Bands[1];
            HospitalizacionBL o = new HospitalizacionBL();
            var listapagos = new List<LiquidacionMedicoList>();

            List<LiquidacionServicios> _data = new List<LiquidacionServicios>();
            if (ddlUsuario.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Debe elegir un Medico a pagar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            foreach (UltraGridRow row in band.GetRowEnumerator(GridRowType.DataRow))
            {
                if ((bool)row.Cells["Select"].Value)
                {
                    var oLiquidacionMedicoList = new LiquidacionServicios();

                    string serviceId = row.Cells["v_ServiceId"].Value.ToString();
                    o.ActualizarPagoMedico(serviceId);

                    oLiquidacionMedicoList.d_ServiceDate = DateTime.Parse(row.Cells["d_ServiceDate"].Value.ToString());
                    oLiquidacionMedicoList.Paciente = row.Cells["Paciente"].Value.ToString();

                    oLiquidacionMedicoList.Tipo = row.Cells["Tipo"].Value.ToString();
                    oLiquidacionMedicoList.Aseguradora = row.Cells["Aseguradora"].Value == null ? "" : row.Cells["Aseguradora"].Value.ToString();
                    oLiquidacionMedicoList.v_ServiceId = row.Cells["v_ServiceId"].Value.ToString();
                    oLiquidacionMedicoList.r_Comision = decimal.Parse(row.Cells["r_Comision"].Value.ToString());

                    _data.Add(oLiquidacionMedicoList);

                }
            }

            
            btnFilter_Click(sender, e);

            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                this.Enabled = false;

                var MedicalCenter = new ServiceBL().GetInfoMedicalCenter();
                OperationResult objOperationResult = new OperationResult();

                DateTime? fechaInicio = dtpDateTimeStar.Value.Date;
                DateTime? fechaFin = dptDateTimeEnd.Value.Date.AddDays(1);

                string fechaInicio_1 = fechaInicio.ToString().Split(' ')[0];
                string fechaFin_1 = fechaFin.ToString().Split(' ')[0];

                string ruta = Common.Utils.GetApplicationConfigValue("rutaPagoMedicos").ToString();

                string fecha = DateTime.Now.ToString().Split('/')[0] + "-" + DateTime.Now.ToString().Split('/')[1] + "-" + DateTime.Now.ToString().Split('/')[2];
                string nombre = "Pago Medico - CSL";

                var medico_info = new ServiceBL().GetSystemUser(ref objOperationResult, int.Parse(ddlUsuario.SelectedValue.ToString()));

                PagoMedicoAsitencial.CreatePagoMedicoAsitencial(ruta + nombre + ".pdf", MedicalCenter, _data, fechaInicio_1, fechaFin_1, medico_info);
                this.Enabled = true;
            }
        }

        private void grdData_ClickCell(object sender, ClickCellEventArgs e)
        {
            if ((e.Cell.Column.Key == "Select"))
            {
                if ((e.Cell.Value.ToString() == "False"))
                    e.Cell.Value = true;
                else
                    e.Cell.Value = false;
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Liquidación de Médicos del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text;
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.grdData, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdData_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.grdData.Selected.Rows)
            {
                if (rowSelected.Band.Index.ToString() == "0")
                {
                    idMedico = grdData.Selected.Rows[0].Cells["MedicoTratante"].Value.ToString();
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UltraGridBand band = this.grdData.DisplayLayout.Bands[1];
            List<LiquidacionServicios> _data = new List<LiquidacionServicios>();
            foreach (UltraGridRow row in band.GetRowEnumerator(GridRowType.DataRow))
            {
                if ((bool)row.Cells["Select"].Value)
                {
                    var oLiquidacionMedicoList = new LiquidacionServicios();

                    //string serviceId = row.Cells["v_ServiceId"].Value.ToString();
                    //o.ActualizarPagoMedico(serviceId);

                    oLiquidacionMedicoList.d_ServiceDate = DateTime.Parse(row.Cells["d_ServiceDate"].Value.ToString());
                    oLiquidacionMedicoList.Paciente = row.Cells["Paciente"].Value.ToString();

                    oLiquidacionMedicoList.Tipo = row.Cells["Tipo"].Value.ToString();
                    oLiquidacionMedicoList.Aseguradora = row.Cells["Aseguradora"].Value == null ? "" : row.Cells["Aseguradora"].Value.ToString();
                    oLiquidacionMedicoList.v_ServiceId = row.Cells["v_ServiceId"].Value.ToString();
                    oLiquidacionMedicoList.r_Comision = decimal.Parse(row.Cells["r_Comision"].Value.ToString()); //TipoPagoMed
                    oLiquidacionMedicoList.TipoPagoMed = row.Cells["TipoPagoMed"].Value.ToString();

                    _data.Add(oLiquidacionMedicoList);

                }
            }
            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                this.Enabled = false;

                var MedicalCenter = new ServiceBL().GetInfoMedicalCenter();
                OperationResult objOperationResult = new OperationResult();

                DateTime? fechaInicio = dtpDateTimeStar.Value.Date;
                DateTime? fechaFin = dptDateTimeEnd.Value.Date.AddDays(1);

                string fechaInicio_1 = fechaInicio.ToString().Split(' ')[0];
                string fechaFin_1 = fechaFin.ToString().Split(' ')[0];

                string ruta = Common.Utils.GetApplicationConfigValue("rutaPagoMedicos").ToString();

                string fecha = DateTime.Now.ToString().Split('/')[0] + "-" + DateTime.Now.ToString().Split('/')[1] + "-" + DateTime.Now.ToString().Split('/')[2];
                string nombre = "Pago Medico - CSL";

                var medico_info = new ServiceBL().GetSystemUser(ref objOperationResult, int.Parse(ddlUsuario.SelectedValue.ToString()));

                PagoMedicoAsitencial.CreatePagoMedicoAsitencial(ruta + nombre + ".pdf", MedicalCenter, _data, fechaInicio_1, fechaFin_1, medico_info);
                this.Enabled = true;
            }
        }

        private void chkPagados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPagados.Checked == true)
            {
                btnPagar.Enabled = false;
                btnImprimir.Enabled = true;
            }
            else
            {
                btnPagar.Enabled = true;
                btnImprimir.Enabled = false;
            }
        }
    }
}
