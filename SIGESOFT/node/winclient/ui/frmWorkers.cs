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
    public partial class frmWorkers : Form
    {
        public string personId, personName;
        public frmWorkers()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            var data = new PacientBL().GetProfesionals(txtFilter.Text);
            grdWorkers.DataSource = data;
        }

        private void frmWorkers_Load(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void grdWorkers_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (grdWorkers.Selected.Rows.Count > 0)
            {
                personId = grdWorkers.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();
                personName = grdWorkers.Selected.Rows[0].Cells["v_FullName"].Value.ToString();

                this.Close();
            }
        }
    }
}
