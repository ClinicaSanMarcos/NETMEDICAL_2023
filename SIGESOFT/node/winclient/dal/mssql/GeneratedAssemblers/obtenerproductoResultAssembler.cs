//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/09 - 00:20:24
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
    /// Assembler for <see cref="obtenerproductoResult"/> and <see cref="obtenerproductoResultDto"/>.
    /// </summary>
    public static partial class obtenerproductoResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="obtenerproductoResultDto"/> converted from <see cref="obtenerproductoResult"/>.</param>
        static partial void OnDTO(this obtenerproductoResult entity, obtenerproductoResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="obtenerproductoResult"/> converted from <see cref="obtenerproductoResultDto"/>.</param>
        static partial void OnEntity(this obtenerproductoResultDto dto, obtenerproductoResult entity);

        /// <summary>
        /// Converts this instance of <see cref="obtenerproductoResultDto"/> to an instance of <see cref="obtenerproductoResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="obtenerproductoResultDto"/> to convert.</param>
        public static obtenerproductoResult ToEntity(this obtenerproductoResultDto dto)
        {
            if (dto == null) return null;

            var entity = new obtenerproductoResult();

            entity.v_IdProductoDetalle = dto.v_IdProductoDetalle;
            entity.v_Descripcion = dto.v_Descripcion;
            entity.d_PrecioVenta = dto.d_PrecioVenta;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="obtenerproductoResult"/> to an instance of <see cref="obtenerproductoResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="obtenerproductoResult"/> to convert.</param>
        public static obtenerproductoResultDto ToDTO(this obtenerproductoResult entity)
        {
            if (entity == null) return null;

            var dto = new obtenerproductoResultDto();

            dto.v_IdProductoDetalle = entity.v_IdProductoDetalle;
            dto.v_Descripcion = entity.v_Descripcion;
            dto.d_PrecioVenta = entity.d_PrecioVenta;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="obtenerproductoResultDto"/> to an instance of <see cref="obtenerproductoResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<obtenerproductoResult> ToEntities(this IEnumerable<obtenerproductoResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="obtenerproductoResult"/> to an instance of <see cref="obtenerproductoResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<obtenerproductoResultDto> ToDTOs(this IEnumerable<obtenerproductoResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
