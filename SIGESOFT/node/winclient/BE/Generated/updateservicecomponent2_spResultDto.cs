//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/05 - 09:04:34
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
    public partial class updateservicecomponent2_spResultDto
    {
        [DataMember()]
        public String v_ServiceComponentId { get; set; }

        public updateservicecomponent2_spResultDto()
        {
        }

        public updateservicecomponent2_spResultDto(String v_ServiceComponentId)
        {
			this.v_ServiceComponentId = v_ServiceComponentId;
        }
    }
}
