//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:50:42
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
    public partial class especialityDto
    {
        [DataMember()]
        public String v_EspecialityId { get; set; }

        [DataMember()]
        public String v_EspecialityName { get; set; }

        [DataMember()]
        public Byte[] b_EspecialityPicture { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_TimeForAttention { get; set; }

        [DataMember()]
        public Nullable<Decimal> r_Cost { get; set; }

        [DataMember()]
        public String v_Description { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_StartTime { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_EndTime { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_StartTime2 { get; set; }

        [DataMember()]
        public Nullable<TimeSpan> t_EndTime2 { get; set; }

        [DataMember()]
        public String v_ProtocolId { get; set; }

        public especialityDto()
        {
        }

        public especialityDto(String v_EspecialityId, String v_EspecialityName, Byte[] b_EspecialityPicture, Nullable<TimeSpan> t_TimeForAttention, Nullable<Decimal> r_Cost, String v_Description, Nullable<Int32> i_IsDeleted, Nullable<TimeSpan> t_StartTime, Nullable<TimeSpan> t_EndTime, Nullable<TimeSpan> t_StartTime2, Nullable<TimeSpan> t_EndTime2, String v_ProtocolId)
        {
			this.v_EspecialityId = v_EspecialityId;
			this.v_EspecialityName = v_EspecialityName;
			this.b_EspecialityPicture = b_EspecialityPicture;
			this.t_TimeForAttention = t_TimeForAttention;
			this.r_Cost = r_Cost;
			this.v_Description = v_Description;
			this.i_IsDeleted = i_IsDeleted;
			this.t_StartTime = t_StartTime;
			this.t_EndTime = t_EndTime;
			this.t_StartTime2 = t_StartTime2;
			this.t_EndTime2 = t_EndTime2;
			this.v_ProtocolId = v_ProtocolId;
        }
    }
}
