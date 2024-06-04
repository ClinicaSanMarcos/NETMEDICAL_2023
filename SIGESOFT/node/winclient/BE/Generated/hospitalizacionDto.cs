//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:44:21
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
    public partial class hospitalizacionDto
    {
        [DataMember()]
        public String v_HopitalizacionId { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaIngreso { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaAlta { get; set; }

        [DataMember()]
        public String v_Comentario { get; set; }

        [DataMember()]
        public String v_NroLiquidacion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_PagoMedico { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoPago { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_PagoPaciente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PacientePago { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public String v_CIEIdIngreso { get; set; }

        [DataMember()]
        public String v_DxIngreso { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TipoProcedimiento { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaHoraHospitalizacion { get; set; }

        [DataMember()]
        public String v_MedicoPricipal { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_MontoTotalPagar { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Hospitalizado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Procedimiento { get; set; }

        [DataMember()]
        public String v_ComprobanteDePago { get; set; }

        [DataMember()]
        public String v_CIEIdSalida { get; set; }

        [DataMember()]
        public String v_DxSalida { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaHoraInicioSop { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaHoraFinSop { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TramaHosp { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TramaSop { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ProcedimientoSOP { get; set; }

        [DataMember()]
        public String v_ProcedimientoSOP { get; set; }

        [DataMember()]
        public List<hospitalizacionserviceDto> hospitalizacionservice { get; set; }

        public hospitalizacionDto()
        {
        }

        public hospitalizacionDto(String v_HopitalizacionId, String v_PersonId, Nullable<DateTime> d_FechaIngreso, Nullable<DateTime> d_FechaAlta, String v_Comentario, String v_NroLiquidacion, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Decimal> d_PagoMedico, Nullable<Int32> i_MedicoPago, Nullable<Decimal> d_PagoPaciente, Nullable<Int32> i_PacientePago, String v_ComentaryUpdate, String v_CIEIdIngreso, String v_DxIngreso, Nullable<Int32> i_TipoProcedimiento, Nullable<DateTime> d_FechaHoraHospitalizacion, String v_MedicoPricipal, Nullable<Decimal> d_MontoTotalPagar, Nullable<Int32> i_Hospitalizado, Nullable<Int32> i_Procedimiento, String v_ComprobanteDePago, String v_CIEIdSalida, String v_DxSalida, Nullable<DateTime> d_FechaHoraInicioSop, Nullable<DateTime> d_FechaHoraFinSop, Nullable<Int32> i_TramaHosp, Nullable<Int32> i_TramaSop, Nullable<Int32> i_ProcedimientoSOP, String v_ProcedimientoSOP, List<hospitalizacionserviceDto> hospitalizacionservice)
        {
			this.v_HopitalizacionId = v_HopitalizacionId;
			this.v_PersonId = v_PersonId;
			this.d_FechaIngreso = d_FechaIngreso;
			this.d_FechaAlta = d_FechaAlta;
			this.v_Comentario = v_Comentario;
			this.v_NroLiquidacion = v_NroLiquidacion;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.d_PagoMedico = d_PagoMedico;
			this.i_MedicoPago = i_MedicoPago;
			this.d_PagoPaciente = d_PagoPaciente;
			this.i_PacientePago = i_PacientePago;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.v_CIEIdIngreso = v_CIEIdIngreso;
			this.v_DxIngreso = v_DxIngreso;
			this.i_TipoProcedimiento = i_TipoProcedimiento;
			this.d_FechaHoraHospitalizacion = d_FechaHoraHospitalizacion;
			this.v_MedicoPricipal = v_MedicoPricipal;
			this.d_MontoTotalPagar = d_MontoTotalPagar;
			this.i_Hospitalizado = i_Hospitalizado;
			this.i_Procedimiento = i_Procedimiento;
			this.v_ComprobanteDePago = v_ComprobanteDePago;
			this.v_CIEIdSalida = v_CIEIdSalida;
			this.v_DxSalida = v_DxSalida;
			this.d_FechaHoraInicioSop = d_FechaHoraInicioSop;
			this.d_FechaHoraFinSop = d_FechaHoraFinSop;
			this.i_TramaHosp = i_TramaHosp;
			this.i_TramaSop = i_TramaSop;
			this.i_ProcedimientoSOP = i_ProcedimientoSOP;
			this.v_ProcedimientoSOP = v_ProcedimientoSOP;
			this.hospitalizacionservice = hospitalizacionservice;
        }
    }
}
