﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;
using Infragistics.Win.UltraWinGrid;


namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmOffice_ : Form
    {
        #region Declarations

        string _Piso;
        string _serviceId;
        string _componentId;
        string _componentName;
        string _IsCall;
        int _Flag = 0;
        int _TserviceId;
        string _CalendarId;
        List<string> _ServiceComponentId = new List<string>();
        byte[] _personImage;
        string _personName;
        int _categoryId;
        private Sigesoft.Node.WinClient.UI.Utils.CustomizedToolTip _customizedToolTip = null;
        private string _serviceStatusId;
        ServiceBL _serviceBL = new ServiceBL();
        PacientBL _pacientBL = new PacientBL();
        private string _personId;
        private int _categoriaId;
        private string _ProtocolId;
        CalendarBL _objCalendarBL = new CalendarBL();


        #endregion

        public List<string> _componentIds { get; set; }

        public frmOffice_(string pstrComponentName, int pintCategoria)
        {
            InitializeComponent();
            //timer1.Interval = 200;
            _componentId = "";
            _categoriaId = pintCategoria;
            _componentName = pstrComponentName;

        }

        private void frmOffice_Load(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

             Utils.LoadDropDownList(cbOficina, "Value1", "Id", BLL.Utils.GetDataHierarchyForCombo(ref objOperationResult, 116, null), DropDownListAction.Select);
            
            using (new LoadingClass.PleaseWait(this.Location, "Cargando..."))
            {
                _customizedToolTip = new Sigesoft.Node.WinClient.UI.Utils.CustomizedToolTip(grdDataServiceComponent);
                btnRefresh_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label10.Visible = !label10.Visible;
        }

        private void Llamar()
        {
            OperationResult objOperationResult = new OperationResult();
            List<ServiceComponentList> ListServiceComponent = new List<ServiceComponentList>();
            CalendarBL objCalendarBL = new CalendarBL();
            CalendarList objCalendar = new CalendarList();
            List<CalendarList> objCalendarList = new List<CalendarList>();
            ProtocolBL oProtocolBL = new ProtocolBL();

            ServiceBL objServiceBL = new ServiceBL();
            servicecomponentDto objservicecomponentDto = new servicecomponentDto();

            _ServiceComponentId = new List<string>();

            // Verificar si un componente está en la categoría
            MedicalExamBL oMedicalExamBL = new MedicalExamBL();

          Boolean Resultado = oMedicalExamBL.VerificarComponentePorCategoria(_categoriaId, Constants.ELECTROCARDIOGRAMA_ID);

          if (Resultado)
          {

            List<ServiceComponentFieldValuesList> Valores=  objServiceBL.ValoresComponente(_serviceId, Constants.ANTROPOMETRIA_ID);
            decimal ValorIMCServicio = decimal.Parse(Valores.Find(p => p.v_ComponentFieldId == Constants.ANTROPOMETRIA_IMC_ID).v_Value1.ToString());
            decimal ValorIMCProtocolo = decimal.Parse(oProtocolBL.GetProtocolComponentByProtocol(ref objOperationResult, _ProtocolId, Constants.ELECTROCARDIOGRAMA_ID).r_Imc.ToString());

            if (ValorIMCServicio < ValorIMCProtocolo)
            {
                MessageBox.Show("El I.M.C. del paciente tiene valores normales, no aplica para este examen", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


          }


            //Validación de Piso
            if (_Piso != "-1")
            {
                var ResultPiso = objServiceBL.PermitirLlamar(_serviceId, int.Parse(_Piso.ToString()));
                if (!ResultPiso)
                {
                    MessageBox.Show("El Paciente tiene consultorios por culminar, antes de ser llamado por este. Verifíquelo en unos minutos", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
           
            if (int.Parse(_serviceStatusId) == (int)ServiceStatus.EsperandoAptitud)
            {
                MessageBox.Show("Este paciente ya tiene el servicio en espera de Aptitud, no puede ser llamado.", "INFORMACIÓN!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            if (_IsCall == "OcupadoLlamado")
            {
                DialogResult Result = MessageBox.Show("¿Está seguro de LLAMAR a este paciente que está ocupado?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == DialogResult.No) 
                    return;
            }
          
            objCalendar.v_Pacient = grdListaLlamando.Selected.Rows[0].Cells["v_Pacient"].Value.ToString();
            objCalendar.v_OrganizationName = grdListaLlamando.Selected.Rows[0].Cells["v_WorkingOrganizationName"].Value.ToString();
            objCalendar.v_ServiceComponentId = grdListaLlamando.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString();         

            if (_categoryId == -1)
            {
                _ServiceComponentId.Add(grdListaLlamando.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString());
            }
            else
            {
                foreach (var item in objServiceBL.GetServiceComponentByCategoryId(ref objOperationResult, _categoryId, _serviceId))
                {
                    _ServiceComponentId.Add(item.v_ServiceComponentId);
                }
            }

            // Cargar grilla de llamando al paciente  ************
            objCalendarList.Add(objCalendar);
            grdLlamandoPaciente.DataSource = objCalendarList;

            if (grdLlamandoPaciente.Rows.Count > 0)         
                grdLlamandoPaciente.Rows[0].Selected = true;

            //*******************************************************
            
            for (int i = 0; i < _ServiceComponentId.Count; i++)
            {           
                objservicecomponentDto = new servicecomponentDto();
                objservicecomponentDto.v_ServiceComponentId = _ServiceComponentId[i];             
                objservicecomponentDto.i_QueueStatusId = (int)Common.QueueStatusId.LLAMANDO;
                objservicecomponentDto.v_NameOfice = cbOficina.Text.ToString();
                objServiceBL.UpdateServiceComponentOfficeLlamando(objservicecomponentDto);
            }

            //Actualizar grdDataServiceComponent      
            ListServiceComponent = objServiceBL.GetServiceComponents(ref objOperationResult, _serviceId);
            grdDataServiceComponent.DataSource = ListServiceComponent;

            grdListaLlamando.Enabled = false;
            grdLlamandoPaciente.Enabled = true;
            btnRefresh.Enabled = false;

            chkHability.Enabled = true;

            btnLlamar.Enabled = false;
        }

        private void mnullamar_Click(object sender, EventArgs e)
        {
            Llamar();
        }

        private void Atender()
        {
            OperationResult objOperationResult = new OperationResult();
            ServiceBL objServiceBL = new ServiceBL();
            servicecomponentDto objservicecomponentDto = new servicecomponentDto();
            List<ServiceComponentList> ListServiceComponent = new List<ServiceComponentList>();
            _ServiceComponentId = new List<string>();

            if (chkVerificarHuellaDigital.Checked)
            {
                var checkingFinger = new frmCheckingFinger("");
                checkingFinger._PacientId = _personId;
                checkingFinger.ShowDialog();

                if (checkingFinger.DialogResult == DialogResult.Cancel)
                    return;
            }
          
            DialogResult Result = MessageBox.Show("¿Está seguro de INICIAR ATENCIÓN este registro?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (_categoryId == -1)
            {
                _ServiceComponentId.Add(grdListaLlamando.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString());
            }
            else
            {
                foreach (var item in objServiceBL.GetServiceComponentByCategoryId(ref objOperationResult, _categoryId, _serviceId))
                {
                    _ServiceComponentId.Add(item.v_ServiceComponentId);
                }
            }
      
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < _ServiceComponentId.Count(); i++)
                {
                    objservicecomponentDto = objServiceBL.GetServiceComponent(ref objOperationResult, _ServiceComponentId[i]);
                    objservicecomponentDto.i_QueueStatusId = (int)Common.QueueStatusId.OCUPADO;
                    objservicecomponentDto.d_StartDate = DateTime.Now;
                    objServiceBL.UpdateServiceComponent(ref objOperationResult, objservicecomponentDto, Globals.ClientSession.GetAsList());
                }
                //Actualizar grdDataServiceComponent
                string strServicelId = grdListaLlamando.Selected.Rows[0].Cells[5].Value.ToString();
                ListServiceComponent = objServiceBL.GetServiceComponents(ref objOperationResult, strServicelId);
                grdDataServiceComponent.DataSource = ListServiceComponent;

                _Flag = 1;

                Form frm;
                if (_TserviceId == (int)MasterService.AtxMedicaParticular || _TserviceId == (int)MasterService.AtxMedicaSeguros)
                {
                    frm = new Operations.frmMedicalConsult(_serviceId, string.Join("|", _componentIds.Select(p => p)), null);
                    frm.ShowDialog();
                }
                else
                {
                    this.Enabled = false;
                    frm = new Operations.frmEso(_serviceId, string.Join("|", _componentIds.Select(p => p)), null, (int)MasterService.Eso);
                    frm.ShowDialog();
                    this.Enabled = true;
                    // Aviso automático de que se culminaron todos los examanes, se tendria que proceder
                    // a establecer el estado del servicio a (Culminado Esperando Aptitud)               

                    var alert = objServiceBL.GetServiceComponentsCulminados(ref objOperationResult, _serviceId);

                    if (alert != null && alert.Count > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Todos los Examenes se encuentran concluidos.\nEl estado de la Atención es: En espera de Aptitud .", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        serviceDto objserviceDto = new serviceDto();
                        objserviceDto = objServiceBL.GetService(ref objOperationResult, objservicecomponentDto.v_ServiceId);
                        objserviceDto.i_ServiceStatusId = (int)ServiceStatus.EsperandoAptitud;
                        objserviceDto.v_Motive = "Esperando Aptitud";

                        objServiceBL.UpdateService(ref objOperationResult, objserviceDto, Globals.ClientSession.GetAsList());
                    }

                }

                // refrecar la grilla
                ListServiceComponent = objServiceBL.GetServiceComponents(ref objOperationResult, _serviceId);
                grdDataServiceComponent.DataSource = ListServiceComponent;
            }
        }

        private void mnuAtender_Click(object sender, EventArgs e)
        {
            Atender();
        }

        private void Liberar()
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();
                ServiceBL objServiceBL = new ServiceBL();

                servicecomponentDto objservicecomponentDto = null;
                List<ServiceComponentList> ListServiceComponent = new List<ServiceComponentList>();

                if (_categoryId == -1)
                {
                    _ServiceComponentId.Add(grdLlamandoPaciente.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString());
                }
                else
                {
                    var servCompCat = objServiceBL.GetServiceComponentByCategoryId(ref objOperationResult, _categoryId, _serviceId);

                    foreach (var item in servCompCat)
                    {
                        _ServiceComponentId.Add(item.v_ServiceComponentId);
                    }
                }

                List<servicecomponentDto> list = new List<servicecomponentDto>();

                for (int i = 0; i < _ServiceComponentId.Count; i++)
                {
                    objservicecomponentDto = new servicecomponentDto();
                    objservicecomponentDto.v_ServiceComponentId = _ServiceComponentId[i];
                    objservicecomponentDto.i_QueueStatusId = (int)Common.QueueStatusId.LIBRE;
                    objservicecomponentDto.i_Iscalling = (int)SiNo.NO;
                    objservicecomponentDto.d_EndDate = DateTime.Now;
                    list.Add(objservicecomponentDto);
                }

                // update
                objServiceBL.UpdateServiceComponentOffice(list);

                #region Check de salir de circuito
                              
                if (chkHability.Checked == true) // finaliza el servicio y actualiza el estado del servicio
                {
                    if (ddlServiceStatusId.SelectedValue.ToString() == ((int)ServiceStatus.Iniciado).ToString())
                    {
                        MessageBox.Show("Debe elegir cualquier otro estado que no sea (Iniciado)\nSi desea Liberar y/o Finalizar Circuito.", "ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    serviceDto objserviceDto = new serviceDto();
                  
                    objserviceDto.v_ServiceId = _serviceId;
                    objserviceDto.i_ServiceStatusId = int.Parse(ddlServiceStatusId.SelectedValue.ToString());
                    objserviceDto.v_Motive = txtReason.Text;

                    objServiceBL.UpdateServiceOffice(ref objOperationResult, objserviceDto, Globals.ClientSession.GetAsList());

                    //Actualizamos el estado de la linea de la agenda como fuera de circuito
                    CalendarBL objCalendarBL = new CalendarBL();
                    calendarDto objcalendarDto = new calendarDto();
                    objcalendarDto = objCalendarBL.GetCalendar(ref objOperationResult, _CalendarId);
                    objcalendarDto.i_LineStatusId = 2;// int.Parse(Common.LineStatus.FueraCircuito.ToString());
                    objCalendarBL.UpdateCalendar(ref objOperationResult, objcalendarDto, Globals.ClientSession.GetAsList());

                }

                #endregion

                //Actualizar grdDataServiceComponent
              
                ListServiceComponent = objServiceBL.GetServiceComponents(ref objOperationResult, _serviceId);
                grdDataServiceComponent.DataSource = ListServiceComponent;
             
                btnRefresh_Click(null, null);

                txtReason.Text = "";
                grdListaLlamando.Enabled = true;
                grdLlamandoPaciente.Enabled = false;
                btnRefresh.Enabled = true;
                chkHability.Enabled = false;
                chkHability.Checked = false;
                groupBox3.Enabled = false;

                grdLlamandoPaciente.DataSource = new List<CalendarList>();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(Common.Utils.ExceptionFormatter(ex), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void mnuLiberar_Click(object sender, EventArgs e)
        {
            Liberar();
        }

        private void grdListaLlamando_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();

            var serviceId = e.Row.Cells["v_ServiceId"].Value.ToString();
            var Piso = e.Row.Cells["Piso"].Value.ToString();

            var serviceComponents = _serviceBL.GetServiceComponents(ref objOperationResult, serviceId);

            var atendido = serviceComponents.Find(p => _componentIds.Contains(p.v_ComponentId) &&
                                                (p.i_ServiceComponentStatusId == (int)Common.ServiceComponentStatus.Evaluado
                                                || p.i_ServiceComponentStatusId == (int)Common.ServiceComponentStatus.PorAprobacion));
            
            //BETO

            var ResultPiso = _serviceBL.PermitirLlamar(serviceId, int.Parse(Piso.ToString()));
            if (!ResultPiso)
            {
                e.Row.Cells["b_NoLlamar"].Value = Resources.user_cross;
            }
            else
            {
                e.Row.Cells["b_NoLlamar"].Value = Resources.user_earth;
            }


            if (atendido != null)
            {
                e.Row.Cells["b_IsAttended"].Value = Resources.bullet_tick;
                e.Row.Cells["b_IsAttended"].ToolTipText = atendido.v_ServiceComponentStatusName;
            }
            else
            {
                var noAtendido = serviceComponents.Find(p => _componentIds.Contains(p.v_ComponentId));
                                           
                e.Row.Cells["b_IsAttended"].Value = Resources.bullet_red;
                e.Row.Cells["b_IsAttended"].ToolTipText = noAtendido.v_ServiceComponentStatusName;
            }

            //Si el contenido de la columna Vip es igual a SI
            if (e.Row.Cells["v_IsVipName"].Value.ToString().Trim() == Common.SiNo.SI.ToString())
            {
                //Escojo 2 colores
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.BackColor2 = Color.Pink;
                //Y doy el efecto degradado vertical
                e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
              
            }
            else
            {
              
                //label10.Visible = false;
            }
        }

        private void grdDataServiceComponent_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            //Si el contenido de la columna Vip es igual a SI
            if (e.Row.Cells["v_QueueStatusName"].Value.ToString().Trim() == Common.QueueStatusId.OCUPADO.ToString())
            {
                //Escojo 2 colores
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.BackColor2 = Color.Pink;
                //Y doy el efecto degradado vertical
                e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                //timer1.Start();
            }
            if (e.Row.Cells["v_QueueStatusName"].Value.ToString().Trim() == Common.QueueStatusId.LLAMANDO.ToString())
            {
                //Escojo 2 colores
                e.Row.Appearance.BackColor = Color.Orange;
                //e.Row.Appearance.BackColor2 = Color.Pink;
                //Y doy el efecto degradado vertical
                //e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                //timer1.Start();
            }

            //Si el contenido de la columna Vip es igual a SI
            if (e.Row.Cells["i_ServiceComponentStatusId"].Value.ToString() == ((int)Common.ServiceComponentStatus.Evaluado).ToString()
                || e.Row.Cells["i_ServiceComponentStatusId"].Value.ToString() == ((int)Common.ServiceComponentStatus.PorAprobacion).ToString())
            {
                //Escojo 2 colores
                e.Row.Appearance.BackColor = Color.White;
                e.Row.Appearance.BackColor2 = Color.Cyan;
                //Y doy el efecto degradado vertical
                e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            try
            {
                OperationResult objOperationResult = new OperationResult();
                CalendarBL objCalendarBL = new CalendarBL();
                List<CalendarList> objCalendarList = new List<CalendarList>();
                ServiceComponentList objServiceComponent = new ServiceComponentList();
                List<ServiceComponentList> ListServiceComponent = new List<ServiceComponentList>();

                objCalendarList = objCalendarBL.GetPacientInLineByComponentId1(ref objOperationResult, 0, null, "d_ServiceDate ASC", _componentId, DateTime.Now.Date, _componentIds.ToArray(),0);
                grdListaLlamando.DataSource = objCalendarList;
            
                lblNameComponent.Text = _componentName;

                //var dataList = BLL.Utils.GetSystemParameterForCombo(ref objOperationResult, 125, null).FindAll(p => p.Id != "1" && p.Id != "3");

                //Utils.LoadDropDownList(ddlServiceStatusId, "Value1", "Id", dataList, DropDownListAction.Select);

                grdDataServiceComponent.DataSource = ListServiceComponent;       
            }
            catch (Exception ex)
            {                
                MessageBox.Show(Common.Utils.ExceptionFormatter(ex), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void chkHability_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHability.Checked == true)
            {
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void btnEndCircuit_Click(object sender, EventArgs e) { }

        private void grdListaLlamando_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            btnLlamar.Enabled = (grdListaLlamando.Selected.Rows.Count > 0);

            if (grdListaLlamando.Selected.Rows.Count == 0)
                return;


            //Obtener Piso Actual

            _Piso = grdListaLlamando.Selected.Rows[0].Cells["Piso"].Value.ToString();

            txtPacient.Text = grdListaLlamando.Selected.Rows[0].Cells["v_Pacient"].Value.ToString();
            _personName = txtPacient.Text;
            WorkingOrganization.Text = grdListaLlamando.Selected.Rows[0].Cells["v_WorkingOrganizationName"].Value.ToString();
            OperationResult objOperationResult = new OperationResult();
          
            List<ServiceComponentList> ListServiceComponent = new List<ServiceComponentList>();

            _serviceId = grdListaLlamando.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
            _TserviceId = int.Parse(grdListaLlamando.Selected.Rows[0].Cells["i_ServiceId"].Value.ToString());
            _CalendarId = grdListaLlamando.Selected.Rows[0].Cells["v_CalendarId"].Value.ToString();
            _categoryId = (int)grdListaLlamando.Selected.Rows[0].Cells["i_CategoryId"].Value;
            _serviceStatusId = grdListaLlamando.Selected.Rows[0].Cells["i_ServiceStatusId"].Value.ToString();
            _personId = grdListaLlamando.Selected.Rows[0].Cells["v_PersonId"].Value.ToString();

            ListServiceComponent = _serviceBL.GetServiceComponents(ref objOperationResult, _serviceId);
            grdDataServiceComponent.DataSource = ListServiceComponent;

            DateTime FechaNacimiento = (DateTime)grdListaLlamando.Selected.Rows[0].Cells["d_Birthdate"].Value;
            int PacientAge = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;
            txtAge.Text = PacientAge.ToString();

            txtDni.Text = grdListaLlamando.Selected.Rows[0].Cells["v_DocNumber"].Value.ToString();
            txtProtocol.Text = grdListaLlamando.Selected.Rows[0].Cells["v_ProtocolName"].Value.ToString();
            _ProtocolId = grdListaLlamando.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();
            if (grdListaLlamando.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString() == Constants.CONSULTAMEDICA)
            {
                txtTypeESO.Text = "";
            }
            else
            {
                txtTypeESO.Text = grdListaLlamando.Selected.Rows[0].Cells["v_EsoTypeName"].Value.ToString();
            }


            // Mostrar la foto del paciente
            var personImage = _pacientBL.GetPersonImage(_personId);

            if (personImage != null)
            {
                pbImage.Image = Common.Utils.BytesArrayToImageOficce(personImage.b_PersonImage, pbImage);
                _personImage = personImage.b_PersonImage;
            }
       
            // Verificar el estado de la cola
            var ocupation = ListServiceComponent.Find(p => p.i_QueueStatusId == (int)Common.QueueStatusId.LLAMANDO
                                                        || p.i_QueueStatusId == (int)Common.QueueStatusId.OCUPADO);
            if (ocupation != null)        
                _IsCall = "OcupadoLlamado";
            else
                _IsCall = "Libre";

            ddlServiceStatusId.SelectedValue = ListServiceComponent[0].ServiceStatusId.ToString();
            txtReason.Text = ListServiceComponent[0].v_Motive.ToString();
            
        }

        private void Rellamar()
        {
            OperationResult objOperationResult = new OperationResult();
           
            //servicecomponentDto objservicecomponentDto = new servicecomponentDto();
            //CalendarBL objCalendarBL = new CalendarBL();
            //List<CalendarList> x = objCalendarBL.GetCallPacientPagedAndFiltered(ref objOperationResult, 0, null, "", "");

            //foreach (var item in x)
            //{
            //    //volver a cambiar el Flag IsCalling en 0 para que se vuelva a llamar
            //    objservicecomponentDto.v_ServiceComponentId = _ServiceComponentId[0];

                //objServiceBL.UpdateServiceComponentVisor(ref objOperationResult, item.v_ServiceComponentId, 0);

                foreach (var scid in _ServiceComponentId)
                {
                    _serviceBL.UpdateServiceComponentVisor(ref objOperationResult, scid, (int)SiNo.NO);
                }
                
            //}

        }

        private void mnuRellamar_Click(object sender, EventArgs e)
        {
            Rellamar();         
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            if (_personImage != null)
            {
                var frm = new Sigesoft.Node.WinClient.UI.Operations.Popups.frmPreviewImagePerson(_personImage, _personName);
                frm.ShowDialog();
            }

        }

        private void grdDataServiceComponent_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            // if we are not leaving a cell, then don't anything
            if (!(e.Element is CellUIElement))
            {
                return;
            }

            // prevent the timer from ticking again
            _customizedToolTip.StopTimerToolTip();

            // destroy the tooltip
            _customizedToolTip.DestroyToolTip(this);
        }

        private void grdDataServiceComponent_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            ServiceBL oServiceBL = new ServiceBL();
            List<ServiceComponentList> oServiceComponentList = new List<ServiceComponentList>();
            StringBuilder Cadena = new StringBuilder();


            // if we are not entering a cell, then don't anything
            if (!(e.Element is CellUIElement))
            {
                return;
            }

            // find the cell that the cursor is over, if any
            UltraGridCell cell = e.Element.GetContext(typeof(UltraGridCell)) as UltraGridCell;

            if (cell != null)
            {
                int categoryId = int.Parse(cell.Row.Cells["i_CategoryId"].Value.ToString());
                oServiceComponentList = oServiceBL.GetServiceComponentByCategoryId(ref objOperationResult, categoryId, _serviceId);


                if (categoryId != -1)
                {

                    foreach (var item in oServiceComponentList)
                    {
                        Cadena.Append(item.v_ComponentName);
                        Cadena.Append("\n");
                    }

                    _customizedToolTip.AutomaticDelay = 1;
                    _customizedToolTip.AutoPopDelay = 20000;
                    _customizedToolTip.ToolTipMessage = Cadena.ToString();
                    _customizedToolTip.StopTimerToolTip();
                    _customizedToolTip.StartTimerToolTip();
                }

            }
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            Llamar();
        }

        private void btnRellamar_Click(object sender, EventArgs e)
        {
            Rellamar();
        }

        private void btnAtenderVerServicio_Click(object sender, EventArgs e)
        {
            Atender();
        }

        private void btnLiberarFinalizarCircuito_Click(object sender, EventArgs e)
        {
            Liberar();
        }

        private void grdLlamandoPaciente_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            btnRellamar.Enabled = 
            btnAtenderVerServicio.Enabled = 
            btnLiberarFinalizarCircuito.Enabled = (grdLlamandoPaciente.Selected.Rows.Count > 0);
        }

        private void frmOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdLlamandoPaciente.Rows.Count > 0)
            {
                grdLlamandoPaciente.Rows[0].Selected = true;
                var message = string.Format("Debe liberar al trabajador(a): {0} antes de cerrar.", grdListaLlamando.Selected.Rows[0].Cells["v_Pacient"].Value.ToString());
                MessageBox.Show(message, "ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnAgregarAdiconal_Click(object sender, EventArgs e)
        {
            ServiceBL oServiceBL = new ServiceBL();
            var frm = new frmAddAdditionalExam();
            frm._serviceId = _serviceId;
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                return;

            OperationResult objOperationResult = new OperationResult();
            var ListServiceComponent = oServiceBL.GetServiceComponents(ref objOperationResult, _serviceId);
            grdDataServiceComponent.DataSource = ListServiceComponent;
     
        }

        private void btnRemoverEsamen_Click(object sender, EventArgs e)
        {
            ServiceBL oServiceBL = new ServiceBL();
            DialogResult Result = MessageBox.Show("¿Está seguro de eliminar este registro?", "ADVERTENCIA!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (Result == System.Windows.Forms.DialogResult.OK)
            {

                var _auxiliaryExams = new List<ServiceComponentList>();
                OperationResult objOperationResult = new OperationResult();

                int categoryId = int.Parse(grdDataServiceComponent.Selected.Rows[0].Cells["i_CategoryId"].Value.ToString());
                var serviceComponentId = grdDataServiceComponent.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString();

                if (categoryId == -1)
                {
                    ServiceComponentList auxiliaryExam = new ServiceComponentList();
                    auxiliaryExam.v_ServiceComponentId = serviceComponentId;
                    _auxiliaryExams.Add(auxiliaryExam);
                }
                else
                {
                    var oServiceComponentList = oServiceBL.GetServiceComponentByCategoryId(ref objOperationResult, categoryId, _serviceId);

                    foreach (var scid in oServiceComponentList)
                    {
                        ServiceComponentList auxiliaryExam = new ServiceComponentList();
                        auxiliaryExam.v_ServiceComponentId = scid.v_ServiceComponentId;
                        _auxiliaryExams.Add(auxiliaryExam);
                    }

                }

                _objCalendarBL.UpdateAdditionalExam(_auxiliaryExams, _serviceId, (int?)SiNo.NO, Globals.ClientSession.GetAsList());
                var ListServiceComponent = oServiceBL.GetServiceComponents(ref objOperationResult, _serviceId);
                grdDataServiceComponent.DataSource = ListServiceComponent;
                //MessageBox.Show("Se grabo correctamente", " ¡ INFORMACIÓN !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
    }
}
