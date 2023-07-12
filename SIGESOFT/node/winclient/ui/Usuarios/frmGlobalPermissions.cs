using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Usuarios
{
    public partial class frmGlobalPermissions : Form
    {
        private OperationResult objOperationResult = new OperationResult();
        private AplicationHierarchyBL _objApplicationHierarchyBL = new AplicationHierarchyBL();
        private List<AutorizationList> ListSavePermissions = new List<AutorizationList>();
        private SecurityBL _objSecurityBL = new SecurityBL();
        private int _userId;
        public frmGlobalPermissions(int? userId)
        {
            _userId = userId.Value;
            InitializeComponent();
        }

        private void frmGlobalPermissions_Load(object sender, EventArgs e)
        {
            BindingTreeView();
        }

        private void BindingTreeView()
        {
            ListSavePermissions = _objSecurityBL.GetSystemUserGlobalProfiles(ref objOperationResult, _userId);

            var listApplicationHierarchy = _objApplicationHierarchyBL.GetApplicationHierarchyByScopeId(ref objOperationResult, (int)Scope.Global);
            var parents = listApplicationHierarchy.FindAll(p => p.i_ParentId == -1);
            
            foreach (var parent in parents)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = parent.v_Description;
                treeNode.Tag = parent.i_ApplicationHierarchyId;
                var find = ListSavePermissions.Find(x => x.I_ApplicationHierarchyId == parent.i_ApplicationHierarchyId);
                if (find != null)
                {
                    treeNode.Checked = true;
                }
                LoadSubMenu(ref treeNode, parent.i_ApplicationHierarchyId, listApplicationHierarchy, ListSavePermissions);


                tvGlobalPermissions.Nodes.Add(treeNode);

            }
        }

        private void LoadSubMenu(ref TreeNode parentNode, int parentId, List<applicationhierarchyDto> applicationHierarchys, List<AutorizationList> listAuthorizations)
        {
            var childs = applicationHierarchys.FindAll(p => p.i_ParentId == parentId);
            foreach (var item in childs)
            {
                TreeNode child = new TreeNode();
                child.Text = item.v_Description;
                child.Tag = item.i_ApplicationHierarchyId.ToString();
                var find = listAuthorizations.Find(x => x.I_ApplicationHierarchyId == item.i_ApplicationHierarchyId);
                if (find != null)
                {
                    child.Checked = true;
                }
                parentNode.Nodes.Add(child);
                // Llamada recursiva
                LoadSubMenu(ref child, item.i_ApplicationHierarchyId, applicationHierarchys, listAuthorizations);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateListPermissions(TreeNode node, int applicationHierarchyId, bool check)
        {
            if (check)
            {
                var find = ListSavePermissions.Find(x => x.I_ApplicationHierarchyId == applicationHierarchyId);
                if (find != null)
                {
                    ListSavePermissions.Find(x => x.I_ApplicationHierarchyId == applicationHierarchyId).i_IsDeleted = (int)SiNo.NO;
                }
                else
                {
                    AutorizationList auth = new AutorizationList();
                    auth.I_ApplicationHierarchyId = applicationHierarchyId;

                    if (node.Parent != null)
                        auth.I_ParentId = int.Parse(node.Parent.Tag.ToString());
                    else
                        auth.I_ParentId = -1;

                    auth.i_IsDeleted = (int)SiNo.NO;
                    auth.i_IsNew = (int)SiNo.SI;

                    ListSavePermissions.Add(auth);
                }
            }
            else
            {
                var find = ListSavePermissions.Find(x => x.I_ApplicationHierarchyId == applicationHierarchyId);
                if (find != null)
                {
                    if (find.i_IsNew == (int)SiNo.NO)
                    {
                        ListSavePermissions.Find(x => x.I_ApplicationHierarchyId == applicationHierarchyId).i_IsDeleted = (int)SiNo.SI;
                    }
                    else
                    {
                        ListSavePermissions = ListSavePermissions.FindAll(x => x.I_ApplicationHierarchyId != applicationHierarchyId).ToList();
                    }
                }
            }
        }

        private void tvGlobalPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            

            if (e.Action != TreeViewAction.Unknown)
            {
                int applicationHierarchyId = int.Parse(e.Node.Tag.ToString());

                UpdateListPermissions(e.Node, applicationHierarchyId, e.Node.Checked);

                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }

                if (e.Node.Parent != null && e.Node.Checked)
                {
                    CheckAllParents(e.Node.Parent, e.Node.Checked);
                }
            }

            
        }

        private void CheckAllParents(TreeNode treeNode, bool nodeChecked)
        {
            treeNode.Checked = nodeChecked;

            int applicationHierarchyId = int.Parse(treeNode.Tag.ToString());
            
            UpdateListPermissions(treeNode, applicationHierarchyId, nodeChecked);

            if (treeNode.Parent != null)
            {
                CheckAllParents(treeNode.Parent, nodeChecked);
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;


                int applicationHierarchyId = int.Parse(node.Tag.ToString());

                UpdateListPermissions(node, applicationHierarchyId, nodeChecked);

                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ListSavePermissions.Count > 0)
            {
                List<systemusergobalprofileDto> ListSystemUserGlobalProfileUpdate = new List<systemusergobalprofileDto>();
                List<systemusergobalprofileDto> ListSystemUserGlobalProfileDelete = new List<systemusergobalprofileDto>();
                foreach (var item in ListSavePermissions)
                {
                    systemusergobalprofileDto dto = new systemusergobalprofileDto();
                    dto.i_ApplicationHierarchyId = item.I_ApplicationHierarchyId;
                    dto.i_SystemUserId = _userId;
                    if (item.i_IsDeleted == 1)
                    {
                        
                        ListSystemUserGlobalProfileDelete.Add(dto);
                    }
                    else
                    {
                        ListSystemUserGlobalProfileUpdate.Add(dto);
                    }
                }

                _objSecurityBL.UpdateSystemUserGlobalProfiles(ref objOperationResult, ListSystemUserGlobalProfileUpdate, ListSystemUserGlobalProfileDelete, Globals.ClientSession.GetAsList());
                if (objOperationResult.Success == 0)
                {
                    MessageBox.Show(objOperationResult.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Los permisos se guardaron correctamente.", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No hay permisos por guardar", "INFORMACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
