//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:34:20
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
    public partial class historyclinicsDto
    {
        [DataMember()]
        public Int32 v_HCLId { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public Int32 v_nroHistoria { get; set; }

        public historyclinicsDto()
        {
        }

        public historyclinicsDto(Int32 v_HCLId, String v_PersonId, Int32 v_nroHistoria)
        {
			this.v_HCLId = v_HCLId;
			this.v_PersonId = v_PersonId;
			this.v_nroHistoria = v_nroHistoria;
        }
    }
}
