//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2019/07/04 - 12:29:22
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sigesoft.Server.WebClientAdmin.BE
{
    [DataContract()]
    public partial class masterrecommendationrestricctionDto
    {
        [DataMember()]
        public String v_MasterRecommendationRestricctionId { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TypifyingId { get; set; }

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
        public List<componentfieldvaluesrecommendationDto> componentfieldvaluesrecommendation { get; set; }

        [DataMember()]
        public List<componentfieldvaluesrestrictionDto> componentfieldvaluesrestriction { get; set; }

        public masterrecommendationrestricctionDto()
        {
        }

        public masterrecommendationrestricctionDto(String v_MasterRecommendationRestricctionId, String v_Name, Nullable<Int32> i_TypifyingId, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, String v_ComentaryUpdate, List<componentfieldvaluesrecommendationDto> componentfieldvaluesrecommendation, List<componentfieldvaluesrestrictionDto> componentfieldvaluesrestriction)
        {
			this.v_MasterRecommendationRestricctionId = v_MasterRecommendationRestricctionId;
			this.v_Name = v_Name;
			this.i_TypifyingId = i_TypifyingId;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.componentfieldvaluesrecommendation = componentfieldvaluesrecommendation;
			this.componentfieldvaluesrestriction = componentfieldvaluesrestriction;
        }
    }
}
