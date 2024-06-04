//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:45:09
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
    public partial class professionalDto
    {
        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ProfessionId { get; set; }

        [DataMember()]
        public String v_ProfessionalCode { get; set; }

        [DataMember()]
        public String v_ProfessionalInformation { get; set; }

        [DataMember()]
        public Byte[] b_SignatureImage { get; set; }

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
        public Nullable<Int32> i_UpdateNodeId { get; set; }

        [DataMember()]
        public String v_ComponentId { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public Nullable<Decimal> r_MonthlyPayment { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_MonthlyHours { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_StartDateOfWork { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ContractFrom { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ContractUntil { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_CessationDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_GrupoHorario { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CodigoProfesion { get; set; }

        [DataMember()]
        public personDto person { get; set; }

        public professionalDto()
        {
        }

        public professionalDto(String v_PersonId, Nullable<Int32> i_ProfessionId, String v_ProfessionalCode, String v_ProfessionalInformation, Byte[] b_SignatureImage, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Int32> i_UpdateNodeId, String v_ComponentId, String v_ComentaryUpdate, Nullable<Decimal> r_MonthlyPayment, Nullable<TimeSpan> t_MonthlyHours, Nullable<DateTime> d_StartDateOfWork, Nullable<DateTime> d_ContractFrom, Nullable<DateTime> d_ContractUntil, Nullable<DateTime> d_CessationDate, Nullable<Int32> i_GrupoHorario, Nullable<Int32> i_CodigoProfesion, personDto person)
        {
			this.v_PersonId = v_PersonId;
			this.i_ProfessionId = i_ProfessionId;
			this.v_ProfessionalCode = v_ProfessionalCode;
			this.v_ProfessionalInformation = v_ProfessionalInformation;
			this.b_SignatureImage = b_SignatureImage;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.i_UpdateNodeId = i_UpdateNodeId;
			this.v_ComponentId = v_ComponentId;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.r_MonthlyPayment = r_MonthlyPayment;
			this.t_MonthlyHours = t_MonthlyHours;
			this.d_StartDateOfWork = d_StartDateOfWork;
			this.d_ContractFrom = d_ContractFrom;
			this.d_ContractUntil = d_ContractUntil;
			this.d_CessationDate = d_CessationDate;
			this.i_GrupoHorario = i_GrupoHorario;
			this.i_CodigoProfesion = i_CodigoProfesion;
			this.person = person;
        }
    }
}
