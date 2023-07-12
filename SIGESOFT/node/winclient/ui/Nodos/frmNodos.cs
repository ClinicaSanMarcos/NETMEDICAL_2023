using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;

namespace Sigesoft.Node.WinClient.UI.Nodos
{
    public partial class frmNodos : Form
    {
        private NodeBL _nodeBl = new NodeBL();
        public frmNodos()
        {
            InitializeComponent();
        }

        private void frmNodos_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            var list = _nodeBl.GetNodePagedAndFiltered(txtNodeName.Text);
            grdData.DataSource = list;
        }

        private void txtNodeName_KeyUp(object sender, KeyEventArgs e)
        {
            BindingGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAddNode frm = new frmAddNode("New", null);
            frm.ShowDialog();
            BindingGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());

                frmAddNode frm = new frmAddNode("Edit", nodeId);
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
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar el registro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());
                    bool ok = _nodeBl.DeleteNode(nodeId);
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

        private void grdData_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            if (grdData.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnEditar.Enabled = true;
                btnEditarNodoRol.Enabled = true;
            }
        }

        private void btnEditarNodoRol_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                int nodeId = int.Parse(grdData.Selected.Rows[0].Cells["i_NodeId"].Value.ToString());

                frmNodoRol frm = new frmNodoRol(nodeId);
                frm.ShowDialog();
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
