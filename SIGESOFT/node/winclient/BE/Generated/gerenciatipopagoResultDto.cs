//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 08:57:43
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
    public partial class gerenciatipopagoResultDto
    {
        [DataMember()]
        public Nullable<Int32> IdCondicionPago { get; set; }

        [DataMember()]
        public String CondicionPago { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaFactura { get; set; }

        [DataMember()]
        public String Comprobante { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaFactura1 { get; set; }

        [DataMember()]
        public String Empresa { get; set; }

        [DataMember()]
        public String v_NroDocIdentificacion { get; set; }

        [DataMember()]
        public Nullable<Decimal> Importe { get; set; }

        [DataMember()]
        public String ServiceId { get; set; }

        [DataMember()]
        public String Trabajador { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaServicio { get; set; }

        [DataMember()]
        public String Compania { get; set; }

        [DataMember()]
        public String Contratista { get; set; }

        [DataMember()]
        public Nullable<Double> CostoExamen { get; set; }

        [DataMember()]
        public String TipoEso { get; set; }

        [DataMember()]
        public String Agrupador { get; set; }

        [DataMember()]
        public String UsuarioAgenda { get; set; }

        public gerenciatipopagoResultDto()
        {
        }

        public gerenciatipopagoResultDto(Nullable<Int32> idCondicionPago, String condicionPago, Nullable<DateTime> fechaFactura, String comprobante, Nullable<DateTime> fechaFactura1, String empresa, String v_NroDocIdentificacion, Nullable<Decimal> importe, String serviceId, String trabajador, Nullable<DateTime> fechaServicio, String compania, String contratista, Nullable<Double> costoExamen, String tipoEso, String agrupador, String usuarioAgenda)
        {
			this.IdCondicionPago = idCondicionPago;
			this.CondicionPago = condicionPago;
			this.FechaFactura = fechaFactura;
			this.Comprobante = comprobante;
			this.FechaFactura1 = fechaFactura1;
			this.Empresa = empresa;
			this.v_NroDocIdentificacion = v_NroDocIdentificacion;
			this.Importe = importe;
			this.ServiceId = serviceId;
			this.Trabajador = trabajador;
			this.FechaServicio = fechaServicio;
			this.Compania = compania;
			this.Contratista = contratista;
			this.CostoExamen = costoExamen;
			this.TipoEso = tipoEso;
			this.Agrupador = agrupador;
			this.UsuarioAgenda = usuarioAgenda;
        }
    }
}
