//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:54:49
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
    public partial class historyclinicsdetailDto
    {
        [DataMember()]
        public Int32 v_HServiceId { get; set; }

        [DataMember()]
        public Int32 v_nroHistoria { get; set; }

        [DataMember()]
        public String v_ServiceId { get; set; }

        public historyclinicsdetailDto()
        {
        }

        public historyclinicsdetailDto(Int32 v_HServiceId, Int32 v_nroHistoria, String v_ServiceId)
        {
			this.v_HServiceId = v_HServiceId;
			this.v_nroHistoria = v_nroHistoria;
			this.v_ServiceId = v_ServiceId;
        }
    }
}
