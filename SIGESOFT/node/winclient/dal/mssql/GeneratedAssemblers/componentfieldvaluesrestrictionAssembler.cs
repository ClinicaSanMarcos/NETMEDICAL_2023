//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:52:51
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
    /// Assembler for <see cref="componentfieldvaluesrestriction"/> and <see cref="componentfieldvaluesrestrictionDto"/>.
    /// </summary>
    public static partial class componentfieldvaluesrestrictionAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="componentfieldvaluesrestrictionDto"/> converted from <see cref="componentfieldvaluesrestriction"/>.</param>
        static partial void OnDTO(this componentfieldvaluesrestriction entity, componentfieldvaluesrestrictionDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="componentfieldvaluesrestriction"/> converted from <see cref="componentfieldvaluesrestrictionDto"/>.</param>
        static partial void OnEntity(this componentfieldvaluesrestrictionDto dto, componentfieldvaluesrestriction entity);

        /// <summary>
        /// Converts this instance of <see cref="componentfieldvaluesrestrictionDto"/> to an instance of <see cref="componentfieldvaluesrestriction"/>.
        /// </summary>
        /// <param name="dto"><see cref="componentfieldvaluesrestrictionDto"/> to convert.</param>
        public static componentfieldvaluesrestriction ToEntity(this componentfieldvaluesrestrictionDto dto)
        {
            if (dto == null) return null;

            var entity = new componentfieldvaluesrestriction();

            entity.v_ComponentFieldValuesRestrictionId = dto.v_ComponentFieldValuesRestrictionId;
            entity.v_ComponentFieldValuesId = dto.v_ComponentFieldValuesId;
            entity.v_MasterRecommendationRestricctionId = dto.v_MasterRecommendationRestricctionId;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="componentfieldvaluesrestriction"/> to an instance of <see cref="componentfieldvaluesrestrictionDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="componentfieldvaluesrestriction"/> to convert.</param>
        public static componentfieldvaluesrestrictionDto ToDTO(this componentfieldvaluesrestriction entity)
        {
            if (entity == null) return null;

            var dto = new componentfieldvaluesrestrictionDto();

            dto.v_ComponentFieldValuesRestrictionId = entity.v_ComponentFieldValuesRestrictionId;
            dto.v_ComponentFieldValuesId = entity.v_ComponentFieldValuesId;
            dto.v_MasterRecommendationRestricctionId = entity.v_MasterRecommendationRestricctionId;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="componentfieldvaluesrestrictionDto"/> to an instance of <see cref="componentfieldvaluesrestriction"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<componentfieldvaluesrestriction> ToEntities(this IEnumerable<componentfieldvaluesrestrictionDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="componentfieldvaluesrestriction"/> to an instance of <see cref="componentfieldvaluesrestrictionDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<componentfieldvaluesrestrictionDto> ToDTOs(this IEnumerable<componentfieldvaluesrestriction> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
