using System;
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

namespace Sigesoft.Node.WinClient.UI.Usuarios
{
    public partial class frmUserRol : Form
    {
        private SecurityBL _security = new SecurityBL();
        private OperationResult objOperationResult = new OperationResult();
        private int _userId;
        public frmUserRol(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void frmUserRol_Load(object sender, EventArgs e)
        {
            var nodeList = BLL.Utils.GetAllNodeForCombo(ref objOperationResult);
            UI.Utils.LoadDropDownList(cboNodo, "Value1", "Id", nodeList, DropDownListAction.Select);
            BindingGrid();
        }

        private void BindingGrid()
        {
            var list = _security.GetSystemUserRoleNodeForGridView(ref objOperationResult, _userId);
            grdData.DataSource = list;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdData.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar el ROL ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    int nodeId = Int32.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());
                    int roleId = Int32.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                    _security.DeleteSystemUserRoleNode(ref objOperationResult, nodeId, _userId, roleId, Globals.ClientSession.GetAsList());
                    BindingGrid();
                }      
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var objEntityDTO = new systemuserrolenodeDto();

            objEntityDTO.i_SystemUserId = _userId;
            objEntityDTO.i_RoleId = int.Parse(cboRol.SelectedValue.ToString());
            objEntityDTO.i_NodeId = int.Parse(cboNodo.SelectedValue.ToString());

            _security.AddSystemUserRoleNode(ref objOperationResult, objEntityDTO, Globals.ClientSession.GetAsList());

            if (objOperationResult.ErrorMessage != null)
            {
                MessageBox.Show(objOperationResult.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BindingGrid();
        }

        private void cboNodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleList = BLL.Utils.GetRoleByNodeIdForCombo(ref objOperationResult, int.Parse(cboNodo.SelectedValue.ToString()));

            UI.Utils.LoadDropDownList(cboRol, "Value1", "Id", roleList, DropDownListAction.Select);
        }

    }
}
