//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/05/24 - 18:04:14
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
    /// Assembler for <see cref="gerenciacreditoResult"/> and <see cref="gerenciacreditoResultDto"/>.
    /// </summary>
    public static partial class gerenciacreditoResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="gerenciacreditoResultDto"/> converted from <see cref="gerenciacreditoResult"/>.</param>
        static partial void OnDTO(this gerenciacreditoResult entity, gerenciacreditoResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="gerenciacreditoResult"/> converted from <see cref="gerenciacreditoResultDto"/>.</param>
        static partial void OnEntity(this gerenciacreditoResultDto dto, gerenciacreditoResult entity);

        /// <summary>
        /// Converts this instance of <see cref="gerenciacreditoResultDto"/> to an instance of <see cref="gerenciacreditoResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="gerenciacreditoResultDto"/> to convert.</param>
        public static gerenciacreditoResult ToEntity(this gerenciacreditoResultDto dto)
        {
            if (dto == null) return null;

            var entity = new gerenciacreditoResult();

            entity.FechaServicio = dto.FechaServicio;
            entity.ServiceId = dto.ServiceId;
            entity.Trabajador = dto.Trabajador;
            entity.Ocupacion = dto.Ocupacion;
            entity.TipoEso = dto.TipoEso;
            entity.CostoExamen = dto.CostoExamen;
            entity.Compania = dto.Compania;
            entity.Contratista = dto.Contratista;
            entity.Trabajo = dto.Trabajo;
            entity.EmpresaFacturacion = dto.EmpresaFacturacion;
            entity.Comprobante = dto.Comprobante;
            entity.NroLiquidacion = dto.NroLiquidacion;
            entity.FechaFactura = dto.FechaFactura;
            entity.ImporteTotalFactura = dto.ImporteTotalFactura;
            entity.d_NetoXCobrarFactura = dto.d_NetoXCobrarFactura;
            entity.CondicionFactura = dto.CondicionFactura;
            entity.xxx = dto.xxx;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="gerenciacreditoResult"/> to an instance of <see cref="gerenciacreditoResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="gerenciacreditoResult"/> to convert.</param>
        public static gerenciacreditoResultDto ToDTO(this gerenciacreditoResult entity)
        {
            if (entity == null) return null;

            var dto = new gerenciacreditoResultDto();

            dto.FechaServicio = entity.FechaServicio;
            dto.ServiceId = entity.ServiceId;
            dto.Trabajador = entity.Trabajador;
            dto.Ocupacion = entity.Ocupacion;
            dto.TipoEso = entity.TipoEso;
            dto.CostoExamen = entity.CostoExamen;
            dto.Compania = entity.Compania;
            dto.Contratista = entity.Contratista;
            dto.Trabajo = entity.Trabajo;
            dto.EmpresaFacturacion = entity.EmpresaFacturacion;
            dto.Comprobante = entity.Comprobante;
            dto.NroLiquidacion = entity.NroLiquidacion;
            dto.FechaFactura = entity.FechaFactura;
            dto.ImporteTotalFactura = entity.ImporteTotalFactura;
            dto.d_NetoXCobrarFactura = entity.d_NetoXCobrarFactura;
            dto.CondicionFactura = entity.CondicionFactura;
            dto.xxx = entity.xxx;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="gerenciacreditoResultDto"/> to an instance of <see cref="gerenciacreditoResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<gerenciacreditoResult> ToEntities(this IEnumerable<gerenciacreditoResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="gerenciacreditoResult"/> to an instance of <see cref="gerenciacreditoResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<gerenciacreditoResultDto> ToDTOs(this IEnumerable<gerenciacreditoResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
