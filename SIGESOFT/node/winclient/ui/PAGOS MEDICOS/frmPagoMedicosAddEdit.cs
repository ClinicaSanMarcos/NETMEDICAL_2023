using Sigesoft.Common;
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

            var frm = new frmConfiguracionPagos(null);
            frm.ShowDialog();
            //BindGrid("");
        }

        private void frmPagoMedicosAddEdit_Load(object sender, EventArgs e)
        {


            Utils.LoadDropDownList(ddlUsuarioConf, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlUsuario, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);

            Utils.LoadDropDownList(ddlServiceTypeId, "Value1", "Id", BLL.Utils.GetSystemParameterByParentIdForCombo(ref objOperationResult, 119, -1, null), DropDownListAction.Select);
            ddlServiceTypeId.SelectedIndex = 2;

        }
    }
}
