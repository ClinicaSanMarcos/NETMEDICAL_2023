//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/06/04 - 08:46:08
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
    /// Assembler for <see cref="recetatoreportResult"/> and <see cref="recetatoreportResultDto"/>.
    /// </summary>
    public static partial class recetatoreportResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="recetatoreportResultDto"/> converted from <see cref="recetatoreportResult"/>.</param>
        static partial void OnDTO(this recetatoreportResult entity, recetatoreportResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="recetatoreportResult"/> converted from <see cref="recetatoreportResultDto"/>.</param>
        static partial void OnEntity(this recetatoreportResultDto dto, recetatoreportResult entity);

        /// <summary>
        /// Converts this instance of <see cref="recetatoreportResultDto"/> to an instance of <see cref="recetatoreportResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="recetatoreportResultDto"/> to convert.</param>
        public static recetatoreportResult ToEntity(this recetatoreportResultDto dto)
        {
            if (dto == null) return null;

            var entity = new recetatoreportResult();

            entity.RecetaId = dto.RecetaId;
            entity.CantidadRecetada = dto.CantidadRecetada;
            entity.NombrePaciente = dto.NombrePaciente;
            entity.FechaFin = dto.FechaFin;
            entity.Duracion = dto.Duracion;
            entity.Dosis = dto.Dosis;
            entity.NombreClinica = dto.NombreClinica;
            entity.DireccionClinica = dto.DireccionClinica;
            entity.LogoClinica = dto.LogoClinica;
            entity.Despacho = dto.Despacho;
            entity.MedicinaId = dto.MedicinaId;
            entity.FechaNacimiento = dto.FechaNacimiento;
            entity.v_DiagnosticRepositoryId = dto.v_DiagnosticRepositoryId;
            entity.USUARIO = dto.USUARIO;
            entity.ATENCION = dto.ATENCION;
            entity.ESPECIALIDAD = dto.ESPECIALIDAD;
            entity.CAMA = dto.CAMA;
            entity.Dx = dto.Dx;
            entity.Cie10 = dto.Cie10;
            entity.FechaAtencion = dto.FechaAtencion;
            entity.Medicamento = dto.Medicamento;
            entity.Presentacion = dto.Presentacion;
            entity.Ubicacion = dto.Ubicacion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="recetatoreportResult"/> to an instance of <see cref="recetatoreportResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="recetatoreportResult"/> to convert.</param>
        public static recetatoreportResultDto ToDTO(this recetatoreportResult entity)
        {
            if (entity == null) return null;

            var dto = new recetatoreportResultDto();

            dto.RecetaId = entity.RecetaId;
            dto.CantidadRecetada = entity.CantidadRecetada;
            dto.NombrePaciente = entity.NombrePaciente;
            dto.FechaFin = entity.FechaFin;
            dto.Duracion = entity.Duracion;
            dto.Dosis = entity.Dosis;
            dto.NombreClinica = entity.NombreClinica;
            dto.DireccionClinica = entity.DireccionClinica;
            dto.LogoClinica = entity.LogoClinica;
            dto.Despacho = entity.Despacho;
            dto.MedicinaId = entity.MedicinaId;
            dto.FechaNacimiento = entity.FechaNacimiento;
            dto.v_DiagnosticRepositoryId = entity.v_DiagnosticRepositoryId;
            dto.USUARIO = entity.USUARIO;
            dto.ATENCION = entity.ATENCION;
            dto.ESPECIALIDAD = entity.ESPECIALIDAD;
            dto.CAMA = entity.CAMA;
            dto.Dx = entity.Dx;
            dto.Cie10 = entity.Cie10;
            dto.FechaAtencion = entity.FechaAtencion;
            dto.Medicamento = entity.Medicamento;
            dto.Presentacion = entity.Presentacion;
            dto.Ubicacion = entity.Ubicacion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="recetatoreportResultDto"/> to an instance of <see cref="recetatoreportResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<recetatoreportResult> ToEntities(this IEnumerable<recetatoreportResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="recetatoreportResult"/> to an instance of <see cref="recetatoreportResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<recetatoreportResultDto> ToDTOs(this IEnumerable<recetatoreportResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
