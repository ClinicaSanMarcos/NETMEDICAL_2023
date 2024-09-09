//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:52:27
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
    /// Assembler for <see cref="buscarticketsdetalle_1Result"/> and <see cref="buscarticketsdetalle_1ResultDto"/>.
    /// </summary>
    public static partial class buscarticketsdetalle_1ResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="buscarticketsdetalle_1ResultDto"/> converted from <see cref="buscarticketsdetalle_1Result"/>.</param>
        static partial void OnDTO(this buscarticketsdetalle_1Result entity, buscarticketsdetalle_1ResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="buscarticketsdetalle_1Result"/> converted from <see cref="buscarticketsdetalle_1ResultDto"/>.</param>
        static partial void OnEntity(this buscarticketsdetalle_1ResultDto dto, buscarticketsdetalle_1Result entity);

        /// <summary>
        /// Converts this instance of <see cref="buscarticketsdetalle_1ResultDto"/> to an instance of <see cref="buscarticketsdetalle_1Result"/>.
        /// </summary>
        /// <param name="dto"><see cref="buscarticketsdetalle_1ResultDto"/> to convert.</param>
        public static buscarticketsdetalle_1Result ToEntity(this buscarticketsdetalle_1ResultDto dto)
        {
            if (dto == null) return null;

            var entity = new buscarticketsdetalle_1Result();

            entity.v_TicketDetalleId = dto.v_TicketDetalleId;
            entity.v_TicketId = dto.v_TicketId;
            entity.d_Cantidad = dto.d_Cantidad;
            entity.v_Descripcion = dto.v_Descripcion;
            entity.v_IdProductoDetalle = dto.v_IdProductoDetalle;
            entity.i_EsDespachado = dto.i_EsDespachado;
            entity.d_PrecioVenta = dto.d_PrecioVenta;
            entity.UsuarioCrea = dto.UsuarioCrea;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="buscarticketsdetalle_1Result"/> to an instance of <see cref="buscarticketsdetalle_1ResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="buscarticketsdetalle_1Result"/> to convert.</param>
        public static buscarticketsdetalle_1ResultDto ToDTO(this buscarticketsdetalle_1Result entity)
        {
            if (entity == null) return null;

            var dto = new buscarticketsdetalle_1ResultDto();

            dto.v_TicketDetalleId = entity.v_TicketDetalleId;
            dto.v_TicketId = entity.v_TicketId;
            dto.d_Cantidad = entity.d_Cantidad;
            dto.v_Descripcion = entity.v_Descripcion;
            dto.v_IdProductoDetalle = entity.v_IdProductoDetalle;
            dto.i_EsDespachado = entity.i_EsDespachado;
            dto.d_PrecioVenta = entity.d_PrecioVenta;
            dto.UsuarioCrea = entity.UsuarioCrea;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarticketsdetalle_1ResultDto"/> to an instance of <see cref="buscarticketsdetalle_1Result"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<buscarticketsdetalle_1Result> ToEntities(this IEnumerable<buscarticketsdetalle_1ResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarticketsdetalle_1Result"/> to an instance of <see cref="buscarticketsdetalle_1ResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<buscarticketsdetalle_1ResultDto> ToDTOs(this IEnumerable<buscarticketsdetalle_1Result> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
