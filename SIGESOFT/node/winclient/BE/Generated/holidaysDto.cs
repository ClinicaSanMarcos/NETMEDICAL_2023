//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:54:50
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
    public partial class holidaysDto
    {
        [DataMember()]
        public String v_HolidayId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Year { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Date { get; set; }

        [DataMember()]
        public String v_Reason { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        public holidaysDto()
        {
        }

        public holidaysDto(String v_HolidayId, Nullable<Int32> i_Year, Nullable<DateTime> d_Date, String v_Reason, Nullable<Int32> i_IsDeleted)
        {
			this.v_HolidayId = v_HolidayId;
			this.i_Year = i_Year;
			this.d_Date = d_Date;
			this.v_Reason = v_Reason;
			this.i_IsDeleted = i_IsDeleted;
        }
    }
}
