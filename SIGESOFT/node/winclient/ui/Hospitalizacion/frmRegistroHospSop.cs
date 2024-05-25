using Infragistics.Win.Misc;
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

namespace Sigesoft.Node.WinClient.UI.Hospitalizacion
{
    public partial class frmRegistroHospSop : Form
    {
        private List<HospitalizacionHabitacionList> _objHabitaciones = new List<HospitalizacionHabitacionList>();
        private List<HospitalizacionHabitacionList> objDataHabitaciones = new List<HospitalizacionHabitacionList>();
        //private List<HospitalizacionServiceListNew> objDataServicios = new List<HospitalizacionServiceListNew>();
        //private List<ServiceComponentListNew> objDataComponentes = new List<ServiceComponentListNew>();
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
            txtHosp.Text = Hosp;
            txtSop.Text = Sop;

            CargarGrillaHabitaciones();

            CargarGrillaServicios();



            if (Sop == "SI")
            {
                btnHorasSala.Enabled = true;
            }
            else
            {
                btnHorasSala.Enabled = false;

            }
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
            //objDataHabitaciones = GetHabitaciones();
            //grdHabitaciones.DataSource = objDataHabitaciones;
        }

        private void CargarGrillaServicios()
        {
            //objDataServicios = GetServicios();
            //grdServicios.DataSource = objDataServicios;
            //grdServiciosSegHosp.DataSource = objDataServicios;
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
    }
}
