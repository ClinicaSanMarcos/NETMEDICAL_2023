//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:50:08
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
    public partial class obtenerpreciotarifarioResultDto
    {
        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public String v_ProtocolId { get; set; }

        [DataMember()]
        public String v_EmployerOrganizationId { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

        [DataMember()]
        public String v_IdentificationNumber { get; set; }

        [DataMember()]
        public Int32 i_IdListaPrecios { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Precio { get; set; }

        [DataMember()]
        public Int32 i_IdLista { get; set; }

        [DataMember()]
        public String v_IdListaPrecios { get; set; }

        public obtenerpreciotarifarioResultDto()
        {
        }

        public obtenerpreciotarifarioResultDto(String v_ServiceId, String v_ProtocolId, String v_EmployerOrganizationId, String v_Name, String v_IdentificationNumber, Int32 i_IdListaPrecios, Nullable<Decimal> d_Precio, Int32 i_IdLista, String v_IdListaPrecios)
        {
			this.v_ServiceId = v_ServiceId;
			this.v_ProtocolId = v_ProtocolId;
			this.v_EmployerOrganizationId = v_EmployerOrganizationId;
			this.v_Name = v_Name;
			this.v_IdentificationNumber = v_IdentificationNumber;
			this.i_IdListaPrecios = i_IdListaPrecios;
			this.d_Precio = d_Precio;
			this.i_IdLista = i_IdLista;
			this.v_IdListaPrecios = v_IdListaPrecios;
        }
    }
}
