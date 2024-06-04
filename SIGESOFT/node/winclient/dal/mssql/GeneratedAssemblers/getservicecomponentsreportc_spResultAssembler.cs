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
    /// Assembler for <see cref="getservicecomponentsreportc_spResult"/> and <see cref="getservicecomponentsreportc_spResultDto"/>.
    /// </summary>
    public static partial class getservicecomponentsreportc_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreportc_spResultDto"/> converted from <see cref="getservicecomponentsreportc_spResult"/>.</param>
        static partial void OnDTO(this getservicecomponentsreportc_spResult entity, getservicecomponentsreportc_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreportc_spResult"/> converted from <see cref="getservicecomponentsreportc_spResultDto"/>.</param>
        static partial void OnEntity(this getservicecomponentsreportc_spResultDto dto, getservicecomponentsreportc_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreportc_spResultDto"/> to an instance of <see cref="getservicecomponentsreportc_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreportc_spResultDto"/> to convert.</param>
        public static getservicecomponentsreportc_spResult ToEntity(this getservicecomponentsreportc_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getservicecomponentsreportc_spResult();

            entity.v_ComponentId = dto.v_ComponentId;
            entity.v_ComponentName = dto.v_ComponentName;
            entity.v_ServiceComponentId = dto.v_ServiceComponentId;
            entity.v_CreationUser = dto.v_CreationUser;
            entity.v_UpdateUser = dto.v_UpdateUser;
            entity.d_CreationDate = dto.d_CreationDate;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_CategoryId = dto.i_CategoryId;
            entity.v_CategoryName = dto.v_CategoryName;
            entity.i_ServiceComponentStatusId = dto.i_ServiceComponentStatusId;
            entity.FirmaMedico = dto.FirmaMedico;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreportc_spResult"/> to an instance of <see cref="getservicecomponentsreportc_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreportc_spResult"/> to convert.</param>
        public static getservicecomponentsreportc_spResultDto ToDTO(this getservicecomponentsreportc_spResult entity)
        {
            if (entity == null) return null;

            var dto = new getservicecomponentsreportc_spResultDto();

            dto.v_ComponentId = entity.v_ComponentId;
            dto.v_ComponentName = entity.v_ComponentName;
            dto.v_ServiceComponentId = entity.v_ServiceComponentId;
            dto.v_CreationUser = entity.v_CreationUser;
            dto.v_UpdateUser = entity.v_UpdateUser;
            dto.d_CreationDate = entity.d_CreationDate;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_CategoryId = entity.i_CategoryId;
            dto.v_CategoryName = entity.v_CategoryName;
            dto.i_ServiceComponentStatusId = entity.i_ServiceComponentStatusId;
            dto.FirmaMedico = entity.FirmaMedico;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreportc_spResultDto"/> to an instance of <see cref="getservicecomponentsreportc_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreportc_spResult> ToEntities(this IEnumerable<getservicecomponentsreportc_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreportc_spResult"/> to an instance of <see cref="getservicecomponentsreportc_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreportc_spResultDto> ToDTOs(this IEnumerable<getservicecomponentsreportc_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
