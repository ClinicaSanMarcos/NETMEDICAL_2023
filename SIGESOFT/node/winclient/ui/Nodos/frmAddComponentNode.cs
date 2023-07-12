using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;

namespace Sigesoft.Node.WinClient.UI.Nodos
{
    public partial class frmAddComponentNode : Form
    {
        NodeBL _nodeBl = new NodeBL();
        private List<rolenodecomponentprofileDto> listDto = new List<rolenodecomponentprofileDto>();
        public int _nodeId, _roleId;
        public frmAddComponentNode(int nodeId, int roleId)
        {
            _nodeId = nodeId;
            _roleId = roleId;
            InitializeComponent();
        }

        private void frmAddComponentNode_Load(object sender, EventArgs e)
        {
            BindingTreeView();
        }

        private void BindingTreeView()
        {
            var list = _nodeBl.GetComponentForRolNode();
            listDto = _nodeBl.GetComponentForRolNodeByNodeRole(_nodeId, _roleId);
            foreach (var category in list)
            {
                TreeNode node = new TreeNode();
                node.Text = category.v_CategoryName;
                node.Tag = category.i_CategoryId.ToString();
                foreach (var component in category.List)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = component.v_ComponentName;
                    childNode.Tag = component.v_ComponentId;
                    var find = listDto.FindAll(x => x.v_ComponentId == component.v_ComponentId).ToList();
                    if (find.Count > 0)
                    {
                        childNode.Checked = true;
                        node.Checked = true;
                        //node.IsSelected = false;
                        //childNode. = false;
                    }
                    node.Nodes.Add(childNode);
                }

                tvComponents.Nodes.Add(node);
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var listDelete = listDto.FindAll(x => x.v_RoleNodeComponentId != null && x.i_IsDeleted == 1).ToList();
            var listAdd = listDto.FindAll(x => x.v_RoleNodeComponentId == null).ToList();
            foreach (var itemAdd in listAdd)
            {
                new NodeBL().AddRoleNodeComponentProfile(itemAdd, Globals.ClientSession.i_SystemUserId, Globals.ClientSession.i_CurrentExecutionNodeId);
            }

            foreach (var itemDelete in listDelete)
            {
                new NodeBL().DeleteRoleNodeComponentProfile(itemDelete.v_RoleNodeComponentId);
            }

            MessageBox.Show("Los cambios se guardaron correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.Close();
        }

        private void tvComponents_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                string componentId = e.Node.Tag.ToString();
                var find = listDto.FindAll(x => x.v_ComponentId == componentId).FirstOrDefault();
                if (find == null)
                {
                    frmUpdateComponentRol frm = new frmUpdateComponentRol("New", false, false, false, false, e.Node.Text, null);
                    frm.ShowDialog();
                    rolenodecomponentprofileDto rolenode = new rolenodecomponentprofileDto();
                    rolenode.i_Read = frm._lec ? 1 : 0;
                    rolenode.i_Write = frm._escr ? 1 : 0;
                    rolenode.i_Dx = frm._diag ? 1 : 0;
                    rolenode.i_Approved = frm._apro ? 1 : 0;
                    rolenode.v_ComponentId = e.Node.Tag.ToString();
                    rolenode.i_NodeId = _nodeId;
                    rolenode.i_RoleId = _roleId;   
                    listDto.Add(rolenode);
                }
                else
                {
                    if (e.Node.Checked)
                    {
                        listDto.Find(x => x.v_ComponentId == componentId).i_IsDeleted = 0;
                    }
                    else
                    {
                        if (find.v_RoleNodeComponentId == null)
                        {
                            listDto = listDto.FindAll(x => x.v_ComponentId != componentId).ToList();
                        }
                        else
                        {
                            listDto.Find(x => x.v_ComponentId == componentId).i_IsDeleted = 1;
                        }
                    }
                    

                }

            }

        }

        //private bool ReturnBoolean(int? sino)
        //{
        //    if (sino == 0 || sino == null)
        //    {
        //        return false;
        //    }
        //    else if(sino == 1)
        //    {
        //        return true;
        //    }
        //}

        private void tvComponents_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Cancel = true;
            }
        }
    }
}
