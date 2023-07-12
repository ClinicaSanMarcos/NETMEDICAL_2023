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

namespace Sigesoft.Node.WinClient.UI.Nodos
{
    public partial class frmComponentNode : Form
    {
        OperationResult objOperationResult = new OperationResult();
        NodeBL _nodeBl = new NodeBL();
        private int _nodeId, _roleId;
        private string _name;

        
        public frmComponentNode(int nodeId, int roleId, string name)
        {
            _name = name;
            _nodeId = nodeId;
            _roleId = roleId;
            InitializeComponent();
        }

        private void frmComponentNode_Load(object sender, EventArgs e)
        {
            txtName.Text = _name;
            BindingGrid();
        }

        private void BindingGrid()
        {
            List<RoleNodeComponentProfileList> objData = _nodeBl.GetRoleNodeComponentProfileForGridView(ref objOperationResult, _nodeId, _roleId);
            grdData.DataSource = objData;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar el registro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    string rolenodeCompId = grdData.Selected.Rows[0].Cells["v_RoleNodeComponentId"].Value.ToString();
                    bool ok = _nodeBl.DeleteRoleNodeComponentProfile(rolenodeCompId);
                    if (ok)
                    {
                        MessageBox.Show("Se eliminó correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                string sinoLec = grdData.Selected.Rows[0].Cells["v_Read"].Value.ToString();
                string sinoEsc = grdData.Selected.Rows[0].Cells["v_Write"].Value.ToString();
                string sinoDx = grdData.Selected.Rows[0].Cells["v_Dx"].Value.ToString();
                string sinoApro = grdData.Selected.Rows[0].Cells["v_Approved"].Value.ToString();
                string rolenodeCompId = grdData.Selected.Rows[0].Cells["v_RoleNodeComponentId"].Value.ToString();
                string name = grdData.Selected.Rows[0].Cells["v_ComponentName"].Value.ToString();
                frmUpdateComponentRol frm = new frmUpdateComponentRol("Edit", ReturnValueBool(sinoLec), ReturnValueBool(sinoEsc), ReturnValueBool(sinoDx), ReturnValueBool(sinoApro), name, rolenodeCompId);
                frm.ShowDialog();
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAddComponentNode frm = new frmAddComponentNode(_nodeId, _roleId);
            frm.ShowDialog();
            BindingGrid();
        }

        private bool ReturnValueBool(string sino)
        {
            if (sino == "Si")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void grdData_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdData.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnActualizar.Enabled = true;
            }
        }

    }
}
