//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:53:27
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
    public partial class getservicecomponentsreportc_spResultDto
    {
        [DataMember()]
        public String v_ComponentId { get; set; }

        [DataMember()]
        public String v_ComponentName { get; set; }

        [DataMember()]
        public String v_ServiceComponentId { get; set; }

        [DataMember()]
        public String v_CreationUser { get; set; }

        [DataMember()]
        public String v_UpdateUser { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_CreationDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CategoryId { get; set; }

        [DataMember()]
        public String v_CategoryName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceComponentStatusId { get; set; }

        [DataMember()]
        public Byte[] FirmaMedico { get; set; }

        public getservicecomponentsreportc_spResultDto()
        {
        }

        public getservicecomponentsreportc_spResultDto(String v_ComponentId, String v_ComponentName, String v_ServiceComponentId, String v_CreationUser, String v_UpdateUser, Nullable<DateTime> d_CreationDate, Nullable<DateTime> d_UpdateDate, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_CategoryId, String v_CategoryName, Nullable<Int32> i_ServiceComponentStatusId, Byte[] firmaMedico)
        {
			this.v_ComponentId = v_ComponentId;
			this.v_ComponentName = v_ComponentName;
			this.v_ServiceComponentId = v_ServiceComponentId;
			this.v_CreationUser = v_CreationUser;
			this.v_UpdateUser = v_UpdateUser;
			this.d_CreationDate = d_CreationDate;
			this.d_UpdateDate = d_UpdateDate;
			this.i_IsDeleted = i_IsDeleted;
			this.i_CategoryId = i_CategoryId;
			this.v_CategoryName = v_CategoryName;
			this.i_ServiceComponentStatusId = i_ServiceComponentStatusId;
			this.FirmaMedico = firmaMedico;
        }
    }
}
