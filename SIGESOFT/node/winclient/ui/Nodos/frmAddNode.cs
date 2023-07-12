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
using Sigesoft.Node.WinClient.BE;

namespace Sigesoft.Node.WinClient.UI.Nodos
{
    public partial class frmAddNode : Form
    {
        private NodeBL _nodeBl = new NodeBL();
        private string _modo;
        private int? _nodeId;
        private OperationResult objOperationResult = new OperationResult();
        public frmAddNode(string modo, int? nodeId)
        {
            _modo = modo;
            _nodeId = nodeId;
            InitializeComponent();
        }

        private void frmAddNode_Load(object sender, EventArgs e)
        {
            Utils.LoadDropDownList(cboTipoNodo, "Value1", "Id", BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 105, null), DropDownListAction.Select);
            if (_modo == "Edit")
            {
                var objNode = _nodeBl.GetNodeByNodeId(ref objOperationResult, _nodeId.Value);
                txtNodoName.Text = objNode.v_Description;
                txtUbicacion.Text = objNode.v_GeografyLocationDescription;
                txtUbicacionCodigo.Text = objNode.v_GeografyLocationId;
                cboTipoNodo.SelectedValue = objNode.i_NodeTypeId.ToString();

                dtFechaInicio.Value = objNode.d_BeginDate.Value;
                dtFechaFin.Checked = objNode.d_EndDate == null ? false : true;
                if (objNode.d_EndDate != null)
                {
                    dtFechaFin.Value = objNode.d_EndDate.Value;
                }
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (uvNodos.Validate(true, false).IsValid)
            {
                if (cboTipoNodo.SelectedValue.ToString() == "-1")
                {
                    MessageBox.Show("Seleccione un tipo de nodo para continuar", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_modo == "Edit")
                {
                    var objNode = _nodeBl.GetNodeByNodeId(ref objOperationResult, _nodeId.Value);

                    objNode.v_Description = txtNodoName.Text;
                    objNode.v_GeografyLocationDescription = txtUbicacion.Text;
                    objNode.v_GeografyLocationId = txtUbicacionCodigo.Text;
                    objNode.i_NodeTypeId = int.Parse(cboTipoNodo.SelectedValue.ToString());
                    objNode.i_NodeId = _nodeId.Value;
                    objNode.d_BeginDate = dtFechaInicio.Value;
                    if (dtFechaFin.Checked)
                    {
                        objNode.d_EndDate = dtFechaFin.Value;
                    }
                    else
                    {
                        objNode.d_EndDate = null;
                    }

                    bool ok = _nodeBl.UpdateNodeByNodeId(objNode, Globals.ClientSession.i_SystemUserId);
                    if (ok)
                    {
                        MessageBox.Show("Se actualizó correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    nodeDto objNode = new nodeDto();

                    objNode.v_Description = txtNodoName.Text;
                    objNode.v_GeografyLocationDescription = txtUbicacion.Text;
                    objNode.v_GeografyLocationId = txtUbicacionCodigo.Text;
                    objNode.i_NodeTypeId = int.Parse(cboTipoNodo.SelectedValue.ToString());

                    objNode.d_BeginDate = dtFechaInicio.Value;
                    if (dtFechaFin.Checked)
                    {
                        objNode.d_EndDate = dtFechaFin.Value;
                    }

                    bool ok = _nodeBl.AddNode(objNode, Globals.ClientSession.i_SystemUserId);
                    if (ok)
                    {
                        MessageBox.Show("Se agregó correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
