using Infragistics.Win.Misc;
using NetPdf;
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmRegistroHospSop : Form
    {
        private List<HospitalizacionHabitacionList> _objHabitaciones = new List<HospitalizacionHabitacionList>();
        private List<HospitalizacionHabitacionList> objDataHabitaciones = new List<HospitalizacionHabitacionList>();
        private List<HospitalizacionServiceListNew> objDataServicios = new List<HospitalizacionServiceListNew>();
        private List<ServiceComponentListNew> objDataComponentes = new List<ServiceComponentListNew>();
        private List<TicketList> objDataTickets = new List<TicketList>();

        OperationResult objOperationResult = new OperationResult();

        private ServiceBL oServiceBL = new ServiceBL();
        private HospitalizacionBL _hospitBL = new HospitalizacionBL();
        private PacientBL _pacientBL = new PacientBL();

        List<string> ListaComponentes = new List<string>();
        private List<TicketList> _tempTicket = null;

        private hospitalizacionserviceDto hospser = new hospitalizacionserviceDto();
        private ticketDto Ticket = new ticketDto();
        private protocolDto prot = new protocolDto();
        private serviceDto serv = new serviceDto();

        private string _ticketId;
        private string v_ProtocoloId;

        private string HospId = "";
        private string Pac = "";
        private string Dni = "";
        private string Edad = "";
        private string Medico = "";
        private string Cie10 = "";
        private string Dx = "";
        private string Cie10S = "";
        private string DxS = "";
        private string Procedencia = "";
        private string Hosp = "";
        private string Sop = "";
        private string fechaAlta = "";
        private string Comentarios = "";

        private string ServiceId = "";
        private string PersonId = "";

        private string Cie10DxSalida = "";
        private string DxSalida = "";
        private string ProcOdId = "";
        private string ProcedimientoDec = "";

        byte[] _personImage;


        private OperationResult _objOperationResult = new OperationResult();
        private List<ComponentList> _tmpServiceComponentsForBuildMenuList = null;
        private bool _cancelEventSelectedIndexChange;
        private Dictionary<string, UltraValidator> _dicUltraValidators;
        private readonly string _action;
        private static List<GroupParameter> _cboEso;
        private List<ServiceComponentFieldValuesList> _tmpListValuesOdontograma = null;

        public bool _isChangeValue = false;
        private string _oldValue;
        private int? _sexTypeId;

        private bool flagValueChange = false;

        private string ServiceId_N = "";
        List<Sigesoft.Node.WinClient.UI.Operations.FrmEsoV2.ValidacionAMC> _oListValidacionAMC = new List<Sigesoft.Node.WinClient.UI.Operations.FrmEsoV2.ValidacionAMC>();
        private List<KeyValueDTO> _KeyValueDTO = null;





        private HospitalizacionBL _objHospitalizacionBL = new HospitalizacionBL();

        public frmRegistroHospSop(string _HospId, string _Pac, string _Dni, string _Edad, string _Medico, string _Cie10, string _Dx, string _Procedencia,
            string _Hosp, string _Sop, string _fechaAlta, string _Comentarios, string _PersonId, string v_CIE10IdSalida, string v_DiseasesNameSalida, string i_ProcedimientoSOP, string v_ProcedimientoSOP)
        {
            HospId = _HospId;
            Pac = _Pac;
            Dni = _Dni;
            Edad = _Edad;
            Medico = _Medico;
            Cie10 = _Cie10;
            Dx = _Dx;
            Procedencia = _Procedencia;
            Hosp = _Hosp;
            Sop = _Sop;
            fechaAlta = _fechaAlta;
            Comentarios = _Comentarios;
            PersonId = _PersonId;

            Cie10DxSalida = v_CIE10IdSalida;
            DxSalida = v_DiseasesNameSalida;
            ProcOdId = i_ProcedimientoSOP;
            ProcedimientoDec = v_ProcedimientoSOP;

            InitializeComponent();
            _action = "View";
        }

        private void grdServicios_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistroHospSop_Load(object sender, EventArgs e)
        {
            ValidacionBotones();

            var objPersonDto = _pacientBL.GetPerson(ref objOperationResult, PersonId);

            //Byte[] ooo = objPersonDto.b_PersonImage;

            //if (ooo == null)
            //{
                pbEmployee.Image = Resources.nofoto;
            //}
            //else
            //{
            //    pbEmployee.Image = Common.Utils.BytesArrayToImageOficce(ooo, pbEmployee);
            //    _personImage = ooo;
            //}

            txtCie10_Salida.Text = Cie10DxSalida;
            txtDx_Salida.Text = DxSalida;
            txtIdProcedimiento.Text = ProcOdId;
            txtProcedimiento.Text = ProcedimientoDec;

            txtPacient.Text = Pac;
            txtDni.Text = Dni;
            txtEdad.Text = Edad;
            txtMedico.Text = Medico;
            txtCie10.Text = Cie10;
            txtDx.Text = Dx;
            txtProcedencia.Text = Procedencia;
            //txtHosp.Text = Hosp;
            //txtSop.Text = Sop;

            CargarGrillaHabitaciones();

            CargarGrillaServicios();



            //if (Sop == "SI")
            //{
                btnHorasSala.Enabled = true;
            //}
            //else
            //{
            //    btnHorasSala.Enabled = false;

            //}

            ActualizacionHospitalizacion();
        }

        private void ValidacionBotones()
        {
            if (fechaAlta != "")
            {
                btnAgregarExamenes.Enabled = false;
                btnEditExamen.Enabled = false;
                btnEliminarExamen.Enabled = false;
                btnAsignarHabitacion.Enabled = false;
                btnEditarHabitacion.Enabled = false;
                btnEliminarHabitacion.Enabled = false;
                btnTicket.Enabled = false;
                btnEditarTicket.Enabled = false;
                btnEliminarTicket.Enabled = false;
                btnImprimirTicket.Enabled = true;
                btnDarAlta.Enabled = false;
            }
            else
            {
                btnAgregarExamenes.Enabled = true;
                btnEditExamen.Enabled = true;
                btnEliminarExamen.Enabled = true;
                btnAsignarHabitacion.Enabled = true;
                btnEditarHabitacion.Enabled = true;
                btnEliminarHabitacion.Enabled = true;
                btnTicket.Enabled = true;
                btnEditarTicket.Enabled = true;
                btnEliminarTicket.Enabled = true;
                btnImprimirTicket.Enabled = true;
                btnDarAlta.Enabled = true;
            }
        }

        private void CargarGrillaHabitaciones()
        {
            objDataHabitaciones = GetHabitaciones();
            grdHabitaciones.DataSource = objDataHabitaciones;
        }
        private List<HospitalizacionHabitacionList> GetHabitaciones()
        {
            _objHabitaciones = _hospitBL.BuscarHospitalizacionHabitaciones(HospId).ToList();
            return _objHabitaciones;
        }

        private List<HospitalizacionServiceListNew> GetServicios()
        {
            List<HospitalizacionServiceListNew> servicios = _hospitBL.BuscarServiciosHospitalizacionNew(HospId).ToList();
            return servicios;
        }


        private void CargarGrillaServicios()
        {
            objDataServicios = GetServicios();
            grdServicios.DataSource = objDataServicios;
            //grdServiciosSegHosp.DataSource = objDataServicios;
        }

        private void CargarGrillaExamenes(string serviceId)
        {
            objDataComponentes = GetComponentes(serviceId);
            grdExamenes.DataSource = objDataComponentes;
        }

        private List<ServiceComponentListNew> GetComponentes(string ServiceId)
        {
            var componentes = oServiceBL.GetServiceComponents_New(ref objOperationResult, ServiceId).FindAll(p => p.r_Price != 0);

            return componentes;
        }

        private void btnAsignarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                #region Conexion SIGESOFT Obtener Protocolo
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "select PR.v_ProtocolId " +
                              "from hospitalizacionservice HS " +
                              "inner join service SR on SR.v_ServiceId= HS.v_ServiceId " +
                              "inner join protocol PR on SR.v_ProtocolId=PR.v_ProtocolId " +
                              "where v_HopitalizacionId='" + HospId + "' order by v_ProtocolId";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                v_ProtocoloId = "";
                while (lector.Read()) { v_ProtocoloId = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion

                #region Conexion SIGESOFT Obtener Plan
                conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + v_ProtocoloId + "'";
                comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                lector = comando.ExecuteReader();
                string plan = "";
                while (lector.Read()) { plan = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion
                string modoMasterService;
                if (plan != "") { modoMasterService = "ASEGU"; }
                else { modoMasterService = "HOSPI"; }
                
                var frm = new frmHabitaciones(HospId, "New" + modoMasterService, "", v_ProtocoloId);
                frm.ShowDialog();

                CargarGrillaHabitaciones();

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MessageBox.Show("NO SE PUEDE DAR DE ALTA - YA ASIGNADO", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //throw;
            }
        }

        private void btnEditarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                #region Conexion SIGESOFT Obtener Protocolo
                ConexionSigesoft conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                var cadena1 = "select PR.v_ProtocolId " +
                              "from hospitalizacionservice HS " +
                              "inner join service SR on SR.v_ServiceId= HS.v_ServiceId " +
                              "inner join protocol PR on SR.v_ProtocolId=PR.v_ProtocolId " +
                              "where v_HopitalizacionId='" + HospId + "'";
                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                SqlDataReader lector = comando.ExecuteReader();
                v_ProtocoloId = "";
                while (lector.Read()) { v_ProtocoloId = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion

                #region Conexion SIGESOFT Obtener Plan
                conectasam = new ConexionSigesoft();
                conectasam.opensigesoft();
                cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + v_ProtocoloId + "'";
                comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                lector = comando.ExecuteReader();
                string plan = "";
                while (lector.Read()) { plan = lector.GetValue(0).ToString(); }
                lector.Close();
                conectasam.closesigesoft();
                #endregion
                string modoMasterService;
                if (plan != "") { modoMasterService = "ASEGU"; }
                else { modoMasterService = "HOSPI"; }

                var hospitalizacionHabitacionId = grdHabitaciones.Selected.Rows[0].Cells["v_HospitalizacionHabitacionId"].Value.ToString();

                frmHabitaciones frm = new frmHabitaciones(HospId, "Edit" + modoMasterService, hospitalizacionHabitacionId, v_ProtocoloId);

                frm.ShowDialog();

                CargarGrillaHabitaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE PUEDE EDITAR HABITACIÓN - YA ASIGNADO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();

                var hospitalizacionHabitacionId = grdHabitaciones.Selected.Rows[0]
                    .Cells["v_HospitalizacionHabitacionId"].Value.ToString();

                var habtacion =
                    new HospitalizacionHabitacionBL().GetHabitacion(ref objOperationResult,
                        hospitalizacionHabitacionId);

                habtacion.i_IsDeleted = 1;
                habtacion.i_EstateRoom = 3;

                DialogResult Result = MessageBox.Show("¿Está seguro de eliminar habitación?", "ADVERTENCIA!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    new HospitalizacionHabitacionBL().UpdateHospitalizacionHabitacion(ref objOperationResult, habtacion,
                        Globals.ClientSession.GetAsList());

                    CargarGrillaHabitaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA ELIMINAR HABITACION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdHabitaciones.Selected.Rows.Count == 0)
                    return;
                var fechaFin = grdHabitaciones.Selected.Rows[0].Cells["d_EndDate"].Value;

                if (fechaFin == null)
                {
                    MessageBox.Show("La habitación está ocupada y no puede pasar a limpieza directamente.",
                        "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nroHabitacion = grdHabitaciones.Selected.Rows[0].Cells["NroHabitacion"].Value.ToString();

                var DialogResult = MessageBox.Show("Se pondrá en limpieza la habitación, ¿desea continuar?",
                    "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    new HabitacionBL().UpdateEstateHabitacionLimpieza(HospId, nroHabitacion);
                    CargarGrillaHabitaciones();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA PASAR A LIMPIEZA HABITACIÓN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnCerarHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsUpdateHabitacion = new HabitacionBL().UpdateEstateHabitacionByHospId(HospId);
                if (IsUpdateHabitacion)
                {
                    MessageBox.Show(
                        "El estado de la habitación será de 'En Limpieza', por favor dar aviso al personal correspondiente",
                        "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaHabitaciones();
                }
                else
                {
                    MessageBox.Show(
                        "Sucedió un error, por favor vuelva a intentar.",
                        "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA CERRAR HABITACIÓN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarExamenes_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();
                //ServiceId = grdServicios.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                if (ServiceId != "")
                {
                    var protocolId = grdServicios.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();

                    #region Conexion SAM

                    ConexionSigesoft conectasam = new ConexionSigesoft();
                    conectasam.opensigesoft();

                    #endregion

                    var cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + protocolId +
                                  "'";
                    SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                    SqlDataReader lector = comando.ExecuteReader();
                    string plan = "";
                    while (lector.Read())
                    {
                        plan = lector.GetValue(0).ToString();
                    }

                    lector.Close();
                    conectasam.closesigesoft();

                    var ListServiceComponent =
                        new ServiceBL().GetServiceComponents_New(ref objOperationResult, ServiceId);
                    ListaComponentes = new List<string>();
                    foreach (var item in ListServiceComponent)
                    {
                        ListaComponentes.Add(item.v_ComponentId);
                    }

                    if (plan != "")
                    {
                        var frm = new frmAddExam(ListaComponentes, "ASEGU", protocolId, "Asegu", HospId, Dni, ServiceId,
                            null) { _serviceId = ServiceId };
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            CargarGrillaExamenes(ServiceId);

                            CargarGrillaServicios();
                        }
                    }
                    else
                    {
                        var frm = new frmAddExam(ListaComponentes, "HOSPI", protocolId, "Hospi", HospId, Dni, ServiceId,
                            null) { _serviceId = ServiceId };
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            CargarGrillaExamenes(ServiceId);

                            CargarGrillaServicios();
                        }
                    }

                    CargarGrillaExamenes(ServiceId);

                    CargarGrillaServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA AGREGAR EXAMENES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnEditExamen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServiceId != "")
                {
                    var ServiceComponentId =
                        grdExamenes.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString();

                    Hospitalizacion.CargoExamen from = new Hospitalizacion.CargoExamen(ServiceComponentId);
                    from.ShowDialog();

                    CargarGrillaExamenes(ServiceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA EDITAR EXAMEN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            try
            {
                var ServiceComponentId = grdExamenes.Selected.Rows[0].Cells["v_ServiceComponentId"].Value == null
                    ? ""
                    : grdExamenes.Selected.Rows[0].Cells["v_ServiceComponentId"].Value.ToString();

                if (ServiceComponentId != "")
                {
                    #region CONSULTA

                    ConexionSigesoft conectasam_1 = new ConexionSigesoft();
                    conectasam_1.opensigesoft();
                    var cadena1_1 =
                        "select c.v_Name from [dbo].[servicecomponent] sc join [dbo].[component] c on sc.v_ComponentId = c.v_ComponentId  where sc.v_ServiceComponentId = '" +
                        ServiceComponentId + "'";
                    SqlCommand comando_1 = new SqlCommand(cadena1_1, connection: conectasam_1.conectarsigesoft);
                    SqlDataReader lector_1 = comando_1.ExecuteReader();
                    string Componente = "";
                    while (lector_1.Read())
                    {
                        Componente = lector_1.GetValue(0).ToString();
                    }

                    lector_1.Close();
                    conectasam_1.closesigesoft();

                    #endregion

                    DialogResult Result = MessageBox.Show("¿Está seguro de eliminar el servicio " + Componente + " ? ",
                        "ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (Result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ServiceId != "")
                        {
                            ConexionSigesoft conectasam = new ConexionSigesoft();
                            conectasam.opensigesoft();
                            var cadena1 =
                                "update [dbo].[servicecomponent] set i_IsRequiredId = 0 , i_IsDeleted  = 1 where v_ServiceComponentId = '" +
                                ServiceComponentId + "'";
                            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                            SqlDataReader lector = comando.ExecuteReader();
                            lector.Close();
                            conectasam.closesigesoft();


                            CargarGrillaExamenes(ServiceId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA ELIMINAR EXAMEN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServiceId != "")
                {
                    var protocolId = grdServicios.Selected.Rows[0].Cells["v_ProtocolId"].Value.ToString();

                    #region Conexion SAM Obtener Plan

                    ConexionSigesoft conectasam = new ConexionSigesoft();
                    conectasam.opensigesoft();
                    var cadena1 = "select PL.i_PlanId from [dbo].[plan] PL where PL.v_ProtocoloId ='" + protocolId +
                                  "'";
                    SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                    SqlDataReader lector = comando.ExecuteReader();
                    string plan = "";
                    while (lector.Read())
                    {
                        plan = lector.GetValue(0).ToString();
                    }

                    lector.Close();
                    conectasam.closesigesoft();
                    string modoMasterService;
                    if (plan != "")
                    {
                        modoMasterService = "ASEGU";
                    }
                    else
                    {
                        modoMasterService = "HOSPI";
                    }

                    #endregion

                    // construir formulario ticket
                    frmTicket ticket = new frmTicket(_tempTicket, ServiceId, string.Empty, "New", protocolId,
                        modoMasterService);
                    ticket.ShowDialog();

                    CargarGrillaTickets(ServiceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA AGREGAR TICKET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnEditarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult objOperationResult = new OperationResult();
                if (ServiceId != "")
                {
                    var ticketId = grdTickets.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();

                    #region Conexion SAM

                    ConexionSigesoft conectasam = new ConexionSigesoft();
                    conectasam.opensigesoft();

                    #endregion

                    var cadena1 =
                        "select PL.i_PlanId from service SR inner join protocol PR on SR.v_ProtocolId = PR.v_ProtocolId inner join [dbo].[plan] PL on PR.v_ProtocolId = PL.v_ProtocoloId where SR.v_ServiceId ='" +
                        ServiceId + "'";
                    SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                    SqlDataReader lector = comando.ExecuteReader();
                    string plan = "";
                    string protocolId = "";
                    while (lector.Read())
                    {
                        plan = lector.GetValue(0).ToString();
                    }

                    lector.Close();
                    conectasam.closesigesoft();
                    ServiceList personData = oServiceBL.GetServicePersonData(ref objOperationResult, ServiceId);
                    string modoMasterService;
                    if (plan != "")
                    {
                        modoMasterService = "ASEGU";
                    }
                    else
                    {
                        modoMasterService = "HOSPI";
                    }

                    _ticketId = ticketId;
                    frmTicket ticket = new frmTicket(_tempTicket, ServiceId, _ticketId, "Edit", personData.v_ProtocolId,
                        modoMasterService);
                    ticket.ShowDialog();

                    CargarGrillaTickets(ServiceId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA EDITAR TICKET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("¿Está seguro de eliminar el ticket?", "ADVERTENCIA!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (ServiceId != "")
                    {
                        OperationResult objOperationResult = new OperationResult();
                        TicketBL oTicketBL = new TicketBL();

                        //ServiceId = grdServicios.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();
                        var ticketId = grdTickets.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();

                        oTicketBL.DeleteTicket(ticketId, Globals.ClientSession.GetAsList());

                        CargarGrillaTickets(ServiceId);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA ELIMINAR TICKET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            try
            {
                OperationResult _objOperationResult = new OperationResult();
                using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
                {
                    this.Enabled = false;

                    var MedicalCenter = oServiceBL.GetInfoMedicalCenter();

                    var ticketId = grdTickets.Selected.Rows[0].Cells["v_TicketId"].Value.ToString();

                    var lista = _hospitBL.BuscarTicketsDetalle(ticketId);

                    //var serviceId = lista.SelectMany(p => p.Servicios.Select(q=>q.v_ServiceId));
                    //int doctor = 1;
                    Ticket = _hospitBL.GetHospitServTicket(ticketId);
                    hospser = _hospitBL.GetHospitServwithTicekt(Ticket.v_ServiceId);

                    serv = _hospitBL.GetService(Ticket.v_ServiceId);
                    prot = _hospitBL.GetProtocol(serv.v_ProtocolId);

                    var datosP = _pacientBL.DevolverDatosPaciente(Ticket.v_ServiceId);

                    string ruta = Common.Utils.GetApplicationConfigValue("rutaTicketConsumo").ToString();
                    ServiceList personData =
                        oServiceBL.GetServicePersonData(ref _objOperationResult, hospser.v_ServiceId);

                    var hospitalizacion =
                        _hospitBL.GetHospitalizacion(ref _objOperationResult, hospser.v_HopitalizacionId);
                    var hospitalizacionhabitacion =
                        _hospitBL.GetHospitalizacionHabitacion(ref _objOperationResult, hospser.v_HopitalizacionId);
                    var medicoTratante = new ServiceBL().GetMedicoTratante(Ticket.v_ServiceId);

                    string nombre = "Ticket N° " + ticketId + "_" + personData.v_DocNumber;

                    TicketHospitalarioCSM.CrearTicketConsumo(ruta + nombre + ".pdf", MedicalCenter, lista, datosP, hospitalizacion,
                        hospitalizacionhabitacion, medicoTratante, Ticket, prot);

                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR PARA IMPRIMIR TICKET", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private List<HospitalizacionHabitacionList> GetHabitaciones()
        //{
            //_objHabitaciones = _hospitBL.BuscarHospitalizacionHabitaciones(HospId).ToList();
            //return _objHabitaciones;
        //}

        //private List<HospitalizacionServiceListNew> GetServicios()
        //{
        //    List<HospitalizacionServiceListNew> servicios = _hospitBL.BuscarServiciosHospitalizacionNew(HospId).ToList();
        //    return servicios;
        //}

        private void CargarGrillaTickets(string serviceId)
        {
            objDataTickets = GetTickets(serviceId);
            grdTickets.DataSource = objDataTickets;
        }

        private List<TicketList> GetTickets(string ServiceId)
        {
            var ticketss = _hospitBL.BuscarTickets(ServiceId).ToList();

            return ticketss;
        }

        private void grdServicios_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            ServiceId = grdServicios.Selected.Rows[0].Cells["v_ServiceId"].Value.ToString();

            CargarGrillaExamenes(ServiceId);

            CargarGrillaTickets(ServiceId);
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            try
            {   
                if (txtCie10.Text == "- - -" || txtCie10.Text == string.Empty)
                {
                    MessageBox.Show("Para brindar ALTA MÉDICA, favor de completar el Dx de Ingreso del Paciente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtCie10_Salida.Text == "- - -" || txtCie10_Salida.Text == string.Empty)
                {
                    MessageBox.Show("Para brindar ALTA MÉDICA, favor de completar el Dx de Salida del Paciente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                DateTime? fechaAlta_ = (DateTime?)(fechaAlta == "" ? (ValueType)null
                    : DateTime.Parse(fechaAlta));

                var comentario = Comentarios == null ? "" : Comentarios;
                var frm = new frmDarAlta(HospId, "Edit", fechaAlta_, comentario);
                frm.ShowDialog();

                ActualizacionHospitalizacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE PUEDE DAR DE ALTA - YA ASIGNADO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizacionHospitalizacion()
        {
            var resultadoDx = _hospitBL.GetHospitalizacionDx(HospId);

            txtCie10.Text = resultadoDx.v_CIEIdIngreso == null ? "" : resultadoDx.v_CIEIdIngreso;
            txtDx.Text = resultadoDx.v_DxIngreso == null ? "" : resultadoDx.v_DxIngreso;

            txtCie10_Salida.Text = resultadoDx.v_CIEIdSalida == null ? "" : resultadoDx.v_CIEIdSalida;
            txtDx_Salida.Text = resultadoDx.v_DxSalida == null ? "" : resultadoDx.v_DxSalida;

            txtHoraSalaInic.Text = resultadoDx.d_FechaHoraInicioSop == null ? "" : resultadoDx.d_FechaHoraInicioSop.Value.ToShortTimeString();
            txtHoraSalaFin.Text = resultadoDx.d_FechaHoraFinSop == null ? "" : resultadoDx.d_FechaHoraFinSop.Value.ToShortTimeString();

            Cie10 = txtCie10.Text;
            Dx = txtDx.Text;

            Cie10S = txtCie10_Salida.Text;
            DxS = txtDx_Salida.Text;

            fechaAlta = resultadoDx.d_FechaAlta == null ? "" : resultadoDx.d_FechaAlta.ToString();

            #region Conexion SAM
            ConexionSigesoft conectasam = new ConexionSigesoft();
            conectasam.opensigesoft();
            #endregion

            var cadena1 = "select ISNULL(CONVERT(varchar, i_ProcedimientoSOP),'- - -'), ISNULL(v_ProcedimientoSOP,'- - -') from hospitalizacion where v_HopitalizacionId='" + HospId + "'";
            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                txtIdProcedimiento.Text = lector.GetValue(0).ToString();
                txtProcedimiento.Text = lector.GetValue(1).ToString();
            }
            lector.Close();
            conectasam.closesigesoft();


            ValidacionBotones();
        }

        public hospitalizacionDto GetHospitalizacionDx(string v_HospitalizacionId)
        {
            //mon.IsActive = true;
            try
            {
                SigesoftEntitiesModel dbContext = new SigesoftEntitiesModel();
                hospitalizacionDto objDtoEntity = null;

                var objEntity = (from a in dbContext.hospitalizacion
                                 where a.v_HopitalizacionId == v_HospitalizacionId
                                 select a).FirstOrDefault();

                if (objEntity != null)
                    objDtoEntity = hospitalizacionAssembler.ToDTO(objEntity);

                return objDtoEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void btnDx_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarDx(HospId, "DxE");
            frm.ShowDialog();

            ActualizacionHospitalizacion();
        }

        private void btnDxSalida_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarDx(HospId, "DxS");
            frm.ShowDialog();

            ActualizacionHospitalizacion();
        }

        private void btnHorasSala_Click(object sender, EventArgs e)
        {
            var frm = new frmEditatarHorasSOP(HospId);
            frm.ShowDialog();

            ActualizacionHospitalizacion();
        }

        private void btnProcedimientoHosp_Click(object sender, EventArgs e)
        {
            var frm = new frmAddEditProcedimientos(HospId, txtProcedimiento.Text, txtIdProcedimiento.Text);
            frm.ShowDialog();

            ActualizacionHospitalizacion();
        }

    }
}
