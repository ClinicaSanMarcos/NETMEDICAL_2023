//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 08:59:50
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
    /// Assembler for <see cref="getexamenesadicionales_spResult"/> and <see cref="getexamenesadicionales_spResultDto"/>.
    /// </summary>
    public static partial class getexamenesadicionales_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getexamenesadicionales_spResultDto"/> converted from <see cref="getexamenesadicionales_spResult"/>.</param>
        static partial void OnDTO(this getexamenesadicionales_spResult entity, getexamenesadicionales_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getexamenesadicionales_spResult"/> converted from <see cref="getexamenesadicionales_spResultDto"/>.</param>
        static partial void OnEntity(this getexamenesadicionales_spResultDto dto, getexamenesadicionales_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getexamenesadicionales_spResultDto"/> to an instance of <see cref="getexamenesadicionales_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getexamenesadicionales_spResultDto"/> to convert.</param>
        public static getexamenesadicionales_spResult ToEntity(this getexamenesadicionales_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getexamenesadicionales_spResult();

            entity.v_AdditionalExamId = dto.v_AdditionalExamId;
            entity.v_ComponentId = dto.v_ComponentId;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.v_ComponentName = dto.v_ComponentName;
            entity.Precio = dto.Precio;
            entity.v_PacientName = dto.v_PacientName;
            entity.v_IdGrupoAdicional = dto.v_IdGrupoAdicional;
            entity.ServicioEnlace = dto.ServicioEnlace;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getexamenesadicionales_spResult"/> to an instance of <see cref="getexamenesadicionales_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getexamenesadicionales_spResult"/> to convert.</param>
        public static getexamenesadicionales_spResultDto ToDTO(this getexamenesadicionales_spResult entity)
        {
            if (entity == null) return null;

            var dto = new getexamenesadicionales_spResultDto();

            dto.v_AdditionalExamId = entity.v_AdditionalExamId;
            dto.v_ComponentId = entity.v_ComponentId;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.v_ComponentName = entity.v_ComponentName;
            dto.Precio = entity.Precio;
            dto.v_PacientName = entity.v_PacientName;
            dto.v_IdGrupoAdicional = entity.v_IdGrupoAdicional;
            dto.ServicioEnlace = entity.ServicioEnlace;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getexamenesadicionales_spResultDto"/> to an instance of <see cref="getexamenesadicionales_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getexamenesadicionales_spResult> ToEntities(this IEnumerable<getexamenesadicionales_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getexamenesadicionales_spResult"/> to an instance of <see cref="getexamenesadicionales_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getexamenesadicionales_spResultDto> ToDTOs(this IEnumerable<getexamenesadicionales_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
