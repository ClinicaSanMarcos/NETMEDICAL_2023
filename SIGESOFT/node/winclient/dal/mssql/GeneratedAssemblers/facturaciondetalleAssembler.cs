//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 09:00:10
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
    /// Assembler for <see cref="facturaciondetalle"/> and <see cref="facturaciondetalleDto"/>.
    /// </summary>
    public static partial class facturaciondetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="facturaciondetalleDto"/> converted from <see cref="facturaciondetalle"/>.</param>
        static partial void OnDTO(this facturaciondetalle entity, facturaciondetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="facturaciondetalle"/> converted from <see cref="facturaciondetalleDto"/>.</param>
        static partial void OnEntity(this facturaciondetalleDto dto, facturaciondetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="facturaciondetalleDto"/> to an instance of <see cref="facturaciondetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="facturaciondetalleDto"/> to convert.</param>
        public static facturaciondetalle ToEntity(this facturaciondetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new facturaciondetalle();

            entity.v_FacturacionDetalleId = dto.v_FacturacionDetalleId;
            entity.v_FacturacionId = dto.v_FacturacionId;
            entity.v_ServicioId = dto.v_ServicioId;
            entity.d_Monto = dto.d_Monto;
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
        /// Converts this instance of <see cref="facturaciondetalle"/> to an instance of <see cref="facturaciondetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="facturaciondetalle"/> to convert.</param>
        public static facturaciondetalleDto ToDTO(this facturaciondetalle entity)
        {
            if (entity == null) return null;

            var dto = new facturaciondetalleDto();

            dto.v_FacturacionDetalleId = entity.v_FacturacionDetalleId;
            dto.v_FacturacionId = entity.v_FacturacionId;
            dto.v_ServicioId = entity.v_ServicioId;
            dto.d_Monto = entity.d_Monto;
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
        /// Converts each instance of <see cref="facturaciondetalleDto"/> to an instance of <see cref="facturaciondetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<facturaciondetalle> ToEntities(this IEnumerable<facturaciondetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="facturaciondetalle"/> to an instance of <see cref="facturaciondetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<facturaciondetalleDto> ToDTOs(this IEnumerable<facturaciondetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
