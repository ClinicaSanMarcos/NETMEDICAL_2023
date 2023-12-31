//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2022/12/23 - 00:58:01
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
    /// Assembler for <see cref="getinformacionpacienteResult"/> and <see cref="getinformacionpacienteResultDto"/>.
    /// </summary>
    public static partial class getinformacionpacienteResultAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="getinformacionpacienteResultDto"/> converted from <see cref="getinformacionpacienteResult"/>.</param>
        static partial void OnDTO(this getinformacionpacienteResult entity, getinformacionpacienteResultDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="getinformacionpacienteResult"/> converted from <see cref="getinformacionpacienteResultDto"/>.</param>
        static partial void OnEntity(this getinformacionpacienteResultDto dto, getinformacionpacienteResult entity);

        /// <summary>
        /// Converts this instance of <see cref="getinformacionpacienteResultDto"/> to an instance of <see cref="getinformacionpacienteResult"/>.
        /// </summary>
        /// <param name="dto"><see cref="getinformacionpacienteResultDto"/> to convert.</param>
        public static getinformacionpacienteResult ToEntity(this getinformacionpacienteResultDto dto)
        {
            if (dto == null) return null;

            var entity = new getinformacionpacienteResult();

            entity.Marketing = dto.Marketing;
            entity.PersonId = dto.PersonId;
            entity.Nombres = dto.Nombres;
            entity.ApellidoPaterno = dto.ApellidoPaterno;
            entity.ApellidoMaterno = dto.ApellidoMaterno;
            entity.TipoDocumentoId = dto.TipoDocumentoId;
            entity.NroDocumento = dto.NroDocumento;
            entity.GeneroId = dto.GeneroId;
            entity.FechaNacimiento = dto.FechaNacimiento;
            entity.EstadoCivil = dto.EstadoCivil;
            entity.LugarNacimiento = dto.LugarNacimiento;
            entity.Distrito = dto.Distrito;
            entity.Provincia = dto.Provincia;
            entity.Departamento = dto.Departamento;
            entity.Reside = dto.Reside;
            entity.Email = dto.Email;
            entity.Direccion = dto.Direccion;
            entity.Puesto = dto.Puesto;
            entity.Altitud = dto.Altitud;
            entity.Minerales = dto.Minerales;
            entity.Estudios = dto.Estudios;
            entity.Grupo = dto.Grupo;
            entity.Factor = dto.Factor;
            entity.TiempoResidencia = dto.TiempoResidencia;
            entity.TipoSeguro = dto.TipoSeguro;
            entity.Vivos = dto.Vivos;
            entity.Muertos = dto.Muertos;
            entity.Hermanos = dto.Hermanos;
            entity.Telefono = dto.Telefono;
            entity.Parantesco = dto.Parantesco;
            entity.Labor = dto.Labor;
            entity.b_FingerPrintTemplate = dto.b_FingerPrintTemplate;
            entity.b_FingerPrintImage = dto.b_FingerPrintImage;
            entity.b_RubricImage = dto.b_RubricImage;
            entity.t_RubricImageText = dto.t_RubricImageText;
            entity.b_PersonImage = dto.b_PersonImage;
            entity.Religion = dto.Religion;
            entity.Nacionalidad = dto.Nacionalidad;
            entity.ResidenciaAnterior = dto.ResidenciaAnterior;
            entity.titular = dto.titular;
            entity.IdHistori = dto.IdHistori;
            entity.N_Historia = dto.N_Historia;
            entity.ContactoEmergencia = dto.ContactoEmergencia;
            entity.CelularEmergencia = dto.CelularEmergencia;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="getinformacionpacienteResult"/> to an instance of <see cref="getinformacionpacienteResultDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="getinformacionpacienteResult"/> to convert.</param>
        public static getinformacionpacienteResultDto ToDTO(this getinformacionpacienteResult entity)
        {
            if (entity == null) return null;

            var dto = new getinformacionpacienteResultDto();

            dto.Marketing = entity.Marketing;
            dto.PersonId = entity.PersonId;
            dto.Nombres = entity.Nombres;
            dto.ApellidoPaterno = entity.ApellidoPaterno;
            dto.ApellidoMaterno = entity.ApellidoMaterno;
            dto.TipoDocumentoId = entity.TipoDocumentoId;
            dto.NroDocumento = entity.NroDocumento;
            dto.GeneroId = entity.GeneroId;
            dto.FechaNacimiento = entity.FechaNacimiento;
            dto.EstadoCivil = entity.EstadoCivil;
            dto.LugarNacimiento = entity.LugarNacimiento;
            dto.Distrito = entity.Distrito;
            dto.Provincia = entity.Provincia;
            dto.Departamento = entity.Departamento;
            dto.Reside = entity.Reside;
            dto.Email = entity.Email;
            dto.Direccion = entity.Direccion;
            dto.Puesto = entity.Puesto;
            dto.Altitud = entity.Altitud;
            dto.Minerales = entity.Minerales;
            dto.Estudios = entity.Estudios;
            dto.Grupo = entity.Grupo;
            dto.Factor = entity.Factor;
            dto.TiempoResidencia = entity.TiempoResidencia;
            dto.TipoSeguro = entity.TipoSeguro;
            dto.Vivos = entity.Vivos;
            dto.Muertos = entity.Muertos;
            dto.Hermanos = entity.Hermanos;
            dto.Telefono = entity.Telefono;
            dto.Parantesco = entity.Parantesco;
            dto.Labor = entity.Labor;
            dto.b_FingerPrintTemplate = entity.b_FingerPrintTemplate;
            dto.b_FingerPrintImage = entity.b_FingerPrintImage;
            dto.b_RubricImage = entity.b_RubricImage;
            dto.t_RubricImageText = entity.t_RubricImageText;
            dto.b_PersonImage = entity.b_PersonImage;
            dto.Religion = entity.Religion;
            dto.Nacionalidad = entity.Nacionalidad;
            dto.ResidenciaAnterior = entity.ResidenciaAnterior;
            dto.titular = entity.titular;
            dto.IdHistori = entity.IdHistori;
            dto.N_Historia = entity.N_Historia;
            dto.ContactoEmergencia = entity.ContactoEmergencia;
            dto.CelularEmergencia = entity.CelularEmergencia;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="getinformacionpacienteResultDto"/> to an instance of <see cref="getinformacionpacienteResult"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<getinformacionpacienteResult> ToEntities(this IEnumerable<getinformacionpacienteResultDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="getinformacionpacienteResult"/> to an instance of <see cref="getinformacionpacienteResultDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<getinformacionpacienteResultDto> ToDTOs(this IEnumerable<getinformacionpacienteResult> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
