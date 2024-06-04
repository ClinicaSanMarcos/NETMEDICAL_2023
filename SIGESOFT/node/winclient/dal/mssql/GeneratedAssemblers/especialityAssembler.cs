//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:46:24
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
    /// Assembler for <see cref="especiality"/> and <see cref="especialityDto"/>.
    /// </summary>
    public static partial class especialityAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="especialityDto"/> converted from <see cref="especiality"/>.</param>
        static partial void OnDTO(this especiality entity, especialityDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="especiality"/> converted from <see cref="especialityDto"/>.</param>
        static partial void OnEntity(this especialityDto dto, especiality entity);

        /// <summary>
        /// Converts this instance of <see cref="especialityDto"/> to an instance of <see cref="especiality"/>.
        /// </summary>
        /// <param name="dto"><see cref="especialityDto"/> to convert.</param>
        public static especiality ToEntity(this especialityDto dto)
        {
            if (dto == null) return null;

            var entity = new especiality();

            entity.v_EspecialityId = dto.v_EspecialityId;
            entity.v_EspecialityName = dto.v_EspecialityName;
            entity.b_EspecialityPicture = dto.b_EspecialityPicture;
            entity.t_TimeForAttention = dto.t_TimeForAttention;
            entity.r_Cost = dto.r_Cost;
            entity.v_Description = dto.v_Description;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.t_StartTime = dto.t_StartTime;
            entity.t_EndTime = dto.t_EndTime;
            entity.t_StartTime2 = dto.t_StartTime2;
            entity.t_EndTime2 = dto.t_EndTime2;
            entity.v_ProtocolId = dto.v_ProtocolId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="especiality"/> to an instance of <see cref="especialityDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="especiality"/> to convert.</param>
        public static especialityDto ToDTO(this especiality entity)
        {
            if (entity == null) return null;

            var dto = new especialityDto();

            dto.v_EspecialityId = entity.v_EspecialityId;
            dto.v_EspecialityName = entity.v_EspecialityName;
            dto.b_EspecialityPicture = entity.b_EspecialityPicture;
            dto.t_TimeForAttention = entity.t_TimeForAttention;
            dto.r_Cost = entity.r_Cost;
            dto.v_Description = entity.v_Description;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.t_StartTime = entity.t_StartTime;
            dto.t_EndTime = entity.t_EndTime;
            dto.t_StartTime2 = entity.t_StartTime2;
            dto.t_EndTime2 = entity.t_EndTime2;
            dto.v_ProtocolId = entity.v_ProtocolId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="especialityDto"/> to an instance of <see cref="especiality"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<especiality> ToEntities(this IEnumerable<especialityDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="especiality"/> to an instance of <see cref="especialityDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<especialityDto> ToDTOs(this IEnumerable<especiality> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
