//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:52:03
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
    public partial class getservicecomponents_1ResultDto
    {
        [DataMember()]
        public String v_ServiceComponentId { get; set; }

        [DataMember()]
        public String v_ComponentId { get; set; }

        [DataMember()]
        public Nullable<Single> r_Price { get; set; }

        [DataMember()]
        public String v_ComponentName { get; set; }

        [DataMember()]
        public String v_CategoryName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ConCargoA { get; set; }

        [DataMember()]
        public String MedicoTratante { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaAlta { get; set; }

        public getservicecomponents_1ResultDto()
        {
        }

        public getservicecomponents_1ResultDto(String v_ServiceComponentId, String v_ComponentId, Nullable<Single> r_Price, String v_ComponentName, String v_CategoryName, Nullable<Int32> i_ConCargoA, String medicoTratante, Nullable<DateTime> d_InsertDate, Nullable<DateTime> d_FechaAlta)
        {
			this.v_ServiceComponentId = v_ServiceComponentId;
			this.v_ComponentId = v_ComponentId;
			this.r_Price = r_Price;
			this.v_ComponentName = v_ComponentName;
			this.v_CategoryName = v_CategoryName;
			this.i_ConCargoA = i_ConCargoA;
			this.MedicoTratante = medicoTratante;
			this.d_InsertDate = d_InsertDate;
			this.d_FechaAlta = d_FechaAlta;
        }
    }
}
