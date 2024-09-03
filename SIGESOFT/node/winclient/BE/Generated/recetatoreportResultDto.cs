//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2024/09/03 - 02:33:49
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
    public partial class recetatoreportResultDto
    {
        [DataMember()]
        public Int32 RecetaId { get; set; }

        [DataMember()]
        public Decimal CantidadRecetada { get; set; }

        [DataMember()]
        public String NombrePaciente { get; set; }

        [DataMember()]
        public DateTime FechaFin { get; set; }

        [DataMember()]
        public String Duracion { get; set; }

        [DataMember()]
        public String Dosis { get; set; }

        [DataMember()]
        public String NombreClinica { get; set; }

        [DataMember()]
        public String DireccionClinica { get; set; }

        [DataMember()]
        public Byte[] LogoClinica { get; set; }

        [DataMember()]
        public Int32 Despacho { get; set; }

        [DataMember()]
        public String MedicinaId { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaNacimiento { get; set; }

        [DataMember()]
        public String v_DiagnosticRepositoryId { get; set; }

        [DataMember()]
        public String USUARIO { get; set; }

        [DataMember()]
        public String ATENCION { get; set; }

        [DataMember()]
        public String ESPECIALIDAD { get; set; }

        [DataMember()]
        public String CAMA { get; set; }

        [DataMember()]
        public String Dx { get; set; }

        [DataMember()]
        public String Cie10 { get; set; }

        [DataMember()]
        public Nullable<DateTime> FechaAtencion { get; set; }

        [DataMember()]
        public String Medicamento { get; set; }

        [DataMember()]
        public String Presentacion { get; set; }

        [DataMember()]
        public String Ubicacion { get; set; }

        public recetatoreportResultDto()
        {
        }

        public recetatoreportResultDto(Int32 recetaId, Decimal cantidadRecetada, String nombrePaciente, DateTime fechaFin, String duracion, String dosis, String nombreClinica, String direccionClinica, Byte[] logoClinica, Int32 despacho, String medicinaId, Nullable<DateTime> fechaNacimiento, String v_DiagnosticRepositoryId, String uSUARIO, String aTENCION, String eSPECIALIDAD, String cAMA, String dx, String cie10, Nullable<DateTime> fechaAtencion, String medicamento, String presentacion, String ubicacion)
        {
			this.RecetaId = recetaId;
			this.CantidadRecetada = cantidadRecetada;
			this.NombrePaciente = nombrePaciente;
			this.FechaFin = fechaFin;
			this.Duracion = duracion;
			this.Dosis = dosis;
			this.NombreClinica = nombreClinica;
			this.DireccionClinica = direccionClinica;
			this.LogoClinica = logoClinica;
			this.Despacho = despacho;
			this.MedicinaId = medicinaId;
			this.FechaNacimiento = fechaNacimiento;
			this.v_DiagnosticRepositoryId = v_DiagnosticRepositoryId;
			this.USUARIO = uSUARIO;
			this.ATENCION = aTENCION;
			this.ESPECIALIDAD = eSPECIALIDAD;
			this.CAMA = cAMA;
			this.Dx = dx;
			this.Cie10 = cie10;
			this.FechaAtencion = fechaAtencion;
			this.Medicamento = medicamento;
			this.Presentacion = presentacion;
			this.Ubicacion = ubicacion;
        }
    }
}
