using Sigesoft.Node.WinClient.BE;
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
using Sigesoft.Node.WinClient.UI.Rol;

namespace Sigesoft.Node.WinClient.UI.Nodos
{
    public partial class frmNodoRol : Form
    {
        private NodeBL _objNodeBL = new NodeBL();
        private OperationResult objOperationResult = new OperationResult();
        private int NodeId;
        public frmNodoRol(int nodeId)
        {
            NodeId = nodeId;
            InitializeComponent();
        }

        private void frmNodoRol_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar el registro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());
                    int roleId = int.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                    _objNodeBL.DeleteRoleAll(ref objOperationResult, nodeId, roleId, 1, Globals.ClientSession.GetAsList());
                    if (objOperationResult.ErrorMessage == null)
                    {
                        MessageBox.Show("Se eliminó correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        BindingGrid();
                    }
                    else
                    {
                        MessageBox.Show(objOperationResult.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BindingGrid()
        {
            List<RoleNodeList> objData = _objNodeBL.GetRoleNode(ref objOperationResult, NodeId, "");
            grdData.DataSource = objData;
        }

        private void grdData_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdData.Rows.Count > 0)
            {
                btnNuevo.Enabled = true;
                btnEliminar.Enabled = true;
                btnAddComponente.Enabled = true;
            }
        }

        private void btnAddComponente_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {

                int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());
                int roleId = int.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                string name = grdData.Selected.Rows[0].Cells["v_RoleName"].Value.ToString();
                frmComponentNode frm = new frmComponentNode(nodeId, roleId, name);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {

                int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());
                int roleId = int.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                string name = grdData.Selected.Rows[0].Cells["v_RoleName"].Value.ToString();
                frmAddRoleNode frm = new frmAddRoleNode(nodeId, roleId, name);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            frmAddRol frm = new frmAddRol("New", null, null);
            frm._nodeId = NodeId;
            frm.ShowDialog();
            BindingGrid();
        }

    }
}
