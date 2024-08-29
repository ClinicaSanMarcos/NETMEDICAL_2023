//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 08:59:56
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
    /// Assembler for <see cref="updateservicecomponent2_spResult"/> and <see cref="updateservicecomponent2_spResultDto"/>.
    /// </summary>
    public static partial class updateservicecomponent2_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="updateservicecomponent2_spResultDto"/> converted from <see cref="updateservicecomponent2_spResult"/>.</param>
        static partial void OnDTO(this updateservicecomponent2_spResult entity, updateservicecomponent2_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="updateservicecomponent2_spResult"/> converted from <see cref="updateservicecomponent2_spResultDto"/>.</param>
        static partial void OnEntity(this updateservicecomponent2_spResultDto dto, updateservicecomponent2_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="updateservicecomponent2_spResultDto"/> to an instance of <see cref="updateservicecomponent2_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="updateservicecomponent2_spResultDto"/> to convert.</param>
        public static updateservicecomponent2_spResult ToEntity(this updateservicecomponent2_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new updateservicecomponent2_spResult();

            entity.v_ServiceComponentId = dto.v_ServiceComponentId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="updateservicecomponent2_spResult"/> to an instance of <see cref="updateservicecomponent2_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="updateservicecomponent2_spResult"/> to convert.</param>
        public static updateservicecomponent2_spResultDto ToDTO(this updateservicecomponent2_spResult entity)
        {
            if (entity == null) return null;

            var dto = new updateservicecomponent2_spResultDto();

            dto.v_ServiceComponentId = entity.v_ServiceComponentId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="updateservicecomponent2_spResultDto"/> to an instance of <see cref="updateservicecomponent2_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<updateservicecomponent2_spResult> ToEntities(this IEnumerable<updateservicecomponent2_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="updateservicecomponent2_spResult"/> to an instance of <see cref="updateservicecomponent2_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<updateservicecomponent2_spResultDto> ToDTOs(this IEnumerable<updateservicecomponent2_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
