//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:52:29
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
    public partial class configuracionpagoDto
    {
        [DataMember()]
        public String v_IdConfPago { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SystemUserId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TipoPago { get; set; }

        [DataMember()]
        public Nullable<Single> d_MontoxTurno { get; set; }

        [DataMember()]
        public Nullable<Single> d_MonoxHora { get; set; }

        [DataMember()]
        public Nullable<Int32> i_OrdenExam { get; set; }

        [DataMember()]
        public Nullable<Single> d_PorcClinicaExam { get; set; }

        [DataMember()]
        public Nullable<Single> d_PorcMedicoExam { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DescontarBoletaExam { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DescontarRecbExam { get; set; }

        [DataMember()]
        public String v_Observaciones { get; set; }

        [DataMember()]
        public String v_ObservacionesCambios { get; set; }

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
        public Nullable<Int32> i_DescontarFactExam { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DesucuentodeHorario { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TipoDescuentoHoraMin { get; set; }

        [DataMember()]
        public List<configuracionexamenpagoDto> configuracionexamenpago { get; set; }

        [DataMember()]
        public configuracionpagoDto configuracionpago_v_IdConfPago1 { get; set; }

        [DataMember()]
        public configuracionpagoDto configuracionpago_v_IdConfPago { get; set; }

        [DataMember()]
        public systemuserDto systemuser { get; set; }

        public configuracionpagoDto()
        {
        }

        public configuracionpagoDto(String v_IdConfPago, Nullable<Int32> i_SystemUserId, Nullable<Int32> i_TipoPago, Nullable<Single> d_MontoxTurno, Nullable<Single> d_MonoxHora, Nullable<Int32> i_OrdenExam, Nullable<Single> d_PorcClinicaExam, Nullable<Single> d_PorcMedicoExam, Nullable<Int32> i_DescontarBoletaExam, Nullable<Int32> i_DescontarRecbExam, String v_Observaciones, String v_ObservacionesCambios, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Int32> i_DescontarFactExam, Nullable<Int32> i_DesucuentodeHorario, Nullable<Int32> i_TipoDescuentoHoraMin, List<configuracionexamenpagoDto> configuracionexamenpago, configuracionpagoDto configuracionpago_v_IdConfPago1, configuracionpagoDto configuracionpago_v_IdConfPago, systemuserDto systemuser)
        {
			this.v_IdConfPago = v_IdConfPago;
			this.i_SystemUserId = i_SystemUserId;
			this.i_TipoPago = i_TipoPago;
			this.d_MontoxTurno = d_MontoxTurno;
			this.d_MonoxHora = d_MonoxHora;
			this.i_OrdenExam = i_OrdenExam;
			this.d_PorcClinicaExam = d_PorcClinicaExam;
			this.d_PorcMedicoExam = d_PorcMedicoExam;
			this.i_DescontarBoletaExam = i_DescontarBoletaExam;
			this.i_DescontarRecbExam = i_DescontarRecbExam;
			this.v_Observaciones = v_Observaciones;
			this.v_ObservacionesCambios = v_ObservacionesCambios;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.i_DescontarFactExam = i_DescontarFactExam;
			this.i_DesucuentodeHorario = i_DesucuentodeHorario;
			this.i_TipoDescuentoHoraMin = i_TipoDescuentoHoraMin;
			this.configuracionexamenpago = configuracionexamenpago;
			this.configuracionpago_v_IdConfPago1 = configuracionpago_v_IdConfPago1;
			this.configuracionpago_v_IdConfPago = configuracionpago_v_IdConfPago;
			this.systemuser = systemuser;
        }
    }
}
