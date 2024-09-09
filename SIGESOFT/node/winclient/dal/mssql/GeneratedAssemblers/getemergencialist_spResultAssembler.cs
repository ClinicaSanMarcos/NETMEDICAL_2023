//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/09 - 00:20:22
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
    /// Assembler for <see cref="getemergencialist_spResult"/> and <see cref="getemergencialist_spResultDto"/>.
    /// </summary>
    public static partial class getemergencialist_spResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getemergencialist_spResultDto"/> converted from <see cref="getemergencialist_spResult"/>.</param>
        static partial void OnDTO(this getemergencialist_spResult entity, getemergencialist_spResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getemergencialist_spResult"/> converted from <see cref="getemergencialist_spResultDto"/>.</param>
        static partial void OnEntity(this getemergencialist_spResultDto dto, getemergencialist_spResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getemergencialist_spResultDto"/> to an instance of <see cref="getemergencialist_spResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getemergencialist_spResultDto"/> to convert.</param>
        public static getemergencialist_spResult ToEntity(this getemergencialist_spResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getemergencialist_spResult();

            entity.TipoDeIngreso = dto.TipoDeIngreso;
            entity.HoraCita = dto.HoraCita;
            entity.d_FechaIngreso = dto.d_FechaIngreso;
            entity.d_FechaEgreso = dto.d_FechaEgreso;
            entity.v_Paciente = dto.v_Paciente;
            entity.TipoDocumento = dto.TipoDocumento;
            entity.v_DocNumber = dto.v_DocNumber;
            entity.HistoriaClinica = dto.HistoriaClinica;
            entity.Edad = dto.Edad;
            entity.v_Cie10 = dto.v_Cie10;
            entity.v_Diagnostico = dto.v_Diagnostico;
            entity.v_MedicoTratante = dto.v_MedicoTratante;
            entity.Especialidad = dto.Especialidad;
            entity.Hospitalizado = dto.Hospitalizado;
            entity.Value2 = dto.Value2;
            entity.Monto = dto.Monto;
            entity.d_PagoMedico = dto.d_PagoMedico;
            entity.MedicoPago = dto.MedicoPago;
            entity.d_PagoPaciente = dto.d_PagoPaciente;
            entity.PacientePago = dto.PacientePago;
            entity.v_CIE10IdSalida = dto.v_CIE10IdSalida;
            entity.v_DiseasesNameSalida = dto.v_DiseasesNameSalida;
            entity.i_ProcedimientoSOP = dto.i_ProcedimientoSOP;
            entity.v_ProcedimientoSOP = dto.v_ProcedimientoSOP;
            entity.v_Servicio = dto.v_Servicio;
            entity.v_NroLiquidacion = dto.v_NroLiquidacion;
            entity.VendedorExterno = dto.VendedorExterno;
            entity.v_Comentariox = dto.v_Comentariox;
            entity.v_HopitalizacionId = dto.v_HopitalizacionId;
            entity.v_PersonId = dto.v_PersonId;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.Consultorio = dto.Consultorio;
            entity.Value1 = dto.Value1;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getemergencialist_spResult"/> to an instance of <see cref="getemergencialist_spResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getemergencialist_spResult"/> to convert.</param>
        public static getemergencialist_spResultDto ToDTO(this getemergencialist_spResult entity)
        {
            if (entity == null) return null;

            var dto = new getemergencialist_spResultDto();

            dto.TipoDeIngreso = entity.TipoDeIngreso;
            dto.HoraCita = entity.HoraCita;
            dto.d_FechaIngreso = entity.d_FechaIngreso;
            dto.d_FechaEgreso = entity.d_FechaEgreso;
            dto.v_Paciente = entity.v_Paciente;
            dto.TipoDocumento = entity.TipoDocumento;
            dto.v_DocNumber = entity.v_DocNumber;
            dto.HistoriaClinica = entity.HistoriaClinica;
            dto.Edad = entity.Edad;
            dto.v_Cie10 = entity.v_Cie10;
            dto.v_Diagnostico = entity.v_Diagnostico;
            dto.v_MedicoTratante = entity.v_MedicoTratante;
            dto.Especialidad = entity.Especialidad;
            dto.Hospitalizado = entity.Hospitalizado;
            dto.Value2 = entity.Value2;
            dto.Monto = entity.Monto;
            dto.d_PagoMedico = entity.d_PagoMedico;
            dto.MedicoPago = entity.MedicoPago;
            dto.d_PagoPaciente = entity.d_PagoPaciente;
            dto.PacientePago = entity.PacientePago;
            dto.v_CIE10IdSalida = entity.v_CIE10IdSalida;
            dto.v_DiseasesNameSalida = entity.v_DiseasesNameSalida;
            dto.i_ProcedimientoSOP = entity.i_ProcedimientoSOP;
            dto.v_ProcedimientoSOP = entity.v_ProcedimientoSOP;
            dto.v_Servicio = entity.v_Servicio;
            dto.v_NroLiquidacion = entity.v_NroLiquidacion;
            dto.VendedorExterno = entity.VendedorExterno;
            dto.v_Comentariox = entity.v_Comentariox;
            dto.v_HopitalizacionId = entity.v_HopitalizacionId;
            dto.v_PersonId = entity.v_PersonId;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.Consultorio = entity.Consultorio;
            dto.Value1 = entity.Value1;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getemergencialist_spResultDto"/> to an instance of <see cref="getemergencialist_spResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getemergencialist_spResult> ToEntities(this IEnumerable<getemergencialist_spResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getemergencialist_spResult"/> to an instance of <see cref="getemergencialist_spResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getemergencialist_spResultDto> ToDTOs(this IEnumerable<getemergencialist_spResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
