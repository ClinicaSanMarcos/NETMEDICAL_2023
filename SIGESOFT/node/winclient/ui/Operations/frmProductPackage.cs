using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE;
using Sigesoft.Node.WinClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI.Operations
{
    public partial class frmProductPackage : Form
    {
        public string productPackageId = null;
        private TicketBL _ticketlBL = new TicketBL();
        public List<TicketDetalleList> _TempTicketDetalleList = null;
        TicketDetalleList _objTicketDetalleList = null;
        private string _protocolId; 
        private string _serviceId;
        public frmProductPackage(string protocolId, string serviceId)
        {
            _serviceId = serviceId;
            _protocolId = protocolId;
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            var data = new ProductPackageBL().GetDataProductPackage(txtValue.Text);
            grdProductPackage.DataSource = data;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductPackageDetail frm = new frmProductPackageDetail("New", "");
            frm.ShowDialog();
            BindingGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdProductPackage.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var id = grdProductPackage.Selected.Rows[0].Cells["v_ProductPackageId"].Value.ToString();
            frmProductPackageDetail frm = new frmProductPackageDetail("Edit", id);
            frm.ShowDialog();
            BindingGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdProductPackage.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialog = MessageBox.Show("¿ Desea eliminar el paquete completo ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                var id = grdProductPackage.Selected.Rows[0].Cells["v_ProductPackageId"].Value.ToString();
                bool ok = new ProductPackageBL().DeletedPackage(id);
                if (ok)
                {
                    MessageBox.Show("Se eliminó correctamente.", "HECHO", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "VALIDACIÓN", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void grdProductPackage_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnImprimir.Enabled = true;
        }

        private void grdProductPackage_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {

            productPackageId = grdProductPackage.Selected.Rows[0].Cells["v_ProductPackageId"].Value.ToString();

            var listProd = new ProductPackageBL().GetProductsByPackageId(productPackageId);
            List<string> listaUsados = new List<string>();

            ConexionSigesoft conectasampl = new ConexionSigesoft();
            conectasampl.opensigesoft();

            #region Colocar el Plan en el combo y bloquearlo
            var cadenapl = "select SR.i_PlanId, PL.v_IdUnidadProductiva, LN.v_Nombre " +
                          "from service SR " +
                          "inner join [dbo].[plan] PL on SR.v_ProtocolId=PL.v_ProtocoloId and SR.i_PlanId=PL.i_PlanId " +
                          "inner join [20505310072].[dbo].[linea] LN on PL.v_IdUnidadProductiva= LN.v_IdLinea " +
                          "where v_ServiceId = '" + _serviceId + "' and SR.i_PlanId <> ''";
            SqlCommand comandopl = new SqlCommand(cadenapl, connection: conectasampl.conectarsigesoft);
            SqlDataReader lectorpl = comandopl.ExecuteReader();
            string i_PlanId, v_IdUnidadProductiva, v_Nombre = "";
            bool resultPlan = false;
            while (lectorpl.Read())
            {
                i_PlanId = lectorpl.GetValue(0).ToString();
                v_IdUnidadProductiva = lectorpl.GetValue(1).ToString();
                v_Nombre = lectorpl.GetValue(2).ToString();
                resultPlan = true;
            }
            lectorpl.Close();
            conectasampl.closesigesoft();
            #endregion

            frmPlan planForm = new frmPlan(_protocolId, v_Nombre);
            planForm.ShowDialog();
            
            
            string lineId = planForm.lineId;


            #region Conexion SIGESOFT Obtener Porcentaje de descuento EPS
            ConexionSigesoft conectasamdes = new ConexionSigesoft();
            conectasamdes.opensigesoft();
            var cadenades = "select PR.r_MedicineDiscount from protocol PR inner join organization OO on PR.v_CustomerOrganizationId = OO.v_OrganizationId where PR.v_ProtocolId='" + _protocolId + "'";
            SqlCommand comandodes = new SqlCommand(cadenades, connection: conectasamdes.conectarsigesoft);
            SqlDataReader lectordes = comandodes.ExecuteReader();
            string EPS = "";
            while (lectordes.Read())
            {
                EPS = lectordes.GetValue(0).ToString();
            }
            lectordes.Close();
            conectasamdes.closesigesoft();
            #endregion

            foreach (var item in listProd)
            {
                TicketBL oTicketBL = new TicketBL();
                if (_TempTicketDetalleList == null)
                {
                    _TempTicketDetalleList = new List<TicketDetalleList>();
                }
                OperationResult objOperationResult = new OperationResult();

                string[] componentIdFromProtocol = _TempTicketDetalleList.FindAll(p => p.i_RecordStatus != (int)RecordStatus.EliminadoLogico)
                    .Select(p => p.v_IdProductoDetalle).ToArray();

                bool IsExists = _ticketlBL.IsExistsproductoInTicket(ref objOperationResult, componentIdFromProtocol, item.v_IdProductoDetalle);

                if (IsExists)
                {
                    listaUsados.Add(item.v_NombreProducto);
                    continue; 
                }

                var findResult = _TempTicketDetalleList.Find(p => p.v_IdProductoDetalle == item.v_IdProductoDetalle);
                _objTicketDetalleList = new TicketDetalleList();

                if (findResult == null)
                {
                    _objTicketDetalleList.v_TicketDetalleId = Guid.NewGuid().ToString();

                    _objTicketDetalleList.v_IdProductoDetalle = item.v_IdProductoDetalle;
                    _objTicketDetalleList.v_NombreProducto = item.v_NombreProducto;
                    _objTicketDetalleList.v_CodInterno = item.v_CodInterno;
                    _objTicketDetalleList.v_IdUnidadProductiva = item.v_IdUnidadProductiva;
                    decimal d;
                    _objTicketDetalleList.d_Cantidad = decimal.TryParse(item.d_Cantidad.ToString(), out d) ? d : 0;
                    var tienePlan = false;
                    var resultplan = oTicketBL.TienePlan(_protocolId, lineId);

                    if (resultplan.Count > 0) tienePlan = true;
                    else tienePlan = false;


                    if (tienePlan)
                    {
                        if (resultplan[0].i_EsCoaseguro == 1)
                        {
                            #region Conexion SIGESOFT verificar la unidad productiva del componente
                            ConexionSigesoft conectasam = new ConexionSigesoft();
                            conectasam.opensigesoft();
                            var cadena1 = "select PL.d_ImporteCo, PL.i_PlanId " +
                                          "from [dbo].[plan] PL " +
                                          "inner join protocol PR on PL.v_ProtocoloId=PR.v_ProtocolId " +
                                          "where PR.v_ProtocolId='" + _protocolId + "' and PL.v_IdUnidadProductiva='" + lineId + "'";
                            SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                            SqlDataReader lector = comando.ExecuteReader();
                            string ImporteCo = ""; string PlanId = "";
                            bool lectorleido = false;
                            while (lector.Read())
                            {
                                ImporteCo = lector.GetValue(0).ToString();
                                PlanId = lector.GetValue(1).ToString();
                                lectorleido = true;
                            }

                            if (lectorleido == false)
                            {
                                MessageBox.Show(@"Elija un Examen que tenga Plan de Seguros", @"Error de validación", MessageBoxButtons.OK);
                                return;
                            }
                            lector.Close();

                            #endregion

                            _objTicketDetalleList.d_SaldoPaciente = decimal.Round((decimal.Parse(item.d_PrecioMayorista.ToString())), 2) * decimal.Round((decimal.Parse(item.d_Cantidad.ToString())), 2) * decimal.Round((decimal.Parse(ImporteCo)), 2) / 100;
                            _objTicketDetalleList.d_SaldoAseguradora = decimal.Round((decimal.Parse(item.d_PrecioMayorista.ToString())), 2) * decimal.Round((decimal.Parse(item.d_Cantidad.ToString())), 2) - _objTicketDetalleList.d_SaldoPaciente;
                            _objTicketDetalleList.d_PrecioVenta = (decimal.Round((item.d_PrecioMayorista - (item.d_PrecioMayorista * decimal.Parse(EPS)) / 100), 2)); 

                            #region Update a service agrega el PlanId
                            var cadena2 = "update service set " +
                                          "i_PlanId = '" + PlanId + "' " +
                                          "where v_ServiceId = '" + _serviceId + "' ";
                            SqlCommand comando_ = new SqlCommand(cadena2, connection: conectasam.conectarsigesoft);
                            SqlDataReader lector_ = comando_.ExecuteReader();
                            lector_.Close();

                            conectasam.closesigesoft();
                            #endregion

                        }
                    }
                    else
                    {
                        _objTicketDetalleList.d_PrecioVenta = decimal.Round((decimal.Parse(item.d_PrecioVenta.ToString())), 2);
                    }
                    _objTicketDetalleList.i_RecordStatus = (int)RecordStatus.Agregado;
                    _objTicketDetalleList.i_RecordType = (int)RecordType.Temporal;
                    _TempTicketDetalleList.Add(_objTicketDetalleList);
                }
                else
                {
                    if (findResult.i_RecordStatus == (int)RecordStatus.EliminadoLogico)
                    {
                        if (findResult.i_RecordType == (int)RecordType.NoTemporal)
                        {
                            _objTicketDetalleList.v_IdProductoDetalle = item.v_IdProductoDetalle;
                            _objTicketDetalleList.v_NombreProducto = item.v_NombreProducto;
                            _objTicketDetalleList.v_CodInterno = item.v_CodInterno;
                            _objTicketDetalleList.v_IdUnidadProductiva = item.v_IdUnidadProductiva;
                            var precioTarifa = oTicketBL.ObtenerPrecioTarifario(_serviceId, _objTicketDetalleList.v_IdProductoDetalle);
                            _objTicketDetalleList.d_PrecioVenta = precioTarifa;
                            decimal d;
                            _objTicketDetalleList.d_Cantidad = decimal.TryParse(item.d_Cantidad.ToString(), out d) ? d : 0;

                            var tienePlan = false;
                            var resultplan = oTicketBL.TienePlan(_protocolId, item.v_IdUnidadProductiva);
                            if (resultplan.Count > 0) tienePlan = true;
                            else tienePlan = false;

                            if (tienePlan)
                            {
                                if (resultplan[0].i_EsCoaseguro == 1)
                                {
                                    _objTicketDetalleList.d_SaldoPaciente = resultplan[0].d_Importe;
                                    _objTicketDetalleList.d_SaldoAseguradora = (decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad) - resultplan[0].d_Importe;
                                }
                                if (resultplan[0].i_EsDeducible == 1)
                                {
                                    _objTicketDetalleList.d_SaldoPaciente = resultplan[0].d_Importe * decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad / 100;
                                    _objTicketDetalleList.d_SaldoAseguradora = (decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad) - _objTicketDetalleList.d_SaldoPaciente;
                                }
                            }

                            findResult.i_RecordStatus = (int)RecordStatus.Grabado;
                        }
                        else if (findResult.i_RecordType == (int)RecordType.Temporal)
                        {
                            _objTicketDetalleList.v_IdProductoDetalle = item.v_IdProductoDetalle;
                            _objTicketDetalleList.v_NombreProducto = item.v_NombreProducto;
                            _objTicketDetalleList.v_CodInterno = item.v_CodInterno;
                            _objTicketDetalleList.d_PrecioVenta = decimal.Parse(item.d_PrecioMayorista.ToString());
                            _objTicketDetalleList.v_IdUnidadProductiva = item.v_IdUnidadProductiva;
                            decimal d;
                            _objTicketDetalleList.d_Cantidad = decimal.TryParse(item.d_Cantidad.ToString(), out d) ? d : 0;

                            var tienePlan = false;
                            var resultplan = oTicketBL.TienePlan(_protocolId, item.v_IdUnidadProductiva);
                            if (resultplan.Count > 0) tienePlan = true;
                            else tienePlan = false;

                            if (tienePlan)
                            {
                                if (resultplan[0].i_EsCoaseguro == 1)
                                {
                                    _objTicketDetalleList.d_SaldoPaciente = resultplan[0].d_Importe;
                                    _objTicketDetalleList.d_SaldoAseguradora = (decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad) - resultplan[0].d_Importe;
                                }
                                if (resultplan[0].i_EsDeducible == 1)
                                {
                                    _objTicketDetalleList.d_SaldoPaciente = resultplan[0].d_Importe * decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad / 100;
                                    _objTicketDetalleList.d_SaldoAseguradora = (decimal.Parse(_objTicketDetalleList.d_PrecioVenta.ToString()) * _objTicketDetalleList.d_Cantidad) - _objTicketDetalleList.d_SaldoPaciente;
                                }
                            }

                            _objTicketDetalleList.i_RecordType = (int)RecordType.Temporal;

                            findResult.i_RecordStatus = (int)RecordStatus.Agregado;
                        }

                    }
                }

                

            }

            if (listaUsados.Count > 0)
            {
                var res = String.Join(", ", listaUsados.ToArray());
                var msj = string.Format("El ticket ya contiene los siguientes medicamentos que no fueron agregados: " + res);
                MessageBox.Show(msj, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            this.Close();
        }

    }
}
