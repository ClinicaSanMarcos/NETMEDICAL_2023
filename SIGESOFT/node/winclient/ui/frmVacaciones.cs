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
    public partial class frmVacaciones : Form
    {
        private string personId = null;
        private string _Type = "", _vacationId = "";
        public frmVacaciones(string type, string vacationId)
        {
            _Type = type;
            _vacationId = vacationId;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmWorkers frm = new frmWorkers();
            frm.ShowDialog();
            txtTrabajador.Text = frm.personName;
            personId = frm.personId;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (_Type == "New")
            {
                if (personId == null)
                {
                    MessageBox.Show("Elija un trabajador para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);


                    return;
                }

                bool ok = new VacationsBL().AddVacation(personId, dtDesde.Value, dtHasta.Value,
                    Globals.ClientSession.i_CurrentExecutionNodeId);

                if (!ok)
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                bool ok = new VacationsBL().UpdateVacation(dtDesde.Value, dtHasta.Value, _vacationId);

                if (!ok)
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            this.Close();
            
        }

        private void frmVacaciones_Load(object sender, EventArgs e)
        {
            if (_Type == "Edit")
            {
                var obj = new VacationsBL().GetDataVacationsById(_vacationId);
                txtTrabajador.Visible = false;
                btnBuscar.Visible = false;
                label1.Visible = false;
                dtDesde.Value = obj.d_StartVacation.Value;
                dtHasta.Value = obj.d_EndVacation.Value;
            }
        }
    }
}
