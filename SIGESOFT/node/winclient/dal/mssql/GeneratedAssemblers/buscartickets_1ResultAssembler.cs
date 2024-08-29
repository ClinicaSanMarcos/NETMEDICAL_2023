//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 08:59:49
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
    /// Assembler for <see cref="buscartickets_1Result"/> and <see cref="buscartickets_1ResultDto"/>.
    /// </summary>
    public static partial class buscartickets_1ResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="buscartickets_1ResultDto"/> converted from <see cref="buscartickets_1Result"/>.</param>
        static partial void OnDTO(this buscartickets_1Result entity, buscartickets_1ResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="buscartickets_1Result"/> converted from <see cref="buscartickets_1ResultDto"/>.</param>
        static partial void OnEntity(this buscartickets_1ResultDto dto, buscartickets_1Result entity);

        /// <summary>
        /// Converts this instance of <see cref="buscartickets_1ResultDto"/> to an instance of <see cref="buscartickets_1Result"/>.
        /// </summary>
        /// <param name="dto"><see cref="buscartickets_1ResultDto"/> to convert.</param>
        public static buscartickets_1Result ToEntity(this buscartickets_1ResultDto dto)
        {
            if (dto == null) return null;

            var entity = new buscartickets_1Result();

            entity.v_ServiceId = dto.v_ServiceId;
            entity.v_TicketId = dto.v_TicketId;
            entity.d_Fecha = dto.d_Fecha;
            entity.i_conCargoA = dto.i_conCargoA;
            entity.i_tipoCuenta = dto.i_tipoCuenta;
            entity.i_TicketInterno = dto.i_TicketInterno;
            entity.d_FechaAlta = dto.d_FechaAlta;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="buscartickets_1Result"/> to an instance of <see cref="buscartickets_1ResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="buscartickets_1Result"/> to convert.</param>
        public static buscartickets_1ResultDto ToDTO(this buscartickets_1Result entity)
        {
            if (entity == null) return null;

            var dto = new buscartickets_1ResultDto();

            dto.v_ServiceId = entity.v_ServiceId;
            dto.v_TicketId = entity.v_TicketId;
            dto.d_Fecha = entity.d_Fecha;
            dto.i_conCargoA = entity.i_conCargoA;
            dto.i_tipoCuenta = entity.i_tipoCuenta;
            dto.i_TicketInterno = entity.i_TicketInterno;
            dto.d_FechaAlta = entity.d_FechaAlta;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="buscartickets_1ResultDto"/> to an instance of <see cref="buscartickets_1Result"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<buscartickets_1Result> ToEntities(this IEnumerable<buscartickets_1ResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="buscartickets_1Result"/> to an instance of <see cref="buscartickets_1ResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<buscartickets_1ResultDto> ToDTOs(this IEnumerable<buscartickets_1Result> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
