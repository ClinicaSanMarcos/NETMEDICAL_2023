//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/05/24 - 18:04:16
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
    /// Assembler for <see cref="listllamadadeesperaResult"/> and <see cref="listllamadadeesperaResultDto"/>.
    /// </summary>
    public static partial class listllamadadeesperaResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="listllamadadeesperaResultDto"/> converted from <see cref="listllamadadeesperaResult"/>.</param>
        static partial void OnDTO(this listllamadadeesperaResult entity, listllamadadeesperaResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="listllamadadeesperaResult"/> converted from <see cref="listllamadadeesperaResultDto"/>.</param>
        static partial void OnEntity(this listllamadadeesperaResultDto dto, listllamadadeesperaResult entity);

        /// <summary>
        /// Converts this instance of <see cref="listllamadadeesperaResultDto"/> to an instance of <see cref="listllamadadeesperaResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="listllamadadeesperaResultDto"/> to convert.</param>
        public static listllamadadeesperaResult ToEntity(this listllamadadeesperaResultDto dto)
        {
            if (dto == null) return null;

            var entity = new listllamadadeesperaResult();

            entity.PACIENTE = dto.PACIENTE;
            entity.HORARIO = dto.HORARIO;
            entity.Medico = dto.Medico;
            entity.TURNO = dto.TURNO;
            entity.APTITUD = dto.APTITUD;
            entity.d_ServiceDate = dto.d_ServiceDate;
            entity.v_Value1 = dto.v_Value1;
            entity.v_UserName = dto.v_UserName;
            entity.v_ServiceId = dto.v_ServiceId;
            entity.i_SystemUserId = dto.i_SystemUserId;
            entity.i_ParameterId = dto.i_ParameterId;
            entity.i_ParameterId1 = dto.i_ParameterId1;
            entity.i_GroupId = dto.i_GroupId;
            entity.ESPECIALIDAD = dto.ESPECIALIDAD;
            entity.v_CalendarId = dto.v_CalendarId;
            entity.Protocolo = dto.Protocolo;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="listllamadadeesperaResult"/> to an instance of <see cref="listllamadadeesperaResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="listllamadadeesperaResult"/> to convert.</param>
        public static listllamadadeesperaResultDto ToDTO(this listllamadadeesperaResult entity)
        {
            if (entity == null) return null;

            var dto = new listllamadadeesperaResultDto();

            dto.PACIENTE = entity.PACIENTE;
            dto.HORARIO = entity.HORARIO;
            dto.Medico = entity.Medico;
            dto.TURNO = entity.TURNO;
            dto.APTITUD = entity.APTITUD;
            dto.d_ServiceDate = entity.d_ServiceDate;
            dto.v_Value1 = entity.v_Value1;
            dto.v_UserName = entity.v_UserName;
            dto.v_ServiceId = entity.v_ServiceId;
            dto.i_SystemUserId = entity.i_SystemUserId;
            dto.i_ParameterId = entity.i_ParameterId;
            dto.i_ParameterId1 = entity.i_ParameterId1;
            dto.i_GroupId = entity.i_GroupId;
            dto.ESPECIALIDAD = entity.ESPECIALIDAD;
            dto.v_CalendarId = entity.v_CalendarId;
            dto.Protocolo = entity.Protocolo;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="listllamadadeesperaResultDto"/> to an instance of <see cref="listllamadadeesperaResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<listllamadadeesperaResult> ToEntities(this IEnumerable<listllamadadeesperaResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="listllamadadeesperaResult"/> to an instance of <see cref="listllamadadeesperaResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<listllamadadeesperaResultDto> ToDTOs(this IEnumerable<listllamadadeesperaResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
