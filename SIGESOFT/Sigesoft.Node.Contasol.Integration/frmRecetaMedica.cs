using Sigesoft.Node.WinClient.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.UI.Reports;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

using Utils = Sigesoft.Node.WinClient.BLL.Utils;
using System.Data;
using Sigesoft.Node.Contasol.Integration.Contasol.Models;
using Sigesoft.Node.WinClient.UI.Operations.Popups;
using System.Drawing;

namespace Sigesoft.Node.Contasol.Integration
{
    public partial class frmRecetaMedica : Form
    {
        private string _serviceId;
        private OperationResult _pobjOperationResult;
        private readonly RecetaBl _objRecetaBl;
        private readonly List<DiagnosticRepositoryList> _listDiagnosticRepositoryLists;
        private string _protocolId;
        private MedicamentoBl _objMedicamentoBl;
        private string productoDetalleId = "";

        private recetaDto _recetaDto;

        private List<recetadespachoDto> _dataReporte;
        private OperationResult _objOperationResult;

        private string modoProducto = "";
        private string diagnosticRepositoryId = "";
        List<MedicamentoDto> data = new List<MedicamentoDto>();
        List<MedicamentoDto> dataTemp = new List<MedicamentoDto>();

        public frmRecetaMedica(List<DiagnosticRepositoryList> ListaDX, string serviceId, string protocolId)
        {
            _serviceId = serviceId;
            InitializeComponent();
            _objRecetaBl = new RecetaBl();
            _objMedicamentoBl = new MedicamentoBl();
            _pobjOperationResult = new OperationResult();
            _listDiagnosticRepositoryLists = ListaDX;
            _protocolId = protocolId;
            
        }

        private void GetData(List<DiagnosticRepositoryList> ListaDX)
        {
           
            try
            {
                ListaDX.ForEach(l => l.RecipeDetail = new List<recetaDto>());
                var data = _objRecetaBl.GetHierarchycalData(ref _pobjOperationResult, ListaDX);
                
                if (data.Any())
                {
                    var previousIndex = grdTotalDiagnosticos.ActiveRow != null ? grdTotalDiagnosticos.ActiveRow.Index : 0;
                    grdTotalDiagnosticos.DataSource = data;
                    grdTotalDiagnosticos.Rows.Refresh(RefreshRow.ReloadData);
                    grdTotalDiagnosticos.Rows[previousIndex].Activate();
                }
            }
            catch (Exception e)
            {
            }
        }

        private void MedicinaReceta(string serviceId) {
            var data = _objRecetaBl.GetHierarchycalData(ref _pobjOperationResult, _listDiagnosticRepositoryLists);

            if (data.Any())
            {
                var previousIndex = grdTotalDiagnosticos.ActiveRow != null ? grdTotalDiagnosticos.ActiveRow.Index : 0;
                grdTotalDiagnosticos.DataSource = data;
                grdTotalDiagnosticos.Rows.Refresh(RefreshRow.ReloadData);
                grdTotalDiagnosticos.Rows[previousIndex].Activate();
            }
        }

        private void frmRecetaMedica_Load(object sender, EventArgs e)
        {
            _pobjOperationResult = new OperationResult();
            GetData(_listDiagnosticRepositoryLists);
            CargarData();
        }

