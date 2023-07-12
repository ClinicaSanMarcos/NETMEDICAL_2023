using System;
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
using NetPdf;
using System.IO;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Sigesoft.Node.Contasol.Integration;

namespace Sigesoft.Node.WinClient.UI.Reports
{
    public partial class frmManagementReports : Form
    {
        #region Declarations
        RecetaBl objRecetaBl = new RecetaBl();

        List<ServiceComponentList> ConsolidadoReportes = new List<ServiceComponentList>();
        ServiceBL _serviceBL = new ServiceBL();
        private string _serviceId;
        private string _EmpresaClienteId;
        private int _flagPantalla;
        private MergeExPDF _mergeExPDF = new MergeExPDF();
        PacientBL _pacientBL = new PacientBL();
        HistoryBL _historyBL = new HistoryBL();
        private string _pacientId;
        private string _tempSourcePath;
        private string _customerOrganizationName;
        private SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        private string _personFullName;
        private List<string> _filesNameToMerge = new List<string>();
        List<ServiceComponentList> _listaDosaje = new List<ServiceComponentList>();
        DataSet dsGetRepo = null;
        string ruta;
        int _Eso;
        #endregion

        public frmManagementReports()
        {
            InitializeComponent();
        }

        public frmManagementReports(string serviceId, string pacientId, string customerOrganizationName, string personFullName, int pintFlagPantalla, string pstrEmpresaCliente, int eso)
        {
            InitializeComponent();
            _serviceId = serviceId;
            _pacientId = pacientId;
            _customerOrganizationName = customerOrganizationName;
            _personFullName = personFullName;
            _flagPantalla = pintFlagPantalla;
            _EmpresaClienteId = pstrEmpresaCliente;
            _Eso = eso;
        }

