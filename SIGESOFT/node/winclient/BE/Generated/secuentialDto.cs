//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/05/24 - 18:03:30
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
    public partial class secuentialDto
    {
        [DataMember()]
        public Int32 i_NodeId { get; set; }

        [DataMember()]
        public Int32 i_TableId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SecuentialId { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        public secuentialDto()
        {
        }

        public secuentialDto(Int32 i_NodeId, Int32 i_TableId, Nullable<Int32> i_SecuentialId, String v_ComentaryUpdate)
        {
			this.i_NodeId = i_NodeId;
			this.i_TableId = i_TableId;
			this.i_SecuentialId = i_SecuentialId;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
        }
    }
}
