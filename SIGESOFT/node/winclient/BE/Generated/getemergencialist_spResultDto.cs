//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:33:40
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    [DataContract()]
    public partial class getemergencialist_spResultDto
    {
        [DataMember()]
        public String TipoDeIngreso { get; set; }

        [DataMember()]
        public Nullable<DateTime> HoraCita { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaIngreso { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaEgreso { get; set; }

        [DataMember()]
        public String v_Paciente { get; set; }

        [DataMember()]
        public String TipoDocumento { get; set; }

        [DataMember()]
        public String v_DocNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> HistoriaClinica { get; set; }

        [DataMember()]
        public Nullable<Int32> Edad { get; set; }

        [DataMember()]
        public String v_Cie10 { get; set; }

        [DataMember()]
        public String v_Diagnostico { get; set; }

        [DataMember()]
        public String v_MedicoTratante { get; set; }

        [DataMember()]
        public String Especialidad { get; set; }

        [DataMember()]
        public String Hospitalizado { get; set; }

        [DataMember()]
        public String Value2 { get; set; }

        [DataMember()]
        public Nullable<Decimal> Monto { get; set; }

        [DataMember()]
        public Decimal d_PagoMedico { get; set; }

        [DataMember()]
        public String MedicoPago { get; set; }

        [DataMember()]
        public Decimal d_PagoPaciente { get; set; }

        [DataMember()]
        public String PacientePago { get; set; }

        [DataMember()]
        public String v_CIE10IdSalida { get; set; }

        [DataMember()]
        public String v_DiseasesNameSalida { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ProcedimientoSOP { get; set; }

        [DataMember()]
        public String v_ProcedimientoSOP { get; set; }

        [DataMember()]
        public String v_Servicio { get; set; }

        [DataMember()]
        public String v_NroLiquidacion { get; set; }

        [DataMember()]
        public String VendedorExterno { get; set; }

        [DataMember()]
        public String v_Comentariox { get; set; }

        [DataMember()]
        public String v_HopitalizacionId { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public String Consultorio { get; set; }

        [DataMember()]
        public String Value1 { get; set; }

        public getemergencialist_spResultDto()
        {
        }

        public getemergencialist_spResultDto(String tipoDeIngreso, Nullable<DateTime> horaCita, Nullable<DateTime> d_FechaIngreso, Nullable<DateTime> d_FechaEgreso, String v_Paciente, String tipoDocumento, String v_DocNumber, Nullable<Int32> historiaClinica, Nullable<Int32> edad, String v_Cie10, String v_Diagnostico, String v_MedicoTratante, String especialidad, String hospitalizado, String value2, Nullable<Decimal> monto, Decimal d_PagoMedico, String medicoPago, Decimal d_PagoPaciente, String pacientePago, String v_CIE10IdSalida, String v_DiseasesNameSalida, Nullable<Int32> i_ProcedimientoSOP, String v_ProcedimientoSOP, String v_Servicio, String v_NroLiquidacion, String vendedorExterno, String v_Comentariox, String v_HopitalizacionId, String v_PersonId, Nullable<Int32> i_IsDeleted, String consultorio, String value1)
        {
			this.TipoDeIngreso = tipoDeIngreso;
			this.HoraCita = horaCita;
			this.d_FechaIngreso = d_FechaIngreso;
			this.d_FechaEgreso = d_FechaEgreso;
			this.v_Paciente = v_Paciente;
			this.TipoDocumento = tipoDocumento;
			this.v_DocNumber = v_DocNumber;
			this.HistoriaClinica = historiaClinica;
			this.Edad = edad;
			this.v_Cie10 = v_Cie10;
			this.v_Diagnostico = v_Diagnostico;
			this.v_MedicoTratante = v_MedicoTratante;
			this.Especialidad = especialidad;
			this.Hospitalizado = hospitalizado;
			this.Value2 = value2;
			this.Monto = monto;
			this.d_PagoMedico = d_PagoMedico;
			this.MedicoPago = medicoPago;
			this.d_PagoPaciente = d_PagoPaciente;
			this.PacientePago = pacientePago;
			this.v_CIE10IdSalida = v_CIE10IdSalida;
			this.v_DiseasesNameSalida = v_DiseasesNameSalida;
			this.i_ProcedimientoSOP = i_ProcedimientoSOP;
			this.v_ProcedimientoSOP = v_ProcedimientoSOP;
			this.v_Servicio = v_Servicio;
			this.v_NroLiquidacion = v_NroLiquidacion;
			this.VendedorExterno = vendedorExterno;
			this.v_Comentariox = v_Comentariox;
			this.v_HopitalizacionId = v_HopitalizacionId;
			this.v_PersonId = v_PersonId;
			this.i_IsDeleted = i_IsDeleted;
			this.Consultorio = consultorio;
			this.Value1 = value1;
        }
    }
}
