//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 09:00:54
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
    /// Assembler for <see cref="vacations"/> and <see cref="vacationsDto"/>.
    /// </summary>
    public static partial class vacationsAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="vacationsDto"/> converted from <see cref="vacations"/>.</param>
        static partial void OnDTO(this vacations entity, vacationsDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="vacations"/> converted from <see cref="vacationsDto"/>.</param>
        static partial void OnEntity(this vacationsDto dto, vacations entity);

        /// <summary>
        /// Converts this instance of <see cref="vacationsDto"/> to an instance of <see cref="vacations"/>.
        /// </summary>
        /// <param name="dto"><see cref="vacationsDto"/> to convert.</param>
        public static vacations ToEntity(this vacationsDto dto)
        {
            if (dto == null) return null;

            var entity = new vacations();

            entity.v_VacationId = dto.v_VacationId;
            entity.v_PersonId = dto.v_PersonId;
            entity.i_IsProcessed = dto.i_IsProcessed;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.d_StartVacation = dto.d_StartVacation;
            entity.d_EndVacation = dto.d_EndVacation;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="vacations"/> to an instance of <see cref="vacationsDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="vacations"/> to convert.</param>
        public static vacationsDto ToDTO(this vacations entity)
        {
            if (entity == null) return null;

            var dto = new vacationsDto();

            dto.v_VacationId = entity.v_VacationId;
            dto.v_PersonId = entity.v_PersonId;
            dto.i_IsProcessed = entity.i_IsProcessed;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.d_StartVacation = entity.d_StartVacation;
            dto.d_EndVacation = entity.d_EndVacation;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="vacationsDto"/> to an instance of <see cref="vacations"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<vacations> ToEntities(this IEnumerable<vacationsDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="vacations"/> to an instance of <see cref="vacationsDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<vacationsDto> ToDTOs(this IEnumerable<vacations> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
