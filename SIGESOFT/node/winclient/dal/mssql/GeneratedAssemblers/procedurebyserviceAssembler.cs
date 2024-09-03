//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:36:04
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
    /// Assembler for <see cref="procedurebyservice"/> and <see cref="procedurebyserviceDto"/>.
    /// </summary>
    public static partial class procedurebyserviceAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="procedurebyserviceDto"/> converted from <see cref="procedurebyservice"/>.</param>
        static partial void OnDTO(this procedurebyservice entity, procedurebyserviceDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="procedurebyservice"/> converted from <see cref="procedurebyserviceDto"/>.</param>
        static partial void OnEntity(this procedurebyserviceDto dto, procedurebyservice entity);

        /// <summary>
        /// Converts this instance of <see cref="procedurebyserviceDto"/> to an instance of <see cref="procedurebyservice"/>.
        /// </summary>
        /// <param name="dto"><see cref="procedurebyserviceDto"/> to convert.</param>
        public static procedurebyservice ToEntity(this procedurebyserviceDto dto)
        {
            if (dto == null) return null;

            var entity = new procedurebyservice();

            entity.v_ProcedureByServiceId = dto.v_ProcedureByServiceId;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.i_ProcedureId = dto.i_ProcedureId;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.i_ProcedureTypeId = dto.i_ProcedureTypeId;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="procedurebyservice"/> to an instance of <see cref="procedurebyserviceDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="procedurebyservice"/> to convert.</param>
        public static procedurebyserviceDto ToDTO(this procedurebyservice entity)
        {
            if (entity == null) return null;

            var dto = new procedurebyserviceDto();

            dto.v_ProcedureByServiceId = entity.v_ProcedureByServiceId;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.i_ProcedureId = entity.i_ProcedureId;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.i_ProcedureTypeId = entity.i_ProcedureTypeId;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="procedurebyserviceDto"/> to an instance of <see cref="procedurebyservice"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<procedurebyservice> ToEntities(this IEnumerable<procedurebyserviceDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="procedurebyservice"/> to an instance of <see cref="procedurebyserviceDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<procedurebyserviceDto> ToDTOs(this IEnumerable<procedurebyservice> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
