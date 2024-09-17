//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:54:02
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
    /// Assembler for <see cref="buscarservicioshospitalizacion_1Result"/> and <see cref="buscarservicioshospitalizacion_1ResultDto"/>.
    /// </summary>
    public static partial class buscarservicioshospitalizacion_1ResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="buscarservicioshospitalizacion_1ResultDto"/> converted from <see cref="buscarservicioshospitalizacion_1Result"/>.</param>
        static partial void OnDTO(this buscarservicioshospitalizacion_1Result entity, buscarservicioshospitalizacion_1ResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="buscarservicioshospitalizacion_1Result"/> converted from <see cref="buscarservicioshospitalizacion_1ResultDto"/>.</param>
        static partial void OnEntity(this buscarservicioshospitalizacion_1ResultDto dto, buscarservicioshospitalizacion_1Result entity);

        /// <summary>
        /// Converts this instance of <see cref="buscarservicioshospitalizacion_1ResultDto"/> to an instance of <see cref="buscarservicioshospitalizacion_1Result"/>.
        /// </summary>
        /// <param name="dto"><see cref="buscarservicioshospitalizacion_1ResultDto"/> to convert.</param>
        public static buscarservicioshospitalizacion_1Result ToEntity(this buscarservicioshospitalizacion_1ResultDto dto)
        {
            if (dto == null) return null;

            var entity = new buscarservicioshospitalizacion_1Result();

            entity.v_HospitalizacionServiceId = dto.v_HospitalizacionServiceId;
            entity.v_HopitalizacionId = dto.v_HopitalizacionId;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.d_ServiceDate = dto.d_ServiceDate;
            entity.v_ProtocolName = dto.v_ProtocolName;
            entity.v_ProtocolId = dto.v_ProtocolId;
            entity.v_DocNumber = dto.v_DocNumber;
            entity.d_FechaAlta = dto.d_FechaAlta;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="buscarservicioshospitalizacion_1Result"/> to an instance of <see cref="buscarservicioshospitalizacion_1ResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="buscarservicioshospitalizacion_1Result"/> to convert.</param>
        public static buscarservicioshospitalizacion_1ResultDto ToDTO(this buscarservicioshospitalizacion_1Result entity)
        {
            if (entity == null) return null;

            var dto = new buscarservicioshospitalizacion_1ResultDto();

            dto.v_HospitalizacionServiceId = entity.v_HospitalizacionServiceId;
            dto.v_HopitalizacionId = entity.v_HopitalizacionId;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.d_ServiceDate = entity.d_ServiceDate;
            dto.v_ProtocolName = entity.v_ProtocolName;
            dto.v_ProtocolId = entity.v_ProtocolId;
            dto.v_DocNumber = entity.v_DocNumber;
            dto.d_FechaAlta = entity.d_FechaAlta;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarservicioshospitalizacion_1ResultDto"/> to an instance of <see cref="buscarservicioshospitalizacion_1Result"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<buscarservicioshospitalizacion_1Result> ToEntities(this IEnumerable<buscarservicioshospitalizacion_1ResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarservicioshospitalizacion_1Result"/> to an instance of <see cref="buscarservicioshospitalizacion_1ResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<buscarservicioshospitalizacion_1ResultDto> ToDTOs(this IEnumerable<buscarservicioshospitalizacion_1Result> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
