using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Node.WinClient.BLL;
using System.Transactions;
using Sigesoft.Node.WinClient.BE.Custom;
using System.IO;
using NetPdf;
using System.Reflection;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmBandejaPagoTrabajador : Form
    {
        public string personId = null;
        public frmBandejaPagoTrabajador()
        {
            InitializeComponent();
        }

        public TransactionScope CreateTransactionScope(TimeSpan timeout)
        {
            SetTransactionManagerField("_cachedMaxTimeout", true);
            SetTransactionManagerField("_maximumTimeout", timeout);
            return new TransactionScope(TransactionScopeOption.RequiresNew, timeout);
        }

        private void SetTransactionManagerField(string fieldName, object value)
        {
            typeof(TransactionManager).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, value);
        }

        private void frmBandejaPagoTrabajador_Load(object sender, EventArgs e)
        {
            cboMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmWorkers frm = new frmWorkers();
            frm.ShowDialog();
            txtTrabajador.Text = frm.personName;
            personId = frm.personId;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            
            List<string> listScheduleDetailId = new List<string>();
            foreach (var row in grdDataGroupControl.Rows)
            {
                if ((bool)row.Cells["Check"].Value)
                {
                    
                    foreach (var rowChild in row.ChildBands[0].Rows)
                    {
                        var scheduleDetail = rowChild.Cells["v_ScheduleId"].Value.ToString();
                        if (!listScheduleDetailId.Contains(scheduleDetail))
                        {
                            
                            listScheduleDetailId.Add(scheduleDetail);
                        }
                    }
                    
                    
                }
            }

            if (listScheduleDetailId.Count == 0)
            {
                MessageBox.Show("Seleccione los registros a procesar", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialog = MessageBox.Show("¿ Seguro de pagar las horas ?", "CONFIRMACIÓN",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialog == DialogResult.Yes)
            {
                try
                {

                    var MedicalCenter = new ServiceBL().GetInfoMedicalCenter();
                    MergeExPDF _mergeExPDF = new MergeExPDF();
                    List<string> FileName = new List<string>();
                    string rutaConsolidado = Common.Utils.GetApplicationConfigValue("rutaBoletasConsolidadas").ToString();
                    using (var ts = new TransactionScope())
                    {

                        foreach (var detailId in listScheduleDetailId)
                        {
                            var list = GetDetailsByPersonId(personId);
                           
                            var objSchedule = new WorkerScheduleBL().GetDiasProgramados(detailId);
                            DataBoletaCustom data = new DataBoletaCustom();
                            string docNumber = new WorkerScheduleBL().NumeroDoc(personId);
                            data.v_PersonId = list[0].v_PersonId;
                            data.v_PersonName = list[0].v_PersonName;

                            data.v_DocNumber = docNumber;//list[0].t_ExtraHours;
                            data.v_MesPago = objSchedule.v_MesPago;//list[0].t_ExtraHours;
                            data.DiasProgramados = objSchedule.DiasProgramados;//list[0].t_ExtraHours;
                            data.DiasCompletados = objSchedule.DiasCompletados;//list[0].t_ExtraHours;
                            data.TotalHorasExtras = list[0].t_ExtraHours;
                            data.TotalHorasAsignadas = objSchedule.TotalHorasAsignadas;
                            data.TotalHorasRealizadas = list[0].t_HorasTrabajadas;
                            
                            data.TotalHorasTardanzas = list[0].t_HoursAgainst;
                            data.r_PagoHora = list[0].r_PagoHora;
                            data.r_DescuentoHora = list[0].r_PagoHora;
                            data.r_TotalPago = list[0].r_TotalPago;

                            string ruta = Common.Utils.GetApplicationConfigValue("rutaBoletas").ToString();
                            
                            string fileName = personId + "-BOLETA-AGOSTO";
                            string pathFile = string.Format("{0}.pdf", Path.Combine(ruta, fileName));
                            BoletaTrabajador.GenerarBoleta(pathFile, data, MedicalCenter);
         
                            FileName.Add(pathFile);
                            break;
                        }

                        foreach (var item in listScheduleDetailId)
                        {
                            bool exito = new WorkerScheduleBL().PaidWorker(item);
                            if (!exito)
                            {
                                throw new Exception("Sucedió un error y no se procesaron los cambios, por favor vuelva a intentar");
                            }
                        }
                        ts.Complete();
                        
                    }
                    MessageBox.Show("Los registros se procesaron correctamente.", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _mergeExPDF.FilesName = FileName;
                    _mergeExPDF.DestinationFile = string.Format("{0}.pdf", Path.Combine(rutaConsolidado, "CONSOLIDADO-BOLETA-AGOSTO"));
                    _mergeExPDF.Execute();
                    _mergeExPDF.RunFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BindingGrid();
                
            }

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            BindingGrid();
        }

        private void BindingGrid()
        {
            List<MarkingsHeaderCustom> ListMrk = new List<MarkingsHeaderCustom>();
            
            ListMrk = GetDetailsByPersonId(personId);
            if (ListMrk == null)
            {
                return;
            }
            grdDataGroupControl.DataSource = ListMrk;


        }


        public List<MarkingsHeaderCustom> GetDetailsByPersonId(string _personId)
        {
            MarkingsHeaderCustom mrk = new MarkingsHeaderCustom();
            List<MarkingsHeaderCustom> ListMrk = new List<MarkingsHeaderCustom>();
            if (personId == null)
            {
                MessageBox.Show("Elija un trabajador para continuar.", "VALIDACIÓN",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            var list = new WorkerScheduleBL().GetMarkingsByPersonId(cboMes.Text, _personId);

            if (list.Count > 0)
            {
                TimeSpan horasExtras = TimeSpan.Zero;
                TimeSpan horasTardanza = TimeSpan.Zero;
                TimeSpan horasTrabajadas = TimeSpan.Zero;
                TimeSpan horasAsignadas = TimeSpan.Zero;
                TimeSpan Rango1 = TimeSpan.Zero;
                TimeSpan Rango2 = TimeSpan.Zero;
                string personName = "";
                var scheduleDetailId = "";
                foreach (var item in list)
                {

                    personName = item.v_PersonName;
                    horasExtras += item.t_ExtraHours.Value;
                    horasTardanza += item.t_HoursAgainst.Value;

                    if (scheduleDetailId == "" || scheduleDetailId != item.v_ScheduleId)
                    {
                        if (item.t_StartBreakHour != null)
                        {

                            if (item.t_StartHour > item.t_StartBreakHour)
                            {

                                var startTemp = item.t_StartBreakHour + item.t_EndHour;
                                var EndTemp = item.t_EndBreakHour + item.t_EndHour;
                                Rango1 += startTemp.Value - item.t_EndHour.Value;
                                Rango2 += item.t_StartHour.Value - EndTemp.Value;
                            }
                            else
                            {
                                Rango1 += item.t_StartBreakHour.Value - item.t_StartHour.Value;
                                Rango2 += item.t_EndHour.Value - item.t_EndBreakHour.Value;
                            }
                        }
                        else
                        {
                            if (item.t_StartHour > item.t_EndHour)
                            {
                                Rango1 += item.t_StartHour.Value - item.t_EndHour.Value;
                            }
                            else
                            {
                                Rango1 += item.t_EndHour.Value - item.t_StartHour.Value;
                            }
                        }


                        scheduleDetailId = item.v_ScheduleId;
                    }

                }


                horasAsignadas = Rango1 + Rango2;
                horasTrabajadas = horasExtras + horasAsignadas - horasTardanza;
                var objSchedule = new WorkerScheduleBL().GetDiasProgramados(list[0].v_ScheduleId);

                bool objVacation = new VacationsBL().GetVacation(_personId, GetDate(cboMes.Text));
                decimal? pagoMensual = new WorkerScheduleBL().PagoTrabajador(_personId);
                TimeSpan newTotalSpan = objVacation ? horasTrabajadas : objSchedule.TotalHorasAsignadas.Value;
                double pagoxHora = double.Parse(pagoMensual.ToString()) / newTotalSpan.TotalHours;
                mrk.Check = false;
                mrk.v_ScheduleId = scheduleDetailId;
                mrk.v_PersonName = personName;
                mrk.v_PersonId = _personId;
                mrk.t_ExtraHours = horasExtras;
                mrk.t_HoursAgainst = horasTardanza;
                mrk.t_HorasTrabajadas = horasTrabajadas;
                mrk.t_HorasAsignadas = objVacation ? horasTrabajadas : objSchedule.TotalHorasAsignadas.Value;
                mrk.r_PagoHora = float.Parse(pagoxHora.ToString());
                mrk.r_TotalPago = (double)(((double)horasTrabajadas.Ticks / (double)TimeSpan.Parse("01:00").Ticks) * mrk.r_PagoHora);
                mrk.Detalles = list;
                ListMrk.Add(mrk);

            }

            return ListMrk;
        }

        public DateTime GetDate(string month)
        {
            DateTime dateReturn = DateTime.Now;
            switch (month)
            {
                case "ENERO":
                    dateReturn = DateTime.Parse("01/01/" + dateReturn.Year.ToString());
                    break;
                case "FEBRERO":
                    dateReturn = DateTime.Parse("01/02/" + dateReturn.Year.ToString());
                    break;
                case "MARZO":
                    dateReturn = DateTime.Parse("01/03/" + dateReturn.Year.ToString());
                    break;
                case "ABRIL":
                    dateReturn = DateTime.Parse("01/04/" + dateReturn.Year.ToString());
                    break;
                case "MAYO":
                    dateReturn = DateTime.Parse("01/05/" + dateReturn.Year.ToString());
                    break;
                case "JUNIO":
                    dateReturn = DateTime.Parse("01/06/" + dateReturn.Year.ToString());
                    break;
                case "JULIO":
                    dateReturn = DateTime.Parse("01/07/" + dateReturn.Year.ToString());
                    break;
                case "AGOSTO":
                    dateReturn = DateTime.Parse("01/08/" + dateReturn.Year.ToString());
                    break;
                case "SETIEMBRE":
                    dateReturn = DateTime.Parse("01/09/" + dateReturn.Year.ToString());
                    break;
                case "OCTUBRE":
                    dateReturn = DateTime.Parse("01/10/" + dateReturn.Year.ToString());
                    break;
                case "NOVIEMBRE":
                    dateReturn = DateTime.Parse("01/11/" + dateReturn.Year.ToString());
                    break;
                case "DICIEMBRE":
                    dateReturn = DateTime.Parse("01/12/" + dateReturn.Year.ToString());
                    break;
            }

            return dateReturn;
        }

        private void grdDataGroupControl_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (grdDataGroupControl.Rows.Count > 0)
            {
                //grdDataGroupControl.Rows[0].Cells["MarkingId"].Column.Hidden = true;
                
            }
        }

        private void grdDataGroupControl_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if ((e.Cell.Column.Key == "Check"))
            {
                var scheduleDetailId = grdDataGroupControl.Selected.Rows[0].Cells["v_ScheduleId"].Value.ToString();
                if ((e.Cell.Value.ToString() == "False"))
                {
                    foreach (var row in grdDataGroupControl.Rows)
                    {
                        if (row.Cells["v_ScheduleId"].Value.ToString() == scheduleDetailId)
                        {
                            row.Cells["Check"].Value = true;
                        }
                    }
                }

                
                else
                {
                    foreach (var row in grdDataGroupControl.Rows)
                    {
                        if (row.Cells["v_ScheduleId"].Value.ToString() == scheduleDetailId)
                        {
                            row.Cells["Check"].Value = false;
                        }
                    }
                }
                
                    //e.Cell.Value = false;
            }
        }
       
    }
}
