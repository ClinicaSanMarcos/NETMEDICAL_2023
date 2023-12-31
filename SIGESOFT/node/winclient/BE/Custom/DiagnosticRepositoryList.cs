﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigesoft.Node.WinClient.BE
{
    public class DiagnosticRepositoryList
    {
        public DiagnosticRepositoryList()
        {
            RecipeDetail = new List<recetaDto>();
        }

        public string v_ComponentName { get; set; }
        public string v_DiseasesName { get; set; }  // diagnostico
        public string v_Cie10 { get; set; }
        public string v_DiagnosticRepositoryId { get; set; }
        public string v_ServiceId { get; set; }
        public string v_ComponentId { get; set; }
        public string v_DiseasesId { get; set; }
        public int? i_AutoManualId { get; set; }
        public int? i_PreQualificationId { get; set; }
        public int? i_FinalQualificationId { get; set; }
        public int? i_DiagnosticTypeId { get; set; }
        public int? i_IsSentToAntecedent { get; set; }
        public DateTime? d_ExpirationDateDiagnostic { get; set; }
        public int? i_GenerateMedicalBreak { get; set; }

        public int? i_RecordStatus { get; set; }
        public int? i_RecordType { get; set; }
   
        public int i_IsDeleted { get; set; }
        public string v_CreationUser { get; set; }
        public string v_UpdateUser { get; set; }
        public DateTime? d_CreationDate { get; set; }
        public DateTime? d_UpdateDate { get; set; }

       
      
        
        public string v_AutoManualName { get; set; }
        public string v_RecomendationsName { get; set; }
        public string v_RestrictionsName { get; set; }
       
        public string v_PreQualificationName { get; set; }
        public string v_FinalQualificationName { get; set; }
        public string v_DiagnosticTypeName { get; set; }
        public string v_IsSentToAntecedentName { get; set; }
        

        // Campos para DX sugeridos por el sistema
        public string v_ComponentFieldValuesId { get; set; }
        public string v_ComponentFieldsId { get; set; }
        public string v_LegalStandard { get; set; }
        public int? i_OperatorId { get; set; }
        public int? i_IsAnormal { get; set; }
        public int? i_ValidationMonths { get; set; }
        public string v_AnalyzingValue1 { get; set; }
        public string v_AnalyzingValue2 { get; set; }

        public string v_ProtocolId { get; set; }
        public string v_ProtocolName { get; set; }
        public DateTime? d_BirthDate { get; set; }
        public string v_PersonId { get; set; }
        public string v_EsoTypeName { get; set; }
        public int i_EsoTypeId_Old { get; set; }
        public string i_EsoTypeId { get; set; }
        public string v_OrganizationPartialName { get; set; }
        public string v_LocationName { get; set; }
        public string v_FirstName { get; set; }
        public string v_FirstLastName { get; set; }
        public string v_SecondLastName { get; set; }
        public string v_GenderName { get; set; }
        public string v_AptitudeStatusName { get; set; }
        public string v_OccupationName { get; set; }

        public string v_OrganizationName { get; set; }
        public string v_PersonName { get; set; }
        public string v_DocNumber { get; set; }
        public int? i_Age { get; set; }

        public int? i_DiagnosticSourceId { get; set; }

        // Accidente laboral
        public int? i_ShapeAccidentId { get; set; }
        public int? i_BodyPartId { get; set; }
        public int? i_ClassificationOfWorkAccidentId { get; set; }

        // Enfermedad laboral
        public int? i_RiskFactorId { get; set; }
        public int? i_ClassificationOfWorkdiseaseId { get; set; }
        public string v_RiskFactorName { get; set; }
        public string v_ClassificationOfWorkdiseaseName { get; set; }

        /////////////////////////////////////////////////////////////

        public string v_DiagnosticSourceName { get; set; }
        public string v_OfficeId { get; set; }
        public string v_OfficeName { get; set; }

      

        public int? i_SendToInterconsultationId { get; set; }
        public string v_InterconsultationDestinationId { get; set; }
        
       
        //
        public List<RecomendationList> Recomendations { get; set; }
        public List<RestrictionList> Restrictions { get; set; }

        public int i_Item { get; set; }

        public byte[] g_Image { get; set; }

        public byte[] b_Logo { get; set; }
        public string EmpresaPropietaria { get; set; }
        public string EmpresaPropietariaDireccion { get; set; }
        public string EmpresaPropietariaTelefono { get; set; }
        public string EmpresaPropietariaEmail { get; set; }

        public string v_ServiceDate { get; set; }
        public DateTime? d_ServiceDate { get; set; }

        public int? i_AptitudeStatusId { get; set; }
        public string v_Dx_CIE10 { get; set; }

        public string v_DocTypeName { get; set; }

        public string pathSinRestriccion { get; set; }
        public string pathConRestriccion { get; set; }
        public string pathObservado { get; set; }
        public string pathNoApto { get; set; }

        public string Grupo { get; set; }
        public string Factor { get; set; }
        public string GrupoFactorSanguineo { get; set; }

        public byte[] LogoPropietaria { get; set; }

        public string Resultado { get; set; }
        public string Categoria { get; set; }

        public int i_CategoryId { get; set; }
        public string v_ObsStatusService { get; set; }
        public byte[] b_Photo { get; set; }

        public string v_ComponentFieldId { get; set; }
        public string v_ComponentFielName { get; set; }
        public string v_Value1 { get; set; }

        public string EmpresaCliente { get; set; }
        public DateTime? d_FechaExpiracionServicio { get; set; }


        public string v_Recomendations { get; set; }
        public int? i_InterconsultationDestinationId { get; set; }

        public string v_Name { get; set; }

        public string v_RecomendacionesConcatenadasDx { get; set; }
        
        public List<recetaDto> RecipeDetail { get; set; }

        public string v_DiseasesNameCie10 { get; set; }
    }

    public class ExamenesAuxiliares
    {
        public string Examen { get; set; }
        public string Categoria { get; set; }
    }
    public class DiagnosticosHistoria
    {
        public string Diagnostico { get; set; }
        public string Recomendaciones { get; set; }
        public string Restricciones { get; set; }
    }

    public class PlanTerapeutico
    {
        public string Medicamento { get; set; }
        public string Cantidad { get; set; }
        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public string FinTto { get; set; }
    }
}
