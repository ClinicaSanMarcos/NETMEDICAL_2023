using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE.Custom
{
    public class StateMarking
    {
        public bool Tardanza { get; set; }
        public TimeSpan TiempoTardanza { get; set; }
        public string TypeMarking { get; set; }
        public bool PermiteAntes { get; set; }
        public TimeSpan SobreTiempo { get; set; }
        public TimeSpan HoraEstablecida { get; set; }
        public bool PerteneceDia { get; set; }
        public string Dia { get; set; }
        //public string WorkerScheduleDetailId { get; set; }
    }
    public class WorkersScheduleCustom
    {
        public string v_ScheduleId { get; set; }
        public string v_ScheduleName { get; set; }
        public string v_ScheduleDescription { get; set; }
        public string v_Mes { get; set; }
        public string v_FullName { get; set; }
        public string v_Profesion { get; set; }
        public int? i_IsDeleted { get; set; }
        public int? i_InsertUserId { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public int? i_UpdateUserId { get; set; }
        public DateTime? d_UpdateDate { get; set; }
        public List<WorkersScheduleDetailCustom> ListDetail { get; set; }
    }

    public class WorkersScheduleDetailCustom
    {
        public string v_ScheduleDetailId { get; set; }
        public string v_ScheduleId { get; set; }
        public string v_FullName { get; set; }
        public string v_PersonId { get; set; }

        public DateTime? d_StartDate { get; set; }
        public DateTime? d_EndDate { get; set; }

        public TimeSpan? t_MondayStart { get; set; }
        public TimeSpan? t_MondayStartBreak { get; set; }
        public TimeSpan? t_MondayEndBreak { get; set; }
        public TimeSpan? t_MondayEnd { get; set; }

        public TimeSpan? t_TuesdayStart { get; set; }
        public TimeSpan? t_TuesdayStartBreak { get; set; }
        public TimeSpan? t_TuesdayEndBreak { get; set; }
        public TimeSpan? t_TuesdayEnd { get; set; }

        public TimeSpan? t_WednesdayStart { get; set; }
        public TimeSpan? t_WednesdayStartBreak { get; set; }
        public TimeSpan? t_WednesdayEndBreak { get; set; }
        public TimeSpan? t_WednesdayEnd { get; set; }

        public TimeSpan? t_ThrusdayStart { get; set; }
        public TimeSpan? t_ThrusdayStartBreak { get; set; }
        public TimeSpan? t_ThrusdayEndBreak { get; set; }
        public TimeSpan? t_ThrusdayEnd { get; set; }

        public TimeSpan? t_FridayStart { get; set; }
        public TimeSpan? t_FridayStartBreak { get; set; }
        public TimeSpan? t_FridayEndBreak { get; set; }
        public TimeSpan? t_FridayEnd { get; set; }

        public TimeSpan? t_SaturdayStart { get; set; }
        public TimeSpan? t_SaturdayStartBreak { get; set; }
        public TimeSpan? t_SaturdayEndBreak { get; set; }
        public TimeSpan? t_SaturdayEnd { get; set; }

        public TimeSpan? t_SundayStart { get; set; }
        public TimeSpan? t_SundayStartBreak { get; set; }
        public TimeSpan? t_SundayEndBreak { get; set; }
        public TimeSpan? t_SundayEnd { get; set; }

        public int? i_IsDeleted { get; set; }
        public int? i_InsertUserId { get; set; }
        public DateTime? d_InsertDate { get; set; }
        public int? i_UpdateUserId { get; set; }
        public DateTime? d_UpdateDate { get; set; }
    }

    public class ChartWorkercustom
    {
        public string Name { get; set; }
        public string PersonId { get; set; }
        public TimeSpan? Hours { get; set; }
    }


    public class MarkingsHeaderCustom
    {
        public bool Check { get; set; }
        public string v_PersonId { get; set; }
        public string v_ScheduleId { get; set; }
        public TimeSpan? t_HoursAgainst { get; set; }
        public TimeSpan? t_ExtraHours { get; set; }
        public TimeSpan? t_HorasAsignadas { get; set; }
        public TimeSpan? t_HorasTrabajadas { get; set; }
        public double? r_PagoHora { get; set; }
        public double? r_TotalPago { get; set; }
        public string v_PersonName { get; set; }
        public List<MarkingsCustom> Detalles { get; set; }
    }

    public class MarkingsCustom
    {

        public int MarkingId { get; set; }
        public string v_PersonId { get; set; }
        public string v_ScheduleId { get; set; }
        public string i_UserId { get; set; }
        public string v_UserName { get; set; }
        public TimeSpan? t_HoursAgainst { get; set; }
        public TimeSpan? t_ExtraHours { get; set; }

        public TimeSpan? t_StartHour { get; set; }
        public TimeSpan? t_StartBreakHour { get; set; }
        public TimeSpan? t_EndBreakHour { get; set; }
        public TimeSpan? t_EndHour { get; set; }

        public string v_PersonName { get; set; }
        public string v_TypeMarking { get; set; }
        public DateTime? d_Dialing { get; set; }
    }

    public class DataBoletaCustom
    {
        public string v_PersonId { get; set; }
        public string v_PersonName { get; set; }
        public string v_DocNumber { get; set; }
        public string v_MesPago { get; set; }
        public int DiasProgramados { get; set; }
        public int DiasCompletados { get; set; }
        public TimeSpan? TotalHorasAsignadas { get; set; }
        public TimeSpan? TotalHorasRealizadas { get; set; }
        public TimeSpan? TotalHorasExtras { get; set; }
        public TimeSpan? TotalHorasTardanzas { get; set; }
        public double? r_PagoHora { get; set; }
        public double? r_DescuentoHora { get; set; }
        public double? r_TotalPagoSinDsct { get; set; }
        public double? r_TotalDsct { get; set; }
        public double? r_TotalPago { get; set; }
    }

}
