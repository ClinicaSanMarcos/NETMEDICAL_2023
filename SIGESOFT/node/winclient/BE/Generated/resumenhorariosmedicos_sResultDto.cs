//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/09 - 00:18:52
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
    public partial class resumenhorariosmedicos_sResultDto
    {
        [DataMember()]
        public String TIPO { get; set; }

        [DataMember()]
        public Int32 IdHorario { get; set; }

        [DataMember()]
        public String MEDICO { get; set; }

        [DataMember()]
        public String ESPECIALIDAD { get; set; }

        [DataMember()]
        public Nullable<Int32> INTERVALO { get; set; }

        [DataMember()]
        public Nullable<Int32> CONSULTORIO { get; set; }

        [DataMember()]
        public Nullable<Int32> CODIGO { get; set; }

        [DataMember()]
        public Nullable<DateTime> DIA { get; set; }

        [DataMember()]
        public String HoraInicio { get; set; }

        [DataMember()]
        public String HoraFin { get; set; }

        [DataMember()]
        public String TURNO { get; set; }

        public resumenhorariosmedicos_sResultDto()
        {
        }

        public resumenhorariosmedicos_sResultDto(String tIPO, Int32 idHorario, String mEDICO, String eSPECIALIDAD, Nullable<Int32> iNTERVALO, Nullable<Int32> cONSULTORIO, Nullable<Int32> cODIGO, Nullable<DateTime> dIA, String horaInicio, String horaFin, String tURNO)
        {
			this.TIPO = tIPO;
			this.IdHorario = idHorario;
			this.MEDICO = mEDICO;
			this.ESPECIALIDAD = eSPECIALIDAD;
			this.INTERVALO = iNTERVALO;
			this.CONSULTORIO = cONSULTORIO;
			this.CODIGO = cODIGO;
			this.DIA = dIA;
			this.HoraInicio = horaInicio;
			this.HoraFin = horaFin;
			this.TURNO = tURNO;
        }
    }
}
