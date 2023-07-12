//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2019/07/04 - 12:32:12
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Sigesoft.Server.WebClientAdmin.DAL;

namespace Sigesoft.Server.WebClientAdmin.BE
{

    /// <summary>
    /// Assembler for <see cref="secuential"/> and <see cref="secuentialDto"/>.
    /// </summary>
    public static partial class secuentialAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="secuentialDto"/> converted from <see cref="secuential"/>.</param>
        static partial void OnDTO(this secuential entity, secuentialDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="secuential"/> converted from <see cref="secuentialDto"/>.</param>
        static partial void OnEntity(this secuentialDto dto, secuential entity);

        /// <summary>
        /// Converts this instance of <see cref="secuentialDto"/> to an instance of <see cref="secuential"/>.
        /// </summary>
        /// <param name="dto"><see cref="secuentialDto"/> to convert.</param>
        public static secuential ToEntity(this secuentialDto dto)
        {
            if (dto == null) return null;

            var entity = new secuential();

            entity.i_NodeId = dto.i_NodeId;
            entity.i_TableId = dto.i_TableId;
            entity.i_SecuentialId = dto.i_SecuentialId;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="secuential"/> to an instance of <see cref="secuentialDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="secuential"/> to convert.</param>
        public static secuentialDto ToDTO(this secuential entity)
        {
            if (entity == null) return null;

            var dto = new secuentialDto();

            dto.i_NodeId = entity.i_NodeId;
            dto.i_TableId = entity.i_TableId;
            dto.i_SecuentialId = entity.i_SecuentialId;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="secuentialDto"/> to an instance of <see cref="secuential"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<secuential> ToEntities(this IEnumerable<secuentialDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="secuential"/> to an instance of <see cref="secuentialDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<secuentialDto> ToDTOs(this IEnumerable<secuential> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
