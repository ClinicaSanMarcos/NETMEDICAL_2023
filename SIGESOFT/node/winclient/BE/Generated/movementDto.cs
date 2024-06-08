//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/05 - 09:05:27
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
    public partial class movementDto
    {
        [DataMember()]
        public String v_MovementId { get; set; }

        [DataMember()]
        public String v_WarehouseId { get; set; }

        [DataMember()]
        public String v_SupplierId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ProcessTypeId { get; set; }

        [DataMember()]
        public String v_ParentMovementId { get; set; }

        [DataMember()]
        public String v_Motive { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MotiveTypeId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Date { get; set; }

        [DataMember()]
        public Nullable<Single> r_TotalQuantity { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MovementTypeId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_RequireRemoteProcess { get; set; }

        [DataMember()]
        public String v_RemoteWarehouseId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CurrencyId { get; set; }

        [DataMember()]
        public Nullable<Single> r_ExchangeRate { get; set; }

        [DataMember()]
        public String v_ReferenceDocument { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CostCenterId { get; set; }

        [DataMember()]
        public String v_Observations { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsLocallyProcessed { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsRemoteProcessed { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateNodeId { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public supplierDto supplier { get; set; }

        [DataMember()]
        public warehouseDto warehouse { get; set; }

        [DataMember()]
        public List<movementdetailDto> movementdetail { get; set; }

        public movementDto()
        {
        }

        public movementDto(String v_MovementId, String v_WarehouseId, String v_SupplierId, Nullable<Int32> i_ProcessTypeId, String v_ParentMovementId, String v_Motive, Nullable<Int32> i_MotiveTypeId, Nullable<DateTime> d_Date, Nullable<Single> r_TotalQuantity, Nullable<Int32> i_MovementTypeId, Nullable<Int32> i_RequireRemoteProcess, String v_RemoteWarehouseId, Nullable<Int32> i_CurrencyId, Nullable<Single> r_ExchangeRate, String v_ReferenceDocument, Nullable<Int32> i_CostCenterId, String v_Observations, Nullable<Int32> i_IsLocallyProcessed, Nullable<Int32> i_IsRemoteProcessed, Nullable<Int32> i_InsertUserId, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, Nullable<Int32> i_UpdateNodeId, String v_ComentaryUpdate, supplierDto supplier, warehouseDto warehouse, List<movementdetailDto> movementdetail)
        {
			this.v_MovementId = v_MovementId;
			this.v_WarehouseId = v_WarehouseId;
			this.v_SupplierId = v_SupplierId;
			this.i_ProcessTypeId = i_ProcessTypeId;
			this.v_ParentMovementId = v_ParentMovementId;
			this.v_Motive = v_Motive;
			this.i_MotiveTypeId = i_MotiveTypeId;
			this.d_Date = d_Date;
			this.r_TotalQuantity = r_TotalQuantity;
			this.i_MovementTypeId = i_MovementTypeId;
			this.i_RequireRemoteProcess = i_RequireRemoteProcess;
			this.v_RemoteWarehouseId = v_RemoteWarehouseId;
			this.i_CurrencyId = i_CurrencyId;
			this.r_ExchangeRate = r_ExchangeRate;
			this.v_ReferenceDocument = v_ReferenceDocument;
			this.i_CostCenterId = i_CostCenterId;
			this.v_Observations = v_Observations;
			this.i_IsLocallyProcessed = i_IsLocallyProcessed;
			this.i_IsRemoteProcessed = i_IsRemoteProcessed;
			this.i_InsertUserId = i_InsertUserId;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.i_UpdateNodeId = i_UpdateNodeId;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.supplier = supplier;
			this.warehouse = warehouse;
			this.movementdetail = movementdetail;
        }
    }
}
