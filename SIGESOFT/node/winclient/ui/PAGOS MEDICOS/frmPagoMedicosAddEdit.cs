using Infragistics.Win.UltraWinGrid;
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

namespace Sigesoft.Node.WinClient.UI.PAGOS_MEDICOS
{
    public partial class frmPagoMedicosAddEdit : Form
    {
        ServiceBL oServiceBL = new ServiceBL();
        OperationResult objOperationResult = new OperationResult();
        HospitalizacionBL oHospitalizacionBL = new HospitalizacionBL();
        private string _IdConfPago;

        List<LiquidacionMedicoListPay> _LiquidacionMedicoListPay = new List<LiquidacionMedicoListPay>();

        public frmPagoMedicosAddEdit()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            //List<string> Componentes = new List<string>();
            //var listServicecomponents = oServiceBL.GetServiceComponentsConfig(ref objOperationResult);
            //foreach (var obj in listServicecomponents)
            //{
            //    Componentes.Add(obj.v_ComponentId);
            //}

            var frm = new frmConfiguracionPagos(null, "New", null);
            frm.ShowDialog();
            BindGrid("");
        }

        private void frmPagoMedicosAddEdit_Load(object sender, EventArgs e)
        {


            Utils.LoadDropDownList(ddlUsuarioConf, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);
            Utils.LoadDropDownList(ddlUsuario, "Value1", "Id", BLL.Utils.GetProfessional(ref objOperationResult, ""), DropDownListAction.Select);

            Utils.LoadDropDownList(ddlServiceTypeId, "Value1", "Id", BLL.Utils.GetSystemParameterByParentIdForCombo(ref objOperationResult, 119, -1, null), DropDownListAction.Select);
            ddlServiceTypeId.SelectedIndex = 2;

        }

        string strFilterExpression;
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Filters = new List<string>();
            if (ddlUsuario.SelectedValue.ToString() != "-1")
                Filters.Add("i_SystemUserId ==" + ddlUsuario.SelectedValue);

            strFilterExpression = null;
            if (Filters.Count > 0)
            {
                foreach (string item in Filters)
                {
                    strFilterExpression = strFilterExpression + item + " && ";
                }
                strFilterExpression = strFilterExpression.Substring(0, strFilterExpression.Length - 4);
            }

