//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:52:02
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
    public partial class getlistservicespay_spResultDto
    {
        [DataMember()]
        public Nullable<Int32> i_MasterServiceId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MasterServiceTypeId { get; set; }

        [DataMember()]
        public Int32 MedicoTratanteId { get; set; }

        [DataMember()]
        public String MedicoTratante { get; set; }

        [DataMember()]
        public String Direccion { get; set; }

        [DataMember()]
        public String Telefono { get; set; }

        [DataMember()]
        public String CMP { get; set; }

        [DataMember()]
        public String Paciente { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ServiceDate { get; set; }

        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public String Tipo { get; set; }

        [DataMember()]
        public String v_ServiceComponentId { get; set; }

        [DataMember()]
        public Nullable<Single> r_CostoComponente { get; set; }

        [DataMember()]
        public String Componente { get; set; }

        [DataMember()]
        public String TipoProtocolo { get; set; }

        [DataMember()]
        public String Comprobante { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Total { get; set; }

        [DataMember()]
        public Nullable<Int32> GrupoId { get; set; }

        [DataMember()]
        public String Turno { get; set; }

        [DataMember()]
        public Nullable<Int32> CodigoId { get; set; }

        [DataMember()]
        public String Grupo { get; set; }

        [DataMember()]
        public String TipoComprobante { get; set; }

        [DataMember()]
        public String TipoMed { get; set; }

        public getlistservicespay_spResultDto()
        {
        }

        public getlistservicespay_spResultDto(Nullable<Int32> i_MasterServiceId, Nullable<Int32> i_MasterServiceTypeId, Int32 medicoTratanteId, String medicoTratante, String direccion, String telefono, String cMP, String paciente, Nullable<DateTime> d_ServiceDate, String v_ServiceId, String tipo, String v_ServiceComponentId, Nullable<Single> r_CostoComponente, String componente, String tipoProtocolo, String comprobante, Nullable<Decimal> d_Total, Nullable<Int32> grupoId, String turno, Nullable<Int32> codigoId, String grupo, String tipoComprobante, String tipoMed)
        {
			this.i_MasterServiceId = i_MasterServiceId;
			this.i_MasterServiceTypeId = i_MasterServiceTypeId;
			this.MedicoTratanteId = medicoTratanteId;
			this.MedicoTratante = medicoTratante;
			this.Direccion = direccion;
			this.Telefono = telefono;
			this.CMP = cMP;
			this.Paciente = paciente;
			this.d_ServiceDate = d_ServiceDate;
			this.v_ServiceId = v_ServiceId;
			this.Tipo = tipo;
			this.v_ServiceComponentId = v_ServiceComponentId;
			this.r_CostoComponente = r_CostoComponente;
			this.Componente = componente;
			this.TipoProtocolo = tipoProtocolo;
			this.Comprobante = comprobante;
			this.d_Total = d_Total;
			this.GrupoId = grupoId;
			this.Turno = turno;
			this.CodigoId = codigoId;
			this.Grupo = grupo;
			this.TipoComprobante = tipoComprobante;
			this.TipoMed = tipoMed;
        }
    }
}
