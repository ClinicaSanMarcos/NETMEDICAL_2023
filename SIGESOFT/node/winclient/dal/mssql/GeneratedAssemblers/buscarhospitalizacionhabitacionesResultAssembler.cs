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
    /// Assembler for <see cref="buscarhospitalizacionhabitacionesResult"/> and <see cref="buscarhospitalizacionhabitacionesResultDto"/>.
    /// </summary>
    public static partial class buscarhospitalizacionhabitacionesResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="buscarhospitalizacionhabitacionesResultDto"/> converted from <see cref="buscarhospitalizacionhabitacionesResult"/>.</param>
        static partial void OnDTO(this buscarhospitalizacionhabitacionesResult entity, buscarhospitalizacionhabitacionesResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="buscarhospitalizacionhabitacionesResult"/> converted from <see cref="buscarhospitalizacionhabitacionesResultDto"/>.</param>
        static partial void OnEntity(this buscarhospitalizacionhabitacionesResultDto dto, buscarhospitalizacionhabitacionesResult entity);

        /// <summary>
        /// Converts this instance of <see cref="buscarhospitalizacionhabitacionesResultDto"/> to an instance of <see cref="buscarhospitalizacionhabitacionesResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="buscarhospitalizacionhabitacionesResultDto"/> to convert.</param>
        public static buscarhospitalizacionhabitacionesResult ToEntity(this buscarhospitalizacionhabitacionesResultDto dto)
        {
            if (dto == null) return null;

            var entity = new buscarhospitalizacionhabitacionesResult();

            entity.v_HospitalizacionHabitacionId = dto.v_HospitalizacionHabitacionId;
            entity.v_HopitalizacionId = dto.v_HopitalizacionId;
            entity.i_HabitacionId = dto.i_HabitacionId;
            entity.NroHabitacion = dto.NroHabitacion;
            entity.d_StartDate = dto.d_StartDate;
            entity.d_EndDate = dto.d_EndDate;
            entity.i_conCargoA = dto.i_conCargoA;
            entity.d_Precio = dto.d_Precio;
            entity.i_isdelete = dto.i_isdelete;
            entity.d_FechaAlta = dto.d_FechaAlta;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="buscarhospitalizacionhabitacionesResult"/> to an instance of <see cref="buscarhospitalizacionhabitacionesResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="buscarhospitalizacionhabitacionesResult"/> to convert.</param>
        public static buscarhospitalizacionhabitacionesResultDto ToDTO(this buscarhospitalizacionhabitacionesResult entity)
        {
            if (entity == null) return null;

            var dto = new buscarhospitalizacionhabitacionesResultDto();

            dto.v_HospitalizacionHabitacionId = entity.v_HospitalizacionHabitacionId;
            dto.v_HopitalizacionId = entity.v_HopitalizacionId;
            dto.i_HabitacionId = entity.i_HabitacionId;
            dto.NroHabitacion = entity.NroHabitacion;
            dto.d_StartDate = entity.d_StartDate;
            dto.d_EndDate = entity.d_EndDate;
            dto.i_conCargoA = entity.i_conCargoA;
            dto.d_Precio = entity.d_Precio;
            dto.i_isdelete = entity.i_isdelete;
            dto.d_FechaAlta = entity.d_FechaAlta;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarhospitalizacionhabitacionesResultDto"/> to an instance of <see cref="buscarhospitalizacionhabitacionesResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<buscarhospitalizacionhabitacionesResult> ToEntities(this IEnumerable<buscarhospitalizacionhabitacionesResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="buscarhospitalizacionhabitacionesResult"/> to an instance of <see cref="buscarhospitalizacionhabitacionesResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<buscarhospitalizacionhabitacionesResultDto> ToDTOs(this IEnumerable<buscarhospitalizacionhabitacionesResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
