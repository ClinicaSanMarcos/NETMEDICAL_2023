//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:59:48
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
    /// Assembler for <see cref="restriction"/> and <see cref="restrictionDto"/>.
    /// </summary>
    public static partial class restrictionAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="restrictionDto"/> converted from <see cref="restriction"/>.</param>
        static partial void OnDTO(this restriction entity, restrictionDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="restriction"/> converted from <see cref="restrictionDto"/>.</param>
        static partial void OnEntity(this restrictionDto dto, restriction entity);

        /// <summary>
        /// Converts this instance of <see cref="restrictionDto"/> to an instance of <see cref="restriction"/>.
        /// </summary>
        /// <param name="dto"><see cref="restrictionDto"/> to convert.</param>
        public static restriction ToEntity(this restrictionDto dto)
        {
            if (dto == null) return null;

            var entity = new restriction();

            entity.v_RestrictionId = dto.v_RestrictionId;
            entity.v_DiagnosticRepositoryId = dto.v_DiagnosticRepositoryId;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.v_ComponentId = dto.v_ComponentId;
            entity.v_MasterRestrictionId = dto.v_MasterRestrictionId;
            entity.d_StartDateRestriction = dto.d_StartDateRestriction;
            entity.d_EndDateRestriction = dto.d_EndDateRestriction;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="restriction"/> to an instance of <see cref="restrictionDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="restriction"/> to convert.</param>
        public static restrictionDto ToDTO(this restriction entity)
        {
            if (entity == null) return null;

            var dto = new restrictionDto();

            dto.v_RestrictionId = entity.v_RestrictionId;
            dto.v_DiagnosticRepositoryId = entity.v_DiagnosticRepositoryId;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.v_ComponentId = entity.v_ComponentId;
            dto.v_MasterRestrictionId = entity.v_MasterRestrictionId;
            dto.d_StartDateRestriction = entity.d_StartDateRestriction;
            dto.d_EndDateRestriction = entity.d_EndDateRestriction;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="restrictionDto"/> to an instance of <see cref="restriction"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<restriction> ToEntities(this IEnumerable<restrictionDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="restriction"/> to an instance of <see cref="restrictionDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<restrictionDto> ToDTOs(this IEnumerable<restriction> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
