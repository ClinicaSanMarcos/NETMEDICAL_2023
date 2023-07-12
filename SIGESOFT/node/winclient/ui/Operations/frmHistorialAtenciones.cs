using CrystalDecisions.Shared;
using Sigesoft.Common;
using Sigesoft.Node.Contasol.Integration;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.UI.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Operations
{
    public partial class frmHistorialAtenciones : Form
    {
        private OperationResult _objOperationResult = new OperationResult();

        private string PersonId;
        private string _serviceId;

        ServiceBL _serviceBL = new ServiceBL();
        PacientBL _pacientBL = new PacientBL();
        RecetaBl objRecetaBl = new RecetaBl();
        private string _ServiceId;
        private string _Trabajador;

        private string _componentId;


        public frmHistorialAtenciones(string _PersonId)
        {
            PersonId = _PersonId;
            InitializeComponent();
        }

        private void frmHistorialAtenciones_Load(object sender, EventArgs e)
        {
            _componentId = Sigesoft.Common.Constants.ATENCION_INTEGRAL_ID;
            var services = new ServiceBL().GetServicesConsolidateForPerson(ref _objOperationResult, PersonId);
            ultraGrid1.DataSource = services;
        }

        private void btnVerServicioAnterior_Click(object sender, EventArgs e)
        {
            var _serviceId = ultraGrid1.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();

            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var añosCompleto = DiferenciaFechas(datosP.FechaServicio.Value, datosP.d_Birthdate.Value);
            var medicoTratante = new ServiceBL().GetMedicoTratante(_serviceId);


            _ServiceId = datosP.v_IdService;
            PersonId = datosP.v_PersonId;

            lblFecha.Text = datosP.FechaServicio.ToString().Split(' ')[0];
            lblCodigo.Text = datosP.v_IdService;
            lblMedicoTratante.Text = medicoTratante == null ? "- - -" : medicoTratante.Nombre;
            lblPaciente.Text = datosP.v_FirstLastName + " " + datosP.v_SecondLastName + " " + datosP.v_FirstName;

            _Trabajador = datosP.v_FirstLastName + " " + datosP.v_SecondLastName + " " + datosP.v_FirstName;

            lblDNI.Text = datosP.v_DocNumber;
            lblEdad.Text = añosCompleto;
            lblSexo.Text = datosP.Genero;
            lblEstadoCivil.Text = datosP.v_MaritalStatus;
            lblTelefono.Text = datosP.v_TelephoneNumber;
            lblFechaNacimiento.Text = datosP.d_Birthdate.ToString().Split(' ')[0];
            lblHistoria.Text = datosP.HistoriaClinica.ToString();
            lblNacionalidad.Text = datosP.v_Nacionalidad;
            lblResidenciaActual.Text = datosP.v_AdressLocation;
            lblResidenciaAnterior.Text = datosP.v_ResidenciaAnterior == "" ? "- - -" :
                datosP.v_ResidenciaAnterior == null ? "- - -" : datosP.v_ResidenciaAnterior;
            lblGradoInstruccion.Text = datosP.GradoInstruccion;
            lblReligion.Text = datosP.v_Religion == "" ? "- - -" :
                datosP.v_Religion == null ? "- - -" : datosP.v_Religion;
            lblOcupacion.Text = datosP.v_CurrentOccupation == "" ? "- - -" :
                datosP.v_CurrentOccupation == null ? "- - -" : datosP.v_CurrentOccupation;

            var exams = _serviceBL.GetServiceComponentsReport(_serviceId);

            //Antropometria
            ServiceComponentList antro = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.ANTROPOMETRIA_ID);
            string peso = "", peso_unidad = "", talla = "", talla_unidad = "", imc = "", imc_unidad = "";
            if (antro != null)
            {
                peso = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID).v_Value1;
                peso_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_PESO_ID).v_MeasurementUnitName;
                talla = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID).v_Value1;
                talla_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_TALLA_ID).v_MeasurementUnitName;
                imc = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID).v_Value1;
                imc_unidad = antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID) == null ? "" : antro.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ANTROPOMETRIA_IMC_ID).v_MeasurementUnitName;

            }

            lblPeso.Text = peso + " " + peso_unidad;
            lblTalla.Text = talla + " " + talla_unidad;
            lblImc.Text = imc + " " + imc_unidad;

            ServiceComponentList funcVit = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.FUNCIONES_VITALES_ID);
            string temp = "", temp_unidad = "", pres_Sist = "", pres_Diast = "", pres_Diast_unidad = "", frecCard = "", frecCard_unidad = "", frecResp = "", frecResp_unidad = "", spo2 = "", spo2_unidad = "";
            if (funcVit != null)
            {
                temp = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID).v_Value1;
                temp_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_TEMPERATURA_ID).v_MeasurementUnitName;
                pres_Sist = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAS_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAS_ID).v_Value1;
                pres_Diast = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID).v_Value1;
                pres_Diast_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_PAD_ID).v_MeasurementUnitName;
                frecCard = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID).v_Value1;
                frecCard_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_CARDIACA_ID).v_MeasurementUnitName;
                frecResp = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID).v_Value1;
                frecResp_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_FREC_RESPIRATORIA_ID).v_MeasurementUnitName;
                spo2 = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID).v_Value1;
                spo2_unidad = funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID) == null ? "" : funcVit.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.FUNCIONES_VITALES_SAT_O2_ID).v_MeasurementUnitName;

            }

            lblFrecuenciaRespiratoria.Text = frecResp + " " + frecResp_unidad;
            lblFrecuenciaCardiaca.Text = frecCard + " " + frecCard_unidad;
            lblTemperatura.Text = temp + " " + temp_unidad;
            lblPresionArterial.Text = pres_Sist + " / " + pres_Diast + " " + pres_Diast_unidad;
            lblSaturacion.Text = spo2 + " " + spo2_unidad;


            ServiceComponentList atenInte = exams.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_ID);

            string signos_sintomas = "",
                tiempoEnf = "",
                relato_cronologico = "",
                piel_faneras = "",
                fechaControl = "",
                accionFinal = "",
                observaciones = "",
                planterap = "",
                tDxClinico = "";

            if (atenInte != null)
            {
                signos_sintomas = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_SIGNOS_SINTOMAS) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_SIGNOS_SINTOMAS).v_Value1;
                tiempoEnf = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_TIEMPO_EMF) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_TIEMPO_EMF).v_Value1;
                relato_cronologico = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RELATO_PATOLOGICO_DESC).v_Value1;
                piel_faneras = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PIEL_FANERAS_TEJIDO_SUBCUTANEO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PIEL_FANERAS_TEJIDO_SUBCUTANEO).v_Value1;
                tDxClinico = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_DIAGNOSTICO_CLINICO).v_Value1;

                planterap = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PLAN_TERAPEUTICO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PLAN_TERAPEUTICO).v_Value1;

                fechaControl = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PROX_CITA) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_PROX_CITA).v_Value1;
                accionFinal = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_RESULTADO).v_Value1Name;
                observaciones = atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_OBSERVACIONES) == null ? "" : atenInte.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_OBSERVACIONES).v_Value1;
            }

            txtSingosSintomas.Text = signos_sintomas;
            txtTiempoEnfermedad.Text = tiempoEnf;
            txtRelatoCronologico.Text = relato_cronologico;
            txtPielFaneras.Text = piel_faneras;
            txtPlanTerap.Text = planterap;
            lblFechaControl.Text = fechaControl;
            lblResultadoFinal.Text = accionFinal;
            lblObservacionesAdicionales.Text = observaciones;
            txtDxClinico.Text = tDxClinico;
            var Diagnosticos = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var filterDiagnosticRepository = Diagnosticos.FindAll(p => p.i_FinalQualificationId != (int)Sigesoft.Common.FinalQualification.Descartado);

            List<DiagnosticosHistoria> DiagnosticosHistoriaList = new List<DiagnosticosHistoria>();
            if (filterDiagnosticRepository != null && filterDiagnosticRepository.Count > 0)
            {
                DiagnosticosHistoria DiagnosticosHistoriaObj = new DiagnosticosHistoria();

                foreach (var item in filterDiagnosticRepository)
                {
                    if (item.v_DiseasesId != "N009-DD000000029")
                    {

                        DiagnosticosHistoriaObj.Diagnostico = item.v_DiseasesName + "[" + item.v_Cie10 + "]";
                    }

                    var recomendaciones = "";
                    foreach (var Reco in item.Recomendations)
                    {
                        recomendaciones += " -" + Reco.v_RecommendationName + " / ";

                    }

                    DiagnosticosHistoriaObj.Recomendaciones = recomendaciones;

                    var Restricciones = "";
                    foreach (var Rest in item.Restrictions)
                    {
                        Restricciones += " -" + Rest.v_RestrictionName + " / ";
                    }

                    DiagnosticosHistoriaObj.Restricciones = Restricciones;
                    DiagnosticosHistoriaList.Add(DiagnosticosHistoriaObj);
                }
            }

            grdDiagnosticos.DataSource = DiagnosticosHistoriaList;
            var medicina = objRecetaBl.GetReceta(_serviceId);
            grdPlanTerapeutico.DataSource = medicina;

            List<Categoria> DataSource = new List<Categoria>();
            List<string> ComponentList = new List<string>();
            var ListadditExam = new AdditionalExamBL().GetAdditionalExamByServiceId_Historia(_serviceId);

            foreach (var componenyId in ListadditExam)
            {
                ComponentList.Add(componenyId.ComponentId);
            }
            OperationResult objOperationResult = new OperationResult();

            foreach (var componentId in ComponentList)
            {
                var ListServiceComponent = new ServiceBL().GetAllComponents(ref objOperationResult, 5, componentId);

                Categoria categoria = DataSource.Find(x => x.i_CategoryId == ListServiceComponent[0].i_CategoryId);
                if (categoria != null)
                {
                    List<ComponentDetailList> componentDetail = new List<ComponentDetailList>();
                    componentDetail = ListServiceComponent[0].Componentes;
                    DataSource.Find(x => x.i_CategoryId == ListServiceComponent[0].i_CategoryId).Componentes.AddRange(componentDetail);
                }
                else
                {
                    DataSource.AddRange(ListServiceComponent);
                }
            }

            #region EXAMENES AUXILIARES
            List<ExamenesAuxiliares> ExamenesAuxiliaresList = new List<ExamenesAuxiliares>();
            if (DataSource.Count != 0)
            {
                foreach (var category in DataSource)
                {
                    foreach (var component in category.Componentes)
                    {
                        ExamenesAuxiliares ExamenesAuxiliaresObj = new ExamenesAuxiliares();

                        ExamenesAuxiliaresObj.Categoria = category.v_CategoryName;
                        ExamenesAuxiliaresObj.Examen = component.v_ComponentName;
                        ExamenesAuxiliaresList.Add(ExamenesAuxiliaresObj);
                    }
                }
            }

            #endregion
            grdExamenesAuxiliares.DataSource = ExamenesAuxiliaresList;


            HistoriasMedicasAdjuntas(_ServiceId);

        }

        private string DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            int anios;
            int meses;
            int dias;
            string str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios < 0)
            {
                return "La fecha inicial es mayor a la fecha final";
            }
            if (anios > 0)
            {
                if (anios == 1)
                    str = str + anios.ToString() + " año ";
                else
                    str = str + anios.ToString() + " años ";
            }
            if (meses > 0)
            {
                if (meses == 1)
                    str = str + meses.ToString() + " mes y ";
                else
                    str = str + meses.ToString() + " meses y ";
            }
            if (dias > 0)
            {
                if (dias == 1)
                    str = str + dias.ToString() + " día ";
                else
                    str = str + dias.ToString() + " días ";
            }
            return str;
        }


        private void btnBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileSize = Convert.ToInt32(Convert.ToSingle(Common.Utils.GetFileSizeInMegabytes(openFileDialog1.FileName)));

                if (fileSize > 7)
                {
                    MessageBox.Show("La imagen que está tratando de subir es damasiado grande.\nEl tamaño maximo es de 7 MB.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtFileName.Text = Path.GetFileName(openFileDialog1.FileName);
                btnAceptar.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string ruta = Common.Utils.GetApplicationConfigValue("Interconsulta").ToString();
            string destino = ruta + _ServiceId + "-" + _Trabajador + ".pdf";
            if (File.Exists(destino))
            {
                System.IO.File.Delete(destino);
                File.Copy(openFileDialog1.FileName, destino);
            }
            else { File.Copy(openFileDialog1.FileName, destino); }
            MessageBox.Show("El archivo se anexó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAceptar.Enabled = false;
            HistoriasMedicasAdjuntas(_ServiceId);
        }

        private void HistoriasMedicasAdjuntas(string _ServiceId)
        {
            try
            {
                var consolidado = Common.Utils.GetApplicationConfigValue("Interconsulta").ToString();
                string _rutaconsolidado = consolidado + "\\";



                string fileName = _rutaconsolidado + _ServiceId + "-" + _Trabajador + ".pdf";


                if (File.Exists(fileName))
                {
                    try
                    {
                        panelMensaje.Visible = false;

                        pdfAnexoAdjunto.src = fileName;

                    }
                    catch (Exception f)
                    {
                        panelMensaje.Visible = true;
                    }
                }
                else
                {
                    panelMensaje.Visible = true;
                }

            }
            catch (Exception)
            {

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (new LoadingClass.PleaseWait(this.Location, "Generando Reporte..."))
            {
                OperationResult objOperationResult = new OperationResult();
                PacientListNew filiationData = new PacientBL().GetPacientReportEPS_NewOrganizationId(_ServiceId);
                //PacientId = filiationData.PersonId;
                frmManagementReports frmManagmentReport = new frmManagementReports();
                DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                List<ServiceComponentListReportSolo> serviceComponents = _serviceBL.GetServiceComponentsReportForReportSolo(_ServiceId);
                var arrComponentId = _componentId.Split('|');

                #region medicina

                if (arrComponentId.Contains(Constants.ATENCION_INTEGRAL_ID))
                {
                    List<string> componentIds = new List<string>();

                    ServiceComponentListReportSolo atencionIntegral = serviceComponents.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.ATENCION_INTEGRAL_ID);

                    if (atencionIntegral != null)
                    {
                        componentIds.Add(Constants.ATENCION_INTEGRAL_ID);
                    }

                    frmManagmentReport.reportSolo(componentIds, PersonId, _ServiceId);
                }
                #endregion

            };
        }
    }
}
