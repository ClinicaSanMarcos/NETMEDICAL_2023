//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/08 - 20:49:53
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
    public partial class devolverdatospaciente_spResultDto
    {
        [DataMember()]
        public String Trabajador { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Birthdate { get; set; }

        [DataMember()]
        public String v_PersonId { get; set; }

        [DataMember()]
        public String v_FirstLastName { get; set; }

        [DataMember()]
        public String v_SecondLastName { get; set; }

        [DataMember()]
        public String v_FirstName { get; set; }

        [DataMember()]
        public String v_BirthPlace { get; set; }

        [DataMember()]
        public String v_DepartamentName { get; set; }

        [DataMember()]
        public String v_ProvinceName { get; set; }

        [DataMember()]
        public String v_DistrictName { get; set; }

        [DataMember()]
        public String v_AdressLocation { get; set; }

        [DataMember()]
        public String GradoInstruccion { get; set; }

        [DataMember()]
        public String v_CentroEducativo { get; set; }

        [DataMember()]
        public String v_MaritalStatus { get; set; }

        [DataMember()]
        public String v_BloodGroupName { get; set; }

        [DataMember()]
        public String v_BloodFactorName { get; set; }

        [DataMember()]
        public String v_IdService { get; set; }

        [DataMember()]
        public String v_OrganitationName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NumberLivingChildren { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaCaducidad { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaActualizacion { get; set; }

        [DataMember()]
        public String N_Informe { get; set; }

        [DataMember()]
        public String v_Religion { get; set; }

        [DataMember()]
        public String v_Nacionalidad { get; set; }

        [DataMember()]
        public String v_ResidenciaAnterior { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DocTypeId { get; set; }

        [DataMember()]
        public String v_OwnerName { get; set; }

        [DataMember()]
        public String v_Employer { get; set; }

        [DataMember()]
        public String v_ContactName { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Relationship { get; set; }

        [DataMember()]
        public String v_EmergencyPhone { get; set; }

        [DataMember()]
        public String Genero { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SexTypeId { get; set; }

        [DataMember()]
        public String v_DocNumber { get; set; }

        [DataMember()]
        public String v_TelephoneNumber { get; set; }

        [DataMember()]
        public String Empresa { get; set; }

        [DataMember()]
        public String v_WorkingOrganizationId { get; set; }

        [DataMember()]
        public String Sede { get; set; }

        [DataMember()]
        public String v_CurrentOccupation { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaServicio { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MaritalStatusId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_PAP { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Mamografia { get; set; }

        [DataMember()]
        public String v_CiruGine { get; set; }

        [DataMember()]
        public String v_Gestapara { get; set; }

        [DataMember()]
        public String v_Menarquia { get; set; }

        [DataMember()]
        public String v_Findings { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_Fur { get; set; }

        [DataMember()]
        public String v_CatemenialRegime { get; set; }

        [DataMember()]
        public Nullable<Int32> i_MacId { get; set; }

        [DataMember()]
        public String v_Mac { get; set; }

        [DataMember()]
        public String v_Story { get; set; }

        [DataMember()]
        public String Aptitud { get; set; }

        [DataMember()]
        public Nullable<Int32> Edad { get; set; }

        [DataMember()]
        public Byte[] b_FirmaAuditor { get; set; }

        [DataMember()]
        public Byte[] FirmaTrabajador { get; set; }

        [DataMember()]
        public Byte[] HuellaTrabajador { get; set; }

        [DataMember()]
        public Byte[] FirmaDoctorAuditor { get; set; }

        [DataMember()]
        public String MedicoGrabaMedicina { get; set; }

        [DataMember()]
        public Byte[] b_FirmaEvaluador { get; set; }

        [DataMember()]
        public String v_PhoneContact { get; set; }

        [DataMember()]
        public String value1 { get; set; }

        [DataMember()]
        public String value2 { get; set; }

        [DataMember()]
        public String value3 { get; set; }

        public devolverdatospaciente_spResultDto()
        {
        }

        public devolverdatospaciente_spResultDto(String trabajador, Nullable<DateTime> d_Birthdate, String v_PersonId, String v_FirstLastName, String v_SecondLastName, String v_FirstName, String v_BirthPlace, String v_DepartamentName, String v_ProvinceName, String v_DistrictName, String v_AdressLocation, String gradoInstruccion, String v_CentroEducativo, String v_MaritalStatus, String v_BloodGroupName, String v_BloodFactorName, String v_IdService, String v_OrganitationName, Nullable<Int32> i_NumberLivingChildren, Nullable<DateTime> fechaCaducidad, Nullable<DateTime> fechaActualizacion, String n_Informe, String v_Religion, String v_Nacionalidad, String v_ResidenciaAnterior, Nullable<Int32> i_DocTypeId, String v_OwnerName, String v_Employer, String v_ContactName, Nullable<Int32> i_Relationship, String v_EmergencyPhone, String genero, Nullable<Int32> i_SexTypeId, String v_DocNumber, String v_TelephoneNumber, String empresa, String v_WorkingOrganizationId, String sede, String v_CurrentOccupation, Nullable<DateTime> fechaServicio, Nullable<Int32> i_MaritalStatusId, Nullable<DateTime> d_PAP, Nullable<DateTime> d_Mamografia, String v_CiruGine, String v_Gestapara, String v_Menarquia, String v_Findings, Nullable<DateTime> d_Fur, String v_CatemenialRegime, Nullable<Int32> i_MacId, String v_Mac, String v_Story, String aptitud, Nullable<Int32> edad, Byte[] b_FirmaAuditor, Byte[] firmaTrabajador, Byte[] huellaTrabajador, Byte[] firmaDoctorAuditor, String medicoGrabaMedicina, Byte[] b_FirmaEvaluador, String v_PhoneContact, String value1, String value2, String value3)
        {
			this.Trabajador = trabajador;
			this.d_Birthdate = d_Birthdate;
			this.v_PersonId = v_PersonId;
			this.v_FirstLastName = v_FirstLastName;
			this.v_SecondLastName = v_SecondLastName;
			this.v_FirstName = v_FirstName;
			this.v_BirthPlace = v_BirthPlace;
			this.v_DepartamentName = v_DepartamentName;
			this.v_ProvinceName = v_ProvinceName;
			this.v_DistrictName = v_DistrictName;
			this.v_AdressLocation = v_AdressLocation;
			this.GradoInstruccion = gradoInstruccion;
			this.v_CentroEducativo = v_CentroEducativo;
			this.v_MaritalStatus = v_MaritalStatus;
			this.v_BloodGroupName = v_BloodGroupName;
			this.v_BloodFactorName = v_BloodFactorName;
			this.v_IdService = v_IdService;
			this.v_OrganitationName = v_OrganitationName;
			this.i_NumberLivingChildren = i_NumberLivingChildren;
			this.FechaCaducidad = fechaCaducidad;
			this.FechaActualizacion = fechaActualizacion;
			this.N_Informe = n_Informe;
			this.v_Religion = v_Religion;
			this.v_Nacionalidad = v_Nacionalidad;
			this.v_ResidenciaAnterior = v_ResidenciaAnterior;
			this.i_DocTypeId = i_DocTypeId;
			this.v_OwnerName = v_OwnerName;
			this.v_Employer = v_Employer;
			this.v_ContactName = v_ContactName;
			this.i_Relationship = i_Relationship;
			this.v_EmergencyPhone = v_EmergencyPhone;
			this.Genero = genero;
			this.i_SexTypeId = i_SexTypeId;
			this.v_DocNumber = v_DocNumber;
			this.v_TelephoneNumber = v_TelephoneNumber;
			this.Empresa = empresa;
			this.v_WorkingOrganizationId = v_WorkingOrganizationId;
			this.Sede = sede;
			this.v_CurrentOccupation = v_CurrentOccupation;
			this.FechaServicio = fechaServicio;
			this.i_MaritalStatusId = i_MaritalStatusId;
			this.d_PAP = d_PAP;
			this.d_Mamografia = d_Mamografia;
			this.v_CiruGine = v_CiruGine;
			this.v_Gestapara = v_Gestapara;
			this.v_Menarquia = v_Menarquia;
			this.v_Findings = v_Findings;
			this.d_Fur = d_Fur;
			this.v_CatemenialRegime = v_CatemenialRegime;
			this.i_MacId = i_MacId;
			this.v_Mac = v_Mac;
			this.v_Story = v_Story;
			this.Aptitud = aptitud;
			this.Edad = edad;
			this.b_FirmaAuditor = b_FirmaAuditor;
			this.FirmaTrabajador = firmaTrabajador;
			this.HuellaTrabajador = huellaTrabajador;
			this.FirmaDoctorAuditor = firmaDoctorAuditor;
			this.MedicoGrabaMedicina = medicoGrabaMedicina;
			this.b_FirmaEvaluador = b_FirmaEvaluador;
			this.v_PhoneContact = v_PhoneContact;
			this.value1 = value1;
			this.value2 = value2;
			this.value3 = value3;
        }
    }
}
