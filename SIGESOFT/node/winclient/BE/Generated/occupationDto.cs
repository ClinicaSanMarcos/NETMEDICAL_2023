//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:55:39
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
    public partial class occupationDto
    {
        [DataMember()]
        public String v_OccupationId { get; set; }

        [DataMember()]
        public String v_GesId { get; set; }

        [DataMember()]
        public String v_GroupOccupationId { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

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
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public gesDto ges { get; set; }

        [DataMember()]
        public groupoccupationDto groupoccupation { get; set; }

        public occupationDto()
        {
        }

        public occupationDto(String v_OccupationId, String v_GesId, String v_GroupOccupationId, String v_Name, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, String v_ComentaryUpdate, gesDto ges, groupoccupationDto groupoccupation)
        {
			this.v_OccupationId = v_OccupationId;
			this.v_GesId = v_GesId;
			this.v_GroupOccupationId = v_GroupOccupationId;
			this.v_Name = v_Name;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.ges = ges;
			this.groupoccupation = groupoccupation;
        }
    }
}
