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
    public partial class frmUpdateComponentRol : Form
    {
        public bool _lec, _escr, _diag, _apro;
        private string _mode, _name, _rolenodeComponentId;
        public frmUpdateComponentRol(string mode, bool lec, bool escr, bool diag, bool apro, string name, string rolenodeComponentId)
        {
            _rolenodeComponentId = rolenodeComponentId;
            _mode = mode;
            _lec = lec;
            _escr = escr;
            _diag = diag;
            _apro = apro;
            _name = name;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateComponentRol_Load(object sender, EventArgs e)
        {
            txtExamen.Text = _name;
            if (_mode == "Edit")
            {
                chkLectura.Checked = _lec;
                chkEscritura.Checked = _escr;
                chkDiagnosticable.Checked = _diag;
                chkAprobable.Checked = _apro;
            }
            else
            {
                chkAll.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_mode == "Edit")
            {
                new NodeBL().UpdateRoleNodeComponent(chkLectura.Checked, chkEscritura.Checked, chkDiagnosticable.Checked, chkAprobable.Checked, _rolenodeComponentId);
            }
            else
            {
                _lec = chkLectura.Checked;
                _escr = chkEscritura.Checked;
                _diag = chkDiagnosticable.Checked;
                _apro = chkAprobable.Checked;
            }
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkAprobable.Checked = true;
                chkDiagnosticable.Checked = true;
                chkEscritura.Checked = true;
                chkLectura.Checked = true;
                btnGuardar_Click(sender, e);
            }
        }
    }
}
