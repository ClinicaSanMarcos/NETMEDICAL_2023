using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Rol
{
    public partial class frmAddRol : Form
    {
        NodeBL _nodeBL = new NodeBL();
        public string _modo, _name;
        public int? _roleId;
        public int? _nodeId = null;
        public frmAddRol(string modo, int? roleId, string name)
        {
            _name = name;
            _modo = modo;
            _roleId = roleId;
            InitializeComponent();
        }

        private void frmAddRol_Load(object sender, EventArgs e)
        {
            if (_modo == "Edit")
            {
                txtRolName.Text = _name;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_modo == "New")
            {
                //Buscon si existe
                if (txtRolName.Text == "" || txtRolName.Text == null)
                {
                    MessageBox.Show("Ingrese un nombre para el ROL", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_nodeId == null )
                {
                    _nodeId = Globals.ClientSession.i_CurrentExecutionNodeId;
                }

                var obj = _nodeBL.FindRoleNode(_nodeId.Value, txtRolName.Text.Trim().ToUpper());
                if (obj != null)
                {
                    MessageBox.Show("El nombre ingresado ya existe, por favor elija otro.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool ok = _nodeBL.AddRoleNode(_nodeId.Value, txtRolName.Text.Trim().ToUpper(), Globals.ClientSession.i_SystemUserId);
                if (ok)
                {
                    MessageBox.Show("Se guardó correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (txtRolName.Text.Trim().ToUpper() == _name)
                {
                    MessageBox.Show("Se actualizó correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    var obj = _nodeBL.FindRoleNode(Globals.ClientSession.i_CurrentExecutionNodeId, txtRolName.Text.Trim().ToUpper());
                    if (obj != null)
                    {
                        MessageBox.Show("El nombre ingresado ya existe, por favor elija otro.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool ok = _nodeBL.UpdateRoleNode(_roleId.Value,txtRolName.Text.Trim().ToUpper(), Globals.ClientSession.i_SystemUserId);
                    if (ok)
                    {
                        MessageBox.Show("Se actualizó correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

        }

    }
}
