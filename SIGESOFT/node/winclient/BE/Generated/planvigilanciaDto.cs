//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:34:50
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
    public partial class planvigilanciaDto
    {
        [DataMember()]
        public String v_PlanVigilanciaId { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

        [DataMember()]
        public String v_Description { get; set; }

        [DataMember()]
        public String v_OrganizationId { get; set; }

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
        public List<planvigilanciadiseasesDto> planvigilanciadiseases { get; set; }

        [DataMember()]
        public List<vigilanciaDto> vigilancia { get; set; }

        public planvigilanciaDto()
        {
        }

        public planvigilanciaDto(String v_PlanVigilanciaId, String v_Name, String v_Description, String v_OrganizationId, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, List<planvigilanciadiseasesDto> planvigilanciadiseases, List<vigilanciaDto> vigilancia)
        {
			this.v_PlanVigilanciaId = v_PlanVigilanciaId;
			this.v_Name = v_Name;
			this.v_Description = v_Description;
			this.v_OrganizationId = v_OrganizationId;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.planvigilanciadiseases = planvigilanciadiseases;
			this.vigilancia = vigilancia;
        }
    }
}
