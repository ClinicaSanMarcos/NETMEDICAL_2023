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

namespace Sigesoft.Node.WinClient.UI.Rol
{
    public partial class frmRoles : Form
    {
        private NodeBL _nodeBL = new NodeBL();
        private OperationResult objOperationResult = new OperationResult();
        public frmRoles()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {

            var list = _nodeBL.GetRoleNode(ref objOperationResult, Globals.ClientSession.i_CurrentExecutionNodeId, txtRolName.Text);
            grdData.DataSource = list;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void txtRolName_KeyUp(object sender, KeyEventArgs e)
        {
            BindingGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAddRol frm = new frmAddRol("New", null, null);
            frm.ShowDialog();
            BindingGrid();
        }

        private void grdData_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdData.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                int roleId = int.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                string roleName = grdData.Selected.Rows[0].Cells["v_RoleName"].Value.ToString();
                frmAddRol frm = new frmAddRol("Edit", roleId, roleName);
                frm.ShowDialog();
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar el registro ?", "CONFIRMACIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    int roleId = int.Parse(grdData.Selected.Rows[0].Cells["i_RoleId"].Value.ToString());
                    bool ok = new NodeBL().DeleteRoleNode(roleId);
                    if (ok)
                    {
                        BindingGrid();
                    }
                    else
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
