//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:53:19
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
    public partial class productwarehouseDto
    {
        [DataMember()]
        public String v_WarehouseId { get; set; }

        [DataMember()]
        public String v_ProductId { get; set; }

        [DataMember()]
        public Nullable<Single> r_StockMin { get; set; }

        [DataMember()]
        public Nullable<Single> r_StockMax { get; set; }

        [DataMember()]
        public Nullable<Single> r_StockActual { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public productDto product { get; set; }

        [DataMember()]
        public warehouseDto warehouse { get; set; }

        public productwarehouseDto()
        {
        }

        public productwarehouseDto(String v_WarehouseId, String v_ProductId, Nullable<Single> r_StockMin, Nullable<Single> r_StockMax, Nullable<Single> r_StockActual, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, String v_ComentaryUpdate, productDto product, warehouseDto warehouse)
        {
			this.v_WarehouseId = v_WarehouseId;
			this.v_ProductId = v_ProductId;
			this.r_StockMin = r_StockMin;
			this.r_StockMax = r_StockMax;
			this.r_StockActual = r_StockActual;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.product = product;
			this.warehouse = warehouse;
        }
    }
}
