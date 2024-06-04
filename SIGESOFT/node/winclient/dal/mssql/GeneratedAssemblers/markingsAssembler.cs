//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:46:32
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
    /// Assembler for <see cref="markings"/> and <see cref="markingsDto"/>.
    /// </summary>
    public static partial class markingsAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="markingsDto"/> converted from <see cref="markings"/>.</param>
        static partial void OnDTO(this markings entity, markingsDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="markings"/> converted from <see cref="markingsDto"/>.</param>
        static partial void OnEntity(this markingsDto dto, markings entity);

        /// <summary>
        /// Converts this instance of <see cref="markingsDto"/> to an instance of <see cref="markings"/>.
        /// </summary>
        /// <param name="dto"><see cref="markingsDto"/> to convert.</param>
        public static markings ToEntity(this markingsDto dto)
        {
            if (dto == null) return null;

            var entity = new markings();

            entity.i_DialingId = dto.i_DialingId;
            entity.v_PersonId = dto.v_PersonId;
            entity.d_DialingDate = dto.d_DialingDate;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.v_TypeMarking = dto.v_TypeMarking;
            entity.i_PaidOut = dto.i_PaidOut;
            entity.t_ExtraHours = dto.t_ExtraHours;
            entity.t_HoursAgainst = dto.t_HoursAgainst;
            entity.v_ScheduleDetailId = dto.v_ScheduleDetailId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="markings"/> to an instance of <see cref="markingsDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="markings"/> to convert.</param>
        public static markingsDto ToDTO(this markings entity)
        {
            if (entity == null) return null;

            var dto = new markingsDto();

            dto.i_DialingId = entity.i_DialingId;
            dto.v_PersonId = entity.v_PersonId;
            dto.d_DialingDate = entity.d_DialingDate;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.v_TypeMarking = entity.v_TypeMarking;
            dto.i_PaidOut = entity.i_PaidOut;
            dto.t_ExtraHours = entity.t_ExtraHours;
            dto.t_HoursAgainst = entity.t_HoursAgainst;
            dto.v_ScheduleDetailId = entity.v_ScheduleDetailId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="markingsDto"/> to an instance of <see cref="markings"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<markings> ToEntities(this IEnumerable<markingsDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="markings"/> to an instance of <see cref="markingsDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<markingsDto> ToDTOs(this IEnumerable<markings> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
