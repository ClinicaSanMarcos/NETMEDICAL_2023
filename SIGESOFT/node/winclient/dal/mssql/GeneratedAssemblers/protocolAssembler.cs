//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:36:06
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
    /// Assembler for <see cref="protocol"/> and <see cref="protocolDto"/>.
    /// </summary>
    public static partial class protocolAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="protocolDto"/> converted from <see cref="protocol"/>.</param>
        static partial void OnDTO(this protocol entity, protocolDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="protocol"/> converted from <see cref="protocolDto"/>.</param>
        static partial void OnEntity(this protocolDto dto, protocol entity);

        /// <summary>
        /// Converts this instance of <see cref="protocolDto"/> to an instance of <see cref="protocol"/>.
        /// </summary>
        /// <param name="dto"><see cref="protocolDto"/> to convert.</param>
        public static protocol ToEntity(this protocolDto dto)
        {
            if (dto == null) return null;

            var entity = new protocol();

            entity.v_ProtocolId = dto.v_ProtocolId;
            entity.v_Name = dto.v_Name;
            entity.v_EmployerOrganizationId = dto.v_EmployerOrganizationId;
            entity.v_EmployerLocationId = dto.v_EmployerLocationId;
            entity.i_EsoTypeId = dto.i_EsoTypeId;
            entity.v_GroupOccupationId = dto.v_GroupOccupationId;
            entity.v_CustomerOrganizationId = dto.v_CustomerOrganizationId;
            entity.v_CustomerLocationId = dto.v_CustomerLocationId;
            entity.v_NombreVendedor = dto.v_NombreVendedor;
            entity.v_WorkingOrganizationId = dto.v_WorkingOrganizationId;
            entity.v_WorkingLocationId = dto.v_WorkingLocationId;
            entity.v_CostCenter = dto.v_CostCenter;
            entity.i_MasterServiceTypeId = dto.i_MasterServiceTypeId;
            entity.i_MasterServiceId = dto.i_MasterServiceId;
            entity.i_HasVigency = dto.i_HasVigency;
            entity.i_ValidInDays = dto.i_ValidInDays;
            entity.i_IsActive = dto.i_IsActive;
            entity.i_IsDeleted = dto.i_IsDeleted;
            entity.i_InsertUserId = dto.i_InsertUserId;
            entity.d_InsertDate = dto.d_InsertDate;
            entity.i_UpdateUserId = dto.i_UpdateUserId;
            entity.d_UpdateDate = dto.d_UpdateDate;
            entity.v_AseguradoraOrganizationId = dto.v_AseguradoraOrganizationId;
            entity.v_ComentaryUpdate = dto.v_ComentaryUpdate;
            entity.r_PriceFactor = dto.r_PriceFactor;
            entity.r_MedicineDiscount = dto.r_MedicineDiscount;
            entity.r_HospitalBedPrice = dto.r_HospitalBedPrice;
            entity.r_ClinicDiscount = dto.r_ClinicDiscount;
            entity.r_DiscountExam = dto.r_DiscountExam;
            entity.i_Consultorio = dto.i_Consultorio;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="protocol"/> to an instance of <see cref="protocolDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="protocol"/> to convert.</param>
        public static protocolDto ToDTO(this protocol entity)
        {
            if (entity == null) return null;

            var dto = new protocolDto();

            dto.v_ProtocolId = entity.v_ProtocolId;
            dto.v_Name = entity.v_Name;
            dto.v_EmployerOrganizationId = entity.v_EmployerOrganizationId;
            dto.v_EmployerLocationId = entity.v_EmployerLocationId;
            dto.i_EsoTypeId = entity.i_EsoTypeId;
            dto.v_GroupOccupationId = entity.v_GroupOccupationId;
            dto.v_CustomerOrganizationId = entity.v_CustomerOrganizationId;
            dto.v_CustomerLocationId = entity.v_CustomerLocationId;
            dto.v_NombreVendedor = entity.v_NombreVendedor;
            dto.v_WorkingOrganizationId = entity.v_WorkingOrganizationId;
            dto.v_WorkingLocationId = entity.v_WorkingLocationId;
            dto.v_CostCenter = entity.v_CostCenter;
            dto.i_MasterServiceTypeId = entity.i_MasterServiceTypeId;
            dto.i_MasterServiceId = entity.i_MasterServiceId;
            dto.i_HasVigency = entity.i_HasVigency;
            dto.i_ValidInDays = entity.i_ValidInDays;
            dto.i_IsActive = entity.i_IsActive;
            dto.i_IsDeleted = entity.i_IsDeleted;
            dto.i_InsertUserId = entity.i_InsertUserId;
            dto.d_InsertDate = entity.d_InsertDate;
            dto.i_UpdateUserId = entity.i_UpdateUserId;
            dto.d_UpdateDate = entity.d_UpdateDate;
            dto.v_AseguradoraOrganizationId = entity.v_AseguradoraOrganizationId;
            dto.v_ComentaryUpdate = entity.v_ComentaryUpdate;
            dto.r_PriceFactor = entity.r_PriceFactor;
            dto.r_MedicineDiscount = entity.r_MedicineDiscount;
            dto.r_HospitalBedPrice = entity.r_HospitalBedPrice;
            dto.r_ClinicDiscount = entity.r_ClinicDiscount;
            dto.r_DiscountExam = entity.r_DiscountExam;
            dto.i_Consultorio = entity.i_Consultorio;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="protocolDto"/> to an instance of <see cref="protocol"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<protocol> ToEntities(this IEnumerable<protocolDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="protocol"/> to an instance of <see cref="protocolDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<protocolDto> ToDTOs(this IEnumerable<protocol> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
