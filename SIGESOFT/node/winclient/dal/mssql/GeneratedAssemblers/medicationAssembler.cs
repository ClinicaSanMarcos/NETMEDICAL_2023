//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:46:33
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Sigesoft.Node.WinClient.DAL;

namespace Sigesoft.Node.WinClient.BE
{

    /// <summary>
    /// Assembler for <see cref="medication"/> and <see cref="medicationDto"/>.
    /// </summary>
    public static partial class medicationAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="medicationDto"/> converted from <see cref="medication"/>.</param>
        static partial void OnDTO(this medication entity, medicationDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="medication"/> converted from <see cref="medicationDto"/>.</param>
        static partial void OnEntity(this medicationDto dto, medication entity);

        /// <summary>
        /// Converts this instance of <see cref="medicationDto"/> to an instance of <see cref="medication"/>.
        /// </summary>
        /// <param name="dto"><see cref="medicationDto"/> to convert.</param>
        public static medication ToEntity(this medicationDto dto)
        {
            if (dto == null) return null;

            var entity = new medication();

            entity.v_MedicationId = dto.v_MedicationId;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.v_ProductId = dto.v_ProductId;
            entity.v_ProductName = dto.v_ProductName;
            entity.v_PresentationName = dto.v_PresentationName;
            entity.r_Quantity = dto.r_Quantity;
            entity.r_QuantityVendida = dto.r_QuantityVendida;
            entity.v_Doses = dto.v_Doses;
            entity.i_ViaId = dto.i_ViaId;
            entity.i_SeVendio = dto.i_SeVendio;
            entity.i_SeCreoAca = dto.i_SeCreoAca;
            entity.v_TipoDocVenta = dto.v_TipoDocVenta;
            entity.v_NroDocVenta = dto.v_NroDocVenta;
            entity.d_PrecioVenta = dto.d_PrecioVenta;
            entity.v_MedioPago = dto.v_MedioPago;
            entity.v_Vendedor = dto.v_Vendedor;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="medication"/> to an instance of <see cref="medicationDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="medication"/> to convert.</param>
        public static medicationDto ToDTO(this medication entity)
        {
            if (entity == null) return null;

            var dto = new medicationDto();

            dto.v_MedicationId = entity.v_MedicationId;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.v_ProductId = entity.v_ProductId;
            dto.v_ProductName = entity.v_ProductName;
            dto.v_PresentationName = entity.v_PresentationName;
            dto.r_Quantity = entity.r_Quantity;
            dto.r_QuantityVendida = entity.r_QuantityVendida;
            dto.v_Doses = entity.v_Doses;
            dto.i_ViaId = entity.i_ViaId;
            dto.i_SeVendio = entity.i_SeVendio;
            dto.i_SeCreoAca = entity.i_SeCreoAca;
            dto.v_TipoDocVenta = entity.v_TipoDocVenta;
            dto.v_NroDocVenta = entity.v_NroDocVenta;
            dto.d_PrecioVenta = entity.d_PrecioVenta;
            dto.v_MedioPago = entity.v_MedioPago;
            dto.v_Vendedor = entity.v_Vendedor;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="medicationDto"/> to an instance of <see cref="medication"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<medication> ToEntities(this IEnumerable<medicationDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="medication"/> to an instance of <see cref="medicationDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<medicationDto> ToDTOs(this IEnumerable<medication> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
