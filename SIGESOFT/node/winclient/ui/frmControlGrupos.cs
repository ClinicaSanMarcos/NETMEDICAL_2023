using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmControlGrupos : Form
    {
        public frmControlGrupos()
        {
            InitializeComponent();
        }

        private void frmControlGrupos_Load(object sender, EventArgs e)
        {
            int mes = DateTime.Now.Month - 1;
            cboMes.SelectedIndex = mes;
            BindingGrid();
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            frmControlWorkersSchedulecs frm = new frmControlWorkersSchedulecs("New", "");
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            var list = new WorkerScheduleBL().GetSchedules(txtFilter.Text, cboMes.Text);
            grdDataGroupUser.DataSource = list;
            if (grdDataGroupUser.Rows.Count > 0)
            {
                grdDataGroupUser.Rows[0].Cells["v_ScheduleId"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["v_ScheduleName"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["v_ScheduleDescription"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["i_IsDeleted"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["i_InsertUserId"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["d_InsertDate"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["i_UpdateUserId"].Column.Hidden = true;
                grdDataGroupUser.Rows[0].Cells["d_UpdateDate"].Column.Hidden = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdDataGroupUser.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar registro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialog == DialogResult.No) return;


               string _scheduleId = grdDataGroupUser.Selected.Rows[0].Cells["v_ScheduleId"].Value.ToString();
               bool exit = new WorkerScheduleBL().DeleteWorkerSchedule(_scheduleId);
                if (!exit)
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un detalle para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdDataGroupUser.Selected.Rows.Count > 0)
            {
                string _scheduleId = grdDataGroupUser.Selected.Rows[0].Cells["v_ScheduleId"].Value.ToString();
                frmControlWorkersSchedulecs frm = new frmControlWorkersSchedulecs("Edit", _scheduleId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un detalle para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
