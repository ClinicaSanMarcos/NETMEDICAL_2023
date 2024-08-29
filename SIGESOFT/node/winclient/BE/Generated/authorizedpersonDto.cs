//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 08:58:02
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
    public partial class authorizedpersonDto
    {
        [DataMember()]
        public String v_AuthorizedPersonId { get; set; }

        [DataMember()]
        public String v_FirstName { get; set; }

        [DataMember()]
        public String v_FirstLastName { get; set; }

        [DataMember()]
        public String v_SecondLastName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DocTypeId { get; set; }

        [DataMember()]
        public String v_DocTypeName { get; set; }

        [DataMember()]
        public String v_DocNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SexTypeId { get; set; }

        [DataMember()]
        public String v_SexTypeName { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_BirthDate { get; set; }

        [DataMember()]
        public String v_OccupationName { get; set; }

        [DataMember()]
        public String v_OrganitationName { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_EntryToMedicalCenter { get; set; }

        [DataMember()]
        public String v_ProtocolId { get; set; }

        [DataMember()]
        public String v_ProtocolName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        public authorizedpersonDto()
        {
        }

        public authorizedpersonDto(String v_AuthorizedPersonId, String v_FirstName, String v_FirstLastName, String v_SecondLastName, Nullable<Int32> i_DocTypeId, String v_DocTypeName, String v_DocNumber, Nullable<Int32> i_SexTypeId, String v_SexTypeName, Nullable<DateTime> d_BirthDate, String v_OccupationName, String v_OrganitationName, Nullable<DateTime> d_EntryToMedicalCenter, String v_ProtocolId, String v_ProtocolName, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate)
        {
			this.v_AuthorizedPersonId = v_AuthorizedPersonId;
			this.v_FirstName = v_FirstName;
			this.v_FirstLastName = v_FirstLastName;
			this.v_SecondLastName = v_SecondLastName;
			this.i_DocTypeId = i_DocTypeId;
			this.v_DocTypeName = v_DocTypeName;
			this.v_DocNumber = v_DocNumber;
			this.i_SexTypeId = i_SexTypeId;
			this.v_SexTypeName = v_SexTypeName;
			this.d_BirthDate = d_BirthDate;
			this.v_OccupationName = v_OccupationName;
			this.v_OrganitationName = v_OrganitationName;
			this.d_EntryToMedicalCenter = d_EntryToMedicalCenter;
			this.v_ProtocolId = v_ProtocolId;
			this.v_ProtocolName = v_ProtocolName;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
        }
    }
}
