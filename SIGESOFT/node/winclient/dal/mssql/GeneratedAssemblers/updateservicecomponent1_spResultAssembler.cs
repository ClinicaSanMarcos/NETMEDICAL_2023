//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/05/24 - 18:04:19
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
    /// Assembler for <see cref="updateservicecomponent1_spResult"/> and <see cref="updateservicecomponent1_spResultDto"/>.
    /// </summary>
    public static partial class updateservicecomponent1_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="updateservicecomponent1_spResultDto"/> converted from <see cref="updateservicecomponent1_spResult"/>.</param>
        static partial void OnDTO(this updateservicecomponent1_spResult entity, updateservicecomponent1_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="updateservicecomponent1_spResult"/> converted from <see cref="updateservicecomponent1_spResultDto"/>.</param>
        static partial void OnEntity(this updateservicecomponent1_spResultDto dto, updateservicecomponent1_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="updateservicecomponent1_spResultDto"/> to an instance of <see cref="updateservicecomponent1_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="updateservicecomponent1_spResultDto"/> to convert.</param>
        public static updateservicecomponent1_spResult ToEntity(this updateservicecomponent1_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new updateservicecomponent1_spResult();

            entity.v_Value1 = dto.v_Value1;
            entity.v_ServiceId = dto.v_ServiceId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="updateservicecomponent1_spResult"/> to an instance of <see cref="updateservicecomponent1_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="updateservicecomponent1_spResult"/> to convert.</param>
        public static updateservicecomponent1_spResultDto ToDTO(this updateservicecomponent1_spResult entity)
        {
            if (entity == null) return null;

            var dto = new updateservicecomponent1_spResultDto();

            dto.v_Value1 = entity.v_Value1;
            dto.v_ServiceId = entity.v_ServiceId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="updateservicecomponent1_spResultDto"/> to an instance of <see cref="updateservicecomponent1_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<updateservicecomponent1_spResult> ToEntities(this IEnumerable<updateservicecomponent1_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="updateservicecomponent1_spResult"/> to an instance of <see cref="updateservicecomponent1_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<updateservicecomponent1_spResultDto> ToDTOs(this IEnumerable<updateservicecomponent1_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
