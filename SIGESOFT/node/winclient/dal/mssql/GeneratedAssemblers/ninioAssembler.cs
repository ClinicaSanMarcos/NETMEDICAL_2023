//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/08/29 - 09:00:19
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
    /// Assembler for <see cref="ninio"/> and <see cref="ninioDto"/>.
    /// </summary>
    public static partial class ninioAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ninioDto"/> converted from <see cref="ninio"/>.</param>
        static partial void OnDTO(this ninio entity, ninioDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ninio"/> converted from <see cref="ninioDto"/>.</param>
        static partial void OnEntity(this ninioDto dto, ninio entity);

        /// <summary>
        /// Converts this instance of <see cref="ninioDto"/> to an instance of <see cref="ninio"/>.
        /// </summary>
        /// <param name="dto"><see cref="ninioDto"/> to convert.</param>
        public static ninio ToEntity(this ninioDto dto)
        {
            if (dto == null) return null;

            var entity = new ninio();

            entity.v_NinioId = dto.v_NinioId;
            entity.v_PersonId = dto.v_PersonId;
            entity.v_NombrePadre = dto.v_NombrePadre;
            entity.v_EdadPadre = dto.v_EdadPadre;
            entity.v_DniPadre = dto.v_DniPadre;
            entity.i_TipoAfiliacionPadre = dto.i_TipoAfiliacionPadre;
            entity.v_CodigoAfiliacionPadre = dto.v_CodigoAfiliacionPadre;
            entity.i_GradoInstruccionPadre = dto.i_GradoInstruccionPadre;
            entity.v_OcupacionPadre = dto.v_OcupacionPadre;
            entity.i_EstadoCivilIdPadre = dto.i_EstadoCivilIdPadre;
            entity.v_ReligionPadre = dto.v_ReligionPadre;
            entity.v_NombreMadre = dto.v_NombreMadre;
            entity.v_EdadMadre = dto.v_EdadMadre;
            entity.v_DniMadre = dto.v_DniMadre;
            entity.i_TipoAfiliacionMadre = dto.i_TipoAfiliacionMadre;
            entity.v_CodigoAfiliacionMadre = dto.v_CodigoAfiliacionMadre;
            entity.i_GradoInstruccionMadre = dto.i_GradoInstruccionMadre;
            entity.v_OcupacionMadre = dto.v_OcupacionMadre;
            entity.i_EstadoCivilIdMadre1 = dto.i_EstadoCivilIdMadre1;
            entity.v_ReligionMadre = dto.v_ReligionMadre;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.v_NombreCuidador = dto.v_NombreCuidador;
            entity.v_EdadCuidador = dto.v_EdadCuidador;
            entity.v_DniCuidador = dto.v_DniCuidador;
            entity.v_PatologiasGestacion = dto.v_PatologiasGestacion;
            entity.v_nEmbarazos = dto.v_nEmbarazos;
            entity.v_nAPN = dto.v_nAPN;
            entity.v_LugarAPN = dto.v_LugarAPN;
            entity.v_ComplicacionesParto = dto.v_ComplicacionesParto;
            entity.v_Atencion = dto.v_Atencion;
            entity.v_EdadGestacion = dto.v_EdadGestacion;
            entity.v_Peso = dto.v_Peso;
            entity.v_Talla = dto.v_Talla;
            entity.v_PerimetroCefalico = dto.v_PerimetroCefalico;
            entity.v_PerimetroToracico = dto.v_PerimetroToracico;
            entity.v_EspecificacionesNac = dto.v_EspecificacionesNac;
            entity.v_LME = dto.v_LME;
            entity.v_Mixta = dto.v_Mixta;
            entity.v_Artificial = dto.v_Artificial;
            entity.v_InicioAlimentacionComp = dto.v_InicioAlimentacionComp;
            entity.v_AlergiasMedicamentos = dto.v_AlergiasMedicamentos;
            entity.v_OtrosAntecedentes = dto.v_OtrosAntecedentes;
            entity.v_EspecificacionesAgua = dto.v_EspecificacionesAgua;
            entity.v_EspecificacionesDesague = dto.v_EspecificacionesDesague;
            entity.v_TiempoHospitalizacion = dto.v_TiempoHospitalizacion;
            entity.v_QuienTuberculosis = dto.v_QuienTuberculosis;
            entity.i_QuienTuberculosis = dto.i_QuienTuberculosis;
            entity.v_QuienAsma = dto.v_QuienAsma;
            entity.i_QuienAsma = dto.i_QuienAsma;
            entity.v_QuienVIH = dto.v_QuienVIH;
            entity.i_QuienVIH = dto.i_QuienVIH;
            entity.v_QuienDiabetes = dto.v_QuienDiabetes;
            entity.i_QuienDiabetes = dto.i_QuienDiabetes;
            entity.v_QuienEpilepsia = dto.v_QuienEpilepsia;
            entity.i_QuienEpilepsia = dto.i_QuienEpilepsia;
            entity.v_QuienAlergias = dto.v_QuienAlergias;
            entity.i_QuienAlergias = dto.i_QuienAlergias;
            entity.v_QuienViolenciaFamiliar = dto.v_QuienViolenciaFamiliar;
            entity.i_QuienViolenciaFamiliar = dto.i_QuienViolenciaFamiliar;
            entity.v_QuienAlcoholismo = dto.v_QuienAlcoholismo;
            entity.i_QuienAlcoholismo = dto.i_QuienAlcoholismo;
            entity.v_QuienDrogadiccion = dto.v_QuienDrogadiccion;
            entity.i_QuienDrogadiccion = dto.i_QuienDrogadiccion;
            entity.v_QuienHeptitisB = dto.v_QuienHeptitisB;
            entity.i_QuienHeptitisB = dto.i_QuienHeptitisB;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ninio"/> to an instance of <see cref="ninioDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="ninio"/> to convert.</param>
        public static ninioDto ToDTO(this ninio entity)
        {
            if (entity == null) return null;

            var dto = new ninioDto();

            dto.v_NinioId = entity.v_NinioId;
            dto.v_PersonId = entity.v_PersonId;
            dto.v_NombrePadre = entity.v_NombrePadre;
            dto.v_EdadPadre = entity.v_EdadPadre;
            dto.v_DniPadre = entity.v_DniPadre;
            dto.i_TipoAfiliacionPadre = entity.i_TipoAfiliacionPadre;
            dto.v_CodigoAfiliacionPadre = entity.v_CodigoAfiliacionPadre;
            dto.i_GradoInstruccionPadre = entity.i_GradoInstruccionPadre;
            dto.v_OcupacionPadre = entity.v_OcupacionPadre;
            dto.i_EstadoCivilIdPadre = entity.i_EstadoCivilIdPadre;
            dto.v_ReligionPadre = entity.v_ReligionPadre;
            dto.v_NombreMadre = entity.v_NombreMadre;
            dto.v_EdadMadre = entity.v_EdadMadre;
            dto.v_DniMadre = entity.v_DniMadre;
            dto.i_TipoAfiliacionMadre = entity.i_TipoAfiliacionMadre;
            dto.v_CodigoAfiliacionMadre = entity.v_CodigoAfiliacionMadre;
            dto.i_GradoInstruccionMadre = entity.i_GradoInstruccionMadre;
            dto.v_OcupacionMadre = entity.v_OcupacionMadre;
            dto.i_EstadoCivilIdMadre1 = entity.i_EstadoCivilIdMadre1;
            dto.v_ReligionMadre = entity.v_ReligionMadre;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.v_NombreCuidador = entity.v_NombreCuidador;
            dto.v_EdadCuidador = entity.v_EdadCuidador;
            dto.v_DniCuidador = entity.v_DniCuidador;
            dto.v_PatologiasGestacion = entity.v_PatologiasGestacion;
            dto.v_nEmbarazos = entity.v_nEmbarazos;
            dto.v_nAPN = entity.v_nAPN;
            dto.v_LugarAPN = entity.v_LugarAPN;
            dto.v_ComplicacionesParto = entity.v_ComplicacionesParto;
            dto.v_Atencion = entity.v_Atencion;
            dto.v_EdadGestacion = entity.v_EdadGestacion;
            dto.v_Peso = entity.v_Peso;
            dto.v_Talla = entity.v_Talla;
            dto.v_PerimetroCefalico = entity.v_PerimetroCefalico;
            dto.v_PerimetroToracico = entity.v_PerimetroToracico;
            dto.v_EspecificacionesNac = entity.v_EspecificacionesNac;
            dto.v_LME = entity.v_LME;
            dto.v_Mixta = entity.v_Mixta;
            dto.v_Artificial = entity.v_Artificial;
            dto.v_InicioAlimentacionComp = entity.v_InicioAlimentacionComp;
            dto.v_AlergiasMedicamentos = entity.v_AlergiasMedicamentos;
            dto.v_OtrosAntecedentes = entity.v_OtrosAntecedentes;
            dto.v_EspecificacionesAgua = entity.v_EspecificacionesAgua;
            dto.v_EspecificacionesDesague = entity.v_EspecificacionesDesague;
            dto.v_TiempoHospitalizacion = entity.v_TiempoHospitalizacion;
            dto.v_QuienTuberculosis = entity.v_QuienTuberculosis;
            dto.i_QuienTuberculosis = entity.i_QuienTuberculosis;
            dto.v_QuienAsma = entity.v_QuienAsma;
            dto.i_QuienAsma = entity.i_QuienAsma;
            dto.v_QuienVIH = entity.v_QuienVIH;
            dto.i_QuienVIH = entity.i_QuienVIH;
            dto.v_QuienDiabetes = entity.v_QuienDiabetes;
            dto.i_QuienDiabetes = entity.i_QuienDiabetes;
            dto.v_QuienEpilepsia = entity.v_QuienEpilepsia;
            dto.i_QuienEpilepsia = entity.i_QuienEpilepsia;
            dto.v_QuienAlergias = entity.v_QuienAlergias;
            dto.i_QuienAlergias = entity.i_QuienAlergias;
            dto.v_QuienViolenciaFamiliar = entity.v_QuienViolenciaFamiliar;
            dto.i_QuienViolenciaFamiliar = entity.i_QuienViolenciaFamiliar;
            dto.v_QuienAlcoholismo = entity.v_QuienAlcoholismo;
            dto.i_QuienAlcoholismo = entity.i_QuienAlcoholismo;
            dto.v_QuienDrogadiccion = entity.v_QuienDrogadiccion;
            dto.i_QuienDrogadiccion = entity.i_QuienDrogadiccion;
            dto.v_QuienHeptitisB = entity.v_QuienHeptitisB;
            dto.i_QuienHeptitisB = entity.i_QuienHeptitisB;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ninioDto"/> to an instance of <see cref="ninio"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ninio> ToEntities(this IEnumerable<ninioDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="ninio"/> to an instance of <see cref="ninioDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ninioDto> ToDTOs(this IEnumerable<ninio> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
