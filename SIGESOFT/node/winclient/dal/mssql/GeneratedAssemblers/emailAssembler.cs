//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:58:40
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
    /// Assembler for <see cref="email"/> and <see cref="emailDto"/>.
    /// </summary>
    public static partial class emailAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="emailDto"/> converted from <see cref="email"/>.</param>
        static partial void OnDTO(this email entity, emailDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="email"/> converted from <see cref="emailDto"/>.</param>
        static partial void OnEntity(this emailDto dto, email entity);

        /// <summary>
        /// Converts this instance of <see cref="emailDto"/> to an instance of <see cref="email"/>.
        /// </summary>
        /// <param name="dto"><see cref="emailDto"/> to convert.</param>
        public static email ToEntity(this emailDto dto)
        {
            if (dto == null) return null;

            var entity = new email();

            entity.i_EmailId = dto.i_EmailId;
            entity.v_Email = dto.v_Email;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="email"/> to an instance of <see cref="emailDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="email"/> to convert.</param>
        public static emailDto ToDTO(this email entity)
        {
            if (entity == null) return null;

            var dto = new emailDto();

            dto.i_EmailId = entity.i_EmailId;
            dto.v_Email = entity.v_Email;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="emailDto"/> to an instance of <see cref="email"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<email> ToEntities(this IEnumerable<emailDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="email"/> to an instance of <see cref="emailDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<emailDto> ToDTOs(this IEnumerable<email> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
