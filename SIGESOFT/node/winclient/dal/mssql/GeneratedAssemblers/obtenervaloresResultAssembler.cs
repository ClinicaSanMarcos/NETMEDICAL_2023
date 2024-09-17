//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:54:06
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
    /// Assembler for <see cref="obtenervaloresResult"/> and <see cref="obtenervaloresResultDto"/>.
    /// </summary>
    public static partial class obtenervaloresResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="obtenervaloresResultDto"/> converted from <see cref="obtenervaloresResult"/>.</param>
        static partial void OnDTO(this obtenervaloresResult entity, obtenervaloresResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="obtenervaloresResult"/> converted from <see cref="obtenervaloresResultDto"/>.</param>
        static partial void OnEntity(this obtenervaloresResultDto dto, obtenervaloresResult entity);

        /// <summary>
        /// Converts this instance of <see cref="obtenervaloresResultDto"/> to an instance of <see cref="obtenervaloresResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="obtenervaloresResultDto"/> to convert.</param>
        public static obtenervaloresResult ToEntity(this obtenervaloresResultDto dto)
        {
            if (dto == null) return null;

            var entity = new obtenervaloresResult();

            entity.v_ServiceComponentFieldsId = dto.v_ServiceComponentFieldsId;
            entity.v_Value1 = dto.v_Value1;
            entity.v_MeasurementUnitName = dto.v_MeasurementUnitName;
            entity.v_Value1Name = dto.v_Value1Name;
            entity.v_ComponentFielName = dto.v_ComponentFielName;
            entity.i_GroupId = dto.i_GroupId;
            entity.v_ComponentId = dto.v_ComponentId;
            entity.v_ServiceComponentId = dto.v_ServiceComponentId;
            entity.v_ComponentFieldsId = dto.v_ComponentFieldsId;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="obtenervaloresResult"/> to an instance of <see cref="obtenervaloresResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="obtenervaloresResult"/> to convert.</param>
        public static obtenervaloresResultDto ToDTO(this obtenervaloresResult entity)
        {
            if (entity == null) return null;

            var dto = new obtenervaloresResultDto();

            dto.v_ServiceComponentFieldsId = entity.v_ServiceComponentFieldsId;
            dto.v_Value1 = entity.v_Value1;
            dto.v_MeasurementUnitName = entity.v_MeasurementUnitName;
            dto.v_Value1Name = entity.v_Value1Name;
            dto.v_ComponentFielName = entity.v_ComponentFielName;
            dto.i_GroupId = entity.i_GroupId;
            dto.v_ComponentId = entity.v_ComponentId;
            dto.v_ServiceComponentId = entity.v_ServiceComponentId;
            dto.v_ComponentFieldsId = entity.v_ComponentFieldsId;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="obtenervaloresResultDto"/> to an instance of <see cref="obtenervaloresResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<obtenervaloresResult> ToEntities(this IEnumerable<obtenervaloresResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="obtenervaloresResult"/> to an instance of <see cref="obtenervaloresResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<obtenervaloresResultDto> ToDTOs(this IEnumerable<obtenervaloresResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
