using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;

//using System.Linq.Expressions;

namespace Sigesoft.Node.WinClient.UI.ReportesCSM
{
    public partial class frmReportesAtenciones : Form
    {
        string strFilterExpression;
        List<HospSopList> _objData2 = new List<HospSopList>();
        List<EmergenciapList> _objData3 = new List<EmergenciapList>();
        List<AmbulatorioList> _objData4 = new List<AmbulatorioList>();

        List<HospSopList> _HospSopList = new List<HospSopList>();
        List<EmergenciapList> _EmergenciapList = new List<EmergenciapList>();
        List<AmbulatorioList> _AmbulatorioList = new List<AmbulatorioList>();

        
        HospitalizacionBL _objHospBL = new HospitalizacionBL();

        public frmReportesAtenciones()
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
            else if (tabName == "EMERGENCIA")
            {
                this.BindGridEmergencia();
            }
            else if (tabName == "AMBULATORIO")
            {
                this.BindGridAmbulatorio();
            }
        }
        private void BindGrid()
        {
            var objData = GetData(0, null, "v_HopitalizacionId ASC", strFilterExpression);
            _HospSopList = objData;
            grdData.DataSource = objData;

            if (objData.Count() >= 1)
            {
                lblRecordCount.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                btnExport.Enabled = true;
            }
            else
            {
                lblRecordCount.Text = string.Format("Se encontraron 0 registros.");
                btnExport.Enabled = false;
            }
        }

        private void BindGridEmergencia()
        {
            var objData = GetDataEmrg(0, null, "v_HopitalizacionId ASC", strFilterExpression);
            _EmergenciapList = objData;
            ultraGrid1.DataSource = objData;

            if (objData.Count() >= 1)
            {
                label3.Text = string.Format("Se encontraron {0} registros.", objData.Count());

                button2.Enabled = true;
            }
            else
            {
                label3.Text = string.Format("Se encontraron 0 registros.");
                button2.Enabled = false;
            }
        }

        private void BindGridAmbulatorio()
        {
            var objData = GetDataAmb(0, null, "v_ServiceId ASC", strFilterExpression);
            
            _AmbulatorioList = objData;
            ultraGrid2.DataSource = objData;

            if (objData.Count() >= 1)
            {
                label6.Text = string.Format("Se encontraron {0} registros.", objData.Count());
                button1.Enabled = true;
            }
            else
            {
                label6.Text = string.Format("Se encontraron 0 registros.");
                button1.Enabled = false;
            }
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

        private List<AmbulatorioList> GetDataAmb(int pintPageIndex, int? pintPageSize, string pstrSortExpression, string pstrFilterExpression)
        {
            OperationResult objOperationResult = new OperationResult();
            DateTime? pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime? pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            _objData4 = new ProductPackageBL().GetAmbulatorioPagedAndFiltered2(pdatBeginDate, pdatEndDate);

           
            return _objData4;
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

        private void txtPacient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnFilter_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "";
            NombreArchivo = "Reporte Consultas Ambulatorias del " + dtpDateTimeStar.Text + " al " + dptDateTimeEnd.Text;
            NombreArchivo = NombreArchivo.Replace("/", "_");
            NombreArchivo = NombreArchivo.Replace(":", "_");

            saveFileDialog1.FileName = NombreArchivo;
            saveFileDialog1.Filter = "Files (*.xls;*.xlsx;*)|*.xls;*.xlsx;*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ultraGridExcelExporter1.Export(this.ultraGrid2, saveFileDialog1.FileName);
                MessageBox.Show("Se exportaron correctamente los datos.", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
