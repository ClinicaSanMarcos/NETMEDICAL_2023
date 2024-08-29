//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 09:00:12
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
    /// Assembler for <see cref="holidays"/> and <see cref="holidaysDto"/>.
    /// </summary>
    public static partial class holidaysAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="holidaysDto"/> converted from <see cref="holidays"/>.</param>
        static partial void OnDTO(this holidays entity, holidaysDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="holidays"/> converted from <see cref="holidaysDto"/>.</param>
        static partial void OnEntity(this holidaysDto dto, holidays entity);

        /// <summary>
        /// Converts this instance of <see cref="holidaysDto"/> to an instance of <see cref="holidays"/>.
        /// </summary>
        /// <param name="dto"><see cref="holidaysDto"/> to convert.</param>
        public static holidays ToEntity(this holidaysDto dto)
        {
            if (dto == null) return null;

            var entity = new holidays();

            entity.v_HolidayId = dto.v_HolidayId;
            entity.i_Year = dto.i_Year;
            entity.d_Date = dto.d_Date;
            entity.v_Reason = dto.v_Reason;
            entity.i_IsDeleted = dto.i_IsDeleted;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="holidays"/> to an instance of <see cref="holidaysDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="holidays"/> to convert.</param>
        public static holidaysDto ToDTO(this holidays entity)
        {
            if (entity == null) return null;

            var dto = new holidaysDto();

            dto.v_HolidayId = entity.v_HolidayId;
            dto.i_Year = entity.i_Year;
            dto.d_Date = entity.d_Date;
            dto.v_Reason = entity.v_Reason;
            dto.i_IsDeleted = entity.i_IsDeleted;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="holidaysDto"/> to an instance of <see cref="holidays"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<holidays> ToEntities(this IEnumerable<holidaysDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="holidays"/> to an instance of <see cref="holidaysDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<holidaysDto> ToDTOs(this IEnumerable<holidays> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
