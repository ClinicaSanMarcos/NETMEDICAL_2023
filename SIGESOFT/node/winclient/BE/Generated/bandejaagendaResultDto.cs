//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/17 - 08:51:52
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    [DataContract()]
    public partial class bandejaagendaResultDto
    {
        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_DateTimeCalendar { get; set; }

        [DataMember()]
        public String v_Pacient { get; set; }

        [DataMember()]
        public String v_NumberDocument { get; set; }

        [DataMember()]
        public String v_LineStatusName { get; set; }

        [DataMember()]
        public String v_ServiceName { get; set; }

        [DataMember()]
        public String v_CalendarStatusName { get; set; }

        [DataMember()]
        public String v_EsoTypeName { get; set; }

        [DataMember()]
        public String v_ServiceStatusName { get; set; }

        [DataMember()]
        public String v_AptitudeStatusName { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_SalidaCM { get; set; }

        [DataMember()]
        public String v_ServiceTypeName { get; set; }

        [DataMember()]
        public String v_NewContinuationName { get; set; }

        [DataMember()]
        public String v_IsVipName { get; set; }

        [DataMember()]
        public String GESO { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceTypeId { get; set; }

        [DataMember()]
        public String v_ProtocolName { get; set; }

        [DataMember()]
        public String v_OrganizationLocationProtocol { get; set; }

        [DataMember()]
        public String v_WorkingOrganizationName { get; set; }

        [DataMember()]
        public String v_OrganizationLocationService { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_EntryTimeCM { get; set; }

        [DataMember()]
        public String Puesto { get; set; }

        [DataMember()]
        public String Nombres { get; set; }

        [DataMember()]
        public String ApePaterno { get; set; }

        [DataMember()]
        public String ApeMaterno { get; set; }

        [DataMember()]
        public String v_ProtocolId { get; set; }

        [DataMember()]
        public String v_CalendarId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Birthdate { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public String v_DocNumber { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceStatusId { get; set; }

        [DataMember()]
        public String v_CreationUser { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MasterServiceId { get; set; }

        [DataMember()]
        public Double PrecioTotalProtocolo { get; set; }

        [DataMember()]
        public String v_OrganizationId { get; set; }

        [DataMember()]
        public String v_ServiceId1 { get; set; }

        [DataMember()]
        public String v_EmployerOrganizationId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NewContinuationId { get; set; }

        [DataMember()]
        public String v_ComprobantePago { get; set; }

        [DataMember()]
        public String v_NroLiquidacion { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_CircuitStartDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_EntryTimeCM1 { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CalendarStatusId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsVipId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_StatusLiquidation { get; set; }

        [DataMember()]
        public Nullable<Int32> i_LineStatusId { get; set; }

        [DataMember()]
        public String RucEmpFact { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Edad { get; set; }

        [DataMember()]
        public String MEDICO { get; set; }

        [DataMember()]
        public Nullable<Int32> MEDICO_ID { get; set; }

        [DataMember()]
        public String CONSULTORIO { get; set; }

        [DataMember()]
        public String VENDEDOR { get; set; }

        [DataMember()]
        public Double IMPORTE { get; set; }

        [DataMember()]
        public Nullable<Int32> HISTORIA { get; set; }

        [DataMember()]
        public String COMPROBANTE { get; set; }

        [DataMember()]
        public String PROTOCOLO { get; set; }

        [DataMember()]
        public String CONDICION { get; set; }

        [DataMember()]
        public String SERVICIO { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsFac { get; set; }

        [DataMember()]
        public String DETALLE { get; set; }

        [DataMember()]
        public String v_EmergencyPhone { get; set; }

        [DataMember()]
        public String v_ContactName { get; set; }

        [DataMember()]
        public String v_ObservacionesAdicionales { get; set; }

        [DataMember()]
        public String MedicoDerivado { get; set; }

        [DataMember()]
        public String Zona { get; set; }

        [DataMember()]
        public String Establecimiento { get; set; }

        [DataMember()]
        public String VendedorExterno { get; set; }

        [DataMember()]
        public String Sexo { get; set; }

        [DataMember()]
        public String column68 { get; set; }

        public bandejaagendaResultDto()
        {
        }

        public bandejaagendaResultDto(String v_ServiceId, Nullable<DateTime> d_DateTimeCalendar, String v_Pacient, String v_NumberDocument, String v_LineStatusName, String v_ServiceName, String v_CalendarStatusName, String v_EsoTypeName, String v_ServiceStatusName, String v_AptitudeStatusName, Nullable<DateTime> d_SalidaCM, String v_ServiceTypeName, String v_NewContinuationName, String v_IsVipName, String gESO, Nullable<Int32> i_ServiceTypeId, String v_ProtocolName, String v_OrganizationLocationProtocol, String v_WorkingOrganizationName, String v_OrganizationLocationService, Nullable<DateTime> d_EntryTimeCM, String puesto, String nombres, String apePaterno, String apeMaterno, String v_ProtocolId, String v_CalendarId, Nullable<DateTime> d_Birthdate, String v_PersonId, String v_DocNumber, Nullable<Int32> i_ServiceStatusId, String v_CreationUser, Nullable<Int32> i_MasterServiceId, Double precioTotalProtocolo, String v_OrganizationId, String v_ServiceId1, String v_EmployerOrganizationId, Nullable<Int32> i_NewContinuationId, String v_ComprobantePago, String v_NroLiquidacion, Nullable<DateTime> d_CircuitStartDate, Nullable<DateTime> d_EntryTimeCM1, Nullable<Int32> i_CalendarStatusId, Nullable<Int32> i_IsVipId, Nullable<Int32> i_StatusLiquidation, Nullable<Int32> i_LineStatusId, String rucEmpFact, Nullable<Int32> i_Edad, String mEDICO, Nullable<Int32> mEDICO_ID, String cONSULTORIO, String vENDEDOR, Double iMPORTE, Nullable<Int32> hISTORIA, String cOMPROBANTE, String pROTOCOLO, String cONDICION, String sERVICIO, Nullable<Int32> i_IsFac, String dETALLE, String v_EmergencyPhone, String v_ContactName, String v_ObservacionesAdicionales, String medicoDerivado, String zona, String establecimiento, String vendedorExterno, String sexo, String column68)
        {
			this.v_ServiceId = v_ServiceId;
			this.d_DateTimeCalendar = d_DateTimeCalendar;
			this.v_Pacient = v_Pacient;
			this.v_NumberDocument = v_NumberDocument;
			this.v_LineStatusName = v_LineStatusName;
			this.v_ServiceName = v_ServiceName;
			this.v_CalendarStatusName = v_CalendarStatusName;
			this.v_EsoTypeName = v_EsoTypeName;
			this.v_ServiceStatusName = v_ServiceStatusName;
			this.v_AptitudeStatusName = v_AptitudeStatusName;
			this.d_SalidaCM = d_SalidaCM;
			this.v_ServiceTypeName = v_ServiceTypeName;
			this.v_NewContinuationName = v_NewContinuationName;
			this.v_IsVipName = v_IsVipName;
			this.GESO = gESO;
			this.i_ServiceTypeId = i_ServiceTypeId;
			this.v_ProtocolName = v_ProtocolName;
			this.v_OrganizationLocationProtocol = v_OrganizationLocationProtocol;
			this.v_WorkingOrganizationName = v_WorkingOrganizationName;
			this.v_OrganizationLocationService = v_OrganizationLocationService;
			this.d_EntryTimeCM = d_EntryTimeCM;
			this.Puesto = puesto;
			this.Nombres = nombres;
			this.ApePaterno = apePaterno;
			this.ApeMaterno = apeMaterno;
			this.v_ProtocolId = v_ProtocolId;
			this.v_CalendarId = v_CalendarId;
			this.d_Birthdate = d_Birthdate;
			this.v_PersonId = v_PersonId;
			this.v_DocNumber = v_DocNumber;
			this.i_ServiceStatusId = i_ServiceStatusId;
			this.v_CreationUser = v_CreationUser;
			this.i_MasterServiceId = i_MasterServiceId;
			this.PrecioTotalProtocolo = precioTotalProtocolo;
			this.v_OrganizationId = v_OrganizationId;
			this.v_ServiceId1 = v_ServiceId1;
			this.v_EmployerOrganizationId = v_EmployerOrganizationId;
			this.i_NewContinuationId = i_NewContinuationId;
			this.v_ComprobantePago = v_ComprobantePago;
			this.v_NroLiquidacion = v_NroLiquidacion;
			this.d_CircuitStartDate = d_CircuitStartDate;
			this.d_EntryTimeCM1 = d_EntryTimeCM1;
			this.i_CalendarStatusId = i_CalendarStatusId;
			this.i_IsVipId = i_IsVipId;
			this.i_StatusLiquidation = i_StatusLiquidation;
			this.i_LineStatusId = i_LineStatusId;
			this.RucEmpFact = rucEmpFact;
			this.i_Edad = i_Edad;
			this.MEDICO = mEDICO;
			this.MEDICO_ID = mEDICO_ID;
			this.CONSULTORIO = cONSULTORIO;
			this.VENDEDOR = vENDEDOR;
			this.IMPORTE = iMPORTE;
			this.HISTORIA = hISTORIA;
			this.COMPROBANTE = cOMPROBANTE;
			this.PROTOCOLO = pROTOCOLO;
			this.CONDICION = cONDICION;
			this.SERVICIO = sERVICIO;
			this.i_IsFac = i_IsFac;
			this.DETALLE = dETALLE;
			this.v_EmergencyPhone = v_EmergencyPhone;
			this.v_ContactName = v_ContactName;
			this.v_ObservacionesAdicionales = v_ObservacionesAdicionales;
			this.MedicoDerivado = medicoDerivado;
			this.Zona = zona;
			this.Establecimiento = establecimiento;
			this.VendedorExterno = vendedorExterno;
			this.Sexo = sexo;
			this.column68 = column68;
        }
    }
}
