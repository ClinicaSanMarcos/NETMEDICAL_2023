//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:46:06
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
    /// Assembler for <see cref="getservicecomponentsreport_dxlist_spResult"/> and <see cref="getservicecomponentsreport_dxlist_spResultDto"/>.
    /// </summary>
    public static partial class getservicecomponentsreport_dxlist_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreport_dxlist_spResultDto"/> converted from <see cref="getservicecomponentsreport_dxlist_spResult"/>.</param>
        static partial void OnDTO(this getservicecomponentsreport_dxlist_spResult entity, getservicecomponentsreport_dxlist_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreport_dxlist_spResult"/> converted from <see cref="getservicecomponentsreport_dxlist_spResultDto"/>.</param>
        static partial void OnEntity(this getservicecomponentsreport_dxlist_spResultDto dto, getservicecomponentsreport_dxlist_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreport_dxlist_spResultDto"/> to an instance of <see cref="getservicecomponentsreport_dxlist_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreport_dxlist_spResultDto"/> to convert.</param>
        public static getservicecomponentsreport_dxlist_spResult ToEntity(this getservicecomponentsreport_dxlist_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getservicecomponentsreport_dxlist_spResult();

            entity.v_DiseasesId = dto.v_DiseasesId;
            entity.v_DiseasesName = dto.v_DiseasesName;
            entity.d_ExpirationDateDiagnostic = dto.d_ExpirationDateDiagnostic;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreport_dxlist_spResult"/> to an instance of <see cref="getservicecomponentsreport_dxlist_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreport_dxlist_spResult"/> to convert.</param>
        public static getservicecomponentsreport_dxlist_spResultDto ToDTO(this getservicecomponentsreport_dxlist_spResult entity)
        {
            if (entity == null) return null;

            var dto = new getservicecomponentsreport_dxlist_spResultDto();

            dto.v_DiseasesId = entity.v_DiseasesId;
            dto.v_DiseasesName = entity.v_DiseasesName;
            dto.d_ExpirationDateDiagnostic = entity.d_ExpirationDateDiagnostic;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreport_dxlist_spResultDto"/> to an instance of <see cref="getservicecomponentsreport_dxlist_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreport_dxlist_spResult> ToEntities(this IEnumerable<getservicecomponentsreport_dxlist_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreport_dxlist_spResult"/> to an instance of <see cref="getservicecomponentsreport_dxlist_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreport_dxlist_spResultDto> ToDTOs(this IEnumerable<getservicecomponentsreport_dxlist_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