        private void frmManagementReports_Load(object sender, EventArgs e)
        {
            ruta = Common.Utils.GetApplicationConfigValue("rutaReportes").ToString();
            if (_flagPantalla == (int)Sigesoft.Common.MasterService.AtxMedica)
            {
                groupBox3.Visible = false;
                btnGenerarReporteCertificados.Visible = false;
                this.Size = new System.Drawing.Size(604, 400);
                groupBox1.Size = new System.Drawing.Size(484, 150);
                groupBox2.Location = new Point(12, 160);
            }

            string[] InformeAnexo3121 = new string[] 
            { 
                Constants.EXAMEN_FISICO_ID
               
            };

            string[] InformeFisico7C1 = new string[] 
            { 
                Constants.EXAMEN_FISICO_7C_ID
               
            };

            List<ServiceComponentList> serviceComponents = new List<ServiceComponentList>();
            List<ServiceComponentList> ListaOrdenada = new List<ServiceComponentList>();
            chklFichasMedicas.SelectedValueChanged -= chklFichasMedicas_SelectedValueChanged;
            chkCertificados.SelectedValueChanged -= chkCertificados_SelectedValueChanged;
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            if (_flagPantalla == (int)Sigesoft.Common.MasterService.AtxMedica)
            {
                serviceComponents = _serviceBL.GetServiceComponentsForManagementReportAtxMedica(_serviceId);

            }
            else
            {
                //QUERY
                serviceComponents = _serviceBL.GetServiceComponentsForManagementReport(_serviceId);

                //serviceComponents.Add(new ServiceComponentList {  v_ComponentName = "CONSENTIMIENTO INFORMADO ", v_ComponentId = Constants.CONSENTIMIENTO_INFORMADO });

                serviceComponents.Add(new ServiceComponentList { Orden = 1, v_ComponentName = "CONSENTIMIENTO INFORMADO ", v_ComponentId = Constants.CONSENTIMIENTO_INFORMADO });
                serviceComponents.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD SIN Diagnósticos ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_SIN_DX });
                serviceComponents.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD EMPRESARIAL ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_EMPRESARIAL });
                serviceComponents.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD });
                serviceComponents.Add(new ServiceComponentList { Orden = 3, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 1", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR });
                serviceComponents.Add(new ServiceComponentList { Orden = 4, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 2", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR_2 });
                serviceComponents.Add(new ServiceComponentList { Orden = 4, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 3", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR_3 });
                serviceComponents.Add(new ServiceComponentList { Orden = 27, v_ComponentName = "INFORME DE LABORATORIO", v_ComponentId = Constants.INFORME_LABORATORIO_CLINICO });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 Coimolache", v_ComponentId = Constants.INFORME_ANEXO_16_COIMOLACHE });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 Yanacocha", v_ComponentId = Constants.INFORME_ANEXO_16_YANACOCHA });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 Pacasmayo", v_ComponentId = Constants.INFORME_ANEXO_16_PACASMAYO });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 MINSUR SAN RAFAEL", v_ComponentId = Constants.INFORME_ANEXO_16_MINSURSANRAFAEL });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 Shahuindo", v_ComponentId = Constants.INFORME_ANEXO_16_SHAHUINDO });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 16 Gold Field", v_ComponentId = Constants.INFORME_ANEXO_16_GOLD_FIELD });
                serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANTECEDENTE PATOLOGICO", v_ComponentId = Constants.INFORME_ANTECEDENTE_PATOLOGICO });
                serviceComponents.Add(new ServiceComponentList { Orden = 48, v_ComponentName = "DECLARACION CI", v_ComponentId = Constants.INFORME_DECLARACION_CI });
                serviceComponents.Add(new ServiceComponentList { Orden = 51, v_ComponentName = "INFORME ESPIROMETRIA", v_ComponentId = Constants.INFORME_ESPIROMETRIA });
                serviceComponents.Add(new ServiceComponentList { Orden = 52, v_ComponentName = "APTITUD YANACOCHA", v_ComponentId = Constants.APTITUD_YANACOCHA });
                serviceComponents.Add(new ServiceComponentList { Orden = 53, v_ComponentName = "INFORME MEDICO OCUPACIONAL COSAPI", v_ComponentId = Constants.INFORME_MEDICO_OCUPACIONAL_COSAPI });
                serviceComponents.Add(new ServiceComponentList { Orden = 54, v_ComponentName = "CERTIFICADO DE APTITUD MEDICO OCUPACIONAL COSAPI", v_ComponentId = Constants.CERTIFICADO_APTITUD_MEDICO });
                serviceComponents.Add(new ServiceComponentList { Orden = 72, v_ComponentName = "INFORME MEDICO SALUD OCUPACIONAL - EXAMEN ANUAL", v_ComponentId = Constants.INFORME_MEDICO_SALUD_OCUPACIONAL_EXAMEN_MEDICO_ANUAL });
                serviceComponents.Add(new ServiceComponentList { Orden = 73, v_ComponentName = "ANEXO 8 INFORME MEDICO OCUPASIONAL", v_ComponentId = Constants.ANEXO_8_INFORME_MEDICO_OCUPACIONAL });
                serviceComponents.Add(new ServiceComponentList { Orden = 74, v_ComponentName = "INFORME RESULTADOS EVALUACION MEDICA - AUTORIZACION", v_ComponentId = Constants.INFORME_RESULTADOS_EVALUACION_MEDICA });
                serviceComponents.Add(new ServiceComponentList { Orden = 75, v_ComponentName = "AGLUTINACIONES KOH SECRECION CIELO AZUL", v_ComponentId = Constants.AGLUTINACIONES_KOH_SECRECION });
                serviceComponents.Add(new ServiceComponentList { Orden = 76, v_ComponentName = "PARASITOLOGICO COPROCULTIVO CIELO AZUL", v_ComponentId = Constants.PARASITOLOGICO_COPROCULTIVO_CIELO_AZUL });
                serviceComponents.Add(new ServiceComponentList { Orden = 77, v_ComponentName = "MARCOBRE PASE MÉDICO", v_ComponentId = Constants.MARCOBRE_PASE_MEDICO });
                serviceComponents.Add(new ServiceComponentList { Orden = 77, v_ComponentName = "DECLARACIÓN JURADA", v_ComponentId = Constants.DECLARACION_JURADA });
                serviceComponents.Add(new ServiceComponentList { Orden = 82, v_ComponentName = "REGISTRO ENTREGA INFORME RESULTADOS EMO BUENAVENTURA", v_ComponentId = Constants.REGISTRO_ENTREGA_INFORME_RESULTADOS_BUENAVENTURA });

                serviceComponents.Add(new ServiceComponentList { Orden = 78, v_ComponentName = "ENTREGA DE EXAMEN MEDICO OCUPACIONAL", v_ComponentId = Constants.ENTREGA_DE_XAMEN_MEDICO_OCUPACIONAL });

                serviceComponents.Add(new ServiceComponentList { Orden = 79, v_ComponentName = "EV. MED. SAN MARTIN - INFORME RESULTADOS", v_ComponentId = Constants.EVALUACION_MEDICO_SAN_MARTIN_INFORME });

                serviceComponents.Add(new ServiceComponentList { Orden = 80, v_ComponentName = "DECLARACION JURADA EMPO YANACOCHA", v_ComponentId = Constants.Declaracion_Jurada_EMPO_YANACOCHA });
                serviceComponents.Add(new ServiceComponentList { Orden = 81, v_ComponentName = "DECLARACION JURADA EMO SECURITAS", v_ComponentId = Constants.Declaracion_Jurada_EMO_SECURITAS });
                //serviceComponents.Add(new ServiceComponentList { Orden = 61, v_ComponentName = "ANSIEDAD DE ZUNG", v_ComponentId = Constants.ANSIEDAD_ZUNG });
                //serviceComponents.Add(new ServiceComponentList { Orden = 61, v_ComponentName = "INTENSIDAD DE FATIGA", v_ComponentId = Constants.ESCALA_FATIGA });
                //serviceComponents.Add(new ServiceComponentList { Orden = 61, v_ComponentName = "INVENTARIO DE BURNOUT DE MASLACH", v_ComponentId = Constants.INV_MASLACH });
                //serviceComponents.Add(new ServiceComponentList { Orden = 61, v_ComponentName = "TEST SOMNOLENCIA", v_ComponentId = Constants.TEST_SOMNOLENCIA });

                //public const string INFORME_RESULTADOS_EVALUACION_MEDICA = "INFRES-EVALUACION-MED-AUT";
                if (datosP.Genero.ToUpper() == "FEMENINO")
                {
                    serviceComponents.Add(new ServiceComponentList { Orden = 62, v_ComponentName = "DECLARACION JURADA - RX - MUJERES", v_ComponentId = Constants.DECLARACION_JURADA_EMBARAZADAS_RX });
                }
                #region HUDBAY
                serviceComponents.Add(new ServiceComponentList { Orden = 65, v_ComponentName = "CONSENTIMIENTO INFORMADO ACCESO HISTORIA CLÍNICA", v_ComponentId = Constants.CONSENTIMIENTO_INFORMADO_HUDBAY });
                serviceComponents.Add(new ServiceComponentList { Orden = 66, v_ComponentName = "INF MÉD DE APTITUD OCUPACIONAL PARA LA EMPRESA", v_ComponentId = Constants.INFORME_MEDICO_APTITUD_OCUPACIONAL_EMPRESA_HUDBAY });
                #endregion
                var ResultadoAnexo312 = serviceComponents.FindAll(p => InformeAnexo3121.Contains(p.v_ComponentId)).ToList();
                if (ResultadoAnexo312.Count() != 0)
                {
                    serviceComponents.Add(new ServiceComponentList { Orden = 5, v_ComponentName = "ANEXO 312", v_ComponentId = Constants.INFORME_ANEXO_312 });
                }
                var ResultadoFisico7C = serviceComponents.FindAll(p => InformeFisico7C1.Contains(p.v_ComponentId)).ToList();
                if (ResultadoFisico7C.Count() != 0)
                {
                    serviceComponents.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 7C", v_ComponentId = Constants.INFORME_ANEXO_7C });

                }
                serviceComponents.Add(new ServiceComponentList { Orden = 7, v_ComponentName = "HISTORIA OCUPACIONAL", v_ComponentId = Constants.INFORME_HISTORIA_OCUPACIONAL });
            }

            foreach (var item in serviceComponents)
            {


                if (item.v_ComponentId == Constants.ALTURA_7D_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 8;
                }
                else if (item.v_ComponentId == Constants.EVA_ERGONOMICA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 9;
                }
                if (item.v_ComponentId == Constants.OSTEO_MUSCULAR_ID_1)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 10;
                }
                else if (item.v_ComponentId == Constants.ALTURA_ESTRUCTURAL_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 11;
                }
                else if (item.v_ComponentId == Constants.TEST_VERTIGO_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 12;
                }
                else if (item.v_ComponentId == Constants.EVA_NEUROLOGICA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 13;
                }
                else if (item.v_ComponentId == Constants.SINTOMATICO_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 14;
                }
                else if (item.v_ComponentId == Constants.TAMIZAJE_DERMATOLOGIO_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 15;
                }
                else if (item.v_ComponentId == Constants.TESTOJOSECO_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 16;
                }
                else if (item.v_ComponentId == Constants.OFTALMOLOGIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 17;
                }
                else if (item.v_ComponentId == Constants.RX_TORAX_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 18;
                }
                else if (item.v_ComponentId == Constants.OIT_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 19;
                }
                else if (item.v_ComponentId == Constants.LUMBOSACRA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 20;
                }
                else if (item.v_ComponentId == Constants.ACUMETRIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 21;
                }
                else if (item.v_ComponentId == Constants.OTOSCOPIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 22;
                }
                else if (item.v_ComponentId == Constants.AUDIOMETRIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 23;
                }
                else if (item.v_ComponentId == Constants.ODONTOGRAMA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 24;
                }
                else if (item.v_ComponentId == Constants.ESPIROMETRIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 25;
                }
                else if (item.v_ComponentId == Constants.ELECTROCARDIOGRAMA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 26;
                }

                else if (item.v_ComponentId == Constants.HISTORIA_CLINICA_PSICOLOGICA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 28;
                }
                else if (item.v_ComponentId == Constants.PSICOLOGIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 29;
                }
                else if (item.v_ComponentId == Constants.EVALUACION_PSICOLABORAL)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 30;
                }
                else if (item.v_ComponentId == Constants.SOMNOLENCIA_ID)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 31;
                }
                else if (item.v_ComponentId == Constants.FICHA_OTOSCOPIA)
                {
                    var ent = serviceComponents.FirstOrDefault(o => o.v_ComponentId == item.v_ComponentId);
                    ent.Orden = 32;
                }



            }

            #region Consolidado de Reportes
            string[] ConsolidadoReportesForPrint = new string[] 
            {
                Constants.ALTURA_ESTRUCTURAL_ID,
                Constants.ALTURA_7D_ID,
                Constants.CUESTIONARIO_ACTIVIDAD_FISICA,
                Constants.OSTEO_MUSCULAR_ID_1,                
                Constants.ESPIROMETRIA_ID,     
                Constants.AUDIOMETRIA_ID,  
                Constants.OFTALMOLOGIA_ID,
                Constants.TESTOJOSECO_ID, 
                Constants.ELECTROCARDIOGRAMA_ID,
                Constants.EVA_CARDIOLOGICA_ID,
                Constants.EVA_NEUROLOGICA_ID,
                Constants.OSTEO_MUSCULAR_ID_2,
                Constants.EVA_OSTEO_ID,
                Constants.HISTORIA_CLINICA_PSICOLOGICA_ID,
                Constants.EVALUACION_PSICOLABORAL,
                Constants.ECOGRAFIA_ABDOMINAL_ID,
                Constants.INFORME_ECOGRAFICO_PROSTATA_ID,
                Constants.ECOGRAFIA_RENAL_ID,
                Constants.OIT_ID,
                Constants.RX_TORAX_ID,
                Constants.ODONTOGRAMA_ID,
                Constants.TAMIZAJE_DERMATOLOGIO_ID,
                //Constants.PRUEBA_ESFUERZO_ID,
                Constants.PSICOLOGIA_ID,
                Constants.GINECOLOGIA_ID,
                Constants.C_N_ID,
                Constants.TEST_VERTIGO_ID,
                Constants.EVA_ERGONOMICA_ID,
                Constants.SOMNOLENCIA_ID,
                Constants.ACUMETRIA_ID,
                Constants.OTOSCOPIA_ID,
                Constants.SINTOMATICO_ID,
                Constants.LUMBOSACRA_ID,
                //Constants.SINTOMATICO_RESPIRATORIO
            };


            string[] ExamenBioquimica1 = new string[] 
            { 
                Constants.GLUCOSA_ID,
                Constants.COLESTEROL_ID,
                Constants.TRIGLICERIDOS_ID,
                Constants.COLESTEROL_HDL_ID,
                Constants.COLESTEROL_LDL_ID,
                Constants.COLESTEROL_VLDL_ID,
                Constants.UREA_ID,
                Constants.CREATININA_ID,
                Constants.TGO_ID,
                Constants.TGP_ID,
                Constants.TEST_ESTEREOPSIS_ID,
                Constants.ANTIGENO_PROSTATICO_ID,
                Constants.PLOMO_SANGRE_ID,
                Constants.BIOQUIMICA01_ID,
                Constants.BIOQUIMICA02_ID,
                Constants.BIOQUIMICA03_ID
            };

            string[] ExamenEspeciales1 = new string[] 
            { 
                Constants.BK_DIRECTO_ID,
                Constants.EXAMEN_ELISA_ID,
                Constants.HEPATITIS_A_ID,
                Constants.HEPATITIS_C_ID,
                Constants.SUB_UNIDAD_BETA_CUALITATIVO_ID,
                Constants.VDRL_ID,
            };









            //Colocar en la lista

            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 1, v_ComponentName = "CONSENTIMIENTO INFORMADO ", v_ComponentId = Constants.CONSENTIMIENTO_INFORMADO });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD SIN Diagnósticos ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_SIN_DX });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD EMPRESARIAL ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_EMPRESARIAL });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 2, v_ComponentName = "CERTIFICADO APTITUD", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 3, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 1", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 4, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 2", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR_2 });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 27, v_ComponentName = "INFORME DE LABORATORIO", v_ComponentId = Constants.INFORME_LABORATORIO_CLINICO });
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 27, v_ComponentName = "AUDIOMETRIA AUDIOMAX", v_ComponentId = Constants.AUDIOMETRIA_AUDIOMAX_ID });
            serviceComponents.Add(new ServiceComponentList { Orden = 50, v_ComponentName = "INFORME DE TRABAJADOR INTERNACIONAL", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR_CI });

            //QUERY
            var serviceComponents11 = _serviceBL.GetServiceComponentsForManagementReport(_serviceId);
            var ResultadoAnexo3121 = serviceComponents11.FindAll(p => InformeAnexo3121.Contains(p.v_ComponentId)).ToList();
            if (ResultadoAnexo3121.Count() != 0)
            {
                ConsolidadoReportes.Add(new ServiceComponentList { Orden = 5, v_ComponentName = "ANEXO 312", v_ComponentId = Constants.INFORME_ANEXO_312 });
            }
            var ResultadoFisico7C1 = serviceComponents11.FindAll(p => InformeFisico7C1.Contains(p.v_ComponentId)).ToList();
            if (ResultadoFisico7C1.Count() != 0)
            {
                ConsolidadoReportes.Add(new ServiceComponentList { Orden = 6, v_ComponentName = "ANEXO 7C", v_ComponentId = Constants.INFORME_ANEXO_7C });
            }
            ConsolidadoReportes.Add(new ServiceComponentList { Orden = 7, v_ComponentName = "HISTORIA OCUPACIONAL", v_ComponentId = Constants.INFORME_HISTORIA_OCUPACIONAL });

            //var ResultadoBioquimico1 = serviceComponents11.FindAll(p => ExamenBioquimica1.Contains(p.v_ComponentId)).ToList();
            //if (ResultadoBioquimico1.Count() != 0)
            //{

            //}

            //ConsolidadoReportes.Add(new ServiceComponentList { Orden = 29, v_ComponentName = "OSTEO MUSCULAR NUEVO", v_ComponentId = Constants.OSTEO_MUSCULAR_ID_1 });












            ConsolidadoReportes.AddRange(serviceComponents.FindAll(p => ConsolidadoReportesForPrint.Contains(p.v_ComponentId)));







            //ConsolidadoReportes.Insert(1, new ServiceComponentList { v_ComponentName = "Ficha Examen Clínico", v_ComponentId = Constants.INFORME_CLINICO });    

            //ConsolidadoReportes.Add(new ServiceComponentList { v_ComponentName = "CERTIFICADO DE APTITUD COMPLETO", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO });




            //var ResultadoExaEspeciales1 = serviceComponents11.FindAll(p => ExamenEspeciales1.Contains(p.v_ComponentId)).ToList();
            //if (ResultadoExaEspeciales1.Count() != 0)
            //{
            //    ConsolidadoReportes.Add(new ServiceComponentList { v_ComponentName = "EXAMENES ESPECIALES", v_ComponentId = Constants.INFORME_EXAMENES_ESPECIALES });
            //}

            ListaOrdenada = ConsolidadoReportes.OrderBy(p => p.Orden).ToList();



            //Verificar si tiene orden de resportes
            OrganizationBL oOrganizationBL = new OrganizationBL();
            OperationResult objOperationResult = new OperationResult();
            List<ServiceComponentList> ListaFinalOrdena = new List<ServiceComponentList>();
            var ListaOrdenReportes = oOrganizationBL.GetOrdenReportes(ref objOperationResult, _EmpresaClienteId);

            #region lógica de exoneración
            //QUERY
            var serviceComponenteStatusRx = _serviceBL.ServiceComponentStatusByCategoria(6, _serviceId);
            var serviceComponenteStatusLab = _serviceBL.ServiceComponentStatusByCategoria(1, _serviceId);
            var serviceComponenteStatusEsp = _serviceBL.ServiceComponentStatusByCategoria(16, _serviceId);
            var datosPac = _pacientBL.DevolverDatosPaciente(_serviceId);
            var serviceComponenteEstado = _serviceBL.GetServiceComponentsReport(_serviceId);
            
            if (ListaOrdenReportes.Count > 0)
            {
                ListaOrdenada = new List<ServiceComponentList>();
                ServiceComponentList oServiceComponentList = null;

                if (serviceComponenteStatusRx == 7)
                {
                    if (datosPac.Genero == "FEMENINO")
                    {
                        ServiceComponentList mujeres = serviceComponenteEstado.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.EXCEPCIONES_RX_AUTORIZACION_ID);

                        var si = mujeres.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_AUTORIZACION_SI) == null ? "" : mujeres.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_AUTORIZACION_SI).v_Value1;
                        var no = mujeres.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_AUTORIZACION_NO) == null ? "" : mujeres.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_AUTORIZACION_NO).v_Value1;

                        if (si == "1")
                        {
                            ListaOrdenReportes = ListaOrdenReportes.FindAll(
                         p =>
                             p.v_ComponenteId != "N009-ME000000302"
                             && p.v_ComponenteId != "N009-ME000000440");
                        }
                        else if (no == "1")
                        {
                            ListaOrdenReportes = ListaOrdenReportes.FindAll(
                        p =>
                            p.v_ComponenteId != "N002-ME000000032" && p.v_ComponenteId != "N009-ME000000062" &&
                            p.v_ComponenteId != "N009-ME000000130" && p.v_ComponenteId != "N009-ME000000302");
                        }

                    }
                    else
                    {
                        ServiceComponentList exoneracion = serviceComponenteEstado.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.EXCEPCIONES_RX_ID);

                        var si = exoneracion.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_EXO_SI) == null ? "" : exoneracion.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_EXO_SI).v_Value1;
                        var no = exoneracion.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_EXO_NO) == null ? "" : exoneracion.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_RX_EXO_NO).v_Value1;
                        if (si == "1")
                        {
                            ListaOrdenReportes = ListaOrdenReportes.FindAll(
                         p =>
                             p.v_ComponenteId != "N002-ME000000032" && p.v_ComponenteId != "N009-ME000000062" &&
                             p.v_ComponenteId != "N009-ME000000130" && p.v_ComponenteId != "N009-ME000000302"
                             && p.v_ComponenteId != "N009-ME000000442");
                        }
                        else
                        {
                            ListaOrdenReportes = ListaOrdenReportes.FindAll(
                                p =>
                                    p.v_ComponenteId != "N009-ME000000440" && p.v_ComponenteId != "N009-ME000000442");
                        }

                    }
                }
                else
                {
                    ListaOrdenReportes = ListaOrdenReportes.FindAll(
                       p =>
                           p.v_ComponenteId != "N009-ME000000440" && p.v_ComponenteId != "N009-ME000000442");
                }


                if (serviceComponenteStatusLab == 7)
                {
                    ServiceComponentList lab = serviceComponenteEstado.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.EXCEPCIONES_LABORATORIO_ID);

                    var si_lab = lab.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_LABORATORIO_EXO_SI) == null ? "" : lab.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_LABORATORIO_EXO_SI).v_Value1;
                    var no_lab = lab.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_LABORATORIO_EXO_NO) == null ? "" : lab.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_LABORATORIO_EXO_NO).v_Value1;

                    if (si_lab == "1")
                    {
                        ListaOrdenReportes = ListaOrdenReportes.FindAll(
                     p =>
                         p.v_ComponenteId != "N001-ME000000000" && p.v_ComponenteId != "N009-ME000000461" && p.v_ComponenteId != "N009-ME000000053");
                    }
                    else
                    {
                        ListaOrdenReportes = ListaOrdenReportes.FindAll(
                            p =>
                                p.v_ComponenteId != "N009-ME000000441");
                    }
                }
                else
                {
                    ListaOrdenReportes = ListaOrdenReportes.FindAll(
                       p =>
                           p.v_ComponenteId != "N009-ME000000441");
                }

                if (serviceComponenteStatusEsp == 7)
                {
                    ServiceComponentList esp = serviceComponenteEstado.Find(p => p.v_ComponentId == Sigesoft.Common.Constants.EXCEPCIONES_ESPIROMETRIA_ID);

                    var si_esp = esp.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_ESPIROMETRIA_SI) == null ? "" : esp.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_ESPIROMETRIA_SI).v_Value1;
                    var no_esp = esp.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_ESPIROMETRIA_NO) == null ? "" : esp.ServiceComponentFields.Find(p => p.v_ComponentFieldsId == Sigesoft.Common.Constants.EXCEPCIONES_ESPIROMETRIA_NO).v_Value1;

                    if (si_esp == "1")
                    {
                        ListaOrdenReportes = ListaOrdenReportes.FindAll(
                     p =>
                         p.v_ComponenteId != "N002-ME000000031");
                    }
                    else
                    {
                        ListaOrdenReportes = ListaOrdenReportes.FindAll(
                            p =>
                                p.v_ComponenteId != "N009-ME000000513");
                    }
                }
                else
                {
                    ListaOrdenReportes = ListaOrdenReportes.FindAll(
                       p =>
                           p.v_ComponenteId != "N009-ME000000513");
                }

            #endregion
           

                foreach (var item in ListaOrdenReportes)
                {
                 
                    oServiceComponentList = new ServiceComponentList();
                    oServiceComponentList.v_ComponentName = item.v_NombreReporte;
                    oServiceComponentList.v_ComponentId = item.v_ComponenteId + "|" + item.i_NombreCrystalId;
                    ListaOrdenada.Add(oServiceComponentList);
                }


                foreach (var item in ListaOrdenada)
                {
                    //var ComponenteId = "";


                    var array = item.v_ComponentId.Split('|');
                    //if (item.v_ComponentId.Length > 16)
                    //{
                    //    ComponenteId = item.v_ComponentId.Substring(0, 16);
                    //}
                    //else
                    //{
                    //    ComponenteId = item.v_ComponentId;
                    //}
                    foreach (var item1 in serviceComponents)
                    {
                        if (array[0].ToString() == item1.v_ComponentId)
                        {
                            ListaFinalOrdena.Add(item);
                        }
                    }
                }

                chklConsolidadoReportes.DataSource = ListaFinalOrdena;
                chklConsolidadoReportes.DisplayMember = "v_ComponentName";
                chklConsolidadoReportes.ValueMember = "v_ComponentId";
            }
            else
            {
                chklConsolidadoReportes.DataSource = ListaOrdenada;
                chklConsolidadoReportes.DisplayMember = "v_ComponentName";
                chklConsolidadoReportes.ValueMember = "v_ComponentId";
            }




            #endregion

            #region Examen For Print






            string[] examenForPrint = new string[] 
            { 
                Constants.ALTURA_ESTRUCTURAL_ID,
                Constants.ALTURA_7D_ID,
                Constants.ODONTOGRAMA_ID,
                Constants.OSTEO_MUSCULAR_ID_1,
                Constants.OSTEO_MUSCULAR_ID_2,
                Constants.OFTALMOLOGIA_ID,
                Constants.RX_TORAX_ID,
                Constants.OIT_ID,
                Constants.PRUEBA_ESFUERZO_ID,
                Constants.ELECTROCARDIOGRAMA_ID,
                Constants.TAMIZAJE_DERMATOLOGIO_ID,
                Constants.PSICOLOGIA_ID,
                Constants.AUDIOMETRIA_ID,              
                Constants.ESPIROMETRIA_ID,           
                Constants.GINECOLOGIA_ID,
                Constants.EVALUACION_PSICOLABORAL,
                Constants.TESTOJOSECO_ID,                 
                Constants.C_N_ID,
                Constants.CUESTIONARIO_ACTIVIDAD_FISICA,
                Constants.INFORME_ECOGRAFICO_PROSTATA_ID,
                Constants.ECOGRAFIA_ABDOMINAL_ID,
                Constants.ECOGRAFIA_RENAL_ID,
                Constants.TEST_VERTIGO_ID,
                Constants.EVA_CARDIOLOGICA_ID,
                Constants.EVA_OSTEO_ID,
                Constants.HISTORIA_CLINICA_PSICOLOGICA_ID,
                 Constants.EVA_NEUROLOGICA_ID,
                 Constants.EVA_ERGONOMICA_ID

                //Constants.ESPIROMETRIA_CUESTIONARIO_ID
                //Constants.TOXICOLOGICO_COLINESTERASA,
                //Constants.TOXICOLOGICO_CARBOXIHEMOGLOBINA,
                //Constants.TOXICOLOGICO_BENZODIAZEPINAS,
                //Constants.TOXICOLOGICO_ALCOHOLEMIA,
                //Constants.TOXICOLOGICO_ANFETAMINAS
                    //Constants.LABORATORIO_ID,
                  //Constants.ESPIROMETRIA_CUESTIONARIO_ID,
                //Constants.EXAMEN_COMPLETO_DE_ORINA_ID ,
                //Constants.HEMOGRAMA_COMPLETO_ID ,
                //Constants.PARASITOLOGICO_SIMPLE_ID, //Parasito Simple
                //Constants.PARASITOLOGICO_SERIADO_ID ,
                //Constants.TOXICOLOGICO_COCAINA_MARIHUANA_ID,
                //Constants.AGLUTINACIONES_LAMINA_ID, //Antigenos febriles
            };

            #endregion

            // Cargar ListBox de examenes
            _listaDosaje = serviceComponents;
            serviceComponents = serviceComponents.FindAll(p => examenForPrint.Contains(p.v_ComponentId));

            serviceComponents.Insert(0, new ServiceComponentList { v_ComponentName = "Certificado de Aptitud", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD });
            serviceComponents.Insert(1, new ServiceComponentList { v_ComponentName = "Historia Ocupacional", v_ComponentId = Constants.INFORME_HISTORIA_OCUPACIONAL });

            // Si la prueba de RX esta entonces tambien insertar <Informe Radiografico OIT>
            var findRX = serviceComponents.Find(p => p.v_ComponentId == Constants.RX_TORAX_ID);
            //var findEspiro = serviceComponents.Find(p => p.v_ComponentId == Constants.ESPIROMETRIA_ID);

            //if (findRX != null)
            //{
            //    var newPosition = serviceComponents.IndexOf(findRX) + 1;
            //    serviceComponents.Insert(newPosition, new ServiceComponentList { v_ComponentName = "Informe Radiografico OIT", v_ComponentId = Constants.OIT_ID });
            //}

            //if (findEspiro != null)
            //{
            //    var newPosition = serviceComponents.IndexOf(findEspiro) + 1;
            //    serviceComponents.Insert(newPosition, new ServiceComponentList { v_ComponentName = "Cuestionario de Espirometria", v_ComponentId = Constants.ESPIROMETRIA_CUESTIONARIO_ID });
            //}

            chklExamenes.DataSource = serviceComponents;
            chklExamenes.DisplayMember = "v_ComponentName";
            chklExamenes.ValueMember = "v_ComponentId";

            // Cargar ListBox de Fichas            
            List<ServiceComponentList> fichasMedicas = new List<ServiceComponentList>();

            //QUERY
            var serviceComponents1 = _serviceBL.GetServiceComponentsForManagementReport(_serviceId);
            string[] ExamenBioquimica = new string[] 
            { 
                Constants.GLUCOSA_ID,
                Constants.COLESTEROL_ID,
                Constants.TRIGLICERIDOS_ID,
                Constants.COLESTEROL_HDL_ID,
                Constants.COLESTEROL_LDL_ID,
                Constants.COLESTEROL_VLDL_ID,
                Constants.UREA_ID,
                Constants.CREATININA_ID,
                Constants.TGO_ID,
                Constants.TGP_ID,
                Constants.TEST_ESTEREOPSIS_ID,
                Constants.ANTIGENO_PROSTATICO_ID,
                Constants.PLOMO_SANGRE_ID,
                Constants.BIOQUIMICA01_ID,
                Constants.BIOQUIMICA02_ID,
                Constants.BIOQUIMICA03_ID
            };

            string[] ExamenEspeciales = new string[] 
            { 
                Constants.BK_DIRECTO_ID,
                Constants.EXAMEN_ELISA_ID,
                Constants.HEPATITIS_A_ID,
                Constants.HEPATITIS_C_ID,
                Constants.SUB_UNIDAD_BETA_CUALITATIVO_ID,
                Constants.VDRL_ID,
            };

            string[] InformeAnexo312 = new string[] 
            { 
                Constants.EXAMEN_FISICO_ID
               
            };

            string[] InformeFisico7C = new string[] 
            { 
                Constants.EXAMEN_FISICO_7C_ID
               
            };

            //Buscar Examenes segùn protocolo

            // Cargar ListBox de examenes

            if (_flagPantalla == (int)Sigesoft.Common.MasterService.AtxMedica)
            {
                //Historia Clínica
                fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Historia Clínica", v_ComponentId = Constants.HISTORIA_CLINICA });
                fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Atención Integral", v_ComponentId = Constants.ATENCION_INTEGRAL });
            }
            else
            {
                fichasMedicas.Insert(0, new ServiceComponentList { v_ComponentName = "Ficha Médica del trabajador", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR });
                //serviceComponents.Add(new ServiceComponentList { Orden = 4, v_ComponentName = "FICHA MÉDICA DEL TRABAJADOR 3", v_ComponentId = Constants.INFORME_FICHA_MEDICA_TRABAJADOR_3 });
                //fichasMedicas.Insert(1, new ServiceComponentList { v_ComponentName = "Ficha Examen Clínico", v_ComponentId = Constants.INFORME_CLINICO });    
                fichasMedicas.Insert(1, new ServiceComponentList { v_ComponentName = "Informe Médico Resumen", v_ComponentId = Constants.INFORME_MEDICO_RESUMEN });
                fichasMedicas.Insert(1, new ServiceComponentList { v_ComponentName = "Certificado de Aptitud Completo", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO });
                fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Anexo 16 Coimolache", v_ComponentId = Constants.INFORME_ANEXO_7C });
                var ResultadoBioquimico = serviceComponents1.FindAll(p => ExamenBioquimica.Contains(p.v_ComponentId)).ToList();
                if (ResultadoBioquimico.Count() != 0)
                {
                    fichasMedicas.Insert(0, new ServiceComponentList { v_ComponentName = "Informe de Laboratorio", v_ComponentId = Constants.INFORME_LABORATORIO_CLINICO });
                }


                var ResultadoExaEspeciales = serviceComponents1.FindAll(p => ExamenEspeciales.Contains(p.v_ComponentId)).ToList();
                if (ResultadoExaEspeciales.Count() != 0)
                {
                    fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Examenes Especiales", v_ComponentId = Constants.INFORME_EXAMENES_ESPECIALES });
                }

                var ResultadoAnexo312 = serviceComponents1.FindAll(p => InformeAnexo312.Contains(p.v_ComponentId)).ToList();
                if (ResultadoAnexo312.Count() != 0)
                {
                    fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Anexo 312", v_ComponentId = Constants.INFORME_ANEXO_312 });
                }

                var ResultadoFisico7C = serviceComponents1.FindAll(p => InformeFisico7C.Contains(p.v_ComponentId)).ToList();
                if (ResultadoFisico7C.Count() != 0)
                {
                    fichasMedicas.Add(new ServiceComponentList { v_ComponentName = "Anexo 7C", v_ComponentId = Constants.INFORME_ANEXO_7C });

                }
            }

            chklFichasMedicas.DataSource = fichasMedicas;
            chklFichasMedicas.DisplayMember = "v_ComponentName";
            chklFichasMedicas.ValueMember = "v_ComponentId";


            List<ServiceComponentList> CertificadosMedicos = new List<ServiceComponentList>();
            CertificadosMedicos.Insert(0, new ServiceComponentList { v_ComponentName = "Certificado Aptidud Empresarial ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_EMPRESARIAL });
            CertificadosMedicos.Insert(1, new ServiceComponentList { v_ComponentName = "Certificado Aptidud SM ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_SM });
            //CertificadosMedicos.Insert(2, new ServiceComponentList { v_ComponentName = "Certificado Aptidud Completo ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO });
            CertificadosMedicos.Insert(2, new ServiceComponentList { v_ComponentName = "Certificado Aptidud Sin Diagnósticos ", v_ComponentId = Constants.INFORME_CERTIFICADO_APTITUD_SIN_DX });


            chkCertificados.DataSource = CertificadosMedicos;
            chkCertificados.DisplayMember = "v_ComponentName";
            chkCertificados.ValueMember = "v_ComponentId";

            // Marcar todos los cheks

            chklChekedAll(chklExamenes, true);
            chklChekedAll(chklFichasMedicas, true);
            chklChekedAll(chkCertificados, true);

            lblRecordCount1.Text = string.Format("Se encontraron {0} registros.", serviceComponents.Count());
            lblRecordCountFichaMedica.Text = string.Format("Se encontraron {0} registros.", fichasMedicas.Count());
            lblRecordCountCertificados.Text = string.Format("Se encontraron {0} registros.", CertificadosMedicos.Count());

            _tempSourcePath = Path.Combine(Application.StartupPath, "TempMerge");

            chklFichasMedicas.SelectedValueChanged += chklFichasMedicas_SelectedValueChanged;
            chkCertificados.SelectedValueChanged += chkCertificados_SelectedValueChanged;






        }

        private void chklChekedAll(CheckedListBox chkl, bool checkedState)
        {
            for (int i = 0; i < chkl.Items.Count; i++)
            {
                chkl.SetItemChecked(i, checkedState);
            }
        }

        private void rbTodosExamenes_CheckedChanged(object sender, EventArgs e)
        {
            chklChekedAll(chklExamenes, true);
            chklExamenes.Enabled = false;
            SelectChangeExamenes();
        }

        private void rbSeleccioneExamenes_CheckedChanged(object sender, EventArgs e)
        {
            chklExamenes.Enabled = true;
            chklChekedAll(chklExamenes, false);
            SelectChangeExamenes();
        }

        private void btnGenerarReporteExamenes_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var componentId = GetChekedItems(chklExamenes);
            var frm = new Reports.frmConsolidatedReports(_serviceId, componentId, _listaDosaje);
            frm.ShowDialog();
            this.Enabled = true;
        }

        // Alejandro
        private List<string> GetChekedItems(CheckedListBox chkl)
        {
            List<string> componentId = new List<string>();

            for (int i = 0; i < chkl.CheckedItems.Count; i++)
            {
                ServiceComponentList com = (ServiceComponentList)chkl.CheckedItems[i];
                componentId.Add(com.v_ComponentId);
            }

            return componentId.Count == 0 ? null : componentId;
        }

        private void rbTodosFichaMedica_CheckedChanged(object sender, EventArgs e)
        {
            chklChekedAll(chklFichasMedicas, true);
            chklFichasMedicas.Enabled = false;
            SelectChangeFichasMedicas();
        }

        private void rbSeleccioneFichaMedica_CheckedChanged(object sender, EventArgs e)
        {
            chklFichasMedicas.Enabled = true;
            chklChekedAll(chklFichasMedicas, false);
            SelectChangeFichasMedicas();
        }

        private void btnGenerarReporteFichasMedicas_Click(object sender, EventArgs e)
        {

            // Elegir la ruta para guardar el PDF combinado
            saveFileDialog1.FileName = string.Format("{0} Ficha Médica", _personFullName);
            saveFileDialog1.Filter = "Files (*.pdf;)|*.pdf;";

            // Merge PDFs only one document
            var informesSeleccionados = GetChekedItems(chklFichasMedicas);

            if (informesSeleccionados.Count == 1 && _filesNameToMerge.Count == 0)
            {
                var sfd = saveFileDialog1.ShowDialog();

                if (sfd == DialogResult.OK)
                {
                    using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    {
                        foreach (var item in informesSeleccionados)
                        {
                            GeneratePDFOnlyOne(item);
                        }

                        RunFile(saveFileDialog1.FileName);
                    }
                }

            }
            else
            {
                //_filesNameToMerge = new List<string>();

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    {
                        foreach (var item in informesSeleccionados)
                        {
                            GeneratePDF(item);
                        }

                        var x = _filesNameToMerge.OrderBy(y => y).ToList();
                        _mergeExPDF.FilesName = x;
                        _mergeExPDF.DestinationFile = saveFileDialog1.FileName;

                        _mergeExPDF.Execute();
                        _mergeExPDF.RunFile();
                    }
                }
            }

        }

        private void GeneratePDF(string componentId)
        {
            switch (componentId)
            {
                case Constants.INFORME_ANEXO_312:
                    GenerateAnexo312(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_312)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_FICHA_MEDICA_TRABAJADOR:
                    GenerateInformeMedicoTrabajador(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_FICHA_MEDICA_TRABAJADOR)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_FICHA_MEDICA_TRABAJADOR_3:
                    GenerateInformeMedicoTrabajador(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_FICHA_MEDICA_TRABAJADOR_3)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_ANEXO_7C:
                    GenerateAnexo7C(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_7C)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_ANEXO_16_COIMOLACHE:
                    GenerateAnexo16Coimolache(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_16_COIMOLACHE)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_ANEXO_16_YANACOCHA:
                    GenerateAnexo16Yanacocha(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_16_YANACOCHA)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_ANEXO_16_SHAHUINDO:
                    GenerateAnexo16Shahuindo(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_16_SHAHUINDO)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_ANEXO_16_GOLD_FIELD:
                    GenerateAnexo16GoldField(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_ANEXO_16_GOLD_FIELD)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;

                case Constants.INFORME_CLINICO:
                    GenerateInformeExamenClinico(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_CLINICO)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_LABORATORIO_CLINICO:
                    GenerateLaboratorioReport(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_LABORATORIO_CLINICO)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_EXAMENES_ESPECIALES:
                    GenerateExamenesEspecialesReport(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_EXAMENES_ESPECIALES)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_MEDICO_RESUMEN:
                    GenerateInformeMedicoResumen(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_MEDICO_RESUMEN)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO:
                    GenerateCertificadoAptitudCompleto(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(_tempSourcePath, componentId)));
                    break;
                case Constants.INFORME_FICHA_MEDICA_TRABAJADOR_CI:
                    GenerateInformeMedicoTrabajadorInternacional(string.Format("{0}.pdf", Path.Combine(ruta, _serviceId + "-" + Constants.INFORME_FICHA_MEDICA_TRABAJADOR_CI)), _serviceId, _pacientId);
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(ruta, _serviceId + "-" + componentId)));
                    break;
                default:
                    break;
            }
        }

        private void GenerateInformeMedicoTrabajadorInternacional(string pathFile, string ServicioId, string PacienteId)
        {
            PacientBL oPacientBL = new PacientBL();

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var Cabecera = oPacientBL.DevolverDatosPaciente(ServicioId);
            var AntOcupacionales = _historyBL.GetHistoryReport(_pacientId);
            //var HabitosNocivos = oPacientBL.DevolverHabitosNoscivos(PacienteId);
            var HabitosNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            //var AntFami = oPacientBL.DevolverAntecedentesFamiliares(PacienteId);
            var AntPersonales = oPacientBL.DevolverAntecedentesPersonales(PacienteId);
            //var AntOcupacionales = oPacientBL.DevolverAntecedentesOcupacionales(PacienteId);
            var Valores = _serviceBL.GetServiceComponentsReport_New(ServicioId);//_serviceBL.GetServiceComponentsReport(ServicioId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(ServicioId);
            var AntFami = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var Reco = _serviceBL.ConcatenateRecommendationByService(ServicioId);
            InformeMedicoTrabajadorInternacional.CreateInformeMedicoTrabajadorInternacional(pathFile, Cabecera, HabitosNocivos, AntFami, Valores, diagnosticRepository, AntPersonales, AntOcupacionales, MedicalCenter, Reco);
        }

        private void GeneratePDFOnlyOne(string componentId)
        {
            switch (componentId)
            {
                case Constants.INFORME_ANEXO_312:
                    GenerateAnexo312(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_FICHA_MEDICA_TRABAJADOR:
                    GenerateInformeMedicoTrabajador(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_ANEXO_7C:
                    GenerateAnexo7C(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_CLINICO:
                    GenerateInformeExamenClinico(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_LABORATORIO_CLINICO:
                    GenerateLaboratorioReport(saveFileDialog1.FileName);
                    break;

                case Constants.INFORME_EXAMENES_ESPECIALES:
                    GenerateExamenesEspecialesReport(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_MEDICO_RESUMEN:
                    GenerateInformeMedicoResumen(saveFileDialog1.FileName);
                    break;
                case Constants.INFORME_CERTIFICADO_APTITUD_COMPLETO:
                    GenerateCertificadoAptitudCompleto(saveFileDialog1.FileName);
                    break;

                case Constants.HISTORIA_CLINICA:
                    GenerateHistoriaClinica(saveFileDialog1.FileName);
                    break;
                //case Constants.INFORME_FICHA_MEDICA_TRABAJADOR_CI:
                //    GenerateInformeMedicoTrabajadorInternacional(saveFileDialog1.FileName);
                //    break;
                default:
                    break;
            }
        }

        private void GenerateAnexo312(string pathFile)
        {

            //Demoraba 15-16 seg
            var filiationData = _pacientBL.GetPacientReportEPS_312(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId); //
            var _listAtecedentesOcupacionales = _historyBL.GetHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);

            #region OLd
            //var Antropometria = _serviceBL.ValoresComponente(_serviceId, Constants.ANTROPOMETRIA_ID);
            //var FuncionesVitales = _serviceBL.ValoresComponente(_serviceId, Constants.FUNCIONES_VITALES_ID);
            //var ExamenFisico = _serviceBL.ValoresComponente(_serviceId, Constants.EXAMEN_FISICO_ID);
            //var Oftalmologia = _serviceBL.ValoresComponente(_serviceId, Constants.OFTALMOLOGIA_ID);


            //var Psicologia = _serviceBL.ValoresExamenComponete(_serviceId, Constants.PSICOLOGIA_ID, 195);
            //var OIT = _serviceBL.ValoresExamenComponete(_serviceId, Constants.OIT_ID, 211);
            //var RX = _serviceBL.ValoresExamenComponete(_serviceId, Constants.RX_TORAX_ID, 135);

            //var Laboratorio = new List<ServiceComponentFieldValuesList>();
            //if (CentroMEdico.v_IdentificationNumber == "20519254086")// se hizo para mavimedic (loco cambio el id de informe médico)
            //{
            //    Laboratorio = _serviceBL.ValoresComponente(_serviceId, "N001-ME000000000");
            //}
            //else
            //{
              //  Laboratorio = _serviceBL.ValoresComponente(_serviceId, Constants.INFORME_LABORATORIO_ID);
            //}

            //var Audiometria = _serviceBL.ValoresComponente(_serviceId, Constants.AUDIOMETRIA_ID);
            //var TestIhihara = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ISHIHARA_ID);
            //var TestEstereopsis = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ESTEREOPSIS_ID);
            //var Espirometria = _serviceBL.ValoresExamenComponete(_serviceId, Constants.ESPIROMETRIA_ID, 210);
            #endregion
            
            var CentroMEdico = _serviceBL.GetInfoMedicalCenter();

            
            var Audiometria = _serviceBL.GetDiagnosticForAudiometria(_serviceId, Constants.AUDIOMETRIA_ID);
            
            var _DiagnosticRepository = _serviceBL.GetServiceDisgnosticsReports(_serviceId);
            var _Recomendation = _serviceBL.GetServiceRecommendationByServiceId(_serviceId);

            var _ExamenesServicio = _serviceBL.GetServiceComponentsReport_New312(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//

            var ValoresDxLab = _serviceBL.ValoresComponenteAMC_(_serviceId, 1);
            var MedicalCenter = CentroMEdico;//_serviceBL.GetInfoMedicalCenter();
            
            var serviceComponents = _ExamenesServicio;//_serviceBL.GetServiceComponentsReport(_serviceId);//

            FichaMedicaOcupacional312.CreateFichaMedicalOcupacional312Report(_DataService,
                        filiationData, _listAtecedentesOcupacionales, _listaPatologicosFamiliares,
                        _listMedicoPersonales, _listaHabitoNocivos, 
                        //Antropometria, FuncionesVitales, ExamenFisico, Oftalmologia, Laboratorio,
                        Audiometria, //Psicologia, OIT, RX, Espirometria,
                        _DiagnosticRepository, _Recomendation, _ExamenesServicio, ValoresDxLab, MedicalCenter, //TestIhihara, TestEstereopsis,
                        serviceComponents, pathFile);
        }



        private void CreateFichaMedicaTrabajador2(string pathFile)
        {
            var filiationData = _pacientBL.GetPacientReportEPS_InfoMediTrab2(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var doctoPhisicalExam = _serviceBL.GetDoctoPhisicalExam(_serviceId);
            InformeTrabajador.CreateFichaMedicaTrabajador2(filiationData, doctoPhisicalExam, diagnosticRepository, MedicalCenter, pathFile);
        }

        private void GenerateInformeMedicoTrabajador(string pathFile)
        {
            var filiationData = _pacientBL.GetPacientReportEPS_InfoMediTrab(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var personMedicalHistory = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var noxiousHabit = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var familyMedicalAntecedent = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var anamnesis = _serviceBL.GetAnamnesisReport(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//

            ReportPDF.CreateMedicalReportForTheWorker(filiationData,
                                            personMedicalHistory,
                                            noxiousHabit,
                                            familyMedicalAntecedent,
                                            anamnesis,
                                            serviceComponents,
                                            diagnosticRepository,
                                            _customerOrganizationName,
                                            MedicalCenter,
                                            pathFile);


        }

        private void CreateFichaMedicaTrabajador3(string pathFile)
        {
            var filiationData = _pacientBL.GetPacientReportEPS_New(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport_TODOS(_serviceId);
            var doctoPhisicalExam = _serviceBL.GetDoctoPhisicalExam(_serviceId);
            var ComponetesConcatenados = _pacientBL.DevolverComponentesConcatenados(_serviceId);
            var ComponentesLaboratorioConcatenados = _pacientBL.DevolverComponentesLaboratorioConcatenados(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            InformeTrabajador3.CreateFichaMedicaTrabajador3(filiationData, doctoPhisicalExam, diagnosticRepository, MedicalCenter, ComponetesConcatenados, ComponentesLaboratorioConcatenados, serviceComponents, Restricciton, pathFile);
        }

        private void GenerateAnexo7C(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId); //_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo7C(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateAptitudYanacocha(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId); //_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAptitudYanacocha(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateAnsiedadZung(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Ansiedad(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();
            var _Valores = _serviceBL.ValoresComponente_ObservadoAMC(_serviceId, Constants.PSICOLOGIA_ID);
            InformeAnsiedadZung.CreateInformeAnsiedadZung(_DataService, MedicalCenter, _Valores,pathFile);
        }
        private void GenerateEscalafatiga(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Fatiga(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var _Valores = _serviceBL.ValoresComponente_ObservadoAMC(_serviceId, Constants.PSICOLOGIA_ID);
            Informeintensidadfatiga.CreateInformeintensidadfatiga(_DataService, MedicalCenter, _Valores, pathFile);
        }
        private void GenerateInventarioMaslach(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();
            var _Valores = _serviceBL.ValoresComponente_ObservadoAMC(_serviceId, Constants.PSICOLOGIA_ID);
            InformeMaslach.CreateInformeMaslach(_DataService, MedicalCenter, _Valores, pathFile);
        }
        private void GenerateTestSomnolencia(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Somno(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();
            var _Valores = _serviceBL.ValoresComponente_ObservadoAMC(_serviceId, Constants.PSICOLOGIA_ID);
            TestSomnolencia.CreateTestSomnolencia(_DataService, MedicalCenter, _Valores, pathFile);
        }
        private void GenerateAnexo16Coimolache(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId); //_serviceBL.GetServiceReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId); //_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16Coimolache(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateAnexo16Pacasmayo(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId); //_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16Pacasmayo(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }
        private void GenerateAnexo16MinsurSanRafael(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16MinsurSanRafael(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }
        private void GenerateAnexo16Yanacocha(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16Yanacocha(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateAnexo16Shahuindo(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16Shahuindo(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateAnexo16GoldField(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_PHOTO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _Valores = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _PiezasCaries = _serviceBL.GetCantidadCaries(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_CARIES_ID);
            var _PiezasAusentes = _serviceBL.GetCantidadAusentes(_serviceId, Constants.ODONTOGRAMA_ID, Constants.ODONTOGRAMA_PIEZAS_AUSENTES_ID);
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);
            var Pulmones = Common.Utils.BitmapToByteArray(Resources.MisPulmones);
            var Audiometria = _serviceBL.ValoresComponenteOdontogramaValue1(_serviceId, Constants.AUDIOMETRIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateAnexo16GoldField(_DataService, filiationData, _Valores, _listMedicoPersonales,
                                    _listaPatologicosFamiliares, _listaHabitoNocivos,
                                    CuadroVacio, CuadroCheck, Pulmones, _PiezasCaries,
                                    _PiezasAusentes, Audiometria, diagnosticRepository, MedicalCenter,
                                    pathFile);

        }

        private void GenerateInformeExamenClinico(string pathFile)
        {
            var filiationData = _pacientBL.GetPacientReportEPS_ExaCli(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);
            var personMedicalHistory = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var noxiousHabit = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var familyMedicalAntecedent = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var anamnesis = _serviceBL.GetAnamnesisReport(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var doctoPhisicalExam = _serviceBL.GetDoctoPhisicalExam(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            ReportPDF.CreateMedicalReportForExamenClinico(filiationData,
                                            personMedicalHistory,
                                            noxiousHabit,
                                            familyMedicalAntecedent,
                                            anamnesis,
                                            serviceComponents,
                                            diagnosticRepository,
                                            _customerOrganizationName,
                                            MedicalCenter,
                                            pathFile,
                                            doctoPhisicalExam);


        }

        private void GenerateLaboratorioReport(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_Lab(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewLab(_serviceId);
            //var serviceComponents = _serviceBL.GetServiceComponentsReport(_serviceId);
            //_serviceBL.GetServiceComponentsReport(_serviceId);//GetServiceComponentsReport_NewLab
            // usar para el logo cliente filiationData.LogoCliente
            LaboratorioReport.CreateLaboratorioReport(filiationData, serviceComponents, MedicalCenter, pathFile);
        }
        //ARNOLD
        private void GenerateMiExamen(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            //var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);

            MiExamen.CreateMiExamen(serviceComponents, MedicalCenter,datosP, pathFile);
        }

        private void GenerateInformeSAS(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_InfSAS(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_SAS(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var _DataService = _serviceBL.GetInformacion_FirmaMedicoMed(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//

            INFORME_SAS_REPORT.CreateReportSAS(filiationData, _DataService, serviceComponents, MedicalCenter, datosP, pathFile);
        }

        private void GenerateExamenOftalmologicoSimple(string pathFile)
        {
            //se demoraba 10 seg  //ahora 4seg
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftSimple(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_OftSimple(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var _DataService = _serviceBL.GetServiceReport_OftSimple(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);

            Examen_Oftalmologico_Simple.CreateExamen_Oftalmologico_Simple(filiationData, _DataService, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }
        private void GenerateExamenOftalmologicoCompleto(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_OftSimple(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Examen_Oftalmologico_Completo.CreateExamen_Oftalmologico_Completo(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }
        private void GenerateEvaluavionOftalmologicaYanacocha(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_OftSimple(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa//var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);
            var _ExamenesServicio = serviceComponents;
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            ApendiceN2_Evaluacion_Oftalmologica_Yanacocha.CreateApendiceN2_Evaluacion_Oftalmologica_Yanacocha(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, _ExamenesServicio, diagnosticRepository);
        }

        private void GenerateInformeOftalmologicoHudbay(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_HudBay(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_OftSimple(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = //_serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Informe_Oftalmologico_Hudbay.CreateInforme_Oftalmologico_Hudbay(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }

        public void GenerateFichaPsicologicaGoldfies(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_PsicoGoldfields(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Psicologia, _serviceId);
            FichaPsicologicaGoldfields.CreateFichaPsicologicaGoldfields(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }

        

        public void GenerateDeclaracionJuradaCoimolacheLaZanja(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo(); //_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_HudBay(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewLab(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_PsicoGoldfields(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//

            DeclaracionJuradaPsicologia_Coimolache_LaZanja.CreateDeclaracionJuradaCoimolacheLaZanja(filiationData, serviceComponents, MedicalCenter, datosP, pathFile);
        }
        public void GenerateInformePsicologicoGoldfieds(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_InfoGoldfields(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
             
            var _InformacionHistoriaPsico = _serviceBL.GetHistoriaClinicaPsicologica(_serviceId, Constants.FICHA_PSICOLOGICA_OCUPACIONAL_GOLDFIELDS);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Psicologia, _serviceId);

            InformePsicologicoGoldfields.CreateInformePsicologicoGoldfields(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }

        private void GenerateCertificadoPsicosensometricoDatos(string pathFile)
        {
            //var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_PsicosenDatos(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Psicosensometrico, _serviceId);

            Certificado_Psicosensometrico_Datos.CreateCertificadoPsicosensometricoDatos( filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }
        private void GenerateAltura_Fisica_F_Yanacocha(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            //No usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_FYanacocha(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            Altura_Fisica_F_Yanacocha.CreateAltura_Fisica_F_Yanacocha(_DataService, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }
        private void GenerateOsteMuscular_Mibanco(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_HudBay(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_MiBanco(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Osteomuscular_MiBanco.CreateOsteoMuscularMibanco( filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }
        private void GenerateAccidentesTrabajoF1(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            //No usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_MiBanco(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            AccidentesTrabajo_F1.CreateAccidentesTrabajoF1(serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }

        private void GenerateAccidentesTrabajoF2(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            
            //No se usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            //No usa var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            AccidentesTrabajo_F2.CreateAccidentesTrabajoF2 (serviceComponents, MedicalCenter, pathFile, datosGrabo);
        }

        private void GenerateExamenSuficienciaMedicaOperadores(string pathFile)
        {
            ///No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_SMO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);


            EXAMEN_SUF_MED_OPERADORES_EQUIPOS_MOVILES.CreateExamenSuficienciaMedicaOperadores(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }

        private void GenerateCertificadoSuficienciaMedicaTC(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_SMO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            CERTIFICADO_SUFICIENCIA_MEDICA_TC.CreateCertificadoSuficienciaTC(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo);
        }
        private void GenerateExoneraxionLaboratorio(string pathFile)
        {
            //demoraba 11 - 8 seg // ahora 4 - 2 seg
            //var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var exams = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_ExoLab(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftSimple(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Exoneracion_Laboratorio.CreateExoneracionLaboratorio(filiationData, pathFile, datosP, MedicalCenter, exams, diagnosticRepository);
        }

        private void GenerateExoneraxionPlacaTorax(string pathFile)
        {
            //var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var exams = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_ExoLab(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_312(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var serviceComponents = exams;
            Exoneracion_Placa_Torax_PA.CreateExoneracionPlacaTorax(filiationData, pathFile, datosP, MedicalCenter, exams, diagnosticRepository, serviceComponents);
        }

        private void GenerateExoneracionEspirometria(string pathFile)
        {
            //var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var exams = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_ExoLab(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_312(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var serviceComponents = exams;
            ExoneracionEspirometria.CreateExoneracionEspirometria(filiationData, pathFile, datosP, MedicalCenter, exams, diagnosticRepository, serviceComponents);
        }
        public void GenerateRegistroInformeEMOBuenaventura(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_EMOBu(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            Registro_Entrega_Informe_Resultados_EMO_BUENAVENTURA.CreateRegistroInformeEMOBuenaventura(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, datosGrabo);
        }

        private void GenerateDeclaracionJuradaRX(string pathFile)
        {
            //var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var exams = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_ExoLab(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var serviceComponents = exams;

            DeclaracionJuradaRX.CreateDeclaracionJurada(filiationData, pathFile, datosP, MedicalCenter, exams, diagnosticRepository, serviceComponents);
        }
        private void GenerateInformeResultadosAutorizacion(string pathFile)
        {
            //Se demoraba 6 - 4 seg //ahora 2-1 seg
            //No lo usa// var _DataService = _serviceBL.GetServiceReport(_serviceId);
            //No lo usa//var exams =  _serviceBL.GetServiceComponentsReport(_serviceId); //
            var datosP = _pacientBL.DevolverDatosPaciente_InfResulAutori(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_InfoResulAutori();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar_InfResulAutori(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//

            //No se usa //var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            //No se usa //var serviceComponents = _serviceBL.GetServiceComponentsReport(_serviceId); 

            InformedeResultados_Autorización.CreateInformeResultadosAutorizacion(filiationData, pathFile, datosP, MedicalCenter);
        }


        private void Generate_PARASITOLOGICO_COPROCULTIVO_CIELO_AZUL(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewLab(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_CieloAzul(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Coprocultivo_PSeriado.CreateExamen_PARASITOLOGICO_COPROCULTIVO_CIELO_AZUL(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }

        private void Generate_AGLUTINACIONES_KOH_SECRECION(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Oftalmología, _serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Coprocultivo_PSeriado.CreateExamen_AGLUTINACIONES_KOH_SECRECION(filiationData, serviceComponents, MedicalCenter, datosP, pathFile, datosGrabo, diagnosticRepository);
        }

        private void GenerateAnexo3_Exoneracion_ResponsabilidadYanacocha(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_ResYana(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_CieloAzul(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_InfMO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//

            Anexo3_Exo_Resp_Yanacocha.CreateAnexo3_Exoneracion_ResponsabilidadYanacocha(_DataService, pathFile, datosP, MedicalCenter,filiationData, serviceComponents);
        }
        private void GenerateDeclaracionJurada(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_ExoLab(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//

            DeclaracionJurada.CreateDeclaracionJurada(pathFile, datosP, MedicalCenter, filiationData, serviceComponents);
        }
        private void GenerateExamen_Medico_Visitantes_GoldFields(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_GoldField(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_VisiGoldfields(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
           Examen_Medico_Visitantes_GoldFields.CreateExamen_Medico_Visitantes_GoldFields(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents);
        }

        private void GenerateMarcobrePaseMedico(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_PaseMedico(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_PaseMedico(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Name();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            //No usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var habitosPersonales = new PacientBL().DevolverHabitos_PersonalesSolo(datosP.v_PersonId);

            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);

            Marcobre_Pase_Medico.CreateMarcobrePaseMedico(_DataService, pathFile, datosP, MedicalCenter, serviceComponents, diagnosticRepository, habitosPersonales);
        }
        private void GenerateTOXICOLOGICO_COCAINA_MARIHUANA_TODOS(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Cos(_serviceId);//_serviceBL.GetInformacion_Laboratorio(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_Toxi(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Laboratorio, _serviceId);
            TOXICOLOGICO_COCAINA_MARIHUANA_TODOS.CreateTOXICOLOGICO_COCAINA_MARIHUANA_TODOS(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, datosGrabo);
        }

        #region HUDBAY METODOS
        private void GenerateConsentimientoInformadoAccesoHistoriaClinica(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_HC(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            //No se usa var exams = _serviceBL.GetServiceComponentsReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_HistCli(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            //No se usa var MedicalCenter = _serviceBL.GetInfoMedicalCenter();

            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);

            ConsentimientoInformadoAccesoClinica.CreateConsentimientoInformadoAccesoHistoriClinica(_DataService, pathFile, datosP, diagnosticRepository, serviceComponents);
        }

        private void GenerateInformeMedicoAptitudOcupacional(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_HC(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var exams = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_MAO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Tra();//_serviceBL.GetInfoMedicalCenter();//

            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var serviceComponents = exams;

            InformeMedicoDeAptitudOcupacional_Empresa.CreateInformeMedicoAptitudOcupacionalEmpresa(_DataService, pathFile, datosP, MedicalCenter, exams, diagnosticRepository, serviceComponents);
        }
        #endregion

        private void GenerateInformeMedicoOcupacional_Cosapi(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Cos(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_InfMO(_serviceId);//_pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var RecoAudio = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.AUDIOMETRIA_ID);
            var RecoElectro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ELECTROCARDIOGRAMA_ID);
            var RecoEspiro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ESPIROMETRIA_ID);
            var RecoNeuro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EVAL_NEUROLOGICA_ID);
            var datosP = _pacientBL.DevolverDatosPaciente_Cosapi(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var RecoAltEst = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_ESTRUCTURAL_ID);
            var RecoActFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.CUESTIONARIO_ACTIVIDAD_FISICA);
            var RecoCustNor = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.C_N_ID);
            var RecoAlt7D = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_7D_ID);
            var RecoExaFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_ID);
            var RecoExaFis7C = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_7C_ID);
            var RecoOsteoMus1 = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OSTEO_MUSCULAR_ID_1);
            var RecoTamDer = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.TAMIZAJE_DERMATOLOGIO_ID);
            var RecoOdon = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ODONTOGRAMA_ID);
            var RecoPsico = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.PSICOLOGIA_ID);
            var RecoRx = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.RX_TORAX_ID);
            var RecoOit = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OIT_ID);
            var RecoOft = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OFTALMOLOGIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);


            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            var _listAtecedentesOcupacionales = _historyBL.GetHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);

            InformeMedicoOcupacional_Cosapi.CreateInformeMedicoOcupacional_Cosapi(_DataService,
                filiationData, diagnosticRepository, serviceComponents, MedicalCenter,
                datosP,
                pathFile,
                RecoAudio,
                RecoElectro,
                RecoEspiro,
                RecoNeuro, RecoAltEst, RecoActFis, RecoCustNor, RecoAlt7D, RecoExaFis, RecoExaFis7C, RecoOsteoMus1, RecoTamDer, RecoOdon,
                RecoPsico, RecoRx, RecoOit, RecoOft, Restricciton, Aptitud, _listAtecedentesOcupacionales, _listaPatologicosFamiliares, _listMedicoPersonales, _listaHabitoNocivos);
        }
        
        private void GenerateCertificadoAptitudMedicoOcupacional_Cosapi(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Cos2(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_InfMO(_serviceId);//_pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//

            var datosP = _pacientBL.DevolverDatosPaciente_Cosapi2(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);


            //var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);

            CertificadoAptitudMedico_Cosapi.CreateCertificadoMedicoOcupacional_Cosapi(_DataService,
                filiationData, diagnosticRepository, serviceComponents, MedicalCenter,
                datosP,
                pathFile);
        }

        private void GenerateInformeMedicoOcupacionalExamenMedicoAnual(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_OftCompl(_serviceId);//_pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewIMO(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var RecoAudio = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.AUDIOMETRIA_ID);
            var RecoElectro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ELECTROCARDIOGRAMA_ID);
            var RecoEspiro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ESPIROMETRIA_ID);
            var RecoNeuro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EVAL_NEUROLOGICA_ID);
            var datosP = _pacientBL.DevolverDatosPaciente_ExMedAnual(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var RecoAltEst = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_ESTRUCTURAL_ID);
            var RecoActFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.CUESTIONARIO_ACTIVIDAD_FISICA);
            var RecoCustNor = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.C_N_ID);
            var RecoAlt7D = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_7D_ID);
            var RecoExaFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_ID);
            var RecoExaFis7C = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_7C_ID);
            var RecoOsteoMus1 = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OSTEO_MUSCULAR_ID_1);
            var RecoTamDer = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.TAMIZAJE_DERMATOLOGIO_ID);
            var RecoOdon = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ODONTOGRAMA_ID);
            var RecoPsico = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.PSICOLOGIA_ID);
            var RecoRx = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.RX_TORAX_ID);
            var RecoOit = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OIT_ID);
            var RecoOft = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OFTALMOLOGIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);


            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            var _listAtecedentesOcupacionalesA = _historyBL.GetHistoryReportA(_pacientId);
            var _listAtecedentesOcupacionalesB = _historyBL.GetHistoryReportB(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var anamnesis = _serviceBL.GetAnamnesisReport(_serviceId);
            var exams = serviceComponents; //_serviceBL.GetServiceComponentsReport(_serviceId);
            var _ExamenesServicio = serviceComponents; //_serviceBL.GetServiceComponentsReport(_serviceId);
            var ExamenFisico = _serviceBL.ValoresComponente(_serviceId, Constants.EXAMEN_FISICO_ID);
            var Oftalmologia = _serviceBL.ValoresComponente(_serviceId, Constants.OFTALMOLOGIA_ID);
            var TestIhihara = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ISHIHARA_ID);
            var TestEstereopsis = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ESTEREOPSIS_ID);
            InformeMedicoSaludOcupacional_ExamenAnual.CreateInformeMedicoOcupacionalExamenMedicoAnual(_DataService,
                filiationData, diagnosticRepository, serviceComponents, MedicalCenter,
                datosP,
                pathFile,
                RecoAudio,
                RecoElectro,
                RecoEspiro,
                RecoNeuro, RecoAltEst, RecoActFis, RecoCustNor, RecoAlt7D, RecoExaFis, RecoExaFis7C, RecoOsteoMus1, RecoTamDer, RecoOdon,
                RecoPsico, RecoRx, RecoOit, RecoOft, Restricciton, Aptitud, _listAtecedentesOcupacionalesA,_listAtecedentesOcupacionalesB, _listaPatologicosFamiliares,
                _listMedicoPersonales, _listaHabitoNocivos, anamnesis, exams, _ExamenesServicio, ExamenFisico, TestIhihara, TestEstereopsis, Oftalmologia);
        }

        private void GenerateAnexo8InformeMedicoOcupacional(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport_Anexo8(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_InfMO(_serviceId);//_pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var RecoAudio = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.AUDIOMETRIA_ID);
            var RecoElectro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ELECTROCARDIOGRAMA_ID);
            var RecoEspiro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ESPIROMETRIA_ID);
            var RecoNeuro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EVAL_NEUROLOGICA_ID);
            var datosP = _pacientBL.DevolverDatosPaciente_Anexo8IMO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var RecoAltEst = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_ESTRUCTURAL_ID);
            var RecoActFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.CUESTIONARIO_ACTIVIDAD_FISICA);
            var RecoCustNor = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.C_N_ID);
            var RecoAlt7D = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_7D_ID);
            var RecoExaFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_ID);
            var RecoExaFis7C = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_7C_ID);
            var RecoOsteoMus1 = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OSTEO_MUSCULAR_ID_1);
            var RecoTamDer = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.TAMIZAJE_DERMATOLOGIO_ID);
            var RecoOdon = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ODONTOGRAMA_ID);
            var RecoPsico = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.PSICOLOGIA_ID);
            var RecoRx = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.RX_TORAX_ID);
            var RecoOit = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OIT_ID);
            var RecoOft = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OFTALMOLOGIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);


            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            var _listAtecedentesOcupacionales = _historyBL.GetHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);

            Anexo8_InformeMedicoOcupacionalcs.CreateAnexo8InformeMedicoOcupacional(_DataService,
                filiationData, diagnosticRepository, serviceComponents, MedicalCenter,
                datosP,
                pathFile,
                RecoAudio,
                RecoElectro,
                RecoEspiro,
                RecoNeuro, RecoAltEst, RecoActFis, RecoCustNor, RecoAlt7D, RecoExaFis, RecoExaFis7C, RecoOsteoMus1, RecoTamDer, RecoOdon,
                RecoPsico, RecoRx, RecoOit, RecoOft, Restricciton, Aptitud, _listAtecedentesOcupacionales, _listaPatologicosFamiliares, _listMedicoPersonales, _listaHabitoNocivos);
        }
        private void GenerateDeclaracionJuradaAntecedentesPersonales(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            //No usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_DJAP(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var _DataService = _serviceBL.GetInformacion_FirmaHuella(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//

            DeclaracionJuradaAntecedentesPersonales.CreateDeclaracionJuradaAntecedentesPersonales(_DataService, serviceComponents, MedicalCenter, datosP, pathFile);
        }
        private void GenerateEntregaExamenMedicoOcupacional(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_InfMO(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_EEMO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var _DataService = _serviceBL.GetServiceReport_Cos(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//

            EntregaExamenMedicoOcipacional.CreateEntregaExamenMedicoOcipacional(filiationData, _DataService, serviceComponents, MedicalCenter, datosP, pathFile);
        }
        private void GenerateInforme_Otorrinolaringologico(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_Otorr(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);//ServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Audiometria, _serviceId);

            Informe_Otorrinolaringologico.CreateInforme_Otorrinolaringologico(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }

        private void GenerateDeclaracionJurada_Encuesta(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_FirmaHuella(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_EEMO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            //No usa var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            DeclaracionJurada_Encuesta.CreateDeclaracionJurada_Encuesta(_DataService, pathFile, datosP, MedicalCenter, serviceComponents);
        }
        private void GenerateInforme_Resultados_San_Martinm(string pathFile)
        {
            //demoraba 32 - 18 seg // ahora 6 - 4 seg
            var _DataService = _serviceBL.GetServiceReport_16(_serviceId);//_serviceBL.GetServiceReport(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();
            //var filiationData = _pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewIMO(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var RecoAudio = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.AUDIOMETRIA_ID);
            var RecoElectro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ELECTROCARDIOGRAMA_ID);
            var RecoEspiro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ESPIROMETRIA_ID);
            var RecoNeuro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EVAL_NEUROLOGICA_ID);
            var datosP = _pacientBL.DevolverDatosPaciente_SanMartin(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var RecoAltEst = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_ESTRUCTURAL_ID);
            var RecoActFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.CUESTIONARIO_ACTIVIDAD_FISICA);
            var RecoCustNor = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.C_N_ID);
            var RecoAlt7D = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_7D_ID);
            var RecoExaFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_ID);
            var RecoExaFis7C = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_7C_ID);
            var RecoOsteoMus1 = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OSTEO_MUSCULAR_ID_1);
            var RecoTamDer = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.TAMIZAJE_DERMATOLOGIO_ID);
            var RecoOdon = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ODONTOGRAMA_ID);
            var RecoPsico = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.PSICOLOGIA_ID);
            var RecoRx = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.RX_TORAX_ID);
            var RecoOit = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OIT_ID);
            var RecoOft = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OFTALMOLOGIA_ID);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);


            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            var _listAtecedentesOcupacionalesA = _historyBL.GetHistoryReportA(_pacientId);
            var _listAtecedentesOcupacionalesB = _historyBL.GetHistoryReportB(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var anamnesis = _serviceBL.GetAnamnesisReport(_serviceId);
            var exams = serviceComponents;//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var _ExamenesServicio = serviceComponents;//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var ExamenFisico = _serviceBL.ValoresComponente(_serviceId, Constants.EXAMEN_FISICO_ID);
            var Oftalmologia = _serviceBL.ValoresComponente(_serviceId, Constants.OFTALMOLOGIA_ID);
            var TestIhihara = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ISHIHARA_ID);
            var TestEstereopsis = _serviceBL.ValoresComponente(_serviceId, Constants.TEST_ESTEREOPSIS_ID);

            Informe_Resultados_San_Martinm.CreateInforme_Resultados_San_Martinm(_DataService,
                filiationData, diagnosticRepository, serviceComponents, MedicalCenter,
                datosP,
                pathFile,
                RecoAudio,
                RecoElectro,
                RecoEspiro,
                RecoNeuro, RecoAltEst, RecoActFis, RecoCustNor, RecoAlt7D, RecoExaFis, RecoExaFis7C, RecoOsteoMus1, RecoTamDer, RecoOdon,
                RecoPsico, RecoRx, RecoOit, RecoOft, Restricciton, Aptitud, _listAtecedentesOcupacionalesA, _listAtecedentesOcupacionalesB, _listaPatologicosFamiliares,
                _listMedicoPersonales, _listaHabitoNocivos, anamnesis, exams, _ExamenesServicio, ExamenFisico, TestIhihara, TestEstereopsis, Oftalmologia);
        }

        private void GenerateAnexo16A(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_HC(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_LogoAddress();//_serviceBL.GetInfoMedicalCenter();//
            //No usa var filiationData = _pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_16A(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//

            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);

            Anexo16A.CreateAnexo16A(_DataService, pathFile, datosP, MedicalCenter, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void GenerateAltura_Fisica_Shahuindo(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_FisShahui(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_AFShahuindo(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            //var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            Altura_Fisica_Shahuindo.CreateAltura_Fisica_Shahuindo(_DataService, pathFile, datosP, MedicalCenter, serviceComponents);
        }
        private void GenerateDeclaracion_Jurada_EMPO_YANACOCHA(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_EmpoYana(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_EMOYanacocha(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuellaPhoto(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var CuadroVacio = Common.Utils.BitmapToByteArray(Resources.CuadradoVacio);
            var CuadroCheck = Common.Utils.BitmapToByteArray(Resources.CuadradoCheck);

            Declaracion_Jurada_EMPO_YANACOCHA.CreateDeclaracion_Jurada_EMPO_YANACOCHA(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, CuadroVacio, CuadroCheck);
        }
        private void GenerateDeclaracion_Jurada_EMO_Secutiras(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_SECURITAS(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//

            Declaracion_Jurada_EMO_Secutiras.CreateDeclaracion_Jurada_EMO_Secutiras( pathFile, datosP, MedicalCenter, filiationData, serviceComponents);
        }

        private void GenerateAutorizacion_Realizacion_Ex_Lumina(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetInformacion_OtrosExamenes(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_SECURITAS(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//

            Autorizacion_Realizacion_Ex_Lumina.CreateAutorizacion_Realizacion_Ex_Lumina(pathFile, datosP, MedicalCenter, filiationData);
        }
        private void GenerateExamen_Dermatologico_Ocupacional(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_3img(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_DO(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_SanMar(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            Examen_Dermatologico_Ocupacional.CreateExamen_Dermatologico_Ocupacional(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository);
        }
        private void GenerateCertificado_Suficiencia_Medica_Trabajo_Altura_V4(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_ResYana(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_SMB(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);
            Certificado_Suficiencia_Medica_Trabajo_Altura_V4.CreateCertificado_Suficiencia_Medica_Trabajo_Altura_V4(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void GenerateFicha_Evaluacion_Musculoesqueletica_GoldFields(string pathFile)
        {
            var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);

            var servicesId7 = new List<string>();
            servicesId7.Add(_serviceId);
            var componentReportId7 = new ServiceBL().ObtenerIdsParaImportacionExcel(servicesId7, 11);

            var uc = new ServiceBL().ReporteOsteomuscular(_serviceId, componentReportId7[0].ComponentId);

            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);
            //var uc = _serviceBL.ReporteOsteomuscular(_serviceId, Sigesoft.Common.Constants.EVALUACION_OTEOMUSCULAR_GOLDFIELDS_ID);
            Ficha_Evaluacion_Musculoesqueletica_GoldFields.CreateFicha_Evaluacion_Musculoesqueletica_GoldFields(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, uc, datosGrabo);
        }
        public void GenerateInforme_Psicologico_Resumen(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewLab(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var _DataService = _serviceBL.GetServiceReport(_serviceId);

            var _InformacionHistoriaPsico = _serviceBL.GetHistoriaClinicaPsicologica(_serviceId, Constants.FICHA_PSICOLOGICA_OCUPACIONAL_GOLDFIELDS);


            Informe_Psicologico_Resumen.CreateInforme_Psicologico_Resumen(filiationData, _DataService, serviceComponents, MedicalCenter, datosP, pathFile);
        }

        private void GenerateCertificado_Suficiencia_Medica_Brigadistas(string pathFile)
        {
            var _DataService = _serviceBL.GetInformacion_ResYana(_serviceId);//_serviceBL.GetInformacion_OtrosExamenes(_serviceId);//
            var datosP = _pacientBL.DevolverDatosPaciente_SMB(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ExamenFisico, _serviceId);
            Certificado_Suficiencia_Medica_Brigadistas.CreateCertificado_Suficiencia_Medica_Brigadistas(_DataService, pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Obstetrico(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Obstetrico(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Ginecologico(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Ginecologico(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }

        private void Generate_Informe_Ecografico_Abdominal(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Abdominal(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }

        private void Generate_Informe_Ecografico_Renal(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Renal(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Mamas(string pathFile)
        {
            //var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Mamas(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Prostata(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Prostata(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Partes_Blandas(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Partes_Blandas(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        private void Generate_Informe_Ecografico_Obstetrico_Pelvico(string pathFile)
        {
            //No usa var _DataService = _serviceBL.GetServiceReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente_IE(_serviceId);//_pacientBL.DevolverDatosPaciente(_serviceId);//
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_New(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var filiationData = _pacientBL.GetPacientReportEPS_FirmaHuella(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var datosGrabo = _serviceBL.DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.Ecografia, _serviceId);

            Ecografias_P_JP.Create_Informe_Ecografico_Obstetrico_Pelvico(pathFile, datosP, MedicalCenter, filiationData, serviceComponents, diagnosticRepository, datosGrabo);
        }
        
        private void GenerateExamenesEspecialesReport(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPS_EspeReports(_serviceId);//_pacientBL.GetPacientReportEPS(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewLab(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//

            ExamenesEspecialesReport.CreateLaboratorioReport(filiationData, serviceComponents, MedicalCenter, pathFile);
        }

        private void GenerateInformeMedicoResumen(string pathFile)
        {
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var filiationData = _pacientBL.GetPacientReportEPSFirmaMedicoOcupacional_MedicoResumen(_serviceId);//_pacientBL.GetPacientReportEPSFirmaMedicoOcupacional(_serviceId);//
            var serviceComponents = _serviceBL.GetServiceComponentsReport_NewIMO(_serviceId);//_serviceBL.GetServiceComponentsReport(_serviceId);//
            var RecoAudio = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.AUDIOMETRIA_ID);
            var RecoElectro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ELECTROCARDIOGRAMA_ID);
            var RecoEspiro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ESPIROMETRIA_ID);
            var RecoNeuro = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EVAL_NEUROLOGICA_ID);

            var RecoAltEst = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_ESTRUCTURAL_ID);
            var RecoActFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.CUESTIONARIO_ACTIVIDAD_FISICA);
            var RecoCustNor = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.C_N_ID);
            var RecoAlt7D = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ALTURA_7D_ID);
            var RecoExaFis = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_ID);
            var RecoExaFis7C = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.EXAMEN_FISICO_7C_ID);
            var RecoOsteoMus1 = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OSTEO_MUSCULAR_ID_1);
            var RecoTamDer = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.TAMIZAJE_DERMATOLOGIO_ID);
            var RecoOdon = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.ODONTOGRAMA_ID);
            var RecoPsico = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.PSICOLOGIA_ID);
            var RecoRx = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.RX_TORAX_ID);
            var RecoOit = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OIT_ID);
            var RecoOft = _serviceBL.GetListRecommendationByServiceIdAndComponent(_serviceId, Constants.OFTALMOLOGIA_ID);


            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            InformeMedicoOcupacional.CreateInformeMedicoOcupacional(filiationData, serviceComponents, MedicalCenter, pathFile,
                RecoAudio,
                RecoElectro,
                RecoEspiro,
                RecoNeuro, RecoAltEst, RecoActFis, RecoCustNor, RecoAlt7D, RecoExaFis, RecoExaFis7C, RecoOsteoMus1, RecoTamDer, RecoOdon,
                RecoPsico, RecoRx, RecoOit, RecoOft, Restricciton, Aptitud);
        }

        private void GenerateCertificadoAptitudCompleto(string pathFile)
        {

            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_Logo();//_serviceBL.GetInfoMedicalCenter();//
            var CAPC = _serviceBL.GetCAPC(_serviceId);
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var PathNegro = Application.StartupPath + "\\Resources\\cuadradonegro.jpg";
            var PathBlanco = Application.StartupPath + "\\Resources\\cuadroblanco.png";
            CertificadoAptitudCompleto.CreateCertificadoAptitudCompleto(
                CAPC,
                MedicalCenter,
                diagnosticRepository,
                pathFile,
                PathNegro,
                PathBlanco

                );
        }

        public void RunFile(string fileName)
        {
            Process proceso = Process.Start(fileName);
            //proceso.WaitForExit();
            proceso.Close();

        }

        private void chklExamenes_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectChangeExamenes();
        }

        private void chklFichasMedicas_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectChangeFichasMedicas();
        }

        private void SelectChangeExamenes()
        {
            var s = GetChekedItems(chklExamenes);

            if (s != null)
            {
                btnGenerarReporteExamenes.Enabled = true;
            }
            else
            {
                btnGenerarReporteExamenes.Enabled = false;

            }
        }

        private void SelectChangeFichasMedicas()
        {
            var s = GetChekedItems(chklFichasMedicas);

            if (s != null)
            {
                btnGenerarReporteFichasMedicas.Enabled = true;
            }
            else
            {
                btnGenerarReporteFichasMedicas.Enabled = false;
            }
        }

        private void SelectChangeCertificados()
        {
            var s = GetChekedItems(chkCertificados);

            if (s != null)
            {
                btnGenerarReporteCertificados.Enabled = true;
            }
            else
            {
                btnGenerarReporteCertificados.Enabled = false;
            }
        }

        private void chkCertificados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = GetChekedItems(chkCertificados);

            if (s != null)
            {
                btnGenerarReporteCertificados.Enabled = true;
            }
            else
            {
                btnGenerarReporteCertificados.Enabled = false;
            }
        }

        private void chkCertificados_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectChangeCertificados();
        }

        private void rbTodosCertificados_CheckedChanged(object sender, EventArgs e)
        {
            chklChekedAll(chkCertificados, true);
            chkCertificados.Enabled = false;
            SelectChangeCertificados();
        }

        private void rbSeleccioneCertificados_CheckedChanged(object sender, EventArgs e)
        {
            chkCertificados.Enabled = true;
            chklChekedAll(chkCertificados, false);
            SelectChangeCertificados();
        }

        private void btnGenerarReporteCertificados_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            var componentId = GetChekedItems(chkCertificados);
            var frm = new Reports.frmConsolidateReportsCertificados(_serviceId, componentId);
            frm.ShowDialog();
            this.Enabled = true;
        }
        private void GenerateAutorizacion_Liberacion_SanMartin(string pathFile)
        {
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);

            Aut_Liberacion_San_Martin.CreateAutorizacionLiberacionInformacionMedicaSanMartin(pathFile, datosP, MedicalCenter, filiationData);
        }

        private void GenerateActaEntregaYLecturaResultadosEMO_GOLD_MUR(string pathFile)
        {
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter_ExoLab();
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);

            Acta_Entrega_Lectura_Resultados_EMO_GOLD_MUR.CreateActaEntregaYLecturaResultadosEMO_GOLD_MUR(pathFile, datosP, MedicalCenter, filiationData);
        }
        private void GenerateHistoriaClinica(string pathFile)
        {
            OperationResult objOperationResult = new OperationResult();
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();
            var filiationData = _pacientBL.GetPacientReportEPS(_serviceId);
            var serviceComponents = _serviceBL.GetServiceComponentsReport_(_serviceId);
            var _listMedicoPersonales = _historyBL.GetPersonMedicalHistoryReport(_pacientId);
            var _listaPatologicosFamiliares = _historyBL.GetFamilyMedicalAntecedentsReport(_pacientId);
            var _listaHabitoNocivos = _historyBL.GetNoxiousHabitsReport(_pacientId);
            var _DiagnosticRepository = _serviceBL.GetServiceDisgnosticsHistoriaClinica(_serviceId);

            var Restricciton = _serviceBL.GetRestrictionByServiceId(_serviceId);
            var Aptitud = _serviceBL.DevolverAptitud(_serviceId);

            var Medicacion = _serviceBL.GetServiceMedicationsForGridView(ref objOperationResult, _serviceId);
            var Recomendaciones = _serviceBL.GetListRecommendationByServiceIdConcatenado(_serviceId);

            HistoriaClinica.CreateHistoriaClinica(filiationData, serviceComponents, MedicalCenter, _listMedicoPersonales, _listaPatologicosFamiliares, _listaHabitoNocivos, _DiagnosticRepository, Medicacion, Recomendaciones, pathFile);
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult = new OperationResult();
            MultimediaFileBL _multimediaFileBL = new MultimediaFileBL();

            _filesNameToMerge = new List<string>();


            List<string> files = Directory.GetFiles(Application.StartupPath + @"\Interconsultas\", "*.pdf").ToList();

            var Resultado = files.Find(p => p == Application.StartupPath + @"\Interconsultas\" + _serviceId + ".pdf");
            if (Resultado != null)
            {
                _filesNameToMerge.Add(Application.StartupPath + @"\Interconsultas\" + _serviceId + ".pdf");
            }


            var Grupo1 = GetChekedItems(chklExamenes);

            if (Grupo1 != null)
            {
                btnGenerarReporteExamenes_Click(sender, e);
                _filesNameToMerge.Add(Application.StartupPath + @"\TempMerge\Crystal1.pdf");
            }

            var Grupo3 = GetChekedItems(chkCertificados);


            if (Grupo3 != null)
            {
                btnGenerarReporteCertificados_Click(sender, e);
                _filesNameToMerge.Add(Application.StartupPath + @"\TempMerge\Crystal2.pdf");
            }

            var Grupo2 = GetChekedItems(chklFichasMedicas);
            if (Grupo2 != null)
            {
                //Obtner Archivos Pdf del Servicio

                var ListaPdf = _serviceBL.GetFilePdfsByServiceId(ref objOperationResult, _serviceId);
                if (ListaPdf.ToList().Count != 0)
                {
                    foreach (var item in ListaPdf)
                    {
                        var multimediaFile = _multimediaFileBL.GetMultimediaFileById(ref objOperationResult, item.v_MultimediaFileId);
                        var path = Application.StartupPath + @"\TempMerge\" + item.v_FileName;
                        File.WriteAllBytes(path, multimediaFile.ByteArrayFile);
                        _filesNameToMerge.Add(path);

                    }
                }

                btnGenerarReporteFichasMedicas_Click(sender, e);
            }
        }

        private void btnConsolidadoReportes_Click(object sender, EventArgs e)
        {
            if (_Eso == 1)
            {
                DialogResult Result = MessageBox.Show("¿Desea publicar a la WEB?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                OperationResult objOperationResult = new OperationResult();


               

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {

                    if (!Common.Utils.AccesoInternet())
                    {
                        MessageBox.Show("Verifique la conexión de Internet para publicar", "VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return ; 
                    }
                    string ruta = Common.Utils.GetApplicationConfigValue("rutaReportes").ToString();
                    string rutaBasura = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();
                    string rutaConsolidado = Common.Utils.GetApplicationConfigValue("rutaConsolidado").ToString();

                    var Reportes = GetChekedItems(chklConsolidadoReportes);
                    using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    {
                        CrearReportesCrystal(_serviceId, _pacientId, Reportes, _listaDosaje, Result == System.Windows.Forms.DialogResult.Yes ? true : false);
                    };

                    var x = _filesNameToMerge.ToList();
                    _mergeExPDF.FilesName = x;
                    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf";
                    _mergeExPDF.DestinationFile = ruta + _serviceId + ".pdf"; 
                    _mergeExPDF.Execute();
                    _mergeExPDF.RunFile();

                    var oService = _serviceBL.GetServiceShort(_serviceId);
                    _mergeExPDF.FilesName = x;
                    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";
                    if (oService.Empresa != oService.Contract)
                    {
                        _mergeExPDF.DestinationFile = rutaConsolidado + oService.Empresa + " - Contrata (" + oService.Contract + ") - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";
                        _mergeExPDF.Execute();
                    }
                    else if (oService.Empresa == oService.Contract)
                    {
                        _mergeExPDF.DestinationFile = rutaConsolidado + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";
                        _mergeExPDF.Execute();
                    }
    
                    


                    //Cambiar de estado a generado de reportes
                    _serviceBL.UpdateStatusPreLiquidation(ref objOperationResult, 2, _serviceId, Globals.ClientSession.GetAsList());

                    //if (AccesoInternet())
                    //{
                        Common.Utils.SendFileFtp("ftp.site4now.net", "SLReportesMedicos", "SLRepotMed123_", ruta + _serviceId + ".pdf");
                    //}
                    
                }
                else
                {
                    string ruta = Common.Utils.GetApplicationConfigValue("rutaReportes").ToString();
                    string rutaBasura = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();
                    string rutaConsolidado = Common.Utils.GetApplicationConfigValue("rutaConsolidado").ToString();

                    var Reportes = GetChekedItems(chklConsolidadoReportes);
                    using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    {
                        CrearReportesCrystal(_serviceId, _pacientId, Reportes, _listaDosaje, Result == System.Windows.Forms.DialogResult.Yes ? true : false);
                    };
                    var x = _filesNameToMerge.ToList();
                    _mergeExPDF.FilesName = x;
                    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf"; ;
                    _mergeExPDF.DestinationFile = rutaBasura + _serviceId + ".pdf"; ;
                    _mergeExPDF.Execute();
                    _mergeExPDF.RunFile();
                }
            }
            else if (_Eso == 2)
            {
                DialogResult Result = MessageBox.Show("¿Desea Visualizar reporte?", "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                OperationResult objOperationResult = new OperationResult();

                string ruta = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();
                string rutaBasura = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();
                string rutaConsolidado = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();

                var Reportes = GetChekedItems(chklConsolidadoReportes);
                

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                    {
                        CrearReportesCrystal(_serviceId, _pacientId, Reportes, _listaDosaje, Result == System.Windows.Forms.DialogResult.Yes);
                    };
                    var x = _filesNameToMerge.ToList();
                    _mergeExPDF.FilesName = x;
                    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf";
                    _mergeExPDF.DestinationFile = rutaBasura + _serviceId + ".pdf"; ;
                    _mergeExPDF.Execute();
                    _mergeExPDF.RunFile();

                    var oService = _serviceBL.GetServiceShort(_serviceId);
                    _mergeExPDF.FilesName = x;
                    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                    _mergeExPDF.DestinationFile = rutaBasura + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";
                    _mergeExPDF.Execute();

                    //Cambiar de estado a generado de reportes
                    //_serviceBL.UpdateStatusPreLiquidation(ref objOperationResult, 2, _serviceId, Globals.ClientSession.GetAsList());
                }
                else
                {
                    Result = DialogResult.Cancel;
                }
            }
            
        }

        public void reportSolo(List<string> componentIds, string idPacient, string serviceId)
        {

            OperationResult objOperationResult = new OperationResult();
            string rutaBasura = Common.Utils.GetApplicationConfigValue("rutaReportesBasura").ToString();
            CrearReportesCrystal(serviceId, idPacient, componentIds, _listaDosaje, false);
            var x = _filesNameToMerge.ToList();
            _mergeExPDF.FilesName = x;
            _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf";
            _mergeExPDF.DestinationFile = rutaBasura + _serviceId + ".pdf"; ;
            _mergeExPDF.Execute();
            _mergeExPDF.RunFile();
        }

      private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                chklChekedAll(chklConsolidadoReportes, true);
                chklConsolidadoReportes.Enabled = true;
                SelectChangeConsolidadoReportes();
                chkTodos.Text = "Deseleccionar Todos";
            }
            else
            {
                chklConsolidadoReportes.Enabled = true;
                chklChekedAll(chklConsolidadoReportes, false);
                SelectChangeConsolidadoReportes();
                chkTodos.Text = "Seleccionar Todos";
            }

        }

        private void SelectChangeConsolidadoReportes()
        {
            var s = GetChekedItems(chklConsolidadoReportes);
        }

        public void CrearReportesCrystal(string serviceId, string pPacienteId, List<string> reportesId, List<ServiceComponentList> ListaDosaje, bool Publicar)
        {
            OperationResult objOperationResult = new OperationResult();
            MultimediaFileBL _multimediaFileBL = new MultimediaFileBL();
            crConsolidatedReports rp = null;
            ruta = Common.Utils.GetApplicationConfigValue("rutaReportes").ToString();
            rp = new Reports.crConsolidatedReports();
            _filesNameToMerge = new List<string>();


            //reportesId.FindAll(p => p != Constants.HISTORIA_CLINICA_PSICOLOGICA_ID || p != Constants.PSICOLOGIA_ID || p != Constants.INFORME_LABORATORIO_ID);

            foreach (var com in reportesId)
            {
                //string CompnenteId = "";
                int IdCrystal = 0;
                //Obtener el Id del componente 

                var array = com.Split('|');

                if (array.Count() == 1)
                {
                    IdCrystal = 0;
                }
                else if (array[1] == "")
                {
                    IdCrystal = 0;
                }
                else
                {
                    IdCrystal = int.Parse(array[1].ToString());
                }

                ChooseReport(array[0], serviceId, pPacienteId, IdCrystal);


            }

            #region ...

            

          
            //if (Publicar)
            //{
            //    #region Adjuntar Archivos Adjuntos

            //    string rutaInterconsulta = Common.Utils.GetApplicationConfigValue("Interconsulta").ToString();

            //    List<string> files = Directory.GetFiles(rutaInterconsulta, "*.pdf").ToList();
            //    var o = _serviceBL.GetServiceShort(serviceId);

            //    var Resultado = files.Find(p => p == rutaInterconsulta + serviceId + "-" + o.Paciente + ".pdf");
            //    if (Resultado != null)
            //    {
            //        _filesNameToMerge.Add(rutaInterconsulta + _serviceId + "-" + o.Paciente + ".pdf");
            //    }


            //    var ListaPdf = _serviceBL.GetFilePdfsByServiceId(ref objOperationResult, _serviceId);
            //    if (ListaPdf != null)
            //    {
            //        if (ListaPdf.ToList().Count != 0)
            //        {
            //            foreach (var item in ListaPdf)
            //            {
            //                var multimediaFile = _multimediaFileBL.GetMultimediaFileById(ref objOperationResult, item.v_MultimediaFileId);
            //                var path = ruta + _serviceId + "-" + item.v_FileName;
            //                File.WriteAllBytes(path, multimediaFile.ByteArrayFile);
            //                _filesNameToMerge.Add(path);

            //            }
            //        }
            //    }

            //    //Obtner DNI y Fecha del servicio

            //    string Fecha = o.FechaServicio.Value.Day.ToString().PadLeft(2, '0') + o.FechaServicio.Value.Month.ToString().PadLeft(2, '0') + o.FechaServicio.Value.Year.ToString();
            //    DirectoryInfo rutaOrigen = null;


            //    //ELECTRO
            //    rutaOrigen = new DirectoryInfo(Common.Utils.GetApplicationConfigValue("ImgEKGOrigen").ToString());
            //    FileInfo[] files1 = rutaOrigen.GetFiles();

            //    foreach (FileInfo file in files1)
            //    {
            //        if (file.ToString().Count() > 16)
            //        {
            //            if (file.ToString().Substring(0, 17) == o.DNI + "-" + Fecha)
            //            {
            //                _filesNameToMerge.Add(rutaOrigen + file.ToString());
            //            };
            //        }
            //    }


            //    //ESPIRO
            //    rutaOrigen = new DirectoryInfo(Common.Utils.GetApplicationConfigValue("ImgESPIROOrigen").ToString());
            //    FileInfo[] files2 = rutaOrigen.GetFiles();

            //    foreach (FileInfo file in files2)
            //    {
            //        if (file.ToString().Count() > 16)
            //        {
            //            if (file.ToString().Substring(0, 17) == o.DNI + "-" + Fecha)
            //            {
            //                _filesNameToMerge.Add(rutaOrigen + file.ToString());
            //            };
            //        }
            //    }

            //    //ESPIRO
            //    rutaOrigen = new DirectoryInfo(Common.Utils.GetApplicationConfigValue("ImgPSICOOrigen").ToString());
            //    FileInfo[] files3 = rutaOrigen.GetFiles();

            //    foreach (FileInfo file in files3)
            //    {
            //        if (file.ToString().Count() > 16)
            //        {
            //            if (file.ToString().Substring(0, 17) == o.DNI + "-" + Fecha)
            //            {
            //                _filesNameToMerge.Add(rutaOrigen + file.ToString());
            //            };
            //        }
            //    }
            //    //LAB
            //    rutaOrigen = new DirectoryInfo(Common.Utils.GetApplicationConfigValue("ImgLABOrigen").ToString());
            //    FileInfo[] files4 = rutaOrigen.GetFiles();

            //    foreach (FileInfo file in files4)
            //    {
            //        if (file.ToString().Count() > 16)
            //        {
            //            if (file.ToString().Substring(0, 17) == o.DNI + "-" + Fecha)
            //            {
            //                _filesNameToMerge.Add(rutaOrigen + file.ToString());
            //            };
            //        }
            //    }


            //    var x = _filesNameToMerge.ToList();
            //    _mergeExPDF.FilesName = x;
            //    _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf"; ;
            //    _mergeExPDF.DestinationFile = ruta + _serviceId + ".pdf"; ;
            //    _mergeExPDF.Execute();

            //    #endregion
            //}

            #endregion

            if (Publicar)
            {
                #region Adjuntar Archivos Adjuntos

                string rutaInterconsulta = Common.Utils.GetApplicationConfigValue("Interconsulta").ToString();

                List<string> files = Directory.GetFiles(rutaInterconsulta, "*.pdf").ToList();
                var o = _serviceBL.GetServiceShort(serviceId);

                var Resultado = files.Find(p => p == rutaInterconsulta + serviceId + "-" + o.Paciente + ".pdf");
                if (Resultado != null)
                {
                    _filesNameToMerge.Add(rutaInterconsulta + _serviceId + "-" + o.Paciente + ".pdf");
                }

                var ListaPdf = _serviceBL.GetFilePdfsByServiceId(ref objOperationResult, _serviceId);
                if (ListaPdf != null)
                {
                    if (ListaPdf.ToList().Count != 0)
                    {
                        foreach (var item in ListaPdf)
                        {
                            var multimediaFile = _multimediaFileBL.GetMultimediaFileById(ref objOperationResult, item.v_MultimediaFileId);
                            string rutaOrigenArchivo = "";
                            if (multimediaFile.ByteArrayFile == null)
                            {
                                var a = multimediaFile.FileName.Split('-');
                                var consultorio = a[2].Substring(0, a[2].Length - 0);
                                if (consultorio == "ESPIROMETRÍA")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgESPIROOrigen").ToString();
                                }
                                else if (consultorio == "RAYOS X")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgRxOrigen").ToString();
                                }
                                else if (consultorio == "CARDIOLOGÍA")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgEKGOrigen").ToString();
                                }
                                else if (consultorio == "LABORATORIO")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgLABOrigen").ToString();
                                }
                                else if (consultorio == "PSICOLOGÍA")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgPSICOOrigen").ToString();
                                }
                                else if (consultorio == "OFTALMOLOGÍA")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgOftalmoOrigen").ToString();
                                }
                                else if (consultorio == "MEDICINA")
                                {
                                    rutaOrigenArchivo = Common.Utils.GetApplicationConfigValue("ImgMedicinaOrigen").ToString();
                                }
                                else 
                                {
                                    MessageBox.Show("No se ha configurado una ruta para subir el archivo.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                var path = rutaOrigenArchivo + item.v_FileName;
                                _filesNameToMerge.Add(path);
                            }
                            else
                            {
                                var path = ruta + _serviceId + "-" + item.v_FileName;
                                File.WriteAllBytes(path, multimediaFile.ByteArrayFile);
                                _filesNameToMerge.Add(path);
                            }
                        }
                    }
                }

                //string rutaDeclaracionJurada = Common.Utils.GetApplicationConfigValue("DeclaracionJurada");
                //List<string> filesConsentimientos = Directory.GetFiles(rutaDeclaracionJurada, "*.pdf").ToList();


                //var resultadoConsentimiento = filesConsentimientos.Find(p => p == rutaDeclaracionJurada + serviceId + "-DJ.pdf");
                //if (resultadoConsentimiento != null)
                //{
                //    _filesNameToMerge.Add(rutaDeclaracionJurada + _serviceId + "-DJ.pdf");
                //}
                //var x = _filesNameToMerge.ToList();
                //_mergeExPDF.FilesName = x;
                //_mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + _serviceId + ".pdf"; ;
                //_mergeExPDF.DestinationFile = ruta + _serviceId + ".pdf"; ;
                //_mergeExPDF.Execute();

                #endregion
            }


        }

        public void ChooseReport(string componentId, string serviceId, string pPacienteId, int pintIdCrystal)
        {
            ruta = Common.Utils.GetApplicationConfigValue("rutaReportes").ToString();
            _tempSourcePath = Path.Combine(Application.StartupPath, "TempMerge");

            DataSet ds = null;
            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
            OperationResult objOperationResult = new OperationResult();
            _serviceId = serviceId;
            _pacientId = pPacienteId;
            switch (componentId)
            {

                case Constants.INFORME_CERTIFICADO_APTITUD:
                    var INFORME_CERTIFICADO_APTITUD = new ServiceBL().GetAptitudeCertificateRefact(ref objOperationResult, _serviceId);

                    if (INFORME_CERTIFICADO_APTITUD == null)
                    {
                        break;
                    }
                    DataSet ds1 = new DataSet();

                    DataTable dtINFORME_CERTIFICADO_APTITUD = Sigesoft.Node.WinClient.BLL.Utils.ConvertToDatatable(INFORME_CERTIFICADO_APTITUD);

                    dtINFORME_CERTIFICADO_APTITUD.TableName = "AptitudeCertificate";
                    ds1.Tables.Add(dtINFORME_CERTIFICADO_APTITUD);


                    var TipoServicio = INFORME_CERTIFICADO_APTITUD[0].i_EsoTypeId;
                    ReportDocument rp;



                    if (pintIdCrystal == 24)
                    {
                        if (TipoServicio == ((int)TypeESO.Retiro).ToString())
                        {
                            rp = new Reports.crCertificadoDeAptitudEmpresarial();
                            rp.SetDataSource(ds1);

                            string rutaCertificado = Common.Utils.GetApplicationConfigValue("CertificadoRetiro").ToString();
                            //rp = new Reports.crOccupationalRetirosSinFirma();
                            rp.SetDataSource(ds1);
                            rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            objDiskOpt = new DiskFileDestinationOptions();
                            objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                            rp.ExportOptions.DestinationOptions = objDiskOpt;
                            rp.Export();


                        }
                        else
                        {
                            if (INFORME_CERTIFICADO_APTITUD[0].i_AptitudeStatusId == (int)AptitudeStatus.AptoObs)
                            {
                                rp = new Reports.crCertficadoObservadoSinFirma();
                                rp.SetDataSource(ds1);


                                string rutaCertificado = Common.Utils.GetApplicationConfigValue("CertificadoObs").ToString();
                                //rp = new Reports.crCertficadoObservadoSinFirma();
                                rp.SetDataSource(ds1);
                                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                                objDiskOpt = new DiskFileDestinationOptions();
                                objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                                rp.ExportOptions.DestinationOptions = objDiskOpt;
                                rp.Export();

                            }
                            else
                            {
                                rp = new Reports.crOccupationalCertificateSinFirma();
                                rp.SetDataSource(ds1);

                                string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                                //rp = new Reports.crOccupationalCertificateSinFirma();
                                rp.SetDataSource(ds1);
                                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                                objDiskOpt = new DiskFileDestinationOptions();
                                objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                                rp.ExportOptions.DestinationOptions = objDiskOpt;
                                rp.Export();

                            }
                        }
                    }
                    else if (pintIdCrystal == 23)
                    {
                        rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                        rp.SetDataSource(ds1);
                        string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                        //rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                        rp.SetDataSource(ds1);
                        rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        objDiskOpt = new DiskFileDestinationOptions();
                        objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                        rp.ExportOptions.DestinationOptions = objDiskOpt;
                        rp.Export();
                    }
                    else if (pintIdCrystal == 25)
                    {
                        string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                        rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                        rp.SetDataSource(ds1);
                        rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        objDiskOpt = new DiskFileDestinationOptions();
                        objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                        rp.ExportOptions.DestinationOptions = objDiskOpt;
                        rp.Export();

                    }
                    else if (pintIdCrystal == 26)
                    {
                        rp = new Reports.crOccupationalMedicalAptitudeCertificateSinDx();
                        rp.SetDataSource(ds1);

                        string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                        //rp = new Reports.crOccupationalMedicalAptitudeCertificateSinDx();
                        rp.SetDataSource(ds1);
                        rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        objDiskOpt = new DiskFileDestinationOptions();
                        objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                        rp.ExportOptions.DestinationOptions = objDiskOpt;
                        rp.Export();

                    }
                    else if (pintIdCrystal == 28)
                    {
                        rp = new Reports.crOccupationaCertificateSinDxSinFirma();
                        rp.SetDataSource(ds1);

                        string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                        //rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                        rp.SetDataSource(ds1);
                        rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        objDiskOpt = new DiskFileDestinationOptions();
                        objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                        rp.ExportOptions.DestinationOptions = objDiskOpt;
                        rp.Export();

                    }
                    else
                    {
                        if (TipoServicio == ((int)TypeESO.Retiro).ToString())
                        {
                            rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                            rp.SetDataSource(ds1);

                            string rutaCertificado = Common.Utils.GetApplicationConfigValue("CertificadoRetiro").ToString();
                            //rp = new Reports.crOccupationalMedicalAptitudeCertificateRetiros();
                            rp.SetDataSource(ds1);
                            rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            objDiskOpt = new DiskFileDestinationOptions();
                            objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                            rp.ExportOptions.DestinationOptions = objDiskOpt;
                            rp.Export();
                        }
                        else
                        {
                            if (INFORME_CERTIFICADO_APTITUD[0].i_AptitudeStatusId == (int)AptitudeStatus.AptoObs)
                            {
                                //midificacion por que no sale bien 
                                rp = new Reports.crCertficadoObservado();
                                //rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                                rp.SetDataSource(ds1);

                                string rutaCertificado = Common.Utils.GetApplicationConfigValue("CertificadoObs").ToString();
                                //rp = new Reports.crCertficadoObservado();
                                rp.SetDataSource(ds1);
                                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                                objDiskOpt = new DiskFileDestinationOptions();
                                objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                                rp.ExportOptions.DestinationOptions = objDiskOpt;
                                rp.Export();
                            }
                            else
                            {
                                rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                                rp.SetDataSource(ds1);

                                string rutaCertificado = Common.Utils.GetApplicationConfigValue("Certificado312").ToString();
                                //rp = new Reports.crOccupationalMedicalAptitudeCertificate();
                                rp.SetDataSource(ds1);
                                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                                objDiskOpt = new DiskFileDestinationOptions();
                                objDiskOpt.DiskFileName = rutaCertificado + INFORME_CERTIFICADO_APTITUD[0].v_OrganizationName + "-" + INFORME_CERTIFICADO_APTITUD[0].v_PersonName + "-" + Constants.INFORME_CERTIFICADO_APTITUD + "-" + INFORME_CERTIFICADO_APTITUD[0].d_ServiceDate.Value.ToString("dd MMMM,  yyyy") + ".pdf";

                                rp.ExportOptions.DestinationOptions = objDiskOpt;
                                rp.Export();
                            }
                        }
                    }

                    rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    objDiskOpt = new DiskFileDestinationOptions();
                    objDiskOpt.DiskFileName = ruta + serviceId + "-" + Constants.INFORME_CERTIFICADO_APTITUD + ".pdf";
                    _filesNameToMerge.Add(objDiskOpt.DiskFileName);
                    rp.ExportOptions.DestinationOptions = objDiskOpt;
                    rp.Export();
                    rp.Close();
                    break;

                case Constants.ATENCION_INTEGRAL_ID:
                    GenerateAtencionIntegral(string.Format("{0}.pdf", Path.Combine(ruta, _serviceId + "-" + Constants.ATENCION_INTEGRAL_ID)));
                    _filesNameToMerge.Add(string.Format("{0}.pdf", Path.Combine(ruta, _serviceId + "-" + componentId)));
                    break;

                default:
                    break;
            }
        }

        private void GenerateAtencionIntegral(string pathFile)
        {
            //var _DataService = _serviceBL.GetServiceReport(_serviceId);
            // en esta variable va a traer todos los valores de los examenes
            var exams = _serviceBL.GetServiceComponentsReport(_serviceId);
            var datosP = _pacientBL.DevolverDatosPaciente(_serviceId);
            var MedicalCenter = _serviceBL.GetInfoMedicalCenter();
            int GrupoEtario = 0;
            int Grupo = 0;
            var diagnosticRepository = _serviceBL.GetServiceComponentConclusionesDxServiceIdReport(_serviceId);
            var medico = _pacientBL.ObtenerDatosMedicoMedicina(_serviceId, Constants.ATENCION_INTEGRAL_ID, Constants.ATENCION_INTEGRAL_ID);
            var medicina = objRecetaBl.GetReceta(_serviceId);
            var medicoTratante = new ServiceBL().GetMedicoTratante(_serviceId);
            var datosGrabo = new ServiceBL().DevolverDatosUsuarioGraboExamen((int)CategoryTypeExam.ConsultorioExternoYEmergencia, _serviceId);

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
                var ListServiceComponent = new ServiceBL().GetAllComponents(ref objOperationResult, (int)TipoBusqueda.ComponentId, componentId);

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

            //var añosCompleto = "25";//DiferenciaFechas(DateTime.Now, datosP.d_Birthdate.Value);
            var añosCompleto = DiferenciaFechas(datosP.FechaServicio.Value, datosP.d_Birthdate.Value);

            AtencionIntegral.CreateAtencionIntegral(pathFile, medico, datosP, MedicalCenter,
                exams, diagnosticRepository, medicina,
                medicoTratante, datosGrabo, DataSource, añosCompleto);

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



        public void GenerarReportes(string serviceId, string pPacienteId, List<string> pReportes)
        {
            OperationResult objOperationResult = new OperationResult();

            CrearReportesCrystal(serviceId, pPacienteId, pReportes, _listaDosaje, true);
            ruta = Common.Utils.GetApplicationConfigValue("rutaConsolidado").ToString();

            var oService = _serviceBL.GetServiceShort(serviceId);

            var x = _filesNameToMerge.ToList();
            _mergeExPDF.FilesName = x;
            _mergeExPDF.DestinationFile = Application.StartupPath + @"\TempMerge\" + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";

            _mergeExPDF.DestinationFile = ruta + oService.Empresa + " - " + oService.Paciente + " - " + oService.FechaServicio.Value.ToString("dd MMMM,  yyyy") + ".pdf";
            _mergeExPDF.Execute();

            //Cambiar de estado a generado de reportes
            _serviceBL.UpdateStatusPreLiquidation(ref objOperationResult, 2, serviceId, Globals.ClientSession.GetAsList());



        }

        private void chklConsolidadoReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
