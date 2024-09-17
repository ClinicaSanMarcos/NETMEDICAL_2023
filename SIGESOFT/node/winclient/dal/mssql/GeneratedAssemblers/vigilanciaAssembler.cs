//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:54:52
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
    /// Assembler for <see cref="vigilancia"/> and <see cref="vigilanciaDto"/>.
    /// </summary>
    public static partial class vigilanciaAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="vigilanciaDto"/> converted from <see cref="vigilancia"/>.</param>
        static partial void OnDTO(this vigilancia entity, vigilanciaDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="vigilancia"/> converted from <see cref="vigilanciaDto"/>.</param>
        static partial void OnEntity(this vigilanciaDto dto, vigilancia entity);

        /// <summary>
        /// Converts this instance of <see cref="vigilanciaDto"/> to an instance of <see cref="vigilancia"/>.
        /// </summary>
        /// <param name="dto"><see cref="vigilanciaDto"/> to convert.</param>
        public static vigilancia ToEntity(this vigilanciaDto dto)
        {
            if (dto == null) return null;

            var entity = new vigilancia();

            entity.v_VigilanciaId = dto.v_VigilanciaId;
            entity.v_PersonId = dto.v_PersonId;
            entity.v_PlanVigilanciaId = dto.v_PlanVigilanciaId;
            entity.i_WasNotifiedId = dto.i_WasNotifiedId;
            entity.i_ConfirmedNotification = dto.i_ConfirmedNotification;
            entity.v_Commentary = dto.v_Commentary;
            entity.i_DoctorRespondibleId = dto.i_DoctorRespondibleId;
            entity.i_StateVigilanciaId = dto.i_StateVigilanciaId;
            entity.d_StartDate = dto.d_StartDate;
            entity.d_EndDate = dto.d_EndDate;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="vigilancia"/> to an instance of <see cref="vigilanciaDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="vigilancia"/> to convert.</param>
        public static vigilanciaDto ToDTO(this vigilancia entity)
        {
            if (entity == null) return null;

            var dto = new vigilanciaDto();

            dto.v_VigilanciaId = entity.v_VigilanciaId;
            dto.v_PersonId = entity.v_PersonId;
            dto.v_PlanVigilanciaId = entity.v_PlanVigilanciaId;
            dto.i_WasNotifiedId = entity.i_WasNotifiedId;
            dto.i_ConfirmedNotification = entity.i_ConfirmedNotification;
            dto.v_Commentary = entity.v_Commentary;
            dto.i_DoctorRespondibleId = entity.i_DoctorRespondibleId;
            dto.i_StateVigilanciaId = entity.i_StateVigilanciaId;
            dto.d_StartDate = entity.d_StartDate;
            dto.d_EndDate = entity.d_EndDate;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="vigilanciaDto"/> to an instance of <see cref="vigilancia"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<vigilancia> ToEntities(this IEnumerable<vigilanciaDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="vigilancia"/> to an instance of <see cref="vigilanciaDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<vigilanciaDto> ToDTOs(this IEnumerable<vigilancia> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
