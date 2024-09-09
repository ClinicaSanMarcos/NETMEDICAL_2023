//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:51:48
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
    public partial class serviceDto
    {
        [DataMember()]
        public String v_ServiceId { get; set; }

        [DataMember()]
        public String v_ProtocolId { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MasterServiceId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceStatusId { get; set; }

        [DataMember()]
        public String v_Motive { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AptitudeStatusId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ServiceDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_GlobalExpirationDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_ObsExpirationDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_FlagAgentId { get; set; }

        [DataMember()]
        public String v_OrganizationId { get; set; }

        [DataMember()]
        public String v_LocationId { get; set; }

        [DataMember()]
        public String v_MainSymptom { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TimeOfDisease { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TimeOfDiseaseTypeId { get; set; }

        [DataMember()]
        public String v_Story { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DreamId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UrineId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DepositionId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AppetiteId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ThirstId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Fur { get; set; }

        [DataMember()]
        public String v_CatemenialRegime { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MacId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsNewControl { get; set; }

        [DataMember()]
        public Nullable<Int32> i_HasMedicalBreakId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_MedicalBreakStartDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_MedicalBreakEndDate { get; set; }

        [DataMember()]
        public String v_GeneralRecomendations { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DestinationMedicationId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_TransportMedicationId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_StartDateRestriction { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_EndDateRestriction { get; set; }

        [DataMember()]
        public Nullable<Int32> i_HasRestrictionId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_HasSymptomId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_NextAppointment { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SendToTracking { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserMedicalAnalystId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserMedicalAnalystId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDateMedicalAnalyst { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDateMedicalAnalyst { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserOccupationalMedicalId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserOccupationalMedicaltId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDateOccupationalMedical { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDateOccupationalMedical { get; set; }

        [DataMember()]
        public Nullable<Int32> i_HazInterconsultationId { get; set; }

        [DataMember()]
        public String v_Gestapara { get; set; }

        [DataMember()]
        public String v_Menarquia { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_PAP { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Mamografia { get; set; }

        [DataMember()]
        public String v_CiruGine { get; set; }

        [DataMember()]
        public String v_Findings { get; set; }

        [DataMember()]
        public Nullable<Int32> i_StatusLiquidation { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceTypeOfInsurance { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ModalityOfInsurance { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsFac { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InicioEnf { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CursoEnf { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Evolucion { get; set; }

        [DataMember()]
        public String v_ExaAuxResult { get; set; }

        [DataMember()]
        public String v_ObsStatusService { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_FechaEntrega { get; set; }

        [DataMember()]
        public String v_AreaId { get; set; }

        [DataMember()]
        public String v_FechaUltimoPAP { get; set; }

        [DataMember()]
        public String v_ResultadosPAP { get; set; }

        [DataMember()]
        public String v_FechaUltimaMamo { get; set; }

        [DataMember()]
        public String v_ResultadoMamo { get; set; }

        [DataMember()]
        public Nullable<Decimal> r_Costo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_EnvioCertificado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_EnvioHistoria { get; set; }

        [DataMember()]
        public String v_IdVentaCliente { get; set; }

        [DataMember()]
        public String v_IdVentaAseguradora { get; set; }

        [DataMember()]
        public String v_InicioVidaSexaul { get; set; }

        [DataMember()]
        public String v_NroParejasActuales { get; set; }

        [DataMember()]
        public String v_NroAbortos { get; set; }

        [DataMember()]
        public String v_PrecisarCausas { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoTratanteId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsFacMedico { get; set; }

        [DataMember()]
        public String v_centrocosto { get; set; }

        [DataMember()]
        public String v_NroLiquidacion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoPagado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PagoEspecialista { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsControl { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsRevisedHistoryId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_StatusVigilanciaId { get; set; }

        [DataMember()]
        public String v_NroCartaSolicitud { get; set; }

        [DataMember()]
        public String v_ComentaryUpdate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PlanId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AptitudesStatusId_First { get; set; }

        [DataMember()]
        public String v_CommentAptitusStatus_First { get; set; }

        [DataMember()]
        public String v_ComprobantePago { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ServiceUserId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoAtencion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CodigoAtencion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_GrupoAtencion { get; set; }

        [DataMember()]
        public String v_ObservacionesAdicionales { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoDerivado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Zona { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Establecimiento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_VendedorExterno { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MedicoSolicitanteExterno { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ProcedenciaAtencion { get; set; }

        [DataMember()]
        public List<auxiliaryexamDto> auxiliaryexam { get; set; }

        [DataMember()]
        public List<calendarDto> calendar { get; set; }

        [DataMember()]
        public List<diagnosticrepositoryDto> diagnosticrepository { get; set; }

        [DataMember()]
        public List<medicationDto> medication { get; set; }

        [DataMember()]
        public List<procedurebyserviceDto> procedurebyservice { get; set; }

        [DataMember()]
        public List<recommendationDto> recommendation { get; set; }

        [DataMember()]
        public List<restrictionDto> restriction { get; set; }

        [DataMember()]
        public protocolDto protocol { get; set; }

        [DataMember()]
        public personDto person { get; set; }

        [DataMember()]
        public List<servicecomponentDto> servicecomponent { get; set; }

        [DataMember()]
        public List<servicemultimediaDto> servicemultimedia { get; set; }

        [DataMember()]
        public List<vigilanciaserviceDto> vigilanciaservice { get; set; }

        public serviceDto()
        {
        }

        public serviceDto(String v_ServiceId, String v_ProtocolId, String v_PersonId, Nullable<Int32> i_MasterServiceId, Nullable<Int32> i_ServiceStatusId, String v_Motive, Nullable<Int32> i_AptitudeStatusId, Nullable<DateTime> d_ServiceDate, Nullable<DateTime> d_GlobalExpirationDate, Nullable<DateTime> d_ObsExpirationDate, Nullable<Int32> i_FlagAgentId, String v_OrganizationId, String v_LocationId, String v_MainSymptom, Nullable<Int32> i_TimeOfDisease, Nullable<Int32> i_TimeOfDiseaseTypeId, String v_Story, Nullable<Int32> i_DreamId, Nullable<Int32> i_UrineId, Nullable<Int32> i_DepositionId, Nullable<Int32> i_AppetiteId, Nullable<Int32> i_ThirstId, Nullable<DateTime> d_Fur, String v_CatemenialRegime, Nullable<Int32> i_MacId, Nullable<Int32> i_IsNewControl, Nullable<Int32> i_HasMedicalBreakId, Nullable<DateTime> d_MedicalBreakStartDate, Nullable<DateTime> d_MedicalBreakEndDate, String v_GeneralRecomendations, Nullable<Int32> i_DestinationMedicationId, Nullable<Int32> i_TransportMedicationId, Nullable<DateTime> d_StartDateRestriction, Nullable<DateTime> d_EndDateRestriction, Nullable<Int32> i_HasRestrictionId, Nullable<Int32> i_HasSymptomId, Nullable<DateTime> d_UpdateDate, Nullable<DateTime> d_NextAppointment, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<Int32> i_SendToTracking, Nullable<Int32> i_InsertUserMedicalAnalystId, Nullable<Int32> i_UpdateUserMedicalAnalystId, Nullable<DateTime> d_InsertDateMedicalAnalyst, Nullable<DateTime> d_UpdateDateMedicalAnalyst, Nullable<Int32> i_InsertUserOccupationalMedicalId, Nullable<Int32> i_UpdateUserOccupationalMedicaltId, Nullable<DateTime> d_InsertDateOccupationalMedical, Nullable<DateTime> d_UpdateDateOccupationalMedical, Nullable<Int32> i_HazInterconsultationId, String v_Gestapara, String v_Menarquia, Nullable<DateTime> d_PAP, Nullable<DateTime> d_Mamografia, String v_CiruGine, String v_Findings, Nullable<Int32> i_StatusLiquidation, Nullable<Int32> i_ServiceTypeOfInsurance, Nullable<Int32> i_ModalityOfInsurance, Nullable<Int32> i_IsFac, Nullable<Int32> i_InicioEnf, Nullable<Int32> i_CursoEnf, Nullable<Int32> i_Evolucion, String v_ExaAuxResult, String v_ObsStatusService, Nullable<DateTime> d_FechaEntrega, String v_AreaId, String v_FechaUltimoPAP, String v_ResultadosPAP, String v_FechaUltimaMamo, String v_ResultadoMamo, Nullable<Decimal> r_Costo, Nullable<Int32> i_EnvioCertificado, Nullable<Int32> i_EnvioHistoria, String v_IdVentaCliente, String v_IdVentaAseguradora, String v_InicioVidaSexaul, String v_NroParejasActuales, String v_NroAbortos, String v_PrecisarCausas, Nullable<Int32> i_MedicoTratanteId, Nullable<Int32> i_IsFacMedico, String v_centrocosto, String v_NroLiquidacion, Nullable<Int32> i_MedicoPagado, Nullable<Int32> i_PagoEspecialista, Nullable<Int32> i_IsControl, Nullable<Int32> i_IsRevisedHistoryId, Nullable<Int32> i_StatusVigilanciaId, String v_NroCartaSolicitud, String v_ComentaryUpdate, Nullable<Int32> i_PlanId, Nullable<Int32> i_AptitudesStatusId_First, String v_CommentAptitusStatus_First, String v_ComprobantePago, Nullable<Int32> i_ServiceUserId, Nullable<Int32> i_MedicoAtencion, Nullable<Int32> i_CodigoAtencion, Nullable<Int32> i_GrupoAtencion, String v_ObservacionesAdicionales, Nullable<Int32> i_MedicoDerivado, Nullable<Int32> i_Zona, Nullable<Int32> i_Establecimiento, Nullable<Int32> i_VendedorExterno, Nullable<Int32> i_MedicoSolicitanteExterno, Nullable<Int32> i_ProcedenciaAtencion, List<auxiliaryexamDto> auxiliaryexam, List<calendarDto> calendar, List<diagnosticrepositoryDto> diagnosticrepository, List<medicationDto> medication, List<procedurebyserviceDto> procedurebyservice, List<recommendationDto> recommendation, List<restrictionDto> restriction, protocolDto protocol, personDto person, List<servicecomponentDto> servicecomponent, List<servicemultimediaDto> servicemultimedia, List<vigilanciaserviceDto> vigilanciaservice)
        {
			this.v_ServiceId = v_ServiceId;
			this.v_ProtocolId = v_ProtocolId;
			this.v_PersonId = v_PersonId;
			this.i_MasterServiceId = i_MasterServiceId;
			this.i_ServiceStatusId = i_ServiceStatusId;
			this.v_Motive = v_Motive;
			this.i_AptitudeStatusId = i_AptitudeStatusId;
			this.d_ServiceDate = d_ServiceDate;
			this.d_GlobalExpirationDate = d_GlobalExpirationDate;
			this.d_ObsExpirationDate = d_ObsExpirationDate;
			this.i_FlagAgentId = i_FlagAgentId;
			this.v_OrganizationId = v_OrganizationId;
			this.v_LocationId = v_LocationId;
			this.v_MainSymptom = v_MainSymptom;
			this.i_TimeOfDisease = i_TimeOfDisease;
			this.i_TimeOfDiseaseTypeId = i_TimeOfDiseaseTypeId;
			this.v_Story = v_Story;
			this.i_DreamId = i_DreamId;
			this.i_UrineId = i_UrineId;
			this.i_DepositionId = i_DepositionId;
			this.i_AppetiteId = i_AppetiteId;
			this.i_ThirstId = i_ThirstId;
			this.d_Fur = d_Fur;
			this.v_CatemenialRegime = v_CatemenialRegime;
			this.i_MacId = i_MacId;
			this.i_IsNewControl = i_IsNewControl;
			this.i_HasMedicalBreakId = i_HasMedicalBreakId;
			this.d_MedicalBreakStartDate = d_MedicalBreakStartDate;
			this.d_MedicalBreakEndDate = d_MedicalBreakEndDate;
			this.v_GeneralRecomendations = v_GeneralRecomendations;
			this.i_DestinationMedicationId = i_DestinationMedicationId;
			this.i_TransportMedicationId = i_TransportMedicationId;
			this.d_StartDateRestriction = d_StartDateRestriction;
			this.d_EndDateRestriction = d_EndDateRestriction;
			this.i_HasRestrictionId = i_HasRestrictionId;
			this.i_HasSymptomId = i_HasSymptomId;
			this.d_UpdateDate = d_UpdateDate;
			this.d_NextAppointment = d_NextAppointment;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.i_SendToTracking = i_SendToTracking;
			this.i_InsertUserMedicalAnalystId = i_InsertUserMedicalAnalystId;
			this.i_UpdateUserMedicalAnalystId = i_UpdateUserMedicalAnalystId;
			this.d_InsertDateMedicalAnalyst = d_InsertDateMedicalAnalyst;
			this.d_UpdateDateMedicalAnalyst = d_UpdateDateMedicalAnalyst;
			this.i_InsertUserOccupationalMedicalId = i_InsertUserOccupationalMedicalId;
			this.i_UpdateUserOccupationalMedicaltId = i_UpdateUserOccupationalMedicaltId;
			this.d_InsertDateOccupationalMedical = d_InsertDateOccupationalMedical;
			this.d_UpdateDateOccupationalMedical = d_UpdateDateOccupationalMedical;
			this.i_HazInterconsultationId = i_HazInterconsultationId;
			this.v_Gestapara = v_Gestapara;
			this.v_Menarquia = v_Menarquia;
			this.d_PAP = d_PAP;
			this.d_Mamografia = d_Mamografia;
			this.v_CiruGine = v_CiruGine;
			this.v_Findings = v_Findings;
			this.i_StatusLiquidation = i_StatusLiquidation;
			this.i_ServiceTypeOfInsurance = i_ServiceTypeOfInsurance;
			this.i_ModalityOfInsurance = i_ModalityOfInsurance;
			this.i_IsFac = i_IsFac;
			this.i_InicioEnf = i_InicioEnf;
			this.i_CursoEnf = i_CursoEnf;
			this.i_Evolucion = i_Evolucion;
			this.v_ExaAuxResult = v_ExaAuxResult;
			this.v_ObsStatusService = v_ObsStatusService;
			this.d_FechaEntrega = d_FechaEntrega;
			this.v_AreaId = v_AreaId;
			this.v_FechaUltimoPAP = v_FechaUltimoPAP;
			this.v_ResultadosPAP = v_ResultadosPAP;
			this.v_FechaUltimaMamo = v_FechaUltimaMamo;
			this.v_ResultadoMamo = v_ResultadoMamo;
			this.r_Costo = r_Costo;
			this.i_EnvioCertificado = i_EnvioCertificado;
			this.i_EnvioHistoria = i_EnvioHistoria;
			this.v_IdVentaCliente = v_IdVentaCliente;
			this.v_IdVentaAseguradora = v_IdVentaAseguradora;
			this.v_InicioVidaSexaul = v_InicioVidaSexaul;
			this.v_NroParejasActuales = v_NroParejasActuales;
			this.v_NroAbortos = v_NroAbortos;
			this.v_PrecisarCausas = v_PrecisarCausas;
			this.i_MedicoTratanteId = i_MedicoTratanteId;
			this.i_IsFacMedico = i_IsFacMedico;
			this.v_centrocosto = v_centrocosto;
			this.v_NroLiquidacion = v_NroLiquidacion;
			this.i_MedicoPagado = i_MedicoPagado;
			this.i_PagoEspecialista = i_PagoEspecialista;
			this.i_IsControl = i_IsControl;
			this.i_IsRevisedHistoryId = i_IsRevisedHistoryId;
			this.i_StatusVigilanciaId = i_StatusVigilanciaId;
			this.v_NroCartaSolicitud = v_NroCartaSolicitud;
			this.v_ComentaryUpdate = v_ComentaryUpdate;
			this.i_PlanId = i_PlanId;
			this.i_AptitudesStatusId_First = i_AptitudesStatusId_First;
			this.v_CommentAptitusStatus_First = v_CommentAptitusStatus_First;
			this.v_ComprobantePago = v_ComprobantePago;
			this.i_ServiceUserId = i_ServiceUserId;
			this.i_MedicoAtencion = i_MedicoAtencion;
			this.i_CodigoAtencion = i_CodigoAtencion;
			this.i_GrupoAtencion = i_GrupoAtencion;
			this.v_ObservacionesAdicionales = v_ObservacionesAdicionales;
			this.i_MedicoDerivado = i_MedicoDerivado;
			this.i_Zona = i_Zona;
			this.i_Establecimiento = i_Establecimiento;
			this.i_VendedorExterno = i_VendedorExterno;
			this.i_MedicoSolicitanteExterno = i_MedicoSolicitanteExterno;
			this.i_ProcedenciaAtencion = i_ProcedenciaAtencion;
			this.auxiliaryexam = auxiliaryexam;
			this.calendar = calendar;
			this.diagnosticrepository = diagnosticrepository;
			this.medication = medication;
			this.procedurebyservice = procedurebyservice;
			this.recommendation = recommendation;
			this.restriction = restriction;
			this.protocol = protocol;
			this.person = person;
			this.servicecomponent = servicecomponent;
			this.servicemultimedia = servicemultimedia;
			this.vigilanciaservice = vigilanciaservice;
        }
    }
}
