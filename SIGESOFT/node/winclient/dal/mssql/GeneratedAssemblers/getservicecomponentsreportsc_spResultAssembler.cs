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
    /// Assembler for <see cref="getservicecomponentsreportsc_spResult"/> and <see cref="getservicecomponentsreportsc_spResultDto"/>.
    /// </summary>
    public static partial class getservicecomponentsreportsc_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreportsc_spResultDto"/> converted from <see cref="getservicecomponentsreportsc_spResult"/>.</param>
        static partial void OnDTO(this getservicecomponentsreportsc_spResult entity, getservicecomponentsreportsc_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreportsc_spResult"/> converted from <see cref="getservicecomponentsreportsc_spResultDto"/>.</param>
        static partial void OnEntity(this getservicecomponentsreportsc_spResultDto dto, getservicecomponentsreportsc_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreportsc_spResultDto"/> to an instance of <see cref="getservicecomponentsreportsc_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getservicecomponentsreportsc_spResultDto"/> to convert.</param>
        public static getservicecomponentsreportsc_spResult ToEntity(this getservicecomponentsreportsc_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getservicecomponentsreportsc_spResult();

            entity.v_ServiceComponentFieldsId = dto.v_ServiceComponentFieldsId;
            entity.v_ComponentFielName = dto.v_ComponentFielName;
            entity.i_GroupId = dto.i_GroupId;
            entity.v_ComponentId = dto.v_ComponentId;
            entity.v_ServiceComponentId = dto.v_ServiceComponentId;
            entity.v_ComponentFieldsId = dto.v_ComponentFieldsId;
            entity.v_Value1 = dto.v_Value1;
            entity.v_MeasurementUnitName = dto.v_MeasurementUnitName;
            entity.v_Value1Name = dto.v_Value1Name;
            entity.v_Diseases = dto.v_Diseases;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getservicecomponentsreportsc_spResult"/> to an instance of <see cref="getservicecomponentsreportsc_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getservicecomponentsreportsc_spResult"/> to convert.</param>
        public static getservicecomponentsreportsc_spResultDto ToDTO(this getservicecomponentsreportsc_spResult entity)
        {
            if (entity == null) return null;

            var dto = new getservicecomponentsreportsc_spResultDto();

            dto.v_ServiceComponentFieldsId = entity.v_ServiceComponentFieldsId;
            dto.v_ComponentFielName = entity.v_ComponentFielName;
            dto.i_GroupId = entity.i_GroupId;
            dto.v_ComponentId = entity.v_ComponentId;
            dto.v_ServiceComponentId = entity.v_ServiceComponentId;
            dto.v_ComponentFieldsId = entity.v_ComponentFieldsId;
            dto.v_Value1 = entity.v_Value1;
            dto.v_MeasurementUnitName = entity.v_MeasurementUnitName;
            dto.v_Value1Name = entity.v_Value1Name;
            dto.v_Diseases = entity.v_Diseases;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreportsc_spResultDto"/> to an instance of <see cref="getservicecomponentsreportsc_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreportsc_spResult> ToEntities(this IEnumerable<getservicecomponentsreportsc_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getservicecomponentsreportsc_spResult"/> to an instance of <see cref="getservicecomponentsreportsc_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getservicecomponentsreportsc_spResultDto> ToDTOs(this IEnumerable<getservicecomponentsreportsc_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
