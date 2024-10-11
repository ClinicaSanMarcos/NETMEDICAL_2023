using Infragistics.Win.UltraWinGrid;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.PAGOS_MEDICOS
{
    public partial class frmConfiguracionPagos : Form
    {
        ServiceBL objServiceBL = new ServiceBL();

        private string MedicalExamId { get; set; }
        private string MedicalExamName { get; set; }
        private string CategoryName { get; set; }

        List<string> _ListaComponentes = null;
        List<MedicoConfExamenList> ExamenesConfigurados = new List<MedicoConfExamenList>();
        HospitalizacionBL oHospitalizacionBL = new HospitalizacionBL();
        configuracionpagoDto _objEdit = new configuracionpagoDto();
        string _IdConfPago;
        string _mode;

        string _idPagoExam;
        public frmConfiguracionPagos(List<string> ListaComponentes, string mode, string IdConfPago)
        {
            _ListaComponentes = ListaComponentes;
            _mode = mode;
            _IdConfPago = IdConfPago;
            InitializeComponent();
        }

        private void rbMedSolicitante_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmConfiguracionPagos_Load(object sender, EventArgs e)
        {
            OperationResult objOperationResult1 = new OperationResult();

            Utils.LoadDropDownList(ddlUsuario, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult1, ""), DropDownListAction.Select);

            var ListServiceComponent = objServiceBL.GetAllComponentsNew(ref objOperationResult1, null, "");
            gdDataExamsNew.DataSource = ListServiceComponent;

            rbXTurno_CheckedChanged(sender, e);

            if (_mode == "Edit")
            {
                _objEdit = oHospitalizacionBL.GetConfPago(ref objOperationResult1, _IdConfPago);
                CargarExamenes();

                ddlUsuario.SelectedValue = _objEdit.i_SystemUserId.ToString();

                if (_objEdit.i_TipoPago == 1)
                {
                    rbXTurno.Checked = true;
                    txtMontoTurno.Text = _objEdit.d_MontoxTurno.ToString(); 
                }
                else if (_objEdit.i_TipoPago == 2)
                {
                    rbXHora.Checked = true;
                    txtMontoHora.Text = _objEdit.d_MonoxHora.ToString();

                    rbHoras.Checked = _objEdit.i_TipoDescuentoHoraMin == 1 ? true : false;
                    rbMinutos.Checked = _objEdit.i_TipoDescuentoHoraMin == 2 ? true : false;

                    txtTiempoDesc.Text = _objEdit.i_DesucuentodeHorario.ToString(); 

                }
                else if (_objEdit.i_TipoPago == 3)
                {
                    rbXExamen.Checked = true;
                    if (_objEdit.i_OrdenExam == 1)
                    {
                        rbMedTratante.Checked = true;
                    }
                    else if (rbMedSolicitante.Checked == true)
                    {
                        rbMedSolicitante.Checked = true;
                    }
                   
                    txtClinica.Text = _objEdit.d_PorcClinicaExam.ToString();
                    txtMedico.Text = _objEdit.d_PorcMedicoExam.ToString();

                    chkBoleta.Checked = _objEdit.i_DescontarBoletaExam == 1 ? true : false;
                    chkFactura.Checked = _objEdit.i_DescontarFactExam == 1 ? true : false;
                    chkRecibo.Checked = _objEdit.i_DescontarRecbExam == 1 ? true : false;

                }

                txtObservaciones.Text = _objEdit.v_Observaciones;



            }

        }

        private void CargarExamenes()
        {
            ExamenesConfigurados = oHospitalizacionBL.GetMedicosConfiguracionExamenesPago(_IdConfPago);
            grdExamenes.DataSource = ExamenesConfigurados;
        }

        private void rbXTurno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXTurno.Checked == true)
            {
                groupTurno.Enabled = true;
                groupHora.Enabled = false;
                groupExamen.Enabled = false;
            }
        }

        private void rbXHora_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXHora.Checked == true)
            {
                groupTurno.Enabled = false;
                groupHora.Enabled = true;
                groupExamen.Enabled = false;
            }
        }

        private void rbXExamen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbXExamen.Checked == true)
            {
                groupTurno.Enabled = false;
                groupHora.Enabled = false;
                groupExamen.Enabled = true;
            }
        }

        private void btnAgregarExamenAuxiliar_Click(object sender, EventArgs e)
        {
            AddAuxiliaryExam(); 
        }

        private void AddAuxiliaryExam()
        {
            var findResult = lvExamenesSeleccionados.FindItemWithText(MedicalExamId);
            var lista = ExamenesConfigurados.FindAll(p => p.v_ComponentId == MedicalExamId);

            string IsProcessed = "0";
            string IsNewService = "0";
            // El examen ya esta agregado
            if (findResult != null)
            {
                MessageBox.Show("Por favor seleccione otro examen.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lista.Count >= 1)
            {
                MessageBox.Show("Examen ya se encuentra cargado, elija otro.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //var res = _ListaComponentes.Find(p => p == MedicalExamId);
            //if (res != null)
            //{
            //    var DialogResult = MessageBox.Show("Este examen ya se encuentra agregado, ¿Desea crear nuevo servicio?", "Error de validación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    if (DialogResult == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        IsNewService = "1";
            //    }
            //    else
            //    {
            //        return;
            //    }

            //}


            var row = new ListViewItem(new[] { MedicalExamName, MedicalExamId, IsProcessed, IsNewService });

            lvExamenesSeleccionados.Items.Add(row);

            gbExamenesSeleccionados.Text = string.Format("Examenes Seleccionados {0}", lvExamenesSeleccionados.Items.Count);
        }

        private void btnRemoverExamenAuxiliar_Click(object sender, EventArgs e)
        {
            var selectedItem = lvExamenesSeleccionados.SelectedItems[0];
            var medicalExamId = selectedItem.SubItems[1].Text;

            // Eliminacion fisica
            lvExamenesSeleccionados.Items.Remove(selectedItem);
            gbExamenesSeleccionados.Text = string.Format("Examenes Seleccionados {0}", lvExamenesSeleccionados.Items.Count);
        }

        private void gdDataExamsNew_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            bool row = gdDataExamsNew.Selected.Rows.Count > 0;
            if (!row)
            {
                return;
            }
            if (gdDataExamsNew.Selected.Rows[0].Cells["v_ComponentId"].Value == null)
            {
                btnAgregarExamenAuxiliar.Enabled = false;

                return;
            }
            else
            {
                btnAgregarExamenAuxiliar.Enabled = true;
            }

            lvExamenesSeleccionados.SelectedItems.Clear();

            if (gdDataExamsNew.Selected.Rows.Count == 0)
                return;

            MedicalExamId = gdDataExamsNew.Selected.Rows[0].Cells["v_ComponentId"].Value.ToString();
            MedicalExamName = gdDataExamsNew.Selected.Rows[0].Cells["v_ComponentName"].Value.ToString();

            if (gdDataExamsNew.Selected.Rows[0].Cells["v_ComponentId"].Value != null)
            {
                MedicalExamName = gdDataExamsNew.Selected.Rows[0].Cells["v_ComponentName"].Value.ToString();
            }
            else
            {
                MedicalExamName = string.Empty;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            configuracionpagoDto confPagoDto = new configuracionpagoDto();
            if (ddlUsuario.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Seleccione Médico para configurar pago.", "VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                confPagoDto.i_SystemUserId = int.Parse(ddlUsuario.SelectedValue.ToString());
            }
            if (rbXTurno.Checked == true)
            {
                confPagoDto.i_TipoPago = 1;
                confPagoDto.d_MontoxTurno = float.Parse(txtMontoTurno.Text);

                //
                confPagoDto.d_MonoxHora = null;
                confPagoDto.i_DesucuentodeHorario = null;
                confPagoDto.i_TipoDescuentoHoraMin = null;

                confPagoDto.i_OrdenExam = null;
                confPagoDto.d_PorcClinicaExam = null;
                confPagoDto.d_PorcMedicoExam = null;
                confPagoDto.i_DescontarBoletaExam = null;
                confPagoDto.i_DescontarFactExam = null;
                confPagoDto.i_DescontarRecbExam = null;
            }
            else if (rbXHora.Checked == true)
            {
                confPagoDto.i_TipoPago = 2;
                confPagoDto.d_MonoxHora = float.Parse(txtMontoHora.Text);
                confPagoDto.i_DesucuentodeHorario = int.Parse(txtTiempoDesc.Text);
                confPagoDto.i_TipoDescuentoHoraMin = rbHoras.Checked == true ? 1 : 2;

                //
                confPagoDto.d_MontoxTurno = null;

                confPagoDto.i_OrdenExam = null;
                confPagoDto.d_PorcClinicaExam = null;
                confPagoDto.d_PorcMedicoExam = null;
                confPagoDto.i_DescontarBoletaExam = null;
                confPagoDto.i_DescontarFactExam = null;
                confPagoDto.i_DescontarRecbExam = null;
            }
            else if (rbXExamen.Checked == true)
            {
                confPagoDto.i_TipoPago = 3;
                if (rbMedTratante.Checked == true)
                {
                    confPagoDto.i_OrdenExam = 1;
                }
                else if (rbMedSolicitante.Checked == true)
                {
                    confPagoDto.i_OrdenExam = 2;
                }
                else
                {
                    MessageBox.Show("Seleccione tipo de comisión.", "VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                confPagoDto.d_PorcClinicaExam = float.Parse(txtClinica.Text);
                confPagoDto.d_PorcMedicoExam = float.Parse(txtMedico.Text);

                confPagoDto.i_DescontarBoletaExam = chkBoleta.Checked == true ? 1 : 0;
                confPagoDto.i_DescontarFactExam = chkFactura.Checked == true ? 1 : 0;
                confPagoDto.i_DescontarRecbExam = chkRecibo.Checked == true ? 1 : 0;

                //
                confPagoDto.d_MontoxTurno = null;
                confPagoDto.d_MonoxHora = null;
                confPagoDto.i_DesucuentodeHorario = null;
                confPagoDto.i_TipoDescuentoHoraMin = null;
            }

            List<AdditionalExamCustom> ListAdditionalExam = new List<AdditionalExamCustom>();

            foreach (ListViewItem item in lvExamenesSeleccionados.Items)
            {
                AdditionalExamCustom _additionalExam = new AdditionalExamCustom();
                var fields = item.SubItems;
                _additionalExam.ComponentId = fields[1].Text;
                _additionalExam.IsProcessed = int.Parse(fields[2].Text);
                _additionalExam.IsNewService = int.Parse(fields[3].Text);

                if (_additionalExam.IsNewService == 1)
                {
                    _additionalExam.ProtocolId = Constants.Prot_Hospi_Adic;
                }
                ListAdditionalExam.Add(_additionalExam);
            }



            confPagoDto.v_Observaciones = txtObservaciones.Text;

            if (_mode == "New")
            {
                var registroNuevo = oHospitalizacionBL.AddConfiguracionPago(ref objOperationResult, confPagoDto, Globals.ClientSession.GetAsList(), ListAdditionalExam);
                MessageBox.Show("Registro N° " + registroNuevo + " fue guardado Correctamente.", "INFORMACION!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

                confPagoDto.v_IdConfPago = _IdConfPago;
                oHospitalizacionBL.UpdateConfiguracionPago(ref objOperationResult, confPagoDto, Globals.ClientSession.GetAsList(), ListAdditionalExam);

                MessageBox.Show("Registro N° " + _IdConfPago + "fue actualizado Correctamente.", "INFORMACION!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdExamenes_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.grdExamenes.Selected.Rows)
            {
                btnEliminar.Enabled =

                (grdExamenes.Selected.Rows.Count > 0);

                if (grdExamenes.Selected.Rows.Count == 0)
                    return;

                _idPagoExam = grdExamenes.Selected.Rows[0].Cells["v_idPagoExam"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult1 = new OperationResult();
            _idPagoExam = grdExamenes.Selected.Rows[0].Cells["v_idPagoExam"].Value.ToString();
            oHospitalizacionBL.DeleteExamenConf(ref objOperationResult1, _idPagoExam, Globals.ClientSession.GetAsList());
            MessageBox.Show("Se eliminó correctamente", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarExamenes();

        }

        private void lvExamenesSeleccionados_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = lvExamenesSeleccionados.SelectedItems[0];
            var medicalExamId = selectedItem.SubItems[1].Text;

            // Eliminacion fisica
            lvExamenesSeleccionados.Items.Remove(selectedItem);
            gbExamenesSeleccionados.Text = string.Format("Examenes Seleccionados {0}", lvExamenesSeleccionados.Items.Count);
        }

        private void lvExamenesSeleccionados_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnRemoverExamenAuxiliar.Enabled = (lvExamenesSeleccionados.SelectedItems.Count > 0);
        }

    }
}