            BindGrid(strFilterExpression);
        }

        private void BindGrid(string strFilterExpression)
        {
            var data = oHospitalizacionBL.GetMedicosConfiguracionPago(strFilterExpression);
            ultraGrid3.DataSource = data;
        }

        private void ultraGrid3_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            foreach (UltraGridRow rowSelected in this.ultraGrid3.Selected.Rows)
            {
                btnEditar.Enabled =
                btnEliminar.Enabled =

                (ultraGrid3.Selected.Rows.Count > 0);

                if (ultraGrid3.Selected.Rows.Count == 0)
                    return;

                _IdConfPago = ultraGrid3.Selected.Rows[0].Cells["v_IdConfPago"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ultraGrid3.Selected.Rows.Count > 0)
            {
                _IdConfPago = ultraGrid3.Selected.Rows[0].Cells["v_IdConfPago"].Value.ToString();

                var frm = new frmConfiguracionPagos(null, "Edit", _IdConfPago);
                frm.ShowDialog();

                BindGrid("");
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "VALIDACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (new LoadingClass.PleaseWait(this.Location, "Generando..."))
            {
                this.BindGridConfMed();
            };
        }
        private void BindGridConfMed()
        {
            DateTime pdatBeginDate = dtpDateTimeStar.Value.Date;
            DateTime pdatEndDate = dptDateTimeEnd.Value.Date.AddDays(1);

            HospitalizacionBL o = new HospitalizacionBL();
            if (ddlUsuario.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Debe elegir un Medico para filtrar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            _LiquidacionMedicoListPay = o.GetListServicesPay_SP(pdatBeginDate, pdatEndDate, int.Parse(ddlUsuario.SelectedValue.ToString()), 0);
            grdData.DataSource = _LiquidacionMedicoListPay;

            //////////// turno
            var listaPagoTurno = o.ObtenerConfPagoTurno(int.Parse(ddlUsuario.SelectedValue.ToString()), 1);

            if (listaPagoTurno.Count != 0)
            {
                var _LiquidacionMedicoListPayTurno = _LiquidacionMedicoListPay.FindAll(p => p.GrupoId != 0);

                var _LiquidacionMedicoListPayTurnoList = _LiquidacionMedicoListPayTurno.AsEnumerable()
                        .Where(a => a.v_ServiceId != null)
                        .GroupBy(b => b.d_ServiceDate.Value.ToShortDateString())
                        .Select(group => group.First());

                 List<LiquidacionMedicoListPay> _LiquidacionMedicoListPayTurnoN = new List<LiquidacionMedicoListPay>(); 

                foreach (var item in _LiquidacionMedicoListPayTurnoList)
                {
                    var _ObjList = _LiquidacionMedicoListPay.AsEnumerable()
                        .Where(a => a.v_ServiceId  == item.v_ServiceId)
                        .GroupBy(b => b.v_ServiceId)
                        .Select(group => group.First());

                    foreach (var item2 in _ObjList)
                    {
                        _LiquidacionMedicoListPayTurnoN.Add(item2);
                    }
                }
                List<DetallePagoTurno> DetallePagoTurnoLit = new List<DetallePagoTurno>();
                foreach (var item in _LiquidacionMedicoListPayTurnoN)
                {
                    DetallePagoTurno DetallePagoTurnoObj = new DetallePagoTurno();
                    DetallePagoTurnoObj.Fecha = item.d_ServiceDate.Value;
                    DetallePagoTurnoObj.Grupo = item.Grupo;
                    foreach (var item2 in listaPagoTurno)
                    {
                        DetallePagoTurnoObj.Monto = decimal.Parse(item2.d_MontoxTurno.ToString());
                    }
                    DetallePagoTurnoLit.Add(DetallePagoTurnoObj);

                }
                grdPagosTurno.DataSource = DetallePagoTurnoLit;
            }

            //////////// HORA
            var listaPagoHORA = o.ObtenerConfPagoTurno(int.Parse(ddlUsuario.SelectedValue.ToString()), 2);

            if (listaPagoHORA.Count != 0)
            {
                var listaPagoHORAObj = listaPagoHORA[0];


                var _LiquidacionMedicoListPayHORA = _LiquidacionMedicoListPay.FindAll(p => p.GrupoId != 0);

                var _LiquidacionMedicoListPayHORAList = _LiquidacionMedicoListPayHORA.AsEnumerable()
                       .Where(a => a.v_ServiceId != null)
                       .GroupBy(b => b.d_ServiceDate.Value.ToShortDateString())
                       .Select(group => group.First());

                List<LiquidacionMedicoListPay> _LiquidacionMedicoListPayHORAN = new List<LiquidacionMedicoListPay>();

                foreach (var item in _LiquidacionMedicoListPayHORAList)
                {
                    var objSp = o.ObtenerSpTurno(item.GrupoId.Value);

                    var hora1 = DateTime.Parse(objSp.First().Value1.Split('-')[0].Trim());

                    var hora2 = DateTime.Parse(objSp.OrderByDescending(x => x.ParameterId).First().Value1.Split('-')[1].Trim());

                    //double horas = Math.Round(hora2.Subtract(hora1).TotalMinutes, 1);

                    TimeSpan horas = hora2.Subtract(hora1);
                    if (hora1.Hour <= 10 && hora2.Hour >= 14)
                    {
                        if (listaPagoHORAObj.i_TipoDescuentoHoraMin == 1)
                        {
                            TimeSpan _horas = TimeSpan.FromHours(-listaPagoHORAObj.i_DesucuentodeHorario.Value);
                            horas = horas.Add(_horas);
                        }
                        else
                        {
                            TimeSpan _minutos = TimeSpan.FromMinutes(-listaPagoHORAObj.i_DesucuentodeHorario.Value);
                            horas = horas.Add(_minutos);
                        }
                    }
     
                    var _ObjList = _LiquidacionMedicoListPay.AsEnumerable()
                        .Where(a => a.v_ServiceId == item.v_ServiceId)
                        .GroupBy(b => b.v_ServiceId)
                        .Select(group => group.First());

                    foreach (var item2 in _ObjList)
                    {
                        item2.horas = double.Parse(horas.Hours.ToString());
                        item2.minutos = double.Parse(horas.Minutes.ToString());

                        _LiquidacionMedicoListPayHORAN.Add(item2);
                    }
                }
                List<DetallePagoTurno> DetallePagoHoraLit = new List<DetallePagoTurno>();
                foreach (var item in _LiquidacionMedicoListPayHORAN)
                {
                    DetallePagoTurno DetallePagoTurnoObj = new DetallePagoTurno();
                    DetallePagoTurnoObj.Fecha = item.d_ServiceDate.Value;
                    DetallePagoTurnoObj.Grupo = item.Grupo;
                    DetallePagoTurnoObj.horas = item.horas;
                    DetallePagoTurnoObj.minutos = item.minutos;

                    DetallePagoTurnoObj.Tiempo = "H: " + item.horas.ToString() + " - M:" + item.minutos.ToString();
                    decimal montMin = 0;

                    var costMin = decimal.Parse(listaPagoHORAObj.d_MonoxHora.ToString()) / 60;

                    montMin = costMin * (decimal)item.minutos;
                    DetallePagoTurnoObj.Monto = decimal.Parse(listaPagoHORAObj.d_MonoxHora.ToString());
                    DetallePagoTurnoObj.Total = (decimal.Parse(listaPagoHORAObj.d_MonoxHora.ToString()) * (decimal)item.horas) + montMin;

                    DetallePagoHoraLit.Add(DetallePagoTurnoObj);

                }
                grdPagosHora.DataSource = DetallePagoHoraLit; 
            }
            


            //////////// EXAMEN
            var listaPagoEXAMEN = o.ObtenerConfPagoTurno(int.Parse(ddlUsuario.SelectedValue.ToString()), 3);
            if (listaPagoEXAMEN.Count != 0)
            {
                var listaPagoEXAMENObj = listaPagoEXAMEN[0];


                var _LiquidacionMedicoListPayEXAMEN = _LiquidacionMedicoListPay.FindAll(p => p.GrupoId == 0);

                List<LiquidacionMedicoListPay> _LiquidacionMedicoListPayEXAMENN = new List<LiquidacionMedicoListPay>();

                foreach (var item in listaPagoEXAMEN)
                {
                    var obj = _LiquidacionMedicoListPay.FindAll(p => p.Componente == item.Examen);

                    foreach (var item2 in obj)
                    {
                        var _ObjList = _LiquidacionMedicoListPay.AsEnumerable()
                        .Where(a => a.v_ServiceId == item2.v_ServiceId)
                        .GroupBy(b => b.v_ServiceId)
                        .Select(group => group.First());

                        foreach (var item3 in _ObjList)
                        {
                            _LiquidacionMedicoListPayEXAMENN.Add(item3);
                        }
                    }
                }



                List<DetallePagoeEXAMEN> DetallePagoEXAMENLit = new List<DetallePagoeEXAMEN>();
                foreach (var item in _LiquidacionMedicoListPayEXAMENN)
                {
                    DetallePagoeEXAMEN DetallePagoTurnoObj = new DetallePagoeEXAMEN();
                    DetallePagoTurnoObj.Fecha = item.d_ServiceDate.Value;
                    DetallePagoTurnoObj.Examen = item.Componente;
                    DetallePagoTurnoObj.TipoComprobante = item.TipoComprobante;
                    DetallePagoTurnoObj.Comprobante = item.Comprobante;
                    DetallePagoTurnoObj.Monto = item.d_Total.Value;
                    DetallePagoTurnoObj.TipoMed = "TRATANTE";


                    DetallePagoTurnoObj.DescIgv_Bol = listaPagoEXAMENObj.i_DescontarBoletaExam == 1 ? "X" : "";
                    DetallePagoTurnoObj.DescIgv_Fac = listaPagoEXAMENObj.i_DescontarFactExam == 1 ? "X" : "";
                    DetallePagoTurnoObj.DescIgv_Rec = listaPagoEXAMENObj.i_DescontarRecbExam == 1 ? "X" : "";

                    if (item.TipoComprobante == "BOLETA")
                    {
                        if (listaPagoEXAMENObj.i_DescontarBoletaExam == 1)
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value / decimal.Parse("1.18")) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }
                        else
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }


                    }
                    else if (item.TipoComprobante == "FACTURA")
                    {
                        if (listaPagoEXAMENObj.i_DescontarFactExam == 1)
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value / decimal.Parse("1.18")) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }
                        else
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }
                    }

                    else if (item.TipoComprobante == "RECIBO")
                    {
                        if (listaPagoEXAMENObj.i_DescontarRecbExam == 1)
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value / decimal.Parse("1.18")) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }
                        else
                        {
                            DetallePagoTurnoObj.PagMed = decimal.Round(((item.d_Total.Value) * decimal.Parse(listaPagoEXAMENObj.d_PorcMedicoExam.ToString()) / 100), 2);

                        }
                    }

                    DetallePagoEXAMENLit.Add(DetallePagoTurnoObj);

                }
                grdPagosExamen.DataSource = DetallePagoEXAMENLit;
            }
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OperationResult objOperationResult1 = new OperationResult();
            _IdConfPago = ultraGrid3.Selected.Rows[0].Cells["v_IdConfPago"].Value.ToString();

            oHospitalizacionBL.DeleteConfHorario(ref objOperationResult1, _IdConfPago, Globals.ClientSession.GetAsList());

            MessageBox.Show("Se eliminó correctamente", "INFORMACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BindGrid("");

        }
    }
}
