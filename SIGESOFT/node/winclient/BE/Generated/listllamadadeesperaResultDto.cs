//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:53:34
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
    public partial class listllamadadeesperaResultDto
    {
        [DataMember()]
        public String PACIENTE { get; set; }

        [DataMember()]
        public String HORARIO { get; set; }

        [DataMember()]
        public String Medico { get; set; }

        [DataMember()]
        public String TURNO { get; set; }

        [DataMember()]
        public String APTITUD { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ServiceDate { get; set; }

        [DataMember()]
        public String v_Value1 { get; set; }

        [DataMember()]
        public String v_UserName { get; set; }

        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public Int32 i_SystemUserId { get; set; }

        [DataMember()]
        public Int32 i_ParameterId { get; set; }

        [DataMember()]
        public Int32 i_ParameterId1 { get; set; }

        [DataMember()]
        public Int32 i_GroupId { get; set; }

        [DataMember()]
        public String ESPECIALIDAD { get; set; }

        [DataMember()]
        public String v_CalendarId { get; set; }

        [DataMember()]
        public String Protocolo { get; set; }

        public listllamadadeesperaResultDto()
        {
        }

        public listllamadadeesperaResultDto(String pACIENTE, String hORARIO, String medico, String tURNO, String aPTITUD, Nullable<DateTime> d_ServiceDate, String v_Value1, String v_UserName, String v_ServiceId, Int32 i_SystemUserId, Int32 i_ParameterId, Int32 i_ParameterId1, Int32 i_GroupId, String eSPECIALIDAD, String v_CalendarId, String protocolo)
        {
			this.PACIENTE = pACIENTE;
			this.HORARIO = hORARIO;
			this.Medico = medico;
			this.TURNO = tURNO;
			this.APTITUD = aPTITUD;
			this.d_ServiceDate = d_ServiceDate;
			this.v_Value1 = v_Value1;
			this.v_UserName = v_UserName;
			this.v_ServiceId = v_ServiceId;
			this.i_SystemUserId = i_SystemUserId;
			this.i_ParameterId = i_ParameterId;
			this.i_ParameterId1 = i_ParameterId1;
			this.i_GroupId = i_GroupId;
			this.ESPECIALIDAD = eSPECIALIDAD;
			this.v_CalendarId = v_CalendarId;
			this.Protocolo = protocolo;
        }
    }
}
