//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:36:24
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
    /// Assembler for <see cref="workersscheduledetail"/> and <see cref="workersscheduledetailDto"/>.
    /// </summary>
    public static partial class workersscheduledetailAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="workersscheduledetailDto"/> converted from <see cref="workersscheduledetail"/>.</param>
        static partial void OnDTO(this workersscheduledetail entity, workersscheduledetailDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="workersscheduledetail"/> converted from <see cref="workersscheduledetailDto"/>.</param>
        static partial void OnEntity(this workersscheduledetailDto dto, workersscheduledetail entity);

        /// <summary>
        /// Converts this instance of <see cref="workersscheduledetailDto"/> to an instance of <see cref="workersscheduledetail"/>.
        /// </summary>
        /// <param name="dto"><see cref="workersscheduledetailDto"/> to convert.</param>
        public static workersscheduledetail ToEntity(this workersscheduledetailDto dto)
        {
            if (dto == null) return null;

            var entity = new workersscheduledetail();

            entity.v_ScheduleDetailId = dto.v_ScheduleDetailId;
            entity.v_ScheduleId = dto.v_ScheduleId;
            entity.v_PersonId = dto.v_PersonId;
            entity.d_Date = dto.d_Date;
            entity.t_StartDate = dto.t_StartDate;
            entity.t_StartBreak = dto.t_StartBreak;
            entity.t_EndBreak = dto.t_EndBreak;
            entity.t_EndDate = dto.t_EndDate;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="workersscheduledetail"/> to an instance of <see cref="workersscheduledetailDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="workersscheduledetail"/> to convert.</param>
        public static workersscheduledetailDto ToDTO(this workersscheduledetail entity)
        {
            if (entity == null) return null;

            var dto = new workersscheduledetailDto();

            dto.v_ScheduleDetailId = entity.v_ScheduleDetailId;
            dto.v_ScheduleId = entity.v_ScheduleId;
            dto.v_PersonId = entity.v_PersonId;
            dto.d_Date = entity.d_Date;
            dto.t_StartDate = entity.t_StartDate;
            dto.t_StartBreak = entity.t_StartBreak;
            dto.t_EndBreak = entity.t_EndBreak;
            dto.t_EndDate = entity.t_EndDate;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="workersscheduledetailDto"/> to an instance of <see cref="workersscheduledetail"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<workersscheduledetail> ToEntities(this IEnumerable<workersscheduledetailDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="workersscheduledetail"/> to an instance of <see cref="workersscheduledetailDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<workersscheduledetailDto> ToDTOs(this IEnumerable<workersscheduledetail> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
