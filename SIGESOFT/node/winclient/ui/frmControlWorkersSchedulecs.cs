using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sigesoft.Common;
using Sigesoft.Node.WinClient.BE.Custom;
using Sigesoft.Node.WinClient.BLL;
using Sigesoft.Node.WinClient.BE;

namespace Sigesoft.Node.WinClient.UI
{
    public partial class frmControlWorkersSchedulecs : Form
    {
        ComboBox[] comboLunes = new ComboBox[4];
        ComboBox[] comboMartes = new ComboBox[4];
        ComboBox[] comboMiercoles = new ComboBox[4];
        ComboBox[] comboJueves = new ComboBox[4];
        ComboBox[] comboViernes = new ComboBox[4];
        ComboBox[] comboSabado = new ComboBox[4];
        ComboBox[] comboDomingo = new ComboBox[4];
        private string personId = "";
        private string _scheduleId = "";
        private string _scheduleDetailId = "";
        private string _mode = "";
        public frmControlWorkersSchedulecs(string mode, string scheduleId)
        {
            _mode = mode;
            _scheduleId = scheduleId == null ? "" : scheduleId;
            InitializeComponent();
        }

        private void frmControlWorkersSchedulecs_Load(object sender, EventArgs e)
        {
            
            if (_mode == "Edit")
            {
                BindingGrid();

            }

            dtHasta.Value = dtDesde.Value;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                    {
                        comboLunes[i] = cbLunesIngreso;
                        comboMartes[i] = cbMartesIngreso;
                        comboMiercoles[i] = cbMiercolesIngreso;
                        comboJueves[i] = cbJuevesIngreso;
                        comboViernes[i] = cbViernesIngreso;
                        comboSabado[i] = cbSabadoIngreso;
                        comboDomingo[i] = cbDomingoIngreso;
                    }
                        break;
                    case 1:
                    {
                        comboLunes[i] = cbLunesRefrigerio;
                        comboMartes[i] = cbMartesRefrigerio;
                        comboMiercoles[i] = cbMiercolesRefrigerio;
                        comboJueves[i] = cbJuevesRefrigerio;
                        comboViernes[i] = cbViernesRefrigerio;
                        comboSabado[i] = cbSabadoRefrigerio;
                        comboDomingo[i] = cbDomingoRefrigerio;
                    }
                        break;
                    case 2:
                    {
                        comboLunes[i] = cbLunesRetorno;
                        comboMartes[i] = cbMartesRetorno;
                        comboMiercoles[i] = cbMiercolesRetorno;
                        comboJueves[i] = cbJuevesRetorno;
                        comboViernes[i] = cbViernesRetorno;
                        comboSabado[i] = cbSabadoRetorno;
                        comboDomingo[i] = cbDomingoRetorno;
                    }
                        break;
                    case 3:
                    {
                        comboLunes[i] = cbLunesSalida;
                        comboMartes[i] = cbMartesSalida;
                        comboMiercoles[i] = cbMiercolesSalida;
                        comboJueves[i] = cbJuevesSalida;
                        comboViernes[i] = cbViernesSalida;
                        comboSabado[i] = cbSabadoSalida;
                        comboDomingo[i] = cbDomingoSalida;
                    }
                        break;
                }
            }
        }

        private void BindingGrid()
        {
            OperationResult obj = new OperationResult();
            var list = new WorkerScheduleBL().GetSchedulesDetail(_scheduleId);
            grdDataScheduleWorking.DataSource = list;

            if (list.Count > 0)
            {
                personId = list[0].v_PersonId;
                var objperson = new PacientBL().GetPerson(ref obj, personId);
                txtPersonName.Text = objperson.v_FirstLastName + " " + objperson.v_SecondLastName + ", " + objperson.v_FirstName;
                txtPersonName.Enabled = false;
                btnBuscarTrabajador.Enabled = false;
            }

        }

        private string GetMonthName(int month)
        {
            string mes = "";
            switch (month)
            {
                case 1:
                    mes = "ENERO";
                    break;
                case 2:
                    mes = "FEBRERO";
                    break;
                case 3:
                    mes = "MARZO";
                    break;
                case 4:
                    mes = "ABRIL";
                    break;
                case 5:
                    mes = "MAYO";
                    break;
                case 6:
                    mes = "JUNIO";
                    break;
                case 7:
                    mes = "JULIO";
                    break;
                case 8:
                    mes = "AGOSTO";
                    break;
                case 9:
                    mes = "SETIEMBRE";
                    break;
                case 10:
                    mes = "OCTUBRE";
                    break;
                case 11:
                    mes = "NOVIEMBRE";
                    break;
                case 12:
                    mes = "DICIEMBRE";
                    break;
            }

            return mes;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            #region Nuevo

            if (personId == "")
            {
                MessageBox.Show("El horario debe ser asignado a un trabajador.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (!chkLunes.Checked && !chkMartes.Checked && !chkMiercoles.Checked && !chkjueves.Checked && !chkViernes.Checked && !chkSabado.Checked && !chkDomingo.Checked)
            {
                MessageBox.Show("Para asignar un horario debe seleccionar al menos un día.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            DateTime horaIngresoLunes = Convert.ToDateTime(cbLunesIngreso.Text);
            workersscheduleDto worksche = new workersscheduleDto();
            worksche.v_ScheduleDescription = txtScheduleDescription.Text;
            worksche.v_Mes = GetMonthName(dtDesde.Value.Month);

            // Difference in days, hours, and minutes.
            TimeSpan ts = dtHasta.Value.Date - dtDesde.Value.Date;
            // Difference in days.
            int differenceInDays = ts.Days + 1;
            if (differenceInDays < 0)
            {
                MessageBox.Show("Verifique las fechas para continuar", "VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<workersscheduledetailDto> listDto = new List<workersscheduledetailDto>();
            for (int i = 0; i < differenceInDays; i++)
            {
                workersscheduledetailDto dto = new workersscheduledetailDto();
                DateTime desde = dtDesde.Value;
                DateTime nuevoDesde = desde.AddDays(i);

                dto.d_Date = nuevoDesde.Date;
                dto.v_PersonId = personId;

                if (nuevoDesde.DayOfWeek == DayOfWeek.Monday)
                {
                    if (chkLunes.Checked)
	                {
                        dto.t_StartDate = TimeSpan.Parse(cbLunesIngreso.Text); 
                        dto.t_StartBreak = cbLunesRefrigerio.Text == "00:00" || cbLunesRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbLunesRefrigerio.Text);
                        dto.t_EndBreak = cbLunesRetorno.Text == "00:00" || cbLunesRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbLunesRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbLunesSalida.Text);
                        listDto.Add(dto);        
                    }             
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (chkMartes.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbMartesIngreso.Text);
                        dto.t_StartBreak = cbMartesRefrigerio.Text == "00:00" || cbMartesRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbMartesRefrigerio.Text);
                        dto.t_EndBreak = cbMartesRetorno.Text == "00:00" || cbMartesRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbMartesRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbMartesSalida.Text);
                        listDto.Add(dto);          
                    }
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (chkMiercoles.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbMiercolesIngreso.Text);
                        dto.t_StartBreak = cbMiercolesRefrigerio.Text == "00:00" || cbMiercolesRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbMiercolesRefrigerio.Text);
                        dto.t_EndBreak = cbMiercolesRetorno.Text == "00:00" || cbMiercolesRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbMiercolesRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbMiercolesSalida.Text);
                        listDto.Add(dto);        
                    }
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (chkjueves.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbJuevesIngreso.Text);
                        dto.t_StartBreak = cbJuevesRefrigerio.Text == "00:00" || cbJuevesRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbJuevesRefrigerio.Text);
                        dto.t_EndBreak = cbJuevesRetorno.Text == "00:00" || cbJuevesRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbJuevesRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbJuevesSalida.Text);
                        listDto.Add(dto);        
                    }
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Friday)
                {
                    if (chkViernes.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbViernesIngreso.Text);
                        dto.t_StartBreak = cbViernesRefrigerio.Text == "00:00" || cbViernesRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbViernesRefrigerio.Text);
                        dto.t_EndBreak = cbViernesRetorno.Text == "00:00" || cbViernesRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbViernesRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbViernesSalida.Text);
                        listDto.Add(dto);        
                    }
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (chkSabado.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbSabadoIngreso.Text);
                        dto.t_StartBreak = cbSabadoRefrigerio.Text == "00:00" || cbSabadoRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbSabadoRefrigerio.Text);
                        dto.t_EndBreak = cbSabadoRetorno.Text == "00:00" || cbSabadoRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbSabadoRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbSabadoSalida.Text);
                        listDto.Add(dto);        
                    }
                }
                else if (nuevoDesde.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (chkDomingo.Checked)
                    {
                        dto.t_StartDate = TimeSpan.Parse(cbDomingoIngreso.Text);
                        dto.t_StartBreak = cbDomingoRefrigerio.Text == "00:00" || cbDomingoRetorno.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbDomingoRefrigerio.Text);
                        dto.t_EndBreak = cbDomingoRetorno.Text == "00:00" || cbDomingoRefrigerio.Text == "00:00" ? null : (TimeSpan?)TimeSpan.Parse(cbDomingoRetorno.Text); 
                        dto.t_EndDate = TimeSpan.Parse(cbDomingoSalida.Text);
                        listDto.Add(dto);        
                    }
                }
            }

            if (_scheduleId == "")
            {
                
                _scheduleId = new WorkerScheduleBL().AddWorkerSchedule(worksche, Globals.ClientSession.i_SystemUserId,
                    Globals.ClientSession.i_CurrentExecutionNodeId);
            }
            else
            {
                worksche.v_ScheduleId = _scheduleId;
                new WorkerScheduleBL().UpdateWorkerSchedule(worksche, Globals.ClientSession.i_SystemUserId,
                    Globals.ClientSession.i_CurrentExecutionNodeId);

                
            }

            if (_scheduleDetailId == "")
            {
                foreach (var item in listDto)
                {
                    item.v_ScheduleId = _scheduleId;

                    bool exit = new WorkerScheduleBL().AddWorkerScheduleDetail(item,
                        Globals.ClientSession.i_SystemUserId,
                        Globals.ClientSession.i_CurrentExecutionNodeId);

                    if (!exit)
                    {
                        MessageBox.Show("Sucedió un error, por favor vuelva a intentar", "CONFIRMACIÓN",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        return;
                    }
                }
                
            }
            else
            {
                listDto[0].v_ScheduleDetailId = _scheduleDetailId;
                listDto[0].v_ScheduleId = _scheduleId;

                new WorkerScheduleBL().UpdateWorkerScheduleDetail(listDto[0],
                    Globals.ClientSession.i_SystemUserId,
                    Globals.ClientSession.i_CurrentExecutionNodeId);
                _scheduleDetailId = "";
            }

            MessageBox.Show("El horario asignó correctamente.", "HECHO",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkjueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;

            BlockedComboBox(comboLunes);
            BlockedComboBox(comboMartes);
            BlockedComboBox(comboMiercoles);
            BlockedComboBox(comboJueves);
            BlockedComboBox(comboViernes);
            BlockedComboBox(comboSabado);
            BlockedComboBox(comboDomingo);
            BindingGrid();

            #region Old

            
            //if (chkLunes.Checked)
            //{
            //    workschedet.t_MondayStart = TimeSpan.Parse(cbLunesIngreso.Text.ToString());
            //    workschedet.t_MondayEnd = TimeSpan.Parse(cbLunesSalida.Text.ToString());
            //    if (TimeSpan.Parse(cbLunesRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_MondayStartBreak = TimeSpan.Parse(cbLunesRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbLunesRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_MondayEndBreak = TimeSpan.Parse(cbLunesRetorno.Text.ToString());
            //    }

            //}
            //if (chkMartes.Checked)
            //{
            //    workschedet.t_TuesdayStart = TimeSpan.Parse(cbMartesIngreso.Text.ToString());
            //    workschedet.t_TuesdayEnd = TimeSpan.Parse(cbMartesSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbMartesRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_TuesdayStartBreak = TimeSpan.Parse(cbMartesRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbMartesRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_TuesdayEndBreak = TimeSpan.Parse(cbMartesRetorno.Text.ToString());
            //    }

            //}
            //if (chkMiercoles.Checked)
            //{
            //    workschedet.t_WednesdayStart = TimeSpan.Parse(cbMiercolesIngreso.Text.ToString());
            //    workschedet.t_WednesdayEnd = TimeSpan.Parse(cbMiercolesSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbMiercolesRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_WednesdayStartBreak = TimeSpan.Parse(cbMiercolesRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbMiercolesRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_WednesdayEndBreak = TimeSpan.Parse(cbMiercolesRetorno.Text.ToString());
            //    }

            //}
            //if (chkjueves.Checked)
            //{
            //    workschedet.t_ThrusdayStart = TimeSpan.Parse(cbJuevesIngreso.Text.ToString());
            //    workschedet.t_ThrusdayEnd = TimeSpan.Parse(cbJuevesSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbJuevesRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_ThrusdayStartBreak = TimeSpan.Parse(cbJuevesRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbJuevesRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_ThrusdayEndBreak = TimeSpan.Parse(cbJuevesRetorno.Text.ToString());
            //    }

            //}
            //if (chkViernes.Checked)
            //{
            //    workschedet.t_FridayStart = TimeSpan.Parse(cbViernesIngreso.Text.ToString());
            //    workschedet.t_FridayEnd = TimeSpan.Parse(cbViernesSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbViernesRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_FridayStartBreak = TimeSpan.Parse(cbViernesRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbViernesRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_FridayEndBreak = TimeSpan.Parse(cbViernesRetorno.Text.ToString());
            //    }
            //}
            //if (chkSabado.Checked)
            //{
            //    workschedet.t_SaturdayStart = TimeSpan.Parse(cbSabadoIngreso.Text.ToString());
            //    workschedet.t_SaturdayEnd = TimeSpan.Parse(cbSabadoSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbSabadoRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_SaturdayStartBreak = TimeSpan.Parse(cbSabadoRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbSabadoRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_SaturdayEndBreak = TimeSpan.Parse(cbSabadoRetorno.Text.ToString());
            //    }
            //}
            //if (chkDomingo.Checked)
            //{
            //    workschedet.t_SundayStart = TimeSpan.Parse(cbDomingoIngreso.Text.ToString());
            //    workschedet.t_SundayEnd = TimeSpan.Parse(cbDomingoSalida.Text.ToString());

            //    if (TimeSpan.Parse(cbDomingoRefrigerio.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_SundayStartBreak = TimeSpan.Parse(cbDomingoRefrigerio.Text.ToString());
            //    }
            //    if (TimeSpan.Parse(cbDomingoRetorno.Text.ToString()) != TimeSpan.Parse("00:00"))
            //    {
            //        workschedet.t_SundayEndBreak = TimeSpan.Parse(cbDomingoRetorno.Text.ToString());
            //    }
            //}

            //if (_scheduleId == "")
            //{
                
            //    _scheduleId = new WorkerScheduleBL().AddWorkerSchedule(worksche, Globals.ClientSession.i_SystemUserId,
            //        Globals.ClientSession.i_CurrentExecutionNodeId);
            //}
            //else
            //{
            //    worksche.v_ScheduleId = _scheduleId;
            //    new WorkerScheduleBL().UpdateWorkerSchedule(worksche, Globals.ClientSession.i_SystemUserId,
            //        Globals.ClientSession.i_CurrentExecutionNodeId);

                
            //}


            //workschedet.v_ScheduleId = _scheduleId;

            //if (_scheduleDetailId == "")
            //{
            //    bool exit = new WorkerScheduleBL().AddWorkerScheduleDetail(workschedet,
            //        Globals.ClientSession.i_SystemUserId,
            //        Globals.ClientSession.i_CurrentExecutionNodeId);

            //    if (!exit)
            //    {
            //        MessageBox.Show("Sucediò un error, por favor vuelva a intentar", "CONFIRMACIÓN",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        return;
            //    }
            //}
            //else
            //{
            //    workschedet.v_ScheduleDetailId = _scheduleDetailId;
            //    new WorkerScheduleBL().UpdateWorkerScheduleDetail(workschedet,
            //        Globals.ClientSession.i_SystemUserId,
            //        Globals.ClientSession.i_CurrentExecutionNodeId);
            //    _scheduleDetailId = "";
            //}

            //MessageBox.Show("El horario asignó correctamente.", "HECHO",
            //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //chkLunes.Checked = false;
            //chkMartes.Checked = false;
            //chkMiercoles.Checked = false;
            //chkjueves.Checked = false;
            //chkViernes.Checked = false;
            //chkSabado.Checked = false;
            //chkDomingo.Checked = false;

            //BlockedComboBox(comboLunes);
            //BlockedComboBox(comboMartes);
            //BlockedComboBox(comboMiercoles);
            //BlockedComboBox(comboJueves);
            //BlockedComboBox(comboViernes);
            //BlockedComboBox(comboSabado);
            //BlockedComboBox(comboDomingo);
            //BindingGrid();


            #endregion

            #endregion
        }

        private void chkLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLunes.Checked) UnlockedComboBox(comboLunes);
            else BlockedComboBox(comboLunes);
        }

        private void chkMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMartes.Checked) UnlockedComboBox(comboMartes);
            else BlockedComboBox(comboMartes);
        }

        private void chkMiercoles_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkMiercoles.Checked) UnlockedComboBox(comboMiercoles);
            else BlockedComboBox(comboMiercoles);
        }

        private void chkjueves_CheckedChanged(object sender, EventArgs e)
        {
            if (chkjueves.Checked) UnlockedComboBox(comboJueves);
            else BlockedComboBox(comboJueves);
        }

        private void chkViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViernes.Checked) UnlockedComboBox(comboViernes);
            else BlockedComboBox(comboViernes);
        }

        private void chkSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSabado.Checked) UnlockedComboBox(comboSabado);
            else BlockedComboBox(comboSabado);
        }

        private void chkDomingo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDomingo.Checked) UnlockedComboBox(comboDomingo);
            else BlockedComboBox(comboDomingo);
        }

        private void UnlockedComboBox(ComboBox[] combo)
        {
            foreach (var cbo in combo)
            {
                cbo.Enabled = true;

            }
        }

        private void BlockedComboBox(ComboBox[] combo)
        {
            foreach (var cbo in combo)
            {
                cbo.Enabled = false;
                
            }

            cbLunesRetorno.Text = "00:00";
            cbMartesRetorno.Text = "00:00";
            cbMiercolesRetorno.Text = "00:00";
            cbJuevesRetorno.Text = "00:00";
            cbViernesRetorno.Text = "00:00";
            cbSabadoRetorno.Text = "00:00";
            cbDomingoRetorno.Text = "00:00";

            cbLunesIngreso.Text = "08:00";
            cbMartesIngreso.Text = "08:00";
            cbMiercolesIngreso.Text = "08:00";
            cbJuevesIngreso.Text = "08:00";
            cbViernesIngreso.Text = "08:00";
            cbSabadoIngreso.Text = "08:00";
            cbDomingoIngreso.Text = "08:00";

            cbLunesRefrigerio.Text = "00:00";
            cbMartesRefrigerio.Text = "00:00";
            cbMiercolesRefrigerio.Text = "00:00";
            cbJuevesRefrigerio.Text = "00:00";
            cbViernesRefrigerio.Text = "00:00";
            cbSabadoRefrigerio.Text = "00:00";
            cbDomingoRefrigerio.Text = "00:00";

            cbLunesSalida.Text = "20:00";
            cbMartesSalida.Text = "20:00";
            cbMiercolesSalida.Text = "20:00";
            cbJuevesSalida.Text = "20:00";
            cbViernesSalida.Text = "20:00";
            cbSabadoSalida.Text = "20:00";
            cbDomingoSalida.Text = "20:00";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _scheduleDetailId = "";
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkjueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;

            dtDesde.Enabled = true;
            dtHasta.Enabled = true;

            BlockedComboBox(comboLunes);
            BlockedComboBox(comboMartes);
            BlockedComboBox(comboMiercoles);
            BlockedComboBox(comboJueves);
            BlockedComboBox(comboViernes);
            BlockedComboBox(comboSabado);
            BlockedComboBox(comboDomingo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (grdDataScheduleWorking.Selected.Rows.Count > 0)
            {
                _scheduleDetailId = grdDataScheduleWorking.Selected.Rows[0].Cells["v_ScheduleDetailId"].Value.ToString();

                var objDetail = new WorkerScheduleBL().GetWorkerScheduleDetail(_scheduleDetailId);
                dtDesde.Value = objDetail.d_Date.Value;
                dtHasta.Value = objDetail.d_Date.Value;

                dtDesde.Enabled = false;
                dtHasta.Enabled = false;

                chkLunes.Checked = false;
                chkMartes.Checked = false;
                chkMiercoles.Checked = false;
                chkjueves.Checked = false;
                chkViernes.Checked = false;
                chkSabado.Checked = false;
                chkDomingo.Checked = false;

                if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Monday)
                {
                    UnlockedComboBox(comboLunes);
                    chkLunes.Checked = true;
                    cbLunesIngreso.Text = objDetail.t_StartDate.ToString();
                    cbLunesRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbLunesRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbLunesSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Tuesday)
                {
                    UnlockedComboBox(comboMartes);
                    chkMartes.Checked = true;
                    cbMartesIngreso.Text = objDetail.t_StartDate.ToString();
                    cbMartesRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbMartesRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbMartesSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Wednesday)
                {
                    UnlockedComboBox(comboMiercoles);
                    chkMiercoles.Checked = true;
                    cbMiercolesIngreso.Text = objDetail.t_StartDate.ToString();
                    cbMiercolesRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbMiercolesRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbMiercolesSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Thursday)
                {
                    UnlockedComboBox(comboJueves);
                    chkjueves.Checked = true;
                    cbJuevesIngreso.Text = objDetail.t_StartDate.ToString();
                    cbJuevesRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbJuevesRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbJuevesSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Friday)
                {
                    UnlockedComboBox(comboViernes);
                    chkViernes.Checked = true;
                    cbViernesIngreso.Text = objDetail.t_StartDate.ToString();
                    cbViernesRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbViernesRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbViernesSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    UnlockedComboBox(comboSabado);
                    chkSabado.Checked = true;
                    cbSabadoIngreso.Text = objDetail.t_StartDate.ToString();
                    cbSabadoRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbSabadoRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbSabadoSalida.Text = objDetail.t_EndDate.ToString();
                }
                else if (objDetail.d_Date.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    UnlockedComboBox(comboDomingo);
                    chkDomingo.Checked = true;
                    cbDomingoIngreso.Text = objDetail.t_StartDate.ToString();
                    cbDomingoRefrigerio.Text = objDetail.t_StartBreak == null ? "00:00" : objDetail.t_StartBreak.ToString();
                    cbDomingoRetorno.Text = objDetail.t_EndBreak == null ? "00:00" : objDetail.t_EndBreak.ToString();
                    cbDomingoSalida.Text = objDetail.t_EndDate.ToString();
                }

                #region Old
                //chkLunes.Checked = objDetail.t_MondayStart == null ? false : true;
                //chkMartes.Checked = objDetail.t_TuesdayStart == null ? false : true;
                //chkMiercoles.Checked = objDetail.t_WednesdayStart == null ? false : true;
                //chkjueves.Checked = objDetail.t_ThrusdayStart == null ? false : true;
                //chkViernes.Checked = objDetail.t_FridayStart == null ? false : true;
                //chkSabado.Checked = objDetail.t_SaturdayStart == null ? false : true;
                //chkDomingo.Checked = objDetail.t_SundayStart == null ? false : true;

                //if (objDetail.t_MondayStart != null)
                //{
                //    UnlockedComboBox(comboLunes);

                //    cbLunesRetorno.Text = objDetail.t_MondayEndBreak == null ? "00:00" : objDetail.t_MondayEndBreak.ToString();
                //    cbLunesIngreso.Text = objDetail.t_MondayStart.ToString();
                //    cbLunesRefrigerio.Text = objDetail.t_MondayStartBreak == null ? "00:00" : objDetail.t_MondayStartBreak.ToString();
                //    cbLunesSalida.Text = objDetail.t_MondayEnd.ToString();


                //}
                //if (objDetail.t_TuesdayStart != null)
                //{
                //    UnlockedComboBox(comboMartes);

                //    cbMartesRetorno.Text = objDetail.t_TuesdayEndBreak == null ? "00:00" : objDetail.t_TuesdayEndBreak.ToString();
                //    cbMartesIngreso.Text = objDetail.t_TuesdayStart.ToString();
                //    cbMartesRefrigerio.Text = objDetail.t_TuesdayStartBreak == null ? "00:00" : objDetail.t_TuesdayStartBreak.ToString();
                //    cbMartesSalida.Text = objDetail.t_TuesdayEnd.ToString();

                //}
                //if (objDetail.t_WednesdayStart != null)
                //{
                //    UnlockedComboBox(comboMiercoles);

                //    cbMiercolesRetorno.Text = objDetail.t_WednesdayEndBreak == null ? "00:00" : objDetail.t_WednesdayEndBreak.ToString();
                //    cbMiercolesIngreso.Text = objDetail.t_WednesdayStart.ToString();
                //    cbMiercolesRefrigerio.Text = objDetail.t_WednesdayStartBreak == null ? "00:00" : objDetail.t_WednesdayStartBreak.ToString();
                //    cbMiercolesSalida.Text = objDetail.t_WednesdayEnd.ToString();

                //}
                //if (objDetail.t_ThrusdayStart != null)
                //{
                //    UnlockedComboBox(comboJueves);

                //    cbJuevesRetorno.Text = objDetail.t_ThrusdayEndBreak == null ? "00:00" : objDetail.t_ThrusdayEndBreak.ToString();
                //    cbJuevesIngreso.Text = objDetail.t_ThrusdayStart.ToString();
                //    cbJuevesRefrigerio.Text = objDetail.t_ThrusdayStartBreak == null ? "00:00" : objDetail.t_ThrusdayStartBreak.ToString();
                //    cbJuevesSalida.Text = objDetail.t_ThrusdayEnd.ToString();


                //}
                //if (objDetail.t_FridayStart != null)
                //{
                //    UnlockedComboBox(comboViernes);

                //    cbViernesRetorno.Text = objDetail.t_FridayEndBreak == null ? "00:00" : objDetail.t_FridayEndBreak.ToString();
                //    cbViernesIngreso.Text = objDetail.t_FridayStart.ToString();
                //    cbViernesRefrigerio.Text = objDetail.t_FridayStartBreak == null ? "00:00" : objDetail.t_FridayStartBreak.ToString();
                //    cbViernesSalida.Text = objDetail.t_FridayEnd.ToString();

                //}
                //if (objDetail.t_SaturdayStart != null)
                //{
                //    UnlockedComboBox(comboSabado);

                //    cbSabadoRetorno.Text = objDetail.t_SaturdayEndBreak == null ? "00:00" : objDetail.t_SaturdayEndBreak.ToString();
                //    cbSabadoIngreso.Text = objDetail.t_SaturdayStart.ToString();
                //    cbSabadoRefrigerio.Text = objDetail.t_SaturdayStartBreak == null ? "00:00" : objDetail.t_SaturdayStartBreak.ToString();
                //    cbSabadoSalida.Text = objDetail.t_SaturdayEnd.ToString();
                //}
                //if (objDetail.t_SundayStart != null)
                //{
                //    UnlockedComboBox(comboDomingo);

                //    cbDomingoRetorno.Text = objDetail.t_SundayEndBreak == null ? "00:00" : objDetail.t_SundayEndBreak.ToString();
                //    cbDomingoIngreso.Text = objDetail.t_SundayStart.ToString();
                //    cbDomingoRefrigerio.Text = objDetail.t_SundayStartBreak == null ? "00:00" : objDetail.t_SundayStartBreak.ToString();
                //    cbDomingoSalida.Text = objDetail.t_SundayEnd.ToString();
                //}
                #endregion
                
                
            }
            else
            {
                MessageBox.Show("Seleccione un detalle para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarTrabajador_Click(object sender, EventArgs e)
        {
            frmWorkers frm = new frmWorkers();
            frm.ShowDialog();
            txtPersonName.Text = frm.personName;
            personId = frm.personId;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdDataScheduleWorking.Selected.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("¿ Seguro de eliminar registro ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialog == DialogResult.No) return;


                _scheduleDetailId = grdDataScheduleWorking.Selected.Rows[0].Cells["v_ScheduleDetailId"].Value
                    .ToString();
                bool exit = new WorkerScheduleBL().DeleteWorkerScheduleDetail(_scheduleDetailId);
                if (!exit)
                {
                    MessageBox.Show("Sucedió un error, por favor vuelva a intentar.", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                BindingGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un detalle para continuar.", "VALIDACIÓN", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            
        }

      

        
       
    }
}
