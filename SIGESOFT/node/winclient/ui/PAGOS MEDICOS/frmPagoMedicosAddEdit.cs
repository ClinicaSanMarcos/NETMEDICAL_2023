using Infragistics.Win.UltraWinGrid;
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

namespace Sigesoft.Node.WinClient.UI.PAGOS_MEDICOS
{
    public partial class frmPagoMedicosAddEdit : Form
    {
        ServiceBL oServiceBL = new ServiceBL();
        OperationResult objOperationResult = new OperationResult();
        HospitalizacionBL oHospitalizacionBL = new HospitalizacionBL();
        private string _IdConfPago;
        public frmPagoMedicosAddEdit()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            //List<string> Componentes = new List<string>();
            //var listServicecomponents = oServiceBL.GetServiceComponentsConfig(ref objOperationResult);
            //foreach (var obj in listServicecomponents)
            //{
            //    Componentes.Add(obj.v_ComponentId);
            //}

            var frm = new frmConfiguracionPagos(null, "New", null);
            frm.ShowDialog();
            BindGrid("");
        }

        private void frmPagoMedicosAddEdit_Load(object sender, EventArgs e)
        {


            Utils.LoadDropDownList(ddlUsuarioConf, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlUsuario, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);

            Utils.LoadDropDownList(ddlServiceTypeId, "Value1", "Id", BLL.Utils.GetSystemParameterByParentIdForCombo(ref objOperationResult, 119, -1, null), DropDownListAction.Select);
            ddlServiceTypeId.SelectedIndex = 2;

        }

        string strFilterExpression;
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Filters = new List<string>();
            if (ddlUsuario.SelectedValue.ToString() != "-1")
                Filters.Add("i_SystemUserId ==" + ddlUsuario.SelectedValue);

            strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    strFilterExpression = strFilterExpression + item + " && ";
                }
                strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
            }

            BindGrid(strFilterExpression);
        }

        private void BindGrid(string strFilterExpression)
        {
            var data = oHospitalizacionBL.GetMedicosConfiguracionPago(strFilterExpression);
            ultraGrid3.DataSource = data;
        }

        private void ultraGrid3_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.ultraGrid3.Selected.Rows)
            {
                btnEditar.Enabled =
                btnEliminar.Enabled =

                (ultraGrid3.Selected.Rows.Count > 0);

                if (ultraGrid3.Selected.Rows.Count == 0)
                    return;

                _IdConfPago = ultraGrid3.Selected.Rows[0].Cells["v_IdConfPago"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ultraGrid3.Selected.Rows.Count > 0)
            {
                _IdConfPago = ultraGrid3.Selected.Rows[0].Cells["v_IdConfPago"].Value.ToString();

                var frm = new frmConfiguracionPagos(null, "Edit", _IdConfPago);
                frm.ShowDialog();

                BindGrid("");
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
