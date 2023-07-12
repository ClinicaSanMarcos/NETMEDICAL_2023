using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Common;

namespace Sigesoft.Node.WinClient.UI.Usuarios
{
    public partial class frmUsers : Form
    {
        private SecurityBL _objSecurityBL = new SecurityBL();
        private PacientBL _objPerson = new PacientBL();
        private OperationResult objOperation = new OperationResult();
        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {

            var list = _objSecurityBL.GetSystemUserPagedAndFiltered(ref objOperation, null, null, null, txtUserName.Text);
            grdData.DataSource = list;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUserAdd frm = new frmUserAdd("New", null, null);
            frm.ShowDialog();
            BindingGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                string personId = grdData.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();
                int userId = Int32.Parse(grdData.Selected.Rows[0].Cells["i_SystemUserId"].Value.ToString());
                frmUserAdd frm = new frmUserAdd("Edit", userId, personId);
                frm.ShowDialog();
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para actualizar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar usuario ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    string personId = grdData.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();
                    int userId = Int32.Parse(grdData.Selected.Rows[0].Cells["i_SystemUserId"].Value.ToString());
                    _objSecurityBL.DeleteSystemUSer(ref objOperation, userId, Globals.ClientSession.GetAsList());
                    _objPerson.DeletePerson(ref objOperation, personId, Globals.ClientSession.GetAsList());
                    BindingGrid();
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        
    }
}