        private void grdTotalDiagnosticos_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void grdTotalDiagnosticos_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                //if (e.Cell == null || e.Cell.Row.Cells["v_DiagnosticRepositoryId"].Value == null) return;
                //var diagnosticRepositoryId = e.Cell.Row.Cells["v_DiagnosticRepositoryId"].Value.ToString();
                //var categoryName = e.Cell.Row.Cells["v_ComponentName"].Value.ToString();
                #region Conexion SIGESOFT verificar la unidad productiva del componente
                //ConexionSigesoft conectasam = new ConexionSigesoft();
                //conectasam.opensigesoft();
                //var cadena1 = "select CP.v_IdUnidadProductiva " +
                //              "from diagnosticrepository DR " +
                //              "inner join component CP on DR.v_ComponentId=CP.v_ComponentId "+
                //              "where DR.v_DiagnosticRepositoryId='"+diagnosticRepositoryId+"' ";
                //SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                //SqlDataReader lector = comando.ExecuteReader();
                //string LineId = "";
                //while (lector.Read())
                //{
                //    LineId = lector.GetValue(0).ToString();
                //}
                //lector.Close();
                //conectasam.closesigesoft();
                #endregion
                switch (e.Cell.Column.Key)
                {
                    //case "_AddRecipe":
                    //{
                    //    var f = new frmAddRecipe(ActionForm.Add, diagnosticRepositoryId, 0, _protocolId, _serviceId, categoryName, LineId) { StartPosition = FormStartPosition.CenterScreen };
                    //    f.ShowDialog();
                    //    GetData(_listDiagnosticRepositoryLists);
                    //}
                    //    break;

                    case "_EditRecipe":
                    {
                        modoProducto = "Editar";

                        txtIdReceta.Text = e.Cell.Row.Cells["i_IdReceta"].Value.ToString();
                        txtMedicamento.Text = e.Cell.Row.Cells["NombreMedicamento"].Value.ToString();
                        txtCantidad.Text = e.Cell.Row.Cells["d_Cantidad"].Value.ToString();
                        txtPosologia.Text = e.Cell.Row.Cells["v_Posologia"].Value.ToString();
                        txtDuracion.Text = e.Cell.Row.Cells["v_Duracion"].Value.ToString();
                        txtPrecio.Text = e.Cell.Row.Cells["d_SaldoPaciente"].Value.ToString();
                        txtIdProductoDetalle.Text = e.Cell.Row.Cells["v_IdProductoDetalle"].Value.ToString();
                            
                        //var recipeId = int.Parse(e.Cell.Row.Cells["i_IdReceta"].Value.ToString());
                        //var f = new frmAddRecipe(ActionForm.Edit, diagnosticRepositoryId, recipeId, _protocolId, _serviceId, "", LineId, id_receta, _userId, _usuariocrea) { StartPosition = FormStartPosition.CenterScreen };
                        //f.ShowDialog();
                        //GetData(_listDiagnosticRepositoryLists);
                    }
                        break;

                    case "_DeleteRecipe":
                    {
                        ConexionSigesoft conectasam = new ConexionSigesoft();
                    

                        _pobjOperationResult = new OperationResult();
                        var recipeId = int.Parse(e.Cell.Row.Cells["i_IdReceta"].Value.ToString());
                        var msg = MessageBox.Show(@"¿Seguro de eliminar esta receta?", @"Confirmación",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.No) return;

                        #region Verificar si existe receta por Dx
                        ConexionSigesoft conectasam4 = new ConexionSigesoft();
                        conectasam4.opensigesoft();
                        var cadena4 = "UPDATE receta set i_isDelete = 1 where i_IdReceta ='" + recipeId + "' ";
                        SqlCommand comando4 = new SqlCommand(cadena4, connection: conectasam4.conectarsigesoft);
                        SqlDataReader lector4 = comando4.ExecuteReader();
                        lector4.Close();
                        conectasam.closesigesoft();
                        #endregion

                        //_pobjOperationResult = new OperationResult();
                        //var recipeId = int.Parse(e.Cell.Row.Cells["i_IdReceta"].Value.ToString());
                        //var msg = MessageBox.Show(@"¿Seguro de eliminar esta receta?", @"Confirmación",
                        //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (msg == DialogResult.No) return;
                        //_objRecetaBl.DeleteRecipe(ref _pobjOperationResult, recipeId);
                        //if (_pobjOperationResult.Success == 0)
                        //{
                        //    MessageBox.Show(_pobjOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                        //        MessageBoxIcon.Error);
                        //    return;
                        //}

                        GetData(_listDiagnosticRepositoryLists);
                    }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConsolidado.Checked == true)
                {
                    CargarConsolidado();
                }
                else
                {
                    MostrarReceta();
                }
            }
            catch (Exception exception)
            {
                CargarConsolidado();
            }
            //var f = new frmReporteReceta(_serviceId, recomendaciones, restricciones);
            //f.ShowDialog();
        }

        private void MostrarReceta()
        {
            try
            {
                var _v_DiagnosticRepositoryId = grdTotalDiagnosticos.Selected.Rows[0].Cells["v_DiagnosticRepositoryId"]
                   .Value.ToString();

                var _recomendaciones = string.Join("\n-",
                    _listDiagnosticRepositoryLists.Where(o => !string.IsNullOrWhiteSpace(o.v_RecomendationsName))
                        .Select(p => p.v_RecomendationsName).Distinct()).Trim();
                var _restricciones = string.Join("\n-",
                    _listDiagnosticRepositoryLists.Where(o => !string.IsNullOrWhiteSpace(o.v_RestrictionsName))
                        .Select(p => p.v_RestrictionsName).Distinct()).Trim();

                var objRecetaBl = new RecetaBl();
                var _ruta = Common.Utils.GetApplicationConfigValue("Receta").ToString();
                DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                _objOperationResult = new OperationResult();

                _dataReporte =
                    objRecetaBl.GetRecetaToReport(ref _objOperationResult, _serviceId, _v_DiagnosticRepositoryId);



                if (_objOperationResult.Success == 0)
                {
                    MessageBox.Show(_objOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var rp = new crRecetaPresentacion();
                var ds = new DataSet();
                var dsReport = Utils.ConvertToDatatable(_dataReporte);
                ds.Tables.Add(dsReport);
                ds.Tables[0].TableName = "dsReporteReceta";
                rp.SetDataSource(dsReport);
                rp.SetParameterValue("_Recomendaciones", _recomendaciones);
                rp.SetParameterValue("_Restricciones", _restricciones);
                crystalReportViewer1.ReportSource = rp;

                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                objDiskOpt = new DiskFileDestinationOptions();
                objDiskOpt.DiskFileName = _ruta + _serviceId + "-" + _v_DiagnosticRepositoryId + ".pdf";
                rp.ExportOptions.DestinationOptions = objDiskOpt;
                rp.Export();
                rp.Close();
                rp.Dispose();
            }
            catch (Exception e)
            {
              
            }
            
        }
        private void CargarConsolidado()
        {
            try
            {
                //var _v_DiagnosticRepositoryId = grdTotalDiagnosticos.Selected.Rows[0].Cells["v_DiagnosticRepositoryId"]
                //   .Value.ToString();

                var _recomendaciones = string.Join("\n-",
                    _listDiagnosticRepositoryLists.Where(o => !string.IsNullOrWhiteSpace(o.v_RecomendationsName))
                        .Select(p => p.v_RecomendationsName).Distinct()).Trim();
                var _restricciones = string.Join("\n-",
                    _listDiagnosticRepositoryLists.Where(o => !string.IsNullOrWhiteSpace(o.v_RestrictionsName))
                        .Select(p => p.v_RestrictionsName).Distinct()).Trim();

                var objRecetaBl = new RecetaBl();
                var _ruta = Common.Utils.GetApplicationConfigValue("Receta").ToString();
                DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                _objOperationResult = new OperationResult();

                _dataReporte =
                    objRecetaBl.GetRecetaToReport(ref _objOperationResult, _serviceId, null);



                if (_objOperationResult.Success == 0)
                {
                    MessageBox.Show(_objOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var rp = new crRecetaPresentacion();
                var ds = new DataSet();
                var dsReport = Utils.ConvertToDatatable(_dataReporte);
                ds.Tables.Add(dsReport);
                ds.Tables[0].TableName = "dsReporteReceta";
                rp.SetDataSource(dsReport);
                rp.SetParameterValue("_Recomendaciones", _recomendaciones);
                rp.SetParameterValue("_Restricciones", _restricciones);
                crystalReportViewer1.ReportSource = rp;

                rp.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                rp.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                objDiskOpt = new DiskFileDestinationOptions();
                objDiskOpt.DiskFileName = _ruta + _serviceId + ".pdf";
                rp.ExportOptions.DestinationOptions = objDiskOpt;
                rp.Export();
                rp.Close();
                rp.Dispose();
            }
            catch (Exception e)
            {

            }

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            var f = new frmConfirmarDespacho(_serviceId);
            f.ShowDialog();

        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            CargarData();
        }
        private void CargarData()
        {
            try
            {
                _pobjOperationResult = new OperationResult();
                txtBuscarNombre.Text = "";
                txtBuscarAccionF.Text = "";

                data = _objMedicamentoBl.GetListMedicamentos(ref _pobjOperationResult, txtBuscarNombre.Text,
                    txtBuscarAccionF.Text, chekMedicinaExterna.Checked);

                if (_pobjOperationResult.Success == 0)
                {
                    MessageBox.Show(_pobjOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                ultraGrid1.DataSource = data;
                lblRecordCount.Text = string.Format("Se encontraron {0} registros.", data.Count());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"CargarData()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ultraGrid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            try
            {
                modoProducto = "Nuevo";

                productoDetalleId = ultraGrid1.Selected.Rows[0].Cells["IdProductoDetalle"].Value == null ? "" : ultraGrid1.Selected.Rows[0].Cells["IdProductoDetalle"].Value.ToString();
                if (productoDetalleId != "")
                {
                    txtIdProductoDetalle.Text = productoDetalleId;
                    txtMedicamento.Text = ultraGrid1.Selected.Rows[0].Cells["Nombre"].Value == null ? "" : ultraGrid1.Selected.Rows[0].Cells["Nombre"].Value.ToString();
                    txtCantidad.Text = "1";
                    txtPrecio.Text = ultraGrid1.Selected.Rows[0].Cells["PrecioVenta"].Value == null ? "" : ultraGrid1.Selected.Rows[0].Cells["PrecioVenta"].Value.ToString();
                    txtPosologia.Text = ultraGrid1.Selected.Rows[0].Cells["Concentracion"].Value == null ? "" : ultraGrid1.Selected.Rows[0].Cells["Concentracion"].Value.ToString();
                    txtDuracion.Text = ultraGrid1.Selected.Rows[0].Cells["Presentacion"].Value == null ? "" : ultraGrid1.Selected.Rows[0].Cells["Presentacion"].Value.ToString(); ;
                }

            }
            catch (Exception exception)
            {
                return;
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TicketBL oTicketBL = new TicketBL();
            try
            {
                if (modoProducto == "Nuevo")
                {
                    _pobjOperationResult = new OperationResult();
                    _recetaDto = new recetaDto();
                  
                    if (diagnosticRepositoryId != "")
	                {
		                decimal d;
                        _recetaDto.v_IdProductoDetalle = txtIdProductoDetalle.Text;
                        _recetaDto.d_Cantidad = decimal.TryParse(txtCantidad.Text, out d) ? d : 0;
                        _recetaDto.v_Duracion = txtDuracion.Text.Trim();
                        _recetaDto.v_Posologia = txtPosologia.Text.Trim();
                        _recetaDto.t_FechaFin = dtpFechaFin.Value;
                        _recetaDto.v_DiagnosticRepositoryId = diagnosticRepositoryId;
                        _recetaDto.i_isDelete = 0;
                   
                        _recetaDto.v_ServiceId = _serviceId;

                        var tienePlan = false;
                        var resultplan = oTicketBL.TienePlan(_protocolId, txtUnidadProductiva.Text);
                        if (resultplan.Count > 0) tienePlan = true;
                        else tienePlan = false;

                        if (tienePlan)
                        {
                            if (resultplan[0].i_EsCoaseguro == 1)
                            {
                                #region Conexion SIGESOFT verificar la unidad productiva del componente
                                ConexionSigesoft conectasam = new ConexionSigesoft();
                                conectasam.opensigesoft();
                                var cadena1 = "select PL.d_ImporteCo " +
                                              "from [dbo].[plan] PL " +
                                              "inner join protocol PR on PL.v_ProtocoloId=PR.v_ProtocolId " +
                                              "inner join servicecomponent SC on PL.v_IdUnidadProductiva=SC.v_IdUnidadProductiva " +
                                              "inner join diagnosticrepository DR on DR.v_ComponentId=SC.v_ComponentId " +
                                              "where PR.v_ProtocolId='" + _protocolId + "' and DR.v_DiagnosticRepositoryId='" + diagnosticRepositoryId + "' ";
                                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                                SqlDataReader lector = comando.ExecuteReader();
                                string ImporteCo = "";
                                bool lectorleido = false;
                                while (lector.Read())
                                {
                                    ImporteCo = lector.GetValue(0).ToString();
                                    lectorleido = true;
                                }
                                if (lectorleido == false)
                                {
                                    MessageBox.Show(@"El consultorio no tiene Plan de Seguros", @"Error de validación", MessageBoxButtons.OK);
                                    return;
                                }
                                lector.Close();
                                conectasam.closesigesoft();
                                #endregion
                                _recetaDto.d_SaldoPaciente = (decimal.Parse(ImporteCo) / 100) * (decimal.Parse(txtNuevoPrecio.Text) * _recetaDto.d_Cantidad);
                                _recetaDto.d_SaldoAseguradora = (decimal.Parse(txtNuevoPrecio.Text) * _recetaDto.d_Cantidad) - _recetaDto.d_SaldoPaciente;
                            }
                        }
                        else
                        {
                            _recetaDto.d_SaldoPaciente = decimal.Parse(txtPrecio.Text) * _recetaDto.d_Cantidad;
                        }

                        _objRecetaBl.AddUpdateRecipe(ref _pobjOperationResult, _recetaDto);

                        if (_pobjOperationResult.Success == 0)
                        {
                            MessageBox.Show(_pobjOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            GetData(_listDiagnosticRepositoryLists);
                            CargarData(); 

                            txtIdProductoDetalle.Text = "";
                            txtMedicamento.Text = "";
                            txtCantidad.Text = "";
                            txtPrecio.Text = "";
                            txtPosologia.Text = "";
                            txtDuracion.Text = "";
                            modoProducto = "";
                        } 
	                }
                    else
	                {
                        MessageBox.Show(@"Por favor seleccione un diagnóstico para poder agregar medicamentos a receta.", @"Error ", MessageBoxButtons.OK);
                        return;;
	                }  
                }
                else if (modoProducto == "Editar")
                {
                    _pobjOperationResult = new OperationResult();
                    _recetaDto = new recetaDto();
                  
                    if (diagnosticRepositoryId != "")
	                {
		                decimal d;
                        _recetaDto.v_IdProductoDetalle = txtIdProductoDetalle.Text;
                        _recetaDto.d_Cantidad = decimal.TryParse(txtCantidad.Text, out d) ? d : 0;
                        _recetaDto.v_Duracion = txtDuracion.Text.Trim();
                        _recetaDto.v_Posologia = txtPosologia.Text.Trim();
                        _recetaDto.t_FechaFin = dtpFechaFin.Value;
                        _recetaDto.i_IdReceta = int.Parse(txtIdReceta.Text);
                        _recetaDto.v_DiagnosticRepositoryId = diagnosticRepositoryId;
                        _recetaDto.i_isDelete = 0;

                        _recetaDto.v_ServiceId = _serviceId;

                        var tienePlan = false;
                        var resultplan = oTicketBL.TienePlan(_protocolId, txtUnidadProductiva.Text);
                        if (resultplan.Count > 0) tienePlan = true;
                        else tienePlan = false;

                        if (tienePlan)
                        {
                            if (resultplan[0].i_EsCoaseguro == 1)
                            {
                                #region Conexion SIGESOFT verificar la unidad productiva del componente
                                ConexionSigesoft conectasam = new ConexionSigesoft();
                                conectasam.opensigesoft();
                                var cadena1 = "select PL.d_ImporteCo " +
                                              "from [dbo].[plan] PL " +
                                              "inner join protocol PR on PL.v_ProtocoloId=PR.v_ProtocolId " +
                                              "inner join servicecomponent SC on PL.v_IdUnidadProductiva=SC.v_IdUnidadProductiva " +
                                              "inner join diagnosticrepository DR on DR.v_ComponentId=SC.v_ComponentId " +
                                              "where PR.v_ProtocolId='" + _protocolId + "' and DR.v_DiagnosticRepositoryId='" + diagnosticRepositoryId + "' ";
                                SqlCommand comando = new SqlCommand(cadena1, connection: conectasam.conectarsigesoft);
                                SqlDataReader lector = comando.ExecuteReader();
                                string ImporteCo = "";
                                bool lectorleido = false;
                                while (lector.Read())
                                {
                                    ImporteCo = lector.GetValue(0).ToString();
                                    lectorleido = true;
                                }
                                if (lectorleido == false)
                                {
                                    MessageBox.Show(@"El consultorio no tiene Plan de Seguros", @"Error de validación", MessageBoxButtons.OK);
                                    return;
                                }
                                lector.Close();
                                conectasam.closesigesoft();
                                #endregion
                                _recetaDto.d_SaldoPaciente = (decimal.Parse(ImporteCo) / 100) * (decimal.Parse(txtNuevoPrecio.Text) * _recetaDto.d_Cantidad);
                                _recetaDto.d_SaldoAseguradora = (decimal.Parse(txtNuevoPrecio.Text) * _recetaDto.d_Cantidad) - _recetaDto.d_SaldoPaciente;
                            }
                        }
                        else
                        {
                            _recetaDto.d_SaldoPaciente = decimal.Parse(txtPrecio.Text) * _recetaDto.d_Cantidad;
                        }

                        _objRecetaBl.AddUpdateRecipe(ref _pobjOperationResult, _recetaDto);

                        if (_pobjOperationResult.Success == 0)
                        {
                            MessageBox.Show(_pobjOperationResult.ErrorMessage, @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            GetData(_listDiagnosticRepositoryLists);
                            CargarData(); 

                            txtIdProductoDetalle.Text = "";
                            txtMedicamento.Text = "";
                            txtCantidad.Text = "";
                            txtPrecio.Text = "";
                            txtPosologia.Text = "";
                            txtDuracion.Text = "";
                            modoProducto = "";

                        } 
	                }
                    else
	                {
                        MessageBox.Show(@"Por favor seleccione un diagnóstico para poder agregar medicamentos a receta.", @"Error ", MessageBoxButtons.OK);
                        return;;
	                }  
                }

                GetData(_listDiagnosticRepositoryLists);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"btnGuardar_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdTotalDiagnosticos_ClickCell(object sender, ClickCellEventArgs e)
        {
            diagnosticRepositoryId = grdTotalDiagnosticos.Selected.Rows[0].Cells["v_DiagnosticRepositoryId"].Value.ToString();

        }

        private void txtBuscarNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarNombre.Text != string.Empty)
            {
                dataTemp = new List<MedicamentoDto>(data.Where(p => p.Nombre.Contains(txtBuscarNombre.Text.ToUpper())));

                ultraGrid1.DataSource = dataTemp;

                if (dataTemp != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", dataTemp.Count());
                }

                txtBuscarAccionF.Enabled = false;
            }
            else
            {
                ultraGrid1.DataSource = data;

                if (data != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", data.Count());
                }
                txtBuscarAccionF.Enabled = true;

            }
        }

        private void txtBuscarAccionF_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarAccionF.Text != string.Empty)
            {
                dataTemp = new List<MedicamentoDto>(data.Where(p => p.AccionFarmaco.Contains(txtBuscarAccionF.Text.ToUpper())));

                ultraGrid1.DataSource = dataTemp;

                if (dataTemp != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", dataTemp.Count());
                }

                txtBuscarNombre.Enabled = false;
            }
            else
            {
                ultraGrid1.DataSource = data;

                if (data != null)
                {
                    lblRecordCount.Text = string.Format("Se encontraron {0} registros.", data.Count());
                }

                txtBuscarNombre.Enabled = true;
            }
        }

        private void btnRegistrarMedicamento_Click(object sender, EventArgs e)
        {
            var f = new frmSearchMedicamento("");
            f.ShowDialog();

       
        }

        private void ultraGrid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            var banda = e.Row.Band.Index.ToString();
            var row = e.Row;
            if (banda == "0")
            {
                if (row.Band.Index.ToString() == "0")
                {
                    if (e.Row.Cells["CodInterno"].Value.ToString().Split('-')[0] == "FNE")
                    {
                        e.Row.Appearance.BackColor = Color.Yellow;
                        e.Row.Appearance.BackColor2 = Color.White;
                        //Y doy el efecto degradado vertical
                        e.Row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                    }
                }
            }
        }
    }
}
