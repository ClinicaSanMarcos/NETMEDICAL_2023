//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:52:08
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
    public partial class obtenervaloresResultDto
    {
        [DataMember()]
        public String v_ServiceComponentFieldsId { get; set; }

        [DataMember()]
        public String v_Value1 { get; set; }

        [DataMember()]
        public String v_MeasurementUnitName { get; set; }

        [DataMember()]
        public String v_Value1Name { get; set; }

        [DataMember()]
        public String v_ComponentFielName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_GroupId { get; set; }

        [DataMember()]
        public String v_ComponentId { get; set; }

        [DataMember()]
        public String v_ServiceComponentId { get; set; }

        [DataMember()]
        public String v_ComponentFieldsId { get; set; }

        public obtenervaloresResultDto()
        {
        }

        public obtenervaloresResultDto(String v_ServiceComponentFieldsId, String v_Value1, String v_MeasurementUnitName, String v_Value1Name, String v_ComponentFielName, Nullable<Int32> i_GroupId, String v_ComponentId, String v_ServiceComponentId, String v_ComponentFieldsId)
        {
			this.v_ServiceComponentFieldsId = v_ServiceComponentFieldsId;
			this.v_Value1 = v_Value1;
			this.v_MeasurementUnitName = v_MeasurementUnitName;
			this.v_Value1Name = v_Value1Name;
			this.v_ComponentFielName = v_ComponentFielName;
			this.i_GroupId = i_GroupId;
			this.v_ComponentId = v_ComponentId;
			this.v_ServiceComponentId = v_ServiceComponentId;
			this.v_ComponentFieldsId = v_ComponentFieldsId;
        }
    }
}
