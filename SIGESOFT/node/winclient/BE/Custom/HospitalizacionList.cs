using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    public class HospitalizacionList
    {
        public string v_HopitalizacionId { get; set; }
        public string v_PersonId { get; set; }
        public string v_DocNumber { get; set; }
        public int i_Years { get; set; }
        public DateTime d_Birthdate { get; set; }
        public string v_Paciente { get; set; }
        public DateTime? d_FechaIngreso { get; set; }
        public DateTime? d_FechaAlta { get; set; }
        public int i_IsDeleted { get; set; }
        public string v_Comentario { get; set; }
        public string v_NroLiquidacion { get; set; }
        public string v_NroHospitalizacion { get; set; }

        public decimal? d_PagoMedico { get; set; }
        public int? i_MedicoPago { get; set; }
        public string MedicoPago { get; set; }
        public decimal? d_PagoPaciente { get; set; }
        public int? i_PacientePago { get; set; }
        public string PacientePago { get; set; }

        public string v_MedicoTratante { get; set; }

        public string v_Servicio { get; set; }


        public List<HospitalizacionServiceList> Servicios{ get; set; }
        public List<HospitalizacionHabitacionList> Habitaciones { get; set; }
       
    }
    public class HospSopList
    {
        public string TipoDeIngreso { get; set; }
        public string TipoProcedimiento { get; set; }
        public DateTime? d_FechaIngreso { get; set; }
        public DateTime? d_FechaHoraCirugia { get; set; }
        public DateTime? d_FechaHoraHospPac { get; set; }
        public DateTime? d_FechaAlta { get; set; }
        public string v_Paciente { get; set; }
        public string TipoDocumento { get; set; }
        public string v_DocNumber { get; set; }
        public int? HistoriaClinica { get; set; }
        public int? Edad { get; set; }
        public string v_Cie10 { get; set; }
        public string v_Diagnostico { get; set; }
        public string v_MedicoTratante { get; set; }
        public string Especialidad { get; set; }
        public decimal? Monto { get; set; }
        public decimal? d_PagoMedico { get; set; }
        public string MedicoPago { get; set; }
        public decimal? d_PagoPaciente { get; set; }
        public string PacientePago { get; set; }
        public string v_CIE10IdSalida { get; set; }
        public string v_DiseasesNameSalida { get; set; }
        public int? i_ProcedimientoSOP { get; set; }
        public string v_ProcedimientoSOP { get; set; }
        public string v_Servicio { get; set; }
        public string v_NroLiquidacion { get; set; }
        public string VendedorExterno { get; set; }
        public string v_Comentariox { get; set; }
        public string v_HopitalizacionId { get; set; }
        public string v_PersonId { get; set; }
        public int? i_IsDeleted { get; set; }
        public string Value1 { get; set; }//v_NroHospitalizacion
        public string Value2 { get; set; }
    }

    public class EmergenciapList
    {
        public string TipoDeIngreso { get; set; }
        public DateTime? HoraCita { get; set; }
        public DateTime? d_FechaIngreso { get; set; }
        public DateTime? d_FechaEgreso { get; set; }
        public string v_Paciente { get; set; }
        public string TipoDocumento { get; set; }
        public string v_DocNumber { get; set; }
        public int? HistoriaClinica { get; set; }
        public int? Edad { get; set; }
        public string v_Cie10 { get; set; }
        public string v_Diagnostico { get; set; }
        public string v_MedicoTratante { get; set; }
        public string Especialidad { get; set; }
        public string Hospitalizado { get; set; }
        public string Value2 { get; set; }
        public decimal? Monto { get; set; }
        public decimal? d_PagoMedico { get; set; }
        public string MedicoPago { get; set; }
        public decimal? d_PagoPaciente { get; set; }
        public string PacientePago { get; set; }
        public string v_CIE10IdSalida { get; set; }
        public string v_DiseasesNameSalida { get; set; }
        public int? i_ProcedimientoSOP { get; set; }
        public string v_ProcedimientoSOP { get; set; }
        public string v_Servicio { get; set; }
        public string v_NroLiquidacion { get; set; }
        public string VendedorExterno { get; set; }
        public string v_Comentariox { get; set; }
        public string v_HopitalizacionId { get; set; }
        public string v_PersonId { get; set; }
        public int? i_IsDeleted { get; set; }
        public string Consultorio { get; set; }
        public string Value1 { get; set; }//v_NroHospitalizacion

    }

}
