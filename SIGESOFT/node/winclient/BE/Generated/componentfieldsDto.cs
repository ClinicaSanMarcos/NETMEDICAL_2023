//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/09 - 00:19:04
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
    public partial class componentfieldsDto
    {
        [DataMember()]
        public String v_ComponentId { get; set; }

        [DataMember()]
        public String v_ComponentFieldId { get; set; }

        [DataMember()]
        public String v_Group { get; set; }

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
        public componentDto component { get; set; }

        [DataMember()]
        public componentfieldDto componentfield { get; set; }

        [DataMember()]
        public List<diagnosticrepositoryDto> diagnosticrepository { get; set; }

        [DataMember()]
        public List<servicecomponentfieldsDto> servicecomponentfields { get; set; }

        public componentfieldsDto()
        {
        }

        public componentfieldsDto(String v_ComponentId, String v_ComponentFieldId, String v_Group, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, String v_ComentaryUpdate, componentDto component, componentfieldDto componentfield, List<diagnosticrepositoryDto> diagnosticrepository, List<servicecomponentfieldsDto> servicecomponentfields)
        {
			this.v_ComponentId = v_ComponentId;
			this.v_ComponentFieldId = v_ComponentFieldId;
			this.v_Group = v_Group;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.component = component;
			this.componentfield = componentfield;
			this.diagnosticrepository = diagnosticrepository;
			this.servicecomponentfields = servicecomponentfields;
        }
    }
}
