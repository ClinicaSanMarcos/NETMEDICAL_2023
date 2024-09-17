//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:54:20
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
    /// Assembler for <see cref="horarios"/> and <see cref="horariosDto"/>.
    /// </summary>
    public static partial class horariosAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="horariosDto"/> converted from <see cref="horarios"/>.</param>
        static partial void OnDTO(this horarios entity, horariosDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="horarios"/> converted from <see cref="horariosDto"/>.</param>
        static partial void OnEntity(this horariosDto dto, horarios entity);

        /// <summary>
        /// Converts this instance of <see cref="horariosDto"/> to an instance of <see cref="horarios"/>.
        /// </summary>
        /// <param name="dto"><see cref="horariosDto"/> to convert.</param>
        public static horarios ToEntity(this horariosDto dto)
        {
            if (dto == null) return null;

            var entity = new horarios();

            entity.IdHorario = dto.IdHorario;
            entity.i_SystemUserId = dto.i_SystemUserId;
            entity.d_FechaInicio = dto.d_FechaInicio;
            entity.d_FechaFin = dto.d_FechaFin;
            entity.i_01 = dto.i_01;
            entity.i_02 = dto.i_02;
            entity.i_03 = dto.i_03;
            entity.i_04 = dto.i_04;
            entity.i_05 = dto.i_05;
            entity.i_06 = dto.i_06;
            entity.i_07 = dto.i_07;
            entity.i_08 = dto.i_08;
            entity.i_09 = dto.i_09;
            entity.i_10 = dto.i_10;
            entity.i_11 = dto.i_11;
            entity.i_12 = dto.i_12;
            entity.i_13 = dto.i_13;
            entity.i_14 = dto.i_14;
            entity.i_15 = dto.i_15;
            entity.i_16 = dto.i_16;
            entity.i_17 = dto.i_17;
            entity.i_18 = dto.i_18;
            entity.i_19 = dto.i_19;
            entity.i_20 = dto.i_20;
            entity.i_21 = dto.i_21;
            entity.i_22 = dto.i_22;
            entity.i_23 = dto.i_23;
            entity.i_24 = dto.i_24;
            entity.i_25 = dto.i_25;
            entity.i_26 = dto.i_26;
            entity.i_27 = dto.i_27;
            entity.i_28 = dto.i_28;
            entity.i_29 = dto.i_29;
            entity.i_30 = dto.i_30;
            entity.i_31 = dto.i_31;
            entity.v_Comentary = dto.v_Comentary;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="horarios"/> to an instance of <see cref="horariosDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="horarios"/> to convert.</param>
        public static horariosDto ToDTO(this horarios entity)
        {
            if (entity == null) return null;

            var dto = new horariosDto();

            dto.IdHorario = entity.IdHorario;
            dto.i_SystemUserId = entity.i_SystemUserId;
            dto.d_FechaInicio = entity.d_FechaInicio;
            dto.d_FechaFin = entity.d_FechaFin;
            dto.i_01 = entity.i_01;
            dto.i_02 = entity.i_02;
            dto.i_03 = entity.i_03;
            dto.i_04 = entity.i_04;
            dto.i_05 = entity.i_05;
            dto.i_06 = entity.i_06;
            dto.i_07 = entity.i_07;
            dto.i_08 = entity.i_08;
            dto.i_09 = entity.i_09;
            dto.i_10 = entity.i_10;
            dto.i_11 = entity.i_11;
            dto.i_12 = entity.i_12;
            dto.i_13 = entity.i_13;
            dto.i_14 = entity.i_14;
            dto.i_15 = entity.i_15;
            dto.i_16 = entity.i_16;
            dto.i_17 = entity.i_17;
            dto.i_18 = entity.i_18;
            dto.i_19 = entity.i_19;
            dto.i_20 = entity.i_20;
            dto.i_21 = entity.i_21;
            dto.i_22 = entity.i_22;
            dto.i_23 = entity.i_23;
            dto.i_24 = entity.i_24;
            dto.i_25 = entity.i_25;
            dto.i_26 = entity.i_26;
            dto.i_27 = entity.i_27;
            dto.i_28 = entity.i_28;
            dto.i_29 = entity.i_29;
            dto.i_30 = entity.i_30;
            dto.i_31 = entity.i_31;
            dto.v_Comentary = entity.v_Comentary;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="horariosDto"/> to an instance of <see cref="horarios"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<horarios> ToEntities(this IEnumerable<horariosDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="horarios"/> to an instance of <see cref="horariosDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<horariosDto> ToDTOs(this IEnumerable<horarios> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
