using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmSystemUser : Form
    {
        private PacientList objpacientDto = new PacientList();
        PacientBL _objPacientBL = new PacientBL();
        OperationResult objOperationResult = new OperationResult();
        string Mode;
        public byte[] FingerPrintTemplate { get; set; }

        public byte[] FingerPrintImage { get; set; }

        public byte[] RubricImage { get; set; }

        public string RubricImageText { get; set; }

        public frmSystemUser()
        {
            InitializeComponent();
        }

        private void frmSystemUser_Load(object sender, EventArgs e)
        {
            
            Utils.LoadDropDownList(ddlMaritalStatusId, "Value1", "Id", BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 101, null), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlDocTypeId, "Value1", "Id", BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 106, null), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlSexTypeId, "Value1", "Id", BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 100, null), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlLevelOfId, "Value1", "Id", BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 108, null), DropDownListAction.Select);
            List<systemUser> systemUsers = ObtenerSystemUser();
            grdData.DataSource = systemUsers;
            BlockControls(false);
        }

        private void BlockControls(bool block)
        {
            txtName.Enabled = block;
            txtFirstLastName.Enabled = block;
            txtSecondLastName.Enabled = block;
            ddlDocTypeId.Enabled = block;
            txtDocNumber.Enabled = block;
            ddlSexTypeId.Enabled = block;
            txtBirthPlace.Enabled = block;
            dtpBirthdate.Enabled = block;
            ddlMaritalStatusId.Enabled = block;
            txtMail.Enabled = block;
            txtTelephoneNumber.Enabled = block;
            ddlLevelOfId.Enabled = block;
            btnWebCam.Enabled = block;
            txtAdressLocation.Enabled = block;
            btnCapturedFingerPrintAndRubric.Enabled = block;
            btnArchivo1.Enabled = block;
            btnClear.Enabled = block;
        }

        private List<systemUser> ObtenerSystemUser()
        {
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            var cadenasam =
                "select PP.v_PersonId, PP.v_FirstLastName + ' ' + PP.v_SecondLastName + ', ' + PP.v_FirstName as v_NombreCompleto, pp.v_TelephoneNumber, PP.v_Mail " +
                "from systemuser SU inner join person PP on SU.v_PersonId=PP.v_PersonId";
            SqlCommand comando = new SqlCommand(cadenasam, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            List<systemUser> objsysUsers = new List<systemUser>();
            while (lector.Read())
            {
                systemUser user = new systemUser();
                user.v_PersonId = lector.GetValue(0).ToString();
                user.v_NombreCompleto = lector.GetValue(1).ToString();
                user.v_TelephoneNumber = lector.GetValue(2).ToString();
                user.v_Mail = lector.GetValue(3).ToString();
                objsysUsers.Add(user);
            }
            lector.Close();
            conectasam.closesigesoft();
            return objsysUsers;
        }

        private void grdData_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            string PacientId = grdData.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();
            PacientList su = ObtenerPerson(PacientId);
            if (su != null)
            {
                txtName.Text = su.v_FirstName;
                txtFirstLastName.Text = su.v_FirstLastName;
                txtSecondLastName.Text = su.v_SecondLastName;
                ddlDocTypeId.SelectedValue = su.i_DocTypeId.ToString();
                txtDocNumber.Text = su.v_DocNumber;
                ddlSexTypeId.SelectedValue = su.i_SexTypeId.ToString();
                txtBirthPlace.Text = su.v_BirthPlace;
                dtpBirthdate.Value = (DateTime)su.d_Birthdate;
                ddlMaritalStatusId.SelectedValue = su.i_MaritalStatusId.ToString();
                txtMail.Text = su.v_Mail;
                txtTelephoneNumber.Text = su.v_TelephoneNumber;
                ddlLevelOfId.SelectedValue = su.i_LevelOfId.ToString();
                txtAdressLocation.Text = su.v_AdressLocation;
                FingerPrintTemplate = su.b_FingerPrintTemplate;
                FingerPrintImage = su.b_FingerPrintImage;
                RubricImage = su.b_RubricImage;
                RubricImageText = su.t_RubricImageText;
                pbPersonImage.Image = Common.Utils.BytesArrayToImage(su.b_Photo, pbPersonImage); 
            }
            
        }

        private PacientList ObtenerPerson(string PacientId)
        {
            
            
            objpacientDto = _objPacientBL.GetPacientUser(ref objOperationResult, PacientId, null);
            return objpacientDto;
        }

        private void btnCapturedFingerPrintAndRubric_Click(object sender, EventArgs e)
        {
            var frm = new frmCapturedFingerPrint();
            frm.Mode = Mode;

            if (Mode == "Edit")
            {
                frm.FingerPrintTemplate = FingerPrintTemplate;
                frm.FingerPrintImage = FingerPrintImage;
                frm.RubricImage = RubricImage;
                frm.RubricImageText = RubricImageText;
            }

            frm.ShowDialog();

            FingerPrintTemplate = frm.FingerPrintTemplate;
            FingerPrintImage = frm.FingerPrintImage;
            RubricImage = frm.RubricImage;
            RubricImageText = frm.RubricImageText;
        }

        private void btnWebCam_Click(object sender, EventArgs e)
        {
            try
            {
                frmCamera frm = new frmCamera();
                frm.ShowDialog();

                if (System.Windows.Forms.DialogResult.Cancel != frm.DialogResult)
                {
                    pbPersonImage.Image = frm._Image;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("ddd");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Mode = "Edit";
            objpacientDto.b_FingerPrintTemplate = FingerPrintTemplate;
            objpacientDto.b_FingerPrintImage = FingerPrintImage;
            objpacientDto.b_RubricImage = RubricImage;
            objpacientDto.t_RubricImageText = RubricImageText;
            if (pbPersonImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();

                Bitmap bm = new Bitmap(pbPersonImage.Image);
                bm.Save(ms, ImageFormat.Jpeg);
                objpacientDto.b_PersonImage = Common.Utils.ResizeUploadedImage(ms);
                pbPersonImage.Image.Dispose();

            }
            else
            {
                objpacientDto.b_PersonImage = null;
            }

            UpdateSystemUser(objpacientDto);
            BlockControls(false);
        }

        private void UpdateSystemUser(PacientList objpacientDto)
        {
            personDto objpersonDto = new personDto();

            objpersonDto = _objPacientBL.GetPerson(ref objOperationResult, objpacientDto.v_PersonId);
            objpersonDto.v_PersonId = objpacientDto.v_PersonId;
            objpersonDto.v_FirstName = txtName.Text.Trim();
            objpersonDto.v_FirstLastName = txtFirstLastName.Text.Trim();
            objpersonDto.v_SecondLastName = txtSecondLastName.Text.Trim();
            objpersonDto.i_DocTypeId = Convert.ToInt32(ddlDocTypeId.SelectedValue);
            objpersonDto.i_SexTypeId = Convert.ToInt32(ddlSexTypeId.SelectedValue);
            objpersonDto.i_MaritalStatusId = Convert.ToInt32(ddlMaritalStatusId.SelectedValue);
            objpersonDto.i_LevelOfId = Convert.ToInt32(ddlLevelOfId.SelectedValue);
            objpersonDto.v_DocNumber = txtDocNumber.Text.Trim();
            objpersonDto.d_Birthdate = dtpBirthdate.Value;
            objpersonDto.v_BirthPlace = txtBirthPlace.Text.Trim();
            objpersonDto.v_TelephoneNumber = txtTelephoneNumber.Text.Trim();
            objpersonDto.v_AdressLocation = txtAdressLocation.Text.Trim();
            objpersonDto.v_Mail = txtMail.Text.Trim();
            objpersonDto.b_FingerPrintTemplate = FingerPrintTemplate;
            objpersonDto.b_FingerPrintImage = FingerPrintImage;
            objpersonDto.b_RubricImage = RubricImage;
            objpersonDto.t_RubricImageText = RubricImageText;
            if (pbPersonImage.Image != null)
            {
                MemoryStream ms = new MemoryStream();

                Bitmap bm = new Bitmap(pbPersonImage.Image);
                bm.Save(ms, ImageFormat.Jpeg);
                objpersonDto.b_PersonImage = Common.Utils.ResizeUploadedImage(ms);
                pbPersonImage.Image.Dispose();

            }
            else
            {
                objpersonDto.b_PersonImage = null;
            }

            // Save the data
            string Result = _objPacientBL.UpdatePacient(ref objOperationResult, objpersonDto, Globals.ClientSession.GetAsList(), txtDocNumber.Text, txtDocNumber.Text);

            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BlockControls(true);
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BlockControls(true);
            CleanControls();
        }

        private void CleanControls()
        {
            txtName.Text = "";
            txtFirstLastName.Text = "";
            txtSecondLastName.Text = "";
            ddlDocTypeId.Text = "";
            txtDocNumber.Text = "";
            ddlSexTypeId.Text = "";
            txtBirthPlace.Text = "";
            dtpBirthdate.Text = "";
            ddlMaritalStatusId.Text = "";
            txtMail.Text = "";
            txtTelephoneNumber.Text = "";
            ddlLevelOfId.Text = "";
            btnWebCam.Text = "";
            txtAdressLocation.Text = "";
            btnCapturedFingerPrintAndRubric.Text = "";
            btnArchivo1.Text = "";
            btnClear.Text = "";
        }
    }
}
