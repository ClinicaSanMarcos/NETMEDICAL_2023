//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:54:14
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
    /// Assembler for <see cref="configuracionpago"/> and <see cref="configuracionpagoDto"/>.
    /// </summary>
    public static partial class configuracionpagoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="configuracionpagoDto"/> converted from <see cref="configuracionpago"/>.</param>
        static partial void OnDTO(this configuracionpago entity, configuracionpagoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="configuracionpago"/> converted from <see cref="configuracionpagoDto"/>.</param>
        static partial void OnEntity(this configuracionpagoDto dto, configuracionpago entity);

        /// <summary>
        /// Converts this instance of <see cref="configuracionpagoDto"/> to an instance of <see cref="configuracionpago"/>.
        /// </summary>
        /// <param name="dto"><see cref="configuracionpagoDto"/> to convert.</param>
        public static configuracionpago ToEntity(this configuracionpagoDto dto)
        {
            if (dto == null) return null;

            var entity = new configuracionpago();

            entity.v_IdConfPago = dto.v_IdConfPago;
            entity.i_SystemUserId = dto.i_SystemUserId;
            entity.i_TipoPago = dto.i_TipoPago;
            entity.d_MontoxTurno = dto.d_MontoxTurno;
            entity.d_MonoxHora = dto.d_MonoxHora;
            entity.i_OrdenExam = dto.i_OrdenExam;
            entity.d_PorcClinicaExam = dto.d_PorcClinicaExam;
            entity.d_PorcMedicoExam = dto.d_PorcMedicoExam;
            entity.i_DescontarBoletaExam = dto.i_DescontarBoletaExam;
            entity.i_DescontarRecbExam = dto.i_DescontarRecbExam;
            entity.v_Observaciones = dto.v_Observaciones;
            entity.v_ObservacionesCambios = dto.v_ObservacionesCambios;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.i_DescontarFactExam = dto.i_DescontarFactExam;
            entity.i_DesucuentodeHorario = dto.i_DesucuentodeHorario;
            entity.i_TipoDescuentoHoraMin = dto.i_TipoDescuentoHoraMin;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="configuracionpago"/> to an instance of <see cref="configuracionpagoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="configuracionpago"/> to convert.</param>
        public static configuracionpagoDto ToDTO(this configuracionpago entity)
        {
            if (entity == null) return null;

            var dto = new configuracionpagoDto();

            dto.v_IdConfPago = entity.v_IdConfPago;
            dto.i_SystemUserId = entity.i_SystemUserId;
            dto.i_TipoPago = entity.i_TipoPago;
            dto.d_MontoxTurno = entity.d_MontoxTurno;
            dto.d_MonoxHora = entity.d_MonoxHora;
            dto.i_OrdenExam = entity.i_OrdenExam;
            dto.d_PorcClinicaExam = entity.d_PorcClinicaExam;
            dto.d_PorcMedicoExam = entity.d_PorcMedicoExam;
            dto.i_DescontarBoletaExam = entity.i_DescontarBoletaExam;
            dto.i_DescontarRecbExam = entity.i_DescontarRecbExam;
            dto.v_Observaciones = entity.v_Observaciones;
            dto.v_ObservacionesCambios = entity.v_ObservacionesCambios;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.i_DescontarFactExam = entity.i_DescontarFactExam;
            dto.i_DesucuentodeHorario = entity.i_DesucuentodeHorario;
            dto.i_TipoDescuentoHoraMin = entity.i_TipoDescuentoHoraMin;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="configuracionpagoDto"/> to an instance of <see cref="configuracionpago"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<configuracionpago> ToEntities(this IEnumerable<configuracionpagoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="configuracionpago"/> to an instance of <see cref="configuracionpagoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<configuracionpagoDto> ToDTOs(this IEnumerable<configuracionpago> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
