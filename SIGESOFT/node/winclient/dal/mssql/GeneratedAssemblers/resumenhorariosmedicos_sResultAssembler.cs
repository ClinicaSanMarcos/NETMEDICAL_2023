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
    /// Assembler for <see cref="resumenhorariosmedicos_sResult"/> and <see cref="resumenhorariosmedicos_sResultDto"/>.
    /// </summary>
    public static partial class resumenhorariosmedicos_sResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="resumenhorariosmedicos_sResultDto"/> converted from <see cref="resumenhorariosmedicos_sResult"/>.</param>
        static partial void OnDTO(this resumenhorariosmedicos_sResult entity, resumenhorariosmedicos_sResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="resumenhorariosmedicos_sResult"/> converted from <see cref="resumenhorariosmedicos_sResultDto"/>.</param>
        static partial void OnEntity(this resumenhorariosmedicos_sResultDto dto, resumenhorariosmedicos_sResult entity);

        /// <summary>
        /// Converts this instance of <see cref="resumenhorariosmedicos_sResultDto"/> to an instance of <see cref="resumenhorariosmedicos_sResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="resumenhorariosmedicos_sResultDto"/> to convert.</param>
        public static resumenhorariosmedicos_sResult ToEntity(this resumenhorariosmedicos_sResultDto dto)
        {
            if (dto == null) return null;

            var entity = new resumenhorariosmedicos_sResult();

            entity.TIPO = dto.TIPO;
            entity.IdHorario = dto.IdHorario;
            entity.MEDICO = dto.MEDICO;
            entity.ESPECIALIDAD = dto.ESPECIALIDAD;
            entity.INTERVALO = dto.INTERVALO;
            entity.CONSULTORIO = dto.CONSULTORIO;
            entity.CODIGO = dto.CODIGO;
            entity.DIA = dto.DIA;
            entity.HoraInicio = dto.HoraInicio;
            entity.HoraFin = dto.HoraFin;
            entity.TURNO = dto.TURNO;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="resumenhorariosmedicos_sResult"/> to an instance of <see cref="resumenhorariosmedicos_sResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="resumenhorariosmedicos_sResult"/> to convert.</param>
        public static resumenhorariosmedicos_sResultDto ToDTO(this resumenhorariosmedicos_sResult entity)
        {
            if (entity == null) return null;

            var dto = new resumenhorariosmedicos_sResultDto();

            dto.TIPO = entity.TIPO;
            dto.IdHorario = entity.IdHorario;
            dto.MEDICO = entity.MEDICO;
            dto.ESPECIALIDAD = entity.ESPECIALIDAD;
            dto.INTERVALO = entity.INTERVALO;
            dto.CONSULTORIO = entity.CONSULTORIO;
            dto.CODIGO = entity.CODIGO;
            dto.DIA = entity.DIA;
            dto.HoraInicio = entity.HoraInicio;
            dto.HoraFin = entity.HoraFin;
            dto.TURNO = entity.TURNO;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="resumenhorariosmedicos_sResultDto"/> to an instance of <see cref="resumenhorariosmedicos_sResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<resumenhorariosmedicos_sResult> ToEntities(this IEnumerable<resumenhorariosmedicos_sResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="resumenhorariosmedicos_sResult"/> to an instance of <see cref="resumenhorariosmedicos_sResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<resumenhorariosmedicos_sResultDto> ToDTOs(this IEnumerable<resumenhorariosmedicos_sResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
