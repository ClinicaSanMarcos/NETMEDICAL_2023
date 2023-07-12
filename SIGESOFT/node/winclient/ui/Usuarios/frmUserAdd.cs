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
using Sigesoft.Node.WinClient.BE.Custom;

namespace Sigesoft.Node.WinClient.UI.Usuarios
{
    public partial class frmUserAdd : Form
    {
        public string _modo;
        public string _personId;
        private ProtocolBL _protocolBL = new ProtocolBL();
        private PacientBL _objPacientBL = new PacientBL();
        private SecurityBL _objSecurityBL = new SecurityBL();
        private personDto objPerson = new personDto();
        private List<KeyValueDTO> _docType = new List<KeyValueDTO>();
        private systemuserDto _objSystemUserTemp = new systemuserDto();
        private OperationResult objOperationResult = new OperationResult();
        private int? _systemUserId;
        public frmUserAdd(string modo, int? systemUserId, string personId)
        {
            _personId = personId;
            _modo = modo;
            _systemUserId = systemUserId;
            InitializeComponent();
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            _docType = BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 106, null);

            //Llenado de combos
            Utils.LoadDropDownList(cboEstadoCivil, "Value1", "Id", BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 101, null), DropDownListAction.Select);
            Utils.LoadDropDownList(cboTipoDocumento, "Value1", "Id", _docType, DropDownListAction.Select);
            Utils.LoadDropDownList(cboGenero, "Value1", "Id", BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 100, null), DropDownListAction.Select);
            Utils.LoadDropDownList(cboNivelEstudios, "Value1", "Id", BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 108, null), DropDownListAction.Select);
            Utils.LoadDropDownList(cboProfesion, "Value1", "Id", BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 101, null), DropDownListAction.Select);
            Utils.LoadDropDownList(cboRolVenta, "Value1", "Id", BLL.Utils.GetRolSAMBHS(), DropDownListAction.Select);
            if (_modo == "Edit")
            {
                OperationResult objCommonOperationResultedit = new OperationResult();
                objPerson = _objPacientBL.GetPerson(ref objCommonOperationResultedit, _personId);

                _objSystemUserTemp = _objSecurityBL.GetSystemUser(ref objOperationResult, _systemUserId.Value);

                this.Text = this.Text + " (" + objPerson.v_FirstName + " " + objPerson.v_FirstLastName + " " + objPerson.v_SecondLastName + ")";
                // Informacion de la persona
                txtNombres.Text = objPerson.v_FirstName;
                txtApepat.Text = objPerson.v_FirstLastName;
                txtApemat.Text = objPerson.v_SecondLastName;
                txtNumeroDocumento.Text = objPerson.v_DocNumber;
                dtFechaNacimiento.Value = objPerson.d_Birthdate == null ? DateTime.Now : objPerson.d_Birthdate.Value;
                txtLugarNacimiento.Text = objPerson.v_BirthPlace;
                cboEstadoCivil.SelectedValue = objPerson.i_MaritalStatusId.ToString();
                cboNivelEstudios.SelectedValue = objPerson.i_LevelOfId.ToString();
                cboTipoDocumento.SelectedValue = objPerson.i_DocTypeId.ToString();
                txtNumeroDocumento.Text = objPerson.v_DocNumber;
                cboGenero.SelectedValue = objPerson.i_SexTypeId.ToString();
                txtTelefono.Text = objPerson.v_TelephoneNumber;
                txtDireccion.Text = objPerson.v_AdressLocation;
                txtEmail.Text = objPerson.v_Mail;
               
                // Informacion de Profesional
                OperationResult objCommonOperationResult1 = new OperationResult();
                var objProfessional = _objPacientBL.GetProfessional(ref objCommonOperationResult1, _personId);
                
                if (objProfessional != null)
                {
                    cboProfesion.SelectedValue = objProfessional.i_ProfessionId.ToString();
                    txtColegiatura.Text = objProfessional.v_ProfessionalCode;
                    txtInfoAdicional.Text = objProfessional.v_ProfessionalInformation;
                    dtContratoDesde.Value = objProfessional.d_ContractFrom == null ? DateTime.Now : objProfessional.d_ContractFrom.Value;
                    dtContratoHasta.Value = objProfessional.d_ContractUntil == null ? DateTime.Now : objProfessional.d_ContractUntil.Value;
                    txtSalario.Text = objProfessional.r_MonthlyPayment == null ? "0" : objProfessional.r_MonthlyPayment.ToString();
                }


                // Informacion del usuario
                OperationResult objOperationResultUser = new OperationResult();
                _objSystemUserTemp = _objSecurityBL.GetSystemUser(ref objOperationResultUser, _systemUserId.Value);

                txtUserName.Text = _objSystemUserTemp.v_UserName;
                txtContrasenia.Text = _objSystemUserTemp.v_Password;
                txtRepetirContrasenia.Text = _objSystemUserTemp.v_Password;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (uvUser.Validate(true, false).IsValid)
            {
                if (!Sigesoft.Common.Utils.email_bien_escrito(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Por favor ingrese un Email con formato correcto.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int caracteres = txtNumeroDocumento.TextLength;
                if (int.Parse(cboTipoDocumento.SelectedValue.ToString()) == (int)Common.Document.DNI)
                {
                    if (caracteres != 8)
                    {
                        MessageBox.Show("La cantida de caracteres de Número Documento es invalido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (int.Parse(cboTipoDocumento.SelectedValue.ToString()) == (int)Common.Document.PASAPORTE)
                {
                    if (caracteres != 9)
                    {
                        MessageBox.Show("La cantida de caracteres de Número Documento es invalido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (int.Parse(cboTipoDocumento.SelectedValue.ToString()) == (int)Common.Document.LICENCIACONDUCIR)
                {
                    if (caracteres != 9)
                    {
                        MessageBox.Show("La cantida de caracteres de Número Documento es invalido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (int.Parse(cboTipoDocumento.SelectedValue.ToString()) == (int)Common.Document.CARNETEXTRANJ)
                {
                    if (caracteres < 9)
                    {
                        MessageBox.Show("La cantida de caracteres de Número Documento es invalido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (txtContrasenia.Text.Trim() != txtRepetirContrasenia.Text.Trim())
                {
                    MessageBox.Show("Las contraseñas no coinciden, por favor verifique.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtSalario.Text.Trim()== "")
                {
                    MessageBox.Show("Ingrese un salario por favor.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (_modo == "New")
                {
                    var objPerson = new personDto();

                    objPerson.v_FirstName = txtNombres.Text.Trim();
                    objPerson.v_FirstLastName = txtApepat.Text.Trim();
                    objPerson.v_SecondLastName = txtApemat.Text.Trim();
                    objPerson.i_DocTypeId = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                    objPerson.i_SexTypeId = Convert.ToInt32(cboGenero.SelectedValue);
                    objPerson.i_MaritalStatusId = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                    objPerson.i_LevelOfId = Convert.ToInt32(cboNivelEstudios.SelectedValue);
                    objPerson.v_DocNumber = txtNumeroDocumento.Text.Trim();
                    objPerson.d_Birthdate = dtFechaNacimiento.Value;
                    objPerson.v_BirthPlace = txtLugarNacimiento.Text.Trim();
                    objPerson.v_TelephoneNumber = txtTelefono.Text.Trim();
                    objPerson.v_AdressLocation = txtDireccion.Text.Trim();
                    objPerson.v_Mail = txtEmail.Text.Trim();
                    
                    // Datos de Profesional    
                    var _professionalDto = new professionalDto();
                    _professionalDto.d_ContractFrom = dtContratoDesde.Value;
                    _professionalDto.d_ContractUntil = dtContratoHasta.Value;
                    _professionalDto.r_MonthlyPayment = decimal.Parse(txtSalario.Text);
                    if (cboProfesion.SelectedValue.ToString() != "-1" ||
                        !string.IsNullOrEmpty(txtColegiatura.Text) ||
                        !string.IsNullOrEmpty(txtInfoAdicional.Text))
                    {

                        _professionalDto.i_ProfessionId = Convert.ToInt32(cboProfesion.SelectedValue.ToString());
                        if (!string.IsNullOrEmpty(txtColegiatura.Text))
                            _professionalDto.v_ProfessionalCode = txtColegiatura.Text.Trim();
                        if (!string.IsNullOrEmpty(txtInfoAdicional.Text))
                            _professionalDto.v_ProfessionalInformation = txtInfoAdicional.Text.Trim();
                    }

                    var _objPersonBL = new PacientBL();
                    // Datos de usuario
                    systemuserDto pobjSystemUser = new systemuserDto();
                    pobjSystemUser.v_UserName = txtUserName.Text.Trim();
                    pobjSystemUser.v_Password = SecurityBL.Encrypt(txtRepetirContrasenia.Text.Trim());

                    var _systemuserSAM = new SystemUserSAMBHS();
                    _systemuserSAM.i_UsuarioContable = chkUsercontable.Checked ? 1 : 0;
                    _systemuserSAM.i_RoleId = int.Parse(cboRolVenta.SelectedValue.ToString());
                    _systemuserSAM.v_Password = pobjSystemUser.v_Password;
                    _systemuserSAM.v_UserName = pobjSystemUser.v_UserName;

                   // _objPersonBL.AddPerson(ref objOperationResult, _personDto, _systemuserDto, Globals.ClientSession.GetAsList());
                    _objPersonBL.AddPersonSAMBHS(ref objOperationResult, objPerson, _systemuserSAM, Globals.ClientSession.GetAsList());
                    // Graba persona                        
                    _personId = _protocolBL.AddSystemUserExternal(ref objOperationResult, objPerson, _professionalDto, pobjSystemUser, null, Globals.ClientSession.GetAsList());
                    _systemUserId = _protocolBL.GetSystemUserByPersonId(_personId);
                    if (_personId == "-1")
                    {
                        if (objOperationResult.ErrorMessage != null)
                        {
                            MessageBox.Show(objOperationResult.ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario se guardó correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    bool isChangeUserName = false;
                    bool isChangeDocNumber = false;

                    #region Validate SystemUSer
                    // Almacenar temporalmente el nombre de usuario actual                 
                    if (txtUserName.Text != _objSystemUserTemp.v_UserName)
                    {
                        isChangeUserName = true;

                    }
                    #endregion

                    #region Validate Document Number
                    // Almacenar temporalmente el número de documento del usuario actual                
                    if (txtNumeroDocumento.Text != objPerson.v_DocNumber)
                    {
                        isChangeDocNumber = true;
                    }
                    #endregion

                    // Almacenar temporalmente el password del usuario actual
                    var passTemp = _objSystemUserTemp.v_Password;

                    // Si el password actual es diferente al ingresado en la cajita de texto, quiere decir que se ha cambiado el password por lo tanto
                    // se bede encriptar el nuevo password
                    if (txtRepetirContrasenia.Text != passTemp)
                    {
                        _objSystemUserTemp.v_Password = SecurityBL.Encrypt(txtRepetirContrasenia.Text.Trim());

                    }
                    else
                    {
                        _objSystemUserTemp.v_Password = txtRepetirContrasenia.Text.Trim();
                    }

                    #region Datos de persona

                    // Datos de persona                
                    objPerson.v_PersonId = _personId;
                    objPerson.v_FirstName = txtNombres.Text.Trim();
                    objPerson.v_FirstLastName = txtApepat.Text.Trim();
                    objPerson.v_SecondLastName = txtApemat.Text.Trim();
                    objPerson.i_DocTypeId = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                    objPerson.i_SexTypeId = Convert.ToInt32(cboGenero.SelectedValue);
                    objPerson.i_MaritalStatusId = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                    objPerson.i_LevelOfId = Convert.ToInt32(cboNivelEstudios.SelectedValue);
                    objPerson.v_DocNumber = txtNumeroDocumento.Text.Trim();
                    objPerson.d_Birthdate = dtFechaNacimiento.Value;
                    objPerson.v_BirthPlace = txtLugarNacimiento.Text.Trim();
                    objPerson.v_TelephoneNumber = txtTelefono.Text.Trim();
                    objPerson.v_AdressLocation = txtDireccion.Text.Trim();
                    objPerson.v_Mail = txtEmail.Text.Trim();

                    #endregion
                    #region Datos de Profesional

                    // Datos de Profesional  
                    var _professionalDto = new professionalDto();
                    _professionalDto.d_ContractFrom = dtContratoDesde.Value;
                    _professionalDto.d_ContractUntil = dtContratoHasta.Value;
                    _professionalDto.r_MonthlyPayment = decimal.Parse(txtSalario.Text);
                    if (cboProfesion.SelectedValue.ToString() != "-1" ||
                        !string.IsNullOrEmpty(txtColegiatura.Text) ||
                        !string.IsNullOrEmpty(txtInfoAdicional.Text))
                    {
                        
                        _professionalDto.i_ProfessionId = Convert.ToInt32(cboProfesion.SelectedValue.ToString());
                        if (!string.IsNullOrEmpty(txtColegiatura.Text))
                            _professionalDto.v_ProfessionalCode = txtColegiatura.Text.Trim();
                        if (!string.IsNullOrEmpty(txtInfoAdicional.Text))
                            _professionalDto.v_ProfessionalInformation = txtInfoAdicional.Text.Trim();
                    }
                    #endregion

                    #region Datos de Usuario

                    // Datos de Usuario
                    _objSystemUserTemp.i_SystemUserId = _objSystemUserTemp.i_SystemUserId;
                    _objSystemUserTemp.v_PersonId = _personId;
                    _objSystemUserTemp.v_UserName = txtUserName.Text;
                    _objSystemUserTemp.d_InsertDate = _objSystemUserTemp.d_InsertDate;
                    _objSystemUserTemp.i_InsertUserId = _objSystemUserTemp.i_SystemUserId;
                    _objSystemUserTemp.i_IsDeleted = _objSystemUserTemp.i_IsDeleted;

                    #endregion
                    // Actualiza persona       
                    SystemUserSAMBHS _systemuserSAM = new SystemUserSAMBHS();
                    _systemuserSAM.i_RoleId = int.Parse(cboRolVenta.SelectedValue.ToString());
                    _systemuserSAM.v_Password = _objSystemUserTemp.v_Password;
                    _systemuserSAM.v_UserName = _objSystemUserTemp.v_UserName;
                    _systemuserSAM.i_UsuarioContable = chkUsercontable.Checked ? 1 : 0;
                    new PacientBL().UpdatePersonSAMBHS(ref objOperationResult, isChangeDocNumber, objPerson, isChangeUserName, _systemuserSAM, Globals.ClientSession.GetAsList());

                    _protocolBL.UpdateSystemUserExternal(ref objOperationResult, isChangeDocNumber, objPerson, _professionalDto, isChangeUserName, _objSystemUserTemp, null, null, null, null, Globals.ClientSession.GetAsList());
                    
                    if (objOperationResult.ErrorMessage != null)
                    {
                        //MessageBox.Show("Por favor ingrese un nombre apropiado para Nombres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;
                        MessageBox.Show(objOperationResult.ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (objOperationResult.Success != 1)
                        {
                            MessageBox.Show("Error en operación:" + System.Environment.NewLine + objOperationResult.ExceptionMessage);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("El usuario se actualizó correctamente", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void txtRepetirContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtRepetirContrasenia.Text != txtContrasenia.Text)
            {
                txtRepetirContrasenia.BackColor = Color.Pink;
            }
            else
            {
                txtRepetirContrasenia.BackColor = Color.White;
            }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            if (_systemUserId == null)
            {
                MessageBox.Show("Debe grabar el usuario para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmUserRol frm = new frmUserRol(_systemUserId.Value);
            frm.ShowDialog();
        }

        private void btnPermisosGlobales_Click(object sender, EventArgs e)
        {
            if (_systemUserId == null)
            {
                MessageBox.Show("Debe grabar el usuario para continuar.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmGlobalPermissions frm = new frmGlobalPermissions(_systemUserId);
            frm.ShowDialog();
        }

        
    }
}
