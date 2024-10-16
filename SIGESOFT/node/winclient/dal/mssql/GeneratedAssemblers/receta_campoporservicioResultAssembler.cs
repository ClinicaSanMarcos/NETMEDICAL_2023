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
    /// Assembler for <see cref="receta_campoporservicioResult"/> and <see cref="receta_campoporservicioResultDto"/>.
    /// </summary>
    public static partial class receta_campoporservicioResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="receta_campoporservicioResultDto"/> converted from <see cref="receta_campoporservicioResult"/>.</param>
        static partial void OnDTO(this receta_campoporservicioResult entity, receta_campoporservicioResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="receta_campoporservicioResult"/> converted from <see cref="receta_campoporservicioResultDto"/>.</param>
        static partial void OnEntity(this receta_campoporservicioResultDto dto, receta_campoporservicioResult entity);

        /// <summary>
        /// Converts this instance of <see cref="receta_campoporservicioResultDto"/> to an instance of <see cref="receta_campoporservicioResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="receta_campoporservicioResultDto"/> to convert.</param>
        public static receta_campoporservicioResult ToEntity(this receta_campoporservicioResultDto dto)
        {
            if (dto == null) return null;

            var entity = new receta_campoporservicioResult();

            entity.ServicioId = dto.ServicioId;
            entity.Valor = dto.Valor;
            entity.NombreComponente = dto.NombreComponente;
            entity.IdComponente = dto.IdComponente;
            entity.NombreCampo = dto.NombreCampo;
            entity.IdCampo = dto.IdCampo;
            entity.i_GroupId = dto.i_GroupId;
            entity.ValorName = dto.ValorName;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="receta_campoporservicioResult"/> to an instance of <see cref="receta_campoporservicioResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="receta_campoporservicioResult"/> to convert.</param>
        public static receta_campoporservicioResultDto ToDTO(this receta_campoporservicioResult entity)
        {
            if (entity == null) return null;

            var dto = new receta_campoporservicioResultDto();

            dto.ServicioId = entity.ServicioId;
            dto.Valor = entity.Valor;
            dto.NombreComponente = entity.NombreComponente;
            dto.IdComponente = entity.IdComponente;
            dto.NombreCampo = entity.NombreCampo;
            dto.IdCampo = entity.IdCampo;
            dto.i_GroupId = entity.i_GroupId;
            dto.ValorName = entity.ValorName;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="receta_campoporservicioResultDto"/> to an instance of <see cref="receta_campoporservicioResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<receta_campoporservicioResult> ToEntities(this IEnumerable<receta_campoporservicioResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="receta_campoporservicioResult"/> to an instance of <see cref="receta_campoporservicioResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<receta_campoporservicioResultDto> ToDTOs(this IEnumerable<receta_campoporservicioResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
