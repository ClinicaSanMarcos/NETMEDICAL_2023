//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:53:24
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
    public partial class recetaDto
    {
        [DataMember()]
        public Int32 i_IdReceta { get; set; }

        [DataMember()]
        public String v_DiagnosticRepositoryId { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Cantidad { get; set; }

        [DataMember()]
        public String v_Posologia { get; set; }

        [DataMember()]
        public String v_Duracion { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaFin { get; set; }

        [DataMember()]
        public String v_IdProductoDetalle { get; set; }

        [DataMember()]
        public String v_Lote { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdAlmacen { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Lleva { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NoLleva { get; set; }

        [DataMember()]
        public String v_IdVentaPaciente { get; set; }

        [DataMember()]
        public String v_IdVentaAseguradora { get; set; }

        [DataMember()]
        public String v_IdUnidadProductiva { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SaldoPaciente { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SaldoAseguradora { get; set; }

        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_isDelete { get; set; }

        public recetaDto()
        {
        }

        public recetaDto(Int32 i_IdReceta, String v_DiagnosticRepositoryId, Nullable<Decimal> d_Cantidad, String v_Posologia, String v_Duracion, Nullable<DateTime> t_FechaFin, String v_IdProductoDetalle, String v_Lote, Nullable<Int32> i_IdAlmacen, Nullable<Int32> i_Lleva, Nullable<Int32> i_NoLleva, String v_IdVentaPaciente, String v_IdVentaAseguradora, String v_IdUnidadProductiva, Nullable<Decimal> d_SaldoPaciente, Nullable<Decimal> d_SaldoAseguradora, String v_ServiceId, String v_ComentaryUpdate, Nullable<Int32> i_isDelete)
        {
			this.i_IdReceta = i_IdReceta;
			this.v_DiagnosticRepositoryId = v_DiagnosticRepositoryId;
			this.d_Cantidad = d_Cantidad;
			this.v_Posologia = v_Posologia;
			this.v_Duracion = v_Duracion;
			this.t_FechaFin = t_FechaFin;
			this.v_IdProductoDetalle = v_IdProductoDetalle;
			this.v_Lote = v_Lote;
			this.i_IdAlmacen = i_IdAlmacen;
			this.i_Lleva = i_Lleva;
			this.i_NoLleva = i_NoLleva;
			this.v_IdVentaPaciente = v_IdVentaPaciente;
			this.v_IdVentaAseguradora = v_IdVentaAseguradora;
			this.v_IdUnidadProductiva = v_IdUnidadProductiva;
			this.d_SaldoPaciente = d_SaldoPaciente;
			this.d_SaldoAseguradora = d_SaldoAseguradora;
			this.v_ServiceId = v_ServiceId;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.i_isDelete = i_isDelete;
        }
    }
}
