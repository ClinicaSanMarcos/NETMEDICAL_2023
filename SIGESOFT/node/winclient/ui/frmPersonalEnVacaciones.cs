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
    public partial class frmPersonalEnVacaciones : Form
    {
        public frmPersonalEnVacaciones()
        {
            InitializeComponent();
        }

        private void frmPersonalEnVacaciones_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            grdData.DataSource = new VacationsBL().GetDataVacations();
        }

        private void btnNuevasVacaciones_Click(object sender, EventArgs e)
        {
            frmVacaciones frm = new frmVacaciones("New", "");
            frm.ShowDialog();
            BindingGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                string vacationId = grdData.Selected.Rows[0].Cells["VacationId"].Value.ToString();
                frmVacaciones frm = new frmVacaciones("Edit", vacationId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            BindingGrid();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de terminar y procesar las vacaciones ?.", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string vacationId = grdData.Selected.Rows[0].Cells["VacationId"].Value.ToString();
                    bool ok = new VacationsBL().ProcessedVacation(vacationId);
                    if (!ok)
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            BindingGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar registro ?.", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string vacationId = grdData.Selected.Rows[0].Cells["VacationId"].Value.ToString();
                    bool ok = new VacationsBL().DeleteVacation(vacationId);
                    if (!ok)
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }                
            }
            else
            {
                MessageBox.Show("Seleccione un registro para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            BindingGrid();
        }

        private void btnGenerarMarcaciones_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de autogenerar las marcaciones ?.", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string vacationId = grdData.Selected.Rows[0].Cells["VacationId"].Value.ToString();
                    bool ok = new VacationsBL().AutogenerarMarcaciones(vacationId);
                    if (!ok)
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Las marcaciones se generaron automaticamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            BindingGrid();
        }
    }
}
