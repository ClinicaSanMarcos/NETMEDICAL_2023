//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:54:02
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
    public partial class blacklistpersonDto
    {
        [DataMember()]
        public String v_BlackListPerson { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public String v_Comment { get; set; }

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
        public Nullable<Int32> i_Status { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_DateRegister { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_DateDetection { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_DateSolution { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public personDto person { get; set; }

        public blacklistpersonDto()
        {
        }

        public blacklistpersonDto(String v_BlackListPerson, String v_PersonId, String v_Comment, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Int32> i_Status, Nullable<DateTime> d_DateRegister, Nullable<DateTime> d_DateDetection, Nullable<DateTime> d_DateSolution, String v_ComentaryUpdate, personDto person)
        {
			this.v_BlackListPerson = v_BlackListPerson;
			this.v_PersonId = v_PersonId;
			this.v_Comment = v_Comment;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.i_Status = i_Status;
			this.d_DateRegister = d_DateRegister;
			this.d_DateDetection = d_DateDetection;
			this.d_DateSolution = d_DateSolution;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.person = person;
        }
    }
}
